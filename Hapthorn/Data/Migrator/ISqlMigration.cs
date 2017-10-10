namespace Hapthorn.Data.Migrator
{
    public interface ISqlMigration
    {
        /// <summary>
        /// Should return one or more SQL statements. Multiple statements can be separated by GO.
        /// </summary>
        string Sql { get; } 
    }
}