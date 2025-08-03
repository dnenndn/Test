using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000033 RID: 51
	public partial class bsm_general : Form
	{
		// Token: 0x06000263 RID: 611 RVA: 0x000671C9 File Offset: 0x000653C9
		public bsm_general()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000671F0 File Offset: 0x000653F0
		private void bsm_general_Load(object sender, EventArgs e)
		{
			this.select_intervenant();
			bd bd = new bd();
			string cmdText = "select intervenant.nom, date_bsm, heure_bsm, n_ot from bsm inner join intervenant on bsm.id_receptionniste = intervenant.id where bsm.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = historique_bsm.id_bsm;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList6.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.radDateTimePicker1.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[1].ToString());
				this.vr = Convert.ToDateTime(dataTable.Rows[0].ItemArray[1].ToString());
				this.radTimePicker1.Value = new DateTime?(Convert.ToDateTime(dataTable.Rows[0].ItemArray[2].ToString()));
				bool flag2 = Convert.ToString(dataTable.Rows[0].ItemArray[3]) != "";
				if (flag2)
				{
					this.TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
				}
				else
				{
					this.label10.Hide();
					this.label14.Hide();
					this.TextBox1.Hide();
				}
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00067388 File Offset: 0x00065588
		private void select_intervenant()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, nom from intervenant where deleted = @i order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
				int selectedIndex = 0;
				for (int j = 0; j < this.radDropDownList6.Items.Count; j++)
				{
					bool flag2 = this.radDropDownList6.Items[j].ToString() == this.radDropDownList6.Text;
					if (flag2)
					{
						selectedIndex = j;
					}
				}
				this.radDropDownList6.SelectedIndex = selectedIndex;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000674FC File Offset: 0x000656FC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = !this.TextBox1.Visible | this.test_format_ot() == 1;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "update bsm set id_receptionniste = @i1 ,date_bsm = @i2 ,heure_bsm = @i3 , n_ot = @i4 where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = historique_bsm.id_bsm;
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 8);
				sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.TextBox1.Text;
				string cmdText2 = "update modification_article set date_modification = @h where date_modification = @v and id_article in (select id_article from bsm_article where id_bsm = @i)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@h", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand2.Parameters.Add("@v", SqlDbType.Date).Value = this.vr;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = historique_bsm.id_bsm;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				historique_bsm.remplissage_tableau(2);
				MessageBox.Show("Modification avec succés");
			}
			else
			{
				MessageBox.Show("Erreur : Format de l'OT est incorrecte, le format est de la forme N-N", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000676E0 File Offset: 0x000658E0
		private int test_format_ot()
		{
			int result = 0;
			bool flag = this.TextBox1.Text.Contains("-");
			if (flag)
			{
				int num = this.TextBox1.Text.IndexOf("-");
				num++;
				fonction fonction = new fonction();
				bool flag2 = num != 0 & this.TextBox1.Text.Length > num;
				if (flag2)
				{
					string nombre = fonction.Mid(this.TextBox1.Text, 1, num - 1);
					string nombre2 = fonction.Mid(this.TextBox1.Text, num + 1, this.TextBox1.Text.Length - num);
					bool flag3 = fonction.isnumeric(nombre) & fonction.isnumeric(nombre2);
					if (flag3)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x04000334 RID: 820
		private DateTime vr = default(DateTime);
	}
}
