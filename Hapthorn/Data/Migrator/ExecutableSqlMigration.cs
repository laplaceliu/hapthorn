namespace Hapthorn.Data.Migrator
{
    class ExecutableSqlMigration : IExecutableSqlMigration
    {
        public ExecutableSqlMigration(string id, string sql, string description, int sequenceNumber, string branchSpecification, ISqlMigration instance)
        {
            Id = id;
            Sql = sql;
            Description = description;
            SequenceNumber = sequenceNumber;
            BranchSpecification = branchSpecification;
            SqlMigration = instance;
        }

        public string Id { get; }
        public string Sql { get; }
        public string Description { get; }
        public int SequenceNumber { get; }
        public string BranchSpecification { get; }
        public ISqlMigration SqlMigration { get; }

        public override string ToString()
        {
            const int maxDisplayLength = 80;

            var sql = Sql.Length > maxDisplayLength
                ? Sql.Substring(0, maxDisplayLength) + "..."
                : Sql;

            return $"{Id}: {sql}";
        }
    }
}