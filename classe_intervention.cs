using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200003B RID: 59
	public partial class classe_intervention : Form
	{
		// Token: 0x0600029C RID: 668 RVA: 0x0006EE3C File Offset: 0x0006D03C
		public classe_intervention()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0006EEBA File Offset: 0x0006D0BA
		private void classe_intervention_Load(object sender, EventArgs e)
		{
			this.guna2Button2.Hide();
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0006EECC File Offset: 0x0006D0CC
		private void save_classe_intervention()
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_classe_intervention where code = @v1 or designation = @v2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into parametre_classe_intervention (code, designation) values (@v1, @v2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Enregistrement avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.remplissage_tableau(0);
				}
				else
				{
					MessageBox.Show("Erreur : Classe d'intervention déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0006F090 File Offset: 0x0006D290
		private void update_classe_intervention(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_classe_intervention where id <> @i and (code = @v1 or designation = @v2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_c;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "update parametre_classe_intervention set code = @v1, designation = @v2 where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_c;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.guna2Button2_Click(sender, e);
					this.remplissage_tableau(2);
				}
				else
				{
					MessageBox.Show("Erreur : Classe d'intervention déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0006F298 File Offset: 0x0006D498
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.Text == "Ajouter";
			if (flag)
			{
				this.save_classe_intervention();
			}
			else
			{
				this.update_classe_intervention(sender, e);
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0006F2D8 File Offset: 0x0006D4D8
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select * from parametre_classe_intervention";
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
					this.radGridView1.Rows[classe_intervention.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = classe_intervention.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[classe_intervention.row_act - 1].IsCurrent = true;
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

		// Token: 0x060002A2 RID: 674 RVA: 0x0006F57D File Offset: 0x0006D77D
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Text = "Ajouter";
			this.label2.Text = "Ajouter Classe d'intervention";
			this.guna2Button2.Hide();
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0006F5B0 File Offset: 0x0006D7B0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					classe_intervention.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "delete parametre_classe_intervention where id = @i";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
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
						this.label2.Text = "Modifier Classe d'intervention";
						this.guna2Button2.Show();
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x04000381 RID: 897
		private string id_c;

		// Token: 0x04000382 RID: 898
		private static int row_act;
	}
}
