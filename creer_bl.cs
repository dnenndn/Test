using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
	// Token: 0x02000050 RID: 80
	public partial class creer_bl : Form
	{
		// Token: 0x06000384 RID: 900 RVA: 0x00093ABC File Offset: 0x00091CBC
		public creer_bl()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00093B4C File Offset: 0x00091D4C
		private void creer_bl_Load(object sender, EventArgs e)
		{
			design.design_datagridview(this.dataGridView2);
			this.radPanel1.Hide();
			this.radGridView1.Size = new Size(1050, 495);
			this.remplissage_tableau(0);
			this.radDateTimePicker1.Value = DateTime.Today;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00093BA8 File Offset: 0x00091DA8
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00093C64 File Offset: 0x00091E64
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

		// Token: 0x06000388 RID: 904 RVA: 0x00093CFC File Offset: 0x00091EFC
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_reception, id_commande, article.code_article, article.designation, qt_recu from reception_article inner join article on reception_article.id_article = article.id inner join reception on reception_article.id_reception = reception.id where reception.statut = @d";
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
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "ID Commande";
				gridViewTemplate.Columns[2].HeaderText = "Code article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Quantité récu";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x000940B0 File Offset: 0x000922B0
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
						string id_r = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						this.id_reception = id_r;
						this.radGridView1.Hide();
						this.label1.Hide();
						this.radPanel1.Location = new Point(20, 31);
						this.radPanel1.Size = new Size(1000, 500);
						this.dataGridView2.Size = new Size(985, 326);
						this.radPanel1.Show();
						this.select_article_bl(id_r);
						this.label4.Text = this.radGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
					}
					bool flag4 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag4)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag5 = dialogResult == DialogResult.Yes;
						if (flag5)
						{
							string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
							bd bd = new bd();
							string cmdText = "select id_commande from reception_commande where id_reception = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							for (int i = 0; i < dataTable.Rows.Count; i++)
							{
								string cmdText2 = "update commande set statut = @v where id = @i";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 1;
								sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								bd.cnn.Close();
							}
							string cmdText3 = "select id_article, sum(qt_recu) from reception_article where id_reception = @i group by id_article";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag6 = dataTable2.Rows.Count != 0;
							if (flag6)
							{
								for (int j = 0; j < dataTable2.Rows.Count; j++)
								{
									string cmdText4 = "update article  set stock_neuf = stock_neuf - @v where id = @i";
									SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
									sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable2.Rows[j].ItemArray[0]);
									sqlCommand4.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable2.Rows[j].ItemArray[1]);
									bd.ouverture_bd(bd.cnn);
									sqlCommand4.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							string cmdText5 = "delete reception where id = @i";
							string cmdText6 = "delete reception_commande where id_reception = @i";
							string cmdText7 = "delete reception_article where id_reception = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							sqlCommand6.ExecuteNonQuery();
							sqlCommand7.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
				}
			}
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0009456C File Offset: 0x0009276C
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select reception.id, date_reel, date_reception, heure_reception, reception_par, fournisseur.nom from reception inner join reception_commande on reception.id = reception_commande.id_reception inner join commande on reception_commande.id_commande = commande.id inner join fournisseur on commande.id_fournisseur = fournisseur.id where reception.statut = @i";
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
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[4].ToString()),
						dataTable.Rows[i].ItemArray[5].ToString(),
						"Créer Bon de livraison",
						Resources.icons8_supprimer_pour_toujours_100__4_
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
					this.radGridView1.Rows[creer_bl.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = creer_bl.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[creer_bl.row_act - 1].IsCurrent = true;
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

		// Token: 0x0600038B RID: 907 RVA: 0x00094895 File Offset: 0x00092A95
		private void label3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00094898 File Offset: 0x00092A98
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.radPanel1.Hide();
			this.label1.Show();
			this.radGridView1.Show();
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000948C0 File Offset: 0x00092AC0
		private void select_article_bl(string id_r)
		{
			this.dataGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select article.code_article, article.designation, sum(qt_recu), article.id from reception_article inner join article on reception_article.id_article = article.id where reception_article.id_reception = @i group by article.code_article, article.designation, article.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_r;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.dataGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						0,
						0,
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
			}
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00094A08 File Offset: 0x00092C08
		private int test_format_qt()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
			{
				bool flag = !fonction.is_reel(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00094A80 File Offset: 0x00092C80
		private int test_format_prix()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
			{
				bool flag = !fonction.is_reel(this.dataGridView2.Rows[i].Cells[3].Value.ToString());
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00094AF8 File Offset: 0x00092CF8
		private int test_format_remise()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
			{
				bool flag = !fonction.is_reel(this.dataGridView2.Rows[i].Cells[4].Value.ToString());
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00094B70 File Offset: 0x00092D70
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.dataGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.test_format_qt() == 1;
				if (flag2)
				{
					bool flag3 = this.test_format_prix() == 1;
					if (flag3)
					{
						bool flag4 = this.test_format_remise() == 1;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "insert into bon_livraison (date_livraison, heure_livraison, livraison_par, id_reception, statut, date_reel, bl_fournisseur) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.id_reception;
							sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
							sqlCommand.Parameters.Add("@i6", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
							sqlCommand.Parameters.Add("@i7", SqlDbType.VarChar).Value = this.TextBox1.Text;
							bd.ouverture_bd(bd.cnn);
							int num = (int)sqlCommand.ExecuteScalar();
							bd.cnn.Close();
							string cmdText2 = "update reception set statut = @d where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_reception;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
							{
								bool flag5 = Convert.ToDouble(this.dataGridView2.Rows[i].Cells[2].Value) > 0.0;
								if (flag5)
								{
									int num2 = 0;
									bool flag6 = Convert.ToBoolean(this.dataGridView2.Rows[i].Cells[6].Value);
									if (flag6)
									{
										num2 = 1;
									}
									string cmdText3 = "insert into livraison_article (id_livraison, id_article, qt, prix_ht, remise, investissement) values (@i1, @i2, @i3, @i4, @i5, @i6)";
									SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
									sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
									sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
									sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
									sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = this.dataGridView2.Rows[i].Cells[3].Value.ToString();
									sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = this.dataGridView2.Rows[i].Cells[4].Value.ToString();
									sqlCommand3.Parameters.Add("@i6", SqlDbType.Int).Value = num2;
									bd.ouverture_bd(bd.cnn);
									sqlCommand3.ExecuteNonQuery();
									bd.cnn.Close();
									string cmdText4 = "select stock_neuf, prix_ht from article where id = @a";
									SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
									sqlCommand4.Parameters.Add("@a", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
									SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand4);
									DataTable dataTable = new DataTable();
									sqlDataAdapter.Fill(dataTable);
									bool flag7 = dataTable.Rows.Count != 0;
									if (flag7)
									{
										double num3 = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]) - this.select_qt_article(this.dataGridView2.Rows[i].Cells[5].Value.ToString(), this.id_reception);
										double num4 = Convert.ToDouble(dataTable.Rows[0].ItemArray[1]) * num3 + this.select_qt_article(this.dataGridView2.Rows[i].Cells[5].Value.ToString(), this.id_reception) * Convert.ToDouble(this.dataGridView2.Rows[i].Cells[3].Value.ToString());
										num4 /= Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
										num4 = Math.Round(num4, 3);
										bool flag8 = num3 <= 0.0 | Convert.ToDouble(dataTable.Rows[0].ItemArray[1]) <= 0.0;
										if (flag8)
										{
											string cmdText5 = "update article set prix_ht = @p where id = @i";
											SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
											sqlCommand5.Parameters.Add("@p", SqlDbType.Real).Value = Convert.ToDouble(this.dataGridView2.Rows[i].Cells[3].Value.ToString());
											sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
											bd.ouverture_bd(bd.cnn);
											sqlCommand5.ExecuteNonQuery();
											bd.cnn.Close();
										}
										else
										{
											string cmdText6 = "update article set prix_ht = @p where id = @i";
											SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
											sqlCommand6.Parameters.Add("@p", SqlDbType.Real).Value = num4;
											sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
											bd.ouverture_bd(bd.cnn);
											sqlCommand6.ExecuteNonQuery();
											bd.cnn.Close();
										}
										string cmdText7 = "select  tva, prix_ht, stock_neuf,  stock_use, stock_rebute from article where id = @i";
										SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
										sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
										SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand7);
										DataTable dataTable2 = new DataTable();
										sqlDataAdapter2.Fill(dataTable2);
										string cmdText8 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
										SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
										sqlCommand8.Parameters.Add("@i1", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
										sqlCommand8.Parameters.Add("@i2", SqlDbType.Real).Value = dataTable2.Rows[0].ItemArray[0].ToString();
										sqlCommand8.Parameters.Add("@i3", SqlDbType.Real).Value = dataTable2.Rows[0].ItemArray[1].ToString();
										sqlCommand8.Parameters.Add("@i4", SqlDbType.Real).Value = dataTable2.Rows[0].ItemArray[2].ToString();
										sqlCommand8.Parameters.Add("@i5", SqlDbType.Real).Value = dataTable2.Rows[0].ItemArray[3].ToString();
										sqlCommand8.Parameters.Add("@i6", SqlDbType.Real).Value = dataTable2.Rows[0].ItemArray[4].ToString();
										sqlCommand8.Parameters.Add("@i7", SqlDbType.Date).Value = DateTime.Today;
										bd.ouverture_bd(bd.cnn);
										sqlCommand8.ExecuteNonQuery();
										bd.cnn.Close();
									}
								}
							}
							MessageBox.Show("Création d'un bon de livraison avec succés");
							this.pictureBox3_Click(sender, e);
							this.remplissage_tableau(0);
							this.TextBox1.Clear();
						}
						else
						{
							MessageBox.Show("Erreur : Format de la colonne remise est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Format de la colonne prix est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Format de la colonne quantité livrée est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Tableau des articles est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00095558 File Offset: 0x00093758
		private double select_qt_article(string id_ar, string id_rc)
		{
			double result = 0.0;
			bd bd = new bd();
			string cmdText = "select sum(qt_recu) from reception_article where id_article = @a1 and id_reception = @a2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a1", SqlDbType.Int).Value = id_ar;
			sqlCommand.Parameters.Add("@a2", SqlDbType.Int).Value = id_rc;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
			}
			return result;
		}

		// Token: 0x040004C0 RID: 1216
		private static int row_act;

		// Token: 0x040004C1 RID: 1217
		private string id_reception;
	}
}
