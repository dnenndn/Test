using System;
using System.Collections.Generic;
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
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200003F RID: 63
	public partial class commande_annule : Form
	{
		// Token: 0x060002B9 RID: 697 RVA: 0x000730B4 File Offset: 0x000712B4
		public commande_annule()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.article_formatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radDateTimePicker1.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
			this.radDateTimePicker2.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00073198 File Offset: 0x00071398
		private void commande_annule_Load(object sender, EventArgs e)
		{
			design.design_datagridview(this.dataGridView2);
			this.radPanel2.Hide();
			this.radGridView1.Size = new Size(1095, 480);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00073230 File Offset: 0x00071430
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

		// Token: 0x060002BC RID: 700 RVA: 0x000732C8 File Offset: 0x000714C8
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(52, 152, 219), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
			bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 8;
			if (flag3)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
				radButtonElement3.Text = "Retourner en attente";
				radButtonElement3.TextAlignment = ContentAlignment.MiddleCenter;
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement3.ForeColor = Color.White;
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000734F8 File Offset: 0x000716F8
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select commande.id, date_commande, heure_commande, createur,  fournisseur.nom, n_commande from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where statut = @i and date_commande between @d1 and @d2";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 5;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
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
						dataTable.Rows[i].ItemArray[5].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
					this.radGridView1.Rows[i].Cells[6].Value = "Afficher";
					this.radGridView1.Rows[i].Cells[7].Value = "Historique Modification";
				}
				bool flag2 = UserSession.CurrentUser.Statut != "Administrateur" & UserSession.CurrentUser.Statut != "Responsable Méthode" & UserSession.CurrentUser.Statut != "Responsable Achat";
				if (flag2)
				{
					this.radGridView1.Columns[6].IsVisible = false;
					this.radGridView1.Columns[7].IsVisible = false;
					this.radGridView1.Columns[8].IsVisible = false;
				}
				bool flag3 = UserSession.CurrentUser.Statut != "Responsable Achat";
				if (flag3)
				{
					this.radGridView1.Columns[8].IsVisible = false;
				}
			}
			bool flag4 = this.radGridView1.Rows.Count != 0;
			if (flag4)
			{
				bool flag5 = o == 0;
				if (flag5)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag6 = o == 1;
				if (flag6)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag7 = o == 2;
				if (flag7)
				{
					this.radGridView1.Rows[commande_annule.row_act].IsCurrent = true;
				}
				bool flag8 = o == 3;
				if (flag8)
				{
					bool flag9 = commande_annule.row_act != 0;
					if (flag9)
					{
						this.radGridView1.Rows[commande_annule.row_act - 1].IsCurrent = true;
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
			this.LoadArticle();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00073964 File Offset: 0x00071B64
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 6;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					commande_encour.id_commande = text;
					commande_encour.nom_fournisseur = this.radGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
					bon_commande_encour bon_commande_encour = new bon_commande_encour();
					bon_commande_encour.Show();
				}
				bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
				if (flag3)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					commande_annule.id_historique = value;
					this.liste_id.Clear();
					this.id_pos = 0;
					bd bd = new bd();
					string cmdText = "select id from commande_modification_base where id_commande = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag4 = dataTable.Rows.Count != 0;
					if (flag4)
					{
						for (int i = 0; i < dataTable.Rows.Count; i++)
						{
							this.liste_id.Add(dataTable.Rows[i].ItemArray[0].ToString());
						}
					}
					this.afficher_modification(0);
					this.label9.Text = (this.id_pos + 1).ToString() + " Sur " + this.liste_id.Count.ToString();
					this.radGridView1.Size = new Size(1095, 245);
					this.radPanel2.Show();
				}
				bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 8;
				if (flag5)
				{
					string value2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					commande_annule.row_act = e.RowIndex;
					bd bd2 = new bd();
					DialogResult dialogResult = MessageBox.Show("Vous voulez Retourner en attente cette commande ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag6 = dialogResult == DialogResult.Yes;
					if (flag6)
					{
						string cmdText2 = "update commande set statut = @d where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd2.cnn.Close();
						this.radPanel2.Hide();
						this.radGridView1.Size = new Size(1095, 480);
						this.remplissage_tableau(3);
					}
				}
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00073CC0 File Offset: 0x00071EC0
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_commande, article.code_article,article.designation, qt_commande, commande_article.prix_ht, commande_article.remise  from commande_article inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join commande on commande_article.id_commande = commande.id where commande.statut = @d and commande.date_commande between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 5;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
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
				bool flag2 = UserSession.CurrentUser.Statut != "Administrateur" & UserSession.CurrentUser.Statut != "Responsable Méthode" & UserSession.CurrentUser.Statut != "Responsable Achat";
				if (flag2)
				{
					gridViewTemplate.Columns[4].IsVisible = false;
					gridViewTemplate.Columns[5].IsVisible = false;
				}
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00074213 File Offset: 0x00072413
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.radPanel2.Hide();
			this.radGridView1.Size = new Size(1095, 480);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00074240 File Offset: 0x00072440
		private void afficher_modification(int p)
		{
			this.dataGridView2.Rows.Clear();
			bool flag = p == 0;
			if (flag)
			{
				this.label2.Text = "Créer le :";
				this.label3.Text = "Créer par :";
				this.label5.Text = commande_annule.id_historique;
			}
			else
			{
				this.label2.Text = "Modifié le :";
				this.label3.Text = "Modifié par :";
				this.label5.Text = commande_annule.id_historique;
			}
			bd bd = new bd();
			string cmdText = "select modifier_par, date_modification, heure_modification from commande_modification_base where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.liste_id[p];
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.label6.Text = fonction.Mid(dataTable.Rows[0].ItemArray[1].ToString(), 1, 10) + " à " + dataTable.Rows[0].ItemArray[2].ToString() + " H";
			this.label7.Text = (this.select_utilisateur(dataTable.Rows[0].ItemArray[0].ToString() ?? "") ?? "");
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

		// Token: 0x060002C2 RID: 706 RVA: 0x000744FC File Offset: 0x000726FC
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

		// Token: 0x060002C3 RID: 707 RVA: 0x00074598 File Offset: 0x00072798
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

		// Token: 0x060002C4 RID: 708 RVA: 0x00074634 File Offset: 0x00072834
		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.DeleteSpace(this.TextBox1.Text) != "";
				if (flag2)
				{
					for (int i = 0; i < this.radGridView1.Rows.Count; i++)
					{
						int num = 0;
						bool flag3 = this.radGridView1.Templates.Count != 0;
						if (flag3)
						{
							bool flag4 = this.radGridView1.Templates[0].RowCount != 0;
							if (flag4)
							{
								for (int j = 0; j < this.radGridView1.Rows[i].ChildRows.Count; j++)
								{
									bool flag5 = Convert.ToString(this.radGridView1.Rows[i].ChildRows[j].Cells[2].Value).ToUpper().Contains(this.TextBox1.Text.ToUpper());
									if (flag5)
									{
										num = 1;
									}
								}
							}
						}
						bool flag6 = num == 0;
						if (flag6)
						{
							this.radGridView1.Rows[i].IsVisible = false;
						}
						else
						{
							this.radGridView1.Rows[i].IsVisible = true;
						}
					}
					this.radGridView1.MasterTemplate.ExpandAll();
				}
				else
				{
					this.radGridView1.MasterTemplate.CollapseAll();
					for (int k = 0; k < this.radGridView1.Rows.Count; k++)
					{
						this.radGridView1.Rows[k].IsVisible = true;
					}
				}
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0007482C File Offset: 0x00072A2C
		private void article_formatting(object sender, CellFormattingEventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "";
			if (flag)
			{
				bool flag2 = e.CellElement.ViewTemplate.Parent != null;
				if (flag2)
				{
					string text = Convert.ToString(e.CellElement.RowInfo.Cells["Column3"].Value);
					bool flag3 = text.ToUpper().Contains(this.TextBox1.Text.ToUpper());
					if (flag3)
					{
						e.CellElement.DrawFill = true;
						e.CellElement.GradientStyle = 0;
						e.CellElement.BackColor = Color.Goldenrod;
					}
				}
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x040003A7 RID: 935
		private static int row_act;

		// Token: 0x040003A8 RID: 936
		public static string id_commande;

		// Token: 0x040003A9 RID: 937
		public static string nom_fournisseur;

		// Token: 0x040003AA RID: 938
		public static string id_historique;

		// Token: 0x040003AB RID: 939
		private List<string> liste_id = new List<string>();

		// Token: 0x040003AC RID: 940
		private int id_pos;
	}
}
