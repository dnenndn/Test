using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000042 RID: 66
	public partial class commande_attente_st : Form
	{
		// Token: 0x060002ED RID: 749 RVA: 0x0007DEE8 File Offset: 0x0007C0E8
		public commande_attente_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView2.CellDoubleClick += new GridViewCellEventHandler(this.RadGridView2_CellDoubleClick);
			commande_attente_st.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			commande_attente_st.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			commande_attente_st.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			commande_attente_st.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			commande_attente_st.panel1.Visible = false;
			commande_attente_st.radGridView1.Size = new Size(1080, 471);
			commande_attente_st.remplissage_tableau(0);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0007DFE8 File Offset: 0x0007C1E8
		private void RadGridView2_CellDoubleClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				commande_attente_st.id_art = this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
				commande_vr_prix_st commande_vr_prix_st = new commande_vr_prix_st();
				commande_vr_prix_st.Show();
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0007E068 File Offset: 0x0007C268
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			commande_attente_st.panel1.Visible = false;
			commande_attente_st.radGridView1.Size = new Size(1080, 471);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0007E094 File Offset: 0x0007C294
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 8;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0007E1E8 File Offset: 0x0007C3E8
		private static string select_utilisateur(string i)
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

		// Token: 0x060002F2 RID: 754 RVA: 0x0007E280 File Offset: 0x0007C480
		public static void remplissage_tableau(int o)
		{
			commande_attente_st.radGridView1.Rows.Clear();
			commande_attente_st.radGridView1.AllowDragToGroup = false;
			commande_attente_st.radGridView1.AllowAddNewRow = false;
			commande_attente_st.radGridView1.EnablePaging = true;
			commande_attente_st.radGridView1.PageSize = 14;
			commande_attente_st.radGridView1.EnableSorting = true;
			commande_attente_st.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select ds_commande.id, date_commande, heure_commande, createur,  fournisseur.nom, urgence, n_commande from ds_commande inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id where statut = @i";
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
					string text = "Red";
					bool flag2 = dataTable.Rows[i].ItemArray[5].ToString() == "2";
					if (flag2)
					{
						text = "Yellow";
					}
					bool flag3 = dataTable.Rows[i].ItemArray[5].ToString() == "3";
					if (flag3)
					{
						text = "Green";
					}
					commande_attente_st.radGridView1.Rows.Add(new object[]
					{
						text,
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						commande_attente_st.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
					commande_attente_st.radGridView1.Rows[i].Cells[7].Value = "Afficher";
					commande_attente_st.radGridView1.Rows[i].Cells[8].Value = "Annuler";
					commande_attente_st.radGridView1.Rows[i].Cells[9].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				}
				bool flag4 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Administrateur";
				if (flag4)
				{
					commande_attente_st.radGridView1.Columns[8].IsVisible = false;
					commande_attente_st.radGridView1.Columns[9].IsVisible = false;
					commande_attente_st.radGridView1.Columns[7].IsVisible = false;
				}
				bool flag5 = page_loginn.stat_user != "Responsable Achat";
				if (flag5)
				{
					commande_attente_st.radGridView1.Columns[8].IsVisible = false;
					commande_attente_st.radGridView1.Columns[9].IsVisible = false;
				}
			}
			bool flag6 = commande_attente_st.radGridView1.Rows.Count != 0;
			if (flag6)
			{
				bool flag7 = o == 0;
				if (flag7)
				{
					commande_attente_st.radGridView1.MasterTemplate.MoveToFirstPage();
					commande_attente_st.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag8 = o == 1;
				if (flag8)
				{
					commande_attente_st.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag9 = o == 2;
				if (flag9)
				{
					commande_attente_st.radGridView1.Rows[commande_attente_st.row_act].IsCurrent = true;
				}
				bool flag10 = o == 3;
				if (flag10)
				{
					bool flag11 = commande_attente_st.row_act != 0;
					if (flag11)
					{
						commande_attente_st.radGridView1.Rows[commande_attente_st.row_act - 1].IsCurrent = true;
					}
					else
					{
						commande_attente_st.radGridView1.MasterTemplate.MoveToFirstPage();
						commande_attente_st.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			commande_attente_st.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			commande_attente_st.radGridView1.Templates.Clear();
			commande_attente_st.cmp = 0;
			commande_attente_st.loadarticle1();
			commande_attente_st.loadarticle2();
			commande_attente_st.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0007E740 File Offset: 0x0007C940
		private static void loadarticle1()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, magasin_sous_traitance.ref_interne, article.code_article, article.designation, activite.designation, magasin_sous_traitance.description,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s and ds_commande.statut = @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
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
				commande_attente_st.radGridView1.Templates.Insert(commande_attente_st.cmp, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(commande_attente_st.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(commande_attente_st.radGridView1.MasterTemplate.Columns[1].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				commande_attente_st.radGridView1.Relations.Add(gridViewRelation);
				commande_attente_st.cmp++;
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0007EDB4 File Offset: 0x0007CFB4
		private static void loadarticle2()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, article.code_article, article.designation, activite.designation, ds_nv_article.description,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s and ds_commande.statut = @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
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
				int count = commande_attente_st.radGridView1.Templates.Count;
				commande_attente_st.radGridView1.Templates.Insert(count, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(commande_attente_st.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(commande_attente_st.radGridView1.MasterTemplate.Columns[1].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				commande_attente_st.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0007F414 File Offset: 0x0007D614
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = commande_attente_st.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					this.guna2Button1.Visible = false;
					this.guna2Button3.Visible = false;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						string value = commande_attente_st.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						commande_attente_st.id_commande = value;
						string cmdText = "select id from fournisseur where nom = @n";
						bd bd = new bd();
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = commande_attente_st.radGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						this.id_fournisseur = dataTable.Rows[0].ItemArray[0].ToString();
						commande_attente_st.row_act = e.RowIndex;
						commande_attente_st.panel1.Show();
						commande_attente_st.radGridView1.Size = new Size(1080, 195);
						this.radGridView2.Rows.Clear();
						string cmdText2 = "select ds_commande_article.id,id_commande, magasin_sous_traitance.ref_interne, article.code_article, article.designation, activite.designation,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise, activite.type_st from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s and ds_commande.statut = @d and ds_commande_article.id_commande = @i ";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand2.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						string cmdText3 = "select ds_commande_article.id,id_commande,  article.code_article, article.designation, activite.designation,ds_commande_article.qt ,ds_commande_article.prix_ht, ds_commande_article.remise, activite.type_st from ds_commande_article inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_commande on ds_commande_article.id_commande = ds_commande.id where ds_commande_article.source = @s and ds_commande.statut = @d and ds_commande_article.id_commande = @i ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						string cmdText4 = "select urgence, fodec from ds_commande where id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag4 = dataTable4.Rows[0].ItemArray[0].ToString() == "1";
						if (flag4)
						{
							this.radRadioButton1.IsChecked = true;
						}
						bool flag5 = dataTable4.Rows[0].ItemArray[0].ToString() == "2";
						if (flag5)
						{
							this.radRadioButton2.IsChecked = true;
						}
						bool flag6 = dataTable4.Rows[0].ItemArray[0].ToString() == "3";
						if (flag6)
						{
							this.radRadioButton3.IsChecked = true;
						}
						bool flag7 = dataTable4.Rows[0].ItemArray[1].ToString() == "1";
						if (flag7)
						{
							this.radRadioButton6.IsChecked = true;
						}
						bool flag8 = dataTable4.Rows[0].ItemArray[1].ToString() == "0";
						if (flag8)
						{
							this.radRadioButton5.IsChecked = true;
						}
						bool flag9 = dataTable2.Rows.Count != 0;
						if (flag9)
						{
							for (int i = 0; i < dataTable2.Rows.Count; i++)
							{
								this.radGridView2.Rows.Add(new object[]
								{
									dataTable2.Rows[i].ItemArray[0].ToString(),
									dataTable2.Rows[i].ItemArray[1].ToString(),
									dataTable2.Rows[i].ItemArray[2].ToString(),
									dataTable2.Rows[i].ItemArray[3].ToString(),
									dataTable2.Rows[i].ItemArray[4].ToString(),
									dataTable2.Rows[i].ItemArray[5].ToString(),
									dataTable2.Rows[i].ItemArray[6].ToString(),
									Convert.ToDouble(dataTable2.Rows[i].ItemArray[7]).ToString("0.000"),
									dataTable2.Rows[i].ItemArray[8].ToString(),
									dataTable2.Rows[i].ItemArray[9].ToString()
								});
							}
						}
						bool flag10 = dataTable3.Rows.Count != 0;
						if (flag10)
						{
							for (int j = 0; j < dataTable3.Rows.Count; j++)
							{
								this.radGridView2.Rows.Add(new object[]
								{
									dataTable3.Rows[j].ItemArray[0].ToString(),
									dataTable3.Rows[j].ItemArray[1].ToString(),
									"-",
									dataTable3.Rows[j].ItemArray[2].ToString(),
									dataTable3.Rows[j].ItemArray[3].ToString(),
									dataTable3.Rows[j].ItemArray[4].ToString(),
									dataTable3.Rows[j].ItemArray[5].ToString(),
									Convert.ToDouble(dataTable3.Rows[j].ItemArray[6]).ToString("0.000"),
									dataTable3.Rows[j].ItemArray[7].ToString(),
									dataTable3.Rows[j].ItemArray[8].ToString()
								});
							}
						}
						this.guna2Button3.Hide();
						bool flag11 = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode";
						if (flag11)
						{
							this.guna2Button1.Show();
							this.guna2Button3.Show();
						}
						bool flag12 = page_loginn.stat_user == "Responsable Achat";
						if (flag12)
						{
							this.guna2Button1.Show();
						}
						bool flag13 = page_loginn.stat_user == "Responsable Méthode";
						if (flag13)
						{
							this.guna2Button1.Hide();
							bool flag14 = this.radGridView2.Rows.Count != 0;
							if (flag14)
							{
								int num = 0;
								for (int k = 0; k < this.radGridView2.Rows.Count; k++)
								{
									bool flag15 = this.radGridView2.Rows[k].Cells[9].Value.ToString() == "1";
									if (flag15)
									{
										num = 1;
									}
								}
								bool flag16 = num == 0;
								if (flag16)
								{
									this.guna2Button3.Show();
									this.guna2Button1.Show();
								}
							}
						}
						bool flag17 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Administrateur";
						if (flag17)
						{
							this.label10.Visible = false;
							this.radGridView2.Columns[7].IsVisible = false;
							this.radGridView2.Columns[8].IsVisible = false;
						}
						double num2 = 0.0;
						for (int l = 0; l < this.radGridView2.Rows.Count; l++)
						{
							double num3 = Convert.ToDouble(this.radGridView2.Rows[l].Cells[6].Value) * Convert.ToDouble(this.radGridView2.Rows[l].Cells[7].Value);
							num3 -= num3 * Convert.ToDouble(this.radGridView2.Rows[l].Cells[8].Value) / 100.0;
							num2 += num3;
						}
						this.label10.Text = num2.ToString("0.000");
					}
				}
				bool flag18 = e.RowIndex >= 0 && e.ColumnIndex == 8;
				if (flag18)
				{
					string value2 = commande_attente_st.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					commande_attente_st.row_act = e.RowIndex;
					bd bd2 = new bd();
					DialogResult dialogResult = MessageBox.Show("Vous voulez annuler cette commande ?", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag19 = dialogResult == DialogResult.Yes;
					if (flag19)
					{
						string cmdText5 = "update ds_commande set statut = @d where id = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 5;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand5.ExecuteNonQuery();
						bd2.cnn.Close();
						string cmdText6 = "update article set stock_neuf = stock_neuf + t2.qt from article t1 inner join ds_mp t2 on t1.id = t2.id_article where t2.id_demande = @i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						string cmdText7 = "delete ds_mp where id_demande = @i";
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd2.cnn);
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand6.ExecuteNonQuery();
						sqlCommand7.ExecuteNonQuery();
						bd2.cnn.Close();
						commande_attente_st.remplissage_tableau(3);
						this.guna2Button2_Click(sender, e);
					}
				}
				bool flag20 = e.RowIndex >= 0 && e.ColumnIndex == 9;
				if (flag20)
				{
					string id_cmnd = commande_attente_st.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					commande_attente_st.row_act = e.RowIndex;
					bd bd3 = new bd();
					DialogResult dialogResult2 = MessageBox.Show("Vous voulez supprimer cette commande ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag21 = dialogResult2 == DialogResult.Yes;
					if (flag21)
					{
						this.delete_commande(id_cmnd);
						commande_attente_st.remplissage_tableau(3);
						this.guna2Button2_Click(sender, e);
					}
				}
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0007FFC4 File Offset: 0x0007E1C4
		private void delete_commande(string id_cmnd)
		{
			bd bd = new bd();
			string cmdText = "delete ds_commande where id = @i";
			string cmdText2 = "delete ds_commande_article where id_commande = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			string cmdText3 = "update demande_sous_traitance set statut = @d where id in (select id_ds from ds_commande where id = @i)";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			bd.ouverture_bd(bd.cnn);
			sqlCommand3.ExecuteNonQuery();
			sqlCommand.ExecuteNonQuery();
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000800B0 File Offset: 0x0007E2B0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bd bd = new bd();
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					string cmdText = "update ds_commande_article set prix_ht = @h1, remise = @h2 where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@h1", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[7].Value;
					sqlCommand.Parameters.Add("@h2", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[8].Value;
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[0].Value;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
				int num = 0;
				bool isChecked = this.radRadioButton6.IsChecked;
				if (isChecked)
				{
					num = 1;
				}
				string cmdText2 = "update ds_commande set urgence = @u, fodec = @v where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				string value = "1";
				bool isChecked2 = this.radRadioButton2.IsChecked;
				if (isChecked2)
				{
					value = "2";
				}
				bool isChecked3 = this.radRadioButton3.IsChecked;
				if (isChecked3)
				{
					value = "3";
				}
				sqlCommand2.Parameters.Add("@u", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = num;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = commande_attente_st.id_commande;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Modification avec succés");
				commande_attente_st.panel1.Hide();
				this.guna2Button2_Click(sender, e);
				commande_attente_st.remplissage_tableau(2);
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00080300 File Offset: 0x0007E500
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			signature_commande_attente_st signature_commande_attente_st = new signature_commande_attente_st();
			signature_commande_attente_st.Show();
		}

		// Token: 0x04000410 RID: 1040
		private static int row_act;

		// Token: 0x04000411 RID: 1041
		public static string id_commande;

		// Token: 0x04000412 RID: 1042
		private string id_fournisseur;

		// Token: 0x04000413 RID: 1043
		private static int cmp;

		// Token: 0x04000414 RID: 1044
		public static string id_art;
	}
}
