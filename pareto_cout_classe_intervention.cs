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
	// Token: 0x020000F4 RID: 244
	public partial class pareto_cout_classe_intervention : Form
	{
		// Token: 0x06000A8D RID: 2701 RVA: 0x0019F8D0 File Offset: 0x0019DAD0
		public pareto_cout_classe_intervention()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(pareto_cout_classe_intervention.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(pareto_cout_classe_intervention.select_changee);
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x0019F980 File Offset: 0x0019DB80
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

		// Token: 0x06000A8F RID: 2703 RVA: 0x0019FA04 File Offset: 0x0019DC04
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

		// Token: 0x06000A90 RID: 2704 RVA: 0x0019FB08 File Offset: 0x0019DD08
		private void pareto_cout_classe_intervention_Load(object sender, EventArgs e)
		{
			this.radDomainUpDown1.Text = "1";
			this.radDomainUpDown2.Text = "1";
			this.radDomainUpDown3.Text = "1";
			this.radDomainUpDown4.Text = "1";
			this.remplissage_graphique_classe();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0019FB64 File Offset: 0x0019DD64
		public void select_cout_mo(List<int> id_ot)
		{
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			for (int i = 0; i < this.id_classe.Count; i++)
			{
				double item = 0.0;
				string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ot in (" + str + ") and ordre_travail.statut = @s and id_classe = @eq) ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_classe[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					fonction fonction = new fonction();
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
					if (flag2)
					{
						item = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
					}
				}
				this.cout_mo.Add(item);
			}
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0019FCB0 File Offset: 0x0019DEB0
		public void select_cout_pdr(List<int> id_ot)
		{
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			for (int i = 0; i < this.id_classe.Count; i++)
			{
				double item = 0.0;
				string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s and id_classe = @eq";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
				sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_classe[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					fonction fonction = new fonction();
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
					if (flag2)
					{
						item = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
					}
				}
				this.cout_pdr.Add(item);
			}
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0019FE38 File Offset: 0x0019E038
		public void select_cout_reparation_externe(List<int> id_ot)
		{
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			for (int i = 0; i < this.id_classe.Count; i++)
			{
				double item = 0.0;
				string cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id   where  ot_bl.id_ot in (" + str + ") and ordre_travail.statut = @s and id_classe = @eq";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_classe[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					fonction fonction = new fonction();
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
					if (flag2)
					{
						item = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
					}
				}
				this.cout_externe.Add(item);
			}
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0019FF84 File Offset: 0x0019E184
		public void select_cout_projet(List<int> id_ot)
		{
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			for (int i = 0; i < this.id_classe.Count; i++)
			{
				double item = 0.0;
				string cmdText = "select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + str + ") and ordre_travail.statut = @s and id_classe = @eq";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_classe[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					fonction fonction = new fonction();
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
					if (flag2)
					{
						item = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
					}
				}
				this.cout_projet.Add(item);
			}
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x001A00D0 File Offset: 0x0019E2D0
		private void list_classe()
		{
			bd bd = new bd();
			this.id_classe.Clear();
			this.des_classe.Clear();
			this.cout_projet.Clear();
			this.cout_pdr.Clear();
			this.cout_mo.Clear();
			this.cout_externe.Clear();
			this.cout_total.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct ordre_travail.id_classe, parametre_classe_intervention.designation from ordre_travail inner join parametre_classe_intervention on ordre_travail.id_classe = parametre_classe_intervention.id where ordre_travail.id in (" + str + ")";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.id_classe.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0].ToString()));
					this.des_classe.Add(Convert.ToString(dataTable.Rows[i].ItemArray[1].ToString()));
				}
			}
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x001A021C File Offset: 0x0019E41C
		private void remplissage_graphique_classe()
		{
			this.list_classe();
			this.radGridView3.Hide();
			this.radChartView1.Show();
			this.radChartView1.Series.Clear();
			int num = Convert.ToInt32(this.radDomainUpDown1.Text);
			int num2 = Convert.ToInt32(this.radDomainUpDown2.Text);
			int num3 = Convert.ToInt32(this.radDomainUpDown3.Text);
			int num4 = Convert.ToInt32(this.radDomainUpDown4.Text);
			this.select_cout_mo(ordre_travail.id_ort);
			this.select_cout_pdr(ordre_travail.id_ort);
			this.select_cout_reparation_externe(ordre_travail.id_ort);
			this.select_cout_projet(ordre_travail.id_ort);
			double num5 = 0.0;
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
			for (int i = 0; i < this.id_classe.Count; i++)
			{
				double num6 = (double)num * this.cout_mo[i] + (double)num2 * this.cout_pdr[i] + (double)num3 * this.cout_externe[i] + (double)num4 * this.cout_projet[i];
				this.cout_total.Add(num6);
				num5 += num6;
			}
			this.tri_tableau();
			double num7 = 0.0;
			for (int j = 0; j < this.id_classe.Count; j++)
			{
				double num8 = this.cout_total[j];
				num7 += num8 / num5 * 100.0;
				bool flag = num8 != 0.0;
				if (flag)
				{
					barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num8), 2), this.des_classe[j]));
					lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num7), 2), this.des_classe[j]));
				}
			}
			this.radChartView1.Series.Add(lineSeries);
			this.radChartView1.Series.Add(barSeries);
			this.FillColors(this.radChartView1.View, KnownPalette.Windows8);
			CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
			area.ShowGrid = true;
			CartesianGrid grid = area.GetGrid<CartesianGrid>();
			grid.DrawHorizontalStripes = true;
			barSeries.LabelMode = 1;
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x001A0568 File Offset: 0x0019E768
		private void remplissage_tableau_classe()
		{
			this.list_classe();
			this.radChartView1.Hide();
			this.radGridView3.Show();
			this.radChartView1.Series.Clear();
			int num = Convert.ToInt32(this.radDomainUpDown1.Text);
			int num2 = Convert.ToInt32(this.radDomainUpDown2.Text);
			int num3 = Convert.ToInt32(this.radDomainUpDown3.Text);
			int num4 = Convert.ToInt32(this.radDomainUpDown4.Text);
			this.select_cout_mo(ordre_travail.id_ort);
			this.select_cout_pdr(ordre_travail.id_ort);
			this.select_cout_reparation_externe(ordre_travail.id_ort);
			this.select_cout_projet(ordre_travail.id_ort);
			double num5 = 0.0;
			for (int i = 0; i < this.id_classe.Count; i++)
			{
				double num6 = (double)num * this.cout_mo[i] + (double)num2 * this.cout_pdr[i] + (double)num3 * this.cout_externe[i] + (double)num4 * this.cout_projet[i];
				this.cout_total.Add(num6);
				num5 += num6;
			}
			this.tri_tableau();
			this.radGridView3.Rows.Clear();
			double num7 = 0.0;
			for (int j = 0; j < this.id_classe.Count; j++)
			{
				double num8 = (double)num * this.cout_mo[j] + (double)num2 * this.cout_pdr[j] + (double)num3 * this.cout_externe[j] + (double)num4 * this.cout_projet[j];
				double num9 = num8 / num5 * 100.0;
				num7 = num9 + num7;
				bool flag = num8 != 0.0;
				if (flag)
				{
					bool flag2 = j != this.id_classe.Count - 1;
					if (flag2)
					{
						this.radGridView3.Rows.Add(new object[]
						{
							this.des_classe[j],
							((double)num * this.cout_mo[j]).ToString("0.000"),
							((double)num2 * this.cout_pdr[j]).ToString("0.000"),
							((double)num3 * this.cout_externe[j]).ToString("0.000"),
							((double)num4 * this.cout_projet[j]).ToString("0.000"),
							this.cout_total[j].ToString("0.000"),
							Math.Round(num9, 2),
							Math.Round(num7, 2)
						});
					}
					else
					{
						this.radGridView3.Rows.Add(new object[]
						{
							this.des_classe[j],
							((double)num * this.cout_mo[j]).ToString("0.000"),
							((double)num2 * this.cout_pdr[j]).ToString("0.000"),
							((double)num3 * this.cout_externe[j]).ToString("0.000"),
							((double)num4 * this.cout_projet[j]).ToString("0.000"),
							this.cout_total[j].ToString("0.000"),
							Math.Round(num9, 2),
							100
						});
					}
				}
			}
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x001A0956 File Offset: 0x0019EB56
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x001A096C File Offset: 0x0019EB6C
		private void tri_tableau()
		{
			bool flag = this.des_classe.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.des_classe.Count; i++)
				{
					for (int j = 0; j < this.des_classe.Count - 1; j++)
					{
						bool flag2 = this.cout_total[j] < this.cout_total[j + 1];
						if (flag2)
						{
							double value = this.cout_total[j];
							double value2 = this.cout_mo[j];
							double value3 = this.cout_pdr[j];
							double value4 = this.cout_externe[j];
							double value5 = this.cout_projet[j];
							string value6 = this.des_classe[j];
							this.cout_total[j] = this.cout_total[j + 1];
							this.cout_mo[j] = this.cout_mo[j + 1];
							this.cout_pdr[j] = this.cout_pdr[j + 1];
							this.cout_externe[j] = this.cout_externe[j + 1];
							this.cout_projet[j] = this.cout_projet[j + 1];
							this.des_classe[j] = this.des_classe[j + 1];
							this.cout_total[j + 1] = value;
							this.des_classe[j + 1] = value6;
							this.cout_mo[j + 1] = value2;
							this.cout_pdr[j + 1] = value3;
							this.cout_externe[j + 1] = value4;
							this.cout_projet[j + 1] = value5;
						}
					}
				}
			}
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x001A0B5C File Offset: 0x0019ED5C
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_classe();
			}
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x001A0B84 File Offset: 0x0019ED84
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton8.IsChecked;
			if (isChecked)
			{
				this.remplissage_tableau_classe();
			}
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x001A0BAC File Offset: 0x0019EDAC
		private void radDomainUpDown4_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_classe();
			}
			else
			{
				this.remplissage_tableau_classe();
			}
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x001A0BE0 File Offset: 0x0019EDE0
		private void radDomainUpDown3_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_classe();
			}
			else
			{
				this.remplissage_tableau_classe();
			}
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x001A0C14 File Offset: 0x0019EE14
		private void radDomainUpDown2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_classe();
			}
			else
			{
				this.remplissage_tableau_classe();
			}
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x001A0C48 File Offset: 0x0019EE48
		private void radDomainUpDown1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_classe();
			}
			else
			{
				this.remplissage_tableau_classe();
			}
		}

		// Token: 0x04000D91 RID: 3473
		private List<int> id_classe = new List<int>();

		// Token: 0x04000D92 RID: 3474
		private List<string> des_classe = new List<string>();

		// Token: 0x04000D93 RID: 3475
		private List<double> cout_mo = new List<double>();

		// Token: 0x04000D94 RID: 3476
		private List<double> cout_pdr = new List<double>();

		// Token: 0x04000D95 RID: 3477
		private List<double> cout_externe = new List<double>();

		// Token: 0x04000D96 RID: 3478
		private List<double> cout_projet = new List<double>();

		// Token: 0x04000D97 RID: 3479
		private List<double> cout_total = new List<double>();
	}
}
