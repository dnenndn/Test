using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using Bunifu.Framework.UI;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Gauges;

namespace GMAO
{
	// Token: 0x02000004 RID: 4
	public partial class accueil : Form
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00006B18 File Offset: 0x00004D18
		public accueil()
		{
			this.InitializeComponent();
			this.radCalendar1.SelectionChanged += this.RadCalendar1_SelectionChanged;
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(accueil.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(accueil.select_changee);
			this.radCalendar1.ElementRender += new RenderElementEventHandler(this.select_approvisionnement);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00006BA8 File Offset: 0x00004DA8
		private void RadCalendar1_SelectionChanged(object sender, EventArgs e)
		{
			accueil.article_des.Clear();
			accueil.article_qt.Clear();
			string text = this.radCalendar1.SelectedDate.ToString();
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.isdate(text);
			if (flag)
			{
				string cmdText = "select article.designation, ac_reapprovisionnement.qt from ac_reapprovisionnement inner join ac_reapprovisionnement_ech on ac_reapprovisionnement.id = ac_reapprovisionnement_ech.id_rep inner join article on ac_reapprovisionnement.id_article = article.id where date_ech = @d1 and article.deleted = @d and arr = @d and ac_reapprovisionnement_ech.deleted = @d";
				string cmdText2 = "select article.designation from ac_recompletement inner join ac_recompletement_ech on ac_recompletement.id = ac_recompletement_ech.id_rep inner join article on ac_recompletement.id_article = article.id where date_ech = @d1 and article.deleted = @d and arr = @d and ac_recompletement_ech.deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = text;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable = new DataTable();
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						accueil.article_des.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
						accueil.article_qt.Add(Convert.ToString(dataTable.Rows[i].ItemArray[1]));
					}
				}
				bool flag3 = dataTable2.Rows.Count != 0;
				if (flag3)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						accueil.article_des.Add(Convert.ToString(dataTable2.Rows[j].ItemArray[0]));
						accueil.article_qt.Add(Convert.ToString("Recomplètement"));
					}
				}
				acceuil_stock_liste_article acceuil_stock_liste_article = new acceuil_stock_liste_article();
				acceuil_stock_liste_article.Show();
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00006DD8 File Offset: 0x00004FD8
		private void accueil_Load(object sender, EventArgs e)
		{
			accueil.article_des.Clear();
			accueil.article_qt.Clear();
			this.select_usine();
			this.select_atelier();
			this.select_parc();
			this.select_da();
			this.repture_stock();
			this.select_histogramme_commande_bl();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00006E28 File Offset: 0x00005028
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = System.Drawing.Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00006EAC File Offset: 0x000050AC
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = System.Drawing.Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = System.Drawing.Color.Firebrick;
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

		// Token: 0x0600002D RID: 45 RVA: 0x00006FB0 File Offset: 0x000051B0
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
				MemoryStream stream = new MemoryStream(buffer);
				this.pictureBox1.Image = Image.FromStream(stream);
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000703C File Offset: 0x0000523C
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
				MemoryStream stream = new MemoryStream(buffer);
				this.imageList1.Images.Add(Image.FromStream(stream));
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000070D0 File Offset: 0x000052D0
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

		// Token: 0x06000030 RID: 48 RVA: 0x0000714C File Offset: 0x0000534C
		private void select_da()
		{
			this.pieChart1.Series.Clear();
			bd bd = new bd();
			string cmdText = "select count(distinct id) , statut from demande_achat where (statut = @s1 or statut = @s2 or statut = @s3) and month(date_da) = @m and year(date_da) = @y group by statut order by statut";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@s1", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@s2", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@s3", SqlDbType.Int).Value = 10;
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				SeriesCollection seriesCollection = new SeriesCollection();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					PieSeries pieSeries = new PieSeries();
					Series series = pieSeries;
					ChartValues<int> chartValues = new ChartValues<int>();
					chartValues.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
					series.Values = chartValues;
					pieSeries.DataLabels = true;
					string title = "";
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[1]) == 0;
					if (flag2)
					{
						title = "En Cours";
						pieSeries.Fill = System.Windows.Media.Brushes.DodgerBlue;
					}
					bool flag3 = Convert.ToInt32(dataTable.Rows[i].ItemArray[1]) == 1;
					if (flag3)
					{
						title = "Confirmée";
						pieSeries.Fill = System.Windows.Media.Brushes.Red;
					}
					bool flag4 = Convert.ToInt32(dataTable.Rows[i].ItemArray[1]) == 10;
					if (flag4)
					{
						title = "Clôturée";
						pieSeries.Fill = System.Windows.Media.Brushes.LimeGreen;
					}
					pieSeries.Title = title;
					seriesCollection.Add(pieSeries);
				}
				this.pieChart1.Series = seriesCollection;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000073A8 File Offset: 0x000055A8
		private void repture_stock()
		{
			bd bd = new bd();
			string cmdText = "select top 10 (stock_neuf - stock_mini), designation, stock_neuf from article where stock_neuf - stock_mini <=@d and id in(select id_article from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id where month(date_bsm) = @m and year(date_bsm) = @y) order by (stock_neuf - stock_mini)";
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
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
				this.radGridView3.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00007500 File Offset: 0x00005700
		private void select_histogramme_commande_bl()
		{
			this.radChartView1.Series.Clear();
			bd bd = new bd();
			fonction fonction = new fonction();
			string cmdText = "select count(distinct commande.id), sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande where statut = @d and month(date_commande) = @m and year(date_commande) = @y";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			double num = 0.0;
			double num2 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				num = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[1]));
				if (flag2)
				{
					num2 = Convert.ToDouble(dataTable.Rows[0].ItemArray[1]);
				}
			}
			string cmdText2 = "select count(distinct ds_commande.id), sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where statut = @d and month(date_commande) = @m and year(date_commande) = @y";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand2.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag3 = dataTable2.Rows.Count != 0;
			if (flag3)
			{
				num += Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
				bool flag4 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[1]));
				if (flag4)
				{
					num2 += Convert.ToDouble(dataTable2.Rows[0].ItemArray[1]);
				}
			}
			string cmdText3 = "select count(distinct commande.id), sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande where (statut = @d or statut = @c) and month(date_commande) = @m and year(date_commande) = @y";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand3.Parameters.Add("@c", SqlDbType.Int).Value = 10;
			sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand3.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			double num3 = 0.0;
			double num4 = 0.0;
			bool flag5 = dataTable3.Rows.Count != 0;
			if (flag5)
			{
				num3 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
				bool flag6 = fonction.is_reel(Convert.ToString(dataTable3.Rows[0].ItemArray[1]));
				if (flag6)
				{
					num4 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[1]);
				}
			}
			string cmdText4 = "select count(distinct ds_commande.id), sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where (statut = @d or statut = @c) and month(date_commande) = @m and year(date_commande) = @y";
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
			sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand4.Parameters.Add("@c", SqlDbType.Int).Value = 10;
			sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand4.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
			DataTable dataTable4 = new DataTable();
			sqlDataAdapter4.Fill(dataTable4);
			bool flag7 = dataTable4.Rows.Count != 0;
			if (flag7)
			{
				num3 += Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
				bool flag8 = fonction.is_reel(Convert.ToString(dataTable4.Rows[0].ItemArray[1]));
				if (flag8)
				{
					num4 += Convert.ToDouble(dataTable4.Rows[0].ItemArray[1]);
				}
			}
			string cmdText5 = "select count(distinct bon_livraison.id), sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where statut = @d and month(date_livraison) = @m and year(date_livraison) = @y";
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
			sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand5.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand5.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
			DataTable dataTable5 = new DataTable();
			sqlDataAdapter5.Fill(dataTable5);
			double num5 = 0.0;
			double num6 = 0.0;
			bool flag9 = dataTable5.Rows.Count != 0;
			if (flag9)
			{
				num5 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[0]);
				bool flag10 = fonction.is_reel(Convert.ToString(dataTable5.Rows[0].ItemArray[1]));
				if (flag10)
				{
					num6 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[1]);
				}
			}
			string cmdText6 = "select count(distinct ds_bon_livraison.id), sum(ds_livraison_article.qt * ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*(ds_livraison_article.qt * ds_livraison_article.prix_ht)) from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison where statut = @d and month(date_livraison) = @m and year(date_livraison) = @y";
			SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
			sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand6.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
			DataTable dataTable6 = new DataTable();
			sqlDataAdapter6.Fill(dataTable6);
			bool flag11 = dataTable6.Rows.Count != 0;
			if (flag11)
			{
				num5 += Convert.ToDouble(dataTable6.Rows[0].ItemArray[0]);
				bool flag12 = fonction.is_reel(Convert.ToString(dataTable6.Rows[0].ItemArray[1]));
				if (flag12)
				{
					num6 += Convert.ToDouble(dataTable6.Rows[0].ItemArray[1]);
				}
			}
			string cmdText7 = "select count(distinct bon_livraison.id), sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where statut = @d and month(date_livraison) = @m and year(date_livraison) = @y";
			SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
			sqlCommand7.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand7.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand7.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
			DataTable dataTable7 = new DataTable();
			sqlDataAdapter7.Fill(dataTable7);
			double num7 = 0.0;
			double num8 = 0.0;
			bool flag13 = dataTable7.Rows.Count != 0;
			if (flag13)
			{
				num7 = Convert.ToDouble(dataTable7.Rows[0].ItemArray[0]);
				bool flag14 = fonction.is_reel(Convert.ToString(dataTable7.Rows[0].ItemArray[1]));
				if (flag14)
				{
					num8 = Convert.ToDouble(dataTable7.Rows[0].ItemArray[1]);
				}
			}
			string cmdText8 = "select count(distinct ds_bon_livraison.id), sum(ds_livraison_article.qt * ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*(ds_livraison_article.qt * ds_livraison_article.prix_ht)) from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison where statut = @d and month(date_livraison) = @m and year(date_livraison) = @y";
			SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
			sqlCommand8.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand8.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand8.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
			DataTable dataTable8 = new DataTable();
			sqlDataAdapter8.Fill(dataTable8);
			bool flag15 = dataTable8.Rows.Count != 0;
			if (flag15)
			{
				num7 += Convert.ToDouble(dataTable8.Rows[0].ItemArray[0]);
				bool flag16 = fonction.is_reel(Convert.ToString(dataTable8.Rows[0].ItemArray[1]));
				if (flag16)
				{
					num8 += Convert.ToDouble(dataTable8.Rows[0].ItemArray[1]);
				}
			}
			LinearAxis linearAxis = new LinearAxis();
			linearAxis.HorizontalLocation = 0;
			LinearAxis linearAxis2 = new LinearAxis();
			linearAxis2.HorizontalLocation = 0;
			CategoricalAxis horizontalAxis = new CategoricalAxis();
			linearAxis.AxisType = 1;
			linearAxis2.AxisType = 1;
			linearAxis.Title = "Nombre";
			linearAxis2.Title = "Montant";
			BarSeries barSeries = new BarSeries();
			BarSeries barSeries2 = new BarSeries();
			barSeries.DataPoints.Add(new CategoricalDataPoint(num, "Cmd En Attente"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(num2, 3), "Cmd En Attente"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(num3, "Cmd Confirmée"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(num4, 3), "Cmd Confirmée"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(num5, "BL non Facturé"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(num6, 3), "BL non Facturé"));
			barSeries.DataPoints.Add(new CategoricalDataPoint(num7, "BL Facturé"));
			barSeries2.DataPoints.Add(new CategoricalDataPoint(Math.Round(num8, 3), "BL Facturé"));
			this.radChartView1.Series.Add(barSeries);
			this.radChartView1.Series.Add(barSeries2);
			this.FillColors(this.radChartView1.View, KnownPalette.Fluent);
			this.radChartView1.ShowTrackBall = true;
			this.radChartView1.ShowLegend = true;
			barSeries.LegendTitle = "Nombre";
			barSeries2.LegendTitle = "Montant (TND)";
			this.radChartView1.Title = "Flux D'Achat";
			barSeries.VerticalAxis = linearAxis;
			barSeries.HorizontalAxis = horizontalAxis;
			barSeries2.HorizontalAxis = horizontalAxis;
			barSeries2.VerticalAxis = linearAxis2;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000807D File Offset: 0x0000627D
		private void FillColors(ChartView view, ChartPalette pallete)
		{
			view.Palette = null;
			view.Palette = pallete;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00008090 File Offset: 0x00006290
		private void select_approvisionnement(object sender, RenderElementEventArgs e)
		{
			e.Element.NumberOfColors = 1;
			bool flag = e.Element.ToolTipText != "lundi" & e.Element.ToolTipText != "mardi" & e.Element.ToolTipText != "mercredi" & e.Element.ToolTipText != "jeudi" & e.Element.ToolTipText != "vendredi" & e.Element.ToolTipText != "samedi" & e.Element.ToolTipText != "dimanche";
			if (flag)
			{
				e.Element.DrawBorder = true;
				e.Element.BorderColor = System.Drawing.Color.Gold;
				e.Element.BorderColor2 = System.Drawing.Color.Gold;
				e.Element.BorderColor3 = System.Drawing.Color.Gold;
				e.Element.BorderColor4 = System.Drawing.Color.Gold;
				e.Element.ForeColor = System.Drawing.Color.Black;
			}
			else
			{
				e.Element.ForeColor = System.Drawing.Color.Firebrick;
			}
			bd bd = new bd();
			fonction fonction = new fonction();
			string cmdText = "select distinct date_ech from ac_reapprovisionnement_ech where deleted = @d and month(date_ech) = @m and year(date_ech) = @y";
			string cmdText2 = "select distinct date_ech from ac_recompletement_ech where deleted = @d and month(date_ech) = @m and year(date_ech) = @y";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = DateTime.Today.Month;
			sqlCommand2.Parameters.Add("@y", SqlDbType.Int).Value = DateTime.Today.Year;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int num = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[0]), 1, 2));
					int num2 = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[0]), 4, 2));
					int num3 = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[0]), 7, 4));
					bool flag3 = e.Day.Date.Date.Day == num & e.Day.Date.Date.Year == num3 & e.Day.Date.Date.Month == num2;
					if (flag3)
					{
						bool flag4 = e.Element.ToolTipText != "lundi" & e.Element.ToolTipText != "mardi" & e.Element.ToolTipText != "mercredi" & e.Element.ToolTipText != "jeudi" & e.Element.ToolTipText != "vendredi" & e.Element.ToolTipText != "samedi" & e.Element.ToolTipText != "dimanche";
						if (flag4)
						{
							e.Element.BackColor = System.Drawing.Color.Gold;
							e.Element.ForeColor = System.Drawing.Color.Black;
						}
					}
				}
			}
			bool flag5 = dataTable2.Rows.Count != 0;
			if (flag5)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					int num4 = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable2.Rows[j].ItemArray[0]), 1, 2));
					int num5 = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable2.Rows[j].ItemArray[0]), 4, 2));
					int num6 = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable2.Rows[j].ItemArray[0]), 7, 4));
					bool flag6 = e.Day.Date.Date.Day == num4 & e.Day.Date.Date.Year == num6 & e.Day.Date.Date.Month == num5;
					if (flag6)
					{
						bool flag7 = e.Element.ToolTipText != "lundi" & e.Element.ToolTipText != "mardi" & e.Element.ToolTipText != "mercredi" & e.Element.ToolTipText != "jeudi" & e.Element.ToolTipText != "vendredi" & e.Element.ToolTipText != "samedi" & e.Element.ToolTipText != "dimanche";
						if (flag7)
						{
							e.Element.DrawBorder = true;
							e.Element.BorderColor = System.Drawing.Color.Firebrick;
							e.Element.BorderColor2 = System.Drawing.Color.Firebrick;
							e.Element.BorderColor3 = System.Drawing.Color.Firebrick;
							e.Element.BorderColor4 = System.Drawing.Color.Firebrick;
							e.Element.ForeColor = System.Drawing.Color.Black;
						}
					}
				}
			}
		}

		// Token: 0x04000019 RID: 25
		public static List<string> article_des = new List<string>();

		// Token: 0x0400001A RID: 26
		public static List<string> article_qt = new List<string>();

		// Token: 0x0400001B RID: 27
		private fonction a = new fonction();
	}
}
