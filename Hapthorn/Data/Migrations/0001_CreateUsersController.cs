using Migr8;

namespace Hapthorn.Data.Migrations
{
    public class CreateUsersController : ISqlMigration
    {
        public string Sql => @"
CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY,
    loginid varchar(20) NOT NULL,
    
)";
    }
}