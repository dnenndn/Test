using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000DD RID: 221
	public partial class ot_tb_cout_total : Form
	{
		// Token: 0x060009BF RID: 2495 RVA: 0x0018ADC8 File Offset: 0x00188FC8
		public ot_tb_cout_total()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tb_cout_total.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tb_cout_total.select_changee);
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0018AE1B File Offset: 0x0018901B
		private void ot_tb_cout_total_Load(object sender, EventArgs e)
		{
			this.select_cout();
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0018AE28 File Offset: 0x00189028
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

		// Token: 0x060009C2 RID: 2498 RVA: 0x0018AEAC File Offset: 0x001890AC
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

		// Token: 0x060009C3 RID: 2499 RVA: 0x0018AFB0 File Offset: 0x001891B0
		private void select_cout()
		{
			this.radGridView3.Rows.Clear();
			this.label1.Text = "";
			indicateur_maintenance indicateur_maintenance = new indicateur_maintenance();
			double num = indicateur_maintenance.select_cout_mo(ordre_travail.id_ort);
			double num2 = indicateur_maintenance.select_cout_pdr(ordre_travail.id_ort);
			double num3 = indicateur_maintenance.select_cout_reparation_externe(ordre_travail.id_ort);
			double num4 = indicateur_maintenance.select_cout_projet(ordre_travail.id_ort);
			this.radGridView3.Rows.Add(new object[]
			{
				"Coût main d'oeuvre",
				num.ToString("0.000")
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Coût PDR",
				num2.ToString("0.000")
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Coût Réparation Externe",
				num3.ToString("0.000")
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Coût Projet",
				num4.ToString("0.000")
			});
			double num5 = num + num2 + num3 + num4;
			this.label1.Text = num5.ToString("0.000");
			this.radChartView1.Series.Clear();
			PieSeries pieSeries = new PieSeries();
			pieSeries.ShowLabels = true;
			pieSeries.DrawLinesToLabels = true;
			pieSeries.SyncLinesToLabelsColor = true;
			this.radChartView1.ShowTitle = false;
			this.radChartView1.ForeColor = Color.CornflowerBlue;
			this.radChartView1.ShowLegend = true;
			pieSeries.DataPoints.Add(new PieDataPoint(num, "Coût main d'oeuvre"));
			pieSeries.DataPoints.Add(new PieDataPoint(num2, "Coût PDR"));
			pieSeries.DataPoints.Add(new PieDataPoint(num3, "Coût Réparation Externe"));
			pieSeries.DataPoints.Add(new PieDataPoint(num4, "Coût Projet"));
			this.radChartView1.Series.Add(pieSeries);
			this.radChartView1.Area.View.Palette = KnownPalette.Fluent;
			PieDataPoint pieDataPoint = this.radChartView1.Series[0].DataPoints[0] as PieDataPoint;
			PieDataPoint pieDataPoint2 = this.radChartView1.Series[0].DataPoints[1] as PieDataPoint;
			PieDataPoint pieDataPoint3 = this.radChartView1.Series[0].DataPoints[2] as PieDataPoint;
			PieDataPoint pieDataPoint4 = this.radChartView1.Series[0].DataPoints[3] as PieDataPoint;
			bool flag = pieDataPoint != null;
			if (flag)
			{
				pieDataPoint.OffsetFromCenter = 0.1;
			}
			bool flag2 = pieDataPoint2 != null;
			if (flag2)
			{
				pieDataPoint2.OffsetFromCenter = 0.1;
			}
			bool flag3 = pieDataPoint3 != null;
			if (flag3)
			{
				pieDataPoint3.OffsetFromCenter = 0.1;
			}
			bool flag4 = pieDataPoint4 != null;
			if (flag4)
			{
				pieDataPoint4.OffsetFromCenter = 0.1;
			}
		}
	}
}
