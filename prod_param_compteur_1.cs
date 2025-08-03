using System;
using System.Collections.Generic;
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
	// Token: 0x02000109 RID: 265
	public partial class prod_param_compteur_1 : Form
	{
		// Token: 0x06000BD6 RID: 3030 RVA: 0x001D0DD4 File Offset: 0x001CEFD4
		public prod_param_compteur_1()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x001D0E4C File Offset: 0x001CF04C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 3;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete prod_fab_compteur where id = @i";
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

		// Token: 0x06000BD8 RID: 3032 RVA: 0x001D0F2B File Offset: 0x001CF12B
		private void prod_param_compteur_1_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
			this.select_unite_fabrication();
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x001D0F40 File Offset: 0x001CF140
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select prod_fab_compteur.id, equipement.designation, equipement_compteur.designation from prod_fab_compteur inner join equipement on prod_fab_compteur.id_unite = equipement.id inner join equipement_compteur on prod_fab_compteur.id_compteur = equipement_compteur.id";
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
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x001D10C0 File Offset: 0x001CF2C0
		private void select_unite_fabrication()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select equipement.id, equipement.designation from prod_equipement inner join equipement on prod_equipement.id_equipement = equipement.id where unite_production = @f order by equipement.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Fabrication";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x001D11C8 File Offset: 0x001CF3C8
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.radDropDownList2.Items.Clear();
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				List<int> list = new List<int>();
				int id_prn = Convert.ToInt32(this.radDropDownList1.SelectedItem.Tag);
				fonction.telecharger_tous_id_enfant(id_prn, list);
				string str = string.Join<int>(",", list.ToArray());
				string cmdText = "select id, designation from equipement_compteur where id_equipement in (" + str + ") and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
						this.radDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					}
				}
			}
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x001D1338 File Offset: 0x001CF538
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "" & this.radDropDownList2.Text != "";
			if (flag)
			{
				string cmdText = "select id from prod_fab_compteur where id_unite = @i1 and id_compteur = @i2";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag.ToString();
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag.ToString();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into prod_fab_compteur (id_unite, id_compteur) values (@v1, @v2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag.ToString();
					sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag.ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Ajout avec succés");
					this.remplissage_tableau(0);
					this.select_unite_fabrication();
				}
				else
				{
					MessageBox.Show("Erreur : Le Compteur est déja choisi", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un Champs Obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
