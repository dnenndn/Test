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
	// Token: 0x020000E3 RID: 227
	public partial class ot_tb_type_maintenance : Form
	{
		// Token: 0x060009EE RID: 2542 RVA: 0x0018F284 File Offset: 0x0018D484
		public ot_tb_type_maintenance()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tb_type_maintenance.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tb_type_maintenance.select_changee);
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0018F2E4 File Offset: 0x0018D4E4
		private void ot_tb_type_maintenance_Load(object sender, EventArgs e)
		{
			this.select_donne();
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0018F2F0 File Offset: 0x0018D4F0
		private void select_donne()
		{
			this.radChartView1.Series.Clear();
			this.radGridView3.Rows.Clear();
			this.radGridView3.Hide();
			this.radChartView1.Hide();
			bd bd = new bd();
			List<double> list = new List<double>();
			List<double> list2 = new List<double>();
			List<double> list3 = new List<double>();
			List<double> list4 = new List<double>();
			List<double> list5 = new List<double>();
			List<double> list6 = new List<double>();
			List<double> list7 = new List<double>();
			indicateur_maintenance indicateur_maintenance = new indicateur_maintenance();
			list = indicateur_maintenance.select_cout_mo_par_type(ordre_travail.id_ort);
			list2 = indicateur_maintenance.select_cout_pdr_par_type(ordre_travail.id_ort);
			list3 = indicateur_maintenance.select_cout_reparation_externe_par_type(ordre_travail.id_ort);
			list4 = indicateur_maintenance.select_cout_projet_par_type(ordre_travail.id_ort);
			double num = 0.0;
			for (int i = 0; i < 6; i++)
			{
				double num2 = list[i] + list2[i] + list3[i] + list4[i];
				num = num2 + num;
				list5.Add(num2);
			}
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select count(id), type from ordre_travail where id in (" + str + ") and statut = @a group by type";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select sum(datediff(MINUTE, concat(date_debut, @espace, heure_debut, @f), concat(date_fin, @espace, heure_fin, @f))/60.0), type from ordre_travail where id in (" + str + ") and statut = @a group by type";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand2.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand2.Parameters.Add("@f", SqlDbType.VarChar).Value = ":00";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			double item = 0.0;
			double item2 = 0.0;
			double item3 = 0.0;
			double item4 = 0.0;
			double item5 = 0.0;
			double item6 = 0.0;
			double item7 = 0.0;
			double item8 = 0.0;
			double item9 = 0.0;
			double item10 = 0.0;
			double item11 = 0.0;
			double item12 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[j].ItemArray[0]));
					if (flag2)
					{
						bool flag3 = dataTable.Rows[j].ItemArray[1].ToString() == "Corrective Curative";
						if (flag3)
						{
							item = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						}
						bool flag4 = dataTable.Rows[j].ItemArray[1].ToString() == "Corrective Palliative";
						if (flag4)
						{
							item2 = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						}
						bool flag5 = dataTable.Rows[j].ItemArray[1].ToString() == "Travaux Neufs";
						if (flag5)
						{
							item3 = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						}
						bool flag6 = dataTable.Rows[j].ItemArray[1].ToString() == "Préventive Systématique";
						if (flag6)
						{
							item4 = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						}
						bool flag7 = dataTable.Rows[j].ItemArray[1].ToString() == "Préventive Syst Compteur";
						if (flag7)
						{
							item5 = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						}
						bool flag8 = dataTable.Rows[j].ItemArray[1].ToString() == "Préventive Conditionnelle";
						if (flag8)
						{
							item6 = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
						}
					}
				}
			}
			bool flag9 = dataTable2.Rows.Count != 0;
			if (flag9)
			{
				fonction fonction2 = new fonction();
				for (int k = 0; k < dataTable2.Rows.Count; k++)
				{
					bool flag10 = fonction2.is_reel(Convert.ToString(dataTable2.Rows[k].ItemArray[0]));
					if (flag10)
					{
						bool flag11 = dataTable2.Rows[k].ItemArray[1].ToString() == "Corrective Curative";
						if (flag11)
						{
							item7 = Convert.ToDouble(dataTable2.Rows[k].ItemArray[0]);
						}
						bool flag12 = dataTable2.Rows[k].ItemArray[1].ToString() == "Corrective Palliative";
						if (flag12)
						{
							item8 = Convert.ToDouble(dataTable2.Rows[k].ItemArray[0]);
						}
						bool flag13 = dataTable2.Rows[k].ItemArray[1].ToString() == "Travaux Neufs";
						if (flag13)
						{
							item9 = Convert.ToDouble(dataTable2.Rows[k].ItemArray[0]);
						}
						bool flag14 = dataTable2.Rows[k].ItemArray[1].ToString() == "Préventive Systématique";
						if (flag14)
						{
							item10 = Convert.ToDouble(dataTable2.Rows[k].ItemArray[0]);
						}
						bool flag15 = dataTable2.Rows[k].ItemArray[1].ToString() == "Préventive Syst Compteur";
						if (flag15)
						{
							item11 = Convert.ToDouble(dataTable2.Rows[k].ItemArray[0]);
						}
						bool flag16 = dataTable2.Rows[k].ItemArray[1].ToString() == "Préventive Conditionnelle";
						if (flag16)
						{
							item12 = Convert.ToDouble(dataTable2.Rows[k].ItemArray[0]);
						}
					}
				}
			}
			list6.Add(item);
			list6.Add(item2);
			list6.Add(item3);
			list6.Add(item4);
			list6.Add(item5);
			list6.Add(item6);
			list7.Add(item7);
			list7.Add(item8);
			list7.Add(item9);
			list7.Add(item10);
			list7.Add(item11);
			list7.Add(item12);
			this.radGridView3.Rows.Add(new object[]
			{
				"Corrective Curative",
				list6[0],
				Math.Round(list7[0], 2),
				list[0].ToString("0.000"),
				list2[0].ToString("0.000"),
				list3[0].ToString("0.000"),
				list4[0].ToString("0.000"),
				list5[0].ToString("0.000"),
				Math.Round(list5[0] / num * 100.0, 2)
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Corrective Palliative",
				list6[1],
				Math.Round(list7[1], 2),
				list[1].ToString("0.000"),
				list2[1].ToString("0.000"),
				list3[1].ToString("0.000"),
				list4[1].ToString("0.000"),
				list5[1].ToString("0.000"),
				Math.Round(list5[1] / num * 100.0, 2)
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Travaux Neufs",
				list6[2],
				list7[2],
				Math.Round(list7[2], 2).ToString("0.000"),
				list2[2].ToString("0.000"),
				list3[2].ToString("0.000"),
				list4[2].ToString("0.000"),
				list5[2].ToString("0.000"),
				Math.Round(list5[2] / num * 100.0, 2)
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Préventive Systématique",
				list6[3],
				Math.Round(list7[3], 2),
				list[3].ToString("0.000"),
				list2[3].ToString("0.000"),
				list3[3].ToString("0.000"),
				list4[3].ToString("0.000"),
				list5[3].ToString("0.000"),
				Math.Round(list5[3] / num * 100.0, 2)
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Préventive Syst Compteur",
				list6[4],
				Math.Round(list7[4], 2),
				list[4].ToString("0.000"),
				list2[4].ToString("0.000"),
				list3[4].ToString("0.000"),
				list4[4].ToString("0.000"),
				list5[4].ToString("0.000"),
				Math.Round(list5[4] / num * 100.0, 2)
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Préventive Conditionnelle",
				list6[5],
				Math.Round(list7[5], 2),
				list[5].ToString("0.000"),
				list2[5].ToString("0.000"),
				list3[5].ToString("0.000"),
				list4[5].ToString("0.000"),
				list5[5].ToString("0.000"),
				Math.Round(list5[5] / num * 100.0, 2)
			});
			BarSeries barSeries = new BarSeries();
			BarSeries barSeries2 = new BarSeries();
			BarSeries barSeries3 = new BarSeries();
			BarSeries barSeries4 = new BarSeries();
			this.radChartView1.Axes.Clear();
			LinearAxis linearAxis = new LinearAxis();
			linearAxis.HorizontalLocation = 0;
			LinearAxis linearAxis2 = new LinearAxis();
			linearAxis2.HorizontalLocation = 1;
			CategoricalAxis categoricalAxis = new CategoricalAxis();
			linearAxis.AxisType = 1;
			linearAxis2.AxisType = 1;
			linearAxis2.Maximum = 110.0;
			categoricalAxis.ForeColor = Color.Crimson;
			barSeries.VerticalAxis = linearAxis;
			barSeries2.VerticalAxis = linearAxis;
			barSeries3.VerticalAxis = linearAxis;
			barSeries4.VerticalAxis = linearAxis;
			barSeries.HorizontalAxis = categoricalAxis;
			barSeries2.HorizontalAxis = categoricalAxis;
			barSeries3.HorizontalAxis = categoricalAxis;
			barSeries4.HorizontalAxis = categoricalAxis;
			barSeries.ShowLabels = true;
			barSeries2.ShowLabels = true;
			barSeries3.ShowLabels = true;
			barSeries4.ShowLabels = true;
			barSeries.LegendTitle = "Coût MO";
			barSeries2.LegendTitle = "Coût PDR";
			barSeries3.LegendTitle = "Coût Rép. Externe";
			barSeries4.LegendTitle = "Coût Projet";
			linearAxis.Title = "Coût (TND)";
			linearAxis2.Title = "Pourcentage (%) ";
			barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(list[0], 3), "Corrective Curative"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(list[1], 3), "Corrective Palliative"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(list[2], 3), "Travaux Neufs"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(list[3], 3), "Préventive Systématique"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(list[4], 3), "Préventive Syst Compteur"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(list[5], 3), "Préventive Conditionnelle"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(list2[0], 3), "Corrective Curative"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(list2[1], 3), "Corrective Palliative"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(list2[2], 3), "Travaux Neufs"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(list2[3], 3), "Préventive Systématique"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(list2[4], 3), "Préventive Syst Compteur"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(list2[5], 3), "Préventive Conditionnelle"));
			barSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(list3[0], 3), "Corrective Curative"));
			barSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(list3[1], 3), "Corrective Palliative"));
			barSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(list3[2], 3), "Travaux Neufs"));
			barSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(list3[3], 3), "Préventive Systématique"));
			barSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(list3[4], 3), "Préventive Syst Compteur"));
			barSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(list3[5], 3), "Préventive Conditionnelle"));
			barSeries4.DataPoints.Add(new CategoricalDataPoint(Math.Round(list4[0], 3), "Corrective Curative"));
			barSeries4.DataPoints.Add(new CategoricalDataPoint(Math.Round(list4[1], 3), "Corrective Palliative"));
			barSeries4.DataPoints.Add(new CategoricalDataPoint(Math.Round(list4[2], 3), "Travaux Neufs"));
			barSeries4.DataPoints.Add(new CategoricalDataPoint(Math.Round(list4[3], 3), "Préventive Systématique"));
			barSeries4.DataPoints.Add(new CategoricalDataPoint(Math.Round(list4[4], 3), "Préventive Syst Compteur"));
			barSeries4.DataPoints.Add(new CategoricalDataPoint(Math.Round(list4[5], 3), "Préventive Conditionnelle"));
			this.radChartView1.Series.Add(barSeries);
			this.radChartView1.Series.Add(barSeries2);
			this.radChartView1.Series.Add(barSeries3);
			this.radChartView1.Series.Add(barSeries4);
			barSeries.CombineMode = 2;
			barSeries2.CombineMode = 2;
			barSeries3.CombineMode = 2;
			barSeries4.CombineMode = 2;
			this.affichage_partie();
			this.radChartView1.ShowLegend = true;
			this.radChartView1.View.Palette = KnownPalette.Metro;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x001904EC File Offset: 0x0018E6EC
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

		// Token: 0x060009F2 RID: 2546 RVA: 0x00190570 File Offset: 0x0018E770
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

		// Token: 0x060009F3 RID: 2547 RVA: 0x00190674 File Offset: 0x0018E874
		private void affichage_partie()
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.radGridView3.Hide();
				this.radChartView1.Show();
			}
			else
			{
				this.radGridView3.Show();
				this.radChartView1.Hide();
			}
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x001906C7 File Offset: 0x0018E8C7
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_partie();
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x001906D1 File Offset: 0x0018E8D1
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_partie();
		}
	}
}
