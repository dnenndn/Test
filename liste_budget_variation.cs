using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200008B RID: 139
	public partial class liste_budget_variation : Form
	{
		// Token: 0x06000682 RID: 1666 RVA: 0x001184F3 File Offset: 0x001166F3
		public liste_budget_variation()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00118521 File Offset: 0x00116721
		private void liste_budget_variation_Load(object sender, EventArgs e)
		{
			this.les_dates.Clear();
			this.les_valeurs.Clear();
			this.remplissage_pointé(liste_budget.id_budget);
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00118548 File Offset: 0x00116748
		private void remplissage_pointé(string id_bud)
		{
			LineSeries lineSeries = new LineSeries();
			bd bd = new bd();
			string cmdText = "select montant from budget where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_bud;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
			}
			this.select_total_commande_encour(id_bud);
			bool flag2 = this.les_dates.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < this.les_dates.Count; i++)
				{
					bool flag3 = this.les_valeurs[i] > 0.0;
					if (flag3)
					{
						lineSeries.DataPoints.Add(new CategoricalDataPoint(this.les_valeurs[i], fonction.Mid(this.les_dates[i], 1, 10) ?? ""));
					}
				}
			}
			this.radChartView1.Series.Add(lineSeries);
			lineSeries.VerticalAxis.LabelInterval = 2;
			ChartPanZoomController chartPanZoomController = new ChartPanZoomController();
			chartPanZoomController.PanZoomMode = 0;
			this.radChartView1.Controllers.Add(chartPanZoomController);
			this.radChartView1.Zoom(2.0, 1.0);
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x001186E4 File Offset: 0x001168E4
		private void select_total_commande_encour(string id_bud)
		{
			bd bd = new bd();
			string cmdText = "select id, nom, date_creation, montant, categorie, fournisseur_choix, categorie_choix, duree, description from budget where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_bud;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0].ItemArray[2]);
				bool flag2 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque Jour";
				if (flag2)
				{
					dateTime = dateTime.AddDays(1.0);
				}
				bool flag3 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque Semaine";
				if (flag3)
				{
					dateTime = dateTime.AddDays(7.0);
				}
				bool flag4 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque 2 Semaine";
				if (flag4)
				{
					dateTime = dateTime.AddDays(14.0);
				}
				bool flag5 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque Mois";
				if (flag5)
				{
					dateTime = dateTime.AddMonths(1);
				}
				bool flag6 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque 2 Mois";
				if (flag6)
				{
					dateTime = dateTime.AddMonths(2);
				}
				bool flag7 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque Trimestre";
				if (flag7)
				{
					dateTime = dateTime.AddMonths(3);
				}
				bool flag8 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque Simestre";
				if (flag8)
				{
					dateTime = dateTime.AddMonths(6);
				}
				bool flag9 = dataTable.Rows[0].ItemArray[7].ToString() == "Chaque Année";
				if (flag9)
				{
					dateTime = dateTime.AddYears(1);
				}
				bool flag10 = dataTable.Rows[0].ItemArray[5].ToString() == "1";
				if (flag10)
				{
					bool flag11 = dataTable.Rows[0].ItemArray[4].ToString() == "1";
					if (flag11)
					{
						bool flag12 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
						if (flag12)
						{
							string cmdText2 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature ";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag13 = dataTable2.Rows.Count != 0;
							if (flag13)
							{
								fonction fonction = new fonction();
								for (int i = 0; i < dataTable2.Rows.Count; i++)
								{
									double item = 0.0;
									bool flag14 = fonction.is_reel(Convert.ToString(dataTable2.Rows[i].ItemArray[0]));
									if (flag14)
									{
										item = Convert.ToDouble(dataTable2.Rows[i].ItemArray[0]);
									}
									this.les_dates.Add(dataTable2.Rows[i].ItemArray[1].ToString());
									this.les_valeurs.Add(item);
								}
							}
						}
						bool flag15 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
						if (flag15)
						{
							string cmdText3 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							bool flag16 = dataTable3.Rows.Count != 0;
							if (flag16)
							{
								fonction fonction2 = new fonction();
								for (int j = 0; j < dataTable3.Rows.Count; j++)
								{
									double item2 = 0.0;
									bool flag17 = fonction2.is_reel(Convert.ToString(dataTable3.Rows[j].ItemArray[0]));
									if (flag17)
									{
										item2 = Convert.ToDouble(dataTable3.Rows[j].ItemArray[0]);
									}
									this.les_dates.Add(dataTable3.Rows[j].ItemArray[1].ToString());
									this.les_valeurs.Add(item2);
								}
							}
						}
						bool flag18 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
						if (flag18)
						{
							string cmdText4 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand4.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand4.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							bool flag19 = dataTable4.Rows.Count != 0;
							if (flag19)
							{
								fonction fonction3 = new fonction();
								for (int k = 0; k < dataTable4.Rows.Count; k++)
								{
									double item3 = 0.0;
									bool flag20 = fonction3.is_reel(Convert.ToString(dataTable4.Rows[k].ItemArray[0]));
									if (flag20)
									{
										item3 = Convert.ToDouble(dataTable4.Rows[k].ItemArray[0]);
									}
									this.les_dates.Add(dataTable4.Rows[k].ItemArray[1].ToString());
									this.les_valeurs.Add(item3);
								}
							}
						}
					}
					bool flag21 = dataTable.Rows[0].ItemArray[4].ToString() == "2";
					if (flag21)
					{
						bool flag22 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
						if (flag22)
						{
							string cmdText5 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand5.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand5.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							bool flag23 = dataTable5.Rows.Count != 0;
							if (flag23)
							{
								fonction fonction4 = new fonction();
								for (int l = 0; l < dataTable5.Rows.Count; l++)
								{
									double item4 = 0.0;
									bool flag24 = fonction4.is_reel(Convert.ToString(dataTable5.Rows[l].ItemArray[0]));
									if (flag24)
									{
										item4 = Convert.ToDouble(dataTable5.Rows[l].ItemArray[0]);
									}
									this.les_dates.Add(dataTable5.Rows[l].ItemArray[1].ToString());
									this.les_valeurs.Add(item4);
								}
							}
						}
						bool flag25 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
						if (flag25)
						{
							string cmdText6 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand6.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand6.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand6.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
							DataTable dataTable6 = new DataTable();
							sqlDataAdapter6.Fill(dataTable6);
							bool flag26 = dataTable6.Rows.Count != 0;
							if (flag26)
							{
								fonction fonction5 = new fonction();
								for (int m = 0; m < dataTable6.Rows.Count; m++)
								{
									double item5 = 0.0;
									bool flag27 = fonction5.is_reel(Convert.ToString(dataTable6.Rows[m].ItemArray[0]));
									if (flag27)
									{
										item5 = Convert.ToDouble(dataTable6.Rows[m].ItemArray[0]);
									}
									this.les_dates.Add(dataTable6.Rows[m].ItemArray[1].ToString());
									this.les_valeurs.Add(item5);
								}
							}
						}
						bool flag28 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
						if (flag28)
						{
							string cmdText7 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
							sqlCommand7.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand7.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							sqlCommand7.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand7.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
							DataTable dataTable7 = new DataTable();
							sqlDataAdapter7.Fill(dataTable7);
							bool flag29 = dataTable7.Rows.Count != 0;
							if (flag29)
							{
								fonction fonction6 = new fonction();
								for (int n = 0; n < dataTable7.Rows.Count; n++)
								{
									double item6 = 0.0;
									bool flag30 = fonction6.is_reel(Convert.ToString(dataTable7.Rows[n].ItemArray[0]));
									if (flag30)
									{
										item6 = Convert.ToDouble(dataTable7.Rows[n].ItemArray[0]);
									}
									this.les_dates.Add(dataTable7.Rows[n].ItemArray[1].ToString());
									this.les_valeurs.Add(item6);
								}
							}
						}
					}
					bool flag31 = dataTable.Rows[0].ItemArray[4].ToString() == "3";
					if (flag31)
					{
						bool flag32 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
						if (flag32)
						{
							string cmdText8 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id  where commande.date_signature between @d1 and @d2 and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
							sqlCommand8.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand8.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand8.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand8.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
							DataTable dataTable8 = new DataTable();
							sqlDataAdapter8.Fill(dataTable8);
							bool flag33 = dataTable8.Rows.Count != 0;
							if (flag33)
							{
								fonction fonction7 = new fonction();
								for (int num = 0; num < dataTable8.Rows.Count; num++)
								{
									double item7 = 0.0;
									bool flag34 = fonction7.is_reel(Convert.ToString(dataTable8.Rows[num].ItemArray[0]));
									if (flag34)
									{
										item7 = Convert.ToDouble(dataTable8.Rows[num].ItemArray[0]);
									}
									this.les_dates.Add(dataTable8.Rows[num].ItemArray[1].ToString());
									this.les_valeurs.Add(item7);
								}
							}
						}
						bool flag35 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
						if (flag35)
						{
							string cmdText9 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and da_article.id_article in (select id_categorie from budget_categorie where id_budget = @i) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
							sqlCommand9.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand9.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							sqlCommand9.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand9.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(sqlCommand9);
							DataTable dataTable9 = new DataTable();
							sqlDataAdapter9.Fill(dataTable9);
							bool flag36 = dataTable9.Rows.Count != 0;
							if (flag36)
							{
								fonction fonction8 = new fonction();
								for (int num2 = 0; num2 < dataTable9.Rows.Count; num2++)
								{
									double item8 = 0.0;
									bool flag37 = fonction8.is_reel(Convert.ToString(dataTable9.Rows[num2].ItemArray[0]));
									if (flag37)
									{
										item8 = Convert.ToDouble(dataTable9.Rows[num2].ItemArray[0]);
									}
									this.les_dates.Add(dataTable9.Rows[num2].ItemArray[1].ToString());
									this.les_valeurs.Add(item8);
								}
							}
						}
						bool flag38 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
						if (flag38)
						{
							string cmdText10 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and da_article.id_article not in (select id_categorie from budget_categorie where id_budget = @i) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
							SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd.cnn);
							sqlCommand10.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
							sqlCommand10.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
							sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							sqlCommand10.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand10.Parameters.Add("@a", SqlDbType.Int).Value = 5;
							SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(sqlCommand10);
							DataTable dataTable10 = new DataTable();
							sqlDataAdapter10.Fill(dataTable10);
							bool flag39 = dataTable10.Rows.Count != 0;
							if (flag39)
							{
								fonction fonction9 = new fonction();
								for (int num3 = 0; num3 < dataTable10.Rows.Count; num3++)
								{
									double item9 = 0.0;
									bool flag40 = fonction9.is_reel(Convert.ToString(dataTable10.Rows[num3].ItemArray[0]));
									if (flag40)
									{
										item9 = Convert.ToDouble(dataTable10.Rows[num3].ItemArray[0]);
									}
									this.les_dates.Add(dataTable10.Rows[num3].ItemArray[1].ToString());
									this.les_valeurs.Add(item9);
								}
							}
						}
					}
				}
				else
				{
					bool flag41 = dataTable.Rows[0].ItemArray[5].ToString() == "2";
					if (flag41)
					{
						bool flag42 = dataTable.Rows[0].ItemArray[4].ToString() == "1";
						if (flag42)
						{
							bool flag43 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
							if (flag43)
							{
								string cmdText11 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand11 = new SqlCommand(cmdText11, bd.cnn);
								sqlCommand11.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand11.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand11.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand11.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand11.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(sqlCommand11);
								DataTable dataTable11 = new DataTable();
								sqlDataAdapter11.Fill(dataTable11);
								bool flag44 = dataTable11.Rows.Count != 0;
								if (flag44)
								{
									fonction fonction10 = new fonction();
									for (int num4 = 0; num4 < dataTable11.Rows.Count; num4++)
									{
										double item10 = 0.0;
										bool flag45 = fonction10.is_reel(Convert.ToString(dataTable11.Rows[num4].ItemArray[0]));
										if (flag45)
										{
											item10 = Convert.ToDouble(dataTable11.Rows[num4].ItemArray[0]);
										}
										this.les_dates.Add(dataTable11.Rows[num4].ItemArray[1].ToString());
										this.les_valeurs.Add(item10);
									}
								}
							}
							bool flag46 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
							if (flag46)
							{
								string cmdText12 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and  commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand12 = new SqlCommand(cmdText12, bd.cnn);
								sqlCommand12.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand12.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand12.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand12.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand12.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(sqlCommand12);
								DataTable dataTable12 = new DataTable();
								sqlDataAdapter12.Fill(dataTable12);
								bool flag47 = dataTable12.Rows.Count != 0;
								if (flag47)
								{
									fonction fonction11 = new fonction();
									for (int num5 = 0; num5 < dataTable12.Rows.Count; num5++)
									{
										double item11 = 0.0;
										bool flag48 = fonction11.is_reel(Convert.ToString(dataTable12.Rows[num5].ItemArray[0]));
										if (flag48)
										{
											item11 = Convert.ToDouble(dataTable12.Rows[num5].ItemArray[0]);
										}
										this.les_dates.Add(dataTable12.Rows[num5].ItemArray[1].ToString());
										this.les_valeurs.Add(item11);
									}
								}
							}
							bool flag49 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
							if (flag49)
							{
								string cmdText13 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand13 = new SqlCommand(cmdText13, bd.cnn);
								sqlCommand13.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand13.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand13.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand13.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand13.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(sqlCommand13);
								DataTable dataTable13 = new DataTable();
								sqlDataAdapter13.Fill(dataTable13);
								bool flag50 = dataTable13.Rows.Count != 0;
								if (flag50)
								{
									fonction fonction12 = new fonction();
									for (int num6 = 0; num6 < dataTable13.Rows.Count; num6++)
									{
										double item12 = 0.0;
										bool flag51 = fonction12.is_reel(Convert.ToString(dataTable13.Rows[num6].ItemArray[0]));
										if (flag51)
										{
											item12 = Convert.ToDouble(dataTable13.Rows[num6].ItemArray[0]);
										}
										this.les_dates.Add(dataTable13.Rows[num6].ItemArray[1].ToString());
										this.les_valeurs.Add(item12);
									}
								}
							}
						}
						bool flag52 = dataTable.Rows[0].ItemArray[4].ToString() == "2";
						if (flag52)
						{
							bool flag53 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
							if (flag53)
							{
								string cmdText14 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand14 = new SqlCommand(cmdText14, bd.cnn);
								sqlCommand14.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand14.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand14.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand14.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand14.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(sqlCommand14);
								DataTable dataTable14 = new DataTable();
								sqlDataAdapter14.Fill(dataTable14);
								bool flag54 = dataTable14.Rows.Count != 0;
								if (flag54)
								{
									fonction fonction13 = new fonction();
									for (int num7 = 0; num7 < dataTable14.Rows.Count; num7++)
									{
										double item13 = 0.0;
										bool flag55 = fonction13.is_reel(Convert.ToString(dataTable14.Rows[num7].ItemArray[0]));
										if (flag55)
										{
											item13 = Convert.ToDouble(dataTable14.Rows[num7].ItemArray[0]);
										}
										this.les_dates.Add(dataTable14.Rows[num7].ItemArray[1].ToString());
										this.les_valeurs.Add(item13);
									}
								}
							}
							bool flag56 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
							if (flag56)
							{
								string cmdText15 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and   commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))  and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand15 = new SqlCommand(cmdText15, bd.cnn);
								sqlCommand15.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand15.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand15.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand15.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand15.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(sqlCommand15);
								DataTable dataTable15 = new DataTable();
								sqlDataAdapter15.Fill(dataTable15);
								bool flag57 = dataTable15.Rows.Count != 0;
								if (flag57)
								{
									fonction fonction14 = new fonction();
									for (int num8 = 0; num8 < dataTable15.Rows.Count; num8++)
									{
										double item14 = 0.0;
										bool flag58 = fonction14.is_reel(Convert.ToString(dataTable15.Rows[num8].ItemArray[0]));
										if (flag58)
										{
											item14 = Convert.ToDouble(dataTable15.Rows[num8].ItemArray[0]);
										}
										this.les_dates.Add(dataTable15.Rows[num8].ItemArray[1].ToString());
										this.les_valeurs.Add(item14);
									}
								}
							}
							bool flag59 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
							if (flag59)
							{
								string cmdText16 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and  commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand16 = new SqlCommand(cmdText16, bd.cnn);
								sqlCommand16.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand16.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand16.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand16.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand16.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(sqlCommand16);
								DataTable dataTable16 = new DataTable();
								sqlDataAdapter16.Fill(dataTable16);
								bool flag60 = dataTable16.Rows.Count != 0;
								if (flag60)
								{
									fonction fonction15 = new fonction();
									for (int num9 = 0; num9 < dataTable16.Rows.Count; num9++)
									{
										double item15 = 0.0;
										bool flag61 = fonction15.is_reel(Convert.ToString(dataTable16.Rows[num9].ItemArray[0]));
										if (flag61)
										{
											item15 = Convert.ToDouble(dataTable16.Rows[num9].ItemArray[0]);
										}
										this.les_dates.Add(dataTable16.Rows[num9].ItemArray[1].ToString());
										this.les_valeurs.Add(item15);
									}
								}
							}
						}
						bool flag62 = dataTable.Rows[0].ItemArray[4].ToString() == "3";
						if (flag62)
						{
							bool flag63 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
							if (flag63)
							{
								string cmdText17 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand17 = new SqlCommand(cmdText17, bd.cnn);
								sqlCommand17.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand17.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand17.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand17.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand17.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(sqlCommand17);
								DataTable dataTable17 = new DataTable();
								sqlDataAdapter17.Fill(dataTable17);
								bool flag64 = dataTable17.Rows.Count != 0;
								if (flag64)
								{
									fonction fonction16 = new fonction();
									for (int num10 = 0; num10 < dataTable17.Rows.Count; num10++)
									{
										double item16 = 0.0;
										bool flag65 = fonction16.is_reel(Convert.ToString(dataTable17.Rows[num10].ItemArray[0]));
										if (flag65)
										{
											item16 = Convert.ToDouble(dataTable17.Rows[num10].ItemArray[0]);
										}
										this.les_dates.Add(dataTable17.Rows[num10].ItemArray[1].ToString());
										this.les_valeurs.Add(item16);
									}
								}
							}
							bool flag66 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
							if (flag66)
							{
								string cmdText18 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))  and  da_article.id_article in (select id_categorie from budget_categorie where id_budget = @i) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand18 = new SqlCommand(cmdText18, bd.cnn);
								sqlCommand18.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand18.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand18.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand18.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand18.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(sqlCommand18);
								DataTable dataTable18 = new DataTable();
								sqlDataAdapter18.Fill(dataTable18);
								bool flag67 = dataTable18.Rows.Count != 0;
								if (flag67)
								{
									fonction fonction17 = new fonction();
									for (int num11 = 0; num11 < dataTable18.Rows.Count; num11++)
									{
										double item17 = 0.0;
										bool flag68 = fonction17.is_reel(Convert.ToString(dataTable18.Rows[num11].ItemArray[0]));
										if (flag68)
										{
											item17 = Convert.ToDouble(dataTable18.Rows[num11].ItemArray[0]);
										}
										this.les_dates.Add(dataTable18.Rows[num11].ItemArray[1].ToString());
										this.les_valeurs.Add(item17);
									}
								}
							}
							bool flag69 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
							if (flag69)
							{
								string cmdText19 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))  and da_article.id_article not in (select id_categorie from budget_categorie where id_budget = @i) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand19 = new SqlCommand(cmdText19, bd.cnn);
								sqlCommand19.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand19.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand19.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand19.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand19.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(sqlCommand19);
								DataTable dataTable19 = new DataTable();
								sqlDataAdapter19.Fill(dataTable19);
								bool flag70 = dataTable19.Rows.Count != 0;
								if (flag70)
								{
									fonction fonction18 = new fonction();
									for (int num12 = 0; num12 < dataTable19.Rows.Count; num12++)
									{
										double item18 = 0.0;
										bool flag71 = fonction18.is_reel(Convert.ToString(dataTable19.Rows[num12].ItemArray[0]));
										if (flag71)
										{
											item18 = Convert.ToDouble(dataTable19.Rows[num12].ItemArray[0]);
										}
										this.les_dates.Add(dataTable19.Rows[num12].ItemArray[1].ToString());
										this.les_valeurs.Add(item18);
									}
								}
							}
						}
					}
					else
					{
						bool flag72 = dataTable.Rows[0].ItemArray[4].ToString() == "1";
						if (flag72)
						{
							bool flag73 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
							if (flag73)
							{
								string cmdText20 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand20 = new SqlCommand(cmdText20, bd.cnn);
								sqlCommand20.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand20.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand20.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand20.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand20.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(sqlCommand20);
								DataTable dataTable20 = new DataTable();
								sqlDataAdapter20.Fill(dataTable20);
								bool flag74 = dataTable20.Rows.Count != 0;
								if (flag74)
								{
									fonction fonction19 = new fonction();
									for (int num13 = 0; num13 < dataTable20.Rows.Count; num13++)
									{
										double item19 = 0.0;
										bool flag75 = fonction19.is_reel(Convert.ToString(dataTable20.Rows[num13].ItemArray[0]));
										if (flag75)
										{
											item19 = Convert.ToDouble(dataTable20.Rows[num13].ItemArray[0]);
										}
										this.les_dates.Add(dataTable20.Rows[num13].ItemArray[1].ToString());
										this.les_valeurs.Add(item19);
									}
								}
							}
							bool flag76 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
							if (flag76)
							{
								string cmdText21 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand21 = new SqlCommand(cmdText21, bd.cnn);
								sqlCommand21.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand21.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand21.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand21.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand21.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(sqlCommand21);
								DataTable dataTable21 = new DataTable();
								sqlDataAdapter21.Fill(dataTable21);
								bool flag77 = dataTable21.Rows.Count != 0;
								if (flag77)
								{
									fonction fonction20 = new fonction();
									for (int num14 = 0; num14 < dataTable21.Rows.Count; num14++)
									{
										double item20 = 0.0;
										bool flag78 = fonction20.is_reel(Convert.ToString(dataTable21.Rows[num14].ItemArray[0]));
										if (flag78)
										{
											item20 = Convert.ToDouble(dataTable21.Rows[num14].ItemArray[0]);
										}
										this.les_dates.Add(dataTable21.Rows[num14].ItemArray[1].ToString());
										this.les_valeurs.Add(item20);
									}
								}
							}
							bool flag79 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
							if (flag79)
							{
								string cmdText22 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i))) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand22 = new SqlCommand(cmdText22, bd.cnn);
								sqlCommand22.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand22.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand22.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand22.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand22.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(sqlCommand22);
								DataTable dataTable22 = new DataTable();
								sqlDataAdapter22.Fill(dataTable22);
								bool flag80 = dataTable22.Rows.Count != 0;
								if (flag80)
								{
									fonction fonction21 = new fonction();
									for (int num15 = 0; num15 < dataTable22.Rows.Count; num15++)
									{
										double item21 = 0.0;
										bool flag81 = fonction21.is_reel(Convert.ToString(dataTable22.Rows[num15].ItemArray[0]));
										if (flag81)
										{
											item21 = Convert.ToDouble(dataTable22.Rows[num15].ItemArray[0]);
										}
										this.les_dates.Add(dataTable22.Rows[num15].ItemArray[1].ToString());
										this.les_valeurs.Add(item21);
									}
								}
							}
						}
						bool flag82 = dataTable.Rows[0].ItemArray[4].ToString() == "2";
						if (flag82)
						{
							bool flag83 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
							if (flag83)
							{
								string cmdText23 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand23 = new SqlCommand(cmdText23, bd.cnn);
								sqlCommand23.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand23.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand23.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand23.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand23.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(sqlCommand23);
								DataTable dataTable23 = new DataTable();
								sqlDataAdapter23.Fill(dataTable23);
								bool flag84 = dataTable23.Rows.Count != 0;
								if (flag84)
								{
									fonction fonction22 = new fonction();
									for (int num16 = 0; num16 < dataTable23.Rows.Count; num16++)
									{
										double item22 = 0.0;
										bool flag85 = fonction22.is_reel(Convert.ToString(dataTable23.Rows[num16].ItemArray[0]));
										if (flag85)
										{
											item22 = Convert.ToDouble(dataTable23.Rows[num16].ItemArray[0]);
										}
										this.les_dates.Add(dataTable23.Rows[num16].ItemArray[1].ToString());
										this.les_valeurs.Add(item22);
									}
								}
							}
							bool flag86 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
							if (flag86)
							{
								string cmdText24 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and  commande.id  in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))  and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand24 = new SqlCommand(cmdText24, bd.cnn);
								sqlCommand24.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand24.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand24.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand24.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand24.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(sqlCommand24);
								DataTable dataTable24 = new DataTable();
								sqlDataAdapter24.Fill(dataTable24);
								bool flag87 = dataTable24.Rows.Count != 0;
								if (flag87)
								{
									fonction fonction23 = new fonction();
									for (int num17 = 0; num17 < dataTable24.Rows.Count; num17++)
									{
										double item23 = 0.0;
										bool flag88 = fonction23.is_reel(Convert.ToString(dataTable24.Rows[num17].ItemArray[0]));
										if (flag88)
										{
											item23 = Convert.ToDouble(dataTable24.Rows[num17].ItemArray[0]);
										}
										this.les_dates.Add(dataTable24.Rows[num17].ItemArray[1].ToString());
										this.les_valeurs.Add(item23);
									}
								}
							}
							bool flag89 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
							if (flag89)
							{
								string cmdText25 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and  commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand25 = new SqlCommand(cmdText25, bd.cnn);
								sqlCommand25.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand25.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand25.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand25.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand25.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(sqlCommand25);
								DataTable dataTable25 = new DataTable();
								sqlDataAdapter25.Fill(dataTable25);
								bool flag90 = dataTable25.Rows.Count != 0;
								if (flag90)
								{
									fonction fonction24 = new fonction();
									for (int num18 = 0; num18 < dataTable25.Rows.Count; num18++)
									{
										double item24 = 0.0;
										bool flag91 = fonction24.is_reel(Convert.ToString(dataTable25.Rows[num18].ItemArray[0]));
										if (flag91)
										{
											item24 = Convert.ToDouble(dataTable25.Rows[num18].ItemArray[0]);
										}
										this.les_dates.Add(dataTable25.Rows[num18].ItemArray[1].ToString());
										this.les_valeurs.Add(item24);
									}
								}
							}
						}
						bool flag92 = dataTable.Rows[0].ItemArray[4].ToString() == "3";
						if (flag92)
						{
							bool flag93 = dataTable.Rows[0].ItemArray[6].ToString() == "1";
							if (flag93)
							{
								string cmdText26 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand26 = new SqlCommand(cmdText26, bd.cnn);
								sqlCommand26.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand26.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand26.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand26.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand26.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(sqlCommand26);
								DataTable dataTable26 = new DataTable();
								sqlDataAdapter26.Fill(dataTable26);
								bool flag94 = dataTable26.Rows.Count != 0;
								if (flag94)
								{
									fonction fonction25 = new fonction();
									for (int num19 = 0; num19 < dataTable26.Rows.Count; num19++)
									{
										double item25 = 0.0;
										bool flag95 = fonction25.is_reel(Convert.ToString(dataTable26.Rows[num19].ItemArray[0]));
										if (flag95)
										{
											item25 = Convert.ToDouble(dataTable26.Rows[num19].ItemArray[0]);
										}
										this.les_dates.Add(dataTable26.Rows[num19].ItemArray[1].ToString());
										this.les_valeurs.Add(item25);
									}
								}
							}
							bool flag96 = dataTable.Rows[0].ItemArray[6].ToString() == "2";
							if (flag96)
							{
								string cmdText27 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))  and  da_article.id_article in (select id_categorie from budget_categorie where id_budget = @i) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand27 = new SqlCommand(cmdText27, bd.cnn);
								sqlCommand27.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand27.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand27.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand27.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand27.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(sqlCommand27);
								DataTable dataTable27 = new DataTable();
								sqlDataAdapter27.Fill(dataTable27);
								bool flag97 = dataTable27.Rows.Count != 0;
								if (flag97)
								{
									fonction fonction26 = new fonction();
									for (int num20 = 0; num20 < dataTable27.Rows.Count; num20++)
									{
										double item26 = 0.0;
										bool flag98 = fonction26.is_reel(Convert.ToString(dataTable27.Rows[num20].ItemArray[0]));
										if (flag98)
										{
											item26 = Convert.ToDouble(dataTable27.Rows[num20].ItemArray[0]);
										}
										this.les_dates.Add(dataTable27.Rows[num20].ItemArray[1].ToString());
										this.les_valeurs.Add(item26);
									}
								}
							}
							bool flag99 = dataTable.Rows[0].ItemArray[6].ToString() == "3";
							if (flag99)
							{
								string cmdText28 = "select sum(qt_commande*prix_ht - (qt_commande*prix_ht*remise/100)), commande.date_signature from commande_article inner join commande on commande_article.id_commande = commande.id inner join da_article on commande_article.id_da_article = da_article.id where commande.date_signature between @d1 and @d2 and commande.id in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))  and da_article.id_article not in (select id_categorie from budget_categorie where id_budget = @i) and statut <> @d and statut <> @a group by commande.date_signature order by commande.date_signature";
								SqlCommand sqlCommand28 = new SqlCommand(cmdText28, bd.cnn);
								sqlCommand28.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[0].ItemArray[2];
								sqlCommand28.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand28.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
								sqlCommand28.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand28.Parameters.Add("@a", SqlDbType.Int).Value = 5;
								SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(sqlCommand28);
								DataTable dataTable28 = new DataTable();
								sqlDataAdapter28.Fill(dataTable28);
								bool flag100 = dataTable28.Rows.Count != 0;
								if (flag100)
								{
									fonction fonction27 = new fonction();
									for (int num21 = 0; num21 < dataTable28.Rows.Count; num21++)
									{
										double item27 = 0.0;
										bool flag101 = fonction27.is_reel(Convert.ToString(dataTable28.Rows[num21].ItemArray[0]));
										if (flag101)
										{
											item27 = Convert.ToDouble(dataTable28.Rows[num21].ItemArray[0]);
										}
										this.les_dates.Add(dataTable28.Rows[num21].ItemArray[1].ToString());
										this.les_valeurs.Add(item27);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x040008A7 RID: 2215
		private List<string> les_dates = new List<string>();

		// Token: 0x040008A8 RID: 2216
		private List<double> les_valeurs = new List<double>();
	}
}
