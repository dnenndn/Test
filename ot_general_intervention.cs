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
	// Token: 0x020000C0 RID: 192
	public partial class ot_general_intervention : Form
	{
		// Token: 0x060008A2 RID: 2210 RVA: 0x0016FB2C File Offset: 0x0016DD2C
		public ot_general_intervention()
		{
			this.InitializeComponent();
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0016FB44 File Offset: 0x0016DD44
		private void ot_general_intervention_Load(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select parametre_intervention.code, parametre_intervention.intervention from ordre_travail inner join parametre_intervention on ordre_travail.id_intervention = parametre_intervention.id where ordre_travail.id = @i ";
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
