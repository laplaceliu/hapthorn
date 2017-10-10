namespace Hapthorn.Data.Migrator
{
    public class DatabaseMigratorCore
    {
        readonly string _connectionString;
        readonly IDb _db;
        readonly string _migrationTableName;
    }
}