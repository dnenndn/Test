using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200015E RID: 350
	public partial class reporter_un_da : Form
	{
		// Token: 0x06000F61 RID: 3937 RVA: 0x00251E7F File Offset: 0x0025007F
		public reporter_un_da()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x00251E98 File Offset: 0x00250098
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "update demande_achat set statut = @u where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@u", SqlDbType.Int).Value = 4;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = "insert into da_reporter (id_da, reporter_par, date_report, heure_report, nouvel_date) values (@i1, @i2, @i3, @i4, @i5)";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
			sqlCommand2.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
			sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
			sqlCommand2.Parameters.Add("@i5", SqlDbType.Date).Value = this.radDateTimePicker1.Text;
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			MessageBox.Show("Succés");
			liste_da.remplissage_tableau(0);
			base.Close();
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x0025200E File Offset: 0x0025020E
		private void reporter_un_da_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label6.Text = liste_da.id_da;
			this.radDateTimePicker1.Value = DateTime.Today;
		}
	}
}
