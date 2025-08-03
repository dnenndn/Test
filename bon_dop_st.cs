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
	// Token: 0x0200002F RID: 47
	public partial class bon_dop_st : Form
	{
		// Token: 0x06000245 RID: 581 RVA: 0x0006321F File Offset: 0x0006141F
		public bon_dop_st()
		{
			this.InitializeComponent();
			this.test();
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0006323E File Offset: 0x0006143E
		private void bon_dop_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00063244 File Offset: 0x00061444
		private void test()
		{
			bd bd = new bd();
			Table table = new Table();
			TableRow tableRow = new TableRow();
			TableCell tableCell = new TableCell();
			TableCell tableCell2 = new TableCell();
			string cmdText = "select adresse, telephone_1, email, code_fournisseur from fournisseur where nom = @i ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = choisir_sous_traitant.nom_fournisseur;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			RadDocument radDocument = new RadDocument();
			Section section = new Section();
			Paragraph paragraph = new Paragraph();
			Span span = new Span("IDEAL BRIQUE BENI HASSEN");
			span.ForeColor = Color.Black;
			paragraph.TextAlignment = 0;
			span.FontFamily = new FontFamily("Verdana 12");
			span.FontSize = Unit.PointToDip(12.0);
			span.FontWeight = FontWeights.Bold;
			Paragraph paragraph2 = new Paragraph();
			Span span2 = new Span(choisir_sous_traitant.nom_fournisseur ?? "");
			span2.ForeColor = Color.Black;
			paragraph2.TextAlignment = 0;
			span2.FontFamily = new FontFamily("Verdana 12");
			span2.FontSize = Unit.PointToDip(12.0);
			span2.FontWeight = FontWeights.Bold;
			string cmdText2 = "select mail, telephone from utilisateur where id = @l";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@l", SqlDbType.Int).Value = page_loginn.id_user;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			string str = "";
			string str2 = "";
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				str = Convert.ToString(dataTable2.Rows[0].ItemArray[0].ToString());
				str2 = Convert.ToString(dataTable2.Rows[0].ItemArray[1].ToString());
			}
			Paragraph paragraph3 = new Paragraph();
			Span span3 = new Span("Adresse : route de Mahdia 5014 Béni Hassen");
			span3.ForeColor = Color.Black;
			paragraph3.TextAlignment = 0;
			span3.FontFamily = new FontFamily("Times New Roman");
			span3.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph4 = new Paragraph();
			Span span4 = new Span("N° : " + choisir_sous_traitant.id_ds);
			span4.ForeColor = Color.Black;
			paragraph4.TextAlignment = 0;
			span4.FontFamily = new FontFamily("Times New Roman");
			span4.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph5 = new Paragraph();
			Span span5 = new Span("Tel : " + str2 + " , Fax : 73 491 555");
			span5.ForeColor = Color.Black;
			paragraph5.TextAlignment = 0;
			span5.FontFamily = new FontFamily("Times New Roman");
			span5.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph6 = new Paragraph();
			Span span6 = new Span("Tél : " + dataTable.Rows[0].ItemArray[1].ToString());
			span6.ForeColor = Color.Black;
			paragraph6.TextAlignment = 0;
			span6.FontFamily = new FontFamily("Times New Roman");
			span6.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph7 = new Paragraph();
			Span span7 = new Span("MF : 1086534 EAM 000");
			span7.ForeColor = Color.Black;
			paragraph7.TextAlignment = 0;
			span7.FontFamily = new FontFamily("Times New Roman");
			span7.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph8 = new Paragraph();
			Span span8 = new Span("Adresse : " + dataTable.Rows[0].ItemArray[0].ToString());
			span8.ForeColor = Color.Black;
			paragraph8.TextAlignment = 0;
			span8.FontFamily = new FontFamily("Times New Roman");
			span8.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph9 = new Paragraph();
			Span span9 = new Span("Email : " + str);
			span9.ForeColor = Color.Black;
			paragraph9.TextAlignment = 0;
			span9.FontFamily = new FontFamily("Times New Roman");
			span9.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph10 = new Paragraph();
			Span span10 = new Span("Email : " + dataTable.Rows[0].ItemArray[2].ToString());
			span10.ForeColor = Color.Black;
			paragraph10.TextAlignment = 0;
			span10.FontFamily = new FontFamily("Times New Roman");
			span10.FontSize = Unit.PointToDip(12.0);
			Paragraph paragraph11 = new Paragraph();
			Span span11 = new Span("Emetteur : " + page_loginn.esm + " ");
			span11.ForeColor = Color.Black;
			paragraph11.TextAlignment = 0;
			span11.FontFamily = new FontFamily("Times New Roman");
			span11.FontSize = Unit.PointToDip(12.0);
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
			Size size;
			size..ctor(110.0, 110.0);
			Size size2;
			size2..ctor(760.0, 40.0);
			Size size3;
			size3..ctor(200.0, 150.0);
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
			using (MemoryStream memoryStream3 = new MemoryStream())
			{
				Resources.signature_khalil.Save(memoryStream3, ImageFormat.Png);
				ImageInline imageInline3 = new ImageInline(memoryStream3, size3, "png");
			}
			Paragraph paragraph12 = new Paragraph();
			paragraph12.TextAlignment = 1;
			Span span12 = new Span("              ");
			Span span13 = new Span();
			Paragraph paragraph13 = new Paragraph();
			span13.Text = "                           Demande Offre de Prix";
			span13.FontWeight = FontWeights.Bold;
			span13.FontFamily = new FontFamily("Baskerville Old Face");
			span13.FontSize = Unit.PointToDip(28.0);
			paragraph12.Inlines.Add(span13);
			Paragraph paragraph14 = new Paragraph();
			Paragraph paragraph15 = new Paragraph();
			paragraph15.TextAlignment = 1;
			Span span14 = new Span();
			span14.Text = "                       Date : " + fonction.Mid(DateTime.Today.ToString(), 1, 10);
			span14.FontFamily = new FontFamily("Calibri");
			span14.FontSize = Unit.PointToDip(12.0);
			paragraph15.Inlines.Add(span14);
			paragraph14.LineSpacingType = 2;
			paragraph14.LineSpacing = 12.5;
			paragraph14.Inlines.Add(span12);
			paragraph14.Inlines.Add(imageInline);
			Paragraph paragraph16 = new Paragraph();
			section.Blocks.Add(paragraph16);
			section.Blocks.Add(paragraph12);
			section.Blocks.Add(paragraph15);
			section.Children.Add(paragraph14);
			Paragraph paragraph17 = new Paragraph();
			paragraph17.Inlines.Add(imageInline2);
			section.Blocks.Add(paragraph17);
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
			tableRow.Cells.Add(tableCell);
			tableRow.Cells.Add(tableCell2);
			table.Rows.Add(tableRow);
			Table table2 = new Table();
			table2.StyleName = RadDocumentDefaultStyles.DefaultTableGridStyleName;
			TableRow tableRow2 = new TableRow();
			TableCell tableCell3 = new TableCell();
			Paragraph paragraph18 = new Paragraph();
			Span span15 = new Span();
			span15.FontFamily = new FontFamily("Calibri");
			span15.FontSize = Unit.PointToDip(14.0);
			span15.FontWeight = FontWeights.Bold;
			span15.Text = "Code Article";
			paragraph18.Inlines.Add(span15);
			tableCell3.Blocks.Add(paragraph18);
			tableRow2.Cells.Add(tableCell3);
			TableCell tableCell4 = new TableCell();
			Paragraph paragraph19 = new Paragraph();
			Span span16 = new Span();
			span16.Text = "Désignation";
			paragraph19.Inlines.Add(span16);
			tableCell4.Blocks.Add(paragraph19);
			span16.FontFamily = new FontFamily("Calibri");
			span16.FontSize = Unit.PointToDip(14.0);
			span16.FontWeight = FontWeights.Bold;
			tableRow2.Cells.Add(tableCell4);
			TableCell tableCell5 = new TableCell();
			Paragraph paragraph20 = new Paragraph();
			Span span17 = new Span();
			span17.Text = "Quantité";
			paragraph20.Inlines.Add(span17);
			tableCell5.Blocks.Add(paragraph20);
			TableCell tableCell6 = new TableCell();
			Paragraph paragraph21 = new Paragraph();
			Span span18 = new Span();
			span18.Text = "Activité";
			paragraph21.Inlines.Add(span18);
			tableCell6.Blocks.Add(paragraph21);
			TableCell tableCell7 = new TableCell();
			Paragraph paragraph22 = new Paragraph();
			Span span19 = new Span();
			span19.Text = "Description";
			paragraph22.Inlines.Add(span19);
			tableCell7.Blocks.Add(paragraph22);
			span17.FontFamily = new FontFamily("Calibri");
			span17.FontSize = Unit.PointToDip(14.0);
			span17.FontWeight = FontWeights.Bold;
			span18.FontFamily = new FontFamily("Calibri");
			span18.FontSize = Unit.PointToDip(14.0);
			span18.FontWeight = FontWeights.Bold;
			span19.FontFamily = new FontFamily("Calibri");
			span19.FontSize = Unit.PointToDip(14.0);
			span19.FontWeight = FontWeights.Bold;
			tableRow2.Cells.Add(tableCell5);
			tableRow2.Cells.Add(tableCell6);
			tableRow2.Cells.Add(tableCell7);
			tableCell3.Background = Color.Silver;
			tableCell4.Background = Color.Silver;
			tableCell5.Background = Color.Silver;
			tableCell6.Background = Color.Silver;
			tableCell7.Background = Color.Silver;
			table2.Rows.Add(tableRow2);
			string cmdText3 = "select article.code_article, article.designation, activite.designation, description from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id inner join activite on magasin_sous_traitance.activite_actuel = activite.id inner join demande_sous_traitance on magasin_sous_traitance.demande_actuel = demande_sous_traitance.id where demande_sous_traitance.id = @i";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = choisir_sous_traitant.id_ds;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			bool flag2 = dataTable3.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable3.Rows.Count; i++)
				{
					string h = dataTable3.Rows[i].ItemArray[0].ToString();
					string h2 = dataTable3.Rows[i].ItemArray[1].ToString();
					string h3 = "1";
					string h4 = dataTable3.Rows[i].ItemArray[2].ToString();
					string h5 = dataTable3.Rows[i].ItemArray[3].ToString();
					this.remplissage_tableau(table2, h, h2, h3, h4, h5);
				}
			}
			string cmdText4 = "select article.code_article, article.designation,quantite,  activite.designation, description from ds_nv_article inner join article on ds_nv_article.id_article = article.id inner join activite on ds_nv_article.id_activite = activite.id inner join demande_sous_traitance on ds_nv_article.id_demande = demande_sous_traitance.id where demande_sous_traitance.id = @i";
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
			sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = choisir_sous_traitant.id_ds;
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
			DataTable dataTable4 = new DataTable();
			sqlDataAdapter4.Fill(dataTable4);
			bool flag3 = dataTable4.Rows.Count != 0;
			if (flag3)
			{
				for (int j = 0; j < dataTable4.Rows.Count; j++)
				{
					string h6 = dataTable4.Rows[j].ItemArray[0].ToString();
					string h7 = dataTable4.Rows[j].ItemArray[1].ToString();
					string h8 = dataTable4.Rows[j].ItemArray[2].ToString();
					string h9 = dataTable4.Rows[j].ItemArray[3].ToString();
					string h10 = dataTable4.Rows[j].ItemArray[4].ToString();
					this.remplissage_tableau(table2, h6, h7, h8, h9, h10);
				}
			}
			section.Blocks.Add(table);
			section.Blocks.Add(table2);
			section.Blocks.Add(new Paragraph());
			section.Blocks.Add(new Paragraph());
			section.Blocks.Add(new Paragraph());
			section.Blocks.Add(new Paragraph());
			radDocument.Sections.Add(section);
			this.radRichTextEditor1.Document = radDocument;
			this.radRichTextEditor1.ChangeSectionPageMargin(new Padding(25, 20, 25, 20));
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00064200 File Offset: 0x00062400
		private void remplissage_tableau(Table t, string h1, string h2, string h3, string h4, string h5)
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
			t.Rows.Add(tableRow);
		}
	}
}
