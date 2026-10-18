using System;
using MySql.Data.MySqlClient;

namespace C969_001340166
{
    // Configuration parsing does not open a connection or resolve a host.
    public static class DatabaseSettings
    {
        public const string VariableName = "APPOINTMENTAGENDA_CONNECTION_STRING";

        public static string ReadConnectionString()
        {
            return Validate(Environment.GetEnvironmentVariable(VariableName));
        }

        public static string Validate(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException("Set " + VariableName + " for your own database. See README.md.");
            try
            {
                var builder = new MySqlConnectionStringBuilder(value);
                if (String.IsNullOrWhiteSpace(builder.Server) || String.IsNullOrWhiteSpace(builder.Database) ||
                    String.IsNullOrWhiteSpace(builder.UserID) || String.IsNullOrWhiteSpace(builder.Password))
                    throw new InvalidOperationException("Database server, database, user ID, and password are required.");
                return builder.ConnectionString;
            }
            catch (ArgumentException)
            {
                // Do not include the invalid value or nested exception; it can contain a password.
                throw new InvalidOperationException("Invalid " + VariableName + ". See README.md.");
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Invalid " + VariableName + ". See README.md.");
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException("Invalid " + VariableName + ". See README.md.");
            }
        }
    }
}
