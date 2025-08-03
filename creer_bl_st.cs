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
	// Token: 0x02000051 RID: 81
	public partial class creer_bl_st : Form
	{
		// Token: 0x06000395 RID: 917 RVA: 0x00096C94 File Offset: 0x00094E94
		public creer_bl_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.select_fournisseur();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00096D59 File Offset: 0x00094F59
		private void creer_bl_st_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00096D70 File Offset: 0x00094F70
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				bool flag2 = radButtonElement.Text == "Choisir";
				if (flag2)
				{
					radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
					radButtonElement.ForeColor = Color.White;
					radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				}
				else
				{
					radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
					radButtonElement.ForeColor = Color.White;
					radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				}
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00096E90 File Offset: 0x00095090
		public void remplissage_tableau(int o, int f)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView2.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select ds_commande_article.id, id_commande, ds_commande.date_commande, article.designation, magasin_sous_traitance.ref_interne, activite.designation, fournisseur.nom, id_t, source from ds_commande_article inner join ds_commande on ds_commande_article.id_commande = ds_commande.id inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id where ds_commande_article.source = @s and ds_commande.statut = @i and ds_commande_article.reception = @r and fournisseur.id = @f order by ds_commande_article.id_commande";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = f;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select ds_commande_article.id, id_commande, ds_commande.date_commande, article.designation, activite.designation, fournisseur.nom, id_t, source from ds_commande_article inner join ds_commande on ds_commande_article.id_commande = ds_commande.id inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id where ds_commande_article.source = @s and ds_commande.statut = @i and ds_commande_article.reception = @r and fournisseur.id = @f order by ds_commande_article.id_commande";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			sqlCommand2.Parameters.Add("@r", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
			sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = f;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString()
					});
					this.radGridView1.Rows[i].Cells[6].Value = "Choisir";
					this.radGridView1.Rows[i].Cells[7].Value = dataTable.Rows[i].ItemArray[7].ToString();
					this.radGridView1.Rows[i].Cells[8].Value = dataTable.Rows[i].ItemArray[8].ToString();
				}
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable2.Rows[j].ItemArray[0].ToString(),
						dataTable2.Rows[j].ItemArray[1].ToString(),
						fonction.Mid(dataTable2.Rows[j].ItemArray[2].ToString(), 1, 10),
						dataTable2.Rows[j].ItemArray[3].ToString(),
						"-",
						dataTable2.Rows[j].ItemArray[4].ToString()
					});
					int num = this.radGridView1.Rows.Count - 1;
					this.radGridView1.Rows[num].Cells[6].Value = "Choisir";
					this.radGridView1.Rows[num].Cells[7].Value = dataTable2.Rows[j].ItemArray[6].ToString();
					this.radGridView1.Rows[num].Cells[8].Value = dataTable2.Rows[j].ItemArray[7].ToString();
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			ListSortDirection listSortDirection = ListSortDirection.Descending;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterTemplate.SortDescriptors.Add("column5", listSortDirection);
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0009740C File Offset: 0x0009560C
		private void select_fournisseur()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select distinct fournisseur.id, fournisseur.nom from ds_commande_article inner join ds_commande on ds_commande_article.id_commande = ds_commande.id inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id where  ds_commande.statut = @i and ds_commande_article.reception = @r";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00097530 File Offset: 0x00095730
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				this.remplissage_tableau(0, Convert.ToInt32(this.radDropDownList6.SelectedItem.Tag));
			}
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00097578 File Offset: 0x00095778
		private void get_ligne_livree(int id_ds_art, string src)
		{
			bd bd = new bd();
			bool flag = src == "ex";
			if (flag)
			{
				string cmdText = "select ds_commande_article.id, id_commande, article.designation, magasin_sous_traitance.ref_interne, activite.designation,ds_commande_article.qt ,id_t, source from ds_commande_article inner join ds_commande on ds_commande_article.id_commande = ds_commande.id inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id where ds_commande_article.id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_ds_art;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[0].ItemArray[0].ToString(),
						dataTable.Rows[0].ItemArray[1].ToString(),
						dataTable.Rows[0].ItemArray[2].ToString(),
						dataTable.Rows[0].ItemArray[3].ToString(),
						dataTable.Rows[0].ItemArray[4].ToString(),
						dataTable.Rows[0].ItemArray[5].ToString(),
						"",
						"",
						dataTable.Rows[0].ItemArray[6].ToString(),
						dataTable.Rows[0].ItemArray[7].ToString()
					});
				}
			}
			bool flag3 = src == "nv";
			if (flag3)
			{
				string cmdText2 = "select ds_commande_article.id, id_commande, article.designation, activite.designation,ds_commande_article.qt ,id_t, source from ds_commande_article inner join ds_commande on ds_commande_article.id_commande = ds_commande.id inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id where ds_commande_article.id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id_ds_art;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag4 = dataTable2.Rows.Count != 0;
				if (flag4)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						dataTable2.Rows[0].ItemArray[0].ToString(),
						dataTable2.Rows[0].ItemArray[1].ToString(),
						dataTable2.Rows[0].ItemArray[2].ToString(),
						"-",
						dataTable2.Rows[0].ItemArray[3].ToString(),
						dataTable2.Rows[0].ItemArray[4].ToString(),
						"",
						"",
						dataTable2.Rows[0].ItemArray[5].ToString(),
						dataTable2.Rows[0].ItemArray[6].ToString()
					});
				}
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00097880 File Offset: 0x00095A80
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag3)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						string src = this.radGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
						creer_bl_st.row_act = e.RowIndex;
						this.panel1.Visible = true;
						bool flag4 = this.test_existe(text) == 1;
						if (flag4)
						{
							this.get_ligne_livree(Convert.ToInt32(text), src);
							this.radGridView1.Rows[e.RowIndex].Cells[6].Value = "Annuler";
						}
						else
						{
							this.radGridView2.Rows.RemoveAt(this.retour_pos(text));
							this.radGridView1.Rows[e.RowIndex].Cells[6].Value = "Choisir";
						}
					}
				}
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000979E4 File Offset: 0x00095BE4
		private int test_existe(string id_ds_art)
		{
			int result = 1;
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = this.radGridView2.Rows[i].Cells[0].Value.ToString() == id_ds_art;
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00097A6C File Offset: 0x00095C6C
		private int retour_pos(string id_ds_art)
		{
			int result = 0;
			bool flag = this.test_existe(id_ds_art) == 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = this.radGridView2.Rows[i].Cells[0].Value.ToString() == id_ds_art;
					if (flag2)
					{
						result = i;
					}
				}
			}
			return result;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00097AEC File Offset: 0x00095CEC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.format_prix() == 1;
				if (flag2)
				{
					bool flag3 = this.format_remise() == 1;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "insert into ds_bon_livraison (date_livraison, heure_livraison, livraison_par, statut, date_reel, id_fournisseur, bl_fournisseur) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)SELECT CAST(scope_identity() AS int)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
						sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
						sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@i5", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
						sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
						sqlCommand.Parameters.Add("@i7", SqlDbType.VarChar).Value = this.TextBox1.Text;
						bd.ouverture_bd(bd.cnn);
						int num = (int)sqlCommand.ExecuteScalar();
						bd.cnn.Close();
						for (int i = 0; i < this.radGridView2.Rows.Count; i++)
						{
							string cmdText2 = "insert into ds_livraison_article (id_livraison, id_ds_commande_article, qt, prix_ht, remise) values (@i1, @i2, @i3, @i4, @i5)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[0].Value.ToString();
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[5].Value.ToString();
							sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[6].Value.ToString();
							sqlCommand2.Parameters.Add("@i5", SqlDbType.Real).Value = this.radGridView2.Rows[i].Cells[7].Value.ToString();
							string cmdText3 = "update ds_commande_article set reception = @d where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[0].Value.ToString();
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
							bool flag4 = this.radGridView2.Rows[i].Cells[9].Value.ToString() == "ex";
							if (flag4)
							{
								string cmdText4 = "update magasin_sous_traitance set reception = @d, nbr_reparation = nbr_reparation + 1 , emplacement_actuel = @m where id = @t";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@t", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[8].Value.ToString();
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 1;
								sqlCommand4.Parameters.Add("@m", SqlDbType.VarChar).Value = "Magasin";
								string cmdText5 = "insert into ds_historique_mvt (id_t, id_mvt, date_mvt, heure_mvt, mvt) values (@i1, @i2, @i3, @i4, @i5)";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
								sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = num;
								sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[8].Value.ToString();
								sqlCommand5.Parameters.Add("@i3", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
								sqlCommand5.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
								sqlCommand5.Parameters.Add("@i5", SqlDbType.VarChar).Value = "Livraison";
								bd.ouverture_bd(bd.cnn);
								sqlCommand4.ExecuteNonQuery();
								sqlCommand5.ExecuteNonQuery();
								bd.cnn.Close();
							}
							this.cloturer_commande(this.radGridView2.Rows[i].Cells[1].Value.ToString());
						}
						MessageBox.Show("Création d'un BL avec succés");
						this.radGridView1.Rows.Clear();
						this.radGridView2.Rows.Clear();
						this.select_fournisseur();
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

		// Token: 0x060003A0 RID: 928 RVA: 0x0009810C File Offset: 0x0009630C
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
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView2.Rows[i].Cells[6].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000981A0 File Offset: 0x000963A0
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
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView2.Rows[i].Cells[7].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00098234 File Offset: 0x00096434
		private void cloturer_commande(string id_commande)
		{
			bd bd = new bd();
			string cmdText = "select id from ds_commande_article where id_commande = @i and reception = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_commande;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count == 0;
			if (flag)
			{
				string cmdText2 = "update ds_commande set statut = @d where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id_commande;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 10;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}

		// Token: 0x040004D9 RID: 1241
		private static int row_act;
	}
}
