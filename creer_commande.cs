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
	// Token: 0x02000055 RID: 85
	public partial class creer_commande : Form
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x000A6768 File Offset: 0x000A4968
		public creer_commande()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x000A6828 File Offset: 0x000A4A28
		private void creer_commande_Load(object sender, EventArgs e)
		{
			this.guna2Button1.Hide();
			this.guna2Button2.Hide();
			this.radGridView2.Hide();
			this.label10.Hide();
			this.panel3.Hide();
			this.TextBox1.Hide();
			this.label5.Hide();
			this.label6.Hide();
			this.panel2.Hide();
			this.label7.Hide();
			this.panel4.Hide();
			this.radCheckBox1.Checked = true;
			this.radCheckBox2.Checked = false;
			this.radGridView2.Rows.Clear();
			this.select_fournisseur();
			this.select_article();
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000A68F4 File Offset: 0x000A4AF4
		private void select_fournisseur()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select distinct fournisseur.id, fournisseur.nom from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and qt_restant > @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
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
						dataTable.Rows[i].ItemArray[1].ToString(),
						this.da_fournisseur(dataTable.Rows[i].ItemArray[0].ToString()),
						"Créer un bon de commande"
					});
				}
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000A6A44 File Offset: 0x000A4C44
		private int da_fournisseur(string s)
		{
			bd bd = new bd();
			string cmdText = "select distinct demande_achat.id from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and fournisseur.id = @i and qt_restant > @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = s;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			return dataTable.Rows.Count;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000A6AEC File Offset: 0x000A4CEC
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 3;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000A6BA8 File Offset: 0x000A4DA8
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Hide();
			this.guna2Button2.Hide();
			this.radGridView2.Hide();
			this.label5.Hide();
			this.label6.Hide();
			this.panel2.Hide();
			this.label7.Hide();
			this.panel4.Hide();
			this.label10.Hide();
			this.panel3.Hide();
			this.TextBox1.Hide();
			this.radGridView2.Rows.Clear();
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000A6C4C File Offset: 0x000A4E4C
		private void select_tableau_commande(string s)
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select  demande_achat.id, utilisateur.login, article.code_article, article.designation, qt_restant, article.prix_ht, fournisseur.remise_defaut, da_article.id, article.id from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id inner join utilisateur on demande_achat.demandeur = utilisateur.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and fournisseur.id = @i and qt_restant > @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = s;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = !this.radCheckBox1.Checked & this.radCheckBox2.Checked;
			if (flag)
			{
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag3 = this.test_devis_article(dataTable.Rows[i].ItemArray[8].ToString()) == 1;
						if (flag3)
						{
							string cmdText2 = "select dop_fini.prix_ht, dop_fini.remise from dop_fini inner join dop on dop_fini.id_dop = dop.id where dop_fini.id_article = @i1 and id_fournisseur = @i2 and dop.statut = @i3";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[8].ToString();
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = s;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag4 = dataTable2.Rows.Count != 0;
							if (flag4)
							{
								this.radGridView2.Rows.Add(new object[]
								{
									dataTable.Rows[i].ItemArray[0].ToString(),
									dataTable.Rows[i].ItemArray[1].ToString(),
									dataTable.Rows[i].ItemArray[2].ToString(),
									dataTable.Rows[i].ItemArray[3].ToString(),
									dataTable.Rows[i].ItemArray[4].ToString(),
									dataTable.Rows[i].ItemArray[4].ToString(),
									dataTable2.Rows[0].ItemArray[0].ToString(),
									dataTable2.Rows[0].ItemArray[1].ToString(),
									dataTable.Rows[i].ItemArray[7].ToString(),
									dataTable.Rows[i].ItemArray[8].ToString()
								});
							}
						}
					}
				}
			}
			bool flag5 = this.radCheckBox1.Checked & !this.radCheckBox2.Checked;
			if (flag5)
			{
				bool flag6 = dataTable.Rows.Count != 0;
				if (flag6)
				{
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						bool flag7 = this.test_devis_article(dataTable.Rows[j].ItemArray[8].ToString()) == 0;
						if (flag7)
						{
							this.radGridView2.Rows.Add(new object[]
							{
								dataTable.Rows[j].ItemArray[0].ToString(),
								dataTable.Rows[j].ItemArray[1].ToString(),
								dataTable.Rows[j].ItemArray[2].ToString(),
								dataTable.Rows[j].ItemArray[3].ToString(),
								dataTable.Rows[j].ItemArray[4].ToString(),
								dataTable.Rows[j].ItemArray[4].ToString(),
								dataTable.Rows[j].ItemArray[5].ToString(),
								dataTable.Rows[j].ItemArray[6].ToString(),
								dataTable.Rows[j].ItemArray[7].ToString(),
								dataTable.Rows[j].ItemArray[8].ToString()
							});
						}
					}
				}
			}
			bool flag8 = this.radCheckBox1.Checked & this.radCheckBox2.Checked;
			if (flag8)
			{
				bool flag9 = dataTable.Rows.Count != 0;
				if (flag9)
				{
					for (int k = 0; k < dataTable.Rows.Count; k++)
					{
						bool flag10 = this.test_devis_article(dataTable.Rows[k].ItemArray[8].ToString()) == 1;
						if (flag10)
						{
							string cmdText3 = "select dop_fini.prix_ht, dop_fini.remise from dop_fini inner join dop on dop_fini.id_dop = dop.id where dop_fini.id_article = @i1 and id_fournisseur = @i2 and dop.statut = @i3";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[k].ItemArray[8].ToString();
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = s;
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							bool flag11 = dataTable3.Rows.Count != 0;
							if (flag11)
							{
								this.radGridView2.Rows.Add(new object[]
								{
									dataTable.Rows[k].ItemArray[0].ToString(),
									dataTable.Rows[k].ItemArray[1].ToString(),
									dataTable.Rows[k].ItemArray[2].ToString(),
									dataTable.Rows[k].ItemArray[3].ToString(),
									dataTable.Rows[k].ItemArray[4].ToString(),
									dataTable.Rows[k].ItemArray[4].ToString(),
									dataTable3.Rows[0].ItemArray[0].ToString(),
									dataTable3.Rows[0].ItemArray[1].ToString(),
									dataTable.Rows[k].ItemArray[7].ToString(),
									dataTable.Rows[k].ItemArray[8].ToString()
								});
							}
						}
					}
				}
				bool flag12 = dataTable.Rows.Count != 0;
				if (flag12)
				{
					for (int l = 0; l < dataTable.Rows.Count; l++)
					{
						bool flag13 = this.test_devis_article(dataTable.Rows[l].ItemArray[8].ToString()) == 0;
						if (flag13)
						{
							this.radGridView2.Rows.Add(new object[]
							{
								dataTable.Rows[l].ItemArray[0].ToString(),
								dataTable.Rows[l].ItemArray[1].ToString(),
								dataTable.Rows[l].ItemArray[2].ToString(),
								dataTable.Rows[l].ItemArray[3].ToString(),
								dataTable.Rows[l].ItemArray[4].ToString(),
								dataTable.Rows[l].ItemArray[4].ToString(),
								dataTable.Rows[l].ItemArray[5].ToString(),
								dataTable.Rows[l].ItemArray[6].ToString(),
								dataTable.Rows[l].ItemArray[7].ToString(),
								dataTable.Rows[l].ItemArray[8].ToString()
							});
						}
					}
				}
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000A756C File Offset: 0x000A576C
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
						string s = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						this.radGridView2.Show();
						this.guna2Button1.Show();
						this.guna2Button2.Show();
						this.label10.Show();
						this.panel3.Show();
						this.TextBox1.Show();
						this.label7.Show();
						this.panel4.Show();
						this.label5.Show();
						this.label6.Show();
						this.panel2.Show();
						this.select_tableau_commande(s);
						this.id_fournisseur = s;
					}
				}
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x000A7688 File Offset: 0x000A5888
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.format_qt() == 1;
				if (flag2)
				{
					bool flag3 = this.format_prix() == 1;
					if (flag3)
					{
						bool flag4 = this.format_remise() == 1;
						if (flag4)
						{
							int num = 1;
							bool flag5 = num == 1;
							if (flag5)
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
								int num2 = 0;
								bool isChecked3 = this.radRadioButton6.IsChecked;
								if (isChecked3)
								{
									num2 = 1;
								}
								double num3 = 0.0;
								bd bd = new bd();
								int num4 = 0;
								bool isChecked4 = this.radRadioButton7.IsChecked;
								if (isChecked4)
								{
									num4 = 1;
								}
								int num5 = this.select_n_commande();
								string cmdText = "insert into commande (date_commande, heure_commande, createur, id_fournisseur, statut, personne_contacter, date_signature, urgence, fodec, n_commande) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10)SELECT CAST(scope_identity() AS int)";
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
								sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
								sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
								sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.id_fournisseur;
								sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = num4;
								sqlCommand.Parameters.Add("@i6", SqlDbType.VarChar).Value = Convert.ToString(this.TextBox1.Text);
								sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = DateTime.Today;
								sqlCommand.Parameters.Add("@i8", SqlDbType.VarChar).Value = value;
								sqlCommand.Parameters.Add("@i9", SqlDbType.Int).Value = num2;
								sqlCommand.Parameters.Add("@i10", SqlDbType.Int).Value = num5;
								bd.ouverture_bd(bd.cnn);
								int num6 = (int)sqlCommand.ExecuteScalar();
								bd.cnn.Close();
								for (int i = 0; i < this.radGridView2.Rows.Count; i++)
								{
									bool flag6 = Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value) > 0.0;
									if (flag6)
									{
										string cmdText2 = "update da_article set qt_restant = qt_restant - @f where id = @i ";
										SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
										sqlCommand2.Parameters.Add("@f", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value);
										sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[8].Value;
										string cmdText3 = "insert into commande_article (id_commande, id_da_article, qt_commande, prix_ht, remise) values (@v1, @v2, @v3, @v4, @v5)";
										SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
										sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = num6;
										sqlCommand3.Parameters.Add("@v2", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[8].Value;
										sqlCommand3.Parameters.Add("@v3", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value));
										sqlCommand3.Parameters.Add("@v4", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value));
										sqlCommand3.Parameters.Add("@v5", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value));
										bd.ouverture_bd(bd.cnn);
										sqlCommand2.ExecuteNonQuery();
										sqlCommand3.ExecuteNonQuery();
										bd.cnn.Close();
										num3 += Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value) * Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value);
										this.da_cloturer(this.id_fournisseur);
										string cmdText4 = "select id_article from da_article where id = @i";
										SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
										sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[8].Value;
										SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand4);
										DataTable dataTable = new DataTable();
										sqlDataAdapter.Fill(dataTable);
										string value2 = dataTable.Rows[0].ItemArray[0].ToString();
										this.creer_notif(num6.ToString(), Convert.ToInt32(value2), Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value), Convert.ToString(this.radGridView2.Rows[i].Cells[2].Value), num5);
									}
								}
								this.save_modification(num6);
								this.guna2Button1.Hide();
								this.guna2Button2.Hide();
								this.radGridView2.Hide();
								this.label10.Hide();
								this.panel3.Hide();
								this.TextBox1.Hide();
								this.label5.Hide();
								this.label6.Hide();
								this.panel2.Hide();
								this.panel3.Hide();
								this.label7.Hide();
								this.panel4.Hide();
								this.cloturer_dop();
								this.radGridView2.Rows.Clear();
								this.select_fournisseur();
								this.cree_notif_admin(num6, this.id_fournisseur, num3, num5);
								MessageBox.Show("Succés");
							}
							else
							{
								MessageBox.Show("Erreur : Vérifier que la quantité commandée doit être inférieure ou égale à la quantité demandée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : Vérifier le format des cellules remise", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Vérifier le format des cellules prix unitaire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier le format des cellules quantité commandées", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Le tableau des articles est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x000A7E28 File Offset: 0x000A6028
		private int format_qt()
		{
			fonction fonction = new fonction();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(this.radGridView2.Rows[i].Cells[5].Value.ToString());
					if (flag2)
					{
					}
				}
			}
			return 1;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000A7EC0 File Offset: 0x000A60C0
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
					bool flag2 = !fonction.is_reel(this.radGridView2.Rows[i].Cells[7].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000A7F54 File Offset: 0x000A6154
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
					bool flag2 = !fonction.is_reel(this.radGridView2.Rows[i].Cells[6].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000A7FE8 File Offset: 0x000A61E8
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
					bool flag2 = Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value.ToString()) > Convert.ToDouble(this.radGridView2.Rows[i].Cells[4].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000A80AC File Offset: 0x000A62AC
		private void da_cloturer(string i_fourn)
		{
			bd bd = new bd();
			string cmdText = "select distinct  demande_achat.id from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and fournisseur.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = i_fourn;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select da_article.id from da_article inner join demande_achat on da_article.id_da = demande_achat.id where id_da = @i1 and qt_restant <> @i2 and demande_achat.statut = @i3";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = 0;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 1;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count == 0;
					if (flag2)
					{
						string cmdText3 = "update demande_achat set statut = @i where id = @v";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = 10;
						string cmdText4 = "insert into da_cloturer (id_da, cloturer_par, date_cloture, heure_cloture) values (@i1, @i2, @i3, @i4)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
						sqlCommand4.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
						sqlCommand4.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000A8384 File Offset: 0x000A6584
		private void save_modification(int id_c)
		{
			bd bd = new bd();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				string cmdText = "insert into commande_modification_base (id_commande, modifier_par, date_modification, heure_modification) values (@i1, @i2, @i3, @i4)SELECT CAST(scope_identity() AS int)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_c;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
				sqlCommand.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
				sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
				bd.ouverture_bd(bd.cnn);
				int num = (int)sqlCommand.ExecuteScalar();
				bd.cnn.Close();
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value) != 0.0;
					if (flag2)
					{
						string cmdText2 = "select id from article where code_article = @i1 and designation = @i2";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.radGridView2.Rows[i].Cells[2].Value.ToString();
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.radGridView2.Rows[i].Cells[3].Value.ToString();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							string cmdText3 = "insert into commande_modifier_article (id_modification,id_article, qt, prix_ht, remise) values (@i1, @i2, @i3, @i4, @i5)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.radGridView2.Rows[i].Cells[5].Value));
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value));
							sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value));
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000A8718 File Offset: 0x000A6918
		private int test_devis_article(string id_art)
		{
			int result = 0;
			string cmdText = "select dop_fini.id from dop_fini inner join dop on dop_fini.id_dop = dop.id where id_article = @i1 and dop.statut = @i2 and fini = @i2";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_art;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000A87B0 File Offset: 0x000A69B0
		private void cloturer_dop()
		{
			bd bd = new bd();
			string cmdText = " select id from dop where statut = @i";
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
					int num = 0;
					for (int j = 0; j < this.radGridView2.Rows.Count; j++)
					{
						bool flag2 = Convert.ToDouble(this.radGridView2.Rows[j].Cells[5].Value) > 0.0;
						if (flag2)
						{
							string cmdText2 = "update dop_fini set fini = @i where id_dop = @i2 and id_fournisseur = @i3 and id_article =@i4";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;
							sqlCommand2.Parameters.Add("@o", SqlDbType.Int).Value = 0;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.id_fournisseur;
							sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[9].Value.ToString();
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					string cmdText3 = "select id from dop_fini where id_dop = @i2 and fini = @o";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@o", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						num = 1;
					}
					bool flag4 = num == 0;
					if (flag4)
					{
						string cmdText4 = "select id from dop_fini where id_dop = @i2";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag5 = dataTable3.Rows.Count != 0;
						if (flag5)
						{
							string cmdText5 = "update dop set statut = @i where id = @v";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000A8B6C File Offset: 0x000A6D6C
		private void select_article()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select distinct article.designation, article.id from da_article inner join article on da_article.id_article = article.id inner join demande_achat on da_article.id_da = demande_achat.id where demande_achat.statut = @d and article.deleted = @i and qt_restant <> @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
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

		// Token: 0x060003FD RID: 1021 RVA: 0x000A8C90 File Offset: 0x000A6E90
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				string cmdText = "select distinct fournisseur.nom, fournisseur.id from fournisseur where fournisseur.deleted = @d and fournisseur.id not in (select id_fournisseur from tableau_article_fournisseur where id_article = @i)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
						this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
					}
				}
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000A8DE0 File Offset: 0x000A6FE0
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "" & this.radDropDownList6.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "insert into tableau_article_fournisseur (id_article, id_fournisseur) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Enregistrement avec succés");
				this.guna2Button1.Hide();
				this.guna2Button2.Hide();
				this.radGridView2.Hide();
				this.label10.Hide();
				this.panel3.Hide();
				this.TextBox1.Hide();
				this.label5.Hide();
				this.label6.Hide();
				this.panel2.Hide();
				this.radGridView2.Rows.Clear();
				this.select_article();
				this.select_fournisseur();
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000A8F58 File Offset: 0x000A7158
		private void creer_notif(string id_c, int id_art, double prix_article, string code_article, int n_commande)
		{
			bd bd = new bd();
			string cmdText = "select top 1 commande_article.prix_ht from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where statut <> @d1 and statut <> @d2 and id_article = @i1 order by date_signature desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Int).Value = 5;
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_art;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				bool flag2 = prix_article > num;
				if (flag2)
				{
					double value = (prix_article - num) / num * 100.0;
					value = Math.Round(value, 2);
					string cmdText2 = "select id from utilisateur where fonction = @i1 or fonction = @i2 or fonction = @i3";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Responsable Méthode";
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Responsable Achat";
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Administrateur";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						for (int i = 0; i < dataTable2.Rows.Count; i++)
						{
							string cmdText3 = "insert into notification (id_n, type, id_utilisateur, description, vue, date_creation) values (@v1, @v2, @v3, @v4, @v5, @v6)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = id_c;
							sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = "Variation Commande";
							sqlCommand3.Parameters.Add("@v3", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
							sqlCommand3.Parameters.Add("@v4", SqlDbType.VarChar).Value = string.Concat(new string[]
							{
								"Une variation de prix de l'article ",
								code_article,
								" pour la commande N° ",
								n_commande.ToString(),
								"  par rapport à la dernière commande confirmée de : ",
								value.ToString(),
								" %"
							});
							sqlCommand3.Parameters.Add("@v5", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@v6", SqlDbType.Date).Value = DateTime.Today;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000A9258 File Offset: 0x000A7458
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
						"Commande N° ",
						n_commande.ToString(),
						" de fournisseur ",
						text,
						", de Montant Tot : ",
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

		// Token: 0x06000401 RID: 1025 RVA: 0x000A94CC File Offset: 0x000A76CC
		private int select_n_commande()
		{
			int result = 1;
			string cmdText = "select max(n_commande) from commande";
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

		// Token: 0x04000562 RID: 1378
		private string id_fournisseur;
	}
}
