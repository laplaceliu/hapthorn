using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hapthorn.Data.Migrator
{
    public class AssemblyMigrationScanner
    {
        readonly Assembly _assembly;

        public AssemblyMigrationScanner(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IEnumerable<IExecutableSqlMigration> GetMigrations()
        {
            try
            {
                return _assembly
                    .GetTypes()
                    .Select(t => new
                    {
                        Type = t,
                        Attribute = t.GetTypeInfo().GetCustomAttributes(typeof(MigrationAttribute), false)
                            .Cast<MigrationAttribute>()
                            .FirstOrDefault()
                    })
                    .Where(a => a.Attribute != null)
                    .Select(a => new
                    {
                        Type = a.Type,
                        Attribute = a.Attribute,
                        Instance = CreateSqlMigrationInstance(a.Type)
                    })
                    .Select(a => CreateExecutableSqlMigration(a.Attribute, a.Instance))
                    .ToList();

            }
            catch (Exception exception)
            {
                throw new MigrationException(ExceptionHelper.BuildMessage(exception));
            }
        }

        static ISqlMigration CreateSqlMigrationInstance(Type type)
        {
            if (!type.GetTypeInfo().GetInterfaces().Contains(typeof(ISqlMigration)))
            {
                throw new MigrationException($"The type {type} does not implement {typeof(ISqlMigration)}");
            }

            try
            {
                return (ISqlMigration)Activator.CreateInstance(type);
            }
            catch (Exception exception)
            {
                throw new MigrationException($"Could not create instance of {type}", exception);
            }
        }

        static IExecutableSqlMigration CreateExecutableSqlMigration(MigrationAttribute attribute, ISqlMigration instance)
        {
            var sequenceNumber = attribute.SequenceNumber;
            var branchSpecification = attribute.OptionalBranchSpecification ?? "master";
            var id = $"{sequenceNumber}-{branchSpecification}";
            var sql = instance.Sql;
            var description = attribute.Description;

            return new ExecutableSqlMigration(id, sql, description, sequenceNumber, branchSpecification, instance);
        }
    }
}