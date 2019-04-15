using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Context class for dynamic queries and catalog information
/// </summary>
public class QueryCatalogContext : DbContext
{
    private bool modelProvided;
    /// <summary>
    /// Initializes a new instance of the <see cref="QueryCatalogContext" /> class.
    /// </summary>
    /// <param name="model">The model.</param>
    public QueryCatalogContext(DbCompiledModel model)
        : base("DomainDB", model)
    {
        modelProvided = true;
    }

    /// <summary>
    /// Gets a set of generalized query results.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    public IQueryable<T> GetDynamicQueryResults<T>(Dictionary<string, Type> columns)
    {
        var t = DynamicClassFactory.CreateType(columns.Select(c => new DynamicProperty(c.Key, c.Value)).ToList());
        
        // Build the query and execute
        string sql = string.Format("SELECT VALUE {0} FROM CodeFirstContainer.{0} AS {0}", t.FullName);
        return new ObjectQuery<T>(sql, ((IObjectContextAdapter)this).ObjectContext, MergeOption.NoTracking);
    }



    /// <summary>
    /// Gets the dynamic query results.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    public IQueryable<T> GetDynamicQueryResults<T>(QueryMetadata query, List<ColumnMetadata> columns) where T : class
    {

        // Define a dynamic type and create a configuration for it
        DbModelBuilder builder = new DbModelBuilder(DbModelBuilderVersion.V4_1);
        EntityTypeConfiguration<T> configuration = (EntityTypeConfiguration<T>)Activator.CreateInstance(typeof(DynamicViewConfiguration<>).MakeGenericType(typeof(T)), query, columns);

        // Add configuration for dynamic type
        builder.Configurations.Add(configuration);

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString)) // Only need the connection for building the model;
        {
            // Can't use implicit IDisposable because the context is needed when the IQueryable is evaluated.
            QueryCatalogContext context = new QueryCatalogContext(builder.Build(connection).Compile());
            return context.GetDynamicQueryResults<T>(query);
        }
    }

    /// <summary>
    /// A dynamic entity configuration for views specified at run-time.
    /// </summary>
    public class DynamicViewConfiguration<TDynamic> : EntityTypeConfiguration<TDynamic> where TDynamic : class
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicViewConfiguration" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="columns">The columns.</param>
        public DynamicViewConfiguration(QueryMetadata query, List<ColumnMetadata> columns)
            : base()
        {

            // Locate key column (TODO: Handle multiple key fields)
            ColumnMetadata key = columns.FirstOrDefault(c => c.IsKey) ?? columns[0];
            Activator.CreateInstance(typeof(DynamicViewLambdaGenerator<,>).MakeGenericType(typeof(TDynamic), key.DataType.ClrType), this, key.Name);

            ToTable(query.Name);

        }

    }


    /// <summary>
    /// Internal class to generate lambda expressions for the configuration
    /// </summary>
    internal class DynamicViewLambdaGenerator<TDynamic, TKey> where TDynamic : class
    {

        // TODO: Change to a stateful approach and cache reflection and expressions if usage of this class increases
        private readonly Type type;
        private readonly string keyPropertyName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyLambdaGenerator" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public DynamicViewLambdaGenerator(DynamicViewConfiguration<TDynamic> configuration, string keyPropertyName)
        {
            this.keyPropertyName = keyPropertyName;
            this.type = typeof(TDynamic);

            configuration.HasKey(this.Generate());
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        private Expression<Func<TDynamic, TKey>> Generate()
        {
            PropertyInfo property = type.GetProperty(keyPropertyName);
            ParameterExpression thing = Expression.Parameter(type);
            MemberExpression keyExpression = Expression.Property(thing, property);

            return Expression.Lambda<Func<TDynamic, TKey>>(keyExpression, thing);
        }
    }
}