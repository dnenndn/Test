using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000048 RID: 72
	public partial class commande_vr_prix : Form
	{
		// Token: 0x06000338 RID: 824 RVA: 0x0008C080 File Offset: 0x0008A280
		public commande_vr_prix()
		{
			this.InitializeComponent();
			this.radChartView1.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.radChartView1.Area.View.Palette = KnownPalette.Material;
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.id_art = commande_attente.id_art;
			this.radDateTimePicker1.Value = value.AddMonths(-3).AddDays(1.0);
			this.radDateTimePicker2.Value = value;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0008C130 File Offset: 0x0008A330
		private void RadChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
		{
			e.LabelElement.ForeColor = Color.Black;
			e.LabelElement.Font = new Font("Calibri", 10.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			e.LabelElement.BackColor = Color.Transparent;
			e.LabelElement.BorderColor = Color.Transparent;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0008C18F File Offset: 0x0008A38F
		private void commande_vr_prix_Load(object sender, EventArgs e)
		{
			this.stat_prix();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0008C19C File Offset: 0x0008A39C
		private void stat_prix()
		{
			this.radChartView1.ShowLegend = false;
			this.radChartView1.Series.Clear();
			this.radChartView1.ShowTitle = false;
			bd bd = new bd();
			string cmdText = "select livraison_article.id, livraison_article.prix_ht, bon_livraison.date_reel from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id inner join article on livraison_article.id_article = article.id where article.code_article = @i and bon_livraison.date_reel between @d1 and @d2 order by bon_livraison.date_reel desc ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.id_art;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			int count = dataTable.Rows.Count;
			bool flag = count != 0;
			if (flag)
			{
				this.radChartView1.ForeColor = Color.Firebrick;
				LineSeries lineSeries = new LineSeries();
				lineSeries.ShowLabels = true;
				List<string> list = new List<string>();
				for (int i = 0; i < count; i++)
				{
					lineSeries.DataPoints.Insert(0, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3), fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[2]), 1, 10)));
					list.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
				string text = string.Join(",", list.ToArray());
				lineSeries.PointSize = new SizeF(12f, 12f);
				this.radChartView1.Series.Add(lineSeries);
				lineSeries.VerticalAxis.LabelInterval = 2;
				ChartPanZoomController chartPanZoomController = new ChartPanZoomController();
				chartPanZoomController.PanZoomMode = 0;
				this.radChartView1.Controllers.Add(chartPanZoomController);
				int num = count / 8 + 1;
				this.radChartView1.Zoom((double)num, 1.0);
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0008C3DA File Offset: 0x0008A5DA
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.stat_prix();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0008C3E4 File Offset: 0x0008A5E4
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.stat_prix();
		}

		// Token: 0x04000480 RID: 1152
		private string id_art;
	}
}
