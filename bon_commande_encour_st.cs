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
using Telerik.WinForms.Documents.Layout;
using Telerik.WinForms.Documents.Model;

namespace GMAO
{
	// Token: 0x0200002D RID: 45
	public partial class bon_commande_encour_st : Form
	{
		// Token: 0x06000237 RID: 567 RVA: 0x0005FB7B File Offset: 0x0005DD7B
		public bon_commande_encour_st()
		{
			this.InitializeComponent();
			this.test();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0005FB9A File Offset: 0x0005DD9A
		private void bon_commande_encour_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0005FBA0 File Offset: 0x0005DDA0
		private void test()
		{
			bd bd = new bd();
			Table table = new Table();
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			TableCell tableCell2 = new TableCell();
			string cmdText = "select adresse, telephone_1, email, code_fournisseur, tva_defaut from fournisseur where nom = @i ";
			string cmdText2 = "select personne_contacter, createur, utilisateur.mail, utilisateur.telephone from ds_commande inner join utilisateur on ds_commande.createur = utilisateur.id where ds_commande.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = commande_encour_st.id_commande;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string str = "";
			string str2 = "";
			string str3 = "";
			string str4 = "";
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				str = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
				str2 = this.select_utilisateur(Convert.ToString(dataTable.Rows[0].ItemArray[1]));
				str3 = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
				str4 = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
			}
			SqlCommand sqlCommand2 = new SqlCommand(cmdText, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.VarChar).Value = commande_encour_st.nom_fournisseur;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			string cmdText3 = "select ds_commande.id from ds_commande inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id and fournisseur.nom = @i2 and ds_commande.id < @i3";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = commande_encour_st.nom_fournisseur;
			sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = commande_encour_st.id_commande;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			int num = dataTable3.Rows.Count + 1;
			RadDocument radDocument = new RadDocument();
			Section section = new Section();
			Paragraph paragraph = new Paragraph();
			Span span = new Span("IDEAL BRIQUE BENI HASSEN");
			span.ForeColor = Color.Black;
			paragraph.TextAlignment = 0;
			paragraph.LineSpacing = 1.0;
			span.FontFamily = new FontFamily("Verdana 12");
			span.FontSize = Unit.PointToDip(12.0);
			span.FontWeight = FontWeights.Bold;
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span(commande_encour_st.nom_fournisseur ?? "");
			span2.ForeColor = Color.Black;
			paragraph2.TextAlignment = 0;
			paragraph2.LineSpacing = 1.0;
			span2.FontFamily = new FontFamily("Verdana 12");
			span2.FontSize = Unit.PointToDip(12.0);
			span2.FontWeight = FontWeights.Bold;
			Paragraph paragraph3 = new Paragraph();
			Span span3 = new Span("Adresse : route de Mahdia 5014 Béni Hassen");
			span3.ForeColor = Color.Black;
			paragraph3.TextAlignment = 0;
			paragraph3.LineSpacing = 1.0;
			span3.FontFamily = new FontFamily("Times New Roman");
			span3.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph4 = new Paragraph();
			object obj = dataTable2.Rows[0].ItemArray[3];
			Span span4 = new Span(((obj != null) ? obj.ToString() : null) + "-C-" + num.ToString());
			span4.ForeColor = Color.Black;
			paragraph4.TextAlignment = 0;
			paragraph4.LineSpacing = 1.0;
			span4.FontFamily = new FontFamily("Times New Roman");
			span4.FontSize = Unit.PointToDip(12.0);
			string text = "Tel : " + str4 + " , Fax : 73 491 555";
			Paragraph paragraph5 = new Paragraph();
			Span span5 = new Span(text ?? "");
			span5.ForeColor = Color.Black;
			paragraph5.TextAlignment = 0;
			paragraph5.LineSpacing = 1.0;
			span5.FontFamily = new FontFamily("Times New Roman");
			span5.FontSize = Unit.PointToDip(12.0);
			string text2 = "Tél: " + dataTable2.Rows[0].ItemArray[1].ToString();
			Paragraph paragraph6 = new Paragraph();
			Span span6 = new Span(text2 ?? "");
			span6.ForeColor = Color.Black;
			paragraph6.TextAlignment = 0;
			paragraph6.LineSpacing = 1.0;
			span6.FontFamily = new FontFamily("Times New Roman");
			span6.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph7 = new Paragraph();
			Span span7 = new Span("MF : 1086534 EAM 000");
			span7.ForeColor = Color.Black;
			paragraph7.TextAlignment = 0;
			paragraph7.LineSpacing = 1.0;
			span7.FontFamily = new FontFamily("Times New Roman");
			span7.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph8 = new Paragraph();
			Span span8 = new Span("Adresse : " + dataTable2.Rows[0].ItemArray[0].ToString());
			span8.ForeColor = Color.Black;
			paragraph8.TextAlignment = 0;
			paragraph8.LineSpacing = 1.0;
			span8.FontFamily = new FontFamily("Times New Roman");
			span8.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph9 = new Paragraph();
			Span span9 = new Span("Email : " + str3);
			span9.ForeColor = Color.Black;
			paragraph9.TextAlignment = 0;
			span9.FontFamily = new FontFamily("Times New Roman");
			paragraph9.LineSpacing = 1.0;
			span9.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph10 = new Paragraph();
			Span span10 = new Span("Email : " + dataTable2.Rows[0].ItemArray[2].ToString());
			span10.ForeColor = Color.Black;
			paragraph10.TextAlignment = 0;
			span10.FontFamily = new FontFamily("Times New Roman");
			paragraph10.LineSpacing = 1.0;
			span10.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph11 = new Paragraph();
			Span span11 = new Span("Emetteur : " + str2);
			span11.ForeColor = Color.Black;
			paragraph11.TextAlignment = 0;
			span11.FontFamily = new FontFamily("Times New Roman");
			span11.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph12 = new Paragraph();
			Span span12 = new Span("Contact : " + str);
			span12.ForeColor = Color.Black;
			paragraph12.TextAlignment = 0;
			span12.FontFamily = new FontFamily("Times New Roman");
			span12.FontSize = Unit.PointToDip(12.0);
			paragraph.Inlines.Add(span);
			paragraph2.Inlines.Add(span2);
			paragraph3.Inlines.Add(span3);
			paragraph4.Inlines.Add(span4);
			paragraph5.Inlines.Add(span5);
			paragraph6.Inlines.Add(span6);
			paragraph7.Inlines.Add(span7);
			paragraph8.Inlines.Add(span8);
			paragraph9.Inlines.Add(span9);
			paragraph10.Inlines.Add(span10);
			paragraph11.Inlines.Add(span11);
			paragraph12.Inlines.Add(span12);
			tableCell.Blocks.Add(paragraph);
			tableCell.Blocks.Add(paragraph3);
			tableCell.Blocks.Add(paragraph5);
			tableCell.Blocks.Add(paragraph7);
			tableCell.Blocks.Add(paragraph9);
			tableCell.Blocks.Add(paragraph11);
			tableCell2.Blocks.Add(paragraph2);
			tableCell2.Blocks.Add(paragraph4);
			tableCell2.Blocks.Add(paragraph6);
			tableCell2.Blocks.Add(paragraph8);
			tableCell2.Blocks.Add(paragraph10);
			tableCell2.Blocks.Add(paragraph12);
			tableRow.Cells.Add(tableCell);
			tableRow.Cells.Add(tableCell2);
			table.Rows.Add(tableRow);
			Size size;
			size..ctor(110.0, 110.0);
			Size size2;
			size2..ctor(760.0, 40.0);
			Size size3;
			size3..ctor(500.0, 150.0);
			ImageInline imageInline;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Resources.logo_ibb.Save(memoryStream, ImageFormat.Png);
				imageInline = new ImageInline(memoryStream, size, "png");
			}
			ImageInline imageInline2;
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				Resources.bnco.Save(memoryStream2, ImageFormat.Png);
				imageInline2 = new ImageInline(memoryStream2, size2, "png");
			}
			ImageInline imageInline3;
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				Resources.signature_khalil___ahmed_soussia.Save(memoryStream3, ImageFormat.Png);
				imageInline3 = new ImageInline(memoryStream3, size3, "png");
			}
			Paragraph paragraph13 = new Paragraph();
			paragraph13.TextAlignment = 1;
			Span span13 = new Span("              ");
			Span span14 = new Span();
			Paragraph paragraph14 = new Paragraph();
			span14.Text = "                           Bon de Commande";
			span14.FontWeight = FontWeights.Bold;
			span14.FontFamily = new FontFamily("Baskerville Old Face");
			span14.FontSize = Unit.PointToDip(28.0);
			paragraph13.Inlines.Add(span14);
			Paragraph paragraph15 = new Paragraph();
			Paragraph paragraph16 = new Paragraph();
			paragraph16.TextAlignment = 1;
			Span span15 = new Span();
			string cmdText4 = "select date_commande from ds_commande where id = @i";
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
			sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = commande_encour_st.id_commande;
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
			DataTable dataTable4 = new DataTable();
			sqlDataAdapter4.Fill(dataTable4);
			span15.Text = "                       Date : " + fonction.Mid(dataTable4.Rows[0].ItemArray[0].ToString(), 1, 10);
			span15.FontFamily = new FontFamily("Calibri");
			span15.FontSize = Unit.PointToDip(12.0);
			paragraph16.Inlines.Add(span15);
			paragraph15.LineSpacingType = 2;
			paragraph15.LineSpacing = 12.5;
			paragraph15.Inlines.Add(span13);
			paragraph15.Inlines.Add(imageInline);
			Paragraph paragraph17 = new Paragraph();
			section.Blocks.Add(paragraph17);
			section.Blocks.Add(paragraph13);
			section.Blocks.Add(paragraph16);
			section.Children.Add(paragraph15);
			Paragraph paragraph18 = new Paragraph();
			paragraph18.Inlines.Add(imageInline2);
			section.Blocks.Add(paragraph18);
			section.Blocks.Add(table);
			Table table2 = new Table();
			table2.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow2 = new TableRow();
			TableCell tableCell3 = new TableCell();
			Paragraph paragraph19 = new Paragraph();
			Span span16 = new Span();
			span16.FontFamily = new FontFamily("Calibri");
			span16.FontSize = Unit.PointToDip(14.0);
			span16.FontWeight = FontWeights.Bold;
			span16.Text = "Code Article";
			paragraph19.Inlines.Add(span16);
			tableCell3.Blocks.Add(paragraph19);
			tableRow2.Cells.Add(tableCell3);
			TableCell tableCell4 = new TableCell();
			Paragraph paragraph20 = new Paragraph();
			Span span17 = new Span();
			span17.Text = "Désignation";
			paragraph20.Inlines.Add(span17);
			tableCell4.Blocks.Add(paragraph20);
			span17.FontFamily = new FontFamily("Calibri");
			span17.FontSize = Unit.PointToDip(14.0);
			span17.FontWeight = FontWeights.Bold;
			tableRow2.Cells.Add(tableCell4);
			TableCell tableCell5 = new TableCell();
			Paragraph paragraph21 = new Paragraph();
			Span span18 = new Span();
			span18.Text = "Activité";
			paragraph21.Inlines.Add(span18);
			tableCell5.Blocks.Add(paragraph21);
			TableCell tableCell6 = new TableCell();
			Paragraph paragraph22 = new Paragraph();
			Span span19 = new Span();
			span19.Text = "Description";
			paragraph22.Inlines.Add(span19);
			tableCell6.Blocks.Add(paragraph22);
			TableCell tableCell7 = new TableCell();
			Paragraph paragraph23 = new Paragraph();
			Span span20 = new Span();
			span20.Text = "Quantité";
			paragraph23.Inlines.Add(span20);
			tableCell7.Blocks.Add(paragraph23);
			TableCell tableCell8 = new TableCell();
			Paragraph paragraph24 = new Paragraph();
			Span span21 = new Span();
			span21.Text = "Prix U HT";
			paragraph24.Inlines.Add(span21);
			tableCell8.Blocks.Add(paragraph24);
			TableCell tableCell9 = new TableCell();
			Paragraph paragraph25 = new Paragraph();
			Span span22 = new Span();
			span22.Text = "Remise (%)";
			paragraph25.Inlines.Add(span22);
			tableCell9.Blocks.Add(paragraph25);
			TableCell tableCell10 = new TableCell();
			Paragraph paragraph26 = new Paragraph();
			Span span23 = new Span();
			span23.Text = "Prix Tot HT";
			paragraph26.Inlines.Add(span23);
			tableCell10.Blocks.Add(paragraph26);
			span18.FontFamily = new FontFamily("Calibri");
			span18.FontSize = Unit.PointToDip(14.0);
			span18.FontWeight = FontWeights.Bold;
			span19.FontFamily = new FontFamily("Calibri");
			span19.FontSize = Unit.PointToDip(14.0);
			span19.FontWeight = FontWeights.Bold;
			span20.FontFamily = new FontFamily("Calibri");
			span20.FontSize = Unit.PointToDip(14.0);
			span20.FontWeight = FontWeights.Bold;
			span21.FontFamily = new FontFamily("Calibri");
			span21.FontSize = Unit.PointToDip(14.0);
			span21.FontWeight = FontWeights.Bold;
			span22.FontFamily = new FontFamily("Calibri");
			span22.FontSize = Unit.PointToDip(14.0);
			span22.FontWeight = FontWeights.Bold;
			span23.FontFamily = new FontFamily("Calibri");
			span23.FontSize = Unit.PointToDip(14.0);
			span23.FontWeight = FontWeights.Bold;
			tableRow2.Cells.Add(tableCell5);
			tableRow2.Cells.Add(tableCell6);
			tableRow2.Cells.Add(tableCell7);
			tableRow2.Cells.Add(tableCell8);
			tableRow2.Cells.Add(tableCell9);
			tableRow2.Cells.Add(tableCell10);
			tableCell3.Background = Color.Silver;
			tableCell4.Background = Color.Silver;
			tableCell5.Background = Color.Silver;
			tableCell6.Background = Color.Silver;
			tableCell7.Background = Color.Silver;
			tableCell8.Background = Color.Silver;
			tableCell9.Background = Color.Silver;
			tableCell10.Background = Color.Silver;
			table2.Rows.Add(tableRow2);
			string cmdText5 = "select article.code_article, article.designation, activite.designation,magasin_sous_traitance.description,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s  and ds_commande_article.id_commande = @i ";
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
			sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = commande_encour_st.id_commande;
			sqlCommand5.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
			DataTable dataTable5 = new DataTable();
			sqlDataAdapter5.Fill(dataTable5);
			double num2 = 0.0;
			bool flag2 = dataTable5.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable5.Rows.Count; i++)
				{
					double num3 = Convert.ToDouble(dataTable5.Rows[i].ItemArray[5]);
					double num4 = Convert.ToDouble(dataTable5.Rows[i].ItemArray[6]);
					double num5 = Convert.ToDouble(dataTable5.Rows[i].ItemArray[4]);
					double num6 = num3 * num5;
					num6 -= num6 * num4 / 100.0;
					num2 += num6;
					string h = dataTable5.Rows[i].ItemArray[0].ToString();
					string h2 = dataTable5.Rows[i].ItemArray[1].ToString();
					string h3 = dataTable5.Rows[i].ItemArray[4].ToString();
					string h4 = dataTable5.Rows[i].ItemArray[2].ToString();
					string h5 = " ";
					bool flag3 = Convert.ToString(dataTable5.Rows[i].ItemArray[3]) != "";
					if (flag3)
					{
						h5 = dataTable5.Rows[i].ItemArray[3].ToString();
					}
					string h6 = num3.ToString("0.000");
					string h7 = num4.ToString();
					string h8 = num6.ToString("0.000");
					this.remplissage_tableau(table2, h, h2, h4, h5, h3, h6, h7, h8);
				}
			}
			string cmdText6 = "select article.code_article, article.designation, activite.designation,ds_nv_article.description,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s  and ds_commande_article.id_commande = @i ";
			SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
			sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = commande_encour_st.id_commande;
			sqlCommand6.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
			DataTable dataTable6 = new DataTable();
			sqlDataAdapter6.Fill(dataTable6);
			bool flag4 = dataTable6.Rows.Count != 0;
			if (flag4)
			{
				for (int j = 0; j < dataTable6.Rows.Count; j++)
				{
					double num7 = Convert.ToDouble(dataTable6.Rows[j].ItemArray[5]);
					double num8 = Convert.ToDouble(dataTable6.Rows[j].ItemArray[6]);
					double num9 = Convert.ToDouble(dataTable6.Rows[j].ItemArray[4]);
					double num10 = num7 * num9;
					num10 -= num10 * num8 / 100.0;
					num2 += num10;
					string h9 = dataTable6.Rows[j].ItemArray[0].ToString();
					string h10 = dataTable6.Rows[j].ItemArray[1].ToString();
					string h11 = dataTable6.Rows[j].ItemArray[2].ToString();
					string h12 = " ";
					bool flag5 = Convert.ToString(dataTable6.Rows[j].ItemArray[3]) != "";
					if (flag5)
					{
						h12 = dataTable6.Rows[j].ItemArray[3].ToString();
					}
					string h13 = dataTable6.Rows[j].ItemArray[4].ToString();
					string h14 = num7.ToString("0.000");
					string h15 = num8.ToString();
					string h16 = num10.ToString("0.000");
					this.remplissage_tableau(table2, h9, h10, h11, h12, h13, h14, h15, h16);
				}
			}
			string cmdText7 = "select fodec from ds_commande where id = @i";
			SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
			sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = commande_encour_st.id_commande;
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
			DataTable dataTable7 = new DataTable();
			sqlDataAdapter7.Fill(dataTable7);
			int num11 = 0;
			fonction fonction = new fonction();
			bool flag6 = fonction.isnumeric(Convert.ToString(dataTable7.Rows[0].ItemArray[0]));
			if (flag6)
			{
				num11 = Convert.ToInt32(dataTable7.Rows[0].ItemArray[0]);
			}
			section.Blocks.Add(table2);
			section.Blocks.Add(new Paragraph());
			Paragraph paragraph27 = new Paragraph();
			paragraph27.LineSpacing = 0.5;
			paragraph27.TextAlignment = 0;
			Span span24 = new Span("                                                                                                         Total HT : " + num2.ToString("0.000") + "     ");
			span24.FontFamily = new FontFamily("Verdana");
			span24.FontSize = Unit.PointToDip(12.0);
			section.Blocks.Add(paragraph27);
			paragraph27.Inlines.Add(span24);
			Paragraph paragraph28 = new Paragraph();
			paragraph28.LineSpacing = 0.5;
			paragraph28.TextAlignment = 0;
			Span span25 = new Span("                                                                                                         Fodec : " + num11.ToString() + " %    ");
			span25.FontFamily = new FontFamily("Verdana");
			span25.FontSize = Unit.PointToDip(12.0);
			section.Blocks.Add(paragraph28);
			paragraph28.Inlines.Add(span25);
			Paragraph paragraph29 = new Paragraph();
			paragraph29.TextAlignment = 0;
			Span span26 = new Span();
			span26.Text = "                                                                                                         TVA :   " + dataTable2.Rows[0].ItemArray[4].ToString() + "  % ";
			span26.FontFamily = new FontFamily("Verdana");
			span26.FontSize = Unit.PointToDip(12.0);
			paragraph29.LineSpacing = 0.5;
			paragraph29.Inlines.Add(span26);
			section.Blocks.Add(paragraph29);
			double num12 = num2 + (double)num11 * num2 / 100.0;
			double value = num12 + Convert.ToDouble(dataTable2.Rows[0].ItemArray[4].ToString()) * num12 / 100.0;
			value = Math.Round(value, 3);
			Paragraph paragraph30 = new Paragraph();
			paragraph30.TextAlignment = 0;
			paragraph30.LineSpacing = 0.5;
			Span span27 = new Span();
			span27.Text = "                                                                                                         Total TTC :  " + value.ToString("0.000") + "    ";
			span27.FontFamily = new FontFamily("Verdana");
			span27.FontSize = Unit.PointToDip(12.0);
			paragraph30.Inlines.Add(span27);
			section.Blocks.Add(paragraph30);
			section.Blocks.Add(new Paragraph());
			section.Blocks.Add(new Paragraph());
			Paragraph paragraph31 = new Paragraph();
			paragraph31.TextAlignment = 1;
			paragraph31.Inlines.Add(imageInline3);
			section.Blocks.Add(paragraph31);
			section.Blocks.Add(new Paragraph());
			section.Blocks.Add(new Paragraph());
			radDocument.Sections.Add(section);
			this.radRichTextEditor1.Document = radDocument;
			this.radRichTextEditor1.ChangeSectionPageMargin(new Padding(25, 20, 25, 20));
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000614F0 File Offset: 0x0005F6F0
		private void remplissage_tableau(Table t, string h1, string h2, string h3, string h4, string h5, string h6)
		{
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = h1;
			paragraph.Inlines.Add(span);
			tableCell.Blocks.Add(paragraph);
			span.FontFamily = new FontFamily("Calibri");
			span.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell);
			TableCell tableCell2 = new TableCell();
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			span2.Text = h2;
			paragraph2.Inlines.Add(span2);
			tableCell2.Blocks.Add(paragraph2);
			span2.FontFamily = new FontFamily("Calibri");
			span2.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell2);
			TableCell tableCell3 = new TableCell();
			Paragraph paragraph3 = new Paragraph();
			Span span3 = new Span();
			span3.Text = h3;
			paragraph3.Inlines.Add(span3);
			tableCell3.Blocks.Add(paragraph3);
			span3.FontFamily = new FontFamily("Calibri");
			span3.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell3);
			TableCell tableCell4 = new TableCell();
			Paragraph paragraph4 = new Paragraph();
			Span span4 = new Span();
			span4.Text = h4;
			paragraph4.Inlines.Add(span4);
			tableCell4.Blocks.Add(paragraph4);
			span4.FontFamily = new FontFamily("Calibri");
			span4.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell4);
			TableCell tableCell5 = new TableCell();
			Paragraph paragraph5 = new Paragraph();
			Span span5 = new Span();
			span5.Text = h5;
			paragraph5.Inlines.Add(span5);
			tableCell5.Blocks.Add(paragraph5);
			span5.FontFamily = new FontFamily("Calibri");
			span5.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell5);
			TableCell tableCell6 = new TableCell();
			Paragraph paragraph6 = new Paragraph();
			Span span6 = new Span();
			span6.Text = h6;
			paragraph6.Inlines.Add(span6);
			tableCell6.Blocks.Add(paragraph6);
			span6.FontFamily = new FontFamily("Calibri");
			span6.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell6);
			t.Rows.Add(tableRow);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000617B8 File Offset: 0x0005F9B8
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

		// Token: 0x0600023C RID: 572 RVA: 0x00061850 File Offset: 0x0005FA50
		private void remplissage_tableau(Table t, string h1, string h2, string h3, string h4, string h5, string h6, string h7, string h8)
		{
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			Paragraph paragraph = new Paragraph();
			Span span = new Span();
			span.Text = h1;
			paragraph.Inlines.Add(span);
			tableCell.Blocks.Add(paragraph);
			span.FontFamily = new FontFamily("Calibri");
			span.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell);
			TableCell tableCell2 = new TableCell();
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span();
			span2.Text = h2;
			paragraph2.Inlines.Add(span2);
			tableCell2.Blocks.Add(paragraph2);
			span2.FontFamily = new FontFamily("Calibri");
			span2.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell2);
			TableCell tableCell3 = new TableCell();
			Paragraph paragraph3 = new Paragraph();
			Span span3 = new Span();
			span3.Text = h3;
			paragraph3.Inlines.Add(span3);
			tableCell3.Blocks.Add(paragraph3);
			span3.FontFamily = new FontFamily("Calibri");
			span3.FontSize = Unit.PointToDip(12.0);
			TableCell tableCell4 = new TableCell();
			Paragraph paragraph4 = new Paragraph();
			Span span4 = new Span();
			span4.Text = h4;
			paragraph4.Inlines.Add(span4);
			tableCell4.Blocks.Add(paragraph4);
			span4.FontFamily = new FontFamily("Calibri");
			span4.FontSize = Unit.PointToDip(12.0);
			TableCell tableCell5 = new TableCell();
			Paragraph paragraph5 = new Paragraph();
			Span span5 = new Span();
			bool flag = Convert.ToString(h5) != "";
			if (flag)
			{
				span5.Text = h5;
			}
			else
			{
				span5.Text = " ";
			}
			paragraph5.Inlines.Add(span5);
			tableCell5.Blocks.Add(paragraph5);
			span5.FontFamily = new FontFamily("Calibri");
			span5.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell3);
			tableRow.Cells.Add(tableCell4);
			tableRow.Cells.Add(tableCell5);
			TableCell tableCell6 = new TableCell();
			Paragraph paragraph6 = new Paragraph();
			Span span6 = new Span();
			span6.Text = h6;
			paragraph6.Inlines.Add(span6);
			tableCell6.Blocks.Add(paragraph6);
			span6.FontFamily = new FontFamily("Calibri");
			span6.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell6);
			TableCell tableCell7 = new TableCell();
			Paragraph paragraph7 = new Paragraph();
			Span span7 = new Span();
			span7.Text = h7;
			paragraph7.Inlines.Add(span7);
			tableCell7.Blocks.Add(paragraph7);
			span7.FontFamily = new FontFamily("Calibri");
			span7.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell7);
			TableCell tableCell8 = new TableCell();
			Paragraph paragraph8 = new Paragraph();
			Span span8 = new Span();
			span8.Text = h8;
			paragraph8.Inlines.Add(span8);
			tableCell8.Blocks.Add(paragraph8);
			span8.FontFamily = new FontFamily("Calibri");
			span8.FontSize = Unit.PointToDip(12.0);
			tableRow.Cells.Add(tableCell8);
			t.Rows.Add(tableRow);
		}
	}
}
