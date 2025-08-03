using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000002 RID: 2
	public partial class acceuil_maintenance : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public acceuil_maintenance()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(acceuil_maintenance.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(acceuil_maintenance.select_changee);
			this.radChartView1.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020C6 File Offset: 0x000002C6
		private void RadChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020CC File Offset: 0x000002CC
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

		// Token: 0x06000004 RID: 4 RVA: 0x00002150 File Offset: 0x00000350
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

		// Token: 0x06000005 RID: 5 RVA: 0x00002254 File Offset: 0x00000454
		private void acceuil_maintenance_Load(object sender, EventArgs e)
		{
			this.id_atelier.Clear();
			this.id_atelier.Add(8);
			this.id_atelier.Add(9);
			this.id_atelier.Add(730);
			this.id_atelier.Add(39573);
			this.id_atelier.Add(42378);
			this.id_atelier.Add(17);
			this.id_atelier.Add(18);
			this.id_atelier.Add(19);
			this.select_prev_systematique();
			this.select_graphe();
			this.select_nbr_wagon();
			this.select_duree_anomalie();
			double num = this.select_consommation_fuel();
			string text = num.ToString();
			num *= 1000.0;
			double num2 = this.select_quantite_sortie_four();
			double num3 = 0.0;
			bool flag = num2 != 0.0;
			if (flag)
			{
				num3 = Math.Round(num / num2, 2);
			}
			this.label4.Text = text;
			bool flag2 = num3 != 0.0;
			if (flag2)
			{
				this.label5.Text = num3.ToString();
			}
			else
			{
				this.label5.Text = "-";
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000239C File Offset: 0x0000059C
		public void select_usine()
		{
			bd bd = new bd();
			string cmdText = "select photo_usine from parametre_image where photo_usine is not null ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
				MemoryStream memoryStream = new MemoryStream(buffer);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002418 File Offset: 0x00000618
		public void select_parc()
		{
			bd bd = new bd();
			string cmdText = "select photo_parc from parametre_image where photo_parc is not null ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
				MemoryStream memoryStream = new MemoryStream(buffer);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002494 File Offset: 0x00000694
		public void select_atelier()
		{
			bd bd = new bd();
			string cmdText = "select photo_atelier from parametre_image where photo_atelier is not null ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
				MemoryStream memoryStream = new MemoryStream(buffer);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002510 File Offset: 0x00000710
		public void select_prev_systematique()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select date_ech, gamme_operatoire.designation, equipement.designation from prev_syst_ech inner join prev_systematique on prev_syst_ech.id_rep = prev_systematique.id inner join equipement on prev_systematique.equipement = equipement.id inner join gamme_operatoire on prev_systematique.id_gamme = gamme_operatoire.id where equipement.deleted = @d and prev_syst_ech.deleted = @d and month(date_ech) = @m and year(date_ech) = @y order by date_ech";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString().Substring(0, 10),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
			}
			bool flag2 = this.radGridView3.Rows.Count != 0;
			if (flag2)
			{
				this.radGridView3.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000026B9 File Offset: 0x000008B9
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000026CC File Offset: 0x000008CC
		private void select_graphe()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.select_nbr_ot();
			}
			bool isChecked2 = this.radRadioButton2.IsChecked;
			if (isChecked2)
			{
				this.select_ttr_ot();
			}
			bool isChecked3 = this.radRadioButton4.IsChecked;
			if (isChecked3)
			{
				this.select_cout_ot();
			}
			this.radChartView1.View.Palette = KnownPalette.Flower;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002750 File Offset: 0x00000950
		private void select_nbr_ot()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.atelier e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.atelier = equipement.id where atelier in (" + str + ") and ordre_travail.statut <> @a and month(date_debut) = @m and year(date_debut) = @y and ordre_travail.type not like '%'  + @p + '%') select count(i) , e, desi  from temporaire  group by e,c,desi";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.atelier e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.atelier = equipement.id where atelier in (" + str + ") and ordre_travail.statut <> @a and month(date_debut) = @m and year(date_debut) = @y and ordre_travail.type  like '%'  + @p + '%') select count(i) , e, desi  from temporaire  group by e,c,desi";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand2.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand2.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand2.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand2.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			List<double> list = new List<double>();
			List<double> list2 = new List<double>();
			List<string> list3 = new List<string>();
			for (int i = 0; i < this.id_atelier.Count; i++)
			{
				list.Add(0.0);
				list2.Add(0.0);
				string cmdText3 = "select designation from equipement where id = @i";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.id_atelier[i];
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				string item = "";
				bool flag = dataTable3.Rows.Count != 0;
				if (flag)
				{
					item = dataTable3.Rows[0].ItemArray[0].ToString();
				}
				list3.Add(item);
			}
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				fonction fonction = new fonction();
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					bool flag3 = fonction.is_reel(Convert.ToString(dataTable.Rows[j].ItemArray[0]));
					if (flag3)
					{
						for (int k = 0; k < this.id_atelier.Count; k++)
						{
							bool flag4 = Convert.ToInt32(dataTable.Rows[j].ItemArray[1]) == this.id_atelier[k];
							if (flag4)
							{
								list[k] = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
							}
						}
					}
				}
				for (int l = 0; l < dataTable2.Rows.Count; l++)
				{
					bool flag5 = fonction.is_reel(Convert.ToString(dataTable2.Rows[l].ItemArray[0]));
					if (flag5)
					{
						for (int m = 0; m < this.id_atelier.Count; m++)
						{
							bool flag6 = Convert.ToInt32(dataTable2.Rows[l].ItemArray[1]) == this.id_atelier[m];
							if (flag6)
							{
								list2[m] = Convert.ToDouble(dataTable2.Rows[l].ItemArray[0]);
							}
						}
					}
				}
				BarSeries barSeries = new BarSeries();
				BarSeries barSeries2 = new BarSeries();
				barSeries.ShowLabels = true;
				barSeries2.ShowLabels = true;
				barSeries.LegendTitle = "Corrective";
				barSeries2.LegendTitle = "Préventive";
				for (int n = 0; n < this.id_atelier.Count; n++)
				{
					barSeries.DataPoints.Add(new CategoricalDataPoint(list[n], list3[n]));
					barSeries2.DataPoints.Add(new CategoricalDataPoint(list2[n], list3[n]));
				}
				this.radChartView1.Series.Add(barSeries);
				this.radChartView1.Series.Add(barSeries2);
				barSeries.CombineMode = 2;
				barSeries2.CombineMode = 2;
				this.radChartView1.ShowLegend = true;
				this.radChartView1.ShowTrackBall = true;
				bool flag7 = this.radChartView1.Axes.Count >= 1;
				if (flag7)
				{
					this.axisform_shown();
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002D58 File Offset: 0x00000F58
		private void select_ttr_ot()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.atelier e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.atelier = equipement.id where atelier in (" + str + ") and ordre_travail.statut <> @a and month(date_debut) = @m and year(date_debut) = @y and ordre_travail.type not like '%'  + @p + '%') select sum(d) , e, desi  from temporaire  group by e,c,desi";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.atelier e, equipement.code c, equipement.designation desi, equipement.deleted dl from ordre_travail inner join equipement on ordre_travail.atelier = equipement.id where atelier in (" + str + ") and ordre_travail.statut <> @a and month(date_debut) = @m and year(date_debut) = @y and ordre_travail.type  like '%'  + @p + '%') select sum(d) , e, desi  from temporaire  group by e,c,desi";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand2.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand2.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand2.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand2.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			List<double> list = new List<double>();
			List<double> list2 = new List<double>();
			List<string> list3 = new List<string>();
			for (int i = 0; i < this.id_atelier.Count; i++)
			{
				list.Add(0.0);
				list2.Add(0.0);
				string cmdText3 = "select designation from equipement where id = @i";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.id_atelier[i];
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				string item = "";
				bool flag = dataTable3.Rows.Count != 0;
				if (flag)
				{
					item = dataTable3.Rows[0].ItemArray[0].ToString();
				}
				list3.Add(item);
			}
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				fonction fonction = new fonction();
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					bool flag3 = fonction.is_reel(Convert.ToString(dataTable.Rows[j].ItemArray[0]));
					if (flag3)
					{
						for (int k = 0; k < this.id_atelier.Count; k++)
						{
							bool flag4 = Convert.ToInt32(dataTable.Rows[j].ItemArray[1]) == this.id_atelier[k];
							if (flag4)
							{
								list[k] = Convert.ToDouble(dataTable.Rows[j].ItemArray[0]);
							}
						}
					}
				}
				for (int l = 0; l < dataTable2.Rows.Count; l++)
				{
					bool flag5 = fonction.is_reel(Convert.ToString(dataTable2.Rows[l].ItemArray[0]));
					if (flag5)
					{
						for (int m = 0; m < this.id_atelier.Count; m++)
						{
							bool flag6 = Convert.ToInt32(dataTable2.Rows[l].ItemArray[1]) == this.id_atelier[m];
							if (flag6)
							{
								list2[m] = Convert.ToDouble(dataTable2.Rows[l].ItemArray[0]);
							}
						}
					}
				}
				BarSeries barSeries = new BarSeries();
				BarSeries barSeries2 = new BarSeries();
				barSeries.ShowLabels = true;
				barSeries2.ShowLabels = true;
				barSeries.LegendTitle = "Corrective";
				barSeries2.LegendTitle = "Préventive";
				for (int n = 0; n < this.id_atelier.Count; n++)
				{
					barSeries.DataPoints.Add(new CategoricalDataPoint(list[n], list3[n]));
					barSeries2.DataPoints.Add(new CategoricalDataPoint(list2[n], list3[n]));
				}
				this.radChartView1.Series.Add(barSeries);
				this.radChartView1.Series.Add(barSeries2);
				barSeries.CombineMode = 2;
				barSeries2.CombineMode = 2;
				this.radChartView1.ShowLegend = true;
				this.radChartView1.ShowTrackBall = true;
				bool flag7 = this.radChartView1.Axes.Count >= 1;
				if (flag7)
				{
					this.axisform_shown();
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00003360 File Offset: 0x00001560
		private void select_cout_ot()
		{
			bd bd = new bd();
			this.radChartView1.Series.Clear();
			DataTable dataTable = this.select_cout_mo_corrective();
			DataTable dataTable2 = this.select_cout_pdr_corrective();
			DataTable dataTable3 = this.select_cout_reparation_externe_corrective();
			DataTable dataTable4 = this.select_cout_projet_corrective();
			DataTable dataTable5 = this.select_cout_mo_preventive();
			DataTable dataTable6 = this.select_cout_pdr_preventive();
			DataTable dataTable7 = this.select_cout_reparation_externe_preventive();
			DataTable dataTable8 = this.select_cout_projet_preventive();
			DataTable dataTable9 = new DataTable();
			DataTable dataTable10 = new DataTable();
			dataTable9.Columns.Add("valeur", typeof(double));
			dataTable9.Columns.Add("atelier");
			dataTable10.Columns.Add("valeur", typeof(double));
			dataTable10.Columns.Add("atelier");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				dataTable9.Rows.Add(new object[]
				{
					dataTable.Rows[i].ItemArray[0],
					dataTable.Rows[i].ItemArray[1]
				});
			}
			for (int j = 0; j < dataTable2.Rows.Count; j++)
			{
				dataTable9.Rows.Add(new object[]
				{
					dataTable2.Rows[j].ItemArray[0],
					dataTable2.Rows[j].ItemArray[1]
				});
			}
			for (int k = 0; k < dataTable3.Rows.Count; k++)
			{
				dataTable9.Rows.Add(new object[]
				{
					dataTable3.Rows[k].ItemArray[0],
					dataTable3.Rows[k].ItemArray[1]
				});
			}
			for (int l = 0; l < dataTable4.Rows.Count; l++)
			{
				dataTable9.Rows.Add(new object[]
				{
					dataTable4.Rows[l].ItemArray[0],
					dataTable4.Rows[l].ItemArray[1]
				});
			}
			for (int m = 0; m < dataTable5.Rows.Count; m++)
			{
				dataTable10.Rows.Add(new object[]
				{
					dataTable5.Rows[m].ItemArray[0],
					dataTable5.Rows[m].ItemArray[1]
				});
			}
			for (int n = 0; n < dataTable6.Rows.Count; n++)
			{
				dataTable10.Rows.Add(new object[]
				{
					dataTable6.Rows[n].ItemArray[0],
					dataTable6.Rows[n].ItemArray[1]
				});
			}
			for (int num = 0; num < dataTable7.Rows.Count; num++)
			{
				dataTable10.Rows.Add(new object[]
				{
					dataTable7.Rows[num].ItemArray[0],
					dataTable7.Rows[num].ItemArray[1]
				});
			}
			for (int num2 = 0; num2 < dataTable8.Rows.Count; num2++)
			{
				dataTable10.Rows.Add(new object[]
				{
					dataTable8.Rows[num2].ItemArray[0],
					dataTable8.Rows[num2].ItemArray[1]
				});
			}
			DataTable dataTable11 = new DataTable();
			dataTable11.Columns.Add("valeur");
			dataTable11.Columns.Add("atelier");
			DataTable dataTable12 = new DataTable();
			dataTable12.Columns.Add("valeur");
			dataTable12.Columns.Add("atelier");
			List<string> list = new List<string>();
			for (int num3 = 0; num3 < dataTable9.Rows.Count; num3++)
			{
				bool flag = !list.Contains(dataTable9.Rows[num3].ItemArray[1].ToString());
				if (flag)
				{
					string champ_act = dataTable9.Rows[num3].ItemArray[1].ToString();
					double num4 = (from row in dataTable9.AsEnumerable()
					where row.Field("atelier") == champ_act
					select row).Sum((DataRow row) => row.Field("valeur"));
					dataTable11.Rows.Add(new object[]
					{
						num4,
						champ_act
					});
					list.Add(champ_act);
				}
			}
			list.Clear();
			for (int num5 = 0; num5 < dataTable10.Rows.Count; num5++)
			{
				bool flag2 = !list.Contains(dataTable10.Rows[num5].ItemArray[1].ToString());
				if (flag2)
				{
					string champ_act = dataTable10.Rows[num5].ItemArray[1].ToString();
					double num6 = (from row in dataTable10.AsEnumerable()
					where row.Field("atelier") == champ_act
					select row).Sum((DataRow row) => row.Field("valeur"));
					dataTable12.Rows.Add(new object[]
					{
						num6,
						champ_act
					});
					list.Add(champ_act);
				}
			}
			List<double> list2 = new List<double>();
			List<double> list3 = new List<double>();
			List<string> list4 = new List<string>();
			for (int num7 = 0; num7 < this.id_atelier.Count; num7++)
			{
				list2.Add(0.0);
				list3.Add(0.0);
				string cmdText = "select designation from equipement where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_atelier[num7];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable13 = new DataTable();
				sqlDataAdapter.Fill(dataTable13);
				string item = "";
				bool flag3 = dataTable13.Rows.Count != 0;
				if (flag3)
				{
					item = dataTable13.Rows[0].ItemArray[0].ToString();
				}
				list4.Add(item);
			}
			bool flag4 = dataTable11.Rows.Count != 0;
			if (flag4)
			{
				fonction fonction = new fonction();
				for (int num8 = 0; num8 < dataTable11.Rows.Count; num8++)
				{
					bool flag5 = fonction.is_reel(Convert.ToString(dataTable11.Rows[num8].ItemArray[0]));
					if (flag5)
					{
						for (int num9 = 0; num9 < this.id_atelier.Count; num9++)
						{
							bool flag6 = fonction.isnumeric(Convert.ToString(dataTable11.Rows[num8].ItemArray[1]));
							if (flag6)
							{
								bool flag7 = Convert.ToInt32(dataTable11.Rows[num8].ItemArray[1]) == this.id_atelier[num9];
								if (flag7)
								{
									list2[num9] = Math.Round(Convert.ToDouble(dataTable11.Rows[num8].ItemArray[0]), 3);
								}
							}
						}
					}
				}
				for (int num10 = 0; num10 < dataTable12.Rows.Count; num10++)
				{
					bool flag8 = fonction.is_reel(Convert.ToString(dataTable12.Rows[num10].ItemArray[0]));
					if (flag8)
					{
						for (int num11 = 0; num11 < this.id_atelier.Count; num11++)
						{
							bool flag9 = fonction.isnumeric(Convert.ToString(dataTable12.Rows[num10].ItemArray[1]));
							if (flag9)
							{
								bool flag10 = Convert.ToInt32(dataTable12.Rows[num10].ItemArray[1]) == this.id_atelier[num11];
								if (flag10)
								{
									list3[num11] = Math.Round(Convert.ToDouble(dataTable12.Rows[num10].ItemArray[0]));
								}
							}
						}
					}
				}
				BarSeries barSeries = new BarSeries();
				BarSeries barSeries2 = new BarSeries();
				barSeries.ShowLabels = true;
				barSeries2.ShowLabels = true;
				barSeries.LegendTitle = "Corrective";
				barSeries2.LegendTitle = "Préventive";
				for (int num12 = 0; num12 < this.id_atelier.Count; num12++)
				{
					barSeries.DataPoints.Add(new CategoricalDataPoint(list2[num12], list4[num12]));
					barSeries2.DataPoints.Add(new CategoricalDataPoint(list3[num12], list4[num12]));
				}
				this.radChartView1.Series.Add(barSeries);
				this.radChartView1.Series.Add(barSeries2);
				barSeries.CombineMode = 2;
				barSeries2.CombineMode = 2;
				this.radChartView1.ShowLegend = true;
				this.radChartView1.ShowTrackBall = true;
				bool flag11 = this.radChartView1.Axes.Count >= 1;
				if (flag11)
				{
					this.axisform_shown();
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003DDC File Offset: 0x00001FDC
		private void axisform_shown()
		{
			CategoricalAxis categoricalAxis = this.radChartView1.Axes[0] as CategoricalAxis;
			categoricalAxis.ForeColor = Color.Firebrick;
			categoricalAxis.BorderColor = Color.Gray;
			categoricalAxis.Font = new Font("Calibri", 7f, FontStyle.Bold, GraphicsUnit.Point, 0);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003E32 File Offset: 0x00002032
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_graphe();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003E3C File Offset: 0x0000203C
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_graphe();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003E46 File Offset: 0x00002046
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.select_graphe();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003E50 File Offset: 0x00002050
		public DataTable select_cout_mo_corrective()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) as valeur, atelier from ot_ordo_intervenant inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id  where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id  where atelier in (" + str + ") and type not like '%'  + @p + '%' and statut <> @st and month(ordre_travail.date_debut) = @m and year(ordre_travail.date_debut) = @y) group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1])
						});
					}
				}
			}
			return dataTable;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00004028 File Offset: 0x00002228
		public DataTable select_cout_pdr_corrective()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) as valeur, atelier from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  atelier in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and type not like '%'  + @p + '%' and statut <> @st and month(date_debut) = @m and year(date_debut) = @y group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					dataTable.Rows.Add(new object[]
					{
						Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
						Convert.ToString(dataTable2.Rows[i].ItemArray[1])
					});
				}
			}
			return dataTable;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00004214 File Offset: 0x00002414
		public DataTable select_cout_reparation_externe_corrective()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(ds_livraison_article.prix_ht) as valeur, atelier from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id  where  atelier in (" + str + ") and type not like '%'  + @p + '%' and statut <> @st and month(date_debut) = @y and year(date_debut) = @y group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1])
						});
					}
				}
			}
			return dataTable;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000043EC File Offset: 0x000025EC
		public DataTable select_cout_projet_corrective()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(cout) as valeur, atelier from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + str + ") and type not like '%'  + @p + '%' and statut <> @st and month(date_debut) = @m and year(date_debut) = @y group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1])
						});
					}
				}
			}
			return dataTable;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000045C4 File Offset: 0x000027C4
		public DataTable select_cout_mo_preventive()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) as valeur, atelier from ot_ordo_intervenant inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id  where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id  where atelier in (" + str + ") and type  like '%'  + @p + '%' and statut <> @st and month(ordre_travail.date_debut) = @m and year(ordre_travail.date_debut) = @y) group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1])
						});
					}
				}
			}
			return dataTable;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000479C File Offset: 0x0000299C
		public DataTable select_cout_pdr_preventive()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) as valeur, atelier from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  atelier in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and type like '%'  + @p + '%' and statut <> @st and month(date_debut) = @m and year(date_debut) = @y group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					dataTable.Rows.Add(new object[]
					{
						Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
						Convert.ToString(dataTable2.Rows[i].ItemArray[1])
					});
				}
			}
			return dataTable;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004988 File Offset: 0x00002B88
		public DataTable select_cout_reparation_externe_preventive()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(ds_livraison_article.prix_ht) as valeur, atelier from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id  where  atelier in (" + str + ") and type like '%'  + @p + '%' and statut <> @st and month(date_debut) = @y and year(date_debut) = @y group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1])
						});
					}
				}
			}
			return dataTable;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004B60 File Offset: 0x00002D60
		public DataTable select_cout_projet_preventive()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("valeur");
			dataTable.Columns.Add("atelier");
			bd bd = new bd();
			string str = string.Join<int>(",", this.id_atelier);
			string cmdText = "select sum(cout) as valeur, atelier from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + str + ") and type like '%'  + @p + '%' and statut <> @st and month(date_debut) = @m and year(date_debut) = @y group by atelier";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
				if (flag2)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1])
						});
					}
				}
			}
			return dataTable;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004D38 File Offset: 0x00002F38
		private void select_nbr_wagon()
		{
			this.pieChart1.Series.Clear();
			bd bd = new bd();
			string cmdText = "select sum(quantite)/ (select count(distinct date_rapport) from prod_rapport_general where month(date_rapport) = @m and year(date_rapport) = @y), id_unite, equipement.designation from prod_rapport_fab_produit inner join equipement on prod_rapport_fab_produit.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_fab_produit.id_rapport = prod_rapport_general.id where month(date_rapport) = @m and year(date_rapport) = @y group by id_unite, equipement.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			SeriesCollection seriesCollection = new SeriesCollection();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				PieSeries pieSeries = new PieSeries();
				Series series = pieSeries;
				ChartValues<double> chartValues = new ChartValues<double>();
				chartValues.Add(Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2));
				series.Values = chartValues;
				pieSeries.DataLabels = true;
				pieSeries.Title = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
				seriesCollection.Add(pieSeries);
			}
			string cmdText2 = "select sum(quantite) / (select count(distinct date_rapport) from prod_rapport_general where month(date_rapport) = @m and year(date_rapport) = @y)  from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where month(date_rapport) = @m and year(date_rapport) = @y";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand2.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
			if (flag)
			{
				PieSeries pieSeries2 = new PieSeries();
				Series series2 = pieSeries2;
				ChartValues<double> chartValues2 = new ChartValues<double>();
				chartValues2.Add(Math.Round(Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]), 2));
				series2.Values = chartValues2;
				pieSeries2.DataLabels = true;
				pieSeries2.Title = Convert.ToString("Sortie Four");
				seriesCollection.Add(pieSeries2);
			}
			this.pieChart1.Series = seriesCollection;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004F9C File Offset: 0x0000319C
		private void select_duree_anomalie()
		{
			this.pieChart2.Series.Clear();
			bd bd = new bd();
			string cmdText = "select sum(duree), id_unite, equipement.designation from prod_rapport_anomalie inner join equipement on prod_rapport_anomalie.id_unite = equipement.id inner join prod_rapport_general on prod_rapport_anomalie.id_rapport = prod_rapport_general.id where date_rapport = @d  group by id_unite, equipement.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Today.AddDays(-1.0);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			SeriesCollection seriesCollection = new SeriesCollection();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				PieSeries pieSeries = new PieSeries();
				Series series = pieSeries;
				ChartValues<double> chartValues = new ChartValues<double>();
				chartValues.Add(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]));
				series.Values = chartValues;
				pieSeries.DataLabels = true;
				pieSeries.Title = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
				seriesCollection.Add(pieSeries);
			}
			this.pieChart2.Series = seriesCollection;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000050C4 File Offset: 0x000032C4
		private double select_quantite_sortie_four()
		{
			double result = 0.0;
			bd bd = new bd();
			string cmdText = "select sum(tonnage)  from prod_rapport_four_sortie inner join prod_rapport_general on prod_rapport_four_sortie.id_rapport = prod_rapport_general.id where date_rapport = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Today.AddDays(-1.0);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
			if (flag)
			{
				result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00005194 File Offset: 0x00003394
		private double select_consommation_fuel()
		{
			double result = 0.0;
			bd bd = new bd();
			string cmdText = "select sum(quantite)  from prod_fuel inner join prod_rapport_general on prod_fuel.id_rapport = prod_rapport_general.id where date_rapport = @d and type_saisie = @t";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Today.AddDays(-1.0);
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 3;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
			if (flag)
			{
				result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
			}
			return result;
		}

		// Token: 0x04000001 RID: 1
		private List<int> id_atelier = new List<int>();
	}
}
