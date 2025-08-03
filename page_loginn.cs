using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x0200014D RID: 333
	public partial class page_loginn : Form
	{
		// Token: 0x06000EEC RID: 3820 RVA: 0x002403BC File Offset: 0x0023E5BC
		public page_loginn()
		{
			this.InitializeComponent();
			this.button1.Click += this.ouverture_login;
			this.select_type_cnx();
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x002403F4 File Offset: 0x0023E5F4
		public void ouverture_login(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			page_loginn.res = 0;
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) == "" | fonction.DeleteSpace(this.TextBox2.Text) == "";
			if (flag)
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				string cmdText = "select id, fonction from utilisateur where login = @x1 and mot_passe = @x2 and deleted = @d";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@x1", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@x2", SqlDbType.VarChar).Value = this.TextBox2.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					page_loginn.esm = this.TextBox1.Text;
					page_loginn.res = 1;
					page_loginn.id_user = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
					page_loginn.stat_user = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
					Form1 form = new Form1();
					form.Show();
					base.Hide();
				}
				else
				{
					MessageBox.Show("Erreur : Utilisateur ou mot de passe est incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x00240595 File Offset: 0x0023E795
		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x00240598 File Offset: 0x0023E798
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x0024059B File Offset: 0x0023E79B
		private void page_loginn_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x002405A0 File Offset: 0x0023E7A0
		private void select_type_cnx()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("IBB Local");
			this.radDropDownList1.Items.Add("IBB Distant");
			this.radDropDownList1.Items.Add("NGES Local");
			this.radDropDownList1.Text = "IBB Local";
			page_loginn.bas_connextion = "Data Source = 192.168.1.187; database=GMAO_NGES;User Id=sa;Password=hamza1111; Integrated Security = False";
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x0024061C File Offset: 0x0023E81C
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text == "IBB Local";
			if (flag)
			{
				page_loginn.bas_connextion = "Data Source = 192.168.1.187; database=GMAO_NGES;User Id=sa;Password=hamza1111; Integrated Security = False";
			}
			bool flag2 = this.radDropDownList1.Text == "IBB Distant";
			if (flag2)
			{
				page_loginn.bas_connextion = "Data Source = 41.230.4.199; database=GMAO_NGES;User Id=sa;Password=hamza1111; Integrated Security = False";
			}
			else
			{
				page_loginn.bas_connextion = "Data Source = LAPTOP-N6RLFTG6\\HAMZA; database=GMAO;User Id=sa;Password=hamza1111; Integrated Security = False";
			}
		}

		// Token: 0x040012AF RID: 4783
		public static int res;

		// Token: 0x040012B0 RID: 4784
		public static string esm;

		// Token: 0x040012B1 RID: 4785
		public static int id_user;

		// Token: 0x040012B2 RID: 4786
		public static string stat_user;

		// Token: 0x040012B3 RID: 4787
		public static string bas_connextion = "";
	}
}
