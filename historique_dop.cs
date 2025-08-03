using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000139 RID: 313
	public partial class historique_dop : Form
	{
		// Token: 0x06000DFC RID: 3580 RVA: 0x00221C78 File Offset: 0x0021FE78
		public historique_dop()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00221D08 File Offset: 0x0021FF08
		private void historique_dop_Load(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
			this.radDateTimePicker1.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
			this.radDateTimePicker2.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00221D9C File Offset: 0x0021FF9C
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
			return result;
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x00221E34 File Offset: 0x00220034
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.Text = "Afficher";
				radButtonElement.ForeColor = Color.White;
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00221F00 File Offset: 0x00220100
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id, createur, date_dop, heure_dop from dop where statut = @d and date_dop between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
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
						this.select_utilisateur(dataTable.Rows[i].ItemArray[1].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString()
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
					this.radGridView1.Rows[historique_dop.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = historique_dop.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[historique_dop.row_act - 1].IsCurrent = true;
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
			this.LoadArticle();
			this.Loaddevis();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00222230 File Offset: 0x00220430
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 4;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					liste_dop.id_dop = text;
					choisir_fournisseur choisir_fournisseur = new choisir_fournisseur();
					choisir_fournisseur.Show();
				}
			}
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x002222B4 File Offset: 0x002204B4
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_dop, article.code_article, article.designation, qt from dop_article inner join article on dop_article.id_article = article.id inner join dop on dop_article.id_dop = dop.id where dop.statut = @d and dop.date_dop between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
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
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00222690 File Offset: 0x00220890
		private void Loaddevis()
		{
			bd bd = new bd();
			string cmdText = "select id_dop, date_devis, heure_devis, devis.createur, livr, fournisseur.nom, devis.id from devis inner join devis_fournisseur on devis.id = devis_fournisseur.id_devis inner join fournisseur on devis_fournisseur.id_fournisseur = fournisseur.id inner join dop on devis.id_dop = dop.id  where dop.statut = @d and dop.date_dop between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataTable dataTable2 = new DataTable();
					dataTable2.Columns.Add("column1");
					dataTable2.Columns.Add("column2");
					dataTable2.Columns.Add("column3");
					dataTable2.Columns.Add("column4");
					dataTable2.Columns.Add("column5");
					dataTable2.Columns.Add("column6");
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
					GridViewTemplate gridViewTemplate = new GridViewTemplate();
					gridViewTemplate.Caption = "Dévis-" + dataTable.Rows[i].ItemArray[5].ToString();
					gridViewTemplate.DataSource = dataTable2;
					gridViewTemplate.AllowRowResize = false;
					gridViewTemplate.ShowColumnHeaders = true;
					gridViewTemplate.Columns["column1"].Width = 200;
					gridViewTemplate.Columns["column2"].Width = 200;
					gridViewTemplate.Columns["column3"].Width = 200;
					gridViewTemplate.Columns["column4"].Width = 200;
					gridViewTemplate.Columns["column5"].Width = 200;
					gridViewTemplate.AllowAddNewRow = false;
					gridViewTemplate.AllowEditRow = false;
					gridViewTemplate.Columns[0].IsVisible = false;
					gridViewTemplate.Columns[5].IsVisible = false;
					gridViewTemplate.Columns[1].HeaderText = "Date";
					gridViewTemplate.Columns[2].HeaderText = "Heure";
					gridViewTemplate.Columns[3].HeaderText = "Créateur";
					gridViewTemplate.Columns[4].HeaderText = "Livraison";
					gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
					this.radGridView1.Templates.Insert(i + 1, gridViewTemplate);
					GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
					gridViewRelation.ChildTemplate = gridViewTemplate;
					gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
					gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
					this.radGridView1.Relations.Add(gridViewRelation);
					string cmdText2 = "select devis_article.id_devis, article.designation, qt_disponible, devis_article.prix_ht, devis_article.remise from devis_article inner join article on devis_article.id_article = article.id inner join devis on devis_article.id_devis = devis.id inner join dop on devis.id_dop = dop.id where dop.statut = @d and dop.date_dop between @d1 and @d2";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
					sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
					sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter2.Fill(dataTable3);
					bool flag2 = dataTable3.Rows.Count != 0;
					if (flag2)
					{
						DataTable dataTable4 = new DataTable();
						dataTable4.Columns.Add("column1");
						dataTable4.Columns.Add("column2");
						dataTable4.Columns.Add("column3");
						dataTable4.Columns.Add("column4");
						dataTable4.Columns.Add("column5");
						dataTable4.Columns.Add("column6");
						for (int j = 0; j < dataTable3.Rows.Count; j++)
						{
							double num = Convert.ToDouble(dataTable3.Rows[j].ItemArray[2]) * Convert.ToDouble(dataTable3.Rows[j].ItemArray[3]);
							num -= Convert.ToDouble(dataTable3.Rows[j].ItemArray[4]) * num / 100.0;
							dataTable4.Rows.Add(new object[]
							{
								dataTable3.Rows[j].ItemArray[0].ToString(),
								dataTable3.Rows[j].ItemArray[1].ToString(),
								dataTable3.Rows[j].ItemArray[2].ToString(),
								Convert.ToDouble(dataTable3.Rows[j].ItemArray[3]).ToString("0.000"),
								dataTable3.Rows[j].ItemArray[4].ToString(),
								num.ToString("0.000")
							});
						}
						GridViewTemplate gridViewTemplate2 = new GridViewTemplate();
						gridViewTemplate2.Caption = "Articles";
						gridViewTemplate2.DataSource = dataTable4;
						gridViewTemplate2.AllowRowResize = false;
						gridViewTemplate2.ShowColumnHeaders = true;
						gridViewTemplate2.Columns["column1"].Width = 200;
						gridViewTemplate2.Columns["column2"].Width = 200;
						gridViewTemplate2.Columns["column3"].Width = 200;
						gridViewTemplate2.Columns["column4"].Width = 200;
						gridViewTemplate2.Columns["column5"].Width = 200;
						gridViewTemplate2.Columns["column6"].Width = 200;
						gridViewTemplate2.AllowAddNewRow = false;
						gridViewTemplate2.AllowEditRow = false;
						gridViewTemplate2.Columns[0].IsVisible = false;
						gridViewTemplate2.Columns[1].HeaderText = "Article";
						gridViewTemplate2.Columns[2].HeaderText = "Quantité";
						gridViewTemplate2.Columns[3].HeaderText = "Prix U HT";
						gridViewTemplate2.Columns[4].HeaderText = "Remise (%)";
						gridViewTemplate2.Columns[5].HeaderText = "Prix TOT HT";
						gridViewTemplate2.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[5].TextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate2.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
						gridViewTemplate.Templates.Insert(0, gridViewTemplate2);
						GridViewRelation gridViewRelation2 = new GridViewRelation(gridViewTemplate);
						gridViewRelation2.ChildTemplate = gridViewTemplate2;
						gridViewRelation2.ParentColumnNames.Add(gridViewTemplate.Columns[5].Name);
						gridViewRelation2.ChildColumnNames.Add(gridViewTemplate2.Columns[0].Name);
						this.radGridView1.Relations.Add(gridViewRelation2);
					}
				}
			}
			int num2 = dataTable.Rows.Count + 1;
			string cmdText3 = "select  id_dop, article.designation, fournisseur.nom,dop_fini.qt_disponible, dop_fini.prix_ht, dop_fini.remise from dop_fini inner join dop on dop_fini.id_dop = dop.id inner join fournisseur on dop_fini.id_fournisseur = fournisseur.id inner join article on dop_fini.id_article = article.id  where dop.statut = @d and dop.date_dop between @d1 and @d2";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable5 = new DataTable();
			sqlDataAdapter3.Fill(dataTable5);
			DataTable dataTable6 = new DataTable();
			dataTable6.Columns.Add("column1");
			dataTable6.Columns.Add("column2");
			dataTable6.Columns.Add("column3");
			dataTable6.Columns.Add("column4");
			dataTable6.Columns.Add("column5");
			dataTable6.Columns.Add("column6");
			dataTable6.Columns.Add("column7");
			bool flag3 = dataTable5.Rows.Count != 0;
			if (flag3)
			{
				for (int k = 0; k < dataTable5.Rows.Count; k++)
				{
					double num3 = Convert.ToDouble(dataTable5.Rows[k].ItemArray[3]) * Convert.ToDouble(dataTable5.Rows[k].ItemArray[4]);
					num3 -= Convert.ToDouble(dataTable5.Rows[k].ItemArray[5]) * num3 / 100.0;
					dataTable6.Rows.Add(new object[]
					{
						dataTable5.Rows[k].ItemArray[0].ToString(),
						dataTable5.Rows[k].ItemArray[1].ToString(),
						dataTable5.Rows[k].ItemArray[2].ToString(),
						dataTable5.Rows[k].ItemArray[3].ToString(),
						Convert.ToDouble(dataTable5.Rows[k].ItemArray[4]).ToString("0.000"),
						dataTable5.Rows[k].ItemArray[5].ToString(),
						num3.ToString("0.000")
					});
				}
				GridViewTemplate gridViewTemplate3 = new GridViewTemplate();
				gridViewTemplate3.Caption = "Décision";
				gridViewTemplate3.DataSource = dataTable6;
				gridViewTemplate3.AllowRowResize = false;
				gridViewTemplate3.ShowColumnHeaders = true;
				gridViewTemplate3.Columns["column1"].Width = 200;
				gridViewTemplate3.Columns["column2"].Width = 200;
				gridViewTemplate3.Columns["column3"].Width = 200;
				gridViewTemplate3.Columns["column4"].Width = 200;
				gridViewTemplate3.Columns["column5"].Width = 200;
				gridViewTemplate3.Columns["column6"].Width = 200;
				gridViewTemplate3.Columns["column7"].Width = 200;
				gridViewTemplate3.AllowAddNewRow = false;
				gridViewTemplate3.AllowEditRow = false;
				gridViewTemplate3.Columns[0].IsVisible = false;
				gridViewTemplate3.Columns[1].HeaderText = "Article";
				gridViewTemplate3.Columns[2].HeaderText = "Fournisseur";
				gridViewTemplate3.Columns[3].HeaderText = "Quantité";
				gridViewTemplate3.Columns[4].HeaderText = "Prix U HT";
				gridViewTemplate3.Columns[5].HeaderText = "Remise (%)";
				gridViewTemplate3.Columns[6].HeaderText = "Prix Tot HT";
				gridViewTemplate3.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[5].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[6].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate3.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView1.Templates.Insert(this.radGridView1.Templates.Count, gridViewTemplate3);
				GridViewRelation gridViewRelation3 = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation3.ChildTemplate = gridViewTemplate3;
				gridViewRelation3.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation3.ChildColumnNames.Add(gridViewTemplate3.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation3);
			}
		}

		// Token: 0x040011CA RID: 4554
		private static int row_act;

		// Token: 0x040011CB RID: 4555
		public static string id_dop;
	}
}
