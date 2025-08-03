using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace GMAO
{
	// Token: 0x0200009E RID: 158
	public partial class mvt_stock : Form
	{
		// Token: 0x06000731 RID: 1841 RVA: 0x0013C0E8 File Offset: 0x0013A2E8
		public mvt_stock()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(mvt_stock.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(mvt_stock.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.ProgressBar1.Hide();
			this.remplissage_tableau();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0013C19C File Offset: 0x0013A39C
		private void mvt_stock_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0013C1A0 File Offset: 0x0013A3A0
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0013C224 File Offset: 0x0013A424
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0013C328 File Offset: 0x0013A528
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id_reception,reception.date_reel ,article.code_article, article.designation, famille.designation, sous_famille.designation, qt_recu, heure_reception from reception_article inner join reception on reception_article.id_reception = reception.id inner join article on reception_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where qt_recu <> @d and reception.date_reel between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select id_bsm,bsm.date_bsm ,article.code_article, article.designation, famille.designation, sous_famille.designation, bsm_article.quantite, heure_bsm from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join article on bsm_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where bsm_article.quantite > @d and bsm.date_bsm between @d1 and @d2";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			string cmdText3 = "select id_brm,brm.date_retour ,article.code_article, article.designation, famille.designation, sous_famille.designation, brm_article.quantite, heure_retour from brm_article inner join brm on brm_article.id_brm = brm.id inner join article on brm_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where brm_article.quantite > @d and brm.date_retour between @d1 and @d2";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			string cmdText4 = "select ds_mp.id_demande,demande_sous_traitance.date_creation, article.code_article, article.designation,famille.designation, sous_famille.designation, ds_mp.qt, heure_creation from ds_mp inner join article on ds_mp.id_article = article.id inner join demande_sous_traitance on ds_mp.id_demande = demande_sous_traitance.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where demande_sous_traitance.date_creation between @d1 and @d2";
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
			sqlCommand4.Parameters.Add("d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand4.Parameters.Add("d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
			DataTable dataTable4 = new DataTable();
			sqlDataAdapter4.Fill(dataTable4);
			int num = dataTable.Rows.Count + dataTable2.Rows.Count + dataTable3.Rows.Count + dataTable4.Rows.Count;
			this.ProgressBar1.Value = 0;
			bool flag = num != 0;
			if (flag)
			{
				this.ProgressBar1.MaximumValue = dataTable.Rows.Count + dataTable2.Rows.Count + dataTable3.Rows.Count + dataTable4.Rows.Count;
			}
			else
			{
				this.ProgressBar1.MaximumValue = 1;
			}
			this.ProgressBar1.Show();
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0],
						"Entrée",
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[4],
						dataTable.Rows[i].ItemArray[5],
						dataTable.Rows[i].ItemArray[2],
						dataTable.Rows[i].ItemArray[3],
						dataTable.Rows[i].ItemArray[6]
					});
					this.ProgressBar1.Value++;
				}
			}
			bool flag3 = dataTable2.Rows.Count != 0;
			if (flag3)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable2.Rows[j].ItemArray[0],
						"Sortie",
						fonction.Mid(dataTable2.Rows[j].ItemArray[1].ToString(), 1, 10) + " " + dataTable2.Rows[j].ItemArray[7].ToString(),
						dataTable2.Rows[j].ItemArray[4],
						dataTable2.Rows[j].ItemArray[5],
						dataTable2.Rows[j].ItemArray[2],
						dataTable2.Rows[j].ItemArray[3],
						dataTable2.Rows[j].ItemArray[6]
					});
					this.ProgressBar1.Value++;
				}
			}
			bool flag4 = dataTable3.Rows.Count != 0;
			if (flag4)
			{
				for (int k = 0; k < dataTable3.Rows.Count; k++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable3.Rows[k].ItemArray[0],
						"Retour",
						fonction.Mid(dataTable3.Rows[k].ItemArray[1].ToString(), 1, 10) + " " + dataTable3.Rows[k].ItemArray[7].ToString(),
						dataTable3.Rows[k].ItemArray[4],
						dataTable3.Rows[k].ItemArray[5],
						dataTable3.Rows[k].ItemArray[2],
						dataTable3.Rows[k].ItemArray[3],
						dataTable3.Rows[k].ItemArray[6]
					});
					this.ProgressBar1.Value++;
				}
			}
			bool flag5 = dataTable4.Rows.Count != 0;
			if (flag5)
			{
				for (int l = 0; l < dataTable4.Rows.Count; l++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable4.Rows[l].ItemArray[0],
						"MP",
						fonction.Mid(dataTable4.Rows[l].ItemArray[1].ToString(), 1, 10) + " " + dataTable4.Rows[l].ItemArray[7].ToString(),
						dataTable4.Rows[l].ItemArray[4],
						dataTable4.Rows[l].ItemArray[5],
						dataTable4.Rows[l].ItemArray[2],
						dataTable4.Rows[l].ItemArray[3],
						dataTable4.Rows[l].ItemArray[6]
					});
					this.ProgressBar1.Value++;
				}
			}
			this.ProgressBar1.Hide();
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			this.radGridView1.MasterTemplate.SortDescriptors.Add("column4", listSortDirection);
			bool flag6 = this.radGridView1.Rows.Count != 0;
			if (flag6)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0013CC67 File Offset: 0x0013AE67
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0013CC71 File Offset: 0x0013AE71
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0013CC7C File Offset: 0x0013AE7C
		private void radButton8_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0013CCCC File Offset: 0x0013AECC
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}
	}
}
