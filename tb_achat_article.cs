using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace GMAO
{
	// Token: 0x02000163 RID: 355
	public partial class tb_achat_article : Form
	{
		// Token: 0x06000F8C RID: 3980 RVA: 0x00259214 File Offset: 0x00257414
		public tb_achat_article()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(tb_achat_article.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(tb_achat_article.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x002592B8 File Offset: 0x002574B8
		private void tb_achat_article_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x00259300 File Offset: 0x00257500
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x00259384 File Offset: 0x00257584
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x00259488 File Offset: 0x00257688
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select article.id, famille.designation, sous_famille.designation, article.code_article, article.designation,sum(livraison_article.qt), count(distinct bon_livraison.id), sum((livraison_article.qt * livraison_article.prix_ht) - ((livraison_article.qt * livraison_article.prix_ht * livraison_article.remise)/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id inner join article on livraison_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where bon_livraison.date_reel between @d1 and @d2 group by article.id, article.code_article, article.designation, sous_famille.designation, famille.designation order by sum((livraison_article.qt * livraison_article.prix_ht) - ((livraison_article.qt * livraison_article.prix_ht * livraison_article.remise)/100)) desc ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
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
						dataTable.Rows[i].ItemArray[0],
						dataTable.Rows[i].ItemArray[1],
						dataTable.Rows[i].ItemArray[2],
						dataTable.Rows[i].ItemArray[3],
						dataTable.Rows[i].ItemArray[4],
						dataTable.Rows[i].ItemArray[5],
						dataTable.Rows[i].ItemArray[6],
						Convert.ToDouble(dataTable.Rows[i].ItemArray[7]).ToString("0.000")
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.afficher_article();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x002596D6 File Offset: 0x002578D6
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x002596E0 File Offset: 0x002578E0
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x002596EC File Offset: 0x002578EC
		private void afficher_article()
		{
			this.radGridView1.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select id_article,bon_livraison.id, bon_livraison.bl_fournisseur, bon_livraison.date_reel, bon_livraison.heure_livraison, qt,prix_ht, remise, (livraison_article.qt * livraison_article.prix_ht) - ((livraison_article.qt * livraison_article.prix_ht * livraison_article.remise)/100) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_reel between @d1 and @d2  order by date_reel, heure_livraison ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
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
			dataTable2.Columns.Add("column8");
			dataTable2.Columns.Add("column9");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[2]),
						dataTable.Rows[i].ItemArray[3].ToString().Substring(0, 9),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[7].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[8]).ToString("0.000")
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Livraison";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 120;
				gridViewTemplate.Columns["column3"].Width = 120;
				gridViewTemplate.Columns["column4"].Width = 120;
				gridViewTemplate.Columns["column5"].Width = 80;
				gridViewTemplate.Columns["column6"].Width = 120;
				gridViewTemplate.Columns["column7"].Width = 130;
				gridViewTemplate.Columns["column8"].Width = 100;
				gridViewTemplate.Columns["column9"].Width = 180;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "ID BL";
				gridViewTemplate.Columns[2].HeaderText = "N° BL";
				gridViewTemplate.Columns[3].HeaderText = "Date Livraison";
				gridViewTemplate.Columns[4].HeaderText = "Heure";
				gridViewTemplate.Columns[5].HeaderText = "Quantité";
				gridViewTemplate.Columns[6].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[7].HeaderText = "Remise (%)";
				gridViewTemplate.Columns[8].HeaderText = "Prix Tot HT";
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[8].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[8].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].ExcelExportType = 0;
				gridViewTemplate.Columns[6].ExcelExportType = 0;
				gridViewTemplate.Columns[7].ExcelExportType = 0;
				gridViewTemplate.Columns[8].ExcelExportType = 0;
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x00259DCC File Offset: 0x00257FCC
		private void radButton8_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x00259E1C File Offset: 0x0025801C
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 1,
				HiddenColumnOption = 1,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}
	}
}
