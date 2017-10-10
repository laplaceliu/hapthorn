using System;

namespace Hapthorn.Data.Migrator
{
    public class MigrationException : Exception
    {
        /// <summary>
        /// Constructs the exception with the given message and inner exception
        /// </summary>
        public MigrationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        /// <summary>
        /// Constructs the exception with the given message
        /// </summary>
        public MigrationException(string message)
            : base(message)
        {
        }
    }
}