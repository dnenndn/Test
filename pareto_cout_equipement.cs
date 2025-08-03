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
	// Token: 0x020000F6 RID: 246
	public partial class pareto_cout_equipement : Form
	{
		// Token: 0x06000AB7 RID: 2743 RVA: 0x001A3EE8 File Offset: 0x001A20E8
		public pareto_cout_equipement()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(pareto_cout_equipement.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(pareto_cout_equipement.select_changee);
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x001A3FA0 File Offset: 0x001A21A0
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

		// Token: 0x06000AB9 RID: 2745 RVA: 0x001A4024 File Offset: 0x001A2224
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

		// Token: 0x06000ABA RID: 2746 RVA: 0x001A4128 File Offset: 0x001A2328
		private void pareto_cout_equipement_Load(object sender, EventArgs e)
		{
			this.radDomainUpDown1.Text = "1";
			this.radDomainUpDown2.Text = "1";
			this.radDomainUpDown3.Text = "1";
			this.radDomainUpDown4.Text = "1";
			this.remplissage_graphique_equipement();
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x001A4184 File Offset: 0x001A2384
		public void select_cout_mo(List<int> id_ot)
		{
			bd bd = new bd();
			string text = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "";
			for (int i = 0; i < this.id_equipement.Count; i++)
			{
				double item = 0.0;
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ot in (" + text + ") and ordre_travail.statut = @s and equipement = @eq) ";
				}
				bool isChecked2 = this.radRadioButton4.IsChecked;
				if (isChecked2)
				{
					cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ot in (" + text + ") and ordre_travail.statut = @s and sous_equipement = @eq) ";
				}
				bool isChecked3 = this.radRadioButton5.IsChecked;
				if (isChecked3)
				{
					cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ot in (" + text + ") and ordre_travail.statut = @s and organe = @eq) ";
				}
				bool isChecked4 = this.radRadioButton2.IsChecked;
				if (isChecked4)
				{
					cmdText = string.Concat(new string[]
					{
						"select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ot in (",
						text,
						") and ordre_travail.statut = @s and equipement in (",
						this.liste_z[i],
						")) "
					});
				}
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_equipement[i];
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

		// Token: 0x06000ABC RID: 2748 RVA: 0x001A4374 File Offset: 0x001A2574
		public void select_cout_pdr(List<int> id_ot)
		{
			bd bd = new bd();
			string text = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "";
			for (int i = 0; i < this.id_equipement.Count; i++)
			{
				double item = 0.0;
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + text + ") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s and equipement = @eq";
				}
				bool isChecked2 = this.radRadioButton4.IsChecked;
				if (isChecked2)
				{
					cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + text + ") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s and sous_equipement = @eq";
				}
				bool isChecked3 = this.radRadioButton5.IsChecked;
				if (isChecked3)
				{
					cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + text + ") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s and organe = @eq";
				}
				bool isChecked4 = this.radRadioButton2.IsChecked;
				if (isChecked4)
				{
					cmdText = string.Concat(new string[]
					{
						"select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (",
						text,
						") and type_stock <> @v and bsm_article.quantite <> @d and ordre_travail.statut = @s and equipement in (",
						this.liste_z[i],
						") "
					});
				}
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
				sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_equipement[i];
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

		// Token: 0x06000ABD RID: 2749 RVA: 0x001A45A0 File Offset: 0x001A27A0
		public void select_cout_reparation_externe(List<int> id_ot)
		{
			bd bd = new bd();
			string text = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "";
			for (int i = 0; i < this.id_equipement.Count; i++)
			{
				double item = 0.0;
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id   where  ot_bl.id_ot in (" + text + ") and ordre_travail.statut = @s and equipement = @eq";
				}
				bool isChecked2 = this.radRadioButton4.IsChecked;
				if (isChecked2)
				{
					cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id   where  ot_bl.id_ot in (" + text + ") and ordre_travail.statut = @s and sous_equipement = @eq";
				}
				bool isChecked3 = this.radRadioButton5.IsChecked;
				if (isChecked3)
				{
					cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id   where  ot_bl.id_ot in (" + text + ") and ordre_travail.statut = @s and organe = @eq";
				}
				bool isChecked4 = this.radRadioButton2.IsChecked;
				if (isChecked4)
				{
					cmdText = string.Concat(new string[]
					{
						"select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id   where  ot_bl.id_ot in (",
						text,
						") and ordre_travail.statut = @s and equipement in (",
						this.liste_z[i],
						")"
					});
				}
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_equipement[i];
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

		// Token: 0x06000ABE RID: 2750 RVA: 0x001A4790 File Offset: 0x001A2990
		public void select_cout_projet(List<int> id_ot)
		{
			bd bd = new bd();
			string text = string.Join<int>(",", id_ot.ToArray());
			for (int i = 0; i < this.id_equipement.Count; i++)
			{
				double item = 0.0;
				string cmdText = "";
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					cmdText = "select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + text + ") and ordre_travail.statut = @s and equipement = @eq";
				}
				bool isChecked2 = this.radRadioButton4.IsChecked;
				if (isChecked2)
				{
					cmdText = "select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + text + ") and ordre_travail.statut = @s and sous_equipement = @eq";
				}
				bool isChecked3 = this.radRadioButton5.IsChecked;
				if (isChecked3)
				{
					cmdText = "select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + text + ") and ordre_travail.statut = @s and organe = @eq";
				}
				bool isChecked4 = this.radRadioButton2.IsChecked;
				if (isChecked4)
				{
					cmdText = string.Concat(new string[]
					{
						"select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (",
						text,
						") and ordre_travail.statut = @s and equipement in (",
						this.liste_z[i],
						") "
					});
				}
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@eq", SqlDbType.Int).Value = this.id_equipement[i];
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

		// Token: 0x06000ABF RID: 2751 RVA: 0x001A4984 File Offset: 0x001A2B84
		private void list_equipement()
		{
			bd bd = new bd();
			this.id_equipement.Clear();
			this.code_equipement.Clear();
			this.cout_projet.Clear();
			this.cout_pdr.Clear();
			this.cout_mo.Clear();
			this.cout_externe.Clear();
			this.cout_total.Clear();
			string cmdText = "";
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				cmdText = "select distinct ordre_travail.equipement, equipement.code from ordre_travail inner join equipement on ordre_travail.equipement = equipement.id where ordre_travail.id in (" + str + ")";
			}
			bool isChecked2 = this.radRadioButton4.IsChecked;
			if (isChecked2)
			{
				cmdText = "select distinct ordre_travail.sous_equipement, equipement.code from ordre_travail inner join equipement on ordre_travail.sous_equipement = equipement.id where ordre_travail.id in (" + str + ")";
			}
			bool isChecked3 = this.radRadioButton5.IsChecked;
			if (isChecked3)
			{
				cmdText = "select distinct ordre_travail.organe, equipement.code from ordre_travail inner join equipement on ordre_travail.organe = equipement.id where ordre_travail.id in (" + str + ")";
			}
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.id_equipement.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0].ToString()));
					this.code_equipement.Add(Convert.ToString(dataTable.Rows[i].ItemArray[1].ToString()));
				}
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x001A4B2C File Offset: 0x001A2D2C
		private void remplissage_graphique_equipement()
		{
			bool flag = !this.radRadioButton2.IsChecked;
			if (flag)
			{
				this.list_equipement();
			}
			else
			{
				this.liste_zone();
			}
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
			for (int i = 0; i < this.id_equipement.Count; i++)
			{
				double num6 = (double)num * this.cout_mo[i] + (double)num2 * this.cout_pdr[i] + (double)num3 * this.cout_externe[i] + (double)num4 * this.cout_projet[i];
				this.cout_total.Add(num6);
				num5 += num6;
			}
			this.tri_tableau();
			double num7 = 0.0;
			for (int j = 0; j < this.id_equipement.Count; j++)
			{
				double num8 = this.cout_total[j];
				num7 += num8 / num5 * 100.0;
				bool flag2 = num8 != 0.0;
				if (flag2)
				{
					barSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num8), 2), this.code_equipement[j]));
					lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(num7), 2), this.code_equipement[j]));
				}
			}
			this.radChartView1.Series.Add(lineSeries);
			this.radChartView1.Series.Add(barSeries);
			this.FillColors(this.radChartView1.View, KnownPalette.Material);
			CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
			area.ShowGrid = true;
			CartesianGrid grid = area.GetGrid<CartesianGrid>();
			grid.DrawHorizontalStripes = true;
			barSeries.LabelMode = 1;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x001A4E98 File Offset: 0x001A3098
		private void remplissage_tableau_equipement()
		{
			bool flag = !this.radRadioButton2.IsChecked;
			if (flag)
			{
				this.list_equipement();
			}
			else
			{
				this.liste_zone();
			}
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
			for (int i = 0; i < this.id_equipement.Count; i++)
			{
				double num6 = (double)num * this.cout_mo[i] + (double)num2 * this.cout_pdr[i] + (double)num3 * this.cout_externe[i] + (double)num4 * this.cout_projet[i];
				this.cout_total.Add(num6);
				num5 += num6;
			}
			this.tri_tableau();
			this.radGridView3.Rows.Clear();
			double num7 = 0.0;
			for (int j = 0; j < this.id_equipement.Count; j++)
			{
				double num8 = (double)num * this.cout_mo[j] + (double)num2 * this.cout_pdr[j] + (double)num3 * this.cout_externe[j] + (double)num4 * this.cout_projet[j];
				double num9 = num8 / num5 * 100.0;
				num7 = num9 + num7;
				bool flag2 = num8 != 0.0;
				if (flag2)
				{
					bool flag3 = j != this.id_equipement.Count - 1;
					if (flag3)
					{
						this.radGridView3.Rows.Add(new object[]
						{
							this.code_equipement[j],
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
							this.code_equipement[j],
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

		// Token: 0x06000AC2 RID: 2754 RVA: 0x001A52A7 File Offset: 0x001A34A7
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x001A52BC File Offset: 0x001A34BC
		private void tri_tableau()
		{
			bool flag = this.code_equipement.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.code_equipement.Count; i++)
				{
					for (int j = 0; j < this.code_equipement.Count - 1; j++)
					{
						bool flag2 = this.cout_total[j] < this.cout_total[j + 1];
						if (flag2)
						{
							double value = this.cout_total[j];
							double value2 = this.cout_mo[j];
							double value3 = this.cout_pdr[j];
							double value4 = this.cout_externe[j];
							double value5 = this.cout_projet[j];
							string value6 = this.code_equipement[j];
							this.cout_total[j] = this.cout_total[j + 1];
							this.cout_mo[j] = this.cout_mo[j + 1];
							this.cout_pdr[j] = this.cout_pdr[j + 1];
							this.cout_externe[j] = this.cout_externe[j + 1];
							this.cout_projet[j] = this.cout_projet[j + 1];
							this.code_equipement[j] = this.code_equipement[j + 1];
							this.cout_total[j + 1] = value;
							this.code_equipement[j + 1] = value6;
							this.cout_mo[j + 1] = value2;
							this.cout_pdr[j + 1] = value3;
							this.cout_externe[j + 1] = value4;
							this.cout_projet[j + 1] = value5;
						}
					}
				}
			}
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x001A54AC File Offset: 0x001A36AC
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				bool isChecked2 = this.radRadioButton7.IsChecked;
				if (isChecked2)
				{
					this.remplissage_graphique_equipement();
				}
				else
				{
					this.remplissage_tableau_equipement();
				}
			}
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x001A54F0 File Offset: 0x001A36F0
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				bool isChecked2 = this.radRadioButton7.IsChecked;
				if (isChecked2)
				{
					this.remplissage_graphique_equipement();
				}
				else
				{
					this.remplissage_tableau_equipement();
				}
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x001A5534 File Offset: 0x001A3734
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton5.IsChecked;
			if (isChecked)
			{
				bool isChecked2 = this.radRadioButton7.IsChecked;
				if (isChecked2)
				{
					this.remplissage_graphique_equipement();
				}
				else
				{
					this.remplissage_tableau_equipement();
				}
			}
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x001A5578 File Offset: 0x001A3778
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

		// Token: 0x06000AC8 RID: 2760 RVA: 0x001A5654 File Offset: 0x001A3854
		private void liste_zone()
		{
			bd bd = new bd();
			this.id_equipement.Clear();
			this.code_equipement.Clear();
			this.cout_projet.Clear();
			this.cout_pdr.Clear();
			this.cout_mo.Clear();
			this.cout_externe.Clear();
			this.cout_total.Clear();
			this.liste_z.Clear();
			string cmdText = "select id, code from equipement where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ordre_travail.id_atelier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					List<int> list = new List<int>();
					this.telecharger_tous_id_enfant(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]), list);
					string item = string.Join<int>(",", list.ToArray());
					this.liste_z.Add(item);
					this.id_equipement.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
					this.code_equipement.Add(dataTable.Rows[i].ItemArray[1].ToString());
				}
			}
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x001A580C File Offset: 0x001A3A0C
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_equipement();
			}
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x001A5834 File Offset: 0x001A3A34
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton8.IsChecked;
			if (isChecked)
			{
				this.remplissage_tableau_equipement();
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x001A585C File Offset: 0x001A3A5C
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				bool isChecked2 = this.radRadioButton7.IsChecked;
				if (isChecked2)
				{
					this.remplissage_graphique_equipement();
				}
				else
				{
					this.remplissage_tableau_equipement();
				}
			}
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x001A58A0 File Offset: 0x001A3AA0
		private void radDomainUpDown1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_equipement();
			}
			else
			{
				this.remplissage_tableau_equipement();
			}
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x001A58D4 File Offset: 0x001A3AD4
		private void radDomainUpDown2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_equipement();
			}
			else
			{
				this.remplissage_tableau_equipement();
			}
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x001A5908 File Offset: 0x001A3B08
		private void radDomainUpDown3_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_equipement();
			}
			else
			{
				this.remplissage_tableau_equipement();
			}
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x001A593C File Offset: 0x001A3B3C
		private void radDomainUpDown4_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.remplissage_graphique_equipement();
			}
			else
			{
				this.remplissage_tableau_equipement();
			}
		}

		// Token: 0x04000DC1 RID: 3521
		private List<int> id_equipement = new List<int>();

		// Token: 0x04000DC2 RID: 3522
		private List<string> code_equipement = new List<string>();

		// Token: 0x04000DC3 RID: 3523
		private List<string> liste_z = new List<string>();

		// Token: 0x04000DC4 RID: 3524
		private List<double> cout_mo = new List<double>();

		// Token: 0x04000DC5 RID: 3525
		private List<double> cout_pdr = new List<double>();

		// Token: 0x04000DC6 RID: 3526
		private List<double> cout_externe = new List<double>();

		// Token: 0x04000DC7 RID: 3527
		private List<double> cout_projet = new List<double>();

		// Token: 0x04000DC8 RID: 3528
		private List<double> cout_total = new List<double>();
	}
}
