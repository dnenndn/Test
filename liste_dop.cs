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
	// Token: 0x0200013C RID: 316
	public partial class liste_dop : Form
	{
		// Token: 0x06000E27 RID: 3623 RVA: 0x0022965C File Offset: 0x0022785C
		public liste_dop()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x002296EA File Offset: 0x002278EA
		private void liste_dop_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x002296F8 File Offset: 0x002278F8
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

		// Token: 0x06000E2A RID: 3626 RVA: 0x00229790 File Offset: 0x00227990
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(52, 152, 219), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.Text = "Associer fournisseur";
				radButtonElement.ForeColor = Color.White;
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 5;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.Text = "Afficher";
				radButtonElement2.ForeColor = Color.White;
			}
			bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag3)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement3.Text = "Créer un devis";
				radButtonElement3.ForeColor = Color.White;
			}
			bool flag4 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag4)
			{
				RadButtonElement radButtonElement4 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement4.SetThemeValueOverride(VisualElement.BackColorProperty, Color.DarkKhaki, "", typeof(FillPrimitive));
				radButtonElement4.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement4.Text = "Afficher Devis";
				radButtonElement4.ForeColor = Color.White;
			}
			bool flag5 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 8;
			if (flag5)
			{
				RadButtonElement radButtonElement5 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement5.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement5.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement5.Text = "Annuler";
				radButtonElement5.ForeColor = Color.White;
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00229B3C File Offset: 0x00227D3C
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id, createur, date_dop, heure_dop from dop where statut = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
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
						this.select_utilisateur(dataTable.Rows[i].ItemArray[1].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
					this.radGridView1.Rows[i].Cells[9].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
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
					this.radGridView1.Rows[liste_dop.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = liste_dop.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[liste_dop.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000E2C RID: 3628 RVA: 0x00229E3C File Offset: 0x0022803C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 4;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					liste_dop.id_dop = text;
					associer_fournisseur_dop associer_fournisseur_dop = new associer_fournisseur_dop();
					associer_fournisseur_dop.Show();
				}
				bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 5;
				if (flag3)
				{
					string text2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					liste_dop.id_dop = text2;
					choisir_fournisseur choisir_fournisseur = new choisir_fournisseur();
					choisir_fournisseur.Show();
				}
				bool flag4 = e.RowIndex >= 0 && e.ColumnIndex == 6;
				if (flag4)
				{
					string text3 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					liste_dop.id_dop = text3;
					ajouter_devis ajouter_devis = new ajouter_devis();
					ajouter_devis.Show();
				}
				bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 7;
				if (flag5)
				{
					string text4 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					liste_dop.id_dop = text4;
					modifier_devis modifier_devis = new modifier_devis();
					modifier_devis.Show();
				}
				bool flag6 = e.RowIndex >= 0 && e.ColumnIndex == 8;
				if (flag6)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					DialogResult dialogResult = MessageBox.Show("Vous voulez annuler la demande offre de prix?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag7 = dialogResult == DialogResult.Yes;
					if (flag7)
					{
						bd bd = new bd();
						string cmdText = "update dop set statut = @v where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = 5;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(3);
					}
				}
				bool flag8 = e.RowIndex >= 0 && e.ColumnIndex == 9;
				if (flag8)
				{
					string value2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					DialogResult dialogResult2 = MessageBox.Show("Vous voulez supprimer la demande offre de prix ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag9 = dialogResult2 == DialogResult.Yes;
					if (flag9)
					{
						bd bd2 = new bd();
						string cmdText2 = "delete dop where id = @i";
						string cmdText3 = "delete dop_article where id_dop = @i";
						string cmdText4 = "delete dop_fini where id_dop = @i";
						string cmdText5 = "delete dop_fournisseur where id_dop = @i";
						string cmdText6 = "delete devis_fournisseur inner join devis on devis_fournisseur.id_devis = devis.id where devis.id_dop = @i";
						string cmdText7 = "delete devis_article inner join devis on devis_article.id_devis = devis.id where devis.id_dop = @i";
						string cmdText8 = "delete devis where id_dop = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						SqlCommand sqlCommand4 = new SqlCommand(cmdText5, bd2.cnn);
						SqlCommand sqlCommand5 = new SqlCommand(cmdText8, bd2.cnn);
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd2.cnn);
						SqlCommand sqlCommand8 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand2.ExecuteNonQuery();
						sqlCommand3.ExecuteNonQuery();
						sqlCommand4.ExecuteNonQuery();
						sqlCommand5.ExecuteNonQuery();
						sqlCommand6.ExecuteNonQuery();
						sqlCommand7.ExecuteNonQuery();
						sqlCommand8.ExecuteNonQuery();
						bd2.cnn.Close();
						this.remplissage_tableau(3);
					}
				}
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x0022A300 File Offset: 0x00228500
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_dop, article.code_article, article.designation, qt from dop_article inner join article on dop_article.id_article = article.id inner join dop on dop_article.id_dop = dop.id where dop.statut = @d";
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
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x040011F3 RID: 4595
		private static int row_act;

		// Token: 0x040011F4 RID: 4596
		public static string id_dop;
	}
}
