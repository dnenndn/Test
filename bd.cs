using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GMAO
{
    internal class bd
    {
        private static string GetConnectionString(string name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings == null)
            {
                throw new ArgumentException($"Connection string '{name}' not found in app.config.");
            }

            return settings.ConnectionString;
        }

        public SqlConnection GetConnection(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        // This method is kept for compatibility with existing code that uses it.
        // A better practice is to open connections right before use and close them immediately after.
		public void ouverture_bd(SqlConnection cnx)
		{
			if (cnx.State != ConnectionState.Open)
			{
				cnx.Open();
			}
		}
    }
}
