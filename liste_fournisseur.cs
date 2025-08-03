using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200013D RID: 317
	public partial class liste_fournisseur : Form
	{
		// Token: 0x06000E30 RID: 3632 RVA: 0x0022AD84 File Offset: 0x00228F84
		public liste_fournisseur()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView1.ContextMenuOpening += new ContextMenuOpeningEventHandler(this.radGridView1_ContextMenuOpening);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.label3.Text = "";
			this.initialise_tab();
			this.remplissage_tableau(0);
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x0022AE3C File Offset: 0x0022903C
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x0022AE76 File Offset: 0x00229076
		private void liste_fournisseur_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x0022AE7C File Offset: 0x0022907C
		private void initialise_tab()
		{
			menu_fournisseur menu_fournisseur = new menu_fournisseur();
			menu_fournisseur.TopLevel = false;
			menu_fournisseur.button2.BackColor = Color.White;
			menu_fournisseur.button2.ForeColor = Color.Firebrick;
			menu_fournisseur.button1.BackColor = Color.Firebrick;
			menu_fournisseur.button1.ForeColor = Color.White;
			menu_fournisseur.button3.BackColor = Color.Firebrick;
			menu_fournisseur.button3.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_fournisseur);
			menu_fournisseur.Show();
			this.panel4.Hide();
			this.radGridView1.Location = new Point(0, 0);
			this.radGridView1.Size = new Size(1095, 510);
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x0022AF64 File Offset: 0x00229164
		private void panel5_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1072, 1);
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x0022AFA0 File Offset: 0x002291A0
		private void label1_Click(object sender, EventArgs e)
		{
			bool visible = this.panel4.Visible;
			if (visible)
			{
				this.panel4.Visible = false;
				this.radGridView1.Location = new Point(0, 0);
				this.radGridView1.Size = new Size(1095, 510);
			}
			else
			{
				this.panel4.Visible = true;
				this.radGridView1.Location = new Point(0, 197);
				this.radGridView1.Size = new Size(1095, 322);
			}
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x0022B040 File Offset: 0x00229240
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id, code_fournisseur, nom, type, activite, tva_defaut, remise_defaut, delai, commentaire from fournisseur where deleted = @i order by nom";
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
					string cmdText2 = "select designation from parametre_activite_fournisseur inner join tableau_fournisseur_activite on parametre_activite_fournisseur.id = tableau_fournisseur_activite.id_activite where parametre_activite_fournisseur.deleted = @d and tableau_fournisseur_activite.id_fournisseur = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string cmdText3 = "select designation from parametre_devise_fournisseur inner join tableau_fournisseur_devise on parametre_devise_fournisseur.id = tableau_fournisseur_devise.id_devise where parametre_devise_fournisseur.deleted = @d and tableau_fournisseur_devise.id_fournisseur = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					string text = "";
					string text2 = "";
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						text = dataTable2.Rows[0].ItemArray[0].ToString();
					}
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						text2 = dataTable3.Rows[0].ItemArray[0].ToString();
					}
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						text,
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						text2,
						dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[8].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.label3.Text = this.radGridView1.Rows.Count.ToString() + " Fournisseurs";
			bool flag4 = page_loginn.stat_user != "Responsable Méthode";
			if (flag4)
			{
				this.radGridView1.Columns[12].IsVisible = false;
			}
			bool flag5 = this.radGridView1.Rows.Count != 0;
			if (flag5)
			{
				bool flag6 = o == 0;
				if (flag6)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag7 = o == 1;
				if (flag7)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag8 = o == 2;
				if (flag8)
				{
					this.radGridView1.Rows[liste_fournisseur.row_act].IsCurrent = true;
				}
				bool flag9 = o == 3;
				if (flag9)
				{
					bool flag10 = liste_fournisseur.row_act != 0;
					if (flag10)
					{
						this.radGridView1.Rows[liste_fournisseur.row_act - 1].IsCurrent = true;
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
			this.ind_temp = 0;
			this.LoadAdresse();
			this.Loadcontact();
			this.LoadBanque();
			this.Loadcompte();
			this.Loadlivraison();
			this.Loadreglement();
			this.afficher_article();
			this.Loadfichier();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0022B5C4 File Offset: 0x002297C4
		private void LoadAdresse()
		{
			bd bd = new bd();
			string cmdText = "select id, pays, ville, code_postal, adresse from fournisseur where deleted = @d";
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
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Adresse";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 150;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.Columns["column5"].Width = 300;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Pays";
				gridViewTemplate.Columns[2].HeaderText = "Ville";
				gridViewTemplate.Columns[3].HeaderText = "Code_postal";
				gridViewTemplate.Columns[4].HeaderText = "Adresse";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x0022B934 File Offset: 0x00229B34
		private void Loadcontact()
		{
			bd bd = new bd();
			string cmdText = "select id, telephone_1, telephone_2, fax_1, fax_2, email, site_web from fournisseur where deleted = @d";
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
			dataTable2.Columns.Add("column7");
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
						dataTable.Rows[i].ItemArray[6].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Contact";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 125;
				gridViewTemplate.Columns["column3"].Width = 125;
				gridViewTemplate.Columns["column4"].Width = 125;
				gridViewTemplate.Columns["column5"].Width = 125;
				gridViewTemplate.Columns["column6"].Width = 250;
				gridViewTemplate.Columns["column7"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Téléphone n°1";
				gridViewTemplate.Columns[2].HeaderText = "Téléphone n°2";
				gridViewTemplate.Columns[3].HeaderText = "Fax n°1";
				gridViewTemplate.Columns[4].HeaderText = "Fax n°2";
				gridViewTemplate.Columns[5].HeaderText = "Email";
				gridViewTemplate.Columns[6].HeaderText = "Site Web";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x0022BD60 File Offset: 0x00229F60
		private void LoadBanque()
		{
			bd bd = new bd();
			string cmdText = "select id, nom_banque, domiciliation, iban, rib from fournisseur where deleted = @d";
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
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Banque";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 150;
				gridViewTemplate.Columns["column4"].Width = 250;
				gridViewTemplate.Columns["column5"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Nom du banque";
				gridViewTemplate.Columns[2].HeaderText = "Domiciliation";
				gridViewTemplate.Columns[3].HeaderText = "IBAN";
				gridViewTemplate.Columns[4].HeaderText = "RIB";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x0022C0D0 File Offset: 0x0022A2D0
		private void Loadcompte()
		{
			bd bd = new bd();
			string cmdText = "select id_fournisseur, parametre_compte_fournisseur.designation, parametre_compte_fournisseur.estimation, parametre_compte_fournisseur.periode_nbre, parametre_compte_fournisseur.periode from tableau_fournisseur_compte inner join parametre_compte_fournisseur on tableau_fournisseur_compte.id_compte = parametre_compte_fournisseur.id where parametre_compte_fournisseur.deleted = @d";
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
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = dataTable.Rows[i].ItemArray[2].ToString() + " Dinars";
					string text2 = dataTable.Rows[i].ItemArray[3].ToString() + " " + dataTable.Rows[i].ItemArray[4].ToString();
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						text,
						text2
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Compte";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Désignation";
				gridViewTemplate.Columns[2].HeaderText = "Estimation";
				gridViewTemplate.Columns[3].HeaderText = "Période";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x0022C414 File Offset: 0x0022A614
		private void Loadlivraison()
		{
			bd bd = new bd();
			string cmdText = "select id_fournisseur, parametre_livraison_fournisseur.designation from tableau_fournisseur_livraison inner join parametre_livraison_fournisseur on tableau_fournisseur_livraison.id_livraison = parametre_livraison_fournisseur.id where parametre_livraison_fournisseur.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Mode de livraison";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 350;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Désignation";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x0022C658 File Offset: 0x0022A858
		private void Loadreglement()
		{
			bd bd = new bd();
			string cmdText = "select id_fournisseur, parametre_reglement_fournisseur.designation from tableau_fournisseur_reglement inner join parametre_reglement_fournisseur on tableau_fournisseur_reglement.id_reglement = parametre_reglement_fournisseur.id where parametre_reglement_fournisseur.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Mode de règlement";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 350;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Désignation";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x0022C89C File Offset: 0x0022AA9C
		private void afficher_article()
		{
			bd bd = new bd();
			string cmdText = "select tableau_article_fournisseur.id_fournisseur, article.code_article, article.designation from tableau_article_fournisseur inner join article on tableau_article_fournisseur.id_article = article.id where article.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 250;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				this.ind_temp++;
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x0022CB44 File Offset: 0x0022AD44
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 11;
					if (flag3)
					{
						liste_fournisseur.id_modifier = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						modifier_fournisseur modifier_fournisseur = new modifier_fournisseur();
						modifier_fournisseur.TopLevel = false;
						Form1.Panel2.Controls.Clear();
						Form1.Panel2.Controls.Add(modifier_fournisseur);
						modifier_fournisseur.Show();
					}
					bool flag4 = e.RowIndex >= 0 && e.ColumnIndex == 12;
					if (flag4)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer le fournisseur ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag5 = dialogResult == DialogResult.Yes;
						if (flag5)
						{
							liste_fournisseur.row_act = e.RowIndex;
							bd bd = new bd();
							string cmdText = "update fournisseur set deleted = @d where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
				}
			}
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x0022CD04 File Offset: 0x0022AF04
		private void Loadfichier()
		{
			bd bd = new bd();
			string cmdText = "select id_fournisseur, tableau_fournisseur_fichier.adresse from tableau_fournisseur_fichier inner join fournisseur on tableau_fournisseur_fichier.id_fournisseur = fournisseur.id where fournisseur.deleted = @d order by tableau_fournisseur_fichier.id_fournisseur";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2", typeof(Image));
			dataTable2.Columns.Add("column3");
			int index = 9;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "docx";
					if (flag2)
					{
						index = 3;
					}
					bool flag3 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "xlsx" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "xls";
					if (flag3)
					{
						index = 4;
					}
					bool flag4 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "pdf";
					if (flag4)
					{
						index = 5;
					}
					bool flag5 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "txt";
					if (flag5)
					{
						index = 6;
					}
					bool flag6 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "jpeg" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "png" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "jpg";
					if (flag6)
					{
						index = 7;
					}
					bool flag7 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "rar" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "zip";
					if (flag7)
					{
						index = 8;
					}
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						this.imageList1.Images[index],
						dataTable.Rows[i].ItemArray[1].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Fichiers";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 80;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns[1].ImageLayout = ImageLayout.Zoom;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "";
				gridViewTemplate.ShowColumnHeaders = false;
				gridViewTemplate.AllowCellContextMenu = true;
				this.radGridView1.Templates.Insert(this.ind_temp, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x0022D19C File Offset: 0x0022B39C
		public string n_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == ".";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x0022D1FC File Offset: 0x0022B3FC
		private void radGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			GridDataCellElement targetCell = e.ContextMenuProvider as GridDataCellElement;
			bool flag = targetCell != null && targetCell.RowInfo.HierarchyLevel == 1 && targetCell.ColumnIndex == 2;
			if (flag)
			{
				e.ContextMenu.Items.Clear();
				bool flag2 = targetCell.RowInfo.ViewTemplate.Caption == "Fichiers";
				if (flag2)
				{
					RadMenuItem radMenuItem = new RadMenuItem("Ouvrir");
					e.ContextMenu.Items.Add(radMenuItem);
					radMenuItem.Click += delegate(object s, EventArgs f)
					{
						fonction.ouvrir_fichier(targetCell.Value.ToString());
					};
				}
			}
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x0022D2B9 File Offset: 0x0022B4B9
		private void button1_Click(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x040011F9 RID: 4601
		public static string id_modifier;

		// Token: 0x040011FA RID: 4602
		private static int row_act;

		// Token: 0x040011FB RID: 4603
		private int ind_temp = 0;
	}
}
