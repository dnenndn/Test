using System;
using System.Collections.Generic;
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
	// Token: 0x02000100 RID: 256
	public partial class pareto_fiabilite_zone : Form
	{
		// Token: 0x06000B44 RID: 2884 RVA: 0x001B3A1C File Offset: 0x001B1C1C
		public pareto_fiabilite_zone()
		{
			this.InitializeComponent();
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x001B3A9C File Offset: 0x001B1C9C
		private void pareto_fiabilite_zone_Load(object sender, EventArgs e)
		{
			this.panel2.Visible = false;
			this.code_equipement.Clear();
			this.l_combine.Clear();
			this.l_mttr.Clear();
			this.l_ot.Clear();
			this.p_combine.Clear();
			this.p_mttr.Clear();
			this.p_ot.Clear();
			bool flag = ordre_travail.id_atelier != 0;
			if (flag)
			{
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					this.select_pareto(1.0, 0.0, 0.0, "TTR");
				}
				bool isChecked2 = this.radRadioButton2.IsChecked;
				if (isChecked2)
				{
					this.select_pareto(0.0, 0.0, 1.0, "Nombre des OT");
				}
				bool isChecked3 = this.radRadioButton4.IsChecked;
				if (isChecked3)
				{
					this.select_pareto(0.0, 1.0, 0.0, "MTTR");
				}
				bool isChecked4 = this.radRadioButton5.IsChecked;
				if (isChecked4)
				{
					this.panel2.Visible = true;
				}
			}
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x001B3BE4 File Offset: 0x001B1DE4
		private void select_pareto(double p1, double p2, double p3, string titre)
		{
			this.radChartView1.Series.Clear();
			this.select_matrice(p1, p2, p3);
			bool flag = this.code_equipement.Count != 0;
			if (flag)
			{
				this.radChartView1.Axes.Clear();
				BarSeries barSeries = new BarSeries();
				LineSeries lineSeries = new LineSeries();
				LineSeries lineSeries2 = new LineSeries();
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
				lineSeries2.HorizontalAxis = categoricalAxis;
				lineSeries2.VerticalAxis = linearAxis2;
				linearAxis.Title = titre;
				linearAxis2.Title = "Pourcentage cumulée";
				lineSeries2.PointSize = new Size(10, 10);
				barSeries.VerticalAxis = linearAxis;
				barSeries.HorizontalAxis = categoricalAxis;
				lineSeries.HorizontalAxis = categoricalAxis;
				lineSeries.VerticalAxis = linearAxis2;
				lineSeries.Spline = true;
				double num = 0.0;
				for (int i = 0; i < this.code_equipement.Count; i++)
				{
					double value = this.l_combine[i];
					double num2 = this.p_combine[i];
					barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(value), 2), this.code_equipement[i]));
					num += num2;
					lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num), 2), this.code_equipement[i]));
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
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x001B3E36 File Offset: 0x001B2036
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x001B3E4C File Offset: 0x001B204C
		private void select_pareto_combine()
		{
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.radTextBox1.Text) & fonction.is_reel(this.radTextBox2.Text) & fonction.is_reel(this.radTextBox3.Text);
			if (flag)
			{
				bool flag2 = Convert.ToDouble(this.radTextBox1.Text) >= 0.0 & Convert.ToDouble(this.radTextBox2.Text) >= 0.0 & Convert.ToDouble(this.radTextBox3.Text) >= 0.0;
				if (flag2)
				{
					double p = Convert.ToDouble(this.radTextBox1.Text);
					double p2 = Convert.ToDouble(this.radTextBox3.Text);
					double p3 = Convert.ToDouble(this.radTextBox2.Text);
					this.select_pareto(p, p2, p3, "Combinaison");
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

		// Token: 0x06000B49 RID: 2889 RVA: 0x001B3F74 File Offset: 0x001B2174
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

		// Token: 0x06000B4A RID: 2890 RVA: 0x001B3FD8 File Offset: 0x001B21D8
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool flag = ordre_travail.id_atelier != 0;
			if (flag)
			{
				this.select_pareto(1.0, 0.0, 0.0, "TTR");
			}
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x001B401C File Offset: 0x001B221C
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool flag = ordre_travail.id_atelier != 0;
			if (flag)
			{
				this.select_pareto(0.0, 0.0, 1.0, "Nombre des OT");
			}
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x001B4060 File Offset: 0x001B2260
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool flag = ordre_travail.id_atelier != 0;
			if (flag)
			{
				this.select_pareto(0.0, 1.0, 0.0, "MTTR");
			}
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x001B40A4 File Offset: 0x001B22A4
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = ordre_travail.id_atelier != 0;
			if (flag)
			{
				this.select_pareto_combine();
			}
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x001B40C8 File Offset: 0x001B22C8
		private void select_matrice(double poid1, double poid2, double poid3)
		{
			bd bd = new bd();
			this.code_equipement.Clear();
			this.l_combine.Clear();
			this.l_mttr.Clear();
			this.l_ot.Clear();
			this.p_combine.Clear();
			this.p_mttr.Clear();
			this.p_ot.Clear();
			string cmdText = "select id, code from equipement where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ordre_travail.id_atelier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string text = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					List<int> list = new List<int>();
					this.telecharger_tous_id_enfant(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]), list);
					string text2 = string.Join<int>(",", list.ToArray());
					string cmdText2 = string.Concat(new string[]
					{
						"with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.equipement e, equipement.code c, equipement.designation, equipement.deleted desi from ordre_travail inner join equipement on ordre_travail.equipement = equipement.id where ordre_travail.id in (",
						text,
						") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%' and ordre_travail.equipement in (",
						text2,
						") ) select sum(d) ttr,avg(d) mttr, count(i) nbre_ot, datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d) tbf,case datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d) when 0 then (datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d))/(count(i)) else   (datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d))/(count(i) - 1) end  mtbf  from temporaire group by desi "
					});
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
					sqlCommand2.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
					sqlCommand2.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
					sqlCommand2.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						double num2 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
						double num3 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[1]);
						int num4 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[2]);
						string item = dataTable.Rows[i].ItemArray[1].ToString();
						this.code_equipement.Add(item);
						double num5 = num2 * poid1 + num3 * poid2 + (double)num4 * poid3;
						this.l_combine.Add(num5);
						num += num5;
					}
				}
				for (int j = 0; j < this.code_equipement.Count; j++)
				{
					this.p_combine.Add(this.l_combine[j] / num * 100.0);
				}
				this.tri_tableau();
			}
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x001B4414 File Offset: 0x001B2614
		private void telecharger_tous_id_enfant(int id_prn, List<int> l)
		{
			bd bd = new bd();
			l.Add(id_prn);
			string cmdText = "select id from equipement where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_prn;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.telecharger_tous_id_enfant(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]), l);
				}
			}
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x001B44F0 File Offset: 0x001B26F0
		private void tri_tableau()
		{
			bool flag = this.code_equipement.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.code_equipement.Count; i++)
				{
					for (int j = 0; j < this.code_equipement.Count - 1; j++)
					{
						bool flag2 = this.l_combine[j] < this.l_combine[j + 1];
						if (flag2)
						{
							double value = this.l_combine[j];
							double value2 = this.p_combine[j];
							string value3 = this.code_equipement[j];
							this.l_combine[j] = this.l_combine[j + 1];
							this.p_combine[j] = this.p_combine[j + 1];
							this.code_equipement[j] = this.code_equipement[j + 1];
							this.l_combine[j + 1] = value;
							this.p_combine[j + 1] = value2;
							this.code_equipement[j + 1] = value3;
						}
					}
				}
			}
		}

		// Token: 0x04000E5C RID: 3676
		private List<string> code_equipement = new List<string>();

		// Token: 0x04000E5D RID: 3677
		private List<double> l_combine = new List<double>();

		// Token: 0x04000E5E RID: 3678
		private List<double> l_mttr = new List<double>();

		// Token: 0x04000E5F RID: 3679
		private List<double> l_ot = new List<double>();

		// Token: 0x04000E60 RID: 3680
		private List<double> p_combine = new List<double>();

		// Token: 0x04000E61 RID: 3681
		private List<double> p_mttr = new List<double>();

		// Token: 0x04000E62 RID: 3682
		private List<double> p_ot = new List<double>();
	}
}
