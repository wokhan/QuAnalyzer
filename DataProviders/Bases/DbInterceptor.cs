using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text.RegularExpressions;

namespace Wokhan.Data.Providers.Bases
{
    public class DbInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {

        }

        public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {

        }

        public void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            //interceptionContext.Result = null;
        }


        public void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            OverrideCommand(command, interceptionContext);
        }

        private static void OverrideCommand(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            var ictxt = interceptionContext.DbContexts.First() as DBDataProvider.IDynamicDbContext;
            if (ictxt != null)
            {
                command.CommandText = Regex.Replace(command.CommandText.Replace("\"DYNAMICSCHEMA\".\"DYNAMICTABLE\"", " ( " + ictxt.basequery + " ) "), "\".*?\"\\.\"__UID\"", "ROWNUM");
            }
        }

        public void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {

        }

        public void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {

        }
    }
}
