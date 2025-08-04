using System;
using System.Data.SqlClient;
using System.Configuration;

namespace GMAO
{
    public class bd
    {
        public SqlConnection cnn;

        public bd()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GMAO.Properties.Settings.Setting"].ConnectionString;
            this.cnn = new SqlConnection(connectionString);
        }

        public void ouverture_bd(SqlConnection cnn)
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
        }
    }
}
