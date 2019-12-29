using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ProxyClassesGenerator
{
    public class ProxyGenerator
    {
        public Dictionary<string, string> NamespaceMappings { get; } = new Dictionary<string, string>();
        public Dictionary<string, string> ClassMappings { get; } = new Dictionary<string, string>();

        //public void event Loaded(EventHandler value);// => this.Loaded += value;

        public string Generate(Type baseClass)
        {
            var targetNamespace = GetTargetNamespace(baseClass);
            var realNameForGenerics = baseClass.Name.Split("`")[0];
            var targetName = ClassMappings.GetValueOrDefault(realNameForGenerics, realNameForGenerics);

            IEnumerable<MemberDeclarationSyntax> properties = baseClass.GetProperties()
                     .GroupBy(m => m.Name)
                     .Select(m => m.Count() > 1 ? m.FirstOrDefault(_ => _.DeclaringType == baseClass) ?? m.First() : m.First())
                     .Select(property =>
                     {
                         var prop = PropertyDeclaration(ParseGenericType(property.PropertyType), property.Name)
                                                            .WithModifiers(NonNullTokenList(Token(SyntaxKind.PublicKeyword), (property.GetMethod?.IsStatic ?? false) || (property.SetMethod?.IsStatic ?? false) ? Token(SyntaxKind.StaticKeyword) : (SyntaxToken?)null));

                         if (property.GetMethod != null && property.GetMethod.IsPublic)
                         {
                             prop = prop.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                                                .WithExpressionBody(ArrowExpressionClause(ParseExpression($"__ProxyValue.{property.Name}")))
                                                                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));

                         }
                         if (property.SetMethod != null && property.SetMethod.IsPublic)
                         {
                             prop = prop.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                                            .WithExpressionBody(ArrowExpressionClause(ParseExpression($"__ProxyValue.{property.Name} = value")))
                                                            .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
                         }
                         return prop;
                     });

            var excludedMethods = new[] { "GetType" };
            var methods = baseClass.GetMethods().Where(m => !excludedMethods.Contains(m.Name) && !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_"))
                                                .GroupBy(m => (m.Name, m.GetParameters().Select(p => p.ParameterType.FullName)))
                                                .Select(m => m.Count() > 1 ? m.FirstOrDefault(_ => _.DeclaringType == baseClass) ?? m.First() : m.First())
                                                .Select(method =>
                                                {
                                                    var meth = MethodDeclaration(ParseGenericType(method.ReturnType, false), method.Name)
                                                                 .WithModifiers(NonNullTokenList(Token(SyntaxKind.PublicKeyword),
                                                                                            method.GetBaseDefinition().DeclaringType == typeof(object) ? Token(SyntaxKind.OverrideKeyword) : (SyntaxToken?)null,
                                                                                          method.GetCustomAttribute<AsyncStateMachineAttribute>() != null ? Token(SyntaxKind.AsyncKeyword) : (SyntaxToken?)null,
                                                                                          method.IsStatic ? Token(SyntaxKind.StaticKeyword) : (SyntaxToken?)null))
                                                                 .AddParameterListParameters(method.GetParameters().Select(prm => Parameter(ParseIdentifier(prm.Name)).WithType(ParseGenericType(prm.ParameterType)).WithModifiers(NonNullTokenList(prm.IsOut ? Token(SyntaxKind.OutKeyword) : (SyntaxToken?)null))).ToArray())
                                                                 .WithExpressionBody(ArrowExpressionClause(InvocationExpression(IdentifierName((method.IsStatic ? $"{targetNamespace}.{baseClass.Name}" : "__ProxyValue") + $".{method.Name}"))//method.IsGenericMethod ? (ExpressionSyntax)GenericName($"__ProxyValue.{method.Name}").WithTypeArgumentList(TypeArgumentList(SeparatedList<TypeSyntax>(method.GetGenericArguments().Select(arg => IdentifierName(arg.Name))))) : IdentifierName($"__ProxyValue.{method.Name}"))
                                                                                    .AddArgumentListArguments(method.GetParameters().Select(prm => Argument(IdentifierName("@" + prm.Name))).ToArray())))
                                                                 .WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
                                                    if (method.IsGenericMethod)
                                                    {
                                                        meth = meth.AddTypeParameterListParameters(method.GetGenericArguments().Select(arg => TypeParameter(arg.Name)).ToArray());
                                                    }
                                                    return meth;
                                                });

            var constructors = baseClass.GetConstructors()
                                        .Select(ctor =>
            {
                var meth = ConstructorDeclaration(baseClass.Name)
                             .AddModifiers(Token(SyntaxKind.PublicKeyword))
                             .AddParameterListParameters(ctor.GetParameters().Select(prm => Parameter(Identifier("@" + prm.Name)).WithType(ParseGenericType(prm.ParameterType))).ToArray())
                             .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer).AddArgumentListArguments(ctor.GetParameters().Select(prm => Argument(IdentifierName("@" + prm.Name))).ToArray()))
                             .WithBody(Block());
                if (ctor.IsStatic)
                {
                    meth = meth.AddModifiers(Token(SyntaxKind.StaticKeyword));
                }

                return meth;
            });
            var classDeclaration = ClassDeclaration(baseClass.Name)
                                                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                                                .AddMembers(properties.Concat(constructors).Concat(methods).ToArray());

            if (baseClass.IsGenericType)
            {
                classDeclaration = classDeclaration.AddTypeParameterListParameters(baseClass.GetGenericArguments().Select(arg => TypeParameter(arg.Name)).ToArray())
                                                   .AddBaseListTypes(SimpleBaseType(ParseTypeName($"Proxy<global::{targetNamespace}.{targetName}<{String.Join(",", baseClass.GetGenericArguments().Select(arg => TypeParameter(arg.Name)))}>> ")));
            }
            else
            {
                classDeclaration = classDeclaration.AddBaseListTypes(SimpleBaseType(ParseTypeName($"Proxy<global::{targetNamespace}.{targetName}>")));
            }

            return NamespaceDeclaration(ParseName($"{baseClass.Namespace}"))
                          .AddUsings(UsingDirective(ParseName("Uno.UI.Generic")))
                          .AddMembers(classDeclaration)
                          .NormalizeWhitespace()
                          .ToFullString();

        }

        private SyntaxToken ParseIdentifier(string v)
        {
            var ret = Identifier(v);
            if (ret.IsReservedKeyword())
            {
                ret = Identifier($"@{v}");
            }

            return ret;
        }

        private SyntaxTokenList NonNullTokenList(params SyntaxToken?[] tokens)
        {
            return TokenList(tokens.Where(_ => _ != null).Select(_ => _.Value).ToArray());
        }

        private string GetTargetNamespace(Type baseClass)
        {
            var targetNSKey = NamespaceMappings.Keys.FirstOrDefault(k => baseClass.Namespace.StartsWith(k));
            string targetNamespace;
            if (targetNSKey != null)
            {
                targetNamespace = baseClass.Namespace.Replace(targetNSKey, NamespaceMappings[targetNSKey]);
            }
            else
            {
                targetNamespace = baseClass.Namespace;
            }

            return targetNamespace;
        }

        private NameSyntax ParseGenericType(Type prm)
        {
            return ParseGenericType(prm, false);
        }

        private NameSyntax ParseGenericType(Type prm, bool isTarget)
        {
            if (prm.IsGenericParameter)
            {
                return IdentifierName(prm.Name.TrimEnd('&'));
            }

            if (prm.FullName == "System.Void")
            {
                return IdentifierName("void");
            }

            //var newNS = isTarget ? "global::" + GetTargetNamespace(prm) : prm.Namespace;
            var newNS = prm.Namespace;
            if (prm.IsGenericType || (prm.IsArray && prm.GetElementType().IsGenericType))
            {
                return GenericName(Identifier($"{newNS}.{prm.Name.Split('`')[0]}"))
                                .WithTypeArgumentList(
                                    TypeArgumentList(
                                        SeparatedList(prm.GetGenericArguments().Select(ParseGenericType).Cast<SyntaxNode>().ToArray())));
            }

            return IdentifierName($"{newNS}.{prm.Name}".TrimEnd('&'));
        }

        public static string GenerateCodeDom(Type baseClass, string targetNamespace)
        {
            /*if (!baseClass.IsSealed)
            {
                return GenerateStandard(baseClass);
            }*/

            var newClass = new CodeTypeDeclaration(baseClass.Name)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
                BaseTypes = { new CodeTypeReference("Proxy", MakeTypeReference(baseClass)) }
            };

            //Add type arguments (if the interface is generic)
            if (baseClass.IsGenericType)
                foreach (var genericArgumentType in baseClass.GetGenericArguments())
                    newClass.TypeParameters.Add(genericArgumentType.Name);

            //Loop through each method
            foreach (var mi in baseClass.GetProperties())
            {
                var method = new CodeMemberProperty
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    Name = mi.Name

                };
            }

            foreach (var mi in baseClass.GetMethods().Where(m => m.Name.StartsWith("get_") || m.Name.StartsWith("set_")))
            {
                //Create the method
                var method = new CodeMemberMethod
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    Name = mi.Name,
                    ReturnType = MakeTypeReference(mi.ReturnType)
                };

                //Add any generic types
                if (mi.IsGenericMethod)
                    foreach (var genericParameter in mi.GetGenericArguments())
                        method.TypeParameters.Add(genericParameter.Name);

                //Add the parameters
                foreach (var par in mi.GetParameters())
                    method.Parameters.Add(new CodeParameterDeclarationExpression(MakeTypeReference(par.ParameterType), par.Name));

                //Call the same method on the base passing all the parameters
                var allParameters = mi.GetParameters().Select(p => new CodeArgumentReferenceExpression(p.Name)).ToArray();
                var callBase = new CodeMethodInvokeExpression(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "__ProxyValue"), mi.Name, allParameters);

                //If the method is void, we just call base
                if (mi.ReturnType == typeof(void))
                    method.Statements.Add(callBase);
                else
                    //Otherwise, we return the value from the call to base
                    method.Statements.Add(new CodeMethodReturnStatement(callBase));

                //Add the method to our class
                newClass.Members.Add(method);
            }

            //TODO: Also add properties if needed?

            //Make a "CompileUnit" that has a namespace with some 'usings' and then
            //  our new class.
            var unit = new CodeCompileUnit
            {
                Namespaces =
                {
                    new CodeNamespace(targetNamespace)
                    {
                        /*Imports =
                        {
                            new CodeNamespaceImport("System"),
                            new CodeNamespaceImport("System.Linq.Expressions")
                        },*/
                        Types = { newClass }
                    }
                }
            };

            //Use the C# prvider to get a code generator and generate the code
            //Switch this to VBCodeProvider to generate VB Code
            var gen = new CSharpCodeProvider().CreateGenerator();
            using (var tw = new StringWriter())
            {
                gen.GenerateCodeFromCompileUnit(unit, tw, new CodeGeneratorOptions());
                return tw.ToString();
            }
        }

        /// <summary>
        /// Helper method for expanding out a type with all it's generic types.
        /// It seems like there should be an easier way to do this but this work.
        /// </summary>
        private static CodeTypeReference MakeTypeReference(Type type)
        {
            //If the Type isn't generic, just wrap is directly
            if (!type.IsGenericType)
            {
                return new CodeTypeReference(type);
            }

            //Otherwise wrap it but also pass the generic arguments (recursively calling this method
            //  on all the type arguments.
            return new CodeTypeReference(type.Name, type.GetGenericArguments().Select(MakeTypeReference).ToArray());
        }
    }
}
