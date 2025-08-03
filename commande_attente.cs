using System;
using System.Collections.Generic;
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
	// Token: 0x02000041 RID: 65
	public partial class commande_attente : Form
	{
		// Token: 0x060002D6 RID: 726 RVA: 0x00078AC0 File Offset: 0x00076CC0
		public commande_attente()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			commande_attente.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			commande_attente.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			commande_attente.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			commande_attente.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.dataGridView1.CellDoubleClick += this.DataGridView1_CellDoubleClick;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00078B70 File Offset: 0x00076D70
		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				commande_attente.id_art = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
				commande_vr_prix commande_vr_prix = new commande_vr_prix();
				commande_vr_prix.Show();
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00078BF0 File Offset: 0x00076DF0
		private void commande_attente_Load(object sender, EventArgs e)
		{
			this.label10.Text = "";
			design.design_datagridview(this.dataGridView1);
			design.design_datagridview(this.dataGridView2);
			commande_attente.radPanel1.Hide();
			this.radPanel2.Hide();
			commande_attente.radGridView1.Size = new Size(1095, 510);
			this.guna2Button2.Hide();
			this.guna2Button3.Hide();
			commande_attente.remplissage_tableau(0);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00078C78 File Offset: 0x00076E78
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

		// Token: 0x060002DA RID: 730 RVA: 0x00078D10 File Offset: 0x00076F10
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(52, 152, 219), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 8;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
			bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 9;
			if (flag3)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement3.ForeColor = Color.White;
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00078F28 File Offset: 0x00077128
		public static void remplissage_tableau(int o)
		{
			commande_attente.radGridView1.Rows.Clear();
			commande_attente.radGridView1.AllowDragToGroup = false;
			commande_attente.radGridView1.AllowAddNewRow = false;
			commande_attente.radGridView1.EnablePaging = true;
			commande_attente.radGridView1.PageSize = 14;
			commande_attente.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			commande_attente.radGridView1.EnableSorting = true;
			string cmdText = "select commande.id, date_commande, heure_commande, createur,  fournisseur.nom, urgence, n_commande from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where statut = @i";
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
					commande_attente.radGridView1.Rows.Add(new object[]
					{
						text,
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						commande_attente.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
					commande_attente.radGridView1.Rows[i].Cells[7].Value = "Afficher";
					commande_attente.radGridView1.Rows[i].Cells[8].Value = "Historique Modification";
					commande_attente.radGridView1.Rows[i].Cells[9].Value = "Annuler";
					commande_attente.radGridView1.Rows[i].Cells[10].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				}
				bool flag4 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Administrateur";
				if (flag4)
				{
					commande_attente.radGridView1.Columns[8].IsVisible = false;
					commande_attente.radGridView1.Columns[9].IsVisible = false;
				}
				bool flag5 = page_loginn.stat_user != "Responsable Achat";
				if (flag5)
				{
					commande_attente.radGridView1.Columns[9].IsVisible = false;
					commande_attente.radGridView1.Columns[10].IsVisible = false;
				}
			}
			bool flag6 = commande_attente.radGridView1.Rows.Count != 0;
			if (flag6)
			{
				bool flag7 = o == 0;
				if (flag7)
				{
					commande_attente.radGridView1.MasterTemplate.MoveToFirstPage();
					commande_attente.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag8 = o == 1;
				if (flag8)
				{
					commande_attente.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag9 = o == 2;
				if (flag9)
				{
					commande_attente.radGridView1.Rows[commande_attente.row_act].IsCurrent = true;
				}
				bool flag10 = o == 3;
				if (flag10)
				{
					bool flag11 = commande_attente.row_act != 0;
					if (flag11)
					{
						commande_attente.radGridView1.Rows[commande_attente.row_act - 1].IsCurrent = true;
					}
					else
					{
						commande_attente.radGridView1.MasterTemplate.MoveToFirstPage();
						commande_attente.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			commande_attente.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			commande_attente.radGridView1.Templates.Clear();
			commande_attente.LoadArticle();
			commande_attente.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000793F0 File Offset: 0x000775F0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = commande_attente.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						string value = commande_attente.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						commande_attente.id_commande = value;
						string cmdText = "select id from fournisseur where nom = @n";
						bd bd = new bd();
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = commande_attente.radGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						this.id_fournisseur = dataTable.Rows[0].ItemArray[0].ToString();
						commande_attente.row_act = e.RowIndex;
						this.radPanel2.Hide();
						commande_attente.radPanel1.Show();
						commande_attente.radGridView1.Size = new Size(1095, 275);
						this.dataGridView1.Rows.Clear();
						string cmdText2 = "select id_da_article, article.code_article, article.designation, qt_commande, commande_article.prix_ht, remise, commande_article.id,da_article.motif  from commande_article inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id where id_commande = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						string cmdText3 = "select urgence, fodec from commande where id = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							bool flag5 = dataTable3.Rows[0].ItemArray[0].ToString() == "1";
							if (flag5)
							{
								this.radRadioButton1.IsChecked = true;
							}
							bool flag6 = dataTable3.Rows[0].ItemArray[0].ToString() == "2";
							if (flag6)
							{
								this.radRadioButton2.IsChecked = true;
							}
							bool flag7 = dataTable3.Rows[0].ItemArray[0].ToString() == "3";
							if (flag7)
							{
								this.radRadioButton3.IsChecked = true;
							}
							bool flag8 = dataTable3.Rows[0].ItemArray[1].ToString() == "1";
							if (flag8)
							{
								this.radRadioButton6.IsChecked = true;
							}
							bool flag9 = dataTable3.Rows[0].ItemArray[1].ToString() == "0";
							if (flag9)
							{
								this.radRadioButton5.IsChecked = true;
							}
							for (int i = 0; i < dataTable2.Rows.Count; i++)
							{
								this.dataGridView1.Rows.Add(new object[]
								{
									dataTable2.Rows[i].ItemArray[6].ToString(),
									dataTable2.Rows[i].ItemArray[0].ToString(),
									dataTable2.Rows[i].ItemArray[1].ToString(),
									dataTable2.Rows[i].ItemArray[2].ToString(),
									dataTable2.Rows[i].ItemArray[3].ToString(),
									dataTable2.Rows[i].ItemArray[4].ToString(),
									dataTable2.Rows[i].ItemArray[5].ToString(),
									dataTable2.Rows[i].ItemArray[3].ToString()
								});
								double num = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(this.dataGridView1.Rows[i].Cells[5].Value);
								num -= num * Convert.ToDouble(this.dataGridView1.Rows[i].Cells[6].Value) / 100.0;
								this.dataGridView1.Rows[i].Cells[8].Value = num.ToString("0.000");
								this.dataGridView1.Rows[i].Cells[9].Value = Convert.ToString(dataTable2.Rows[i].ItemArray[7]);
								this.dataGridView1.Rows[i].Cells[10].Value = dataTable2.Rows[i].ItemArray[4].ToString();
								this.dataGridView1.Rows[i].Cells[11].Value = dataTable2.Rows[i].ItemArray[5].ToString();
								string cmdText4 = "select equipement.designation from da_article_equipement inner join da_article on da_article_equipement.id_da = da_article.id_da inner join equipement on da_article_equipement.id_equipement = equipement.id where da_article.id = @i2";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag10 = dataTable4.Rows.Count != 0;
								if (flag10)
								{
									string text = "";
									for (int j = 0; j < dataTable4.Rows.Count; j++)
									{
										bool flag11 = j == 0;
										if (flag11)
										{
											text = dataTable4.Rows[0].ItemArray[0].ToString();
										}
										else
										{
											text = text + " - " + dataTable4.Rows[j].ItemArray[0].ToString();
										}
									}
									this.dataGridView1.Rows[i].Cells[12].Value = text;
								}
							}
							double num2 = 0.0;
							for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
							{
								num2 += Convert.ToDouble(this.dataGridView1.Rows[k].Cells[8].Value);
							}
							this.label10.Text = num2.ToString("0.000");
						}
						bool flag12 = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode";
						if (flag12)
						{
							this.guna2Button2.Show();
							this.guna2Button3.Show();
						}
						bool flag13 = page_loginn.stat_user == "Responsable Achat";
						if (flag13)
						{
							this.guna2Button2.Show();
						}
						bool flag14 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Administrateur";
						if (flag14)
						{
							this.dataGridView1.Columns[5].Visible = false;
							this.dataGridView1.Columns[6].Visible = false;
							this.dataGridView1.Columns[8].Visible = false;
							this.label11.Hide();
							this.label10.Hide();
						}
					}
				}
				bool flag15 = e.RowIndex >= 0 && e.ColumnIndex == 8;
				if (flag15)
				{
					commande_attente.radGridView1.Size = new Size(684, commande_attente.radGridView1.Size.Height);
					string value2 = commande_attente.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					commande_attente.id_historique = value2;
					this.liste_id.Clear();
					this.id_pos = 0;
					bd bd2 = new bd();
					string cmdText5 = "select id from commande_modification_base where id_commande = @i";
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
					sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
					DataTable dataTable5 = new DataTable();
					sqlDataAdapter5.Fill(dataTable5);
					bool flag16 = dataTable5.Rows.Count != 0;
					if (flag16)
					{
						for (int l = 0; l < dataTable5.Rows.Count; l++)
						{
							this.liste_id.Add(dataTable5.Rows[l].ItemArray[0].ToString());
						}
					}
					this.afficher_modification(0);
					this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
					this.radPanel2.Show();
				}
				bool flag17 = e.RowIndex >= 0 && e.ColumnIndex == 9;
				if (flag17)
				{
					string value3 = commande_attente.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					commande_attente.row_act = e.RowIndex;
					bd bd3 = new bd();
					DialogResult dialogResult = MessageBox.Show("Vous voulez annuler cette commande ?", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag18 = dialogResult == DialogResult.Yes;
					if (flag18)
					{
						string cmdText6 = "update commande set statut = @d where id = @i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd3.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value3;
						sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 5;
						bd3.ouverture_bd(bd3.cnn);
						sqlCommand6.ExecuteNonQuery();
						bd3.cnn.Close();
						commande_attente.remplissage_tableau(3);
					}
				}
				bool flag19 = e.RowIndex >= 0 && e.ColumnIndex == 10;
				if (flag19)
				{
					string id_cmnd = commande_attente.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					commande_attente.row_act = e.RowIndex;
					bd bd4 = new bd();
					DialogResult dialogResult2 = MessageBox.Show("Vous voulez supprimer cette commande ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag20 = dialogResult2 == DialogResult.Yes;
					if (flag20)
					{
						this.delete_commande(id_cmnd);
						commande_attente.remplissage_tableau(3);
					}
				}
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00079F6C File Offset: 0x0007816C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			commande_attente.radPanel1.Hide();
			bool flag = !this.radPanel2.Visible;
			if (flag)
			{
				commande_attente.radGridView1.Size = new Size(1095, 510);
			}
			else
			{
				commande_attente.radGridView1.Size = new Size(684, 510);
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00079FD4 File Offset: 0x000781D4
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bd bd = new bd();
				int num = 1;
				bool flag2 = num == 1;
				if (flag2)
				{
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						double num2 = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[7].Value) - Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value);
						string cmdText = "update commande_article set qt_commande = @h, prix_ht = @h1, remise = @h2 where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@h", SqlDbType.Real).Value = this.dataGridView1.Rows[i].Cells[4].Value;
						sqlCommand.Parameters.Add("@h1", SqlDbType.Real).Value = this.dataGridView1.Rows[i].Cells[5].Value;
						sqlCommand.Parameters.Add("@h2", SqlDbType.Real).Value = this.dataGridView1.Rows[i].Cells[6].Value;
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView1.Rows[i].Cells[0].Value;
						string cmdText2 = "update da_article set qt_restant = qt_restant + @s where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@s", SqlDbType.Real).Value = num2;
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView1.Rows[i].Cells[1].Value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						bool flag3 = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value) == 0.0;
						if (flag3)
						{
							string cmdText3 = "delete commande_article where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView1.Rows[i].Cells[0].Value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					this.da_cloturer(this.id_fournisseur);
					this.tester_commande_supprimer(commande_attente.id_commande);
					string cmdText4 = "update commande set urgence = @u, fodec = @v where id = @i";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					string value = "1";
					int num3 = 0;
					bool isChecked = this.radRadioButton6.IsChecked;
					if (isChecked)
					{
						num3 = 1;
					}
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
					sqlCommand4.Parameters.Add("@u", SqlDbType.Int).Value = value;
					sqlCommand4.Parameters.Add("@v", SqlDbType.Int).Value = num3;
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = commande_attente.id_commande;
					bd.ouverture_bd(bd.cnn);
					sqlCommand4.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					this.radPanel2.Hide();
					this.guna2Button1_Click(sender, e);
					commande_attente.remplissage_tableau(2);
				}
				else
				{
					MessageBox.Show("Erreur : Quantité commandée est supérieure à la quantité demandée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0007A418 File Offset: 0x00078618
		private int test_quantite()
		{
			int result = 1;
			bd bd = new bd();
			for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
			{
				string cmdText = "select qt from da_article where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView1.Rows[i].Cells[1].Value;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value) > Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0007A510 File Offset: 0x00078710
		private void da_cloturer(string i_fourn)
		{
			bd bd = new bd();
			string cmdText = "select distinct  demande_achat.id from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and fournisseur.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 10;
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
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 10;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						string cmdText3 = "update demande_achat set statut = @i where id = @v";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = 1;
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0007A724 File Offset: 0x00078924
		private void tester_commande_supprimer(string h)
		{
			int num = 1;
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[0].Value) != 0.0;
					if (flag2)
					{
						num = 0;
					}
				}
			}
			bool flag3 = num == 1;
			if (flag3)
			{
				bd bd = new bd();
				string cmdText = "delete commande where id = @h";
				SqlCommand sqlCommand = new SqlCommand(cmdText);
				sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = h;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
			else
			{
				this.save_modification();
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0007A818 File Offset: 0x00078A18
		private void save_modification()
		{
			bool flag = this.test_save_modification() == 1;
			if (flag)
			{
				bd bd = new bd();
				bool flag2 = this.dataGridView1.Rows.Count != 0;
				if (flag2)
				{
					string cmdText = "insert into commande_modification_base (id_commande, modifier_par, date_modification, heure_modification) values (@i1, @i2, @i3, @i4)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = commande_attente.id_commande;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
					sqlCommand.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
					sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
					bd.ouverture_bd(bd.cnn);
					int num = (int)sqlCommand.ExecuteScalar();
					bd.cnn.Close();
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						bool flag3 = Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value) != 0.0;
						if (flag3)
						{
							string cmdText2 = "select id from article where code_article = @i1 and designation = @i2";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag4 = dataTable.Rows.Count != 0;
							if (flag4)
							{
								string cmdText3 = "insert into commande_modifier_article (id_modification,id_article, qt, prix_ht, remise) values (@i1, @i2, @i3, @i4, @i5)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value));
								sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.dataGridView1.Rows[i].Cells[5].Value));
								sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.dataGridView1.Rows[i].Cells[6].Value));
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
							}
						}
					}
				}
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0007ABC4 File Offset: 0x00078DC4
		private int test_save_modification()
		{
			int result = 0;
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					bool flag2 = Math.Abs(Convert.ToDouble(this.dataGridView1.Rows[i].Cells[4].Value)) != Convert.ToDouble(this.dataGridView1.Rows[i].Cells[7].Value) | Math.Abs(Convert.ToDouble(this.dataGridView1.Rows[i].Cells[5].Value)) != Convert.ToDouble(this.dataGridView1.Rows[i].Cells[10].Value) | Math.Abs(Convert.ToDouble(this.dataGridView1.Rows[i].Cells[6].Value)) != Convert.ToDouble(this.dataGridView1.Rows[i].Cells[11].Value);
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0007AD30 File Offset: 0x00078F30
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			signature_commande_attente signature_commande_attente = new signature_commande_attente();
			signature_commande_attente.Show();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0007AD4C File Offset: 0x00078F4C
		private void afficher_modification(int p)
		{
			this.dataGridView2.Rows.Clear();
			bool flag = p == 0;
			if (flag)
			{
				this.label2.Text = "Créer le :";
				this.label3.Text = "Créer par :";
				this.label5.Text = commande_attente.id_historique;
			}
			else
			{
				this.label2.Text = "Modifié le :";
				this.label3.Text = "Modifié par :";
				this.label5.Text = commande_attente.id_historique;
			}
			bd bd = new bd();
			string cmdText = "select modifier_par, date_modification, heure_modification from commande_modification_base where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.liste_id[p];
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.label6.Text = fonction.Mid(dataTable.Rows[0].ItemArray[1].ToString(), 1, 10) + " à " + dataTable.Rows[0].ItemArray[2].ToString() + " H";
			this.label7.Text = (commande_attente.select_utilisateur(dataTable.Rows[0].ItemArray[0].ToString() ?? "") ?? "");
			string cmdText2 = "select  article.code_article, article.designation, commande_modifier_article.qt, commande_modifier_article.prix_ht, commande_modifier_article.remise from commande_modifier_article inner join article on commande_modifier_article.id_article = article.id   where id_modification = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.liste_id[p];
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					this.dataGridView2.Rows.Add(new object[]
					{
						dataTable2.Rows[i].ItemArray[0].ToString(),
						dataTable2.Rows[i].ItemArray[1].ToString(),
						dataTable2.Rows[i].ItemArray[2].ToString(),
						dataTable2.Rows[i].ItemArray[3].ToString(),
						dataTable2.Rows[i].ItemArray[4].ToString()
					});
				}
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0007B004 File Offset: 0x00079204
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			bool flag = this.liste_id.Count != 0;
			if (flag)
			{
				bool flag2 = this.id_pos == this.liste_id.Count - 1;
				if (flag2)
				{
					this.id_pos = 0;
				}
				else
				{
					this.id_pos++;
				}
				this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
				this.afficher_modification(this.id_pos);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0007B0A0 File Offset: 0x000792A0
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			bool flag = this.liste_id.Count != 0;
			if (flag)
			{
				bool flag2 = this.id_pos == 0;
				if (flag2)
				{
					this.id_pos = this.liste_id.Count - 1;
				}
				else
				{
					this.id_pos--;
				}
				this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
				this.afficher_modification(this.id_pos);
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0007B13C File Offset: 0x0007933C
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.radPanel2.Hide();
			commande_attente.radGridView1.Size = new Size(1095, 510);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0007B168 File Offset: 0x00079368
		private void delete_commande(string id_cmnd)
		{
			bd bd = new bd();
			string cmdText = "delete commande where id = @i";
			string cmdText2 = "delete commande_article where id_commande = @i";
			string cmdText3 = "delete commande_modification_base where id_commande = @i";
			string cmdText4 = "select id from commande_modification_base where id_commande  = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			SqlCommand sqlCommand3 = new SqlCommand(cmdText4, bd.cnn);
			SqlCommand sqlCommand4 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText5 = "delete commande_modifier_article from commande where id_modification = @i";
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
					sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand5.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
			string cmdText6 = "select id_da_article, qt_commande from commande_article where id_commande = @i";
			SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
			sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = id_cmnd;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand6);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					string cmdText7 = "update da_article set qt_restant = qt_restant + @q where id = @i";
					SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
					sqlCommand7.Parameters.Add("@q", SqlDbType.Real).Value = Convert.ToDouble(dataTable2.Rows[j].ItemArray[1]);
					sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand7.ExecuteNonQuery();
					bd.cnn.Close();
					string cmdText8 = "select id_da from da_article where id = @i";
					SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
					sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0];
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand8);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						string cmdText9 = "update demande_achat set statut = @d where id = @i";
						SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
						sqlCommand9.Parameters.Add("@d", SqlDbType.Int).Value = 1;
						sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = dataTable3.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand9.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			sqlCommand2.ExecuteNonQuery();
			sqlCommand4.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0007B548 File Offset: 0x00079748
		private static void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, article.code_article,article.designation, qt_commande, commande_article.prix_ht, commande_article.remise  from commande_article inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join commande on commande_article.id_commande = commande.id where commande.statut = @d";
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
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.Columns["column6"].Width = 150;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				gridViewTemplate.Columns[4].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[5].HeaderText = "Remise";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				bool flag2 = page_loginn.stat_user != "Administrateur" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Responsable Achat";
				if (flag2)
				{
					gridViewTemplate.Columns[4].IsVisible = false;
					gridViewTemplate.Columns[5].IsVisible = false;
				}
				commande_attente.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(commande_attente.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(commande_attente.radGridView1.MasterTemplate.Columns[1].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				commande_attente.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x040003D6 RID: 982
		private static int row_act;

		// Token: 0x040003D7 RID: 983
		public static string id_commande;

		// Token: 0x040003D8 RID: 984
		public static string id_historique;

		// Token: 0x040003D9 RID: 985
		private string id_fournisseur;

		// Token: 0x040003DA RID: 986
		private List<string> liste_id = new List<string>();

		// Token: 0x040003DB RID: 987
		private int id_pos;

		// Token: 0x040003DC RID: 988
		public static string id_art;
	}
}
