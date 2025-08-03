using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;

namespace GMAO
{
	// Token: 0x020000BF RID: 191
	public partial class ot_general_gamme : Form
	{
		// Token: 0x0600089E RID: 2206 RVA: 0x0016F372 File Offset: 0x0016D572
		public ot_general_gamme()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0016F38C File Offset: 0x0016D58C
		private void ot_general_gamme_Load(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select gamme_operatoire.code, gamme_operatoire.designation from ordre_travail inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id where ordre_travail.id = @i ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[1].ToString();
			}
		}
	}
}
