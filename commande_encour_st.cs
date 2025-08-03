using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000046 RID: 70
	public partial class commande_encour_st : Form
	{
		// Token: 0x06000324 RID: 804 RVA: 0x00089788 File Offset: 0x00087988
		public commande_encour_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0008981E File Offset: 0x00087A1E
		private void commande_encour_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00089824 File Offset: 0x00087A24
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00089978 File Offset: 0x00087B78
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

		// Token: 0x06000328 RID: 808 RVA: 0x00089A10 File Offset: 0x00087C10
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select ds_commande.id, date_commande, heure_commande, createur,  fournisseur.nom, urgence, n_commande from ds_commande inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id where statut = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
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
						dataTable.Rows[i].ItemArray[6].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
					this.radGridView1.Rows[i].Cells[6].Value = "Afficher";
					this.radGridView1.Rows[i].Cells[7].Value = "Annuler";
				}
				bool flag2 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Administrateur";
				if (flag2)
				{
					this.radGridView1.Columns[6].IsVisible = false;
					this.radGridView1.Columns[7].IsVisible = false;
				}
				bool flag3 = page_loginn.stat_user != "Responsable Achat";
				if (flag3)
				{
					this.radGridView1.Columns[7].IsVisible = false;
				}
			}
			bool flag4 = this.radGridView1.Rows.Count != 0;
			if (flag4)
			{
				bool flag5 = o == 0;
				if (flag5)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag6 = o == 1;
				if (flag6)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag7 = o == 2;
				if (flag7)
				{
					this.radGridView1.Rows[commande_encour_st.row_act].IsCurrent = true;
				}
				bool flag8 = o == 3;
				if (flag8)
				{
					bool flag9 = commande_encour_st.row_act != 0;
					if (flag9)
					{
						this.radGridView1.Rows[commande_encour_st.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000329 RID: 809 RVA: 0x00089E1C File Offset: 0x0008801C
		private void loadarticle1()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, magasin_sous_traitance.ref_interne, article.code_article, article.designation, activite.designation, magasin_sous_traitance.description,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s and ds_commande.statut = @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
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
						dataTable.Rows[i].ItemArray[6].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[7]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[8].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Réparation";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 200;
				gridViewTemplate.Columns["column6"].Width = 200;
				gridViewTemplate.Columns["column7"].Width = 200;
				gridViewTemplate.Columns["column8"].Width = 200;
				gridViewTemplate.Columns["column9"].Width = 200;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[8].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[8].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Activité";
				gridViewTemplate.Columns[1].HeaderText = "Référence interne";
				gridViewTemplate.Columns[5].HeaderText = "Description";
				gridViewTemplate.Columns[6].HeaderText = "Quantité";
				gridViewTemplate.Columns[7].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[8].HeaderText = "Remise";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0008A484 File Offset: 0x00088684
		private void loadarticle2()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, article.code_article, article.designation, activite.designation, ds_nv_article.description,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s and ds_commande.statut = @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
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
						"-",
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
				gridViewTemplate.Caption = "Fabrication";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 200;
				gridViewTemplate.Columns["column6"].Width = 200;
				gridViewTemplate.Columns["column7"].Width = 200;
				gridViewTemplate.Columns["column8"].Width = 200;
				gridViewTemplate.Columns["column9"].Width = 200;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[8].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[8].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Activité";
				gridViewTemplate.Columns[1].HeaderText = "Référence interne";
				gridViewTemplate.Columns[5].HeaderText = "Description";
				gridViewTemplate.Columns[6].HeaderText = "Quantité";
				gridViewTemplate.Columns[7].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[8].HeaderText = "Remise";
				this.radGridView1.Templates.Insert(1, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0008AAD4 File Offset: 0x00088CD4
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 6;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					commande_encour_st.id_commande = text;
					commande_encour_st.nom_fournisseur = this.radGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
					bon_commande_encour_st bon_commande_encour_st = new bon_commande_encour_st();
					bon_commande_encour_st.Show();
				}
				bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
				if (flag3)
				{
					bd bd = new bd();
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					DialogResult dialogResult = MessageBox.Show("Vous voulez Annuler cette commande ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag4 = dialogResult == DialogResult.Yes;
					if (flag4)
					{
						string cmdText = "update ds_commande set statut = @d where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 5;
						string cmdText2 = "delete ds_historique_mvt where id_mvt = @i and mvt = @m";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand2.Parameters.Add("@m", SqlDbType.VarChar).Value = "Commande";
						string cmdText3 = "update magasin_sous_traitance set emplacement_actuel = @e  where id in (select id_t from ds_commande_article where id_commande = @i and source = @s)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand3.Parameters.Add("@e", SqlDbType.VarChar).Value = "Magasin";
						sqlCommand3.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						sqlCommand2.ExecuteNonQuery();
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText4 = "update article set stock_neuf = stock_neuf + t2.qt from article t1 inner join ds_mp t2 on t1.id = t2.id_article where t2.id_demande = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
						string cmdText5 = "delete ds_mp where id_demande = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						sqlCommand5.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(3);
					}
				}
			}
		}

		// Token: 0x04000471 RID: 1137
		private static int row_act;

		// Token: 0x04000472 RID: 1138
		public static string id_commande;

		// Token: 0x04000473 RID: 1139
		public static string nom_fournisseur;
	}
}
