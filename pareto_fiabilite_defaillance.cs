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
	// Token: 0x020000FC RID: 252
	public partial class pareto_fiabilite_defaillance : Form
	{
		// Token: 0x06000B0C RID: 2828 RVA: 0x001ACA15 File Offset: 0x001AAC15
		public pareto_fiabilite_defaillance()
		{
			this.InitializeComponent();
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x001ACA3C File Offset: 0x001AAC3C
		private void pareto_fiabilite_defaillance_Load(object sender, EventArgs e)
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

		// Token: 0x06000B0E RID: 2830 RVA: 0x001ACAC0 File Offset: 0x001AACC0
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.select_pareto_disponibilite();
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x001ACAE8 File Offset: 0x001AACE8
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.select_pareto_fiabilite();
			}
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x001ACB10 File Offset: 0x001AAD10
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.select_pareto_maintenabilite();
			}
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x001ACB38 File Offset: 0x001AAD38
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

		// Token: 0x06000B12 RID: 2834 RVA: 0x001ACB99 File Offset: 0x001AAD99
		private void radButton1_Click(object sender, EventArgs e)
		{
			this.select_pareto_combine();
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x001ACBA4 File Offset: 0x001AADA4
		private void select_pareto_disponibilite()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.id_defaillance e, parametre_anomalie.code c, parametre_anomalie.anomalie desi  from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select (sum(d) * 100) / (select sum(d) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot from temporaire  group by e,c,desi order by sum(d) desc";
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
				this.FillColors(this.radChartView1.View, KnownPalette.Ground);
				CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
				area.ShowGrid = true;
				CartesianGrid grid = area.GetGrid<CartesianGrid>();
				grid.DrawHorizontalStripes = true;
				barSeries.LabelMode = 1;
			}
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x001ACF71 File Offset: 0x001AB171
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x001ACF84 File Offset: 0x001AB184
		private void select_pareto_maintenabilite()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.id_defaillance e, parametre_anomalie.code c, parametre_anomalie.anomalie desi from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select (avg(d) * count(i) * 100) / (select sum(d) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot from temporaire  group by e,c,desi order by avg(d) desc";
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
				this.FillColors(this.radChartView1.View, KnownPalette.Ground);
				CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
				area.ShowGrid = true;
				CartesianGrid grid = area.GetGrid<CartesianGrid>();
				grid.DrawHorizontalStripes = true;
				barSeries.LabelMode = 1;
			}
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x001AD354 File Offset: 0x001AB554
		private void select_pareto_fiabilite()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.id_defaillance e, parametre_anomalie.code c, parametre_anomalie.anomalie desi from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select (count(i) * 100) / (select count(i) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot from temporaire  group by e,c,desi order by count(i) desc";
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
				this.FillColors(this.radChartView1.View, KnownPalette.Ground);
				CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
				area.ShowGrid = true;
				CartesianGrid grid = area.GetGrid<CartesianGrid>();
				grid.DrawHorizontalStripes = true;
				barSeries.LabelMode = 1;
			}
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x001AD708 File Offset: 0x001AB908
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
					string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.id_defaillance e, parametre_anomalie.code c, parametre_anomalie.anomalie desi from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select ((@v1 * count(i) + @v2 * sum(d) + @v3 * avg(d)*count(i)) * 100) / (select @v1*count(i) + @v2 * sum(d) + @v3 * sum(d) from temporaire), e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot, @v1 * count(i) + @v2 * sum(d) + @v3 * avg(d) from temporaire  group by e,c,desi order by @v1 * count(i) + @v2 * sum(d) + @v3 * avg(d)*count(i) desc";
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
						this.FillColors(this.radChartView1.View, KnownPalette.Ground);
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
