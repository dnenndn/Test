using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000029 RID: 41
	public partial class bl_facture_st : Form
	{
		// Token: 0x0600020C RID: 524 RVA: 0x00056A2C File Offset: 0x00054C2C
		public bl_facture_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00056A8C File Offset: 0x00054C8C
		private void bl_facture_st_Load(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00056AF0 File Offset: 0x00054CF0
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

		// Token: 0x0600020F RID: 527 RVA: 0x00056B88 File Offset: 0x00054D88
		private void loadarticle1()
		{
			bd bd = new bd();
			string cmdText = "select id_livraison, magasin_sous_traitance.ref_interne, article.code_article, article.designation, activite.designation,ds_livraison_article.qt ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_livraison_article inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s and ds_bon_livraison.statut = @d and ds_bon_livraison.date_reel between @d1 and @d2 ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
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
						Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[7].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Réparation";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 200;
				gridViewTemplate.Columns["column6"].Width = 200;
				gridViewTemplate.Columns["column7"].Width = 200;
				gridViewTemplate.Columns["column8"].Width = 200;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Activité";
				gridViewTemplate.Columns[1].HeaderText = "Référence interne";
				gridViewTemplate.Columns[5].HeaderText = "Quantité";
				gridViewTemplate.Columns[6].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[7].HeaderText = "Remise";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x000571C4 File Offset: 0x000553C4
		private void loadarticle2()
		{
			bd bd = new bd();
			string cmdText = "select id_livraison, article.code_article, article.designation, activite.designation,ds_livraison_article.qt ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_livraison_article inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s and ds_bon_livraison.statut = @d and ds_bon_livraison.date_reel between @d1 and @d2 ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
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
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						"-",
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Fabrication";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 200;
				gridViewTemplate.Columns["column6"].Width = 200;
				gridViewTemplate.Columns["column7"].Width = 200;
				gridViewTemplate.Columns["column8"].Width = 200;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Activité";
				gridViewTemplate.Columns[1].HeaderText = "Référence interne";
				gridViewTemplate.Columns[5].HeaderText = "Quantité";
				gridViewTemplate.Columns[6].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[7].HeaderText = "Remise";
				int count = this.radGridView1.Templates.Count;
				this.radGridView1.Templates.Insert(count, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000577FC File Offset: 0x000559FC
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select distinct ds_bon_livraison.id, ds_bon_livraison.date_reel,date_livraison, livraison_par, fournisseur.nom, bl_fournisseur, sum((ds_livraison_article.qt*ds_livraison_article.prix_ht) - ((ds_livraison_article.qt*ds_livraison_article.prix_ht*ds_livraison_article.remise)/100)) from ds_bon_livraison  inner join fournisseur on ds_bon_livraison.id_fournisseur = fournisseur.id inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison where ds_bon_livraison.statut = @i and ds_bon_livraison.date_reel between @d1 and @d2 group by ds_bon_livraison.id, ds_bon_livraison.date_reel,date_livraison, livraison_par, fournisseur.nom, bl_fournisseur";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
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
						Convert.ToString(dataTable.Rows[i].ItemArray[5].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000")
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
					this.radGridView1.Rows[bl_facture_st.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = bl_facture_st.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[bl_facture_st.row_act - 1].IsCurrent = true;
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
			this.loadarticle1();
			this.loadarticle2();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00057B9C File Offset: 0x00055D9C
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00057BA7 File Offset: 0x00055DA7
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x040002E5 RID: 741
		private static int row_act;
	}
}
