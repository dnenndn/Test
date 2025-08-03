using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200002B RID: 43
	public partial class bl_non_facture_st : Form
	{
		// Token: 0x06000222 RID: 546 RVA: 0x0005B0B8 File Offset: 0x000592B8
		public bl_non_facture_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0005B144 File Offset: 0x00059344
		private void bl_non_facture_st_Load(object sender, EventArgs e)
		{
			this.panel1.Hide();
			bool flag = page_loginn.stat_user != "Responsable Achat";
			if (flag)
			{
				this.guna2Button1.Hide();
			}
			this.remplissage_tableau(0);
			this.radDateTimePicker1.Value = DateTime.Today;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0005B198 File Offset: 0x00059398
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

		// Token: 0x06000225 RID: 549 RVA: 0x0005B230 File Offset: 0x00059430
		private void loadarticle1()
		{
			bd bd = new bd();
			string cmdText = "select id_livraison, magasin_sous_traitance.ref_interne, article.code_article, article.designation, activite.designation,ds_livraison_article.qt ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_livraison_article inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s and ds_bon_livraison.statut = @d ";
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

		// Token: 0x06000226 RID: 550 RVA: 0x0005B81C File Offset: 0x00059A1C
		private void loadarticle2()
		{
			bd bd = new bd();
			string cmdText = "select id_livraison, article.code_article, article.designation, activite.designation,ds_livraison_article.qt ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_livraison_article inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s and ds_bon_livraison.statut = @d ";
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

		// Token: 0x06000227 RID: 551 RVA: 0x0005BE04 File Offset: 0x0005A004
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 8;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							bd bd = new bd();
							string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
							string cmdText = "update ds_commande_article set reception = @d where id in (select id_ds_commande_article from ds_livraison_article where id_livraison = @i)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							string cmdText2 = "update ds_commande set statut = @d where id in (select id_commande from ds_commande_article where id in (select id_ds_commande_article from ds_livraison_article where id_livraison = @i))";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							string cmdText3 = "update magasin_sous_traitance set reception = @d, nbr_reparation = nbr_reparation - 1, emplacement_actuel = @r where id in (select id_t from ds_historique_mvt where id_mvt = @i and mvt = @l)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@l", SqlDbType.VarChar).Value = "Livraison";
							sqlCommand3.Parameters.Add("@r", SqlDbType.VarChar).Value = "Reparation";
							string cmdText4 = "delete ds_historique_mvt where id_mvt = @i and mvt = @l";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand4.Parameters.Add("@l", SqlDbType.VarChar).Value = "Livraison";
							string cmdText5 = "delete ds_bon_livraison where id = @i";
							string cmdText6 = "delete ds_livraison_article where id_livraison = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							sqlCommand2.ExecuteNonQuery();
							sqlCommand3.ExecuteNonQuery();
							sqlCommand4.ExecuteNonQuery();
							sqlCommand5.ExecuteNonQuery();
							sqlCommand6.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
				}
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0005C0E8 File Offset: 0x0005A2E8
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select distinct ds_bon_livraison.id, ds_bon_livraison.date_reel,date_livraison, livraison_par, fournisseur.nom, bl_fournisseur, sum((ds_livraison_article.qt*ds_livraison_article.prix_ht) - ((ds_livraison_article.qt*ds_livraison_article.prix_ht*ds_livraison_article.remise)/100)) from ds_bon_livraison  inner join fournisseur on ds_bon_livraison.id_fournisseur = fournisseur.id inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison where ds_bon_livraison.statut = @i group by ds_bon_livraison.id, ds_bon_livraison.date_reel,date_livraison, livraison_par, fournisseur.nom, bl_fournisseur";
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
						Convert.ToString(dataTable.Rows[i].ItemArray[5].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000")
					});
					this.radGridView1.Rows[i].Cells[8].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				}
				bool flag2 = page_loginn.stat_user != "Responsable Achat";
				if (flag2)
				{
					this.radGridView1.Columns[7].IsVisible = false;
					this.radGridView1.Columns[8].IsVisible = false;
				}
			}
			bool flag3 = this.radGridView1.Rows.Count != 0;
			if (flag3)
			{
				bool flag4 = o == 0;
				if (flag4)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag5 = o == 1;
				if (flag5)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag6 = o == 2;
				if (flag6)
				{
					this.radGridView1.Rows[bl_non_facture_st.row_act].IsCurrent = true;
				}
				bool flag7 = o == 3;
				if (flag7)
				{
					bool flag8 = bl_non_facture_st.row_act != 0;
					if (flag8)
					{
						this.radGridView1.Rows[bl_non_facture_st.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000229 RID: 553 RVA: 0x0005C4A8 File Offset: 0x0005A6A8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			this.panel1.Hide();
			this.TextBox1.Clear();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.test_cochez() == 1;
				if (flag2)
				{
					this.ss.Clear();
					this.sf.Clear();
					for (int i = 0; i < this.radGridView1.Rows.Count; i++)
					{
						bool flag3 = Convert.ToString(this.radGridView1.Rows[i].Cells[7].Value) == "True";
						if (flag3)
						{
							this.ss.Add(this.radGridView1.Rows[i].Cells[0].Value.ToString());
							this.sf.Add(Convert.ToString(this.radGridView1.Rows[i].Cells[5].Value));
						}
					}
					int num = 0;
					bool flag4 = this.sf.Count > 1;
					if (flag4)
					{
						for (int j = 0; j < this.sf.Count - 1; j++)
						{
							bool flag5 = this.sf[j] != this.sf[j + 1];
							if (flag5)
							{
								num = 1;
							}
						}
					}
					bool flag6 = num == 0;
					if (flag6)
					{
						bd bd = new bd();
						string cmdText = "select tva_defaut from fournisseur where nom = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.sf[0];
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag7 = dataTable.Rows.Count != 0;
						if (flag7)
						{
							this.TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
						}
						this.panel1.Show();
					}
					else
					{
						MessageBox.Show("Erreur : Impossible de créer une facture contenant deux fournisseurs différent", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Il faut cochez au moin un bon de livraison", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Tableau est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0005C739 File Offset: 0x0005A939
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Hide();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0005C748 File Offset: 0x0005A948
		private int test_cochez()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[7].Value) == "True";
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0005C7DC File Offset: 0x0005A9DC
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.TextBox1.Text);
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from fournisseur where nom = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.sf[0];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string value = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
					string cmdText2 = "insert into ds_facture (date_facture, heure_facture, createur, id_fournisseur, tva, date_reel, n_facture) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = value;
					sqlCommand2.Parameters.Add("@i5", SqlDbType.Real).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@i6", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
					sqlCommand2.Parameters.Add("@i7", SqlDbType.VarChar).Value = this.TextBox2.Text;
					bd.ouverture_bd(bd.cnn);
					int num = (int)sqlCommand2.ExecuteScalar();
					bd.cnn.Close();
					for (int i = 0; i < this.ss.Count; i++)
					{
						string cmdText3 = "insert into ds_facture_livraison (id_facture, id_livraison) values (@i1, @i2)";
						string cmdText4 = "update ds_bon_livraison set statut = @d where id = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.ss[i];
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 1;
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.ss[i];
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
					MessageBox.Show("Création de facture avec succés");
					this.panel1.Hide();
					this.remplissage_tableau(0);
					this.TextBox2.Clear();
				}
			}
			else
			{
				MessageBox.Show("Erreur : TVA doit être un réel", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x040002FF RID: 767
		private List<string> ss = new List<string>();

		// Token: 0x04000300 RID: 768
		private List<string> sf = new List<string>();

		// Token: 0x04000301 RID: 769
		private static int row_act;
	}
}
