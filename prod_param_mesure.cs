using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200010B RID: 267
	public partial class prod_param_mesure : Form
	{
		// Token: 0x06000BE7 RID: 3047 RVA: 0x001D36A4 File Offset: 0x001D18A4
		public prod_param_mesure()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x001D371C File Offset: 0x001D191C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 5;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete prod_mesure where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(0);
					}
				}
			}
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x001D37FB File Offset: 0x001D19FB
		private void prod_param_mesure_Load(object sender, EventArgs e)
		{
			this.select_unite_production();
			this.select_gamme();
			this.remplissage_tableau(0);
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x001D3814 File Offset: 0x001D1A14
		private void select_saisie()
		{
			this.radDropDownList1.Items.Clear();
			bool flag = this.radDropDownList5.Text != "";
			if (flag)
			{
				bd bd = new bd();
				int num = 0;
				int num2 = 0;
				bool flag2 = this.radDropDownList4.Text == "Fabrication";
				if (flag2)
				{
					num = 1;
					num2 = 2;
				}
				bool flag3 = this.radDropDownList4.Text == "Préparation";
				if (flag3)
				{
					num = 4;
					num2 = 5;
				}
				bool flag4 = this.radDropDownList4.Text == "Four";
				if (flag4)
				{
					num = 3;
					num2 = 3;
				}
				string cmdText = "select id, designation from prod_saisie where (cible = @i or cible = @j) and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
				sqlCommand.Parameters.Add("@j", SqlDbType.Int).Value = num2;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag5 = dataTable.Rows.Count != 0;
				if (flag5)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
						this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					}
				}
			}
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x001D39E4 File Offset: 0x001D1BE4
		private void select_gamme()
		{
			bd bd = new bd();
			string cmdText = "select id, designation from gamme_operatoire where deleted = @d and id in(select id_gamme from prev_conditionnelle)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			this.radDropDownList2.Items.Clear();
			this.radDropDownList3.Items.Clear();
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x001D3AFC File Offset: 0x001D1CFC
		private void select_mesure(int id_gamme)
		{
			bd bd = new bd();
			string cmdText = "select id, mesure from prev_conditionnelle where id_gamme = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			this.radDropDownList3.Items.Clear();
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_gamme;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList3.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList3.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x001D3C04 File Offset: 0x001D1E04
		private void radDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList2.Text != "";
			if (flag)
			{
				int id_gamme = Convert.ToInt32(this.radDropDownList2.SelectedItem.Tag);
				this.select_mesure(id_gamme);
			}
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x001D3C4C File Offset: 0x001D1E4C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "" & this.radDropDownList2.Text != "" & this.radDropDownList3.Text != "" & this.radDropDownList4.Text != "" & this.radDropDownList5.Text != "";
			if (flag)
			{
				int num = Convert.ToInt32(this.radDropDownList3.SelectedItem.Tag);
				int num2 = Convert.ToInt32(this.radDropDownList1.SelectedItem.Tag);
				int num3 = Convert.ToInt32(this.radDropDownList5.SelectedItem.Tag);
				bd bd = new bd();
				string cmdText = "insert into prod_mesure (id_mesure, id_saisie, id_unite) values (@i1, @i2, @i3)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = num;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = num2;
				sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = num3;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.select_gamme();
				this.select_unite_production();
				this.remplissage_tableau(0);
			}
			else
			{
				MessageBox.Show("Erreur : Champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x001D3DDC File Offset: 0x001D1FDC
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select prod_mesure.id, prod_saisie.designation, gamme_operatoire.designation, prev_conditionnelle.mesure, equipement.designation from prod_mesure inner join equipement on prod_mesure.id_unite = equipement.id inner join prod_saisie on prod_mesure.id_saisie = prod_saisie.id inner join prev_conditionnelle on prod_mesure.id_mesure = prev_conditionnelle.id inner join gamme_operatoire on prev_conditionnelle.id_gamme = gamme_operatoire.id";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x001D3F9C File Offset: 0x001D219C
		private void select_unite_production()
		{
			this.radDropDownList4.Items.Clear();
			this.radDropDownList4.Items.Add("Préparation");
			this.radDropDownList4.Items.Add("Fabrication");
			this.radDropDownList4.Items.Add("Four");
			this.radDropDownList4.Items.Add("Emballage");
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x001D4014 File Offset: 0x001D2214
		private void select_unite()
		{
			this.radDropDownList5.Items.Clear();
			bool flag = this.radDropDownList4.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id_equipement, equipement.designation from prod_equipement inner join equipement on prod_equipement.id_equipement = equipement.id where unite_production = @u";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@u", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList5.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
						this.radDropDownList5.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					}
				}
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x001D4140 File Offset: 0x001D2340
		private void radDropDownList4_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.select_unite();
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x001D414A File Offset: 0x001D234A
		private void radDropDownList5_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.select_saisie();
		}
	}
}
