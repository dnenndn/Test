using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000061 RID: 97
	public partial class da_refuser : Form
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x000C1B54 File Offset: 0x000BFD54
		public da_refuser()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.da_systeme_formatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000C1BFA File Offset: 0x000BFDFA
		private void da_refuser_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000C1C08 File Offset: 0x000BFE08
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000C1CC4 File Offset: 0x000BFEC4
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

		// Token: 0x06000492 RID: 1170 RVA: 0x000C1DD8 File Offset: 0x000BFFD8
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

		// Token: 0x06000493 RID: 1171 RVA: 0x000C2234 File Offset: 0x000C0434
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_refuser.row_act = e.RowIndex;
						DialogResult dialogResult = MessageBox.Show("Vous voulez réenvoyer cette demande d'achat en cours ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "update demande_achat set statut = @u where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@u", SqlDbType.Int).Value = 0;
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							string cmdText2 = "insert into da_reenvoyer (id_da, reenvoyer_par, date_reenvoyer, heure_reenvoyer) values (@i1, @i2, @i3, @i4)";
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
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 9;
					if (flag5)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_refuser.row_act = e.RowIndex;
						DialogResult dialogResult2 = MessageBox.Show("Vous voulez modifier cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag6 = dialogResult2 == DialogResult.Yes;
						if (flag6)
						{
							da_refuser.id_da = text;
							modifier_da_refuser modifier_da_refuser = new modifier_da_refuser();
							modifier_da_refuser.Show();
						}
					}
					bool flag7 = e.RowIndex >= 0 && e.ColumnIndex == 8;
					if (flag7)
					{
						Form1.id_daa = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_eyes da_eyes = new da_eyes();
						da_eyes.Show();
					}
				}
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000C2504 File Offset: 0x000C0704
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bool flag = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Magasin" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat";
			if (flag)
			{
				string cmdText = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where statut = @i";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 2;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					this.radGridView1.Columns[7].IsVisible = false;
					this.radGridView1.Columns[9].IsVisible = false;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						string cmdText2 = "select cause from da_refuser where id_da = @i order by id DESC";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						string text = "";
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							text = dataTable2.Rows[0].ItemArray[0].ToString();
						}
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
							dataTable.Rows[i].ItemArray[2].ToString(),
							this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
							this.select_utilisateur(dataTable.Rows[i].ItemArray[4].ToString()),
							dataTable.Rows[i].ItemArray[5].ToString() + " " + dataTable.Rows[i].ItemArray[6].ToString(),
							text
						});
						this.radGridView1.Rows[i].Cells[7].Value = "Réenvoyer";
						this.radGridView1.Rows[i].Cells[8].Value = this.imageList1.Images[10];
						this.radGridView1.Rows[i].Cells[9].Value = this.imageList1.Images[1];
						bool flag4 = dataTable.Rows[i].ItemArray[4].ToString() == page_loginn.id_user.ToString();
						if (flag4)
						{
						}
					}
				}
			}
			else
			{
				string cmdText3 = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where statut = @i and demandeur = @v";
				bd bd2 = new bd();
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
				sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = 2;
				sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = page_loginn.id_user;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				bool flag5 = dataTable3.Rows.Count != 0;
				if (flag5)
				{
					for (int j = 0; j < dataTable3.Rows.Count; j++)
					{
						string cmdText4 = "select cause from da_refuser where id_da = @i order by id DESC";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable3.Rows[j].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						string text2 = "";
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							text2 = dataTable4.Rows[0].ItemArray[0].ToString();
						}
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable3.Rows[j].ItemArray[0].ToString(),
							fonction.Mid(dataTable3.Rows[j].ItemArray[1].ToString(), 1, 10),
							dataTable3.Rows[j].ItemArray[2].ToString(),
							this.select_utilisateur(dataTable3.Rows[j].ItemArray[3].ToString()),
							this.select_utilisateur(dataTable3.Rows[j].ItemArray[4].ToString()),
							dataTable3.Rows[j].ItemArray[5].ToString() + " " + dataTable3.Rows[j].ItemArray[6].ToString(),
							text2
						});
						this.radGridView1.Rows[j].Cells[7].Value = "Réenvoyer";
						this.radGridView1.Rows[j].Cells[8].Value = this.imageList1.Images[10];
						this.radGridView1.Rows[j].Cells[9].Value = this.imageList1.Images[1];
					}
				}
			}
			bool flag7 = this.radGridView1.Rows.Count != 0;
			if (flag7)
			{
				bool flag8 = o == 0;
				if (flag8)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag9 = o == 1;
				if (flag9)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag10 = o == 2;
				if (flag10)
				{
					this.radGridView1.Rows[da_refuser.row_act].IsCurrent = true;
				}
				bool flag11 = o == 3;
				if (flag11)
				{
					bool flag12 = da_refuser.row_act != 0;
					if (flag12)
					{
						this.radGridView1.Rows[da_refuser.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000495 RID: 1173 RVA: 0x000C2D10 File Offset: 0x000C0F10
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

		// Token: 0x04000605 RID: 1541
		private static int row_act;

		// Token: 0x04000606 RID: 1542
		public static string id_da;
	}
}
