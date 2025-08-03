using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200005D RID: 93
	public partial class da_admin : Form
	{
		// Token: 0x06000461 RID: 1121 RVA: 0x000BA56C File Offset: 0x000B876C
		public da_admin()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.da_systeme_formatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000BA612 File Offset: 0x000B8812
		private void da_admin_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000BA620 File Offset: 0x000B8820
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x000BA6D4 File Offset: 0x000B88D4
		private string select_utilisateur(string i)
		{
			bd bd = new bd();
			string result = "";
			string cmdText = "select login from utilisateur where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = i;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = dataTable.Rows[0].ItemArray[0].ToString();
			}
			bool flag2 = i == "0";
			if (flag2)
			{
				result = "Système";
			}
			bool flag3 = i == "-1";
			if (flag3)
			{
				result = "Réapprovisionnement";
			}
			bool flag4 = i == "-2";
			if (flag4)
			{
				result = "Recomplètement";
			}
			bool flag5 = i == "-3";
			if (flag5)
			{
				result = "Point de commande";
			}
			bool flag6 = i == "-4";
			if (flag6)
			{
				result = "Réapprovisionnement variable";
			}
			return result;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x000BA7E8 File Offset: 0x000B89E8
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_da,id_article, article.code_article, article.designation, qt, motif, da_article.id from da_article inner join article on da_article.id_article = article.id where article.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			dataTable2.Columns.Add("column4");
			dataTable2.Columns.Add("column5");
			dataTable2.Columns.Add("column6");
			dataTable2.Columns.Add("column7");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 120;
				gridViewTemplate.Columns["column6"].Width = 250;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].IsVisible = false;
				gridViewTemplate.Columns[6].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Quantité";
				gridViewTemplate.Columns[5].HeaderText = "Motif";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
				this.afficher_equipement(gridViewTemplate);
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000BAC44 File Offset: 0x000B8E44
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_admin.row_act = e.RowIndex;
						DialogResult dialogResult = MessageBox.Show("Vous voulez confirmer cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "update demande_achat set statut = @u where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@u", SqlDbType.Int).Value = 1;
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							string cmdText2 = "insert into da_confirmer (id_da, confirmer_par, date_confirmer, heure_confirmer) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = value;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag5)
					{
						Form1.id_daa = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_eyes da_eyes = new da_eyes();
						da_eyes.Show();
					}
				}
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000BAE88 File Offset: 0x000B9088
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bool flag = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				string cmdText = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where statut = @i";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 3;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Magasin";
				if (flag2)
				{
					this.radGridView1.Columns[6].IsVisible = false;
				}
				bool flag3 = dataTable.Rows.Count != 0;
				if (flag3)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
							dataTable.Rows[i].ItemArray[2].ToString(),
							this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
							this.select_utilisateur(dataTable.Rows[i].ItemArray[4].ToString()),
							dataTable.Rows[i].ItemArray[5].ToString() + " " + dataTable.Rows[i].ItemArray[6].ToString()
						});
						this.radGridView1.Rows[i].Cells[6].Value = "Confirmer";
						this.radGridView1.Rows[i].Cells[7].Value = Resources.icons8_visible_96;
					}
				}
			}
			else
			{
				string cmdText2 = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where statut = @i and demandeur = @v";
				bd bd2 = new bd();
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 3;
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = page_loginn.id_user;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				this.radGridView1.Columns[6].IsVisible = false;
				bool flag4 = dataTable2.Rows.Count != 0;
				if (flag4)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable2.Rows[j].ItemArray[0].ToString(),
							fonction.Mid(dataTable2.Rows[j].ItemArray[1].ToString(), 1, 10),
							dataTable2.Rows[j].ItemArray[2].ToString(),
							this.select_utilisateur(dataTable2.Rows[j].ItemArray[3].ToString()),
							this.select_utilisateur(dataTable2.Rows[j].ItemArray[4].ToString()),
							dataTable2.Rows[j].ItemArray[5].ToString() + " " + dataTable2.Rows[j].ItemArray[6].ToString()
						});
						this.radGridView1.Rows[j].Cells[6].Value = "Confirmer";
						this.radGridView1.Rows[j].Cells[7].Value = Resources.icons8_visible_96;
					}
				}
			}
			bool flag5 = this.radGridView1.Rows.Count != 0;
			if (flag5)
			{
				bool flag6 = o == 0;
				if (flag6)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag7 = o == 1;
				if (flag7)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag8 = o == 2;
				if (flag8)
				{
					this.radGridView1.Rows[da_admin.row_act].IsCurrent = true;
				}
				bool flag9 = o == 3;
				if (flag9)
				{
					bool flag10 = da_admin.row_act != 0;
					if (flag10)
					{
						this.radGridView1.Rows[da_admin.row_act - 1].IsCurrent = true;
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
			this.loadarticle();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x000BB4D4 File Offset: 0x000B96D4
		private void afficher_equipement(GridViewTemplate ta)
		{
			ta.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select  da_article.id, da_article_equipement.id_article, equipement.id, equipement.designation from da_article_equipement inner join equipement on da_article_equipement.id_equipement = equipement.id inner join da_article on da_article_equipement.id_lis = da_article.id where equipement.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			dataTable2.Columns.Add("column4");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Equipement";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns["column4"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "ID Equipement";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				ta.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(ta);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(ta.Columns[6].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x040005E5 RID: 1509
		private static int row_act;

		// Token: 0x040005E6 RID: 1510
		public static string id_da;
	}
}
