using System;
using System.Data;
using System.Data.SqlClient;

namespace GMAO
{
	// Token: 0x0200016C RID: 364
	internal class update_tableau
	{
		// Token: 0x06001057 RID: 4183 RVA: 0x002968A0 File Offset: 0x00294AA0
		public static void modifier_varchar(string tab_name, int id, string col_name, string val)
		{
			bd bd = new bd();
			string cmdText = string.Concat(new string[]
			{
				"update ",
				tab_name,
				" set ",
				col_name,
				" =  @v where id = @i"
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = val;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x00296944 File Offset: 0x00294B44
		public static void modifier_varReal(string tab_name, int id, string col_name, double val)
		{
			bd bd = new bd();
			string cmdText = string.Concat(new string[]
			{
				"update ",
				tab_name,
				" set ",
				col_name,
				" =  @v where id = @i"
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@v", SqlDbType.Real).Value = val;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}
	}
}
