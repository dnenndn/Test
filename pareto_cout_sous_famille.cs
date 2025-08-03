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
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000FA RID: 250
	public partial class pareto_cout_sous_famille : Form
	{
		// Token: 0x06000AF2 RID: 2802 RVA: 0x001A9C34 File Offset: 0x001A7E34
		public pareto_cout_sous_famille()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(pareto_cout_sous_famille.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(pareto_cout_sous_famille.select_changee);
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x001A9C94 File Offset: 0x001A7E94
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

		// Token: 0x06000AF4 RID: 2804 RVA: 0x001A9D18 File Offset: 0x001A7F18
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

		// Token: 0x06000AF5 RID: 2805 RVA: 0x001A9E1B File Offset: 0x001A801B
		private void pareto_cout_sous_famille_Load(object sender, EventArgs e)
		{
			this.select_famille();
			this.select_cout_pdr(ordre_travail.id_ort);
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x001A9E34 File Offset: 0x001A8034
		private void select_famille()
		{
			this.radDropDownList3.Items.Clear();
			this.radDropDownList3.Items.Add("");
			this.radDropDownList3.Items[0].Tag = 0;
			bd bd = new bd();
			string cmdText = "select id, designation from famille";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList3.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList3.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList3.Items[0].Selected = true;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x001A9F6A File Offset: 0x001A816A
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_cout_pdr(ordre_travail.id_ort);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x001A9F79 File Offset: 0x001A8179
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_cout_pdr(ordre_travail.id_ort);
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x001A9F88 File Offset: 0x001A8188
		private void radDropDownList3_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.select_cout_pdr(ordre_travail.id_ort);
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x001A9F98 File Offset: 0x001A8198
		public void select_cout_pdr(List<int> id_ot)
		{
			this.radGridView3.Rows.Clear();
			this.radChartView1.Series.Clear();
			this.radGridView3.Hide();
			this.radChartView1.Hide();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht), sous_famille.id, sous_famille.designation from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id  inner join article on bsm_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id  where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s and (sous_famille.id_famille = @f or @f = @zero) group by sous_famille.id, sous_famille.designation order by sum(bsm_article.quantite * bsm_article.prix_ht)    desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = this.radDropDownList3.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@zero", SqlDbType.Int).Value = 0;
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
					this.FillColors(this.radChartView1.View, KnownPalette.Metro);
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
								Math.Round(num6, 2),
								Math.Round(num2, 2)
							});
						}
					}
				}
			}
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x001AA475 File Offset: 0x001A8675
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}
	}
}
