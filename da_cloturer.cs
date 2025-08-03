using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200005E RID: 94
	public partial class da_cloturer : Form
	{
		// Token: 0x0600046B RID: 1131 RVA: 0x000BBF14 File Offset: 0x000BA114
		public da_cloturer()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.da_systeme_formatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radDateTimePicker1.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
			this.radDateTimePicker2.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000BBFEC File Offset: 0x000BA1EC
		private void da_cloturer_Load(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000BC050 File Offset: 0x000BA250
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag)
			{
				string cmdText = "select statut from demande_achat where id = @i";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows[0].ItemArray[0].ToString() != "10";
				if (flag2)
				{
					RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
					radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
					radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
					radButtonElement.ForeColor = Color.White;
					radButtonElement.TextAlignment = ContentAlignment.MiddleCenter;
					radButtonElement.Text = "Clôturer";
				}
				else
				{
					this.radGridView1.Rows[e.RowIndex].Cells[7].ReadOnly = true;
				}
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x000BC1F0 File Offset: 0x000BA3F0
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

		// Token: 0x0600046F RID: 1135 RVA: 0x000BC304 File Offset: 0x000BA504
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_da,id_article, article.code_article, article.designation, qt, motif, da_article.id from da_article inner join article on da_article.id_article = article.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and demande_achat.date_da between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
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

		// Token: 0x06000470 RID: 1136 RVA: 0x000BC7B0 File Offset: 0x000BA9B0
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
						da_cloturer.row_act = e.RowIndex;
						string cmdText = "select statut from demande_achat where id = @i";
						bd bd = new bd();
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows[0].ItemArray[0].ToString() != "10";
						if (flag4)
						{
							DialogResult dialogResult = MessageBox.Show("Vous voulez cloturer cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							bool flag5 = dialogResult == DialogResult.Yes;
							if (flag5)
							{
								string cmdText2 = "update demande_achat set statut = @u where id = @i";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@u", SqlDbType.Int).Value = 10;
								sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								string cmdText3 = "insert into da_cloturer (id_da, cloturer_par, date_cloture, heure_cloture) values (@i1, @i2, @i3, @i4)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = value;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
								sqlCommand3.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
								this.remplissage_tableau(3);
							}
						}
						else
						{
							MessageBox.Show("Erreur : La demande d'achat est déja cloturée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					bool flag6 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag6)
					{
						Form1.id_daa = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_eyes da_eyes = new da_eyes();
						da_eyes.Show();
					}
				}
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x000BCA84 File Offset: 0x000BAC84
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
				string cmdText = "select id, date_da, heure_da, createur, demandeur, delai, periode, statut from demande_achat where (statut = @i or statut = @i2) and date_da between @d1 and @d2";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = 10;
				sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Magasin";
				if (flag2)
				{
					this.radGridView1.Columns[6].IsVisible = false;
				}
				bool flag3 = dataTable.Rows.Count != 0;
				if (flag3)
				{
					int num = 0;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag4 = this.test_confirmer(dataTable.Rows[i].ItemArray[0].ToString()) == 1 | dataTable.Rows[i].ItemArray[7].ToString() == "10";
						if (flag4)
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
							this.radGridView1.Rows[num].Cells[6].Value = Resources.icons8_visible_96;
							num++;
						}
					}
				}
			}
			else
			{
				string cmdText2 = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where (statut = @i or statut = @i2) and demandeur = @v and date_da between @d1 and @d2";
				bd bd2 = new bd();
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = 10;
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = page_loginn.id_user;
				sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				this.radGridView1.Columns[6].IsVisible = false;
				bool flag5 = dataTable2.Rows.Count != 0;
				if (flag5)
				{
					int num2 = 0;
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						bool flag6 = this.test_confirmer(dataTable2.Rows[j].ItemArray[0].ToString()) == 1 | dataTable2.Rows[j].ItemArray[7].ToString() == "10";
						if (flag6)
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
							this.radGridView1.Rows[num2].Cells[6].Value = Resources.icons8_visible_96;
							num2++;
						}
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
					this.radGridView1.Rows[da_cloturer.row_act].IsCurrent = true;
				}
				bool flag11 = o == 3;
				if (flag11)
				{
					bool flag12 = da_cloturer.row_act != 0;
					if (flag12)
					{
						this.radGridView1.Rows[da_cloturer.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000472 RID: 1138 RVA: 0x000BD218 File Offset: 0x000BB418
		private void afficher_equipement(GridViewTemplate ta)
		{
			ta.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select  da_article.id, da_article_equipement.id_article, equipement.id, equipement.designation from da_article_equipement inner join equipement on da_article_equipement.id_equipement = equipement.id inner join da_article on da_article_equipement.id_lis = da_article.id inner join demande_achat on da_article.id_da = demande_achat.id where equipement.deleted = @d and demande_achat.date_da between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
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

		// Token: 0x06000473 RID: 1139 RVA: 0x000BD57C File Offset: 0x000BB77C
		private int test_confirmer(string idd)
		{
			int result = 0;
			bd bd = new bd();
			string cmdText = "select id from da_article where id_da = @i and qt > qt_restant";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = idd;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x040005EB RID: 1515
		private static int row_act;

		// Token: 0x040005EC RID: 1516
		public static string id_da;
	}
}
