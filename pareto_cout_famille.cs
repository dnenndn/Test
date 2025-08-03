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
	// Token: 0x020000F7 RID: 247
	public partial class pareto_cout_famille : Form
	{
		// Token: 0x06000AD2 RID: 2770 RVA: 0x001A6C94 File Offset: 0x001A4E94
		public pareto_cout_famille()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(pareto_cout_famille.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(pareto_cout_famille.select_changee);
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x001A6CF4 File Offset: 0x001A4EF4
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

		// Token: 0x06000AD4 RID: 2772 RVA: 0x001A6D78 File Offset: 0x001A4F78
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

		// Token: 0x06000AD5 RID: 2773 RVA: 0x001A6E7B File Offset: 0x001A507B
		private void pareto_cout_famille_Load(object sender, EventArgs e)
		{
			this.select_cout_pdr(ordre_travail.id_ort);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x001A6E8C File Offset: 0x001A508C
		public void select_cout_pdr(List<int> id_ot)
		{
			this.radGridView3.Rows.Clear();
			this.radChartView1.Series.Clear();
			this.radGridView3.Hide();
			this.radChartView1.Hide();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht), famille.id, famille.designation from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id  inner join article on bsm_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s group by famille.id, famille.designation order by sum(bsm_article.quantite * bsm_article.prix_ht)    desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
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

		// Token: 0x06000AD7 RID: 2775 RVA: 0x001A7325 File Offset: 0x001A5525
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x001A7338 File Offset: 0x001A5538
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_cout_pdr(ordre_travail.id_ort);
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x001A7347 File Offset: 0x001A5547
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_cout_pdr(ordre_travail.id_ort);
		}
	}
}
