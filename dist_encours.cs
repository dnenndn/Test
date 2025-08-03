using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200006C RID: 108
	public partial class dist_encours : Form
	{
		// Token: 0x0600052D RID: 1325 RVA: 0x000DDA14 File Offset: 0x000DBC14
		public dist_encours()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000DDAAA File Offset: 0x000DBCAA
		private void dist_encours_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x000DDAB0 File Offset: 0x000DBCB0
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.Text = "DOP";
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 5;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.Text = "Annuler";
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
			bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag3)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.Text = "Liste MP";
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.CadetBlue, "", typeof(FillPrimitive));
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement3.ForeColor = Color.White;
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x000DDCD4 File Offset: 0x000DBED4
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select demande_sous_traitance.id, date_creation, heure_creation, utilisateur.login from demande_sous_traitance inner join utilisateur on demande_sous_traitance.createur = utilisateur.id  where statut = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
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
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
					this.radGridView1.Rows[i].Cells[7].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
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
					this.radGridView1.Rows[dist_encours.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = dist_encours.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[dist_encours.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000531 RID: 1329 RVA: 0x000DDFD4 File Offset: 0x000DC1D4
		private void loadarticle1()
		{
			bd bd = new bd();
			string cmdText = "select demande_actuel,ref_interne ,article.code_article, article.designation, activite.designation, description from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id inner join activite on magasin_sous_traitance.activite_actuel = activite.id inner join demande_sous_traitance on magasin_sous_traitance.demande_actuel = demande_sous_traitance.id where article.deleted = @d and demande_sous_traitance.statut = @d";
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
			dataTable2.Columns.Add("column5");
			dataTable2.Columns.Add("column6");
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
						dataTable.Rows[i].ItemArray[5].ToString()
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
				gridViewTemplate.Columns["column6"].Width = 300;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Activité";
				gridViewTemplate.Columns[1].HeaderText = "Référence interne";
				gridViewTemplate.Columns[5].HeaderText = "Description";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x000DE468 File Offset: 0x000DC668
		private void loadarticle2()
		{
			bd bd = new bd();
			string cmdText = "select id_demande,article.code_article, article.designation,quantite,  activite.designation, description from ds_nv_article inner join article on ds_nv_article.id_article = article.id inner join activite on ds_nv_article.id_activite = activite.id inner join demande_sous_traitance on ds_nv_article.id_demande = demande_sous_traitance.id where article.deleted = @d and demande_sous_traitance.statut = @d";
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
			dataTable2.Columns.Add("column5");
			dataTable2.Columns.Add("column6");
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
						dataTable.Rows[i].ItemArray[5].ToString()
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
				gridViewTemplate.Columns["column6"].Width = 300;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				gridViewTemplate.Columns[4].HeaderText = "Activité";
				gridViewTemplate.Columns[5].HeaderText = "Description";
				int count = this.radGridView1.Templates.Count;
				this.radGridView1.Templates.Insert(count, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x000DE910 File Offset: 0x000DCB10
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						dist_encours.row_act = e.RowIndex;
						dist_encours.id_ds = text;
						choisir_sous_traitant choisir_sous_traitant = new choisir_sous_traitant();
						choisir_sous_traitant.Show();
					}
					bool flag4 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag4)
					{
						string text2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						dist_encours.row_act = e.RowIndex;
						st_matiere_pr.id_ds = text2;
						st_matiere_pr st_matiere_pr = new st_matiere_pr();
						st_matiere_pr.Show();
					}
				}
				bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 5;
				if (flag5)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					dist_encours.row_act = e.RowIndex;
					DialogResult dialogResult = MessageBox.Show("Vous voulez annuler ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag6 = dialogResult == DialogResult.Yes;
					if (flag6)
					{
						bd bd = new bd();
						string cmdText = "update demande_sous_traitance set statut = @d where id=@i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 5;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText2 = "update article set stock_neuf = stock_neuf + t2.qt from article t1 inner join ds_mp t2 on t1.id = t2.id_article where t2.id_demande = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						string cmdText3 = "delete ds_mp where id_demande = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(3);
					}
				}
				bool flag7 = e.RowIndex >= 0 && e.ColumnIndex == 7;
				if (flag7)
				{
					string value2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					dist_encours.row_act = e.RowIndex;
					DialogResult dialogResult2 = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag8 = dialogResult2 == DialogResult.Yes;
					if (flag8)
					{
						bd bd2 = new bd();
						string cmdText4 = "update article set stock_neuf = stock_neuf + t2.qt from article t1 inner join ds_mp t2 on t1.id = t2.id_article where t2.id_demande = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						string cmdText5 = "delete ds_mp where id_demande = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand4.ExecuteNonQuery();
						sqlCommand5.ExecuteNonQuery();
						bd2.cnn.Close();
						string cmdText6 = "update article set stock_neuf = stock_neuf + t2.quantite from article t1 inner join ds_nv_article t2 on t1.id = t2.id_article where t2.id_demande = @i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						string cmdText7 = "delete ds_nv_article where id_demande = @i";
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd2.cnn);
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand6.ExecuteNonQuery();
						sqlCommand7.ExecuteNonQuery();
						bd2.cnn.Close();
						string cmdText8 = "delete demande_sous_traitance where id=@i";
						SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd2.cnn);
						sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						string cmdText9 = "delete ds_devis_article where id_devis in (select id from ds_devis where id_ds = @i)";
						SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd2.cnn);
						sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						string cmdText10 = "delete ds_devis where id_ds = @i";
						SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd2.cnn);
						sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand8.ExecuteNonQuery();
						sqlCommand9.ExecuteNonQuery();
						sqlCommand10.ExecuteNonQuery();
						bd2.cnn.Close();
						this.remplissage_tableau(3);
					}
				}
			}
		}

		// Token: 0x040006DF RID: 1759
		private static int row_act;

		// Token: 0x040006E0 RID: 1760
		public static string id_ds;
	}
}
