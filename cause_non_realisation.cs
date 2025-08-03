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
	// Token: 0x02000037 RID: 55
	public partial class cause_non_realisation : Form
	{
		// Token: 0x0600027E RID: 638 RVA: 0x0006AD78 File Offset: 0x00068F78
		public cause_non_realisation()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0006ADF6 File Offset: 0x00068FF6
		private void cause_non_realisation_Load(object sender, EventArgs e)
		{
			this.guna2Button2.Hide();
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0006AE08 File Offset: 0x00069008
		private void save_cause()
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_cause_realisation where code = @v1 or designation = @v2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into parametre_cause_realisation (code, designation) values (@v1, @v2)";
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
					MessageBox.Show("Erreur : Cause déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0006AFCC File Offset: 0x000691CC
		private void update_cause(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_cause_realisation where id <> @i and (code = @v1 or designation = @v2)";
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
					string cmdText2 = "update parametre_cause_realisation set code = @v1, designation = @v2 where id = @i";
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
					MessageBox.Show("Erreur : Cause déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0006B1D4 File Offset: 0x000693D4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.Text == "Ajouter";
			if (flag)
			{
				this.save_cause();
			}
			else
			{
				this.update_cause(sender, e);
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0006B214 File Offset: 0x00069414
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
			string cmdText = "select * from parametre_cause_realisation";
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
					this.radGridView1.Rows[cause_non_realisation.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = cause_non_realisation.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[cause_non_realisation.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000284 RID: 644 RVA: 0x0006B4B9 File Offset: 0x000696B9
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Text = "Ajouter";
			this.label2.Text = "Ajouter Cause";
			this.guna2Button2.Hide();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0006B4EC File Offset: 0x000696EC
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					cause_non_realisation.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "delete parametre_cause_realisation where id = @i";
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
						this.label2.Text = "Modifier Cause";
						this.guna2Button2.Show();
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x04000357 RID: 855
		private string id_c;

		// Token: 0x04000358 RID: 856
		private static int row_act;
	}
}
