using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace GMAO
{
	// Token: 0x02000169 RID: 361
	public partial class tb_variation_prix_recap : Form
	{
		// Token: 0x06001045 RID: 4165 RVA: 0x00292AC8 File Offset: 0x00290CC8
		public tb_variation_prix_recap()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(tb_variation_prix_recap.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(tb_variation_prix_recap.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x00292B6C File Offset: 0x00290D6C
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

		// Token: 0x06001047 RID: 4167 RVA: 0x00292BF0 File Offset: 0x00290DF0
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

		// Token: 0x06001048 RID: 4168 RVA: 0x00292CF4 File Offset: 0x00290EF4
		private void tb_variation_prix_recap_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x00292D3C File Offset: 0x00290F3C
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.radGridView1.Columns[2].IsVisible = false;
				bd bd = new bd();
				string cmdText = "select article.id ,article.code_article, article.designation, max(livraison_article.prix_ht), min(livraison_article.prix_ht), max(livraison_article.prix_ht)- min(livraison_article.prix_ht), avg(livraison_article.prix_ht), stdev(livraison_article.prix_ht), (stdev(livraison_article.prix_ht)/avg(livraison_article.prix_ht)) * 100 from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id inner join article on livraison_article.id_article = article.id where bon_livraison.date_reel between @d1 and @d2  group by article.id, article.code_article, article.designation having max(livraison_article.prix_ht) <> min(livraison_article.prix_ht) order by (stdev(livraison_article.prix_ht)/avg(livraison_article.prix_ht)) * 100 desc  ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
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
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							"-",
							Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
							Convert.ToDouble(dataTable.Rows[i].ItemArray[4]).ToString("0.000"),
							Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
							Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000"),
							Convert.ToDouble(dataTable.Rows[i].ItemArray[7]).ToString("0.000"),
							Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[8]), 2).ToString() ?? ""
						});
					}
				}
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x00292FB6 File Offset: 0x002911B6
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x00292FC0 File Offset: 0x002911C0
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x00292FCC File Offset: 0x002911CC
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

		// Token: 0x0600104D RID: 4173 RVA: 0x0029301C File Offset: 0x0029121C
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
