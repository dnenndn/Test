using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
	// Token: 0x0200012B RID: 299
	public partial class dop_annule : Form
	{
		// Token: 0x06000D31 RID: 3377 RVA: 0x001FEF0C File Offset: 0x001FD10C
		public dop_annule()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
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

		// Token: 0x06000D32 RID: 3378 RVA: 0x001FEFCC File Offset: 0x001FD1CC
		private void dop_annule_Load(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x001FF030 File Offset: 0x001FD230
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

		// Token: 0x06000D34 RID: 3380 RVA: 0x001FF0C8 File Offset: 0x001FD2C8
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.Text = "Afficher";
				radButtonElement.ForeColor = Color.White;
			}
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x001FF194 File Offset: 0x001FD394
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id, createur, date_dop, heure_dop from dop where statut = @d and date_dop between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 5;
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
						this.select_utilisateur(dataTable.Rows[i].ItemArray[1].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
					this.radGridView1.Rows[i].Cells[5].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
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
					this.radGridView1.Rows[dop_annule.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = dop_annule.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[dop_annule.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000D36 RID: 3382 RVA: 0x001FF4E4 File Offset: 0x001FD6E4
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
					choisir_fournisseur choisir_fournisseur = new choisir_fournisseur();
					choisir_fournisseur.Show();
				}
				bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 5;
				if (flag3)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer la demande offre de prix ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag4 = dialogResult == DialogResult.Yes;
					if (flag4)
					{
						bd bd = new bd();
						string cmdText = "delete dop where id = @i";
						string cmdText2 = "delete dop_article where id_dop = @i";
						string cmdText3 = "delete dop_fournisseur where id_dop = @i";
						string cmdText4 = "delete devis_fournisseur inner join devis on devis_fournisseur.id_devis = devis.id where devis.id_dop = @i";
						string cmdText5 = "delete devis_article inner join devis on devis_article.id_devis = devis.id where devis.id_dop = @i";
						string cmdText6 = "delete devis where id_dop = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						SqlCommand sqlCommand4 = new SqlCommand(cmdText6, bd.cnn);
						SqlCommand sqlCommand5 = new SqlCommand(cmdText4, bd.cnn);
						SqlCommand sqlCommand6 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
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

		// Token: 0x06000D37 RID: 3383 RVA: 0x001FF75C File Offset: 0x001FD95C
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_dop, article.code_article, article.designation, qt from dop_article inner join article on dop_article.id_article = article.id inner join dop on dop_article.id_dop = dop.id where dop.statut = @d and dop.date_dop between @d1 and @d2";
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

		// Token: 0x040010BA RID: 4282
		private static int row_act;

		// Token: 0x040010BB RID: 4283
		public static string id_dop;
	}
}
