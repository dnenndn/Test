using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000BB RID: 187
	public partial class ot_general_commentaire : Form
	{
		// Token: 0x0600086F RID: 2159 RVA: 0x0016898D File Offset: 0x00166B8D
		public ot_general_commentaire()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x001689A8 File Offset: 0x00166BA8
		private void radButton1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "update ordre_travail set commentaire = @v where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			MessageBox.Show("Modification avec succés");
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00168A40 File Offset: 0x00166C40
		private void select_commentaire()
		{
			bd bd = new bd();
			string cmdText = "select commentaire from ordre_travail where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
			}
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00168ADB File Offset: 0x00166CDB
		private void ot_general_commentaire_Load(object sender, EventArgs e)
		{
			this.select_commentaire();
		}
	}
}
