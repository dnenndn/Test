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
	// Token: 0x0200002A RID: 42
	public partial class bl_non_facture : Form
	{
		// Token: 0x06000216 RID: 534 RVA: 0x00058924 File Offset: 0x00056B24
		public bl_non_facture()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000589B0 File Offset: 0x00056BB0
		private void bl_non_facture_Load(object sender, EventArgs e)
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

		// Token: 0x06000218 RID: 536 RVA: 0x00058A04 File Offset: 0x00056C04
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

		// Token: 0x06000219 RID: 537 RVA: 0x00058A9C File Offset: 0x00056C9C
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_livraison, article.code_article, article.designation, livraison_article.qt, livraison_article.prix_ht, livraison_article.remise from livraison_article inner join article on livraison_article.id_article = article.id inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.statut = @d";
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
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.Columns["column6"].Width = 150;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité livrée";
				gridViewTemplate.Columns[4].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[5].HeaderText = "Remise";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00058ED8 File Offset: 0x000570D8
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
							string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
							bd bd = new bd();
							string cmdText = "select id_reception from bon_livraison where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							string cmdText2 = "update reception set statut = @v where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 0;
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							string cmdText3 = "select id_article, qt, prix_ht  from livraison_article where id_livraison = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag5 = dataTable2.Rows.Count != 0;
							if (flag5)
							{
								for (int i = 0; i < dataTable2.Rows.Count; i++)
								{
									string cmdText4 = "select stock_neuf from article where id = @i";
									SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
									sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable2.Rows[i].ItemArray[0]);
									SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
									DataTable dataTable3 = new DataTable();
									sqlDataAdapter3.Fill(dataTable3);
									bool flag6 = dataTable3.Rows.Count != 0;
									if (flag6)
									{
										bool flag7 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]) > Convert.ToDouble(dataTable2.Rows[i].ItemArray[1]);
										if (flag7)
										{
											string cmdText5 = "update article  set prix_ht = (prix_ht * stock_neuf - @v1*@v2)/ (stock_neuf - @v1) where id = @i";
											SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
											sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable2.Rows[i].ItemArray[0]);
											sqlCommand5.Parameters.Add("@v1", SqlDbType.Real).Value = Convert.ToDouble(dataTable2.Rows[i].ItemArray[1]);
											sqlCommand5.Parameters.Add("@v2", SqlDbType.Real).Value = Convert.ToDouble(dataTable2.Rows[i].ItemArray[2]);
											bd.ouverture_bd(bd.cnn);
											sqlCommand5.ExecuteNonQuery();
											bd.cnn.Close();
										}
									}
								}
							}
							string cmdText6 = "delete bon_livraison where id = @i";
							string cmdText7 = "delete livraison_article where id_livraison = @i";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand6.ExecuteNonQuery();
							sqlCommand7.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
				}
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00059328 File Offset: 0x00057528
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select distinct bon_livraison.id, bon_livraison.date_reel,date_livraison, livraison_par, fournisseur.nom, bl_fournisseur, sum((livraison_article.qt*livraison_article.prix_ht) - ((livraison_article.qt*livraison_article.prix_ht*livraison_article.remise)/100)) /COUNT(distinct reception_commande.id) from bon_livraison inner join reception on bon_livraison.id_reception = reception.id inner join reception_commande on reception.id = reception_commande.id_reception inner join commande on reception_commande.id_commande = commande.id inner join fournisseur on commande.id_fournisseur = fournisseur.id inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where bon_livraison.statut = @i group by bon_livraison.id ,date_livraison, heure_livraison, livraison_par, fournisseur.nom, bon_livraison.date_reel, bl_fournisseur";
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
					this.radGridView1.Rows[bl_non_facture.row_act].IsCurrent = true;
				}
				bool flag7 = o == 3;
				if (flag7)
				{
					bool flag8 = bl_non_facture.row_act != 0;
					if (flag8)
					{
						this.radGridView1.Rows[bl_non_facture.row_act - 1].IsCurrent = true;
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
			this.loadarticle();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000596E0 File Offset: 0x000578E0
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

		// Token: 0x0600021D RID: 541 RVA: 0x00059971 File Offset: 0x00057B71
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Hide();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00059980 File Offset: 0x00057B80
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

		// Token: 0x0600021F RID: 543 RVA: 0x00059A14 File Offset: 0x00057C14
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
					string cmdText2 = "insert into facture (date_facture, heure_facture, createur, id_fournisseur, tva, date_reel, n_facture) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)SELECT CAST(scope_identity() AS int)";
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
						string cmdText3 = "insert into facture_livraison (id_facture, id_livraison) values (@i1, @i2)";
						string cmdText4 = "update bon_livraison set statut = @d where id = @i";
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

		// Token: 0x040002EF RID: 751
		private List<string> ss = new List<string>();

		// Token: 0x040002F0 RID: 752
		private List<string> sf = new List<string>();

		// Token: 0x040002F1 RID: 753
		private static int row_act;
	}
}
