using Hapthorn.Data.Migrator;

namespace Hapthorn.Data.Migrations
{
    [Migration(1, "My first testing migration.")]
    public class CreateUsersController : ISqlMigration
    {
        public string Sql => @"
CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY,
    loginid varchar(20) NOT NULL
)";
    }
}