using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000E1 RID: 225
	public partial class ot_tb_realisation_cause : Form
	{
		// Token: 0x060009E2 RID: 2530 RVA: 0x0018E412 File Offset: 0x0018C612
		public ot_tb_realisation_cause()
		{
			this.InitializeComponent();
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0018E437 File Offset: 0x0018C637
		private void ot_tb_realisation_cause_Load(object sender, EventArgs e)
		{
			this.select_cause();
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0018E444 File Offset: 0x0018C644
		private void select_cause()
		{
			this.radChartView1.Series.Clear();
			BarSeries barSeries = new BarSeries();
			CategoricalAxis categoricalAxis = new CategoricalAxis();
			categoricalAxis.HorizontalLocation = 0;
			LinearAxis linearAxis = new LinearAxis();
			categoricalAxis.AxisType = 1;
			linearAxis.ForeColor = Color.Crimson;
			linearAxis.VerticalLocation = 1;
			categoricalAxis.Title = "Cause de non réalisation";
			barSeries.VerticalAxis = categoricalAxis;
			barSeries.HorizontalAxis = linearAxis;
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select parametre_cause_realisation.code, count(id_ot) from ot_cause_realisation inner join parametre_cause_realisation on ot_cause_realisation.id_cause = parametre_cause_realisation.id inner join ordre_travail on ot_cause_realisation.id_ot = ordre_travail.id where id_ot in (" + str + ") and (statut = @a1 or statut = @a2) group by parametre_cause_realisation.id, parametre_cause_realisation.code order by count(id_ot)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a1", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@a2", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[1]) != 0;
					if (flag2)
					{
						barSeries.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable.Rows[i].ItemArray[1]), dataTable.Rows[i].ItemArray[0].ToString()));
					}
				}
			}
			this.FillColors(this.radChartView1.View, KnownPalette.Material);
			CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
			area.ShowGrid = true;
			CartesianGrid grid = area.GetGrid<CartesianGrid>();
			grid.DrawHorizontalStripes = true;
			barSeries.LabelMode = 1;
			this.radChartView1.Series.Add(barSeries);
			this.FillBarSeries(barSeries);
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0018E655 File Offset: 0x0018C855
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0018E668 File Offset: 0x0018C868
		private void FillBarSeries(CartesianSeries series)
		{
			int num = 0;
			foreach (UIChartElement uichartElement in series.Children)
			{
				DataPointElement dataPointElement = (DataPointElement)uichartElement;
				bool flag = num % 5 == 0;
				if (flag)
				{
					dataPointElement.BackColor = Color.Crimson;
					dataPointElement.BorderColor = Color.Crimson;
				}
				bool flag2 = num % 5 == 1;
				if (flag2)
				{
					dataPointElement.BackColor = Color.LimeGreen;
					dataPointElement.BorderColor = Color.LimeGreen;
				}
				bool flag3 = num % 5 == 2;
				if (flag3)
				{
					dataPointElement.BackColor = Color.DodgerBlue;
					dataPointElement.BorderColor = Color.DodgerBlue;
				}
				bool flag4 = num % 5 == 3;
				if (flag4)
				{
					dataPointElement.BackColor = Color.DarkKhaki;
					dataPointElement.BorderColor = Color.DarkKhaki;
				}
				bool flag5 = num % 5 == 5;
				if (flag5)
				{
					dataPointElement.BackColor = Color.DeepPink;
					dataPointElement.BorderColor = Color.DeepPink;
				}
				num++;
			}
		}
	}
}
