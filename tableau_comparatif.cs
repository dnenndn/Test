using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000129 RID: 297
	public partial class tableau_comparatif : Form
	{
		// Token: 0x06000D1E RID: 3358 RVA: 0x001FC910 File Offset: 0x001FAB10
		public tableau_comparatif()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change1);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee1);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x001FC9D0 File Offset: 0x001FABD0
		private void tableau_comparatif_Load(object sender, EventArgs e)
		{
			this.pictureBox3.Hide();
			this.pictureBox4.Hide();
			this.pictureBox1.Hide();
			this.pictureBox2.Hide();
			this.radGridView2.Hide();
			this.radGridView1.Size = new Size(1080, 520);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x001FCA40 File Offset: 0x001FAC40
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

		// Token: 0x06000D21 RID: 3361 RVA: 0x001FCAD8 File Offset: 0x001FACD8
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.Text = "Afficher";
				radButtonElement.ForeColor = Color.White;
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.Text = "Clôturer";
				radButtonElement2.ForeColor = Color.White;
			}
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x001FCC54 File Offset: 0x001FAE54
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id, createur, date_dop, heure_dop from dop where statut = @d";
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
					string cmdText2 = "select count(id) from devis where id_dop = @o";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@o", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					int num = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0].ToString());
					string cmdText3 = "select count(id) from dop_fournisseur where id_dop = @o ";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@o", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					int num2 = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0].ToString());
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[1].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString(),
						num2,
						num
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
					this.radGridView1.Rows[tableau_comparatif.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = tableau_comparatif.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[tableau_comparatif.row_act - 1].IsCurrent = true;
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
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x001FD044 File Offset: 0x001FB244
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 6;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					tableau_comparatif.id_dop = text;
					this.radGridView2.Show();
					this.pictureBox3.Show();
					this.pictureBox4.Show();
					this.pictureBox2.Show();
					this.pictureBox1.Show();
					this.radGridView1.Size = new Size(1080, 171);
					this.select_tbl_comparatif();
				}
				bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
				if (flag3)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					tableau_comparatif.row_act = e.RowIndex;
					DialogResult dialogResult = MessageBox.Show("Vous voulez clôturer la demande offre de prix?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag4 = dialogResult == DialogResult.Yes;
					if (flag4)
					{
						bd bd = new bd();
						string cmdText = "select id from dop_fini where id_dop = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag5 = dataTable.Rows.Count != 0;
						if (flag5)
						{
							string cmdText2 = "update dop set statut = @d where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
						else
						{
							MessageBox.Show("Impossible de clôturer cette demande offre de prix, il n'ya pas une décision");
						}
					}
				}
			}
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x001FD28C File Offset: 0x001FB48C
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_dop, article.code_article, article.designation, qt from dop_article inner join article on dop_article.id_article = article.id inner join dop on dop_article.id_dop = dop.id where dop.statut = @d";
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

		// Token: 0x06000D25 RID: 3365 RVA: 0x001FD618 File Offset: 0x001FB818
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.radGridView2.Hide();
			this.radGridView1.Size = new Size(1080, 520);
			this.pictureBox3.Hide();
			this.pictureBox4.Hide();
			this.pictureBox1.Hide();
			this.pictureBox2.Hide();
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x001FD680 File Offset: 0x001FB880
		private void select_tbl_comparatif()
		{
			this.radGridView2.Rows.Clear();
			this.radGridView2.Columns.Clear();
			this.radGridView2.AllowAutoSizeColumns = true;
			ColumnGroupsViewDefinition columnGroupsViewDefinition = new ColumnGroupsViewDefinition();
			GridViewTextBoxColumn gridViewTextBoxColumn = new GridViewTextBoxColumn();
			GridViewTextBoxColumn gridViewTextBoxColumn2 = new GridViewTextBoxColumn();
			GridViewTextBoxColumn gridViewTextBoxColumn3 = new GridViewTextBoxColumn();
			gridViewTextBoxColumn.HeaderText = "Code Article";
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn3.HeaderText = "Quantité";
			gridViewTextBoxColumn.Width = 150;
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.Width = 150;
			gridViewTextBoxColumn.Name = "t1";
			gridViewTextBoxColumn2.Name = "t2";
			gridViewTextBoxColumn3.Name = "t3";
			gridViewTextBoxColumn.HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.HeaderTextAlignment = ContentAlignment.MiddleLeft;
			this.radGridView2.Columns.Add(gridViewTextBoxColumn);
			this.radGridView2.Columns.Add(gridViewTextBoxColumn2);
			this.radGridView2.Columns.Add(gridViewTextBoxColumn3);
			GridViewColumnGroup gridViewColumnGroup = new GridViewColumnGroup();
			GridViewColumnGroupRow gridViewColumnGroupRow = new GridViewColumnGroupRow();
			gridViewColumnGroup.Text = "";
			gridViewColumnGroupRow.ColumnNames.Add("t1");
			gridViewColumnGroupRow.ColumnNames.Add("t2");
			gridViewColumnGroupRow.ColumnNames.Add("t3");
			bd bd = new bd();
			string cmdText = "select article.code_article, article.designation, dop_article.qt from dop_article inner join article on dop_article.id_article = article.id where id_dop = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = tableau_comparatif.id_dop;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
			}
			columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup);
			gridViewColumnGroup.Rows.Add(gridViewColumnGroupRow);
			string cmdText2 = "select fournisseur.nom, fournisseur.id from dop_fournisseur inner join fournisseur on dop_fournisseur.id_fournisseur = fournisseur.id where id_dop = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = tableau_comparatif.id_dop;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			int num = 0;
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				int num2 = 3;
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					GridViewTextBoxColumn gridViewTextBoxColumn4 = new GridViewTextBoxColumn();
					GridViewTextBoxColumn gridViewTextBoxColumn5 = new GridViewTextBoxColumn();
					GridViewTextBoxColumn gridViewTextBoxColumn6 = new GridViewTextBoxColumn();
					GridViewTextBoxColumn gridViewTextBoxColumn7 = new GridViewTextBoxColumn();
					string text = num.ToString();
					num++;
					string text2 = num.ToString();
					num++;
					string text3 = num.ToString();
					num++;
					string text4 = num.ToString();
					num++;
					gridViewTextBoxColumn4.Name = text;
					gridViewTextBoxColumn5.Name = text2;
					gridViewTextBoxColumn6.Name = text3;
					gridViewTextBoxColumn7.Name = text4;
					gridViewTextBoxColumn4.HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTextBoxColumn5.HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTextBoxColumn6.HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTextBoxColumn7.HeaderTextAlignment = ContentAlignment.MiddleLeft;
					gridViewTextBoxColumn4.HeaderText = "Quantité disponible";
					gridViewTextBoxColumn5.HeaderText = "Prix U HT";
					gridViewTextBoxColumn6.HeaderText = "Remise %";
					gridViewTextBoxColumn7.HeaderText = "Prix T HT";
					gridViewTextBoxColumn4.Width = 200;
					gridViewTextBoxColumn5.Width = 150;
					gridViewTextBoxColumn6.Width = 150;
					gridViewTextBoxColumn7.Width = 150;
					this.radGridView2.Columns.Add(gridViewTextBoxColumn4);
					this.radGridView2.Columns.Add(gridViewTextBoxColumn5);
					this.radGridView2.Columns.Add(gridViewTextBoxColumn6);
					this.radGridView2.Columns.Add(gridViewTextBoxColumn7);
					GridViewColumnGroup gridViewColumnGroup2 = new GridViewColumnGroup();
					GridViewColumnGroupRow gridViewColumnGroupRow2 = new GridViewColumnGroupRow();
					gridViewColumnGroup2.Text = dataTable2.Rows[j].ItemArray[0].ToString();
					gridViewColumnGroupRow2.ColumnNames.Add(text);
					gridViewColumnGroupRow2.ColumnNames.Add(text2);
					gridViewColumnGroupRow2.ColumnNames.Add(text3);
					gridViewColumnGroupRow2.ColumnNames.Add(text4);
					columnGroupsViewDefinition.ColumnGroups.Add(gridViewColumnGroup2);
					gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
					for (int k = 0; k < this.radGridView2.Rows.Count; k++)
					{
						string cmdText3 = "select qt_disponible, devis_article.prix_ht, devis_article.remise from devis_article inner join devis on devis_article.id_devis = devis.id inner join article on devis_article.id_article = article.id inner join devis_fournisseur on devis_article.id_devis = devis_fournisseur.id_devis where devis_fournisseur.id_fournisseur = @i1 and devis.id_dop = @i2 and article.code_article = @i3";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[1].ToString();
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = tableau_comparatif.id_dop;
						sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.radGridView2.Rows[k].Cells[0].Value.ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag3 = dataTable3.Rows.Count != 0;
						if (flag3)
						{
							this.radGridView2.Rows[k].Cells[num2].Value = dataTable3.Rows[0].ItemArray[0].ToString();
							this.radGridView2.Rows[k].Cells[num2 + 1].Value = Convert.ToDouble(dataTable3.Rows[0].ItemArray[1]).ToString(".000");
							this.radGridView2.Rows[k].Cells[num2 + 2].Value = dataTable3.Rows[0].ItemArray[2].ToString();
							double num3 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0].ToString()) * Convert.ToDouble(dataTable3.Rows[0].ItemArray[1].ToString());
							double num4 = num3 * Convert.ToDouble(dataTable3.Rows[0].ItemArray[2].ToString());
							num3 -= num4 / 100.0;
							num3 = Math.Round(num3, 3);
							this.radGridView2.Rows[k].Cells[num2 + 3].Value = num3.ToString(".000");
						}
						else
						{
							this.radGridView2.Rows[k].Cells[num2].Value = "-";
							this.radGridView2.Rows[k].Cells[num2 + 1].Value = "-";
							this.radGridView2.Rows[k].Cells[num2 + 2].Value = "-";
							this.radGridView2.Rows[k].Cells[num2 + 3].Value = "-";
						}
					}
					num2 += 4;
				}
			}
			this.radGridView2.MasterTemplate.ViewDefinition = columnGroupsViewDefinition;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x001FDED4 File Offset: 0x001FC0D4
		private void RunExportToPDF(string fileName, ref bool openExportFile)
		{
			new ExportToPDF(this.radGridView2)
			{
				PdfExportSettings = 
				{
					Title = "Tableau comparatif",
					PageWidth = 297,
					PageHeight = 210
				},
				FitToPageWidth = true,
				ExportVisualSettings = this.exportVisualSettings,
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				FileExtension = "pdf",
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			DialogResult dialogResult = RadMessageBox.Show("Le tableau comparatif est enregistré avec succés. Vous voulez ouvrir le fichier PDF?", "Export PDF", MessageBoxButtons.YesNo, 2);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				openExportFile = true;
			}
			bool flag2 = openExportFile;
			if (flag2)
			{
				Process.Start(fileName);
			}
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x001FDFBC File Offset: 0x001FC1BC
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView2)
			{
				ExportVisualSettings = this.exportVisualSettings,
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			DialogResult dialogResult = RadMessageBox.Show("Le tableau comparatif est enregistré avec succés. Vous voulez ouvrir le fichier PDF?", "Export PDF", MessageBoxButtons.YesNo, 2);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				openExportFile = true;
			}
			bool flag2 = openExportFile;
			if (flag2)
			{
				Process.Start(fileName);
			}
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x001FE05C File Offset: 0x001FC25C
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			GridPrintStyle gridPrintStyle = new GridPrintStyle();
			gridPrintStyle.FitWidthMode = 0;
			gridPrintStyle.PrintGrouping = true;
			gridPrintStyle.PrintSummaries = false;
			gridPrintStyle.PrintHeaderOnEachPage = true;
			gridPrintStyle.PrintHiddenColumns = false;
			gridPrintStyle.CellFont = new Font("Calibri", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			gridPrintStyle.ChildViewPrintMode = 0;
			gridPrintStyle.GroupRowBackColor = Color.Gray;
			gridPrintStyle.HeaderCellBackColor = Color.Khaki;
			this.radGridView2.PrintStyle = gridPrintStyle;
			RadPrintDocument radPrintDocument = new RadPrintDocument();
			radPrintDocument.DefaultPageSettings.Landscape = true;
			radPrintDocument.MiddleHeader = "Tableau Comparatif";
			radPrintDocument.HeaderFont = new Font("Arial", 50f);
			radPrintDocument.HeaderHeight = 100;
			radPrintDocument.Watermark.AllPages = false;
			radPrintDocument.Watermark.ImageOpacity = 180;
			radPrintDocument.Watermark.Pages = "1";
			radPrintDocument.Watermark.DrawInFront = true;
			string text = Path.Combine(Application.StartupPath, "Resources");
			radPrintDocument.Watermark.ImagePath = "\\\\192.168.1.187\\ideal\\ressource-gmao\\logoibb.png";
			this.radGridView2.PrintPreview(radPrintDocument);
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x001FE188 File Offset: 0x001FC388
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			devis_classement_fournisseur devis_classement_fournisseur = new devis_classement_fournisseur();
			devis_classement_fournisseur.Show();
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x001FE1A4 File Offset: 0x001FC3A4
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			cloturer_dop cloturer_dop = new cloturer_dop();
			cloturer_dop.Show();
		}

		// Token: 0x040010AD RID: 4269
		private static int row_act;

		// Token: 0x040010AE RID: 4270
		public static string id_dop;

		// Token: 0x040010AF RID: 4271
		private bool exportVisualSettings;
	}
}
