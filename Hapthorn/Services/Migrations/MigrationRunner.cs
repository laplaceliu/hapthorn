using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Hapthorn.Services.Migrations
{
    public class MigrationRunner
    {
        private IDbConnection DbConnection { get; }
        public Queue<Assembly> MigrationAssemblies { get; } = new Queue<Assembly>();

        public MigrationRunner(IDbConnection dbConnection)
        {
            if (null == dbConnection) throw new ArgumentNullException(nameof(dbConnection));

            DbConnection = dbConnection;
        }

        public MigrationRunner FromAssembly(Assembly assembly)
        {
            if (null == assembly) throw new ArgumentNullException(nameof(assembly));
            this.MigrationAssemblies.Enqueue(assembly);
            return this;
        } 

        public void Run()
        {
        }
    }
}