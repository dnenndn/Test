using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000059 RID: 89
	public partial class creer_reception : Form
	{
		// Token: 0x0600043A RID: 1082 RVA: 0x000B4628 File Offset: 0x000B2828
		public creer_reception()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.CellValueChanged += new GridViewCellEventHandler(this.qt_bon_change);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000B46D9 File Offset: 0x000B28D9
		private void creer_reception_Load(object sender, EventArgs e)
		{
			this.radPanel2.Hide();
			this.select_fournisseur();
			this.radDateTimePicker1.Value = DateTime.Today;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000B4700 File Offset: 0x000B2900
		private void select_fournisseur()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select distinct fournisseur.nom from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where commande.statut = @o and fournisseur.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@o", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000B47F0 File Offset: 0x000B29F0
		public void remplissage_tableau(string o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bool flag = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				string cmdText = "select commande.id,date_commande, createur from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where statut = @i and fournisseur.nom = @k";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = o;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
							this.select_utilisateur(dataTable.Rows[i].ItemArray[2].ToString())
						});
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.LoadArticle();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000B4A10 File Offset: 0x000B2C10
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

		// Token: 0x0600043F RID: 1087 RVA: 0x000B4AA6 File Offset: 0x000B2CA6
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.radPanel2.Hide();
			this.radGridView2.Rows.Clear();
			this.remplissage_tableau(this.radDropDownList6.Text);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x000B4AD8 File Offset: 0x000B2CD8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			this.ss.Clear();
			this.radGridView2.Rows.Clear();
			int num = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[3].Value) == "True";
					if (flag2)
					{
						num = 1;
						this.ss.Add(this.radGridView1.Rows[i].Cells[0].Value.ToString());
					}
				}
			}
			bool flag3 = num == 1;
			if (flag3)
			{
				for (int j = 0; j < this.ss.Count; j++)
				{
					this.select_article_receptionne(this.ss[j]);
				}
				this.label5.Text = this.radDropDownList6.Text;
				this.radPanel2.Show();
			}
			else
			{
				MessageBox.Show("Erreur : Il faut cochez au moin une commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000B4C30 File Offset: 0x000B2E30
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, article.code_article,article.designation, qt_commande  from commande_article inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join commande on commande_article.id_commande = commande.id where commande.statut = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
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
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000B4F3C File Offset: 0x000B313C
		private void select_article_receptionne(string h)
		{
			bd bd = new bd();
			string cmdText = "select id from reception_commande where id_commande = @h";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = h;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id_commande,  article.id,  article.code_article, article.designation, qt_commande, demande_achat.demandeur, demande_achat.id from commande_article inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join demande_achat on da_article.id_da = demande_achat.id where id_commande = @h";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = h;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						string cmdText3 = "select qt_recu from reception_article where id_article = @i1 and id_commande = @i2";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[1];
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						double num = 0.0;
						bool flag3 = dataTable3.Rows.Count != 0;
						if (flag3)
						{
							for (int j = 0; j < dataTable3.Rows.Count; j++)
							{
								num += Convert.ToDouble(dataTable3.Rows[j].ItemArray[0]);
							}
						}
						bool flag4 = num < Convert.ToDouble(dataTable2.Rows[i].ItemArray[4].ToString());
						if (flag4)
						{
							this.radGridView2.Rows.Add(new object[]
							{
								dataTable2.Rows[i].ItemArray[0].ToString(),
								dataTable2.Rows[i].ItemArray[1].ToString(),
								this.select_utilisateur(dataTable2.Rows[i].ItemArray[5].ToString()),
								dataTable2.Rows[i].ItemArray[2].ToString(),
								dataTable2.Rows[i].ItemArray[3].ToString(),
								dataTable2.Rows[i].ItemArray[4].ToString(),
								num,
								Convert.ToDouble(dataTable2.Rows[i].ItemArray[4].ToString()) - num,
								Convert.ToDouble(dataTable2.Rows[i].ItemArray[4].ToString()) - num,
								0,
								100,
								dataTable2.Rows[i].ItemArray[6].ToString()
							});
						}
					}
				}
			}
			else
			{
				string cmdText4 = "select id_commande,  article.id,  article.code_article, article.designation, qt_commande, demande_achat.demandeur, demande_achat.id  from commande_article inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join demande_achat on da_article.id_da = demande_achat.id where id_commande = @h";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@h", SqlDbType.Int).Value = h;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag5 = dataTable4.Rows.Count != 0;
				if (flag5)
				{
					for (int k = 0; k < dataTable4.Rows.Count; k++)
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable4.Rows[k].ItemArray[0].ToString(),
							dataTable4.Rows[k].ItemArray[1].ToString(),
							this.select_utilisateur(dataTable4.Rows[k].ItemArray[5].ToString()),
							dataTable4.Rows[k].ItemArray[2].ToString(),
							dataTable4.Rows[k].ItemArray[3].ToString(),
							dataTable4.Rows[k].ItemArray[4].ToString(),
							0,
							dataTable4.Rows[k].ItemArray[4].ToString(),
							dataTable4.Rows[k].ItemArray[4].ToString(),
							0,
							100,
							dataTable4.Rows[k].ItemArray[6].ToString()
						});
					}
				}
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000B5488 File Offset: 0x000B3688
		private void qt_bon_change(object sender, GridViewCellEventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1 & e.ColumnIndex == 7;
				if (flag2)
				{
					bool flag3 = fonction.is_reel(this.radGridView2.Rows[e.RowIndex].Cells[7].Value.ToString());
					if (flag3)
					{
						this.radGridView2.Rows[e.RowIndex].Cells[8].Value = this.radGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
						this.radGridView2.Rows[e.RowIndex].Cells[9].Value = 0;
					}
				}
				bool flag4 = e.RowIndex != -1 & e.ColumnIndex == 8;
				if (flag4)
				{
					bool flag5 = fonction.is_reel(this.radGridView2.Rows[e.RowIndex].Cells[7].Value.ToString()) & fonction.is_reel(this.radGridView2.Rows[e.RowIndex].Cells[8].Value.ToString());
					if (flag5)
					{
						this.radGridView2.Rows[e.RowIndex].Cells[9].Value = Convert.ToDouble(this.radGridView2.Rows[e.RowIndex].Cells[7].Value.ToString()) - Convert.ToDouble(this.radGridView2.Rows[e.RowIndex].Cells[8].Value.ToString());
					}
				}
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x000B56B0 File Offset: 0x000B38B0
		private int test_format_qt_recu()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.radGridView2.Rows.Count; i++)
			{
				bool flag = !fonction.is_reel(this.radGridView2.Rows[i].Cells[7].Value.ToString());
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x000B5728 File Offset: 0x000B3928
		private int test_format_qt_bon()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.radGridView2.Rows.Count; i++)
			{
				bool flag = !fonction.is_reel(this.radGridView2.Rows[i].Cells[8].Value.ToString());
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x000B57A0 File Offset: 0x000B39A0
		private int test_somme()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.radGridView2.Rows.Count; i++)
			{
				bool flag = Convert.ToDouble(this.radGridView2.Rows[i].Cells[9].Value) != Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value) - Convert.ToDouble(this.radGridView2.Rows[i].Cells[8].Value);
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x000B5868 File Offset: 0x000B3A68
		private int test_aumoin()
		{
			int result = 0;
			fonction fonction = new fonction();
			for (int i = 0; i < this.radGridView2.Rows.Count; i++)
			{
				bool flag = Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value) != 0.0;
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x000B58E4 File Offset: 0x000B3AE4
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.test_format_qt_recu() == 1;
				if (flag2)
				{
					bool flag3 = this.test_format_qt_bon() == 1;
					if (flag3)
					{
						bool flag4 = this.test_somme() == 1;
						if (flag4)
						{
							bool flag5 = this.test_aumoin() == 1;
							if (flag5)
							{
								bool flag6 = this.compare_qt() == 1;
								if (flag6)
								{
									bd bd = new bd();
									string cmdText = "insert into reception (date_reception, heure_reception, reception_par, commentaire, statut, date_reel) values (@i1, @i2, @i3, @i4, @i5, @i6)SELECT CAST(scope_identity() AS int)";
									SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
									sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
									sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
									sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
									sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.TextBox1.Text;
									sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
									sqlCommand.Parameters.Add("@i6", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
									bd.ouverture_bd(bd.cnn);
									int num = (int)sqlCommand.ExecuteScalar();
									bd.cnn.Close();
									for (int i = 0; i < this.ss.Count; i++)
									{
										string cmdText2 = "insert into reception_commande(id_reception, id_commande) values (@i1, @i2)";
										SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
										sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
										sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.ss[i];
										bd.ouverture_bd(bd.cnn);
										sqlCommand2.ExecuteNonQuery();
										bd.cnn.Close();
									}
									for (int j = 0; j < this.radGridView2.Rows.Count; j++)
									{
										string cmdText3 = "insert into reception_article (id_reception, id_commande, id_article, qt_recu, etat, qt_bon_etat, qt_mauvais_etat, id_da) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8) ";
										SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
										sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
										sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[0].Value.ToString();
										sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[1].Value.ToString();
										sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = this.radGridView2.Rows[j].Cells[7].Value.ToString();
										sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(this.radGridView2.Rows[j].Cells[10].Value);
										sqlCommand3.Parameters.Add("@i6", SqlDbType.Real).Value = this.radGridView2.Rows[j].Cells[8].Value.ToString();
										sqlCommand3.Parameters.Add("@i7", SqlDbType.Real).Value = this.radGridView2.Rows[j].Cells[9].Value.ToString();
										sqlCommand3.Parameters.Add("@i8", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[11].Value.ToString();
										string cmdText4 = "update article set stock_neuf = stock_neuf + @a where id = @i";
										SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
										sqlCommand4.Parameters.Add("@a", SqlDbType.Real).Value = this.radGridView2.Rows[j].Cells[7].Value.ToString();
										sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[1].Value.ToString();
										bd.ouverture_bd(bd.cnn);
										sqlCommand4.ExecuteNonQuery();
										bd.cnn.Close();
										string cmdText5 = "select  tva, prix_ht, stock_neuf,  stock_use, stock_rebute from article where id = @i";
										SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
										sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[1].Value.ToString();
										SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand5);
										DataTable dataTable = new DataTable();
										sqlDataAdapter.Fill(dataTable);
										string cmdText6 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
										SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
										sqlCommand6.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[1].Value.ToString();
										sqlCommand6.Parameters.Add("@i2", SqlDbType.Real).Value = dataTable.Rows[0].ItemArray[0].ToString();
										sqlCommand6.Parameters.Add("@i3", SqlDbType.Real).Value = dataTable.Rows[0].ItemArray[1].ToString();
										sqlCommand6.Parameters.Add("@i4", SqlDbType.Real).Value = dataTable.Rows[0].ItemArray[2].ToString();
										sqlCommand6.Parameters.Add("@i5", SqlDbType.Real).Value = dataTable.Rows[0].ItemArray[3].ToString();
										sqlCommand6.Parameters.Add("@i6", SqlDbType.Real).Value = dataTable.Rows[0].ItemArray[4].ToString();
										sqlCommand6.Parameters.Add("@i7", SqlDbType.Date).Value = DateTime.Today;
										bd.ouverture_bd(bd.cnn);
										sqlCommand3.ExecuteNonQuery();
										sqlCommand6.ExecuteNonQuery();
										bd.cnn.Close();
									}
									for (int k = 0; k < this.ss.Count; k++)
									{
										this.cloture_commande(this.ss[k]);
									}
									MessageBox.Show("Création d'un bon de réception commande avec succés");
									this.select_fournisseur();
									this.radGridView1.Rows.Clear();
									this.radPanel2.Hide();
								}
								else
								{
									MessageBox.Show("Erreur : Il faut que la quantité reçu d'un article inférieure ou égale à la quantité commandé ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								MessageBox.Show("Erreur : Il faut que la quantité reçu d'un article au moin est différente à zéro ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : Vérifier la somme qt reçu par rapport à la quantité bonne état et mauvaise état ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Format de la colonne quantité bonne état est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Format de la colonne quantité reçu est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Tableau des articles est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000B6118 File Offset: 0x000B4318
		private void cloture_commande(string id_cmnd)
		{
			bd bd = new bd();
			string cmdText = "select sum(qt_recu), reception_article.id_article from reception_article  where reception_article.id_commande = @d group by reception_article.id_article";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = id_cmnd;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			int num = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select commande_article.id from commande_article inner join da_article on commande_article.id_da_article = da_article.id where commande_article.id_commande = @d and qt_commande > @f and da_article.id_article = @a ";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = id_cmnd;
					sqlCommand2.Parameters.Add("@f", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						num = 1;
					}
				}
				bool flag3 = num == 0;
				if (flag3)
				{
					string cmdText3 = "update commande set statut = @s where id = @h";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@s", SqlDbType.Int).Value = 10;
					sqlCommand3.Parameters.Add("@h", SqlDbType.Int).Value = id_cmnd;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000B62F8 File Offset: 0x000B44F8
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.radPanel2.Hide();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000B6308 File Offset: 0x000B4508
		private int compare_qt()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value.ToString()) > Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value.ToString()) - Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x040005BF RID: 1471
		private List<string> ss = new List<string>();
	}
}
