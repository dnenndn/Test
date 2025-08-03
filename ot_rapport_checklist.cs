using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinForms.Documents.Model;

namespace GMAO
{
	// Token: 0x020000CD RID: 205
	public partial class ot_rapport_checklist : Form
	{
		// Token: 0x0600092D RID: 2349 RVA: 0x0017DF03 File Offset: 0x0017C103
		public ot_rapport_checklist()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0017DF1B File Offset: 0x0017C11B
		private void ot_rapport_checklist_Load(object sender, EventArgs e)
		{
			this.load_plan_maintenance();
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0017DF28 File Offset: 0x0017C128
		private void load_plan_maintenance()
		{
			RadDocument radDocument = new RadDocument();
			Section section = new Section();
			Table table = new Table();
			TableRow tableRow = new TableRow();
			this.titre(section);
			bool flag = ot_checklist.id_plan != 0;
			if (flag)
			{
				this.general_ot(section);
			}
			Paragraph paragraph = new Paragraph();
			Paragraph paragraph2 = new Paragraph();
			section.Blocks.Add(paragraph);
			section.Blocks.Add(paragraph2);
			this.affichage_tableau(section);
			radDocument.Sections.Add(section);
			radDocument.SectionDefaultPageOrientation = 1;
			this.radRichTextEditor1.Document = radDocument;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0017DFC4 File Offset: 0x0017C1C4
		private void titre(Section sc)
		{
			Table table = new Table();
			table.StyleName = RadDocumentDefaultStyles.DefaultDocumentStyleName;
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			TableCell tableCell2 = new TableCell();
			Size size;
			size..ctor(100.0, 100.0);
			ImageInline imageInline;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Resources.logo_ibb.Save(memoryStream, ImageFormat.Png);
				imageInline = new ImageInline(memoryStream, size, "png");
			}
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = "Checklist Maintenance Préventive";
			paragraph.TextAlignment = 1;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(24.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			span2.Text = " ";
			paragraph2.Inlines.Add(span2);
			Paragraph paragraph3 = new Paragraph();
			paragraph3.Inlines.Add(imageInline);
			tableCell.Children.Add(paragraph2);
			tableCell.Children.Add(paragraph);
			tableCell2.Blocks.Add(paragraph3);
			tableCell2.PreferredWidth = new TableWidthUnit(30.0);
			tableRow.Cells.Add(tableCell2);
			tableRow.Cells.Add(tableCell);
			table.Rows.Add(tableRow);
			Border border = new Border(9, Color.FromRgb(220, 20, 60));
			Border border2 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(1, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			tableCell.Borders = borders;
			tableCell2.Borders = borders;
			sc.Blocks.Add(table);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0017E1F0 File Offset: 0x0017C3F0
		private void general_ot(Section sc)
		{
			Table table = new Table();
			table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow = new TableRow();
			TableRow tableRow2 = new TableRow();
			TableCell tableCell = new TableCell();
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = "Plan de maintenance";
			paragraph.TextAlignment = 1;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(14.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			tableCell.Blocks.Add(paragraph);
			TableCell tableCell2 = new TableCell();
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			span2.Text = (ot_checklist.plan_maintenance ?? "");
			paragraph2.TextAlignment = 1;
			span2.ForeColor = Color.Black;
			span2.FontFamily = new FontFamily("Times New Roman");
			span2.FontSize = Unit.PointToDip(12.0);
			span2.FontWeight = FontWeights.Normal;
			paragraph2.Inlines.Add(span2);
			tableCell2.Blocks.Add(paragraph2);
			tableRow.Cells.Add(tableCell);
			tableRow2.Cells.Add(tableCell2);
			table.Rows.Add(tableRow);
			table.Rows.Add(tableRow2);
			sc.Blocks.Add(table);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0017E388 File Offset: 0x0017C588
		private void affichage_tableau(Section sc)
		{
			Table table = new Table();
			table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow = new TableRow();
			TableRow tableRow2 = new TableRow();
			TableCell tableCell = new TableCell();
			TableCell tableCell2 = new TableCell();
			TableCell tableCell3 = new TableCell();
			TableCell tableCell4 = new TableCell();
			TableCell tableCell5 = new TableCell();
			TableCell tableCell6 = new TableCell();
			TableCell tableCell7 = new TableCell();
			this.entete_tableau(tableCell, "Equipement");
			this.entete_tableau(tableCell2, "Gamme Opératoire");
			this.entete_tableau(tableCell3, "Opération");
			this.entete_tableau(tableCell4, "Superviseur");
			this.entete_tableau(tableCell5, "Début Prévu");
			this.entete_tableau(tableCell6, "Fin Prévu");
			this.entete_tableau(tableCell7, "Interventions");
			TableCell tableCell8 = new TableCell();
			TableCell tableCell9 = new TableCell();
			TableCell tableCell10 = new TableCell();
			this.entete_tableau(tableCell8, "Intervenant");
			this.entete_tableau(tableCell9, "Début");
			this.entete_tableau(tableCell10, "Fin");
			tableCell.RowSpan = 2;
			tableCell2.RowSpan = 2;
			tableCell3.RowSpan = 2;
			tableCell4.RowSpan = 2;
			tableCell5.RowSpan = 2;
			tableCell6.RowSpan = 2;
			tableCell7.ColumnSpan = 3;
			tableRow.Cells.Add(tableCell);
			tableRow.Cells.Add(tableCell2);
			tableRow.Cells.Add(tableCell3);
			tableRow.Cells.Add(tableCell4);
			tableRow.Cells.Add(tableCell5);
			tableRow.Cells.Add(tableCell6);
			tableRow.Cells.Add(tableCell7);
			tableRow2.Cells.Add(tableCell8);
			tableRow2.Cells.Add(tableCell9);
			tableRow2.Cells.Add(tableCell10);
			table.Rows.Add(tableRow);
			table.Rows.Add(tableRow2);
			this.remplissage_tableau(table);
			sc.Blocks.Add(table);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0017E57C File Offset: 0x0017C77C
		private void entete_tableau(TableCell c, string u)
		{
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = u;
			paragraph.TextAlignment = 1;
			span.ForeColor = Color.Crimson;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(10.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			c.Blocks.Add(paragraph);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0017E604 File Offset: 0x0017C804
		private void ligne_tableau(TableCell c, string u)
		{
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = u;
			paragraph.TextAlignment = 0;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(10.0);
			span.FontWeight = FontWeights.Normal;
			paragraph.Inlines.Add(span);
			c.Blocks.Add(paragraph);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0017E68C File Offset: 0x0017C88C
		private void remplissage_tableau(Table t)
		{
			bool flag = ot_checklist.id_ot.Count != 0;
			if (flag)
			{
				for (int i = 0; i < ot_checklist.id_ot.Count; i++)
				{
					int num = 0;
					bd bd = new bd();
					string cmdText = "select intervenant.nom from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ordre_travail.id = @i ";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_checklist.id_ot[i];
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					int count = dataTable.Rows.Count;
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable.Rows.Count; j++)
						{
							TableRow tableRow = new TableRow();
							TableCell tableCell = new TableCell();
							TableCell tableCell2 = new TableCell();
							TableCell tableCell3 = new TableCell();
							TableCell tableCell4 = new TableCell();
							TableCell tableCell5 = new TableCell();
							TableCell tableCell6 = new TableCell();
							bool flag3 = num == 0;
							if (flag3)
							{
								this.ligne_tableau(tableCell, ot_checklist.code_equipement[i]);
								this.ligne_tableau(tableCell2, ot_checklist.gamme_operatoire[i]);
								this.ligne_tableau(tableCell3, ot_checklist.operation[i]);
								this.ligne_tableau(tableCell4, ot_checklist.superviseur[i] + " ");
								this.ligne_tableau(tableCell5, ot_checklist.debut_prevu[i]);
								this.ligne_tableau(tableCell6, ot_checklist.fin_prevu[i]);
								this.border_top_l(tableCell);
								this.border_top(tableCell2);
								this.border_top(tableCell3);
								this.border_top(tableCell4);
								this.border_top(tableCell5);
								this.border_top_r(tableCell6);
							}
							else
							{
								this.border_wost_l(tableCell);
								this.border_wost(tableCell2);
								this.border_wost(tableCell3);
								this.border_wost(tableCell4);
								this.border_wost(tableCell5);
								this.border_wost_r(tableCell6);
							}
							tableRow.Cells.Add(tableCell);
							tableRow.Cells.Add(tableCell2);
							tableRow.Cells.Add(tableCell3);
							tableRow.Cells.Add(tableCell4);
							tableRow.Cells.Add(tableCell5);
							tableRow.Cells.Add(tableCell6);
							string u = dataTable.Rows[j].ItemArray[0].ToString();
							TableCell tableCell7 = new TableCell();
							TableCell tableCell8 = new TableCell();
							TableCell tableCell9 = new TableCell();
							this.ligne_tableau(tableCell7, u);
							this.ligne_tableau(tableCell8, " ");
							this.ligne_tableau(tableCell9, " ");
							tableRow.Cells.Add(tableCell7);
							tableRow.Cells.Add(tableCell8);
							tableRow.Cells.Add(tableCell9);
							t.Rows.Add(tableRow);
							num++;
						}
					}
					for (int k = 0; k < 3; k++)
					{
						TableRow tableRow2 = new TableRow();
						TableCell tableCell10 = new TableCell();
						TableCell tableCell11 = new TableCell();
						TableCell tableCell12 = new TableCell();
						TableCell tableCell13 = new TableCell();
						TableCell tableCell14 = new TableCell();
						TableCell tableCell15 = new TableCell();
						bool flag4 = num == 0;
						if (flag4)
						{
							this.ligne_tableau(tableCell10, ot_checklist.code_equipement[i]);
							this.ligne_tableau(tableCell11, ot_checklist.gamme_operatoire[i]);
							this.ligne_tableau(tableCell12, ot_checklist.operation[i]);
							this.ligne_tableau(tableCell13, ot_checklist.superviseur[i] + " ");
							this.ligne_tableau(tableCell14, ot_checklist.debut_prevu[i]);
							this.ligne_tableau(tableCell15, ot_checklist.fin_prevu[i]);
							this.border_top_l(tableCell10);
							this.border_top(tableCell11);
							this.border_top(tableCell12);
							this.border_top(tableCell13);
							this.border_top(tableCell14);
							this.border_top_r(tableCell15);
						}
						else
						{
							bool flag5 = k != 2;
							if (flag5)
							{
								this.border_wost_l(tableCell10);
								this.border_wost(tableCell11);
								this.border_wost(tableCell12);
								this.border_wost(tableCell13);
								this.border_wost(tableCell14);
								this.border_wost_r(tableCell15);
							}
							bool flag6 = k == 2;
							if (flag6)
							{
								this.border_fin_l(tableCell10);
								this.border_fin(tableCell11);
								this.border_fin(tableCell12);
								this.border_fin(tableCell13);
								this.border_fin(tableCell14);
								this.border_fin_r(tableCell15);
							}
						}
						tableRow2.Cells.Add(tableCell10);
						tableRow2.Cells.Add(tableCell11);
						tableRow2.Cells.Add(tableCell12);
						tableRow2.Cells.Add(tableCell13);
						tableRow2.Cells.Add(tableCell14);
						tableRow2.Cells.Add(tableCell15);
						TableCell tableCell16 = new TableCell();
						TableCell tableCell17 = new TableCell();
						TableCell tableCell18 = new TableCell();
						this.ligne_tableau(tableCell16, " ");
						this.ligne_tableau(tableCell17, " ");
						this.ligne_tableau(tableCell18, " ");
						tableRow2.Cells.Add(tableCell16);
						tableRow2.Cells.Add(tableCell17);
						tableRow2.Cells.Add(tableCell18);
						t.Rows.Add(tableRow2);
						num++;
					}
				}
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0017EC28 File Offset: 0x0017CE28
		private void border_wost(TableCell c)
		{
			Border border = new Border(1, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(2, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0017EC88 File Offset: 0x0017CE88
		private void border_wost_r(TableCell c)
		{
			Border border = new Border(1, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(2, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0017ECE8 File Offset: 0x0017CEE8
		private void border_wost_l(TableCell c)
		{
			Border border = new Border(1, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(1, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0017ED48 File Offset: 0x0017CF48
		private void border_fin(TableCell c)
		{
			Border border = new Border(2, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(2, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0017EDA8 File Offset: 0x0017CFA8
		private void border_fin_r(TableCell c)
		{
			Border border = new Border(2, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(2, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0017EE08 File Offset: 0x0017D008
		private void border_fin_l(TableCell c)
		{
			Border border = new Border(2, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(1, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0017EE68 File Offset: 0x0017D068
		private void border_top(TableCell c)
		{
			Border border = new Border(1, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(2, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0017EEC8 File Offset: 0x0017D0C8
		private void border_top_r(TableCell c)
		{
			Border border = new Border(1, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(1, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(2, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0017EF28 File Offset: 0x0017D128
		private void border_top_l(TableCell c)
		{
			Border border = new Border(1, Color.FromRgb(0, 0, 0));
			Border border2 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border3 = new Border(2, Color.FromRgb(0, 0, 0));
			Border border4 = new Border(1, Color.FromRgb(0, 0, 0));
			TableCellBorders borders = new TableCellBorders(border2, border3, border4, border);
			c.Borders = borders;
		}
	}
}
