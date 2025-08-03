using System;
using System.Data;
using System.Data.SqlClient;

namespace GMAO
{
	// Token: 0x02000027 RID: 39
	internal class bd
	{
		// Token: 0x06000201 RID: 513 RVA: 0x00055288 File Offset: 0x00053488
		public void ouverture_bd(SqlConnection cnx)
		{
			bool flag = cnx.State != ConnectionState.Open;
			if (flag)
			{
				cnx.Open();
			}
		}

		// Token: 0x040002DA RID: 730
		public SqlConnection cnn = new SqlConnection(page_loginn.bas_connextion);
	}
}
