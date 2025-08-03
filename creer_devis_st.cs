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
	// Token: 0x02000058 RID: 88
	public partial class creer_devis_st : Form
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x000B3240 File Offset: 0x000B1440
		public creer_devis_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000B32D6 File Offset: 0x000B14D6
		private void creer_devis_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000B32DC File Offset: 0x000B14DC
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 3;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.Text = "Créer Devis";
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.Text = "Afficher Devis";
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.DarkBlue, "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000B3448 File Offset: 0x000B1648
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select demande_sous_traitance.id, date_creation, heure_creation from demande_sous_traitance where statut = @i";
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
						dataTable.Rows[i].ItemArray[2].ToString()
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
					this.radGridView1.Rows[creer_devis_st.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = creer_devis_st.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[creer_devis_st.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000435 RID: 1077 RVA: 0x000B36E8 File Offset: 0x000B18E8
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

		// Token: 0x06000436 RID: 1078 RVA: 0x000B3B7C File Offset: 0x000B1D7C
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

		// Token: 0x06000437 RID: 1079 RVA: 0x000B4024 File Offset: 0x000B2224
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 3;
					if (flag3)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						creer_devis_st.row_act = e.RowIndex;
						creer_devis_st.id_ds = text;
						ajouter_devis_st ajouter_devis_st = new ajouter_devis_st();
						ajouter_devis_st.Show();
					}
					bool flag4 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag4)
					{
						string text2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						creer_devis_st.row_act = e.RowIndex;
						creer_devis_st.id_ds = text2;
						modifier_devis_st modifier_devis_st = new modifier_devis_st();
						modifier_devis_st.Show();
					}
				}
			}
		}

		// Token: 0x040005BA RID: 1466
		private static int row_act;

		// Token: 0x040005BB RID: 1467
		public static string id_ds;
	}
}
