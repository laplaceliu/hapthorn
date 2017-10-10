using System;
using System.Data;

namespace Hapthorn.Data
{
    public static class DbConnectionExtensions
    {
        public static bool CanOpen(this IDbConnection connection)
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}