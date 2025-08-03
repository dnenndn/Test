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
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200010A RID: 266
	public partial class prod_param_equipement : Form
	{
		// Token: 0x06000BDF RID: 3039 RVA: 0x001D2360 File Offset: 0x001D0560
		public prod_param_equipement()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x001D23D8 File Offset: 0x001D05D8
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 4;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete prod_equipement where id = @i";
						string cmdText2 = "delete prod_fab_compteur where id_unite = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(0);
					}
				}
			}
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x001D2519 File Offset: 0x001D0719
		private void prod_param_equipement_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
			this.select_unite_production();
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x001D252C File Offset: 0x001D072C
		private void select_unite_production()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Préparation");
			this.radDropDownList1.Items.Add("Fabrication");
			this.radDropDownList1.Items.Add("Four");
			this.radDropDownList1.Items.Add("Emballage");
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x001D25A4 File Offset: 0x001D07A4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radTextBox1.Text) != "" & this.radDropDownList1.Text != "";
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.radTextBox1.Text);
				if (flag2)
				{
					string cmdText = "select id from equipement where id= @i and deleted = @d";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radTextBox1.Text;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						string cmdText2 = "select id  from prod_equipement where id_equipement = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radTextBox1.Text;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count == 0;
						if (flag4)
						{
							string cmdText3 = "insert into prod_equipement (id_equipement, unite_production) values (@v1, @v2)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = this.radTextBox1.Text;
							sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Ajout avec succés");
							this.radTextBox1.Clear();
							this.select_unite_production();
							this.remplissage_tableau(0);
						}
						else
						{
							MessageBox.Show("Erreur : Equipement déja choisie", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : ID Equipement n'existe pas dans votre arbre equipement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : ID Equipement est un nombre strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs Obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x001D280C File Offset: 0x001D0A0C
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select prod_equipement.id, equipement.id, equipement.designation, unite_production from prod_equipement inner join equipement on prod_equipement.id_equipement = equipement.id order by unite_production, equipement.designation";
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
						dataTable.Rows[i].ItemArray[3].ToString(),
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
	}
}
