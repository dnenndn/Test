using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000168 RID: 360
	public partial class tb_variation_prix_article_vr : Form
	{
		// Token: 0x06001036 RID: 4150 RVA: 0x0028FB04 File Offset: 0x0028DD04
		public tb_variation_prix_article_vr()
		{
			this.InitializeComponent();
			this.radChartView1.Area.View.Palette = KnownPalette.Material;
			this.radChartView1.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.radMenuItem1.Click += this.click_ajouter;
			this.label10.Text = "";
			this.label11.Text = "";
			this.label12.Text = "";
			this.label13.Text = "";
			this.label14.Text = "";
			this.label15.Text = "";
			this.label16.Text = "";
			this.panel1.Hide();
			this.select_article();
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x0028FC90 File Offset: 0x0028DE90
		private void RadChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
		{
			e.LabelElement.ForeColor = Color.Black;
			e.LabelElement.Font = new Font("Calibri", 10.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			e.LabelElement.BackColor = Color.Transparent;
			e.LabelElement.BorderColor = Color.Transparent;
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0028FCEF File Offset: 0x0028DEEF
		private void tb_variation_prix_article_vr_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0028FCF4 File Offset: 0x0028DEF4
		private void select_article()
		{
			this.radTreeView1.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from article where deleted =@d order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0028FE24 File Offset: 0x0028E024
		private void click_ajouter(object sender, EventArgs e)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				bool flag = this.radTreeView1.SelectedNode != null;
				if (flag)
				{
					this.moy = 0.0;
					this.ecart_type = 0.0;
					this.cv = 0.0;
					RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
					bd bd = new bd();
					string cmdText = "select code_article, reference, designation, photo from article where id =@i order by designation";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode.Tag;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						this.id_article = Convert.ToInt32(selectedNode.Tag);
						this.label10.Text = this.id_article.ToString();
						this.label11.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
						this.label12.Text = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
						this.label13.Text = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
						byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[3];
						MemoryStream stream = new MemoryStream(buffer);
						this.pictureBox1.Image = Image.FromStream(stream);
						this.panel1.Show();
						this.stat_prix();
					}
				}
			}
			else
			{
				bool flag3 = this.radTreeView1.SelectedNode != null;
				if (flag3)
				{
					this.moy = 0.0;
					this.ecart_type = 0.0;
					this.cv = 0.0;
					RadTreeNode selectedNode2 = this.radTreeView1.SelectedNode;
					bd bd2 = new bd();
					string cmdText2 = "select code_article, ref_interne, designation, photo from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id where magasin_sous_traitance.id =@i order by designation";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode2.Tag;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag4 = dataTable2.Rows.Count != 0;
					if (flag4)
					{
						this.id_article = Convert.ToInt32(selectedNode2.Tag);
						this.label10.Text = this.id_article.ToString();
						this.label11.Text = Convert.ToString(dataTable2.Rows[0].ItemArray[0]);
						this.label12.Text = Convert.ToString(dataTable2.Rows[0].ItemArray[1]);
						this.label13.Text = Convert.ToString(dataTable2.Rows[0].ItemArray[2]);
						byte[] buffer2 = (byte[])dataTable2.Rows[0].ItemArray[3];
						MemoryStream stream2 = new MemoryStream(buffer2);
						this.pictureBox1.Image = Image.FromStream(stream2);
						this.panel1.Show();
						this.stat_prix_ref();
					}
				}
			}
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x00290194 File Offset: 0x0028E394
		private void stat_prix()
		{
			this.radChartView1.ShowLegend = false;
			this.radChartView1.Series.Clear();
			this.radChartView1.ShowTitle = false;
			bd bd = new bd();
			string cmdText = "select livraison_article.id, prix_ht, bon_livraison.date_reel from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where id_article = @i and bon_livraison.date_reel between @d1 and @d2 order by bon_livraison.date_reel desc ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_article;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			int count = dataTable.Rows.Count;
			bool flag = count != 0;
			if (flag)
			{
				this.radChartView1.ForeColor = Color.Firebrick;
				LineSeries lineSeries = new LineSeries();
				BarSeries barSeries = new BarSeries();
				lineSeries.ShowLabels = true;
				List<string> list = new List<string>();
				for (int i = 0; i < count; i++)
				{
					lineSeries.DataPoints.Insert(0, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3), fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[2]), 1, 10)));
					barSeries.DataPoints.Insert(0, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3), fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[2]), 1, 10)));
					list.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
				string str = string.Join(",", list.ToArray());
				string cmdText2 = "select avg(prix_ht), stdev(prix_ht), (stdev(prix_ht) / avg(prix_ht)) * 100,  max(prix_ht) - min(prix_ht) from livraison_article where id in (" + str + ")";
				SqlCommand selectCommand = new SqlCommand(cmdText2, bd.cnn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
					if (flag3)
					{
						this.moy = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
					}
					bool flag4 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[1]));
					if (flag4)
					{
						this.ecart_type = Convert.ToDouble(dataTable2.Rows[0].ItemArray[1]);
					}
					bool flag5 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[2]));
					if (flag5)
					{
						this.cv = Convert.ToDouble(dataTable2.Rows[0].ItemArray[2]);
					}
					bool flag6 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[3]));
					if (flag6)
					{
						this.etendu = Convert.ToDouble(dataTable2.Rows[0].ItemArray[3]);
					}
				}
				lineSeries.PointSize = new SizeF(12f, 12f);
				this.radChartView1.Series.Add(lineSeries);
				lineSeries.VerticalAxis.LabelInterval = 2;
				ChartPanZoomController chartPanZoomController = new ChartPanZoomController();
				chartPanZoomController.PanZoomMode = 0;
				this.radChartView1.Controllers.Add(chartPanZoomController);
				int num = count / 8 + 1;
				this.radChartView1.Zoom((double)num, 1.0);
			}
			this.label14.Text = this.moy.ToString("0.000");
			this.label15.Text = this.ecart_type.ToString("0.000");
			this.label17.Text = this.etendu.ToString("0.000");
			this.label16.Text = Math.Round(this.cv, 2).ToString() + " %";
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x00290630 File Offset: 0x0028E830
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			bool flag = this.id_article != 0;
			if (flag)
			{
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					this.stat_prix();
				}
				else
				{
					this.stat_prix_ref();
				}
			}
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x00290670 File Offset: 0x0028E870
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			bool flag = this.id_article != 0;
			if (flag)
			{
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					this.stat_prix();
				}
				else
				{
					this.stat_prix_ref();
				}
			}
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x002906B0 File Offset: 0x0028E8B0
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x002906CC File Offset: 0x0028E8CC
		private void select_article_ref()
		{
			this.radTreeView1.Nodes.Clear();
			this.radTreeView1.ShowNodeToolTips = true;
			bd bd = new bd();
			string cmdText = "select magasin_sous_traitance.id, article.designation, ref_interne, article.id from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString() + "-" + dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00290810 File Offset: 0x0028EA10
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.select_article_ref();
			}
			else
			{
				this.select_article();
			}
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x00290844 File Offset: 0x0028EA44
		private void stat_prix_ref()
		{
			this.radChartView1.ShowLegend = false;
			this.radChartView1.Series.Clear();
			this.radChartView1.ShowTitle = false;
			bd bd = new bd();
			string cmdText = "select ds_livraison_article.id, ds_livraison_article.prix_ht, ds_bon_livraison.date_reel from ds_livraison_article inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where id_t = @i and ds_bon_livraison.date_reel between @d1 and @d2 order by ds_bon_livraison.date_reel desc ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_article;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			int count = dataTable.Rows.Count;
			bool flag = count != 0;
			if (flag)
			{
				this.radChartView1.ForeColor = Color.Firebrick;
				LineSeries lineSeries = new LineSeries();
				lineSeries.ShowLabels = true;
				List<string> list = new List<string>();
				for (int i = 0; i < count; i++)
				{
					lineSeries.DataPoints.Insert(0, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3), fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[2]), 1, 10)));
					list.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
				string str = string.Join(",", list.ToArray());
				string cmdText2 = "select avg(prix_ht), stdev(prix_ht), (stdev(prix_ht) / avg(prix_ht)) * 100,  max(prix_ht) - min(prix_ht) from ds_livraison_article where id in (" + str + ")";
				SqlCommand selectCommand = new SqlCommand(cmdText2, bd.cnn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
					if (flag3)
					{
						this.moy = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
					}
					bool flag4 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[1]));
					if (flag4)
					{
						this.ecart_type = Convert.ToDouble(dataTable2.Rows[0].ItemArray[1]);
					}
					bool flag5 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[2]));
					if (flag5)
					{
						this.cv = Convert.ToDouble(dataTable2.Rows[0].ItemArray[2]);
					}
					bool flag6 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[3]));
					if (flag6)
					{
						this.etendu = Convert.ToDouble(dataTable2.Rows[0].ItemArray[3]);
					}
				}
				lineSeries.PointSize = new SizeF(7f, 7f);
				this.radChartView1.Series.Add(lineSeries);
				lineSeries.VerticalAxis.LabelInterval = 2;
				ChartPanZoomController chartPanZoomController = new ChartPanZoomController();
				chartPanZoomController.PanZoomMode = 0;
				this.radChartView1.Controllers.Add(chartPanZoomController);
				int num = count / 8 + 1;
				this.radChartView1.Zoom((double)num, 1.0);
			}
			this.label14.Text = this.moy.ToString("0.000");
			this.label15.Text = this.ecart_type.ToString("0.000");
			this.label17.Text = this.etendu.ToString("0.000");
			this.label16.Text = Math.Round(this.cv, 2).ToString() + " %";
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x00290C7E File Offset: 0x0028EE7E
		private void prop_radchart()
		{
		}

		// Token: 0x0400141C RID: 5148
		private int id_article = 0;

		// Token: 0x0400141D RID: 5149
		private double moy = 0.0;

		// Token: 0x0400141E RID: 5150
		private double ecart_type = 0.0;

		// Token: 0x0400141F RID: 5151
		private double cv = 0.0;

		// Token: 0x04001420 RID: 5152
		private double etendu = 0.0;
	}
}
