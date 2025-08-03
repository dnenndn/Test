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
	// Token: 0x020000FE RID: 254
	public partial class pareto_fiabilite_organe : Form
	{
		// Token: 0x06000B28 RID: 2856 RVA: 0x001B0218 File Offset: 0x001AE418
		public pareto_fiabilite_organe()
		{
			this.InitializeComponent();
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x001B0240 File Offset: 0x001AE440
		private void pareto_fiabilite_organe_Load(object sender, EventArgs e)
		{
			this.panel2.Visible = false;
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.select_pareto_disponibilite();
			}
			bool isChecked2 = this.radRadioButton2.IsChecked;
			if (isChecked2)
			{
				this.select_pareto_fiabilite();
			}
			bool isChecked3 = this.radRadioButton4.IsChecked;
			if (isChecked3)
			{
				this.select_pareto_maintenabilite();
			}
			bool isChecked4 = this.radRadioButton5.IsChecked;
			if (isChecked4)
			{
				this.panel2.Visible = true;
			}
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x001B02C4 File Offset: 0x001AE4C4
		private void select_pareto_disponibilite()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.organe e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.organe = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select (sum(d) * 100) / (select sum(d) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot from temporaire  group by e,c,desi order by sum(d) desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
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
				linearAxis.Title = "TTR";
				linearAxis2.Title = "Pourcentage cumulée";
				barSeries.VerticalAxis = linearAxis;
				barSeries.HorizontalAxis = categoricalAxis;
				lineSeries.HorizontalAxis = categoricalAxis;
				lineSeries.VerticalAxis = linearAxis2;
				lineSeries.Spline = true;
				double num = 0.0;
				double num2 = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[4]);
					double num4 = Convert.ToDouble(dataTable.Rows[i].ItemArray[5]);
					num2 = num3 + num2;
					bool flag2 = num <= 80.0;
					if (!flag2)
					{
						double value = (100.0 - num) * num2 / num;
						barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(value), 2), "Autres"));
						break;
					}
					barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num3), 2), dataTable.Rows[i].ItemArray[2].ToString()));
					num += Convert.ToDouble(dataTable.Rows[i].ItemArray[0].ToString());
					lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num), 2), dataTable.Rows[i].ItemArray[2].ToString()));
				}
				lineSeries.DataPoints.Add(new CategoricalDataPoint(100.0, "Autres"));
				this.radChartView1.Series.Add(lineSeries);
				this.radChartView1.Series.Add(barSeries);
				this.FillColors(this.radChartView1.View, KnownPalette.Grayscale);
				CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
				area.ShowGrid = true;
				CartesianGrid grid = area.GetGrid<CartesianGrid>();
				grid.DrawHorizontalStripes = true;
				barSeries.LabelMode = 1;
			}
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x001B0691 File Offset: 0x001AE891
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x001B06A4 File Offset: 0x001AE8A4
		private void select_pareto_maintenabilite()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.organe e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.organe = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select (avg(d) * count(i) * 100) / (select sum(d) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot from temporaire  group by e,c,desi order by avg(d) desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
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
				linearAxis.Title = "MTTR";
				linearAxis2.Title = "Pourcentage cumulée";
				barSeries.VerticalAxis = linearAxis;
				barSeries.HorizontalAxis = categoricalAxis;
				lineSeries.HorizontalAxis = categoricalAxis;
				lineSeries.VerticalAxis = linearAxis2;
				lineSeries.Spline = true;
				double num = 0.0;
				double num2 = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[4]);
					double num4 = Convert.ToDouble(dataTable.Rows[i].ItemArray[5]);
					num2 = num4 + num2;
					bool flag2 = num <= 80.0;
					if (!flag2)
					{
						double value = (100.0 - num) * num2 / num;
						barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(value), 2), "Autres"));
						break;
					}
					barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num4), 2), dataTable.Rows[i].ItemArray[2].ToString()));
					num += Convert.ToDouble(dataTable.Rows[i].ItemArray[0].ToString());
					lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num), 2), dataTable.Rows[i].ItemArray[2].ToString()));
				}
				lineSeries.DataPoints.Add(new CategoricalDataPoint(100.0, "Autres"));
				this.radChartView1.Series.Add(lineSeries);
				this.radChartView1.Series.Add(barSeries);
				this.FillColors(this.radChartView1.View, KnownPalette.Grayscale);
				CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
				area.ShowGrid = true;
				CartesianGrid grid = area.GetGrid<CartesianGrid>();
				grid.DrawHorizontalStripes = true;
				barSeries.LabelMode = 1;
			}
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x001B0A74 File Offset: 0x001AEC74
		private void select_pareto_fiabilite()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.organe e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.organe = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select (count(i) * 100) / (select count(i) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot from temporaire  group by e,c,desi order by count(i) desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
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
				linearAxis.Title = "Nombre des OT";
				linearAxis2.Title = "Pourcentage cumulée";
				barSeries.VerticalAxis = linearAxis;
				barSeries.HorizontalAxis = categoricalAxis;
				lineSeries.HorizontalAxis = categoricalAxis;
				lineSeries.VerticalAxis = linearAxis2;
				lineSeries.Spline = true;
				double num = 0.0;
				double num2 = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[6]);
					num2 = num3 + num2;
					bool flag2 = num <= 80.0;
					if (!flag2)
					{
						double value = (100.0 - num) * num2 / num;
						barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(value), 2), "Autres"));
						break;
					}
					barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num3), 2), dataTable.Rows[i].ItemArray[2].ToString()));
					num += Convert.ToDouble(dataTable.Rows[i].ItemArray[0].ToString());
					lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num), 2), dataTable.Rows[i].ItemArray[2].ToString()));
				}
				lineSeries.DataPoints.Add(new CategoricalDataPoint(100.0, "Autres"));
				this.radChartView1.Series.Add(lineSeries);
				this.radChartView1.Series.Add(barSeries);
				this.FillColors(this.radChartView1.View, KnownPalette.Grayscale);
				CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
				area.ShowGrid = true;
				CartesianGrid grid = area.GetGrid<CartesianGrid>();
				grid.DrawHorizontalStripes = true;
				barSeries.LabelMode = 1;
			}
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x001B0E28 File Offset: 0x001AF028
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.select_pareto_disponibilite();
			}
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x001B0E50 File Offset: 0x001AF050
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.select_pareto_fiabilite();
			}
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x001B0E78 File Offset: 0x001AF078
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.select_pareto_maintenabilite();
			}
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x001B0EA0 File Offset: 0x001AF0A0
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton5.IsChecked;
			if (isChecked)
			{
				this.panel2.Visible = true;
			}
			else
			{
				this.radTextBox1.Clear();
				this.radTextBox2.Clear();
				this.radTextBox3.Clear();
				this.panel2.Visible = false;
			}
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x001B0F01 File Offset: 0x001AF101
		private void radButton1_Click(object sender, EventArgs e)
		{
			this.select_pareto_combine();
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x001B0F0C File Offset: 0x001AF10C
		private void select_pareto_combine()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.radTextBox1.Text) & fonction.is_reel(this.radTextBox2.Text) & fonction.is_reel(this.radTextBox3.Text);
			if (flag)
			{
				bool flag2 = Convert.ToDouble(this.radTextBox1.Text) >= 0.0 & Convert.ToDouble(this.radTextBox2.Text) >= 0.0 & Convert.ToDouble(this.radTextBox3.Text) >= 0.0;
				if (flag2)
				{
					string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
					string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.organe e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.organe = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select ((@v1 * count(i) + @v2 * sum(d) + @v3 * avg(d)*count(i)) * 100) / (select @v1*count(i) + @v2 * sum(d) + @v3 * sum(d) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot, @v1 * count(i) + @v2 * sum(d) + @v3 * avg(d) from temporaire  group by e,c,desi order by @v1 * count(i) + @v2 * sum(d) + @v3 * avg(d)*count(i) desc";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
					sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
					sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
					sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
					sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.radTextBox1.Text;
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.radTextBox2.Text;
					sqlCommand.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.radTextBox3.Text;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
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
						linearAxis.Title = "Nombre des OT";
						linearAxis2.Title = "Pourcentage cumulée";
						barSeries.VerticalAxis = linearAxis;
						barSeries.HorizontalAxis = categoricalAxis;
						lineSeries.HorizontalAxis = categoricalAxis;
						lineSeries.VerticalAxis = linearAxis2;
						lineSeries.Spline = true;
						double num = 0.0;
						double num2 = 0.0;
						for (int i = 0; i < dataTable.Rows.Count; i++)
						{
							double num3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[7]);
							num2 = num3 + num2;
							bool flag4 = num <= 80.0;
							if (!flag4)
							{
								double value = (100.0 - num) * num2 / num;
								barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(value), 2), "Autres"));
								break;
							}
							barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num3), 2), dataTable.Rows[i].ItemArray[2].ToString()));
							num += Convert.ToDouble(dataTable.Rows[i].ItemArray[0].ToString());
							lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num), 2), dataTable.Rows[i].ItemArray[2].ToString()));
						}
						lineSeries.DataPoints.Add(new CategoricalDataPoint(100.0, "Autres"));
						this.radChartView1.Series.Add(lineSeries);
						this.radChartView1.Series.Add(barSeries);
						this.FillColors(this.radChartView1.View, KnownPalette.Grayscale);
						CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
						area.ShowGrid = true;
						CartesianGrid grid = area.GetGrid<CartesianGrid>();
						grid.DrawHorizontalStripes = true;
						barSeries.LabelMode = 1;
					}
				}
				else
				{
					MessageBox.Show("Erreur : Les poids sont des réels positifs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Les poids sont des réels positifs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
