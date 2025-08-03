using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x0200015D RID: 349
	public partial class refuser_un_da : Form
	{
		// Token: 0x06000F5C RID: 3932 RVA: 0x0025167D File Offset: 0x0024F87D
		public refuser_un_da()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x00251695 File Offset: 0x0024F895
		private void refuser_un_da_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label6.Text = liste_da.id_da;
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x002516BC File Offset: 0x0024F8BC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "update demande_achat set statut = @a where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = 2;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = "insert into da_refuser (id_da, refuser_par, date_refus, heure_refus, cause) values (@i1, @i2, @i3, @i4, @i5)";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
			sqlCommand2.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
			sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
			sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.TextBox1.Text;
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			MessageBox.Show("Succés");
			liste_da.remplissage_tableau(0);
			base.Close();
		}
	}
}
