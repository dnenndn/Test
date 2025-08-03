using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000123 RID: 291
	public partial class stock_magasin_st : Form
	{
		// Token: 0x06000CE2 RID: 3298 RVA: 0x001F48F4 File Offset: 0x001F2AF4
		public stock_magasin_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.label3.Text = "";
			this.remplissage_tableau(0);
			this.radGridView1.FilterChanged += new GridViewCollectionChangedEventHandler(this.RadGridView1_FilterChanged);
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x001F4983 File Offset: 0x001F2B83
		private void RadGridView1_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
		{
			this.change_somme();
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x001F498D File Offset: 0x001F2B8D
		private void stock_magasin_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x001F4990 File Offset: 0x001F2B90
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select magasin_sous_traitance.id, ref_interne, article.code_article, article.reference, article.designation, nbr_reparation from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id where emplacement_actuel = @m";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@m", SqlDbType.VarChar).Value = "Magasin";
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
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						this.get_total_reparation(dataTable.Rows[i].ItemArray[0].ToString()).ToString("0.000")
					});
				}
			}
			this.label3.Text = this.radGridView1.Rows.Count.ToString() + " Articles";
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
					this.radGridView1.Rows[stock_magasin_st.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = stock_magasin_st.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[stock_magasin_st.row_act - 1].IsCurrent = true;
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
			this.LoadHistoriquereparation();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x001F4CF4 File Offset: 0x001F2EF4
		private double get_total_reparation(string id_t)
		{
			double result = 0.0;
			bd bd = new bd();
			string cmdText = "select sum((ds_livraison_article.qt*ds_livraison_article.prix_ht)-(ds_livraison_article.remise/100)*(ds_livraison_article.qt*ds_livraison_article.prix_ht)) from ds_livraison_article inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where ds_commande_article.id_t = @i and ds_commande_article.source = @s group by ds_commande_article.id_t";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_t;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			fonction fonction = new fonction();
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x001F4DDC File Offset: 0x001F2FDC
		private void change_somme()
		{
			int num = 0;
			GridDataView gridDataView = this.radGridView1.MasterTemplate.DataView as GridDataView;
			foreach (GridViewRowInfo gridViewRowInfo in gridDataView.Indexer.Items)
			{
				num++;
			}
			this.label3.Text = num.ToString() + " Articles";
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x001F4E68 File Offset: 0x001F3068
		private void LoadHistoriquereparation()
		{
			bd bd = new bd();
			string cmdText = " select ds_commande_article.id_t, demande_sous_traitance.date_creation, utilisateur.login, activite.designation, ds_commande_article.descr,ds_commande.date_commande,  fournisseur.nom,ds_bon_livraison.date_livraison, ds_livraison_article.prix_ht, ds_livraison_article.remise, (ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*ds_livraison_article.prix_ht) from ds_livraison_article inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id inner join activite on ds_commande_article.id_activite = activite.id inner join demande_sous_traitance on ds_commande.id_ds = demande_sous_traitance.id inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id inner join utilisateur on demande_sous_traitance.createur = utilisateur.id where ds_commande_article.source = @s ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
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
			dataTable2.Columns.Add("column10");
			dataTable2.Columns.Add("column11");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[4]),
						fonction.Mid(dataTable.Rows[i].ItemArray[5].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[6].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[7].ToString(), 1, 10),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[8]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[9].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[10]).ToString("0.000")
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Historique Réparation";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 150;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 250;
				gridViewTemplate.Columns["column5"].Width = 300;
				gridViewTemplate.Columns["column6"].Width = 150;
				gridViewTemplate.Columns["column7"].Width = 250;
				gridViewTemplate.Columns["column8"].Width = 150;
				gridViewTemplate.Columns["column9"].Width = 150;
				gridViewTemplate.Columns["column10"].Width = 150;
				gridViewTemplate.Columns["column11"].Width = 200;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Date Demande";
				gridViewTemplate.Columns[2].HeaderText = "Demande Créer Par";
				gridViewTemplate.Columns[3].HeaderText = "Activité";
				gridViewTemplate.Columns[4].HeaderText = "Description";
				gridViewTemplate.Columns[5].HeaderText = "Date de commande";
				gridViewTemplate.Columns[6].HeaderText = "Sous Traitant";
				gridViewTemplate.Columns[7].HeaderText = "Date de réception";
				gridViewTemplate.Columns[8].HeaderText = "Prix HT";
				gridViewTemplate.Columns[9].HeaderText = "Remise (%)";
				gridViewTemplate.Columns[10].HeaderText = "Prix Tot HT";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[8].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[9].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[10].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[8].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[9].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[10].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x04001072 RID: 4210
		private static int row_act;
	}
}
