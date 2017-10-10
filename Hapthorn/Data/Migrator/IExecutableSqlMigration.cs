namespace Hapthorn.Data.Migrator
{
    public interface IExecutableSqlMigration
    {
        string Id { get; }
        string Sql { get; }
        string Description { get; }
        int SequenceNumber { get; }
        string BranchSpecification { get; }
        ISqlMigration SqlMigration { get; }
    }
}