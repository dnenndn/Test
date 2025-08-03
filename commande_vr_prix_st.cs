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
	// Token: 0x02000049 RID: 73
	public partial class commande_vr_prix_st : Form
	{
		// Token: 0x06000340 RID: 832 RVA: 0x0008CC88 File Offset: 0x0008AE88
		public commande_vr_prix_st()
		{
			this.InitializeComponent();
			this.radChartView1.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.radChartView1.Area.View.Palette = KnownPalette.Material;
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.id_art = commande_attente_st.id_art;
			this.radDateTimePicker1.Value = value.AddMonths(-3).AddDays(1.0);
			this.radDateTimePicker2.Value = value;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0008CD38 File Offset: 0x0008AF38
		private void RadChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
		{
			e.LabelElement.ForeColor = Color.Black;
			e.LabelElement.Font = new Font("Calibri", 10.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			e.LabelElement.BackColor = Color.Transparent;
			e.LabelElement.BorderColor = Color.Transparent;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0008CD97 File Offset: 0x0008AF97
		private void commande_vr_prix_st_Load(object sender, EventArgs e)
		{
			this.stat_prix_ref();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0008CDA4 File Offset: 0x0008AFA4
		private void stat_prix_ref()
		{
			this.radChartView1.ShowLegend = false;
			this.radChartView1.Series.Clear();
			this.radChartView1.ShowTitle = false;
			bd bd = new bd();
			string cmdText = "select ds_livraison_article.id, ds_livraison_article.prix_ht, ds_bon_livraison.date_reel from ds_livraison_article inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id where ref_interne = @i and ds_bon_livraison.date_reel between @d1 and @d2 order by ds_bon_livraison.date_reel desc ";
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
				}
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

		// Token: 0x06000344 RID: 836 RVA: 0x0008CFAA File Offset: 0x0008B1AA
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.stat_prix_ref();
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0008CFB4 File Offset: 0x0008B1B4
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.stat_prix_ref();
		}

		// Token: 0x04000487 RID: 1159
		private string id_art;
	}
}
