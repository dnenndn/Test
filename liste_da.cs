using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200013B RID: 315
	public partial class liste_da : Form
	{
		// Token: 0x06000E1C RID: 3612 RVA: 0x00227070 File Offset: 0x00225270
		public liste_da()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			liste_da.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			liste_da.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			liste_da.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			liste_da.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.da_systeme_formatting);
			liste_da.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00227111 File Offset: 0x00225311
		private void liste_da_Load(object sender, EventArgs e)
		{
			liste_da.remplissage_tableau(0);
			this.action_vu();
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00227124 File Offset: 0x00225324
		public static void remplissage_tableau(int o)
		{
			liste_da.radGridView1.Rows.Clear();
			liste_da.radGridView1.AllowDragToGroup = false;
			liste_da.radGridView1.AllowAddNewRow = false;
			liste_da.radGridView1.EnablePaging = true;
			liste_da.radGridView1.PageSize = 14;
			liste_da.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bool flag = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				string cmdText = "select id, date_da, heure_da, createur, demandeur, delai, periode, statut from demande_achat where statut = @i";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Magasin";
				if (flag2)
				{
					liste_da.radGridView1.Columns[6].IsVisible = false;
					liste_da.radGridView1.Columns[7].IsVisible = false;
					liste_da.radGridView1.Columns[8].IsVisible = false;
					liste_da.radGridView1.Columns[9].IsVisible = false;
					liste_da.radGridView1.Columns[11].IsVisible = false;
					liste_da.radGridView1.Columns[12].IsVisible = false;
				}
				bool flag3 = page_loginn.stat_user == "Responsable Magasin";
				if (flag3)
				{
					liste_da.radGridView1.Columns[12].IsVisible = true;
				}
				bool flag4 = dataTable.Rows.Count != 0;
				if (flag4)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						liste_da.radGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
							dataTable.Rows[i].ItemArray[2].ToString(),
							liste_da.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
							liste_da.select_utilisateur(dataTable.Rows[i].ItemArray[4].ToString()),
							dataTable.Rows[i].ItemArray[5].ToString() + " " + dataTable.Rows[i].ItemArray[6].ToString()
						});
						liste_da.radGridView1.Rows[i].Cells[6].Value = "Confirmer";
						liste_da.radGridView1.Rows[i].Cells[7].Value = "Refuser";
						liste_da.radGridView1.Rows[i].Cells[8].Value = "Vers l'administrateur";
						liste_da.radGridView1.Rows[i].Cells[9].Value = "Reporter";
						liste_da.radGridView1.Rows[i].Cells[10].Value = Resources.icons8_visible_96;
						liste_da.radGridView1.Rows[i].Cells[11].Value = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						liste_da.radGridView1.Rows[i].Cells[12].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					}
				}
			}
			else
			{
				liste_da.radGridView1.Columns[6].IsVisible = false;
				liste_da.radGridView1.Columns[7].IsVisible = false;
				liste_da.radGridView1.Columns[8].IsVisible = false;
				liste_da.radGridView1.Columns[9].IsVisible = false;
				liste_da.radGridView1.Columns[11].IsVisible = false;
				liste_da.radGridView1.Columns[12].IsVisible = false;
				string cmdText2 = "select id, date_da, heure_da, createur, demandeur, delai, periode, statut from demande_achat where statut = @i and demandeur = @v";
				bd bd2 = new bd();
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = page_loginn.id_user;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag5 = dataTable2.Rows.Count != 0;
				if (flag5)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						liste_da.radGridView1.Rows.Add(new object[]
						{
							dataTable2.Rows[j].ItemArray[0].ToString(),
							fonction.Mid(dataTable2.Rows[j].ItemArray[1].ToString(), 1, 10),
							dataTable2.Rows[j].ItemArray[2].ToString(),
							liste_da.select_utilisateur(dataTable2.Rows[j].ItemArray[3].ToString()),
							liste_da.select_utilisateur(dataTable2.Rows[j].ItemArray[4].ToString()),
							dataTable2.Rows[j].ItemArray[5].ToString() + " " + dataTable2.Rows[j].ItemArray[6].ToString()
						});
						liste_da.radGridView1.Rows[j].Cells[6].Value = "Confirmer";
						liste_da.radGridView1.Rows[j].Cells[7].Value = "Refuser";
						liste_da.radGridView1.Rows[j].Cells[8].Value = "Vers l'administrateur";
						liste_da.radGridView1.Rows[j].Cells[9].Value = "Reporter";
						liste_da.radGridView1.Rows[j].Cells[10].Value = Resources.icons8_visible_96;
						liste_da.radGridView1.Rows[j].Cells[11].Value = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						liste_da.radGridView1.Rows[j].Cells[12].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					}
				}
			}
			bool flag6 = liste_da.radGridView1.Rows.Count != 0;
			if (flag6)
			{
				bool flag7 = o == 0;
				if (flag7)
				{
					liste_da.radGridView1.MasterTemplate.MoveToFirstPage();
					liste_da.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag8 = o == 1;
				if (flag8)
				{
					liste_da.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag9 = o == 2;
				if (flag9)
				{
					liste_da.radGridView1.Rows[liste_da.row_act].IsCurrent = true;
				}
				bool flag10 = o == 3;
				if (flag10)
				{
					bool flag11 = liste_da.row_act != 0;
					if (flag11)
					{
						liste_da.radGridView1.Rows[liste_da.row_act - 1].IsCurrent = true;
					}
					else
					{
						liste_da.radGridView1.MasterTemplate.MoveToFirstPage();
						liste_da.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			liste_da.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			liste_da.radGridView1.Templates.Clear();
			liste_da.loadarticle();
			liste_da.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00227A00 File Offset: 0x00225C00
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
			bool flag2 = i == "0";
			if (flag2)
			{
				result = "Système";
			}
			bool flag3 = i == "-1";
			if (flag3)
			{
				result = "Réapprovisionnement";
			}
			bool flag4 = i == "-2";
			if (flag4)
			{
				result = "Recomplètement";
			}
			bool flag5 = i == "-3";
			if (flag5)
			{
				result = "Point de commande";
			}
			bool flag6 = i == "-4";
			if (flag6)
			{
				result = "Réapprovisionnement variable";
			}
			return result;
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00227B14 File Offset: 0x00225D14
		private static void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_da,id_article, article.code_article, article.designation, qt, motif, da_article.id from da_article inner join article on da_article.id_article = article.id where article.deleted = @d";
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
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 120;
				gridViewTemplate.Columns["column6"].Width = 250;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].IsVisible = false;
				gridViewTemplate.Columns[6].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "Code Article";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[4].HeaderText = "Quantité";
				gridViewTemplate.Columns[5].HeaderText = "Motif";
				liste_da.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(liste_da.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(liste_da.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				liste_da.radGridView1.Relations.Add(gridViewRelation);
				liste_da.afficher_equipement(gridViewTemplate);
			}
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00227F68 File Offset: 0x00226168
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
			bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 8;
			if (flag3)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(52, 152, 219), "", typeof(FillPrimitive));
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement3.ForeColor = Color.White;
			}
			bool flag4 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 9;
			if (flag4)
			{
				RadButtonElement radButtonElement4 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement4.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement4.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement4.ForeColor = Color.White;
			}
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00228228 File Offset: 0x00226428
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = liste_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 12;
					if (flag3)
					{
						string value = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						liste_da.row_act = e.RowIndex;
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "delete demande_achat where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							string cmdText2 = "delete da_article where id_da = @a";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = value;
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							liste_da.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag5)
					{
						string value2 = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						liste_da.row_act = e.RowIndex;
						DialogResult dialogResult2 = MessageBox.Show("Vous voulez confirmer cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag6 = dialogResult2 == DialogResult.Yes;
						if (flag6)
						{
							bd bd2 = new bd();
							string cmdText3 = "update demande_achat set statut = @u where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
							sqlCommand3.Parameters.Add("@u", SqlDbType.Int).Value = 1;
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand3.ExecuteNonQuery();
							string cmdText4 = "insert into da_confirmer (id_da, confirmer_par, date_confirmer, heure_confirmer) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
							sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = value2;
							sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand4.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand4.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand4.ExecuteNonQuery();
							bd2.cnn.Close();
							liste_da.remplissage_tableau(3);
						}
					}
					bool flag7 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag7)
					{
						string text = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						liste_da.row_act = e.RowIndex;
						DialogResult dialogResult3 = MessageBox.Show("Vous voulez refuser cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag8 = dialogResult3 == DialogResult.Yes;
						if (flag8)
						{
							liste_da.id_da = text;
							refuser_un_da refuser_un_da = new refuser_un_da();
							refuser_un_da.Show();
						}
					}
					bool flag9 = e.RowIndex >= 0 && e.ColumnIndex == 8;
					if (flag9)
					{
						string value3 = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						liste_da.row_act = e.RowIndex;
						DialogResult dialogResult4 = MessageBox.Show("Vous voulez envoyer cette demande d'achat vers l'administrateur ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag10 = dialogResult4 == DialogResult.Yes;
						if (flag10)
						{
							bd bd3 = new bd();
							string cmdText5 = "update demande_achat set statut = @u where id = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd3.cnn);
							sqlCommand5.Parameters.Add("@u", SqlDbType.Int).Value = 3;
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value3;
							bd3.ouverture_bd(bd3.cnn);
							sqlCommand5.ExecuteNonQuery();
							string cmdText6 = "insert into da_administrateur (id_da, envoyer_par, date_envoyer, heure_envoyer) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd3.cnn);
							sqlCommand6.Parameters.Add("@i1", SqlDbType.Int).Value = value3;
							sqlCommand6.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand6.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand6.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand6.ExecuteNonQuery();
							bd3.cnn.Close();
							liste_da.remplissage_tableau(3);
						}
					}
					bool flag11 = e.RowIndex >= 0 && e.ColumnIndex == 9;
					if (flag11)
					{
						string text2 = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						liste_da.row_act = e.RowIndex;
						DialogResult dialogResult5 = MessageBox.Show("Vous voulez reporter cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag12 = dialogResult5 == DialogResult.Yes;
						if (flag12)
						{
							liste_da.id_da = text2;
							reporter_un_da reporter_un_da = new reporter_un_da();
							reporter_un_da.Show();
						}
					}
					bool flag13 = e.RowIndex >= 0 && e.ColumnIndex == 11;
					if (flag13)
					{
						string text3 = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						liste_da.row_act = e.RowIndex;
						DialogResult dialogResult6 = MessageBox.Show("Vous voulez modifier cette demande d'achat ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag14 = dialogResult6 == DialogResult.Yes;
						if (flag14)
						{
							liste_da.id_da = text3;
							modifier_un_da modifier_un_da = new modifier_un_da();
							modifier_un_da.Show();
						}
					}
					bool flag15 = e.RowIndex >= 0 && e.ColumnIndex == 10;
					if (flag15)
					{
						Form1.id_daa = liste_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						da_eyes da_eyes = new da_eyes();
						da_eyes.Show();
					}
				}
			}
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x002288CC File Offset: 0x00226ACC
		private static void afficher_equipement(GridViewTemplate ta)
		{
			ta.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select  da_article.id, da_article_equipement.id_article, equipement.id, equipement.designation from da_article_equipement inner join equipement on da_article_equipement.id_equipement = equipement.id inner join da_article on da_article_equipement.id_lis = da_article.id where equipement.deleted = @d";
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
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Equipement";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns["column4"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "ID Equipement";
				gridViewTemplate.Columns[3].HeaderText = "Désignation";
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				ta.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(ta);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(ta.Columns[6].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				liste_da.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00228BE0 File Offset: 0x00226DE0
		private void action_vu()
		{
			bool flag = page_loginn.stat_user == "Responsable Achat";
			if (flag)
			{
				bool flag2 = liste_da.radGridView1.Rows.Count != 0;
				if (flag2)
				{
					bd bd = new bd();
					for (int i = 0; i < liste_da.radGridView1.Rows.Count; i++)
					{
						string cmdText = "update demande_achat set vue = @d where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_da.radGridView1.Rows[i].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText2 = "select id from da_vue where id_da = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = liste_da.radGridView1.Rows[i].Cells[0].Value.ToString();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count == 0;
						if (flag3)
						{
							string cmdText3 = "insert into da_vue (id_da,date_vue, heure_vue, vue_par) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = liste_da.radGridView1.Rows[i].Cells[0].Value.ToString();
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = page_loginn.id_user;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x040011ED RID: 4589
		private static int row_act;

		// Token: 0x040011EE RID: 4590
		public static string id_da;
	}
}
