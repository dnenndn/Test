using System;
using System.Collections.Generic;
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
	// Token: 0x0200011F RID: 287
	public partial class rapport_fiche_diagnostic : Form
	{
		// Token: 0x06000CC0 RID: 3264 RVA: 0x001F00EA File Offset: 0x001EE2EA
		public rapport_fiche_diagnostic()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x001F0102 File Offset: 0x001EE302
		private void rapport_fiche_diagnostic_Load(object sender, EventArgs e)
		{
			this.laoding();
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x001F010C File Offset: 0x001EE30C
		private void laoding()
		{
			RadDocument radDocument = new RadDocument();
			Section section = new Section();
			Table table = new Table();
			TableRow tableRow = new TableRow();
			this.titre(section);
			this.general_ot(section);
			Paragraph paragraph = new Paragraph();
			section.Blocks.Add(paragraph);
			this.table_def(section);
			Paragraph paragraph2 = new Paragraph();
			section.Blocks.Add(paragraph2);
			Paragraph paragraph3 = new Paragraph();
			this.table_intervention(section);
			Paragraph paragraph4 = new Paragraph();
			section.Blocks.Add(paragraph4);
			Paragraph paragraph5 = new Paragraph();
			section.Blocks.Add(paragraph5);
			radDocument.Sections.Add(section);
			this.radRichTextEditor1.Document = radDocument;
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x001F01C8 File Offset: 0x001EE3C8
		private void titre(Section sc)
		{
			Table table = new Table();
			table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			TableCell tableCell2 = new TableCell();
			TableCell tableCell3 = new TableCell();
			Size size;
			size..ctor(50.0, 50.0);
			ImageInline imageInline;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Resources.logo_ibb.Save(memoryStream, ImageFormat.Png);
				imageInline = new ImageInline(memoryStream, size, "png");
			}
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = "FICHE DE DIAGNOSTIC";
			paragraph.TextAlignment = 1;
			span.ForeColor = Color.DimGray;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(16.0);
			span.FontWeight = FontWeights.Bold;
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			bd bd = new bd();
			string cmdText = "select n_ot  from ordre_travail where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			span2.Text = "OT N° :  " + dataTable.Rows[0].ItemArray[0].ToString();
			paragraph2.TextAlignment = 1;
			span2.ForeColor = Color.DimGray;
			span2.FontFamily = new FontFamily("Times New Roman");
			span2.FontSize = Unit.PointToDip(10.0);
			span2.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			paragraph2.Inlines.Add(span2);
			Paragraph paragraph3 = new Paragraph();
			paragraph3.Inlines.Add(imageInline);
			tableCell.Blocks.Add(paragraph);
			tableCell2.Blocks.Add(paragraph3);
			tableCell3.Blocks.Add(paragraph2);
			tableCell2.PreferredWidth = new TableWidthUnit(30.0);
			tableCell3.PreferredWidth = new TableWidthUnit(200.0);
			tableRow.Cells.Add(tableCell2);
			tableRow.Cells.Add(tableCell);
			tableRow.Cells.Add(tableCell3);
			table.Rows.Add(tableRow);
			sc.Blocks.Add(table);
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x001F0480 File Offset: 0x001EE680
		private void general_ot(Section sc)
		{
			Table table = new Table();
			table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow = new TableRow();
			TableRow tableRow2 = new TableRow();
			TableRow tableRow3 = new TableRow();
			TableCell tableCell = new TableCell();
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = "Détail de l'OT";
			paragraph.TextAlignment = 1;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(14.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			tableCell.Blocks.Add(paragraph);
			TableCell tableCell2 = new TableCell();
			TableCell tableCell3 = new TableCell();
			TableCell tableCell4 = new TableCell();
			TableCell tableCell5 = new TableCell();
			TableCell tableCell6 = new TableCell();
			TableCell tableCell7 = new TableCell();
			TableCell tableCell8 = new TableCell();
			TableCell tableCell9 = new TableCell();
			tableCell5.ColumnSpan = 2;
			bd bd = new bd();
			string cmdText = "select date_debut, heure_debut, urgence, utilisateur.login, atelier, equipement, sous_equipement, organe from ordre_travail inner join utilisateur on ordre_travail.createur = utilisateur.id where ordre_travail.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string str = fonction.Mid(dataTable.Rows[0].ItemArray[0].ToString(), 1, 10);
			string str2 = dataTable.Rows[0].ItemArray[1].ToString();
			string str3 = dataTable.Rows[0].ItemArray[2].ToString();
			string str4 = dataTable.Rows[0].ItemArray[3].ToString();
			string text = dataTable.Rows[0].ItemArray[4].ToString();
			string text2 = dataTable.Rows[0].ItemArray[5].ToString();
			string text3 = dataTable.Rows[0].ItemArray[6].ToString();
			string text4 = dataTable.Rows[0].ItemArray[7].ToString();
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			span2.Text = "Date de création : " + str + " à " + str2;
			paragraph2.TextAlignment = 0;
			span2.ForeColor = Color.Black;
			span2.FontFamily = new FontFamily("Times New Roman");
			span2.FontSize = Unit.PointToDip(12.0);
			span2.FontWeight = FontWeights.Normal;
			paragraph2.Inlines.Add(span2);
			tableCell2.Blocks.Add(paragraph2);
			Paragraph paragraph3 = new Paragraph();
			Span span3 = new Span();
			span3.Text = "Créateur : " + str4;
			paragraph3.TextAlignment = 0;
			span3.ForeColor = Color.Black;
			span3.FontFamily = new FontFamily("Times New Roman");
			span3.FontSize = Unit.PointToDip(12.0);
			span3.FontWeight = FontWeights.Normal;
			paragraph3.Inlines.Add(span3);
			tableCell3.Blocks.Add(paragraph3);
			Paragraph paragraph4 = new Paragraph();
			Span span4 = new Span();
			span4.Text = "Degré d'urgence : " + str3;
			paragraph4.TextAlignment = 0;
			span4.ForeColor = Color.Black;
			span4.FontFamily = new FontFamily("Times New Roman");
			span4.FontSize = Unit.PointToDip(12.0);
			span4.FontWeight = FontWeights.Normal;
			paragraph4.Inlines.Add(span4);
			tableCell4.Blocks.Add(paragraph4);
			tableRow.Cells.Add(tableCell);
			tableRow2.Cells.Add(tableCell2);
			tableRow3.Cells.Add(tableCell3);
			tableRow3.Cells.Add(tableCell4);
			tableCell.ColumnSpan = 2;
			tableCell2.ColumnSpan = 2;
			table.Rows.Add(tableRow);
			table.Rows.Add(tableRow2);
			table.Rows.Add(tableRow3);
			string str5 = "";
			string str6 = "";
			string str7 = "";
			string str8 = "";
			bool flag = text != "0";
			if (flag)
			{
				string cmdText2 = "select designation from equipement where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = text;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				str5 = dataTable2.Rows[0].ItemArray[0].ToString();
			}
			bool flag2 = text2 != "0";
			if (flag2)
			{
				string cmdText3 = "select designation from equipement where id = @i";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = text2;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				str6 = dataTable3.Rows[0].ItemArray[0].ToString();
			}
			bool flag3 = text3 != "0";
			if (flag3)
			{
				string cmdText4 = "select designation from equipement where id = @i";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = text3;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				str7 = dataTable4.Rows[0].ItemArray[0].ToString();
			}
			bool flag4 = text4 != "0";
			if (flag4)
			{
				string cmdText5 = "select designation from equipement where id = @i";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = text4;
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
				DataTable dataTable5 = new DataTable();
				sqlDataAdapter5.Fill(dataTable5);
				str8 = dataTable5.Rows[0].ItemArray[0].ToString();
			}
			Paragraph paragraph5 = new Paragraph();
			Span span5 = new Span();
			span5.Text = "Localisation de l'intervention";
			paragraph5.TextAlignment = 1;
			span5.ForeColor = Color.Black;
			span5.FontFamily = new FontFamily("Times New Roman");
			span5.FontSize = Unit.PointToDip(14.0);
			span5.FontWeight = FontWeights.Bold;
			paragraph5.Inlines.Add(span5);
			tableCell5.Blocks.Add(paragraph5);
			TableRow tableRow4 = new TableRow();
			tableRow4.Cells.Add(tableCell5);
			TableRow tableRow5 = new TableRow();
			TableRow tableRow6 = new TableRow();
			Paragraph paragraph6 = new Paragraph();
			Span span6 = new Span();
			span6.Text = "Atelier : " + str5;
			paragraph6.TextAlignment = 0;
			span6.ForeColor = Color.Black;
			span6.FontFamily = new FontFamily("Times New Roman");
			span6.FontSize = Unit.PointToDip(12.0);
			span6.FontWeight = FontWeights.Normal;
			paragraph6.Inlines.Add(span6);
			tableCell6.Blocks.Add(paragraph6);
			Paragraph paragraph7 = new Paragraph();
			Span span7 = new Span();
			span7.Text = "Equipement : " + str6;
			paragraph7.TextAlignment = 0;
			span7.ForeColor = Color.Black;
			span7.FontFamily = new FontFamily("Times New Roman");
			span7.FontSize = Unit.PointToDip(12.0);
			span7.FontWeight = FontWeights.Normal;
			paragraph7.Inlines.Add(span7);
			tableCell7.Blocks.Add(paragraph7);
			Paragraph paragraph8 = new Paragraph();
			Span span8 = new Span();
			span8.Text = "Sous-équipement : " + str7;
			paragraph8.TextAlignment = 0;
			span8.ForeColor = Color.Black;
			span8.FontFamily = new FontFamily("Times New Roman");
			span8.FontSize = Unit.PointToDip(12.0);
			span8.FontWeight = FontWeights.Normal;
			paragraph8.Inlines.Add(span8);
			tableCell8.Blocks.Add(paragraph8);
			Paragraph paragraph9 = new Paragraph();
			Span span9 = new Span();
			span9.Text = "Organe : " + str8;
			paragraph9.TextAlignment = 0;
			span9.ForeColor = Color.Black;
			span9.FontFamily = new FontFamily("Times New Roman");
			span9.FontSize = Unit.PointToDip(12.0);
			span9.FontWeight = FontWeights.Normal;
			paragraph9.Inlines.Add(span9);
			tableCell9.Blocks.Add(paragraph9);
			tableRow5.Cells.Add(tableCell6);
			tableRow5.Cells.Add(tableCell7);
			tableRow6.Cells.Add(tableCell8);
			tableRow6.Cells.Add(tableCell9);
			table.Rows.Add(tableRow4);
			table.Rows.Add(tableRow5);
			table.Rows.Add(tableRow6);
			sc.Blocks.Add(table);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x001F0E4C File Offset: 0x001EF04C
		private void table_def(Section sc)
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
			tableCell2.ColumnSpan = 2;
			tableCell3.ColumnSpan = 3;
			TableCell tableCell6 = new TableCell();
			TableCell tableCell7 = new TableCell();
			TableCell tableCell8 = new TableCell();
			TableCell tableCell9 = new TableCell();
			TableCell tableCell10 = new TableCell();
			TableCell tableCell11 = new TableCell();
			TableCell tableCell12 = new TableCell();
			TableCell tableCell13 = new TableCell();
			this.entete_tableau(tableCell, "Défaillance");
			this.entete_tableau(tableCell2, "Symptôme");
			this.entete_tableau(tableCell3, "Opération");
			this.entete_tableau(tableCell4, "Détection");
			this.entete_tableau(tableCell5, "Résultat");
			this.entete_tableau_2(tableCell7, "Désignation");
			this.entete_tableau_2(tableCell8, "Résultat");
			this.entete_tableau_2(tableCell9, "Désignation");
			this.entete_tableau_2(tableCell10, "Début");
			this.entete_tableau_2(tableCell11, "Fin");
			tableRow.Cells.Add(tableCell);
			tableRow.Cells.Add(tableCell2);
			tableRow.Cells.Add(tableCell3);
			tableRow.Cells.Add(tableCell4);
			tableRow.Cells.Add(tableCell5);
			tableRow2.Cells.Add(tableCell6);
			tableRow2.Cells.Add(tableCell7);
			tableRow2.Cells.Add(tableCell8);
			tableRow2.Cells.Add(tableCell9);
			tableRow2.Cells.Add(tableCell10);
			tableRow2.Cells.Add(tableCell11);
			tableRow2.Cells.Add(tableCell12);
			tableRow2.Cells.Add(tableCell13);
			table.Rows.Add(tableRow);
			table.Rows.Add(tableRow2);
			this.remplissage_tab_def(table);
			string cmdText = "select id_defaillance from ordre_travail where id = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.remplissage_tab_def_autre(table, dataTable.Rows[0].ItemArray[0].ToString());
			sc.Blocks.Add(table);
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x001F10D0 File Offset: 0x001EF2D0
		private void entete_tableau(TableCell c, string u)
		{
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = u;
			paragraph.TextAlignment = 0;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(12.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			c.Blocks.Add(paragraph);
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x001F1158 File Offset: 0x001EF358
		private void entete_tableau_2(TableCell c, string u)
		{
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = u;
			paragraph.TextAlignment = 0;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(10.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			c.Blocks.Add(paragraph);
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x001F11E0 File Offset: 0x001EF3E0
		private void entete_tableau_3(TableCell c, string u)
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

		// Token: 0x06000CC9 RID: 3273 RVA: 0x001F1268 File Offset: 0x001EF468
		private void remplissage_tab_def(Table t)
		{
			bd bd = new bd();
			int num = 1;
			string cmdText = "select distinct designation from symptome where id in(select id_symptome from symptome_defaillance inner join ordre_travail on symptome_defaillance.id_defaillance = ordre_travail.id_defaillance where ordre_travail.id = @i1)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				num = dataTable.Rows.Count;
			}
			string cmdText2 = "select designation from operation_diagnostic inner join ordre_travail on operation_diagnostic.id_defaillance = ordre_travail.id_defaillance where ordre_travail.id = @i1";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				bool flag3 = dataTable2.Rows.Count > num;
				if (flag3)
				{
					num = dataTable2.Rows.Count;
				}
			}
			string cmdText3 = "select anomalie from parametre_anomalie inner join ordre_travail on parametre_anomalie.id = ordre_travail.id_defaillance where ordre_travail.id = @i1";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < num; i++)
			{
				list.Add(" ");
				list2.Add(" ");
			}
			bool flag4 = dataTable.Rows.Count != 0;
			if (flag4)
			{
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					list[j] = dataTable.Rows[j].ItemArray[0].ToString();
				}
			}
			bool flag5 = dataTable2.Rows.Count != 0;
			if (flag5)
			{
				for (int k = 0; k < dataTable2.Rows.Count; k++)
				{
					list2[k] = dataTable2.Rows[k].ItemArray[0].ToString();
				}
			}
			bool flag6 = num != 0;
			if (flag6)
			{
				for (int l = 0; l < num; l++)
				{
					bool flag7 = l == 0;
					if (flag7)
					{
						TableRow tableRow = new TableRow();
						TableCell tableCell = new TableCell();
						TableCell tableCell2 = new TableCell();
						TableCell tableCell3 = new TableCell();
						TableCell tableCell4 = new TableCell();
						TableCell tableCell5 = new TableCell();
						TableCell tableCell6 = new TableCell();
						TableCell tableCell7 = new TableCell();
						TableCell tableCell8 = new TableCell();
						string u = " ";
						bool flag8 = dataTable3.Rows.Count != 0;
						if (flag8)
						{
							u = dataTable3.Rows[0].ItemArray[0].ToString();
						}
						tableCell.RowSpan = num;
						this.entete_tableau_3(tableCell, u);
						this.entete_tableau_3(tableCell2, list[l]);
						this.entete_tableau_3(tableCell4, list2[l]);
						tableRow.Cells.Add(tableCell);
						tableRow.Cells.Add(tableCell2);
						tableRow.Cells.Add(tableCell3);
						tableRow.Cells.Add(tableCell4);
						tableRow.Cells.Add(tableCell5);
						tableRow.Cells.Add(tableCell6);
						tableRow.Cells.Add(tableCell7);
						tableRow.Cells.Add(tableCell8);
						t.Rows.Add(tableRow);
					}
					else
					{
						TableRow tableRow2 = new TableRow();
						TableCell tableCell9 = new TableCell();
						TableCell tableCell10 = new TableCell();
						TableCell tableCell11 = new TableCell();
						TableCell tableCell12 = new TableCell();
						TableCell tableCell13 = new TableCell();
						TableCell tableCell14 = new TableCell();
						TableCell tableCell15 = new TableCell();
						TableCell tableCell16 = new TableCell();
						tableCell9.RowSpan = num;
						this.entete_tableau_3(tableCell10, list[l]);
						this.entete_tableau_3(tableCell12, list2[l]);
						tableRow2.Cells.Add(tableCell10);
						tableRow2.Cells.Add(tableCell11);
						tableRow2.Cells.Add(tableCell12);
						tableRow2.Cells.Add(tableCell13);
						tableRow2.Cells.Add(tableCell14);
						tableRow2.Cells.Add(tableCell15);
						tableRow2.Cells.Add(tableCell16);
						t.Rows.Add(tableRow2);
					}
				}
			}
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x001F1728 File Offset: 0x001EF928
		private void remplissage_tab_def_autre(Table t, string id)
		{
			bd bd = new bd();
			string cmdText = "select id_anomalie, parametre_anomalie.anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where id_parent = @h";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int num = 1;
					string text = dataTable.Rows[i].ItemArray[0].ToString();
					string cmdText2 = "select designation from symptome where id in (select id_symptome from symptome_defaillance where id_defaillance = @i1)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = text;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						num = dataTable2.Rows.Count;
					}
					string cmdText3 = "select designation from operation_diagnostic where id_defaillance = @i1";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = text;
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						bool flag4 = dataTable3.Rows.Count > num;
						if (flag4)
						{
							num = dataTable3.Rows.Count;
						}
					}
					List<string> list = new List<string>();
					List<string> list2 = new List<string>();
					for (int j = 0; j < num; j++)
					{
						list.Add(" ");
						list2.Add(" ");
					}
					bool flag5 = dataTable2.Rows.Count != 0;
					if (flag5)
					{
						for (int k = 0; k < dataTable2.Rows.Count; k++)
						{
							list[k] = dataTable2.Rows[k].ItemArray[0].ToString();
						}
					}
					bool flag6 = dataTable3.Rows.Count != 0;
					if (flag6)
					{
						for (int l = 0; l < dataTable3.Rows.Count; l++)
						{
							list2[l] = dataTable3.Rows[l].ItemArray[0].ToString();
						}
					}
					bool flag7 = num != 0;
					if (flag7)
					{
						for (int m = 0; m < num; m++)
						{
							bool flag8 = m == 0;
							if (flag8)
							{
								TableRow tableRow = new TableRow();
								TableCell tableCell = new TableCell();
								TableCell tableCell2 = new TableCell();
								TableCell tableCell3 = new TableCell();
								TableCell tableCell4 = new TableCell();
								TableCell tableCell5 = new TableCell();
								TableCell tableCell6 = new TableCell();
								TableCell tableCell7 = new TableCell();
								TableCell tableCell8 = new TableCell();
								tableCell.RowSpan = num;
								this.entete_tableau_3(tableCell, dataTable.Rows[i].ItemArray[1].ToString());
								this.entete_tableau_3(tableCell2, list[m]);
								this.entete_tableau_3(tableCell4, list2[m]);
								tableRow.Cells.Add(tableCell);
								tableRow.Cells.Add(tableCell2);
								tableRow.Cells.Add(tableCell3);
								tableRow.Cells.Add(tableCell4);
								tableRow.Cells.Add(tableCell5);
								tableRow.Cells.Add(tableCell6);
								tableRow.Cells.Add(tableCell7);
								tableRow.Cells.Add(tableCell8);
								t.Rows.Add(tableRow);
							}
							else
							{
								TableRow tableRow2 = new TableRow();
								TableCell tableCell9 = new TableCell();
								TableCell tableCell10 = new TableCell();
								TableCell tableCell11 = new TableCell();
								TableCell tableCell12 = new TableCell();
								TableCell tableCell13 = new TableCell();
								TableCell tableCell14 = new TableCell();
								TableCell tableCell15 = new TableCell();
								TableCell tableCell16 = new TableCell();
								tableCell9.RowSpan = num;
								this.entete_tableau_3(tableCell10, list[m]);
								this.entete_tableau_3(tableCell12, list2[m]);
								tableRow2.Cells.Add(tableCell10);
								tableRow2.Cells.Add(tableCell11);
								tableRow2.Cells.Add(tableCell12);
								tableRow2.Cells.Add(tableCell13);
								tableRow2.Cells.Add(tableCell14);
								tableRow2.Cells.Add(tableCell15);
								tableRow2.Cells.Add(tableCell16);
								t.Rows.Add(tableRow2);
							}
						}
					}
					this.remplissage_tab_def_autre(t, text);
				}
			}
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x001F1C20 File Offset: 0x001EFE20
		private void table_intervention(Section sc)
		{
			Table table = new Table();
			table.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			TableCell tableCell2 = new TableCell();
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = "Intervention a réalisée";
			paragraph.TextAlignment = 1;
			span.ForeColor = Color.Black;
			span.FontFamily = new FontFamily("Times New Roman");
			span.FontSize = Unit.PointToDip(14.0);
			span.FontWeight = FontWeights.Bold;
			paragraph.Inlines.Add(span);
			tableCell.Blocks.Add(paragraph);
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			span2.Text = " ";
			paragraph2.Inlines.Add(span2);
			tableCell2.Blocks.Add(paragraph2);
			tableRow.Cells.Add(tableCell);
			TableRow tableRow2 = new TableRow();
			tableRow2.Cells.Add(tableCell2);
			tableRow2.Height = 100.0;
			table.Rows.Add(tableRow);
			table.Rows.Add(tableRow2);
			sc.Blocks.Add(table);
		}
	}
}
