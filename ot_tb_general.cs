using System;
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
	// Token: 0x020000DE RID: 222
	public partial class ot_tb_general : Form
	{
		// Token: 0x060009C6 RID: 2502 RVA: 0x0018BA54 File Offset: 0x00189C54
		public ot_tb_general()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tb_general.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tb_general.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(ot_tb_general.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(ot_tb_general.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(ot_tb_general.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(ot_tb_general.select_changee);
			this.radChartView1.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.radChartView2.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.radChartView3.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0018BB4F File Offset: 0x00189D4F
		private void RadChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
		{
			e.LabelElement.BorderColor = ((DataPointElement)e.LabelElement.Parent).BackColor;
			e.LabelElement.BackColor = Color.White;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0018BB84 File Offset: 0x00189D84
		private void ot_tb_general_Load(object sender, EventArgs e)
		{
			this.select_n_ot();
			this.select_delai_ot();
			this.select_cout_ot();
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0018BB9C File Offset: 0x00189D9C
		private void select_n_ot()
		{
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select count(id) from ordre_travail where id in (" + str + ") and type not like '%'  + @p + '%' and statut = @st";
			string cmdText2 = "select count(id) from ordre_travail where id in (" + str + ") and type  like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand2.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand2.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			fonction fonction = new fonction();
			double num = 0.0;
			double num2 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = fonction.isnumeric(dataTable.Rows[0].ItemArray[0].ToString());
				if (flag2)
				{
					num = (double)Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());
				}
			}
			bool flag3 = dataTable2.Rows.Count != 0;
			if (flag3)
			{
				bool flag4 = fonction.isnumeric(dataTable2.Rows[0].ItemArray[0].ToString());
				if (flag4)
				{
					num2 = (double)Convert.ToInt32(dataTable2.Rows[0].ItemArray[0].ToString());
				}
			}
			double num3 = num + num2;
			this.radGridView3.Rows.Add(new object[]
			{
				"Nbre des OT",
				num3
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Nbre des OT Corrective",
				num
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Nbre des OT Préventive",
				num2
			});
			this.radChartView1.Series.Clear();
			PieSeries pieSeries = new PieSeries();
			pieSeries.ShowLabels = true;
			pieSeries.DrawLinesToLabels = true;
			pieSeries.SyncLinesToLabelsColor = true;
			this.radChartView1.ShowTitle = false;
			this.radChartView1.ForeColor = Color.CornflowerBlue;
			this.radChartView1.ShowLegend = true;
			pieSeries.DataPoints.Add(new PieDataPoint(num, "Corrective"));
			pieSeries.DataPoints.Add(new PieDataPoint(num2, "Préventive"));
			this.radChartView1.Series.Add(pieSeries);
			this.radChartView1.Area.View.Palette = KnownPalette.Fluent;
			PieDataPoint pieDataPoint = this.radChartView1.Series[0].DataPoints[0] as PieDataPoint;
			PieDataPoint pieDataPoint2 = this.radChartView1.Series[0].DataPoints[1] as PieDataPoint;
			bool flag5 = pieDataPoint != null;
			if (flag5)
			{
				pieDataPoint.OffsetFromCenter = 0.1;
			}
			bool flag6 = pieDataPoint2 != null;
			if (flag6)
			{
				pieDataPoint2.OffsetFromCenter = 0.1;
			}
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0018BF5C File Offset: 0x0018A15C
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

		// Token: 0x060009CB RID: 2507 RVA: 0x0018BFE0 File Offset: 0x0018A1E0
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

		// Token: 0x060009CC RID: 2508 RVA: 0x0018C0E4 File Offset: 0x0018A2E4
		private void select_delai_ot()
		{
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select date_debut, heure_debut, date_fin, heure_fin from ordre_travail where id in (" + str + ") and type not like '%'  + @p + '%' and statut = @st";
			string cmdText2 = "select date_debut, heure_debut, date_fin, heure_fin from ordre_travail where id in (" + str + ") and type  like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand2.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand2.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			fonction fonction = new fonction();
			double num = 0.0;
			double num2 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				num = this.total_debut(dataTable);
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				num2 = this.total_debut(dataTable2);
			}
			double value = num + num2;
			this.radGridView1.Rows.Add(new object[]
			{
				"Délai Total des interventions",
				Math.Round(value, 2)
			});
			this.radGridView1.Rows.Add(new object[]
			{
				"Délai Total des interventions Corrective",
				Math.Round(num, 2)
			});
			this.radGridView1.Rows.Add(new object[]
			{
				"Délai Total des interventions Préventive",
				Math.Round(num2, 2)
			});
			this.radChartView2.Series.Clear();
			PieSeries pieSeries = new PieSeries();
			pieSeries.ShowLabels = true;
			pieSeries.DrawLinesToLabels = true;
			pieSeries.SyncLinesToLabelsColor = true;
			this.radChartView2.ShowTitle = false;
			this.radChartView2.ForeColor = Color.CornflowerBlue;
			this.radChartView2.ShowLegend = true;
			pieSeries.DataPoints.Add(new PieDataPoint(num, "Corrective"));
			pieSeries.DataPoints.Add(new PieDataPoint(num2, "Préventive"));
			this.radChartView2.Series.Add(pieSeries);
			this.radChartView2.Area.View.Palette = KnownPalette.Material;
			PieDataPoint pieDataPoint = this.radChartView2.Series[0].DataPoints[0] as PieDataPoint;
			PieDataPoint pieDataPoint2 = this.radChartView2.Series[0].DataPoints[1] as PieDataPoint;
			bool flag3 = pieDataPoint != null;
			if (flag3)
			{
				pieDataPoint.OffsetFromCenter = 0.1;
			}
			bool flag4 = pieDataPoint2 != null;
			if (flag4)
			{
				pieDataPoint2.OffsetFromCenter = 0.1;
			}
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0018C438 File Offset: 0x0018A638
		private double total_debut(DataTable dt)
		{
			double num = 0.0;
			bool flag = dt.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					string text = fonction.Mid(dt.Rows[i].ItemArray[0].ToString(), 1, 10);
					string text2 = fonction.Mid(dt.Rows[i].ItemArray[2].ToString(), 1, 10);
					text = text + " " + dt.Rows[i].ItemArray[1].ToString();
					text2 = text2 + " " + dt.Rows[i].ItemArray[3].ToString();
					DateTime d = Convert.ToDateTime(text);
					DateTime d2 = Convert.ToDateTime(text2);
					TimeSpan timeSpan = default(TimeSpan);
					num += (d2 - d).TotalHours;
				}
			}
			return num;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0018C550 File Offset: 0x0018A750
		private string calcul_duree(double m)
		{
			double num = m / 60.0;
			double num2 = m % 60.0;
			return num.ToString() + " Heures " + num2.ToString() + " Min";
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0018C5A0 File Offset: 0x0018A7A0
		private void select_cout_ot()
		{
			string text = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			indicateur_maintenance indicateur_maintenance = new indicateur_maintenance();
			double num = indicateur_maintenance.select_cout_mo_corrective(ordre_travail.id_ort);
			double num2 = indicateur_maintenance.select_cout_pdr_corrective(ordre_travail.id_ort);
			double num3 = indicateur_maintenance.select_cout_reparation_externe_corrective(ordre_travail.id_ort);
			double num4 = indicateur_maintenance.select_cout_projet_corrective(ordre_travail.id_ort);
			double num5 = indicateur_maintenance.select_cout_mo_preventive(ordre_travail.id_ort);
			double num6 = indicateur_maintenance.select_cout_pdr_preventive(ordre_travail.id_ort);
			double num7 = indicateur_maintenance.select_cout_reparation_externe_preventive(ordre_travail.id_ort);
			double num8 = indicateur_maintenance.select_cout_projet_preventive(ordre_travail.id_ort);
			double num9 = num + num2 + num3 + num4;
			double num10 = num5 + num6 + num7 + num8;
			double num11 = num9 + num10;
			this.radGridView2.Rows.Add(new object[]
			{
				"Coût Total de maintenance",
				num11.ToString("0.000")
			});
			this.radGridView2.Rows.Add(new object[]
			{
				"Coût Total de maintenance Corrective",
				num9.ToString("0.000")
			});
			this.radGridView2.Rows.Add(new object[]
			{
				"Coût Total de maintenance Préventive",
				num10.ToString("0.000")
			});
			this.radChartView3.Series.Clear();
			PieSeries pieSeries = new PieSeries();
			pieSeries.ShowLabels = true;
			pieSeries.DrawLinesToLabels = true;
			pieSeries.SyncLinesToLabelsColor = true;
			this.radChartView3.ShowTitle = false;
			this.radChartView3.ForeColor = Color.CornflowerBlue;
			this.radChartView3.ShowLegend = true;
			pieSeries.DataPoints.Add(new PieDataPoint(num9, "Corrective"));
			pieSeries.DataPoints.Add(new PieDataPoint(num10, "Préventive"));
			this.radChartView3.Series.Add(pieSeries);
			this.radChartView3.Area.View.Palette = KnownPalette.Summer;
			PieDataPoint pieDataPoint = this.radChartView3.Series[0].DataPoints[0] as PieDataPoint;
			PieDataPoint pieDataPoint2 = this.radChartView3.Series[0].DataPoints[1] as PieDataPoint;
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
		}
	}
}
