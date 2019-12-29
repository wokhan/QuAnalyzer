using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ProxyClassesGenerator
{
    class Program
    {
        static ProxyGenerator generator = new ProxyGenerator
        {
            NamespaceMappings = {
                //["System.Windows.Controls"] = "Windows.UI.Xaml.Controls",
                //["System.Windows.Media"] = "Windows.UI.Xaml.Media",
                ["System.Windows"] = "Windows.UI.Xaml",
            },
            ClassMappings =
            {
                ["TabItem"] = "PivotItem"
            }
        };

        static void Main(string[] args)
        {
            var dataPath = @"C:\Users\Jérôme\Source\Repos\QuAnalyzer\QuAnalyzer.UWP";
            bool force = true;
            bool onlyTypes = false;
            Regex filter = null;// new Regex("DataGrid|Panel|TabItem|Geometry|DependencyProperty", RegexOptions.Compiled);// "Button";
            Console.WriteLine($"Output dir: {dataPath}");
            var namespaces = new[] {
                "System.Windows"
            };

            var typeslist = new Type[]
            {
                typeof(System.Windows.Controls.DataGrid),
                typeof(System.Windows.Controls.Panel),
                typeof(System.Windows.Controls.TabItem),
                typeof(System.Windows.Media.Geometry),
                typeof(System.Windows.DependencyProperty),
                typeof(System.Windows.Media.SolidColorBrush),
                typeof(System.Windows.RoutedEventArgs)
            };

            var assemblies = new Assembly[] {
                Assembly.Load("WindowsBase"),
                Assembly.Load("PresentationFramework")
            };
            var assFromTypes = typeslist.Select(Assembly.GetAssembly);
            var types = assemblies.Concat(assFromTypes).SelectMany(a => a.ExportedTypes).Distinct();
            List<Type> targets;
            if (onlyTypes)
            {
                targets = typeslist.ToList();
            }
            else
            {
                targets = namespaces.SelectMany(nsp => types.Where(t => (filter?.IsMatch(t.Name) ?? true) && (!t.IsNested || t.IsNestedPublic) && (t.Namespace?.StartsWith(nsp) ?? false))).ToList();
            }
            var totalcnt = targets.Count;
            var cnt = 0;
            var ignored = 0;
            foreach (var targetType in targets.AsParallel())
            {
                Interlocked.Increment(ref cnt);

                var dir = Directory.CreateDirectory(Path.Combine(targetType.Namespace.Split(".").Prepend(dataPath).ToArray()));
                var targetFile = Path.Combine(dir.FullName, $"{targetType.Name}.cs");
                if (!force && File.Exists(targetFile))
                {
                    Interlocked.Increment(ref ignored);
                    Console.WriteLine($"{cnt}/{totalcnt} - Ignoring {targetFile} (already generated).");
                }
                else
                {
                    Console.WriteLine($"{cnt}/{totalcnt} - Generating {targetFile}...");
                    using (var sw = new StreamWriter(targetFile, false, Encoding.UTF8))
                    {
                        sw.Write(generator.Generate(targetType));
                    }
                }
            }

            Console.WriteLine($"Generated {cnt} files, ignored {ignored}.");

            //File.Copy("Proxy.cs", $"{dataPath}\\Proxy.cs");
        }
    }
}
