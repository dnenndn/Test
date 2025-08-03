using System;
using System.Collections.Generic;
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
	// Token: 0x020000AD RID: 173
	public partial class ot_bt_cout_total : Form
	{
		// Token: 0x060007DA RID: 2010 RVA: 0x00157074 File Offset: 0x00155274
		public ot_bt_cout_total()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_bt_cout_total.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_bt_cout_total.select_changee);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x001570C7 File Offset: 0x001552C7
		private void ot_bt_cout_total_Load(object sender, EventArgs e)
		{
			this.select_cout();
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x001570D4 File Offset: 0x001552D4
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

		// Token: 0x060007DD RID: 2013 RVA: 0x00157158 File Offset: 0x00155358
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

		// Token: 0x060007DE RID: 2014 RVA: 0x0015725C File Offset: 0x0015545C
		private void select_cout()
		{
			this.radGridView3.Rows.Clear();
			this.label1.Text = "";
			indicateur_maintenance indicateur_maintenance = new indicateur_maintenance();
			List<int> list = new List<int>();
			list.Add(ot_liste.id_ot_tr);
			double num = indicateur_maintenance.select_cout_mo(list);
			double num2 = indicateur_maintenance.select_cout_pdr(list);
			double num3 = indicateur_maintenance.select_cout_reparation_externe(list);
			double num4 = indicateur_maintenance.select_cout_projet(list);
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
