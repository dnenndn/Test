using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200014F RID: 335
	public partial class parametre_article_localisation : Form
	{
		// Token: 0x06000EFD RID: 3837 RVA: 0x00242800 File Offset: 0x00240A00
		public parametre_article_localisation()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x0024285E File Offset: 0x00240A5E
		private void parametre_article_localisation_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00242884 File Offset: 0x00240A84
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 9;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id,code_emplacement, designation from parametre_emplacement_article where deleted = @i";
			bd bd = new bd();
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
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
					this.radGridView1.Rows[i].Cells[3].Value = this.imageList1.Images[1];
					this.radGridView1.Rows[i].Cells[4].Value = this.imageList1.Images[0];
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
					this.radGridView1.Rows[parametre_article_localisation.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = parametre_article_localisation.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[parametre_article_localisation.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00242B80 File Offset: 0x00240D80
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					parametre_article_localisation.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update parametre_emplacement_article set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
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
						parametre_article_localisation.id_modifier = value;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Emplacement Magasin";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00242D70 File Offset: 0x00240F70
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = this.guna2Button1.Text == "Ajouter";
				if (flag2)
				{
					string cmdText = "select id from parametre_emplacement_article where (code_emplacement = @v1 or designation = @v2) and deleted = @d";
					bd bd = new bd();
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						string cmdText2 = "insert into parametre_emplacement_article (code_emplacement, designation, deleted) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Emplacement est ajoutée avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.remplissage_tableau(1);
					}
					else
					{
						MessageBox.Show("Erreur : Emplacement déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				bool flag4 = this.guna2Button1.Text == "Modifier";
				if (flag4)
				{
					string cmdText3 = "select id from parametre_emplacement_article where (code_emplacement = @v1 or designation = @v2) and deleted = @d and id <> @i";
					bd bd2 = new bd();
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
					sqlCommand3.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = parametre_article_localisation.id_modifier;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag5 = dataTable2.Rows.Count == 0;
					if (flag5)
					{
						string cmdText4 = "update parametre_emplacement_article set code_emplacement = @i1, designation = @i2 where id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = parametre_article_localisation.id_modifier;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd2.cnn.Close();
						MessageBox.Show("Emplacement est modifié avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.guna2Button1.Text = "Ajouter";
						this.label2.Text = "Ajouter Emplacement Magasin";
						this.remplissage_tableau(2);
					}
					else
					{
						MessageBox.Show("Erreur : Emplacement déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x040012CD RID: 4813
		private static string id_modifier;

		// Token: 0x040012CE RID: 4814
		private static int row_act;
	}
}
