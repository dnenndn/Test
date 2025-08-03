using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000F8 RID: 248
	public partial class pareto_cout_fonction : Form
	{
		// Token: 0x06000ADC RID: 2780 RVA: 0x001A7B44 File Offset: 0x001A5D44
		public pareto_cout_fonction()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(pareto_cout_fonction.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(pareto_cout_fonction.select_changee);
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x001A7BA4 File Offset: 0x001A5DA4
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

		// Token: 0x06000ADE RID: 2782 RVA: 0x001A7C28 File Offset: 0x001A5E28
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

		// Token: 0x06000ADF RID: 2783 RVA: 0x001A7D2B File Offset: 0x001A5F2B
		private void pareto_cout_fonction_Load(object sender, EventArgs e)
		{
			this.select_cout_mo(ordre_travail.id_ort);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x001A7D3C File Offset: 0x001A5F3C
		public void select_cout_mo(List<int> id_ot)
		{
			this.radGridView3.Rows.Clear();
			this.radChartView1.Series.Clear();
			this.radGridView3.Hide();
			this.radChartView1.Hide();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)),fonction_intervenant.id, fonction_intervenant.designation, sum(datediff(MINUTE,debut, fin) / 60.0) from ot_ordo_intervenant inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id  where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ot in (" + str + ") and ordre_travail.statut = @s) group by fonction_intervenant.id, fonction_intervenant.designation order by sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) desc ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
				}
				double num2 = 0.0;
				bool isChecked = this.radRadioButton7.IsChecked;
				if (isChecked)
				{
					this.radChartView1.Show();
					this.radChartView1.Axes.Clear();
					BarSeries barSeries = new BarSeries();
					LineSeries lineSeries = new LineSeries();
					LinearAxis linearAxis = new LinearAxis();
					linearAxis.HorizontalLocation = 0;
					LinearAxis linearAxis2 = new LinearAxis();
					linearAxis2.HorizontalLocation = 1;
					CategoricalAxis categoricalAxis = new CategoricalAxis();
					linearAxis.AxisType = 1;
					linearAxis2.AxisType = 1;
					linearAxis2.Maximum = 110.0;
					categoricalAxis.ForeColor = Color.Crimson;
					lineSeries.PointSize = new Size(10, 10);
					linearAxis.Title = "Coût de maintenance (TND)";
					linearAxis2.Title = "Pourcentage cumulée";
					barSeries.VerticalAxis = linearAxis;
					barSeries.HorizontalAxis = categoricalAxis;
					lineSeries.HorizontalAxis = categoricalAxis;
					lineSeries.VerticalAxis = linearAxis2;
					lineSeries.Spline = true;
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						double num3 = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						double num4 = num3 / num * 100.0;
						num2 += num4;
						bool flag2 = num3 != 0.0;
						if (flag2)
						{
							barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num3), 2), dataTable.Rows[j].ItemArray[2].ToString()));
							lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num2), 2), dataTable.Rows[j].ItemArray[2].ToString()));
						}
					}
					this.radChartView1.Series.Add(lineSeries);
					this.radChartView1.Series.Add(barSeries);
					this.FillColors(this.radChartView1.View, KnownPalette.Lilac);
					CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
					area.ShowGrid = true;
					CartesianGrid grid = area.GetGrid<CartesianGrid>();
					grid.DrawHorizontalStripes = true;
					barSeries.LabelMode = 1;
				}
				else
				{
					this.radGridView3.Show();
					for (int k = 0; k < dataTable.Rows.Count; k++)
					{
						double num5 = Convert.ToDouble(dataTable.Rows[k].ItemArray[0]);
						double num6 = num5 / num * 100.0;
						num2 += num6;
						bool flag3 = num5 != 0.0;
						if (flag3)
						{
							this.radGridView3.Rows.Add(new object[]
							{
								dataTable.Rows[k].ItemArray[2].ToString(),
								num5.ToString("0.000"),
								Math.Round(Convert.ToDouble(dataTable.Rows[k].ItemArray[3]), 2),
								Math.Round(num6, 2),
								Math.Round(num2, 2)
							});
						}
					}
				}
			}
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x001A81C5 File Offset: 0x001A63C5
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x001A81D8 File Offset: 0x001A63D8
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_cout_mo(ordre_travail.id_ort);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x001A81E7 File Offset: 0x001A63E7
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_cout_mo(ordre_travail.id_ort);
		}
	}
}
