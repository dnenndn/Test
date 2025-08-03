using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
	// Token: 0x02000080 RID: 128
	public partial class intervention : Form
	{
		// Token: 0x0600060A RID: 1546 RVA: 0x000FBA70 File Offset: 0x000F9C70
		public intervention()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x000FBAEE File Offset: 0x000F9CEE
		private void intervention_Load(object sender, EventArgs e)
		{
			this.guna2Button2.Hide();
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x000FBB00 File Offset: 0x000F9D00
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Text = "Ajouter";
			this.label2.Text = "Ajouter Intervention";
			this.guna2Button2.Hide();
			this.TextBox1.Clear();
			this.TextBox2.Clear();
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x000FBB54 File Offset: 0x000F9D54
		private void save_intervention()
		{
			fonction fonction = new fonction();
			bool flag = this.TextBox1.Text != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_intervention where code = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into parametre_intervention (code, intervention, deleted) values (@v1, @v2, @v3)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@v3", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					MessageBox.Show("Enregistrement avec succés");
					this.remplissage_tableau(0);
				}
				else
				{
					MessageBox.Show("Erreur : Code d'intervention déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000FBD0C File Offset: 0x000F9F0C
		private void update_intervention()
		{
			fonction fonction = new fonction();
			bool flag = this.TextBox1.Text != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_intervention where code = @i and id <> @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = this.id_c;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "update parametre_intervention set code = @v1, intervention = @v2 where id =@v3";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@v3", SqlDbType.Int).Value = this.id_c;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					this.remplissage_tableau(2);
					this.guna2Button1.Text = "Ajouter";
					this.label2.Text = "Ajouter Intervention";
					this.guna2Button2.Hide();
					this.TextBox1.Clear();
					this.TextBox2.Clear();
				}
				else
				{
					MessageBox.Show("Erreur : Code d'intervention déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x000FBF10 File Offset: 0x000FA110
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 8;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select * from parametre_intervention where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
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
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			bool flag2 = this.radGridView1.Rows.Count != 0;
			if (flag2)
			{
				bool flag3 = o == 0;
				if (flag3)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag4 = o == 1;
				if (flag4)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag5 = o == 2;
				if (flag5)
				{
					this.radGridView1.Rows[intervention.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = intervention.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[intervention.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x000FC1D4 File Offset: 0x000FA3D4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.Text == "Ajouter";
			if (flag)
			{
				this.save_intervention();
			}
			else
			{
				this.update_intervention();
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x000FC210 File Offset: 0x000FA410
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					intervention.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update parametre_intervention set deleted = @d where id = @i";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 3;
					if (flag5)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						this.id_c = text;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Intervention";
						this.guna2Button2.Show();
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x040007F9 RID: 2041
		private string id_c;

		// Token: 0x040007FA RID: 2042
		private static int row_act;
	}
}
