using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000056 RID: 86
	public partial class creer_commande_st : Form
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x000ABACC File Offset: 0x000A9CCC
		public creer_commande_st()
		{
			this.InitializeComponent();
			this.panel1.Visible = false;
			this.panel2.Visible = false;
			this.label3.Text = "";
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000ABBBD File Offset: 0x000A9DBD
		private void creer_commande_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x000ABBC0 File Offset: 0x000A9DC0
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 3;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.Text = "Créer Commande";
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x000ABC80 File Offset: 0x000A9E80
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
					this.radGridView1.Rows[creer_commande_st.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = creer_commande_st.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[creer_commande_st.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000408 RID: 1032 RVA: 0x000ABF20 File Offset: 0x000AA120
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

		// Token: 0x06000409 RID: 1033 RVA: 0x000AC3B4 File Offset: 0x000AA5B4
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

		// Token: 0x0600040A RID: 1034 RVA: 0x000AC85C File Offset: 0x000AAA5C
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
						creer_commande_st.row_act = e.RowIndex;
						this.label3.Text = text;
						this.radGridView2.Rows.Clear();
						this.panel1.Visible = true;
						this.panel2.Visible = true;
						this.select_sous_traitant();
					}
				}
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000AC92C File Offset: 0x000AAB2C
		private void select_sous_traitant()
		{
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			string cmdText = "select fournisseur.nom, id from fournisseur where type = @t";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Sous_Traitant";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x000ACA32 File Offset: 0x000AAC32
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.panel2.Visible = false;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000ACA50 File Offset: 0x000AAC50
		private void select_article()
		{
			this.radGridView2.Rows.Clear();
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select article.id,ref_interne, article.code_article, article.designation, activite.designation, magasin_sous_traitance.id from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id inner join activite on magasin_sous_traitance.activite_actuel = activite.id inner join demande_sous_traitance on magasin_sous_traitance.demande_actuel = demande_sous_traitance.id  where demande_sous_traitance.id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string cmdText2 = "select article.id,article.code_article, article.designation,quantite,  activite.designation, ds_nv_article.id from ds_nv_article inner join article on ds_nv_article.id_article = article.id inner join activite on ds_nv_article.id_activite = activite.id inner join demande_sous_traitance on ds_nv_article.id_demande = demande_sous_traitance.id where demande_sous_traitance.id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[5].ToString(),
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString(),
							"1",
							dataTable.Rows[i].ItemArray[4].ToString()
						});
						this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[8].Value = 0;
					}
				}
				bool flag3 = dataTable2.Rows.Count != 0;
				if (flag3)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable2.Rows[j].ItemArray[5].ToString(),
							dataTable2.Rows[j].ItemArray[0].ToString(),
							"-",
							dataTable2.Rows[j].ItemArray[1].ToString(),
							dataTable2.Rows[j].ItemArray[2].ToString(),
							dataTable2.Rows[j].ItemArray[3].ToString(),
							dataTable2.Rows[j].ItemArray[4].ToString()
						});
						this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[8].Value = 0;
					}
				}
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000ACDC8 File Offset: 0x000AAFC8
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select ds_devis.id from ds_devis inner join ds_devis_fournisseur on ds_devis.id = ds_devis_fournisseur.id_devis where id_ds = @i1 and ds_devis_fournisseur.id_fournisseur = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label3.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					this.select_article_1(dataTable.Rows[0].ItemArray[0].ToString());
				}
				else
				{
					this.select_article();
				}
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000ACEB4 File Offset: 0x000AB0B4
		private void select_article_1(string id_devis)
		{
			this.radGridView2.Rows.Clear();
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select article.id,ref_interne, article.code_article, article.designation, activite.designation, magasin_sous_traitance.id, description from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id inner join activite on magasin_sous_traitance.activite_actuel = activite.id inner join demande_sous_traitance on magasin_sous_traitance.demande_actuel = demande_sous_traitance.id where demande_sous_traitance.id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string cmdText2 = "select article.id,article.code_article, article.designation,quantite,  activite.designation, ds_nv_article.id, description from ds_nv_article inner join article on ds_nv_article.id_article = article.id inner join activite on ds_nv_article.id_activite = activite.id inner join demande_sous_traitance on ds_nv_article.id_demande = demande_sous_traitance.id where demande_sous_traitance.id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						string cmdText3 = "select prix_ht, remise from ds_devis_article inner join ds_devis on ds_devis_article.id_devis = ds_devis.id where id_devis = @i1 and source = @i2 and ds_devis_article.id_t = @i3";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id_devis;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = "ex";
						sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[5].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[5].ToString(),
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString(),
							"1",
							dataTable.Rows[i].ItemArray[4].ToString(),
							dataTable3.Rows[0].ItemArray[0],
							dataTable3.Rows[0].ItemArray[1],
							dataTable.Rows[i].ItemArray[6].ToString()
						});
					}
				}
				bool flag3 = dataTable2.Rows.Count != 0;
				if (flag3)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						string cmdText4 = "select prix_ht, remise from ds_devis_article inner join ds_devis on ds_devis_article.id_devis = ds_devis.id where id_devis = @i1 and source = @i2 and ds_devis_article.id_t = @i3";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id_devis;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = "nv";
						sqlCommand4.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[5].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable2.Rows[j].ItemArray[5].ToString(),
							dataTable2.Rows[j].ItemArray[0].ToString(),
							"-",
							dataTable2.Rows[j].ItemArray[1].ToString(),
							dataTable2.Rows[j].ItemArray[2].ToString(),
							dataTable2.Rows[j].ItemArray[3].ToString(),
							dataTable2.Rows[j].ItemArray[4].ToString(),
							dataTable4.Rows[0].ItemArray[0],
							dataTable4.Rows[0].ItemArray[1],
							dataTable2.Rows[j].ItemArray[6].ToString()
						});
					}
				}
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000AD388 File Offset: 0x000AB588
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bool flag2 = this.existe_article() == 1;
				if (flag2)
				{
					bool flag3 = this.format_prix() == 1;
					if (flag3)
					{
						bool flag4 = this.format_remise() == 1;
						if (flag4)
						{
							string value = "1";
							bool isChecked = this.radRadioButton2.IsChecked;
							if (isChecked)
							{
								value = "2";
							}
							bool isChecked2 = this.radRadioButton3.IsChecked;
							if (isChecked2)
							{
								value = "3";
							}
							int num = 0;
							bool isChecked3 = this.radRadioButton6.IsChecked;
							if (isChecked3)
							{
								num = 1;
							}
							double num2 = 0.0;
							int num3 = this.select_n_commande();
							int num4 = 0;
							bool isChecked4 = this.radRadioButton7.IsChecked;
							if (isChecked4)
							{
								num4 = 1;
							}
							string cmdText = "insert into ds_commande (date_commande, heure_commande, createur, id_fournisseur, statut, personne_contacter, date_signature, id_ds, urgence, fodec, n_commande) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
							sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = num4;
							sqlCommand.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand.Parameters.Add("@i8", SqlDbType.Int).Value = this.label3.Text;
							sqlCommand.Parameters.Add("@i9", SqlDbType.VarChar).Value = value;
							sqlCommand.Parameters.Add("@i10", SqlDbType.Int).Value = num;
							sqlCommand.Parameters.Add("@i11", SqlDbType.Int).Value = num3;
							bd.ouverture_bd(bd.cnn);
							int num5 = (int)sqlCommand.ExecuteScalar();
							bd.cnn.Close();
							for (int i = 0; i < this.radGridView2.Rows.Count; i++)
							{
								string value2 = "ex";
								bool flag5 = this.radGridView2.Rows[i].Cells[2].Value.ToString() == "-";
								if (flag5)
								{
									value2 = "nv";
								}
								bool flag6 = Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value) > 0.0;
								if (flag6)
								{
									string cmdText2 = "select id from activite where designation = @i";
									SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
									sqlCommand2.Parameters.Add("@i", SqlDbType.VarChar).Value = this.radGridView2.Rows[i].Cells[6].Value.ToString();
									SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
									DataTable dataTable = new DataTable();
									sqlDataAdapter.Fill(dataTable);
									string cmdText3 = "insert into ds_commande_article (id_commande, id_t, qt,id_activite, prix_ht, remise, source, reception,descr) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9)";
									SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
									sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num5;
									sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[0].Value.ToString();
									sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[5].Value.ToString();
									sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
									sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[7].Value.ToString();
									sqlCommand3.Parameters.Add("@i6", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[8].Value.ToString();
									sqlCommand3.Parameters.Add("@i7", SqlDbType.VarChar).Value = value2;
									sqlCommand3.Parameters.Add("@i8", SqlDbType.Int).Value = 0;
									sqlCommand3.Parameters.Add("@i9", SqlDbType.VarChar).Value = Convert.ToString(this.radGridView2.Rows[i].Cells[9].Value);
									bd.ouverture_bd(bd.cnn);
									sqlCommand3.ExecuteNonQuery();
									bd.cnn.Close();
									num2 += Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value) * Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value);
								}
							}
							string cmdText4 = "update demande_sous_traitance set statut = @d where id = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
							bd.ouverture_bd(bd.cnn);
							sqlCommand4.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Enregistrement avec succés");
							this.TextBox1.Clear();
							this.panel1.Visible = false;
							this.panel2.Visible = false;
							this.remplissage_tableau(0);
							this.radRadioButton2.IsChecked = true;
							this.cree_notif_admin(num5, this.radDropDownList6.SelectedItem.Tag.ToString(), num2, num3);
						}
						else
						{
							MessageBox.Show("Erreur : Vérifier le format des cellules remise", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Vérifier le format des cellules prix ht", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Erreur: Il faut choisir au moin un article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Erreur: Il faut choisir un sous traitant", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000ADADC File Offset: 0x000ABCDC
		private int format_prix()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView2.Rows[i].Cells[7].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000ADB70 File Offset: 0x000ABD70
		private int format_remise()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView2.Rows[i].Cells[8].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000ADC04 File Offset: 0x000ABE04
		private int existe_article()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(this.radGridView2.Rows[i].Cells[7].Value));
					if (flag2)
					{
						bool flag3 = Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value) > 0.0;
						if (flag3)
						{
							result = 1;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000ADCD4 File Offset: 0x000ABED4
		private void cree_notif_admin(int id, string fr, double somme, int n_commande)
		{
			bd bd = new bd();
			string cmdText = "select nom from fournisseur where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = fr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string text = "";
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				text = dataTable.Rows[0].ItemArray[0].ToString();
			}
			string cmdText2 = "select id from utilisateur where fonction = @i1";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Administrateur";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					string cmdText3 = "insert into notification (id_n, type, id_utilisateur, description, vue, date_creation) values (@v1, @v2, @v3, @v4, @v5, @v6)";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = id;
					sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = "Création Commande";
					sqlCommand3.Parameters.Add("@v3", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0].ToString();
					sqlCommand3.Parameters.Add("@v4", SqlDbType.VarChar).Value = string.Concat(new string[]
					{
						"Commande Sous Traitance N° ",
						n_commande.ToString(),
						" de fournisseur ",
						text,
						", Montant Tot : ",
						somme.ToString(),
						" TND est en attente de votre confirmation depuis : ",
						DateTime.Now.ToString()
					});
					sqlCommand3.Parameters.Add("@v5", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@v6", SqlDbType.Date).Value = DateTime.Today;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x000ADF48 File Offset: 0x000AC148
		private int select_n_commande()
		{
			int result = 1;
			string cmdText = "select max(n_commande) from ds_commande";
			bd bd = new bd();
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) + 1;
			}
			return result;
		}

		// Token: 0x04000583 RID: 1411
		private static int row_act;

		// Token: 0x04000584 RID: 1412
		public static string id_ds;
	}
}
