using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Telerik.Charting;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000166 RID: 358
	public partial class tb_variation_prix : Form
	{
		// Token: 0x06000FC5 RID: 4037 RVA: 0x00261D3C File Offset: 0x0025FF3C
		public tb_variation_prix()
		{
			this.InitializeComponent();
			this.radChartView1.Area.View.Palette = KnownPalette.Material;
			this.radChartView2.Area.View.Palette = KnownPalette.Material;
			this.TextBox1.Hide();
			this.panel7.Hide();
			this.radCheckedListBox1.VisualItemFormatting += new ListViewVisualItemEventHandler(this.RadCheckedListBox1_VisualItemFormatting);
			this.radCheckedListBox2.VisualItemFormatting += new ListViewVisualItemEventHandler(this.RadCheckedListBox1_VisualItemFormatting);
			this.radCheckedListBox1.ItemCheckedChanged += new ListViewItemEventHandler(this.RadCheckedListBox1_ItemCheckedChanged);
			this.radCheckedListBox2.ItemCheckedChanged += new ListViewItemEventHandler(this.RadCheckedListBox2_ItemCheckedChanged);
			this.radChartView1.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.radChartView2.LabelFormatting += new ChartViewLabelFormattingEventHandler(this.RadChartView1_LabelFormatting);
			this.panel8.Visible = false;
			this.get_famille();
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00261E54 File Offset: 0x00260054
		private void axisform_shown()
		{
			CategoricalAxis categoricalAxis = this.radChartView1.Axes[0] as CategoricalAxis;
			categoricalAxis.ForeColor = Color.Green;
			categoricalAxis.BorderColor = Color.Blue;
			this.radChartView1.ForeColor = Color.Firebrick;
			this.radChartView1.BackColor = Color.WhiteSmoke;
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00261EB3 File Offset: 0x002600B3
		private void RadCheckedListBox2_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
		{
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00261EB8 File Offset: 0x002600B8
		private void RadCheckedListBox1_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				bool flag = e.Item.CheckState == 1;
				if (flag)
				{
					string id_f = Convert.ToString(e.Item.Tag);
					this.get_sous_famille(id_f);
				}
				else
				{
					this.delete_get_sous_famille(e.Item.Tag.ToString());
				}
			}
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x00261F20 File Offset: 0x00260120
		private void RadChartView1_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
		{
			e.LabelElement.ForeColor = Color.Firebrick;
			e.LabelElement.Font = new Font("Calibri", 10.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			e.LabelElement.BackColor = Color.Transparent;
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x00261F70 File Offset: 0x00260170
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00261FAC File Offset: 0x002601AC
		private void RadCheckedListBox1_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
		{
			e.VisualItem.BorderBoxStyle = 1;
			e.VisualItem.BorderBottomColor = Color.Firebrick;
			bool flag = e.VisualItem.Selected | e.VisualItem.ContainsMouse;
			if (flag)
			{
				e.VisualItem.BackColor = Color.White;
				e.VisualItem.ForeColor = Color.Firebrick;
			}
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x00262018 File Offset: 0x00260218
		private void tb_variation_prix_Load(object sender, EventArgs e)
		{
			this.guna2NumericUpDown1.Value = DateTime.Today.Year;
			this.stat_famille();
			this.remplissage_pie();
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x00262054 File Offset: 0x00260254
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.TextBox1.Hide();
				this.panel7.Hide();
			}
			else
			{
				this.TextBox1.Show();
				this.panel7.Show();
			}
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x002620A8 File Offset: 0x002602A8
		private void get_famille()
		{
			bd bd = new bd();
			this.radCheckedListBox1.Items.Clear();
			string cmdText = "select id, designation from famille where deleted = @d order by designation";
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
					this.radCheckedListBox1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedListBox1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					this.radCheckedListBox1.Items[i].CheckState = 1;
				}
			}
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x002621CC File Offset: 0x002603CC
		private void radButton1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
			{
				this.radCheckedListBox1.Items[i].CheckState = 1;
			}
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00262214 File Offset: 0x00260414
		private void radButton4_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
			{
				this.radCheckedListBox1.Items[i].CheckState = 0;
			}
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x0026225C File Offset: 0x0026045C
		private void stat_famille()
		{
			this.radChartView1.Series.Clear();
			bool flag = this.radCheckedListBox1.Items.Count != 0;
			if (flag)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
				{
					bool flag2 = this.radCheckedListBox1.Items[i].CheckState == 1;
					if (flag2)
					{
						list.Add(this.radCheckedListBox1.Items[i].Tag.ToString());
					}
				}
				string text = string.Join(",", list.ToArray());
				bool flag3 = list.Count != 0;
				if (flag3)
				{
					bool isChecked = this.radRadioButton9.IsChecked;
					if (isChecked)
					{
						bool isChecked2 = this.radRadioButton5.IsChecked;
						if (isChecked2)
						{
							string text2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
							string cmdText = "";
							bool isChecked3 = this.radRadioButton7.IsChecked;
							if (isChecked3)
							{
								cmdText = text2;
							}
							else
							{
								bool isChecked4 = this.radRadioButton13.IsChecked;
								if (isChecked4)
								{
									this.get_famille_nbre_commande_somme(list, text);
								}
								bool isChecked5 = this.radRadioButton12.IsChecked;
								if (isChecked5)
								{
									this.get_famille_nbre_commande_extremum(list, text);
								}
								bool isChecked6 = this.radRadioButton14.IsChecked;
								if (isChecked6)
								{
									this.get_famille_nbre_commande_etendue(list, text);
								}
								bool isChecked7 = this.radRadioButton15.IsChecked;
								if (isChecked7)
								{
									this.get_famille_nbre_commande_etendue_min(list, text);
								}
								bool isChecked8 = this.radRadioButton16.IsChecked;
								if (isChecked8)
								{
									this.get_famille_nbre_commande_ecart_type_max(list, text);
								}
								bool isChecked9 = this.radRadioButton17.IsChecked;
								if (isChecked9)
								{
									this.get_famille_nbre_commande_ecart_type_min(list, text);
								}
								bool isChecked10 = this.radRadioButton18.IsChecked;
								if (isChecked10)
								{
									this.get_famille_nbre_commande_c_variation_max(list, text);
								}
								bool isChecked11 = this.radRadioButton6.IsChecked;
								if (isChecked11)
								{
									this.get_famille_nbre_commande_c_variation_min(list, text);
								}
							}
							bool isChecked12 = this.radRadioButton7.IsChecked;
							if (isChecked12)
							{
								bd bd = new bd();
								fonction fonction = new fonction();
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
								DataTable dataTable = new DataTable();
								sqlDataAdapter.Fill(dataTable);
								bool flag4 = dataTable.Rows.Count != 0;
								if (flag4)
								{
									bool isChecked13 = this.radRadioButton7.IsChecked;
									if (isChecked13)
									{
										LineSeries lineSeries = new LineSeries();
										lineSeries.ShowLabels = true;
										lineSeries.PointSize = new SizeF(10f, 10f);
										this.radChartView1.Title = "Nbre des commandes des Familles";
										this.radChartView1.ShowTitle = true;
										this.radChartView1.ForeColor = Color.Firebrick;
										for (int j = 0; j < dataTable.Rows.Count; j++)
										{
											lineSeries.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable.Rows[j].ItemArray[0]), fonction.rendre_mois(Convert.ToInt32(dataTable.Rows[j].ItemArray[1]))));
										}
										this.radChartView1.Series.Add(lineSeries);
									}
								}
							}
						}
						bool isChecked14 = this.radRadioButton4.IsChecked;
						if (isChecked14)
						{
							string text3 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
							string cmdText2 = "";
							bool isChecked15 = this.radRadioButton7.IsChecked;
							if (isChecked15)
							{
								cmdText2 = text3;
							}
							else
							{
								bool isChecked16 = this.radRadioButton13.IsChecked;
								if (isChecked16)
								{
									this.get_famille_nbre_commande_somme(list, text);
								}
								bool isChecked17 = this.radRadioButton12.IsChecked;
								if (isChecked17)
								{
									this.get_famille_nbre_commande_extremum(list, text);
								}
								bool isChecked18 = this.radRadioButton14.IsChecked;
								if (isChecked18)
								{
									this.get_famille_nbre_commande_etendue(list, text);
								}
								bool isChecked19 = this.radRadioButton15.IsChecked;
								if (isChecked19)
								{
									this.get_famille_nbre_commande_etendue_min(list, text);
								}
								bool isChecked20 = this.radRadioButton16.IsChecked;
								if (isChecked20)
								{
									this.get_famille_nbre_commande_ecart_type_max(list, text);
								}
								bool isChecked21 = this.radRadioButton17.IsChecked;
								if (isChecked21)
								{
									this.get_famille_nbre_commande_ecart_type_min(list, text);
								}
								bool isChecked22 = this.radRadioButton18.IsChecked;
								if (isChecked22)
								{
									this.get_famille_nbre_commande_c_variation_max(list, text);
								}
								bool isChecked23 = this.radRadioButton6.IsChecked;
								if (isChecked23)
								{
									this.get_famille_nbre_commande_c_variation_min(list, text);
								}
							}
							bool isChecked24 = this.radRadioButton7.IsChecked;
							if (isChecked24)
							{
								bd bd2 = new bd();
								fonction fonction2 = new fonction();
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand2.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								bool flag5 = dataTable2.Rows.Count != 0;
								if (flag5)
								{
									LineSeries lineSeries2 = new LineSeries();
									lineSeries2.ShowLabels = true;
									lineSeries2.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Nbre des commandes des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int k = 0; k < dataTable2.Rows.Count; k++)
									{
										lineSeries2.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable2.Rows[k].ItemArray[0]), Convert.ToInt32(dataTable2.Rows[k].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries2);
								}
							}
						}
					}
					bool isChecked25 = this.radRadioButton10.IsChecked;
					if (isChecked25)
					{
						bool isChecked26 = this.radRadioButton5.IsChecked;
						if (isChecked26)
						{
							string text4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
							string cmdText3 = "";
							bool isChecked27 = this.radRadioButton7.IsChecked;
							if (isChecked27)
							{
								cmdText3 = text4;
							}
							else
							{
								bool isChecked28 = this.radRadioButton13.IsChecked;
								if (isChecked28)
								{
									this.get_famille_total_commande_somme(list, text);
								}
								bool isChecked29 = this.radRadioButton12.IsChecked;
								if (isChecked29)
								{
									this.get_famille_total_commande_extremum(list, text);
								}
								bool isChecked30 = this.radRadioButton14.IsChecked;
								if (isChecked30)
								{
									this.get_famille_total_commande_etendue(list, text);
								}
								bool isChecked31 = this.radRadioButton15.IsChecked;
								if (isChecked31)
								{
									this.get_famille_total_commande_etendue_min(list, text);
								}
								bool isChecked32 = this.radRadioButton16.IsChecked;
								if (isChecked32)
								{
									this.get_famille_total_commande_ecart_type_max(list, text);
								}
								bool isChecked33 = this.radRadioButton17.IsChecked;
								if (isChecked33)
								{
									this.get_famille_total_commande_ecart_type_min(list, text);
								}
								bool isChecked34 = this.radRadioButton18.IsChecked;
								if (isChecked34)
								{
									this.get_famille_total_commande_c_variation_max(list, text);
								}
								bool isChecked35 = this.radRadioButton6.IsChecked;
								if (isChecked35)
								{
									this.get_famille_total_commande_c_variation_min(list, text);
								}
							}
							bool isChecked36 = this.radRadioButton7.IsChecked;
							if (isChecked36)
							{
								bd bd3 = new bd();
								fonction fonction3 = new fonction();
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								bool flag6 = dataTable3.Rows.Count != 0;
								if (flag6)
								{
									LineSeries lineSeries3 = new LineSeries();
									lineSeries3.ShowLabels = false;
									lineSeries3.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot Commandes (TND) des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int l = 0; l < dataTable3.Rows.Count; l++)
									{
										lineSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[l].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[l].ItemArray[1]))));
									}
									this.radChartView1.Series.Add(lineSeries3);
								}
							}
						}
						bool isChecked37 = this.radRadioButton4.IsChecked;
						if (isChecked37)
						{
							string text5 = "select sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
							string cmdText4 = "";
							bool isChecked38 = this.radRadioButton7.IsChecked;
							if (isChecked38)
							{
								cmdText4 = text5;
							}
							else
							{
								bool isChecked39 = this.radRadioButton13.IsChecked;
								if (isChecked39)
								{
									this.get_famille_total_commande_somme(list, text);
								}
								bool isChecked40 = this.radRadioButton12.IsChecked;
								if (isChecked40)
								{
									this.get_famille_total_commande_extremum(list, text);
								}
								bool isChecked41 = this.radRadioButton14.IsChecked;
								if (isChecked41)
								{
									this.get_famille_total_commande_etendue(list, text);
								}
								bool isChecked42 = this.radRadioButton15.IsChecked;
								if (isChecked42)
								{
									this.get_famille_total_commande_etendue_min(list, text);
								}
								bool isChecked43 = this.radRadioButton16.IsChecked;
								if (isChecked43)
								{
									this.get_famille_total_commande_ecart_type_max(list, text);
								}
								bool isChecked44 = this.radRadioButton17.IsChecked;
								if (isChecked44)
								{
									this.get_famille_total_commande_ecart_type_min(list, text);
								}
								bool isChecked45 = this.radRadioButton18.IsChecked;
								if (isChecked45)
								{
									this.get_famille_total_commande_c_variation_max(list, text);
								}
								bool isChecked46 = this.radRadioButton6.IsChecked;
								if (isChecked46)
								{
									this.get_famille_total_commande_c_variation_min(list, text);
								}
							}
							bool isChecked47 = this.radRadioButton7.IsChecked;
							if (isChecked47)
							{
								bd bd4 = new bd();
								fonction fonction4 = new fonction();
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd4.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag7 = dataTable4.Rows.Count != 0;
								if (flag7)
								{
									LineSeries lineSeries4 = new LineSeries();
									lineSeries4.ShowLabels = false;
									lineSeries4.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot Commandes (TND) des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int m = 0; m < dataTable4.Rows.Count; m++)
									{
										lineSeries4.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable4.Rows[m].ItemArray[0]), Convert.ToInt32(dataTable4.Rows[m].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries4);
								}
							}
						}
					}
					bool isChecked48 = this.radRadioButton8.IsChecked;
					if (isChecked48)
					{
						bool isChecked49 = this.radRadioButton5.IsChecked;
						if (isChecked49)
						{
							string text6 = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + "))) and  year(date_reel) = @d1   group by month(date_reel) order by month(date_reel)";
							string cmdText5 = "";
							bool isChecked50 = this.radRadioButton7.IsChecked;
							if (isChecked50)
							{
								cmdText5 = text6;
							}
							else
							{
								bool isChecked51 = this.radRadioButton13.IsChecked;
								if (isChecked51)
								{
									this.get_famille_total_BL_somme(list, text);
								}
								bool isChecked52 = this.radRadioButton12.IsChecked;
								if (isChecked52)
								{
									this.get_famille_total_BL_extremum(list, text);
								}
								bool isChecked53 = this.radRadioButton14.IsChecked;
								if (isChecked53)
								{
									this.get_famille_total_BL_etendue(list, text);
								}
								bool isChecked54 = this.radRadioButton15.IsChecked;
								if (isChecked54)
								{
									this.get_famille_total_BL_etendue_min(list, text);
								}
								bool isChecked55 = this.radRadioButton16.IsChecked;
								if (isChecked55)
								{
									this.get_famille_total_BL_ecart_type_max(list, text);
								}
								bool isChecked56 = this.radRadioButton17.IsChecked;
								if (isChecked56)
								{
									this.get_famille_total_BL_ecart_type_min(list, text);
								}
								bool isChecked57 = this.radRadioButton18.IsChecked;
								if (isChecked57)
								{
									this.get_famille_total_BL_c_variation_max(list, text);
								}
								bool isChecked58 = this.radRadioButton6.IsChecked;
								if (isChecked58)
								{
									this.get_famille_total_BL_c_variation_min(list, text);
								}
							}
							bool isChecked59 = this.radRadioButton7.IsChecked;
							if (isChecked59)
							{
								bd bd5 = new bd();
								fonction fonction5 = new fonction();
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd5.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								bool flag8 = dataTable5.Rows.Count != 0;
								if (flag8)
								{
									LineSeries lineSeries5 = new LineSeries();
									lineSeries5.ShowLabels = false;
									lineSeries5.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot BL (TND) des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int n = 0; n < dataTable5.Rows.Count; n++)
									{
										lineSeries5.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable5.Rows[n].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable5.Rows[n].ItemArray[1]))));
									}
									this.radChartView1.Series.Add(lineSeries5);
								}
							}
						}
						bool isChecked60 = this.radRadioButton4.IsChecked;
						if (isChecked60)
						{
							string text7 = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + ")))  and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
							string cmdText6 = "";
							bool isChecked61 = this.radRadioButton7.IsChecked;
							if (isChecked61)
							{
								cmdText6 = text7;
							}
							else
							{
								bool isChecked62 = this.radRadioButton13.IsChecked;
								if (isChecked62)
								{
									this.get_famille_total_BL_somme(list, text);
								}
								bool isChecked63 = this.radRadioButton12.IsChecked;
								if (isChecked63)
								{
									this.get_famille_total_BL_extremum(list, text);
								}
								bool isChecked64 = this.radRadioButton14.IsChecked;
								if (isChecked64)
								{
									this.get_famille_total_BL_etendue(list, text);
								}
								bool isChecked65 = this.radRadioButton15.IsChecked;
								if (isChecked65)
								{
									this.get_famille_total_BL_etendue_min(list, text);
								}
								bool isChecked66 = this.radRadioButton16.IsChecked;
								if (isChecked66)
								{
									this.get_famille_total_BL_ecart_type_max(list, text);
								}
								bool isChecked67 = this.radRadioButton17.IsChecked;
								if (isChecked67)
								{
									this.get_famille_total_BL_ecart_type_min(list, text);
								}
								bool isChecked68 = this.radRadioButton18.IsChecked;
								if (isChecked68)
								{
									this.get_famille_total_BL_c_variation_max(list, text);
								}
								bool isChecked69 = this.radRadioButton6.IsChecked;
								if (isChecked69)
								{
									this.get_famille_total_BL_c_variation_min(list, text);
								}
							}
							bool isChecked70 = this.radRadioButton7.IsChecked;
							if (isChecked70)
							{
								bd bd6 = new bd();
								fonction fonction6 = new fonction();
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd6.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								bool flag9 = dataTable6.Rows.Count != 0;
								if (flag9)
								{
									LineSeries lineSeries6 = new LineSeries();
									lineSeries6.ShowLabels = false;
									lineSeries6.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot BL (TND) des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int num = 0; num < dataTable6.Rows.Count; num++)
									{
										lineSeries6.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable6.Rows[num].ItemArray[0]), Convert.ToInt32(dataTable6.Rows[num].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries6);
								}
							}
						}
					}
				}
			}
			bool flag10 = this.radChartView1.Axes.Count > 1;
			if (flag10)
			{
				this.axisform_shown();
			}
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0026354C File Offset: 0x0026174C
		private void radButton3_Click(object sender, EventArgs e)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.stat_famille();
			}
			bool isChecked2 = this.radRadioButton2.IsChecked;
			if (isChecked2)
			{
				this.stat_sous_famille();
			}
			bool isChecked3 = this.radRadioButton19.IsChecked;
			if (isChecked3)
			{
				this.stat_activite();
			}
			this.remplissage_pie();
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x002635AC File Offset: 0x002617AC
		private int controle_saisie_top()
		{
			fonction fonction = new fonction();
			int result = 0;
			bool flag = fonction.is_reel(this.TextBox1.Text);
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) > 0;
				if (flag2)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x002635FC File Offset: 0x002617FC
		private void get_famille_nbre_commande_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select count(distinct commande.id),famille.id, famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by year(date_commande), famille.id,famille.designation order by count(distinct commande.id) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select count(distinct commande.id),famille.id, famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by  famille.id,famille.designation order by count(distinct commande.id) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00263D74 File Offset: 0x00261F74
		private void get_famille_nbre_commande_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select m from temporaire where id = @a and t = @b";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToString(dataTable.Rows[i].ItemArray[0]),
									" Commandes"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande), famille.id,famille.designation) select m from temporaire where id = @a and t = @b";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToString(dataTable4.Rows[k].ItemArray[0]),
									" Commandes"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x002647EC File Offset: 0x002629EC
		private void get_famille_nbre_commande_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable.Rows[i].ItemArray[0]) + " Commandes";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable3.Rows[k].ItemArray[0]) + " Commandes";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x00264FB8 File Offset: 0x002631B8
		private void get_famille_nbre_commande_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable.Rows[i].ItemArray[0]) + " Commandes";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable3.Rows[k].ItemArray[0]) + " Commandes";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00265784 File Offset: 0x00263984
		private void get_famille_nbre_commande_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x00265FE8 File Offset: 0x002641E8
		private void get_famille_nbre_commande_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x0026684C File Offset: 0x00264A4C
		private void get_famille_nbre_commande_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x002670B0 File Offset: 0x002652B0
		private void get_famille_nbre_commande_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x00267914 File Offset: 0x00265B14
		private void get_famille_total_commande_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)),famille.id, famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by year(date_commande), famille.id,famille.designation order by  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)),famille.id, famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by  famille.id,famille.designation order by  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0026808C File Offset: 0x0026628C
		private void get_famille_total_commande_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande), famille.id,famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x00268B20 File Offset: 0x00266D20
		private void get_famille_total_commande_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00269308 File Offset: 0x00267508
		private void get_famille_total_commande_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x00269AF0 File Offset: 0x00267CF0
		private void get_famille_total_commande_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x0026A354 File Offset: 0x00268554
		private void get_famille_total_commande_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x0026ABB8 File Offset: 0x00268DB8
		private void get_famille_total_commande_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x0026B41C File Offset: 0x0026961C
		private void get_famille_total_commande_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,famille.id, famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + "))) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m)) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x0026BC80 File Offset: 0x00269E80
		private void get_famille_total_BL_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)),famille.id, famille.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by year(date_reel), famille.id,famille.designation order by  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)),famille.id, famille.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2  group by  famille.id,famille.designation order by  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x0026C3F8 File Offset: 0x0026A5F8
		private void get_famille_total_BL_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))  and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))  and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))  and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2  group by year(date_reel), famille.id,famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x0026CE8C File Offset: 0x0026B08C
		private void get_famille_total_BL_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x0026D674 File Offset: 0x0026B874
		private void get_famille_total_BL_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x0026DE5C File Offset: 0x0026C05C
		private void get_famille_total_BL_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x0026E6C0 File Offset: 0x0026C8C0
		private void get_famille_total_BL_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x0026EF24 File Offset: 0x0026D124
		private void get_famille_total_BL_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x0026F788 File Offset: 0x0026D988
		private void get_famille_total_BL_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,famille.id, famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), famille.id,famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x0026FFEC File Offset: 0x0026E1EC
		private int combien_petit(List<int> l, int p)
		{
			int num = -1;
			for (int i = 0; i < l.Count; i++)
			{
				bool flag = l[i] < p;
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x00270030 File Offset: 0x0026E230
		private int test_existe_dtable(DataTable t, int h)
		{
			int result = 0;
			for (int i = 0; i < t.Rows.Count; i++)
			{
				bool flag = Convert.ToInt32(t.Rows[i].ItemArray[1]) == h;
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x00270088 File Offset: 0x0026E288
		private int indice_dtable(DataTable t, int h)
		{
			int result = 0;
			for (int i = 0; i < t.Rows.Count; i++)
			{
				bool flag = Convert.ToInt32(t.Rows[i].ItemArray[1]) == h;
				if (flag)
				{
					result = i;
				}
			}
			return result;
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x002700E0 File Offset: 0x0026E2E0
		private void afficher_sous_famille()
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
				{
					bool flag = this.radCheckedListBox1.Items[i].CheckState == 1;
					if (flag)
					{
						this.get_sous_famille(this.radCheckedListBox1.Items[i].Tag.ToString());
					}
				}
				this.panel8.Visible = true;
			}
			else
			{
				this.panel8.Visible = false;
			}
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x0027017F File Offset: 0x0026E37F
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.afficher_sous_famille();
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x00270189 File Offset: 0x0026E389
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.afficher_sous_famille();
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x00270193 File Offset: 0x0026E393
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.afficher_sous_famille();
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x002701A0 File Offset: 0x0026E3A0
		private void radRadioButton19_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton19.IsChecked;
			if (isChecked)
			{
				this.get_activite();
				this.label1.Text = "Activité";
			}
			else
			{
				this.get_famille();
				this.label1.Text = "Famille";
			}
			this.afficher_sous_famille();
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x002701FC File Offset: 0x0026E3FC
		private void get_sous_famille(string id_f)
		{
			bd bd = new bd();
			string cmdText = "select id, designation from sous_famille where deleted = @d and id_famille = @f order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = id_f;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int count = this.radCheckedListBox2.Items.Count;
					this.radCheckedListBox2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedListBox2.Items[count].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					this.radCheckedListBox2.Items[count].Key = id_f;
					this.radCheckedListBox2.Items[count].CheckState = 1;
				}
			}
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x00270354 File Offset: 0x0026E554
		private void delete_get_sous_famille(string id_f)
		{
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				bool flag = this.radCheckedListBox2.Items[i].Key.ToString() == id_f;
				if (flag)
				{
					this.radCheckedListBox2.Items.RemoveAt(i);
					i--;
				}
			}
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x002703C0 File Offset: 0x0026E5C0
		private void radButton5_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				this.radCheckedListBox2.Items[i].CheckState = 1;
			}
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00270408 File Offset: 0x0026E608
		private void radButton2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				this.radCheckedListBox2.Items[i].CheckState = 0;
			}
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x00270450 File Offset: 0x0026E650
		private void get_sous_famille_nbre_commande_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select count(distinct commande.id),sous_famille.id, sous_famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by year(date_commande), sous_famille.id,sous_famille.designation order by count(distinct commande.id) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select count(distinct commande.id),sous_famille.id, sous_famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by  sous_famille.id,sous_famille.designation order by count(distinct commande.id) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x00270BC8 File Offset: 0x0026EDC8
		private void get_sous_famille_nbre_commande_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select m from temporaire where id = @a and t = @b";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToString(dataTable.Rows[i].ItemArray[0]),
									" Commandes"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande), sous_famille.id,sous_famille.designation) select m from temporaire where id = @a and t = @b";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToString(dataTable4.Rows[k].ItemArray[0]),
									" Commandes"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x00271640 File Offset: 0x0026F840
		private void get_sous_famille_nbre_commande_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable.Rows[i].ItemArray[0]) + " Commandes";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable3.Rows[k].ItemArray[0]) + " Commandes";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x00271E0C File Offset: 0x0027000C
		private void get_sous_famille_nbre_commande_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable.Rows[i].ItemArray[0]) + " Commandes";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in   = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable3.Rows[k].ItemArray[0]) + " Commandes";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x002725D8 File Offset: 0x002707D8
		private void get_sous_famille_nbre_commande_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x00272E3C File Offset: 0x0027103C
		private void get_sous_famille_nbre_commande_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille   = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x002736A0 File Offset: 0x002718A0
		private void get_sous_famille_nbre_commande_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00273F04 File Offset: 0x00272104
		private void get_sous_famille_nbre_commande_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select  count(distinct commande.id) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x00274768 File Offset: 0x00272968
		private void get_sous_famille_total_commande_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)),sous_famille.id, sous_famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by year(date_commande), sous_famille.id,sous_famille.designation order by  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)),sous_famille.id, sous_famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by  sous_famille.id,sous_famille.designation order by  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x00274EE0 File Offset: 0x002730E0
		private void get_sous_famille_total_commande_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande), sous_famille.id,sous_famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x00275974 File Offset: 0x00273B74
		private void get_sous_famille_total_commande_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x0027615C File Offset: 0x0027435C
		private void get_sous_famille_total_commande_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00276944 File Offset: 0x00274B44
		private void get_sous_famille_total_commande_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x002771A8 File Offset: 0x002753A8
		private void get_sous_famille_total_commande_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x00277A0C File Offset: 0x00275C0C
		private void get_sous_famille_total_commande_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x00278270 File Offset: 0x00276470
		private void get_sous_famille_total_commande_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_commande) m from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join tableau_article_sous_famille on da_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x00278AD4 File Offset: 0x00276CD4
		private void get_sous_famille_total_BL_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)),sous_famille.id, sous_famille.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by year(date_reel), sous_famille.id,sous_famille.designation order by  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)),sous_famille.id, sous_famille.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2  group by  sous_famille.id,sous_famille.designation order by  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x0027924C File Offset: 0x0027744C
		private void get_sous_famille_total_BL_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))  and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))  and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)  and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2  group by year(date_reel), sous_famille.id,sous_famille.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00279CE0 File Offset: 0x00277EE0
		private void get_sous_famille_total_BL_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x0027A4C8 File Offset: 0x002786C8
		private void get_sous_famille_total_BL_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x0027ACB0 File Offset: 0x00278EB0
		private void get_sous_famille_total_BL_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0027B514 File Offset: 0x00279714
		private void get_sous_famille_total_BL_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x0027BD78 File Offset: 0x00279F78
		private void get_sous_famille_total_BL_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x0027C5DC File Offset: 0x0027A7DC
		private void get_sous_famille_total_BL_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) = @d1  group by month(date_reel), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,sous_famille.id, sous_famille.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   and year(date_reel) between @d1 and @d2 group by year(date_reel), sous_famille.id,sous_famille.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des sous familles choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0027CE40 File Offset: 0x0027B040
		private void stat_sous_famille()
		{
			this.radChartView1.ShowLegend = false;
			this.radChartView1.Series.Clear();
			this.radChartView1.ShowTitle = false;
			bool flag = this.radCheckedListBox2.Items.Count != 0;
			if (flag)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
				{
					bool flag2 = this.radCheckedListBox2.Items[i].CheckState == 1;
					if (flag2)
					{
						list.Add(this.radCheckedListBox2.Items[i].Tag.ToString());
					}
				}
				string text = string.Join(",", list.ToArray());
				bool flag3 = list.Count != 0;
				if (flag3)
				{
					bool isChecked = this.radRadioButton9.IsChecked;
					if (isChecked)
					{
						bool isChecked2 = this.radRadioButton5.IsChecked;
						if (isChecked2)
						{
							string text2 = "select count(distinct commande.id), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + text + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
							string cmdText = "";
							bool isChecked3 = this.radRadioButton7.IsChecked;
							if (isChecked3)
							{
								cmdText = text2;
							}
							else
							{
								bool isChecked4 = this.radRadioButton13.IsChecked;
								if (isChecked4)
								{
									this.get_sous_famille_nbre_commande_somme(list, text);
								}
								bool isChecked5 = this.radRadioButton12.IsChecked;
								if (isChecked5)
								{
									this.get_sous_famille_nbre_commande_extremum(list, text);
								}
								bool isChecked6 = this.radRadioButton14.IsChecked;
								if (isChecked6)
								{
									this.get_sous_famille_nbre_commande_etendue(list, text);
								}
								bool isChecked7 = this.radRadioButton15.IsChecked;
								if (isChecked7)
								{
									this.get_sous_famille_nbre_commande_etendue_min(list, text);
								}
								bool isChecked8 = this.radRadioButton16.IsChecked;
								if (isChecked8)
								{
									this.get_sous_famille_nbre_commande_ecart_type_max(list, text);
								}
								bool isChecked9 = this.radRadioButton17.IsChecked;
								if (isChecked9)
								{
									this.get_sous_famille_nbre_commande_ecart_type_min(list, text);
								}
								bool isChecked10 = this.radRadioButton18.IsChecked;
								if (isChecked10)
								{
									this.get_sous_famille_nbre_commande_c_variation_max(list, text);
								}
								bool isChecked11 = this.radRadioButton6.IsChecked;
								if (isChecked11)
								{
									this.get_sous_famille_nbre_commande_c_variation_min(list, text);
								}
							}
							bool isChecked12 = this.radRadioButton7.IsChecked;
							if (isChecked12)
							{
								bd bd = new bd();
								fonction fonction = new fonction();
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
								DataTable dataTable = new DataTable();
								sqlDataAdapter.Fill(dataTable);
								bool flag4 = dataTable.Rows.Count != 0;
								if (flag4)
								{
									bool isChecked13 = this.radRadioButton7.IsChecked;
									if (isChecked13)
									{
										LineSeries lineSeries = new LineSeries();
										lineSeries.ShowLabels = true;
										lineSeries.PointSize = new SizeF(10f, 10f);
										this.radChartView1.Title = "Nbre des commandes des Sous Familles";
										this.radChartView1.ShowTitle = true;
										this.radChartView1.ForeColor = Color.Firebrick;
										for (int j = 0; j < dataTable.Rows.Count; j++)
										{
											lineSeries.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable.Rows[j].ItemArray[0]), fonction.rendre_mois(Convert.ToInt32(dataTable.Rows[j].ItemArray[1]))));
										}
										this.radChartView1.Series.Add(lineSeries);
									}
								}
							}
						}
						bool isChecked14 = this.radRadioButton4.IsChecked;
						if (isChecked14)
						{
							string text3 = "select count(distinct commande.id), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + text + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
							string cmdText2 = "";
							bool isChecked15 = this.radRadioButton7.IsChecked;
							if (isChecked15)
							{
								cmdText2 = text3;
							}
							else
							{
								bool isChecked16 = this.radRadioButton13.IsChecked;
								if (isChecked16)
								{
									this.get_sous_famille_nbre_commande_somme(list, text);
								}
								bool isChecked17 = this.radRadioButton12.IsChecked;
								if (isChecked17)
								{
									this.get_sous_famille_nbre_commande_extremum(list, text);
								}
								bool isChecked18 = this.radRadioButton14.IsChecked;
								if (isChecked18)
								{
									this.get_sous_famille_nbre_commande_etendue(list, text);
								}
								bool isChecked19 = this.radRadioButton15.IsChecked;
								if (isChecked19)
								{
									this.get_sous_famille_nbre_commande_etendue_min(list, text);
								}
								bool isChecked20 = this.radRadioButton16.IsChecked;
								if (isChecked20)
								{
									this.get_sous_famille_nbre_commande_ecart_type_max(list, text);
								}
								bool isChecked21 = this.radRadioButton17.IsChecked;
								if (isChecked21)
								{
									this.get_sous_famille_nbre_commande_ecart_type_min(list, text);
								}
								bool isChecked22 = this.radRadioButton18.IsChecked;
								if (isChecked22)
								{
									this.get_sous_famille_nbre_commande_c_variation_max(list, text);
								}
								bool isChecked23 = this.radRadioButton6.IsChecked;
								if (isChecked23)
								{
									this.get_sous_famille_nbre_commande_c_variation_min(list, text);
								}
							}
							bool isChecked24 = this.radRadioButton7.IsChecked;
							if (isChecked24)
							{
								bd bd2 = new bd();
								fonction fonction2 = new fonction();
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand2.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								bool flag5 = dataTable2.Rows.Count != 0;
								if (flag5)
								{
									LineSeries lineSeries2 = new LineSeries();
									lineSeries2.ShowLabels = true;
									lineSeries2.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Nbre des commandes des Sous Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int k = 0; k < dataTable2.Rows.Count; k++)
									{
										lineSeries2.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable2.Rows[k].ItemArray[0]), Convert.ToInt32(dataTable2.Rows[k].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries2);
								}
							}
						}
					}
					bool isChecked25 = this.radRadioButton10.IsChecked;
					if (isChecked25)
					{
						bool isChecked26 = this.radRadioButton5.IsChecked;
						if (isChecked26)
						{
							string text4 = "select  sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), month(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + text + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
							string cmdText3 = "";
							bool isChecked27 = this.radRadioButton7.IsChecked;
							if (isChecked27)
							{
								cmdText3 = text4;
							}
							else
							{
								bool isChecked28 = this.radRadioButton13.IsChecked;
								if (isChecked28)
								{
									this.get_sous_famille_total_commande_somme(list, text);
								}
								bool isChecked29 = this.radRadioButton12.IsChecked;
								if (isChecked29)
								{
									this.get_sous_famille_total_commande_extremum(list, text);
								}
								bool isChecked30 = this.radRadioButton14.IsChecked;
								if (isChecked30)
								{
									this.get_sous_famille_total_commande_etendue(list, text);
								}
								bool isChecked31 = this.radRadioButton15.IsChecked;
								if (isChecked31)
								{
									this.get_sous_famille_total_commande_etendue_min(list, text);
								}
								bool isChecked32 = this.radRadioButton16.IsChecked;
								if (isChecked32)
								{
									this.get_sous_famille_total_commande_ecart_type_max(list, text);
								}
								bool isChecked33 = this.radRadioButton17.IsChecked;
								if (isChecked33)
								{
									this.get_sous_famille_total_commande_ecart_type_min(list, text);
								}
								bool isChecked34 = this.radRadioButton18.IsChecked;
								if (isChecked34)
								{
									this.get_sous_famille_total_commande_c_variation_max(list, text);
								}
								bool isChecked35 = this.radRadioButton6.IsChecked;
								if (isChecked35)
								{
									this.get_sous_famille_total_commande_c_variation_min(list, text);
								}
							}
							bool isChecked36 = this.radRadioButton7.IsChecked;
							if (isChecked36)
							{
								bd bd3 = new bd();
								fonction fonction3 = new fonction();
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								bool flag6 = dataTable3.Rows.Count != 0;
								if (flag6)
								{
									LineSeries lineSeries3 = new LineSeries();
									lineSeries3.ShowLabels = false;
									lineSeries3.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int l = 0; l < dataTable3.Rows.Count; l++)
									{
										lineSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[l].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[l].ItemArray[1]))));
									}
									this.radChartView1.Series.Add(lineSeries3);
								}
							}
						}
						bool isChecked37 = this.radRadioButton4.IsChecked;
						if (isChecked37)
						{
							string text5 = "select sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), year(date_commande) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + text + ")) and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
							string cmdText4 = "";
							bool isChecked38 = this.radRadioButton7.IsChecked;
							if (isChecked38)
							{
								cmdText4 = text5;
							}
							else
							{
								bool isChecked39 = this.radRadioButton13.IsChecked;
								if (isChecked39)
								{
									this.get_sous_famille_total_commande_somme(list, text);
								}
								bool isChecked40 = this.radRadioButton12.IsChecked;
								if (isChecked40)
								{
									this.get_sous_famille_total_commande_extremum(list, text);
								}
								bool isChecked41 = this.radRadioButton14.IsChecked;
								if (isChecked41)
								{
									this.get_sous_famille_total_commande_etendue(list, text);
								}
								bool isChecked42 = this.radRadioButton15.IsChecked;
								if (isChecked42)
								{
									this.get_sous_famille_total_commande_etendue_min(list, text);
								}
								bool isChecked43 = this.radRadioButton16.IsChecked;
								if (isChecked43)
								{
									this.get_sous_famille_total_commande_ecart_type_max(list, text);
								}
								bool isChecked44 = this.radRadioButton17.IsChecked;
								if (isChecked44)
								{
									this.get_sous_famille_total_commande_ecart_type_min(list, text);
								}
								bool isChecked45 = this.radRadioButton18.IsChecked;
								if (isChecked45)
								{
									this.get_sous_famille_total_commande_c_variation_max(list, text);
								}
								bool isChecked46 = this.radRadioButton6.IsChecked;
								if (isChecked46)
								{
									this.get_sous_famille_total_commande_c_variation_min(list, text);
								}
							}
							bool isChecked47 = this.radRadioButton7.IsChecked;
							if (isChecked47)
							{
								bd bd4 = new bd();
								fonction fonction4 = new fonction();
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd4.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag7 = dataTable4.Rows.Count != 0;
								if (flag7)
								{
									LineSeries lineSeries4 = new LineSeries();
									lineSeries4.ShowLabels = false;
									lineSeries4.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot Commandes (TND) des Sous Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int m = 0; m < dataTable4.Rows.Count; m++)
									{
										lineSeries4.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable4.Rows[m].ItemArray[0]), Convert.ToInt32(dataTable4.Rows[m].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries4);
								}
							}
						}
					}
					bool isChecked48 = this.radRadioButton8.IsChecked;
					if (isChecked48)
					{
						bool isChecked49 = this.radRadioButton5.IsChecked;
						if (isChecked49)
						{
							string text6 = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in  (" + text + ")) and  year(date_reel) = @d1   group by month(date_reel) order by month(date_reel)";
							string cmdText5 = "";
							bool isChecked50 = this.radRadioButton7.IsChecked;
							if (isChecked50)
							{
								cmdText5 = text6;
							}
							else
							{
								bool isChecked51 = this.radRadioButton13.IsChecked;
								if (isChecked51)
								{
									this.get_sous_famille_total_BL_somme(list, text);
								}
								bool isChecked52 = this.radRadioButton12.IsChecked;
								if (isChecked52)
								{
									this.get_sous_famille_total_BL_extremum(list, text);
								}
								bool isChecked53 = this.radRadioButton14.IsChecked;
								if (isChecked53)
								{
									this.get_sous_famille_total_BL_etendue(list, text);
								}
								bool isChecked54 = this.radRadioButton15.IsChecked;
								if (isChecked54)
								{
									this.get_sous_famille_total_BL_etendue_min(list, text);
								}
								bool isChecked55 = this.radRadioButton16.IsChecked;
								if (isChecked55)
								{
									this.get_sous_famille_total_BL_ecart_type_max(list, text);
								}
								bool isChecked56 = this.radRadioButton17.IsChecked;
								if (isChecked56)
								{
									this.get_sous_famille_total_BL_ecart_type_min(list, text);
								}
								bool isChecked57 = this.radRadioButton18.IsChecked;
								if (isChecked57)
								{
									this.get_sous_famille_total_BL_c_variation_max(list, text);
								}
								bool isChecked58 = this.radRadioButton6.IsChecked;
								if (isChecked58)
								{
									this.get_sous_famille_total_BL_c_variation_min(list, text);
								}
							}
							bool isChecked59 = this.radRadioButton7.IsChecked;
							if (isChecked59)
							{
								bd bd5 = new bd();
								fonction fonction5 = new fonction();
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd5.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								bool flag8 = dataTable5.Rows.Count != 0;
								if (flag8)
								{
									LineSeries lineSeries5 = new LineSeries();
									lineSeries5.ShowLabels = false;
									lineSeries5.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int n = 0; n < dataTable5.Rows.Count; n++)
									{
										lineSeries5.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable5.Rows[n].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable5.Rows[n].ItemArray[1]))));
									}
									this.radChartView1.Series.Add(lineSeries5);
								}
							}
						}
						bool isChecked60 = this.radRadioButton4.IsChecked;
						if (isChecked60)
						{
							string text7 = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + text + "))  and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
							string cmdText6 = "";
							bool isChecked61 = this.radRadioButton7.IsChecked;
							if (isChecked61)
							{
								cmdText6 = text7;
							}
							else
							{
								bool isChecked62 = this.radRadioButton13.IsChecked;
								if (isChecked62)
								{
									this.get_sous_famille_total_BL_somme(list, text);
								}
								bool isChecked63 = this.radRadioButton12.IsChecked;
								if (isChecked63)
								{
									this.get_sous_famille_total_BL_extremum(list, text);
								}
								bool isChecked64 = this.radRadioButton14.IsChecked;
								if (isChecked64)
								{
									this.get_sous_famille_total_BL_etendue(list, text);
								}
								bool isChecked65 = this.radRadioButton15.IsChecked;
								if (isChecked65)
								{
									this.get_sous_famille_total_BL_etendue_min(list, text);
								}
								bool isChecked66 = this.radRadioButton16.IsChecked;
								if (isChecked66)
								{
									this.get_sous_famille_total_BL_ecart_type_max(list, text);
								}
								bool isChecked67 = this.radRadioButton17.IsChecked;
								if (isChecked67)
								{
									this.get_sous_famille_total_BL_ecart_type_min(list, text);
								}
								bool isChecked68 = this.radRadioButton18.IsChecked;
								if (isChecked68)
								{
									this.get_sous_famille_total_BL_c_variation_max(list, text);
								}
								bool isChecked69 = this.radRadioButton6.IsChecked;
								if (isChecked69)
								{
									this.get_sous_famille_total_BL_c_variation_min(list, text);
								}
							}
							bool isChecked70 = this.radRadioButton7.IsChecked;
							if (isChecked70)
							{
								bd bd6 = new bd();
								fonction fonction6 = new fonction();
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd6.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								bool flag9 = dataTable6.Rows.Count != 0;
								if (flag9)
								{
									LineSeries lineSeries6 = new LineSeries();
									lineSeries6.ShowLabels = false;
									lineSeries6.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot BL (TND) des Sous Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int num = 0; num < dataTable6.Rows.Count; num++)
									{
										lineSeries6.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable6.Rows[num].ItemArray[0]), Convert.ToInt32(dataTable6.Rows[num].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries6);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x0027E128 File Offset: 0x0027C328
		private void remplissage_pie()
		{
			bd bd = new bd();
			this.radChartView2.Series.Clear();
			bool isChecked = this.radRadioButton9.IsChecked;
			if (isChecked)
			{
				bool isChecked2 = this.radRadioButton1.IsChecked;
				if (isChecked2)
				{
					List<string> list = new List<string>();
					for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
					{
						bool flag = this.radCheckedListBox1.Items[i].CheckState == 1;
						if (flag)
						{
							list.Add(this.radCheckedListBox1.Items[i].Tag.ToString());
						}
					}
					string str = string.Join(",", list.ToArray());
					bool flag2 = list.Count != 0;
					if (flag2)
					{
						string cmdText = "select count(distinct commande.id), famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + str + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by famille.designation order by count(distinct commande.id) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							PieSeries pieSeries = new PieSeries();
							pieSeries.ShowLabels = true;
							pieSeries.DrawLinesToLabels = true;
							pieSeries.SyncLinesToLabelsColor = true;
							this.radChartView2.ShowTitle = false;
							this.radChartView2.ForeColor = Color.Firebrick;
							this.radChartView2.ShowLegend = true;
							int num = 5;
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							for (int j = 0; j < num; j++)
							{
								pieSeries.DataPoints.Add(new PieDataPoint((double)Convert.ToInt32(dataTable.Rows[j].ItemArray[0]), Convert.ToString(dataTable.Rows[j].ItemArray[1])));
							}
							bool flag5 = num == 5 & dataTable.Rows.Count != 5;
							if (flag5)
							{
								double num2 = 0.0;
								for (int k = 5; k < dataTable.Rows.Count; k++)
								{
									num2 += Convert.ToDouble(dataTable.Rows[k].ItemArray[0]);
								}
								pieSeries.DataPoints.Add(new PieDataPoint(num2, "Autres"));
							}
							this.radChartView2.Series.Add(pieSeries);
						}
					}
				}
				bool isChecked3 = this.radRadioButton2.IsChecked;
				if (isChecked3)
				{
					List<string> list2 = new List<string>();
					for (int l = 0; l < this.radCheckedListBox2.Items.Count; l++)
					{
						bool flag6 = this.radCheckedListBox2.Items[l].CheckState == 1;
						if (flag6)
						{
							list2.Add(this.radCheckedListBox2.Items[l].Tag.ToString());
						}
					}
					string str2 = string.Join(",", list2.ToArray());
					bool flag7 = list2.Count != 0;
					if (flag7)
					{
						string cmdText = "select count(distinct commande.id), sous_famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + str2 + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by sous_famille.designation order by count(distinct commande.id) desc";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText, bd.cnn);
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag8 = dataTable2.Rows.Count != 0;
						if (flag8)
						{
							PieSeries pieSeries2 = new PieSeries();
							pieSeries2.ShowLabels = true;
							pieSeries2.DrawLinesToLabels = true;
							pieSeries2.SyncLinesToLabelsColor = true;
							this.radChartView2.ShowTitle = false;
							this.radChartView2.ForeColor = Color.Firebrick;
							this.radChartView2.ShowLegend = true;
							int num3 = 7;
							bool flag9 = dataTable2.Rows.Count < num3;
							if (flag9)
							{
								num3 = dataTable2.Rows.Count;
							}
							for (int m = 0; m < num3; m++)
							{
								pieSeries2.DataPoints.Add(new PieDataPoint((double)Convert.ToInt32(dataTable2.Rows[m].ItemArray[0]), Convert.ToString(dataTable2.Rows[m].ItemArray[1])));
							}
							bool flag10 = num3 == 7 & dataTable2.Rows.Count != 7;
							if (flag10)
							{
								double num4 = 0.0;
								for (int n = 7; n < dataTable2.Rows.Count; n++)
								{
									num4 += Convert.ToDouble(dataTable2.Rows[n].ItemArray[0]);
								}
								pieSeries2.DataPoints.Add(new PieDataPoint(num4, "Autres"));
							}
							this.radChartView2.Series.Add(pieSeries2);
						}
					}
				}
			}
			bool isChecked4 = this.radRadioButton10.IsChecked;
			if (isChecked4)
			{
				bool isChecked5 = this.radRadioButton1.IsChecked;
				if (isChecked5)
				{
					List<string> list3 = new List<string>();
					for (int num5 = 0; num5 < this.radCheckedListBox1.Items.Count; num5++)
					{
						bool flag11 = this.radCheckedListBox1.Items[num5].CheckState == 1;
						if (flag11)
						{
							list3.Add(this.radCheckedListBox1.Items[num5].Tag.ToString());
						}
					}
					string str3 = string.Join(",", list3.ToArray());
					bool flag12 = list3.Count != 0;
					if (flag12)
					{
						string cmdText = "select sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + str3 + "))) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by famille.designation order by sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText, bd.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag13 = dataTable3.Rows.Count != 0;
						if (flag13)
						{
							PieSeries pieSeries3 = new PieSeries();
							pieSeries3.ShowLabels = true;
							pieSeries3.DrawLinesToLabels = true;
							pieSeries3.SyncLinesToLabelsColor = true;
							this.radChartView2.ShowTitle = false;
							this.radChartView2.ForeColor = Color.Firebrick;
							this.radChartView2.ShowLegend = true;
							int num6 = 5;
							bool flag14 = dataTable3.Rows.Count < num6;
							if (flag14)
							{
								num6 = dataTable3.Rows.Count;
							}
							for (int num7 = 0; num7 < num6; num7++)
							{
								pieSeries3.DataPoints.Add(new PieDataPoint(Convert.ToDouble(dataTable3.Rows[num7].ItemArray[0]), Convert.ToString(dataTable3.Rows[num7].ItemArray[1])));
							}
							bool flag15 = num6 == 5 & dataTable3.Rows.Count != 5;
							if (flag15)
							{
								double num8 = 0.0;
								for (int num9 = 5; num9 < dataTable3.Rows.Count; num9++)
								{
									num8 += Convert.ToDouble(dataTable3.Rows[num9].ItemArray[0]);
								}
								pieSeries3.DataPoints.Add(new PieDataPoint(num8, "Autres"));
							}
							this.radChartView2.Series.Add(pieSeries3);
						}
					}
				}
				bool isChecked6 = this.radRadioButton2.IsChecked;
				if (isChecked6)
				{
					List<string> list4 = new List<string>();
					for (int num10 = 0; num10 < this.radCheckedListBox2.Items.Count; num10++)
					{
						bool flag16 = this.radCheckedListBox2.Items[num10].CheckState == 1;
						if (flag16)
						{
							list4.Add(this.radCheckedListBox2.Items[num10].Tag.ToString());
						}
					}
					string str4 = string.Join(",", list4.ToArray());
					bool flag17 = list4.Count != 0;
					if (flag17)
					{
						string cmdText = "select sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)), sous_famille.designation from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id inner join article on da_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille  in (" + str4 + ")) and statut <> @d and statut <> @f and year(date_commande) = @d1  group by sous_famille.designation order by sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText, bd.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag18 = dataTable4.Rows.Count != 0;
						if (flag18)
						{
							PieSeries pieSeries4 = new PieSeries();
							pieSeries4.ShowLabels = true;
							pieSeries4.DrawLinesToLabels = true;
							pieSeries4.SyncLinesToLabelsColor = true;
							this.radChartView2.ShowTitle = false;
							this.radChartView2.ForeColor = Color.Firebrick;
							this.radChartView2.ShowLegend = true;
							int num11 = 7;
							bool flag19 = dataTable4.Rows.Count < num11;
							if (flag19)
							{
								num11 = dataTable4.Rows.Count;
							}
							for (int num12 = 0; num12 < num11; num12++)
							{
								pieSeries4.DataPoints.Add(new PieDataPoint(Convert.ToDouble(dataTable4.Rows[num12].ItemArray[0]), Convert.ToString(dataTable4.Rows[num12].ItemArray[1])));
							}
							bool flag20 = num11 == 7 & dataTable4.Rows.Count != 7;
							if (flag20)
							{
								double num13 = 0.0;
								for (int num14 = 7; num14 < dataTable4.Rows.Count; num14++)
								{
									num13 += Convert.ToDouble(dataTable4.Rows[num14].ItemArray[0]);
								}
								pieSeries4.DataPoints.Add(new PieDataPoint(num13, "Autres"));
							}
							this.radChartView2.Series.Add(pieSeries4);
						}
					}
				}
			}
			bool isChecked7 = this.radRadioButton8.IsChecked;
			if (isChecked7)
			{
				bool isChecked8 = this.radRadioButton1.IsChecked;
				if (isChecked8)
				{
					List<string> list5 = new List<string>();
					for (int num15 = 0; num15 < this.radCheckedListBox1.Items.Count; num15++)
					{
						bool flag21 = this.radCheckedListBox1.Items[num15].CheckState == 1;
						if (flag21)
						{
							list5.Add(this.radCheckedListBox1.Items[num15].Tag.ToString());
						}
					}
					string str5 = string.Join(",", list5.ToArray());
					bool flag22 = list5.Count != 0;
					if (flag22)
					{
						string cmdText = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), famille.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison inner join article on livraison_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + str5 + "))) and  year(date_reel) = @d1   group by famille.designation order by sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText, bd.cnn);
						sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag23 = dataTable5.Rows.Count != 0;
						if (flag23)
						{
							PieSeries pieSeries5 = new PieSeries();
							pieSeries5.ShowLabels = true;
							pieSeries5.DrawLinesToLabels = true;
							pieSeries5.SyncLinesToLabelsColor = true;
							this.radChartView2.ShowTitle = false;
							this.radChartView2.ForeColor = Color.Firebrick;
							this.radChartView2.ShowLegend = true;
							int num16 = 5;
							bool flag24 = dataTable5.Rows.Count < num16;
							if (flag24)
							{
								num16 = dataTable5.Rows.Count;
							}
							for (int num17 = 0; num17 < num16; num17++)
							{
								pieSeries5.DataPoints.Add(new PieDataPoint(Convert.ToDouble(dataTable5.Rows[num17].ItemArray[0]), Convert.ToString(dataTable5.Rows[num17].ItemArray[1])));
							}
							bool flag25 = num16 == 5 & dataTable5.Rows.Count != 5;
							if (flag25)
							{
								double num18 = 0.0;
								for (int num19 = 5; num19 < dataTable5.Rows.Count; num19++)
								{
									num18 += Convert.ToDouble(dataTable5.Rows[num19].ItemArray[0]);
								}
								pieSeries5.DataPoints.Add(new PieDataPoint(num18, "Autres"));
							}
							this.radChartView2.Series.Add(pieSeries5);
						}
					}
				}
				bool isChecked9 = this.radRadioButton2.IsChecked;
				if (isChecked9)
				{
					List<string> list6 = new List<string>();
					for (int num20 = 0; num20 < this.radCheckedListBox2.Items.Count; num20++)
					{
						bool flag26 = this.radCheckedListBox2.Items[num20].CheckState == 1;
						if (flag26)
						{
							list6.Add(this.radCheckedListBox2.Items[num20].Tag.ToString());
						}
					}
					string str6 = string.Join(",", list6.ToArray());
					bool flag27 = list6.Count != 0;
					if (flag27)
					{
						string cmdText = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), sous_famille.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison inner join article on livraison_article.id_article = article.id inner join tableau_article_sous_famille on article.id = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + str6 + ")) and  year(date_reel) = @d1   group by sous_famille.designation order by sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText, bd.cnn);
						sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
						DataTable dataTable6 = new DataTable();
						sqlDataAdapter6.Fill(dataTable6);
						bool flag28 = dataTable6.Rows.Count != 0;
						if (flag28)
						{
							PieSeries pieSeries6 = new PieSeries();
							pieSeries6.ShowLabels = true;
							pieSeries6.DrawLinesToLabels = true;
							pieSeries6.SyncLinesToLabelsColor = true;
							this.radChartView2.ShowTitle = false;
							this.radChartView2.ForeColor = Color.Firebrick;
							this.radChartView2.ShowLegend = true;
							int num21 = 7;
							bool flag29 = dataTable6.Rows.Count < num21;
							if (flag29)
							{
								num21 = dataTable6.Rows.Count;
							}
							for (int num22 = 0; num22 < num21; num22++)
							{
								pieSeries6.DataPoints.Add(new PieDataPoint(Convert.ToDouble(dataTable6.Rows[num22].ItemArray[0]), Convert.ToString(dataTable6.Rows[num22].ItemArray[1])));
							}
							bool flag30 = num21 == 7 & dataTable6.Rows.Count != 7;
							if (flag30)
							{
								double num23 = 0.0;
								for (int num24 = 7; num24 < dataTable6.Rows.Count; num24++)
								{
									num23 += Convert.ToDouble(dataTable6.Rows[num24].ItemArray[0]);
								}
								pieSeries6.DataPoints.Add(new PieDataPoint(num23, "Autres"));
							}
							this.radChartView2.Series.Add(pieSeries6);
						}
					}
				}
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x0027F2A4 File Offset: 0x0027D4A4
		private void emplacement_pie()
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.radChartView2.Location = new Point(708, 78);
				this.radChartView2.Size = new Size(396, 228);
			}
			else
			{
				this.radChartView2.Location = new Point(408, 78);
				this.radChartView2.Size = new Size(696, 228);
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0027F330 File Offset: 0x0027D530
		private void get_activite()
		{
			bd bd = new bd();
			this.radCheckedListBox1.Items.Clear();
			this.radCheckedListBox2.Items.Clear();
			string cmdText = "select id, designation from activite where deleted = @d order by designation";
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
					this.radCheckedListBox1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedListBox1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					this.radCheckedListBox1.Items[i].CheckState = 1;
				}
			}
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0027F464 File Offset: 0x0027D664
		private void get_activite_nbre_commande_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select count(distinct ds_commande.id),activite.id, activite.designation from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where activite.id in  (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by year(date_commande), activite.id,activite.designation order by count(distinct ds_commande.id) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select count(distinct ds_commande.id),activite.id, activite.designation from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by  activite.id,activite.designation order by count(distinct ds_commande.id) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande  where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x0027FBDC File Offset: 0x0027DDDC
		private void get_activite_nbre_commande_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select m from temporaire where id = @a and t = @b";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToString(dataTable.Rows[i].ItemArray[0]),
									" Commandes"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande), activite.id,activite.designation) select m from temporaire where id = @a and t = @b";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToString(dataTable4.Rows[k].ItemArray[0]),
									" Commandes"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00280654 File Offset: 0x0027E854
		private void get_activite_nbre_commande_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable.Rows[i].ItemArray[0]) + " Commandes";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable3.Rows[k].ItemArray[0]) + " Commandes";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x00280E20 File Offset: 0x0027F020
		private void get_activite_nbre_commande_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable.Rows[i].ItemArray[0]) + " Commandes";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToString(dataTable3.Rows[k].ItemArray[0]) + " Commandes";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x002815EC File Offset: 0x0027F7EC
		private void get_activite_nbre_commande_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x00281E50 File Offset: 0x00280050
		private void get_activite_nbre_commande_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x002826B4 File Offset: 0x002808B4
		private void get_activite_nbre_commande_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x00282F18 File Offset: 0x00281118
		private void get_activite_nbre_commande_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = " with temporaire as(select  count(distinct ds_commande.id) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Nbre des commandes des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m  and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x0028377C File Offset: 0x0028197C
		private void get_activite_total_commande_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)),activite.id, activite.designation from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by year(date_commande), activite.id,activite.designation order by  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)),activite.id, activite.designation from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by  activite.id,activite.designation order by  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x00283EF4 File Offset: 0x002820F4
		private void get_activite_total_commande_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande), activite.id,activite.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x00284988 File Offset: 0x00282B88
		private void get_activite_total_commande_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x00285170 File Offset: 0x00283370
		private void get_activite_total_commande_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x00285958 File Offset: 0x00283B58
		private void get_activite_total_commande_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x002861BC File Offset: 0x002843BC
		private void get_activite_total_commande_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x00286A20 File Offset: 0x00284C20
		private void get_activite_total_commande_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x00287284 File Offset: 0x00285484
		private void get_activite_total_commande_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, month(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) t ,activite.id, activite.designation, year(date_commande) m from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande inner join activite on ds_commande_article.id_activite = activite.id  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2 group by year(date_commande), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot Commandes (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x00287AE8 File Offset: 0x00285CE8
		private void get_activite_total_BL_somme(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)),activite.id, activite.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by year(date_reel), activite.id,activite.designation order by  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]);
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)),activite.id, activite.designation from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2  group by  activite.id,activite.designation order by  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]);
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x00288260 File Offset: 0x00286460
		private void get_activite_total_BL_extremum(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))  and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))  and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@b", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								string cmdText3 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))  and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - ",
									fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[0].ItemArray[0])),
									" - ",
									Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable3, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable3, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText4 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select max(t), id, designation from temporaire group by id,designation order by max(t) desc";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag6 = dataTable4.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable4.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable4.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText5 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2  group by year(date_reel), activite.id,activite.designation) select m from temporaire where id = @a order by t desc";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand5.Parameters.Add("@b", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[0];
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								string cmdText6 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1];
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable4.Rows[k].ItemArray[2]),
									" - Année :  ",
									Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]).ToString(),
									" - ",
									Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]).ToString("0.000"),
									" Dinars"
								});
								for (int l = 0; l < dataTable6.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable6.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable6.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable6.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x00288CF4 File Offset: 0x00286EF4
		private void get_activite_total_BL_etendue(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t)-min(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having max(t) <> min(t) order by max(t) - min(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							List<int> list = new List<int>();
							list.Add(0);
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x002894DC File Offset: 0x002876DC
		private void get_activite_total_BL_etendue_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select max(t)-min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t)-min(t)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = Convert.ToString(dataTable.Rows[i].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable.Rows[i].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select max(t) - min(t), id, designation from temporaire group by id,designation having count(id) > 1 order by max(t) - min(t)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = Convert.ToString(dataTable3.Rows[k].ItemArray[2]) + " - Etendue :  " + Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]).ToString("0.000") + " Dinars";
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x00289CC4 File Offset: 0x00287EC4
		private void get_activite_total_BL_ecart_type_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0028A528 File Offset: 0x00288728
		private void get_activite_total_BL_ecart_type_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by stdev(t) ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select stdev(t), id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by stdev(t) ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - σ =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x0028AD8C File Offset: 0x00288F8C
		private void get_activite_total_BL_c_variation_max(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 desc";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0028B5F0 File Offset: 0x002897F0
		private void get_activite_total_BL_c_variation_min(List<string> id_f, string liste_id)
		{
			bool flag = this.controle_saisie_top() == 1;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.TextBox1.Text) <= id_f.Count;
				if (flag2)
				{
					bool isChecked = this.radRadioButton5.IsChecked;
					if (isChecked)
					{
						bd bd = new bd();
						string cmdText = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, month(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) = @d1  group by month(date_reel), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1 order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							int num = Convert.ToInt32(this.TextBox1.Text);
							bool flag4 = dataTable.Rows.Count < num;
							if (flag4)
							{
								num = dataTable.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							for (int i = 0; i < num; i++)
							{
								string cmdText2 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) = @d1  group by month(date_reel) order by month(date_reel)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								LineSeries lineSeries = new LineSeries();
								lineSeries.ShowLabels = false;
								lineSeries.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable.Rows[i].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[3]), 2).ToString()
								});
								for (int j = 1; j <= 12; j++)
								{
									bool flag5 = this.test_existe_dtable(dataTable2, j) == 0;
									if (flag5)
									{
										lineSeries.DataPoints.Add(new CategoricalDataPoint(0.0, fonction.rendre_mois(j)));
									}
									else
									{
										int index = this.indice_dtable(dataTable2, j);
										lineSeries.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable2.Rows[index].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable2.Rows[index].ItemArray[1]))));
									}
								}
								this.radChartView1.Series.Add(lineSeries);
							}
						}
					}
					else
					{
						bd bd2 = new bd();
						string cmdText3 = "with temporaire as(select   sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) t ,activite.id, activite.designation, year(date_reel) m from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + liste_id + ")))   and year(date_reel) between @d1 and @d2 group by year(date_reel), activite.id,activite.designation) select (stdev(t) / avg(t)) * 100, id, designation, avg(t) from temporaire group by id,designation having count (id) > 1  order by (stdev(t) / avg(t)) * 100 ";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
						sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
						sqlCommand3.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							int num2 = Convert.ToInt32(this.TextBox1.Text);
							bool flag7 = dataTable3.Rows.Count < num2;
							if (flag7)
							{
								num2 = dataTable3.Rows.Count;
							}
							this.radChartView1.Title = "Tot BL (TND) des Activités";
							this.radChartView1.ShowTitle = true;
							this.radChartView1.ForeColor = Color.Firebrick;
							this.radChartView1.ShowLegend = true;
							List<int> list = new List<int>();
							list.Add(0);
							for (int k = 0; k < num2; k++)
							{
								string cmdText4 = "select  sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison  inner join tableau_article_sous_famille on livraison_article.id_article  = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id  where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille  = @m))   and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = dataTable3.Rows[k].ItemArray[1];
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								LineSeries lineSeries2 = new LineSeries();
								lineSeries2.ShowLabels = false;
								lineSeries2.LegendTitle = string.Concat(new string[]
								{
									Convert.ToString(dataTable3.Rows[k].ItemArray[2]),
									" - Cv =  ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[0]), 2).ToString(),
									" %  -  X̅ = ",
									Math.Round(Convert.ToDouble(dataTable3.Rows[k].ItemArray[3]), 2).ToString()
								});
								for (int l = 0; l < dataTable4.Rows.Count; l++)
								{
									int p = Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]);
									int index2 = this.combien_petit(list, p);
									lineSeries2.DataPoints.Insert(index2, new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable4.Rows[l].ItemArray[0]), 3), Convert.ToInt32(dataTable4.Rows[l].ItemArray[1])));
									bool flag8 = !list.Contains(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									if (flag8)
									{
										list.Add(Convert.ToInt32(dataTable4.Rows[l].ItemArray[1]));
									}
								}
								this.radChartView1.Series.Add(lineSeries2);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : La valeur TOP doit être inférieure ou égal au nombre des Activités choisis", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La valeur TOP doit être un entier strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x0028BE54 File Offset: 0x0028A054
		private void stat_activite()
		{
			this.radChartView1.Series.Clear();
			bool flag = this.radCheckedListBox1.Items.Count != 0;
			if (flag)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
				{
					bool flag2 = this.radCheckedListBox1.Items[i].CheckState == 1;
					if (flag2)
					{
						list.Add(this.radCheckedListBox1.Items[i].Tag.ToString());
					}
				}
				string text = string.Join(",", list.ToArray());
				bool flag3 = list.Count != 0;
				if (flag3)
				{
					bool isChecked = this.radRadioButton9.IsChecked;
					if (isChecked)
					{
						bool isChecked2 = this.radRadioButton5.IsChecked;
						if (isChecked2)
						{
							string text2 = "select count(distinct ds_commande.id), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande   where ds_commande_article.id_activite in (" + text + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
							string cmdText = "";
							bool isChecked3 = this.radRadioButton7.IsChecked;
							if (isChecked3)
							{
								cmdText = text2;
							}
							else
							{
								bool isChecked4 = this.radRadioButton13.IsChecked;
								if (isChecked4)
								{
									this.get_activite_nbre_commande_somme(list, text);
								}
								bool isChecked5 = this.radRadioButton12.IsChecked;
								if (isChecked5)
								{
									this.get_activite_nbre_commande_extremum(list, text);
								}
								bool isChecked6 = this.radRadioButton14.IsChecked;
								if (isChecked6)
								{
									this.get_activite_nbre_commande_etendue(list, text);
								}
								bool isChecked7 = this.radRadioButton15.IsChecked;
								if (isChecked7)
								{
									this.get_activite_nbre_commande_etendue_min(list, text);
								}
								bool isChecked8 = this.radRadioButton16.IsChecked;
								if (isChecked8)
								{
									this.get_activite_nbre_commande_ecart_type_max(list, text);
								}
								bool isChecked9 = this.radRadioButton17.IsChecked;
								if (isChecked9)
								{
									this.get_activite_nbre_commande_ecart_type_min(list, text);
								}
								bool isChecked10 = this.radRadioButton18.IsChecked;
								if (isChecked10)
								{
									this.get_activite_nbre_commande_c_variation_max(list, text);
								}
								bool isChecked11 = this.radRadioButton6.IsChecked;
								if (isChecked11)
								{
									this.get_activite_nbre_commande_c_variation_min(list, text);
								}
							}
							bool isChecked12 = this.radRadioButton7.IsChecked;
							if (isChecked12)
							{
								bd bd = new bd();
								fonction fonction = new fonction();
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
								DataTable dataTable = new DataTable();
								sqlDataAdapter.Fill(dataTable);
								bool flag4 = dataTable.Rows.Count != 0;
								if (flag4)
								{
									bool isChecked13 = this.radRadioButton7.IsChecked;
									if (isChecked13)
									{
										LineSeries lineSeries = new LineSeries();
										lineSeries.ShowLabels = true;
										lineSeries.PointSize = new SizeF(10f, 10f);
										this.radChartView1.Title = "Nbre des commandes des Activités";
										this.radChartView1.ShowTitle = true;
										this.radChartView1.ForeColor = Color.Firebrick;
										for (int j = 0; j < dataTable.Rows.Count; j++)
										{
											lineSeries.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable.Rows[j].ItemArray[0]), fonction.rendre_mois(Convert.ToInt32(dataTable.Rows[j].ItemArray[1]))));
										}
										this.radChartView1.Series.Add(lineSeries);
									}
								}
							}
						}
						bool isChecked14 = this.radRadioButton4.IsChecked;
						if (isChecked14)
						{
							string text3 = "select count(distinct ds_commande.id), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande   where ds_commande_article.id_activite in (" + text + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
							string cmdText2 = "";
							bool isChecked15 = this.radRadioButton7.IsChecked;
							if (isChecked15)
							{
								cmdText2 = text3;
							}
							else
							{
								bool isChecked16 = this.radRadioButton13.IsChecked;
								if (isChecked16)
								{
									this.get_activite_nbre_commande_somme(list, text);
								}
								bool isChecked17 = this.radRadioButton12.IsChecked;
								if (isChecked17)
								{
									this.get_activite_nbre_commande_extremum(list, text);
								}
								bool isChecked18 = this.radRadioButton14.IsChecked;
								if (isChecked18)
								{
									this.get_activite_nbre_commande_etendue(list, text);
								}
								bool isChecked19 = this.radRadioButton15.IsChecked;
								if (isChecked19)
								{
									this.get_activite_nbre_commande_etendue_min(list, text);
								}
								bool isChecked20 = this.radRadioButton16.IsChecked;
								if (isChecked20)
								{
									this.get_activite_nbre_commande_ecart_type_max(list, text);
								}
								bool isChecked21 = this.radRadioButton17.IsChecked;
								if (isChecked21)
								{
									this.get_activite_nbre_commande_ecart_type_min(list, text);
								}
								bool isChecked22 = this.radRadioButton18.IsChecked;
								if (isChecked22)
								{
									this.get_activite_nbre_commande_c_variation_max(list, text);
								}
								bool isChecked23 = this.radRadioButton6.IsChecked;
								if (isChecked23)
								{
									this.get_activite_nbre_commande_c_variation_min(list, text);
								}
							}
							bool isChecked24 = this.radRadioButton7.IsChecked;
							if (isChecked24)
							{
								bd bd2 = new bd();
								fonction fonction2 = new fonction();
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
								sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand2.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								bool flag5 = dataTable2.Rows.Count != 0;
								if (flag5)
								{
									LineSeries lineSeries2 = new LineSeries();
									lineSeries2.ShowLabels = true;
									lineSeries2.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Nbre des commandes des Activités";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int k = 0; k < dataTable2.Rows.Count; k++)
									{
										lineSeries2.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable2.Rows[k].ItemArray[0]), Convert.ToInt32(dataTable2.Rows[k].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries2);
								}
							}
						}
					}
					bool isChecked25 = this.radRadioButton10.IsChecked;
					if (isChecked25)
					{
						bool isChecked26 = this.radRadioButton5.IsChecked;
						if (isChecked26)
						{
							string text4 = "select  sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), month(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande   where ds_commande_article.id_activite in  (" + text + ") and statut <> @d and statut <> @f and year(date_commande) = @d1  group by month(date_commande) order by month(date_commande)";
							string cmdText3 = "";
							bool isChecked27 = this.radRadioButton7.IsChecked;
							if (isChecked27)
							{
								cmdText3 = text4;
							}
							else
							{
								bool isChecked28 = this.radRadioButton13.IsChecked;
								if (isChecked28)
								{
									this.get_activite_total_commande_somme(list, text);
								}
								bool isChecked29 = this.radRadioButton12.IsChecked;
								if (isChecked29)
								{
									this.get_activite_total_commande_extremum(list, text);
								}
								bool isChecked30 = this.radRadioButton14.IsChecked;
								if (isChecked30)
								{
									this.get_activite_total_commande_etendue(list, text);
								}
								bool isChecked31 = this.radRadioButton15.IsChecked;
								if (isChecked31)
								{
									this.get_activite_total_commande_etendue_min(list, text);
								}
								bool isChecked32 = this.radRadioButton16.IsChecked;
								if (isChecked32)
								{
									this.get_activite_total_commande_ecart_type_max(list, text);
								}
								bool isChecked33 = this.radRadioButton17.IsChecked;
								if (isChecked33)
								{
									this.get_activite_total_commande_ecart_type_min(list, text);
								}
								bool isChecked34 = this.radRadioButton18.IsChecked;
								if (isChecked34)
								{
									this.get_activite_total_commande_c_variation_max(list, text);
								}
								bool isChecked35 = this.radRadioButton6.IsChecked;
								if (isChecked35)
								{
									this.get_activite_total_commande_c_variation_min(list, text);
								}
							}
							bool isChecked36 = this.radRadioButton7.IsChecked;
							if (isChecked36)
							{
								bd bd3 = new bd();
								fonction fonction3 = new fonction();
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
								sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								bool flag6 = dataTable3.Rows.Count != 0;
								if (flag6)
								{
									LineSeries lineSeries3 = new LineSeries();
									lineSeries3.ShowLabels = false;
									lineSeries3.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot Commandes (TND) des Activités";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int l = 0; l < dataTable3.Rows.Count; l++)
									{
										lineSeries3.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable3.Rows[l].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable3.Rows[l].ItemArray[1]))));
									}
									this.radChartView1.Series.Add(lineSeries3);
								}
							}
						}
						bool isChecked37 = this.radRadioButton4.IsChecked;
						if (isChecked37)
						{
							string text5 = "select sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)), year(date_commande) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande   where ds_commande_article.id_activite  in (" + text + ") and statut <> @d and statut <> @f and year(date_commande) between @d1 and @d2  group by year(date_commande) order by year(date_commande)";
							string cmdText4 = "";
							bool isChecked38 = this.radRadioButton7.IsChecked;
							if (isChecked38)
							{
								cmdText4 = text5;
							}
							else
							{
								bool isChecked39 = this.radRadioButton13.IsChecked;
								if (isChecked39)
								{
									this.get_activite_total_commande_somme(list, text);
								}
								bool isChecked40 = this.radRadioButton12.IsChecked;
								if (isChecked40)
								{
									this.get_activite_total_commande_extremum(list, text);
								}
								bool isChecked41 = this.radRadioButton14.IsChecked;
								if (isChecked41)
								{
									this.get_activite_total_commande_etendue(list, text);
								}
								bool isChecked42 = this.radRadioButton15.IsChecked;
								if (isChecked42)
								{
									this.get_activite_total_commande_etendue_min(list, text);
								}
								bool isChecked43 = this.radRadioButton16.IsChecked;
								if (isChecked43)
								{
									this.get_activite_total_commande_ecart_type_max(list, text);
								}
								bool isChecked44 = this.radRadioButton17.IsChecked;
								if (isChecked44)
								{
									this.get_activite_total_commande_ecart_type_min(list, text);
								}
								bool isChecked45 = this.radRadioButton18.IsChecked;
								if (isChecked45)
								{
									this.get_activite_total_commande_c_variation_max(list, text);
								}
								bool isChecked46 = this.radRadioButton6.IsChecked;
								if (isChecked46)
								{
									this.get_activite_total_commande_c_variation_min(list, text);
								}
							}
							bool isChecked47 = this.radRadioButton7.IsChecked;
							if (isChecked47)
							{
								bd bd4 = new bd();
								fonction fonction4 = new fonction();
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd4.cnn);
								sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag7 = dataTable4.Rows.Count != 0;
								if (flag7)
								{
									LineSeries lineSeries4 = new LineSeries();
									lineSeries4.ShowLabels = false;
									lineSeries4.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot Commandes (TND) des Activités";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int m = 0; m < dataTable4.Rows.Count; m++)
									{
										lineSeries4.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable4.Rows[m].ItemArray[0]), Convert.ToInt32(dataTable4.Rows[m].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries4);
								}
							}
						}
					}
					bool isChecked48 = this.radRadioButton8.IsChecked;
					if (isChecked48)
					{
						bool isChecked49 = this.radRadioButton5.IsChecked;
						if (isChecked49)
						{
							string text6 = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), month(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + "))) and  year(date_reel) = @d1   group by month(date_reel) order by month(date_reel)";
							string cmdText5 = "";
							bool isChecked50 = this.radRadioButton7.IsChecked;
							if (isChecked50)
							{
								cmdText5 = text6;
							}
							else
							{
								bool isChecked51 = this.radRadioButton13.IsChecked;
								if (isChecked51)
								{
									this.get_activite_total_BL_somme(list, text);
								}
								bool isChecked52 = this.radRadioButton12.IsChecked;
								if (isChecked52)
								{
									this.get_activite_total_BL_extremum(list, text);
								}
								bool isChecked53 = this.radRadioButton14.IsChecked;
								if (isChecked53)
								{
									this.get_activite_total_BL_etendue(list, text);
								}
								bool isChecked54 = this.radRadioButton15.IsChecked;
								if (isChecked54)
								{
									this.get_activite_total_BL_etendue_min(list, text);
								}
								bool isChecked55 = this.radRadioButton16.IsChecked;
								if (isChecked55)
								{
									this.get_activite_total_BL_ecart_type_max(list, text);
								}
								bool isChecked56 = this.radRadioButton17.IsChecked;
								if (isChecked56)
								{
									this.get_activite_total_BL_ecart_type_min(list, text);
								}
								bool isChecked57 = this.radRadioButton18.IsChecked;
								if (isChecked57)
								{
									this.get_activite_total_BL_c_variation_max(list, text);
								}
								bool isChecked58 = this.radRadioButton6.IsChecked;
								if (isChecked58)
								{
									this.get_activite_total_BL_c_variation_min(list, text);
								}
							}
							bool isChecked59 = this.radRadioButton7.IsChecked;
							if (isChecked59)
							{
								bd bd5 = new bd();
								fonction fonction5 = new fonction();
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd5.cnn);
								sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value;
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								bool flag8 = dataTable5.Rows.Count != 0;
								if (flag8)
								{
									LineSeries lineSeries5 = new LineSeries();
									lineSeries5.ShowLabels = false;
									lineSeries5.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot BL (TND) des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int n = 0; n < dataTable5.Rows.Count; n++)
									{
										lineSeries5.DataPoints.Add(new CategoricalDataPoint(Math.Round(Convert.ToDouble(dataTable5.Rows[n].ItemArray[0]), 3), fonction.rendre_mois(Convert.ToInt32(dataTable5.Rows[n].ItemArray[1]))));
									}
									this.radChartView1.Series.Add(lineSeries5);
								}
							}
						}
						bool isChecked60 = this.radRadioButton4.IsChecked;
						if (isChecked60)
						{
							string text7 = "select sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)), year(date_reel) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison   where livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (" + text + ")))  and year(date_reel) between @d1 and @d2  group by year(date_reel) order by year(date_reel)";
							string cmdText6 = "";
							bool isChecked61 = this.radRadioButton7.IsChecked;
							if (isChecked61)
							{
								cmdText6 = text7;
							}
							else
							{
								bool isChecked62 = this.radRadioButton13.IsChecked;
								if (isChecked62)
								{
									this.get_activite_total_BL_somme(list, text);
								}
								bool isChecked63 = this.radRadioButton12.IsChecked;
								if (isChecked63)
								{
									this.get_activite_total_BL_extremum(list, text);
								}
								bool isChecked64 = this.radRadioButton14.IsChecked;
								if (isChecked64)
								{
									this.get_activite_total_BL_etendue(list, text);
								}
								bool isChecked65 = this.radRadioButton15.IsChecked;
								if (isChecked65)
								{
									this.get_activite_total_BL_etendue_min(list, text);
								}
								bool isChecked66 = this.radRadioButton16.IsChecked;
								if (isChecked66)
								{
									this.get_activite_total_BL_ecart_type_max(list, text);
								}
								bool isChecked67 = this.radRadioButton17.IsChecked;
								if (isChecked67)
								{
									this.get_activite_total_BL_ecart_type_min(list, text);
								}
								bool isChecked68 = this.radRadioButton18.IsChecked;
								if (isChecked68)
								{
									this.get_activite_total_BL_c_variation_max(list, text);
								}
								bool isChecked69 = this.radRadioButton6.IsChecked;
								if (isChecked69)
								{
									this.get_activite_total_BL_c_variation_min(list, text);
								}
							}
							bool isChecked70 = this.radRadioButton7.IsChecked;
							if (isChecked70)
							{
								bd bd6 = new bd();
								fonction fonction6 = new fonction();
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd6.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@f", SqlDbType.Int).Value = 5;
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value - 2m;
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Int).Value = this.guna2NumericUpDown1.Value + 2m;
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								bool flag9 = dataTable6.Rows.Count != 0;
								if (flag9)
								{
									LineSeries lineSeries6 = new LineSeries();
									lineSeries6.ShowLabels = false;
									lineSeries6.PointSize = new SizeF(10f, 10f);
									this.radChartView1.Title = "Tot BL (TND) des Familles";
									this.radChartView1.ShowTitle = true;
									this.radChartView1.ForeColor = Color.Firebrick;
									for (int num = 0; num < dataTable6.Rows.Count; num++)
									{
										lineSeries6.DataPoints.Add(new CategoricalDataPoint((double)Convert.ToInt32(dataTable6.Rows[num].ItemArray[0]), Convert.ToInt32(dataTable6.Rows[num].ItemArray[1])));
									}
									this.radChartView1.Series.Add(lineSeries6);
								}
							}
						}
					}
				}
			}
			bool flag10 = this.radChartView1.Axes.Count > 1;
			if (flag10)
			{
				this.axisform_shown();
			}
		}
	}
}
