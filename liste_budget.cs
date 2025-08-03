using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace GMAO
{
	// Token: 0x02000086 RID: 134
	public partial class liste_budget : Form
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x00103954 File Offset: 0x00101B54
		public liste_budget()
		{
			this.InitializeComponent();
			liste_budget.id_budget = "";
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(this.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			this.radGridView1.SelectionChanged += this.RadGridView1_SelectionChanged;
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.label20.Hide();
			this.label19.Hide();
			this.radDateTimePicker1.Hide();
			this.radDateTimePicker2.Hide();
			this.remplissage_tableau1();
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00103A68 File Offset: 0x00101C68
		private void RadGridView1_SelectionChanged(object sender, EventArgs e)
		{
			liste_budget.id_budget = this.radGridView1.CurrentRow.Cells[0].Value.ToString();
			bool flag = this.button2.BackColor == Color.White;
			if (flag)
			{
				liste_budget_variation liste_budget_variation = new liste_budget_variation();
				liste_budget_variation.TopLevel = false;
				this.panel4.Controls.Clear();
				this.panel4.Controls.Add(liste_budget_variation);
				liste_budget_variation.Show();
			}
			else
			{
				liste_budget_general_tous liste_budget_general_tous = new liste_budget_general_tous();
				liste_budget_general_tous.TopLevel = false;
				this.panel4.Controls.Clear();
				this.panel4.Controls.Add(liste_budget_general_tous);
				liste_budget_general_tous.Show();
			}
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00103B2C File Offset: 0x00101D2C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 7;
			if (flag)
			{
				string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete budget where id = @i";
					string cmdText2 = "delete budget_categorie where id_budget = @i";
					string cmdText3 = "delete budget_fournisseur where id_budget = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					sqlCommand2.ExecuteNonQuery();
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
					this.remplissage_tableau1();
				}
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00103C77 File Offset: 0x00101E77
		private void liste_budget_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00103C7C File Offset: 0x00101E7C
		private double calcul_prix_total(double qt, double prix_ht, double remise)
		{
			return qt * prix_ht - qt * prix_ht * remise / 100.0;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00103CB0 File Offset: 0x00101EB0
		private void remplissage_tableau1()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id, nom, date_creation, montant, categorie, fournisseur_choix, categorie_choix, duree, description from budget where creer_nv = @a";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DateTime dateTime = Convert.ToDateTime(dataTable.Rows[i].ItemArray[2]);
					bool flag2 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Jour";
					if (flag2)
					{
						dateTime = dateTime.AddDays(1.0);
					}
					bool flag3 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Semaine";
					if (flag3)
					{
						dateTime = dateTime.AddDays(7.0);
					}
					bool flag4 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque 2 Semaine";
					if (flag4)
					{
						dateTime = dateTime.AddDays(14.0);
					}
					bool flag5 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Mois";
					if (flag5)
					{
						dateTime = dateTime.AddMonths(1);
					}
					bool flag6 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque 2 Mois";
					if (flag6)
					{
						dateTime = dateTime.AddMonths(2);
					}
					bool flag7 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Trimestre";
					if (flag7)
					{
						dateTime = dateTime.AddMonths(3);
					}
					bool flag8 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Simestre";
					if (flag8)
					{
						dateTime = dateTime.AddMonths(6);
					}
					bool flag9 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Année";
					if (flag9)
					{
						dateTime = dateTime.AddYears(1);
					}
					bool flag10 = dataTable.Rows[i].ItemArray[5].ToString() == "1";
					if (flag10)
					{
						bool flag11 = dataTable.Rows[i].ItemArray[4].ToString() == "1";
						if (flag11)
						{
							bool flag12 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
							if (flag12)
							{
								string cmdText2 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								bool flag13 = dataTable2.Rows.Count != 0;
								if (flag13)
								{
									fonction fonction = new fonction();
									double num = 0.0;
									bool flag14 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
									if (flag14)
									{
										num = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag15 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
							if (flag15)
							{
								string cmdText3 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i)))";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								bool flag16 = dataTable3.Rows.Count != 0;
								if (flag16)
								{
									fonction fonction2 = new fonction();
									double num2 = 0.0;
									bool flag17 = fonction2.is_reel(Convert.ToString(dataTable3.Rows[0].ItemArray[0]));
									if (flag17)
									{
										num2 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num2.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag18 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
							if (flag18)
							{
								string cmdText4 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag19 = dataTable4.Rows.Count != 0;
								if (flag19)
								{
									fonction fonction3 = new fonction();
									double num3 = 0.0;
									bool flag20 = fonction3.is_reel(Convert.ToString(dataTable4.Rows[0].ItemArray[0]));
									if (flag20)
									{
										num3 = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num3.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
						}
						bool flag21 = dataTable.Rows[i].ItemArray[4].ToString() == "2";
						if (flag21)
						{
							bool flag22 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
							if (flag22)
							{
								string cmdText5 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								bool flag23 = dataTable5.Rows.Count != 0;
								if (flag23)
								{
									fonction fonction4 = new fonction();
									double num4 = 0.0;
									bool flag24 = fonction4.is_reel(Convert.ToString(dataTable5.Rows[0].ItemArray[0]));
									if (flag24)
									{
										num4 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num4.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag25 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
							if (flag25)
							{
								string cmdText6 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i))";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								bool flag26 = dataTable6.Rows.Count != 0;
								if (flag26)
								{
									fonction fonction5 = new fonction();
									double num5 = 0.0;
									bool flag27 = fonction5.is_reel(Convert.ToString(dataTable6.Rows[0].ItemArray[0]));
									if (flag27)
									{
										num5 = Convert.ToDouble(dataTable6.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num5.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag28 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
							if (flag28)
							{
								string cmdText7 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i))";
								SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
								sqlCommand7.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand7.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
								DataTable dataTable7 = new DataTable();
								sqlDataAdapter7.Fill(dataTable7);
								bool flag29 = dataTable7.Rows.Count != 0;
								if (flag29)
								{
									fonction fonction6 = new fonction();
									double num6 = 0.0;
									bool flag30 = fonction6.is_reel(Convert.ToString(dataTable7.Rows[0].ItemArray[0]));
									if (flag30)
									{
										num6 = Convert.ToDouble(dataTable7.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num6.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
						}
						bool flag31 = dataTable.Rows[i].ItemArray[4].ToString() == "3";
						if (flag31)
						{
							bool flag32 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
							if (flag32)
							{
								string cmdText8 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2";
								SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
								sqlCommand8.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand8.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
								DataTable dataTable8 = new DataTable();
								sqlDataAdapter8.Fill(dataTable8);
								bool flag33 = dataTable8.Rows.Count != 0;
								if (flag33)
								{
									fonction fonction7 = new fonction();
									double num7 = 0.0;
									bool flag34 = fonction7.is_reel(Convert.ToString(dataTable8.Rows[0].ItemArray[0]));
									if (flag34)
									{
										num7 = Convert.ToDouble(dataTable8.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num7.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag35 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
							if (flag35)
							{
								string cmdText9 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_categorie from budget_categorie where id_budget = @i)";
								SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
								sqlCommand9.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand9.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(sqlCommand9);
								DataTable dataTable9 = new DataTable();
								sqlDataAdapter9.Fill(dataTable9);
								bool flag36 = dataTable9.Rows.Count != 0;
								if (flag36)
								{
									fonction fonction8 = new fonction();
									double num8 = 0.0;
									bool flag37 = fonction8.is_reel(Convert.ToString(dataTable9.Rows[0].ItemArray[0]));
									if (flag37)
									{
										num8 = Convert.ToDouble(dataTable9.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num8.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag38 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
							if (flag38)
							{
								string cmdText10 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article not in (select id_categorie from budget_categorie where id_budget = @i)";
								SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd.cnn);
								sqlCommand10.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand10.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(sqlCommand10);
								DataTable dataTable10 = new DataTable();
								sqlDataAdapter10.Fill(dataTable10);
								bool flag39 = dataTable10.Rows.Count != 0;
								if (flag39)
								{
									fonction fonction9 = new fonction();
									double num9 = 0.0;
									bool flag40 = fonction9.is_reel(Convert.ToString(dataTable10.Rows[0].ItemArray[0]));
									if (flag40)
									{
										num9 = Convert.ToDouble(dataTable10.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num9.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
						}
					}
					else
					{
						bool flag41 = dataTable.Rows[i].ItemArray[5].ToString() == "2";
						if (flag41)
						{
							bool flag42 = dataTable.Rows[i].ItemArray[4].ToString() == "1";
							if (flag42)
							{
								bool flag43 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag43)
								{
									string cmdText11 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand11 = new SqlCommand(cmdText11, bd.cnn);
									sqlCommand11.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand11.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand11.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(sqlCommand11);
									DataTable dataTable11 = new DataTable();
									sqlDataAdapter11.Fill(dataTable11);
									bool flag44 = dataTable11.Rows.Count != 0;
									if (flag44)
									{
										fonction fonction10 = new fonction();
										double num10 = 0.0;
										bool flag45 = fonction10.is_reel(Convert.ToString(dataTable11.Rows[0].ItemArray[0]));
										if (flag45)
										{
											num10 = Convert.ToDouble(dataTable11.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num10.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag46 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag46)
								{
									string cmdText12 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand12 = new SqlCommand(cmdText12, bd.cnn);
									sqlCommand12.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand12.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand12.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(sqlCommand12);
									DataTable dataTable12 = new DataTable();
									sqlDataAdapter12.Fill(dataTable12);
									bool flag47 = dataTable12.Rows.Count != 0;
									if (flag47)
									{
										fonction fonction11 = new fonction();
										double num11 = 0.0;
										bool flag48 = fonction11.is_reel(Convert.ToString(dataTable12.Rows[0].ItemArray[0]));
										if (flag48)
										{
											num11 = Convert.ToDouble(dataTable12.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num11.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag49 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag49)
								{
									string cmdText13 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand13 = new SqlCommand(cmdText13, bd.cnn);
									sqlCommand13.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand13.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand13.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(sqlCommand13);
									DataTable dataTable13 = new DataTable();
									sqlDataAdapter13.Fill(dataTable13);
									bool flag50 = dataTable13.Rows.Count != 0;
									if (flag50)
									{
										fonction fonction12 = new fonction();
										double num12 = 0.0;
										bool flag51 = fonction12.is_reel(Convert.ToString(dataTable13.Rows[0].ItemArray[0]));
										if (flag51)
										{
											num12 = Convert.ToDouble(dataTable13.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num12.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag52 = dataTable.Rows[i].ItemArray[4].ToString() == "2";
							if (flag52)
							{
								bool flag53 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag53)
								{
									string cmdText14 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand14 = new SqlCommand(cmdText14, bd.cnn);
									sqlCommand14.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand14.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand14.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(sqlCommand14);
									DataTable dataTable14 = new DataTable();
									sqlDataAdapter14.Fill(dataTable14);
									bool flag54 = dataTable14.Rows.Count != 0;
									if (flag54)
									{
										fonction fonction13 = new fonction();
										double num13 = 0.0;
										bool flag55 = fonction13.is_reel(Convert.ToString(dataTable14.Rows[0].ItemArray[0]));
										if (flag55)
										{
											num13 = Convert.ToDouble(dataTable14.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num13.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag56 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag56)
								{
									string cmdText15 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i))";
									SqlCommand sqlCommand15 = new SqlCommand(cmdText15, bd.cnn);
									sqlCommand15.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand15.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand15.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(sqlCommand15);
									DataTable dataTable15 = new DataTable();
									sqlDataAdapter15.Fill(dataTable15);
									bool flag57 = dataTable15.Rows.Count != 0;
									if (flag57)
									{
										fonction fonction14 = new fonction();
										double num14 = 0.0;
										bool flag58 = fonction14.is_reel(Convert.ToString(dataTable15.Rows[0].ItemArray[0]));
										if (flag58)
										{
											num14 = Convert.ToDouble(dataTable15.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num14.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag59 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag59)
								{
									string cmdText16 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand16 = new SqlCommand(cmdText16, bd.cnn);
									sqlCommand16.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand16.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand16.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(sqlCommand16);
									DataTable dataTable16 = new DataTable();
									sqlDataAdapter16.Fill(dataTable16);
									bool flag60 = dataTable16.Rows.Count != 0;
									if (flag60)
									{
										fonction fonction15 = new fonction();
										double num15 = 0.0;
										bool flag61 = fonction15.is_reel(Convert.ToString(dataTable16.Rows[0].ItemArray[0]));
										if (flag61)
										{
											num15 = Convert.ToDouble(dataTable16.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num15.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag62 = dataTable.Rows[i].ItemArray[4].ToString() == "3";
							if (flag62)
							{
								bool flag63 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag63)
								{
									string cmdText17 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand17 = new SqlCommand(cmdText17, bd.cnn);
									sqlCommand17.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand17.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand17.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(sqlCommand17);
									DataTable dataTable17 = new DataTable();
									sqlDataAdapter17.Fill(dataTable17);
									bool flag64 = dataTable17.Rows.Count != 0;
									if (flag64)
									{
										fonction fonction16 = new fonction();
										double num16 = 0.0;
										bool flag65 = fonction16.is_reel(Convert.ToString(dataTable17.Rows[0].ItemArray[0]));
										if (flag65)
										{
											num16 = Convert.ToDouble(dataTable17.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num16.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag66 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag66)
								{
									string cmdText18 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and  id_article in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand18 = new SqlCommand(cmdText18, bd.cnn);
									sqlCommand18.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand18.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand18.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(sqlCommand18);
									DataTable dataTable18 = new DataTable();
									sqlDataAdapter18.Fill(dataTable18);
									bool flag67 = dataTable18.Rows.Count != 0;
									if (flag67)
									{
										fonction fonction17 = new fonction();
										double num17 = 0.0;
										bool flag68 = fonction17.is_reel(Convert.ToString(dataTable18.Rows[0].ItemArray[0]));
										if (flag68)
										{
											num17 = Convert.ToDouble(dataTable18.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num17.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag69 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag69)
								{
									string cmdText19 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article not in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand19 = new SqlCommand(cmdText19, bd.cnn);
									sqlCommand19.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand19.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand19.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(sqlCommand19);
									DataTable dataTable19 = new DataTable();
									sqlDataAdapter19.Fill(dataTable19);
									bool flag70 = dataTable19.Rows.Count != 0;
									if (flag70)
									{
										fonction fonction18 = new fonction();
										double num18 = 0.0;
										bool flag71 = fonction18.is_reel(Convert.ToString(dataTable19.Rows[0].ItemArray[0]));
										if (flag71)
										{
											num18 = Convert.ToDouble(dataTable19.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num18.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
						}
						else
						{
							bool flag72 = dataTable.Rows[i].ItemArray[4].ToString() == "1";
							if (flag72)
							{
								bool flag73 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag73)
								{
									string cmdText20 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand20 = new SqlCommand(cmdText20, bd.cnn);
									sqlCommand20.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand20.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand20.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(sqlCommand20);
									DataTable dataTable20 = new DataTable();
									sqlDataAdapter20.Fill(dataTable20);
									bool flag74 = dataTable20.Rows.Count != 0;
									if (flag74)
									{
										fonction fonction19 = new fonction();
										double num19 = 0.0;
										bool flag75 = fonction19.is_reel(Convert.ToString(dataTable20.Rows[0].ItemArray[0]));
										if (flag75)
										{
											num19 = Convert.ToDouble(dataTable20.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num19.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag76 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag76)
								{
									string cmdText21 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand21 = new SqlCommand(cmdText21, bd.cnn);
									sqlCommand21.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand21.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand21.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(sqlCommand21);
									DataTable dataTable21 = new DataTable();
									sqlDataAdapter21.Fill(dataTable21);
									bool flag77 = dataTable21.Rows.Count != 0;
									if (flag77)
									{
										fonction fonction20 = new fonction();
										double num20 = 0.0;
										bool flag78 = fonction20.is_reel(Convert.ToString(dataTable21.Rows[0].ItemArray[0]));
										if (flag78)
										{
											num20 = Convert.ToDouble(dataTable21.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num20.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag79 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag79)
								{
									string cmdText22 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand22 = new SqlCommand(cmdText22, bd.cnn);
									sqlCommand22.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand22.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand22.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(sqlCommand22);
									DataTable dataTable22 = new DataTable();
									sqlDataAdapter22.Fill(dataTable22);
									bool flag80 = dataTable22.Rows.Count != 0;
									if (flag80)
									{
										fonction fonction21 = new fonction();
										double num21 = 0.0;
										bool flag81 = fonction21.is_reel(Convert.ToString(dataTable22.Rows[0].ItemArray[0]));
										if (flag81)
										{
											num21 = Convert.ToDouble(dataTable22.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num21.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag82 = dataTable.Rows[i].ItemArray[4].ToString() == "2";
							if (flag82)
							{
								bool flag83 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag83)
								{
									string cmdText23 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand23 = new SqlCommand(cmdText23, bd.cnn);
									sqlCommand23.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand23.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand23.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(sqlCommand23);
									DataTable dataTable23 = new DataTable();
									sqlDataAdapter23.Fill(dataTable23);
									bool flag84 = dataTable23.Rows.Count != 0;
									if (flag84)
									{
										fonction fonction22 = new fonction();
										double num22 = 0.0;
										bool flag85 = fonction22.is_reel(Convert.ToString(dataTable23.Rows[0].ItemArray[0]));
										if (flag85)
										{
											num22 = Convert.ToDouble(dataTable23.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num22.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag86 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag86)
								{
									string cmdText24 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i))";
									SqlCommand sqlCommand24 = new SqlCommand(cmdText24, bd.cnn);
									sqlCommand24.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand24.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand24.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(sqlCommand24);
									DataTable dataTable24 = new DataTable();
									sqlDataAdapter24.Fill(dataTable24);
									bool flag87 = dataTable24.Rows.Count != 0;
									if (flag87)
									{
										fonction fonction23 = new fonction();
										double num23 = 0.0;
										bool flag88 = fonction23.is_reel(Convert.ToString(dataTable24.Rows[0].ItemArray[0]));
										if (flag88)
										{
											num23 = Convert.ToDouble(dataTable24.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num23.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag89 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag89)
								{
									string cmdText25 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i))";
									SqlCommand sqlCommand25 = new SqlCommand(cmdText25, bd.cnn);
									sqlCommand25.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand25.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand25.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(sqlCommand25);
									DataTable dataTable25 = new DataTable();
									sqlDataAdapter25.Fill(dataTable25);
									bool flag90 = dataTable25.Rows.Count != 0;
									if (flag90)
									{
										fonction fonction24 = new fonction();
										double num24 = 0.0;
										bool flag91 = fonction24.is_reel(Convert.ToString(dataTable25.Rows[0].ItemArray[0]));
										if (flag91)
										{
											num24 = Convert.ToDouble(dataTable25.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num24.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag92 = dataTable.Rows[i].ItemArray[4].ToString() == "3";
							if (flag92)
							{
								bool flag93 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag93)
								{
									string cmdText26 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand26 = new SqlCommand(cmdText26, bd.cnn);
									sqlCommand26.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand26.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand26.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(sqlCommand26);
									DataTable dataTable26 = new DataTable();
									sqlDataAdapter26.Fill(dataTable26);
									bool flag94 = dataTable26.Rows.Count != 0;
									if (flag94)
									{
										fonction fonction25 = new fonction();
										double num25 = 0.0;
										bool flag95 = fonction25.is_reel(Convert.ToString(dataTable26.Rows[0].ItemArray[0]));
										if (flag95)
										{
											num25 = Convert.ToDouble(dataTable26.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num25.ToString("0.000"),
											Convert.ToString(dataTable.Rows[i].ItemArray[8])
										});
									}
								}
								bool flag96 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag96)
								{
									string cmdText27 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and  id_article in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand27 = new SqlCommand(cmdText27, bd.cnn);
									sqlCommand27.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand27.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand27.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(sqlCommand27);
									DataTable dataTable27 = new DataTable();
									sqlDataAdapter27.Fill(dataTable27);
									bool flag97 = dataTable27.Rows.Count != 0;
									if (flag97)
									{
										fonction fonction26 = new fonction();
										double num26 = 0.0;
										bool flag98 = fonction26.is_reel(Convert.ToString(dataTable27.Rows[0].ItemArray[0]));
										if (flag98)
										{
											num26 = Convert.ToDouble(dataTable27.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num26.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag99 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag99)
								{
									string cmdText28 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article not in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand28 = new SqlCommand(cmdText28, bd.cnn);
									sqlCommand28.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand28.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand28.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(sqlCommand28);
									DataTable dataTable28 = new DataTable();
									sqlDataAdapter28.Fill(dataTable28);
									bool flag100 = dataTable28.Rows.Count != 0;
									if (flag100)
									{
										fonction fonction27 = new fonction();
										double num27 = 0.0;
										bool flag101 = fonction27.is_reel(Convert.ToString(dataTable28.Rows[0].ItemArray[0]));
										if (flag101)
										{
											num27 = Convert.ToDouble(dataTable28.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num27.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
						}
					}
				}
			}
			bool flag102 = this.radGridView1.Rows.Count != 0;
			if (flag102)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
				liste_budget.id_budget = this.radGridView1.Rows[0].Cells[0].Value.ToString();
				for (int j = 0; j < this.radGridView1.Rows.Count; j++)
				{
					this.radGridView1.Rows[j].Cells[7].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				}
				liste_budget_general_tous liste_budget_general_tous = new liste_budget_general_tous();
				liste_budget_general_tous.TopLevel = false;
				this.panel4.Controls.Clear();
				this.panel4.Controls.Add(liste_budget_general_tous);
				liste_budget_general_tous.Show();
			}
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00107C24 File Offset: 0x00105E24
		private void select_change(object sender, CellFormattingEventArgs e)
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

		// Token: 0x0600064A RID: 1610 RVA: 0x00107CA8 File Offset: 0x00105EA8
		private void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (!flag)
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
				}
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00107D44 File Offset: 0x00105F44
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				liste_budget_modifier liste_budget_modifier = new liste_budget_modifier();
				liste_budget.id_budget = this.radGridView1.CurrentRow.Cells[0].Value.ToString();
				liste_budget_modifier.Show();
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00107DA0 File Offset: 0x00105FA0
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			liste_budget_categorie liste_budget_categorie = new liste_budget_categorie();
			liste_budget.id_budget = this.radGridView1.CurrentRow.Cells[0].Value.ToString();
			liste_budget_categorie.Show();
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00107DE0 File Offset: 0x00105FE0
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			liste_budget_fournisseur liste_budget_fournisseur = new liste_budget_fournisseur();
			liste_budget.id_budget = this.radGridView1.CurrentRow.Cells[0].Value.ToString();
			liste_budget_fournisseur.Show();
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00107E20 File Offset: 0x00106020
		private void button1_Click(object sender, EventArgs e)
		{
			liste_budget_general_tous liste_budget_general_tous = new liste_budget_general_tous();
			liste_budget_general_tous.TopLevel = false;
			this.panel4.Controls.Clear();
			this.panel4.Controls.Add(liste_budget_general_tous);
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.FromArgb(234, 234, 234);
			liste_budget_general_tous.Show();
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x00107E98 File Offset: 0x00106098
		private void button2_Click(object sender, EventArgs e)
		{
			liste_budget_variation liste_budget_variation = new liste_budget_variation();
			liste_budget_variation.TopLevel = false;
			this.panel4.Controls.Clear();
			this.panel4.Controls.Add(liste_budget_variation);
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.FromArgb(234, 234, 234);
			liste_budget_variation.Show();
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x00107F10 File Offset: 0x00106110
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.label20.Hide();
				this.label19.Hide();
				this.radDateTimePicker1.Hide();
				this.radDateTimePicker2.Hide();
				this.remplissage_tableau1();
			}
			else
			{
				this.label20.Show();
				this.label19.Show();
				this.radDateTimePicker1.Show();
				this.radDateTimePicker2.Show();
				this.remplissage_tableau2();
			}
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x00107FA4 File Offset: 0x001061A4
		private void remplissage_tableau2()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select id, nom, date_creation, montant, categorie, fournisseur_choix, categorie_choix, duree, description from budget where creer_nv = @a and date_creation between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DateTime dateTime = Convert.ToDateTime(dataTable.Rows[i].ItemArray[2]);
					bool flag2 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Jour";
					if (flag2)
					{
						dateTime = dateTime.AddDays(1.0);
					}
					bool flag3 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Semaine";
					if (flag3)
					{
						dateTime = dateTime.AddDays(7.0);
					}
					bool flag4 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque 2 Semaine";
					if (flag4)
					{
						dateTime = dateTime.AddDays(14.0);
					}
					bool flag5 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Mois";
					if (flag5)
					{
						dateTime = dateTime.AddMonths(1);
					}
					bool flag6 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque 2 Mois";
					if (flag6)
					{
						dateTime = dateTime.AddMonths(2);
					}
					bool flag7 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Trimestre";
					if (flag7)
					{
						dateTime = dateTime.AddMonths(3);
					}
					bool flag8 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Simestre";
					if (flag8)
					{
						dateTime = dateTime.AddMonths(6);
					}
					bool flag9 = dataTable.Rows[i].ItemArray[7].ToString() == "Chaque Année";
					if (flag9)
					{
						dateTime = dateTime.AddYears(1);
					}
					bool flag10 = dataTable.Rows[i].ItemArray[5].ToString() == "1";
					if (flag10)
					{
						bool flag11 = dataTable.Rows[i].ItemArray[4].ToString() == "1";
						if (flag11)
						{
							bool flag12 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
							if (flag12)
							{
								string cmdText2 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								bool flag13 = dataTable2.Rows.Count != 0;
								if (flag13)
								{
									fonction fonction = new fonction();
									double num = 0.0;
									bool flag14 = fonction.is_reel(Convert.ToString(dataTable2.Rows[0].ItemArray[0]));
									if (flag14)
									{
										num = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag15 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
							if (flag15)
							{
								string cmdText3 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i)))";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								bool flag16 = dataTable3.Rows.Count != 0;
								if (flag16)
								{
									fonction fonction2 = new fonction();
									double num2 = 0.0;
									bool flag17 = fonction2.is_reel(Convert.ToString(dataTable3.Rows[0].ItemArray[0]));
									if (flag17)
									{
										num2 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num2.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag18 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
							if (flag18)
							{
								string cmdText4 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand4.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag19 = dataTable4.Rows.Count != 0;
								if (flag19)
								{
									fonction fonction3 = new fonction();
									double num3 = 0.0;
									bool flag20 = fonction3.is_reel(Convert.ToString(dataTable4.Rows[0].ItemArray[0]));
									if (flag20)
									{
										num3 = Convert.ToDouble(dataTable4.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num3.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
						}
						bool flag21 = dataTable.Rows[i].ItemArray[4].ToString() == "2";
						if (flag21)
						{
							bool flag22 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
							if (flag22)
							{
								string cmdText5 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
								sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand5.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								bool flag23 = dataTable5.Rows.Count != 0;
								if (flag23)
								{
									fonction fonction4 = new fonction();
									double num4 = 0.0;
									bool flag24 = fonction4.is_reel(Convert.ToString(dataTable5.Rows[0].ItemArray[0]));
									if (flag24)
									{
										num4 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num4.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag25 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
							if (flag25)
							{
								string cmdText6 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i))";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
								sqlCommand6.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand6.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								bool flag26 = dataTable6.Rows.Count != 0;
								if (flag26)
								{
									fonction fonction5 = new fonction();
									double num5 = 0.0;
									bool flag27 = fonction5.is_reel(Convert.ToString(dataTable6.Rows[0].ItemArray[0]));
									if (flag27)
									{
										num5 = Convert.ToDouble(dataTable6.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num5.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag28 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
							if (flag28)
							{
								string cmdText7 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i))";
								SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
								sqlCommand7.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand7.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
								DataTable dataTable7 = new DataTable();
								sqlDataAdapter7.Fill(dataTable7);
								bool flag29 = dataTable7.Rows.Count != 0;
								if (flag29)
								{
									fonction fonction6 = new fonction();
									double num6 = 0.0;
									bool flag30 = fonction6.is_reel(Convert.ToString(dataTable7.Rows[0].ItemArray[0]));
									if (flag30)
									{
										num6 = Convert.ToDouble(dataTable7.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num6.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
						}
						bool flag31 = dataTable.Rows[i].ItemArray[4].ToString() == "3";
						if (flag31)
						{
							bool flag32 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
							if (flag32)
							{
								string cmdText8 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2";
								SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
								sqlCommand8.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand8.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
								DataTable dataTable8 = new DataTable();
								sqlDataAdapter8.Fill(dataTable8);
								bool flag33 = dataTable8.Rows.Count != 0;
								if (flag33)
								{
									fonction fonction7 = new fonction();
									double num7 = 0.0;
									bool flag34 = fonction7.is_reel(Convert.ToString(dataTable8.Rows[0].ItemArray[0]));
									if (flag34)
									{
										num7 = Convert.ToDouble(dataTable8.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num7.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag35 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
							if (flag35)
							{
								string cmdText9 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article in (select id_categorie from budget_categorie where id_budget = @i)";
								SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
								sqlCommand9.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand9.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(sqlCommand9);
								DataTable dataTable9 = new DataTable();
								sqlDataAdapter9.Fill(dataTable9);
								bool flag36 = dataTable9.Rows.Count != 0;
								if (flag36)
								{
									fonction fonction8 = new fonction();
									double num8 = 0.0;
									bool flag37 = fonction8.is_reel(Convert.ToString(dataTable9.Rows[0].ItemArray[0]));
									if (flag37)
									{
										num8 = Convert.ToDouble(dataTable9.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num8.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
							bool flag38 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
							if (flag38)
							{
								string cmdText10 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and id_article not in (select id_categorie from budget_categorie where id_budget = @i)";
								SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd.cnn);
								sqlCommand10.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
								sqlCommand10.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
								sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(sqlCommand10);
								DataTable dataTable10 = new DataTable();
								sqlDataAdapter10.Fill(dataTable10);
								bool flag39 = dataTable10.Rows.Count != 0;
								if (flag39)
								{
									fonction fonction9 = new fonction();
									double num9 = 0.0;
									bool flag40 = fonction9.is_reel(Convert.ToString(dataTable10.Rows[0].ItemArray[0]));
									if (flag40)
									{
										num9 = Convert.ToDouble(dataTable10.Rows[0].ItemArray[0]);
									}
									this.radGridView1.Rows.Add(new object[]
									{
										dataTable.Rows[i].ItemArray[0],
										dataTable.Rows[i].ItemArray[1],
										fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
										dataTable.Rows[i].ItemArray[7],
										Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
										num9.ToString("0.000"),
										dataTable.Rows[i].ItemArray[8]
									});
								}
							}
						}
					}
					else
					{
						bool flag41 = dataTable.Rows[i].ItemArray[5].ToString() == "2";
						if (flag41)
						{
							bool flag42 = dataTable.Rows[i].ItemArray[4].ToString() == "1";
							if (flag42)
							{
								bool flag43 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag43)
								{
									string cmdText11 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand11 = new SqlCommand(cmdText11, bd.cnn);
									sqlCommand11.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand11.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand11.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(sqlCommand11);
									DataTable dataTable11 = new DataTable();
									sqlDataAdapter11.Fill(dataTable11);
									bool flag44 = dataTable11.Rows.Count != 0;
									if (flag44)
									{
										fonction fonction10 = new fonction();
										double num10 = 0.0;
										bool flag45 = fonction10.is_reel(Convert.ToString(dataTable11.Rows[0].ItemArray[0]));
										if (flag45)
										{
											num10 = Convert.ToDouble(dataTable11.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num10.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag46 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag46)
								{
									string cmdText12 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand12 = new SqlCommand(cmdText12, bd.cnn);
									sqlCommand12.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand12.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand12.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(sqlCommand12);
									DataTable dataTable12 = new DataTable();
									sqlDataAdapter12.Fill(dataTable12);
									bool flag47 = dataTable12.Rows.Count != 0;
									if (flag47)
									{
										fonction fonction11 = new fonction();
										double num11 = 0.0;
										bool flag48 = fonction11.is_reel(Convert.ToString(dataTable12.Rows[0].ItemArray[0]));
										if (flag48)
										{
											num11 = Convert.ToDouble(dataTable12.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num11.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag49 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag49)
								{
									string cmdText13 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand13 = new SqlCommand(cmdText13, bd.cnn);
									sqlCommand13.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand13.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand13.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(sqlCommand13);
									DataTable dataTable13 = new DataTable();
									sqlDataAdapter13.Fill(dataTable13);
									bool flag50 = dataTable13.Rows.Count != 0;
									if (flag50)
									{
										fonction fonction12 = new fonction();
										double num12 = 0.0;
										bool flag51 = fonction12.is_reel(Convert.ToString(dataTable13.Rows[0].ItemArray[0]));
										if (flag51)
										{
											num12 = Convert.ToDouble(dataTable13.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num12.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag52 = dataTable.Rows[i].ItemArray[4].ToString() == "2";
							if (flag52)
							{
								bool flag53 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag53)
								{
									string cmdText14 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand14 = new SqlCommand(cmdText14, bd.cnn);
									sqlCommand14.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand14.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand14.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(sqlCommand14);
									DataTable dataTable14 = new DataTable();
									sqlDataAdapter14.Fill(dataTable14);
									bool flag54 = dataTable14.Rows.Count != 0;
									if (flag54)
									{
										fonction fonction13 = new fonction();
										double num13 = 0.0;
										bool flag55 = fonction13.is_reel(Convert.ToString(dataTable14.Rows[0].ItemArray[0]));
										if (flag55)
										{
											num13 = Convert.ToDouble(dataTable14.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num13.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag56 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag56)
								{
									string cmdText15 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i))";
									SqlCommand sqlCommand15 = new SqlCommand(cmdText15, bd.cnn);
									sqlCommand15.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand15.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand15.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(sqlCommand15);
									DataTable dataTable15 = new DataTable();
									sqlDataAdapter15.Fill(dataTable15);
									bool flag57 = dataTable15.Rows.Count != 0;
									if (flag57)
									{
										fonction fonction14 = new fonction();
										double num14 = 0.0;
										bool flag58 = fonction14.is_reel(Convert.ToString(dataTable15.Rows[0].ItemArray[0]));
										if (flag58)
										{
											num14 = Convert.ToDouble(dataTable15.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num14.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag59 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag59)
								{
									string cmdText16 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand16 = new SqlCommand(cmdText16, bd.cnn);
									sqlCommand16.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand16.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand16.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(sqlCommand16);
									DataTable dataTable16 = new DataTable();
									sqlDataAdapter16.Fill(dataTable16);
									bool flag60 = dataTable16.Rows.Count != 0;
									if (flag60)
									{
										fonction fonction15 = new fonction();
										double num15 = 0.0;
										bool flag61 = fonction15.is_reel(Convert.ToString(dataTable16.Rows[0].ItemArray[0]));
										if (flag61)
										{
											num15 = Convert.ToDouble(dataTable16.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num15.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag62 = dataTable.Rows[i].ItemArray[4].ToString() == "3";
							if (flag62)
							{
								bool flag63 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag63)
								{
									string cmdText17 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand17 = new SqlCommand(cmdText17, bd.cnn);
									sqlCommand17.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand17.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand17.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(sqlCommand17);
									DataTable dataTable17 = new DataTable();
									sqlDataAdapter17.Fill(dataTable17);
									bool flag64 = dataTable17.Rows.Count != 0;
									if (flag64)
									{
										fonction fonction16 = new fonction();
										double num16 = 0.0;
										bool flag65 = fonction16.is_reel(Convert.ToString(dataTable17.Rows[0].ItemArray[0]));
										if (flag65)
										{
											num16 = Convert.ToDouble(dataTable17.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num16.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag66 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag66)
								{
									string cmdText18 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and  id_article in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand18 = new SqlCommand(cmdText18, bd.cnn);
									sqlCommand18.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand18.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand18.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(sqlCommand18);
									DataTable dataTable18 = new DataTable();
									sqlDataAdapter18.Fill(dataTable18);
									bool flag67 = dataTable18.Rows.Count != 0;
									if (flag67)
									{
										fonction fonction17 = new fonction();
										double num17 = 0.0;
										bool flag68 = fonction17.is_reel(Convert.ToString(dataTable18.Rows[0].ItemArray[0]));
										if (flag68)
										{
											num17 = Convert.ToDouble(dataTable18.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num17.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag69 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag69)
								{
									string cmdText19 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article not in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand19 = new SqlCommand(cmdText19, bd.cnn);
									sqlCommand19.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand19.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand19.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(sqlCommand19);
									DataTable dataTable19 = new DataTable();
									sqlDataAdapter19.Fill(dataTable19);
									bool flag70 = dataTable19.Rows.Count != 0;
									if (flag70)
									{
										fonction fonction18 = new fonction();
										double num18 = 0.0;
										bool flag71 = fonction18.is_reel(Convert.ToString(dataTable19.Rows[0].ItemArray[0]));
										if (flag71)
										{
											num18 = Convert.ToDouble(dataTable19.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num18.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
						}
						else
						{
							bool flag72 = dataTable.Rows[i].ItemArray[4].ToString() == "1";
							if (flag72)
							{
								bool flag73 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag73)
								{
									string cmdText20 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand20 = new SqlCommand(cmdText20, bd.cnn);
									sqlCommand20.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand20.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand20.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(sqlCommand20);
									DataTable dataTable20 = new DataTable();
									sqlDataAdapter20.Fill(dataTable20);
									bool flag74 = dataTable20.Rows.Count != 0;
									if (flag74)
									{
										fonction fonction19 = new fonction();
										double num19 = 0.0;
										bool flag75 = fonction19.is_reel(Convert.ToString(dataTable20.Rows[0].ItemArray[0]));
										if (flag75)
										{
											num19 = Convert.ToDouble(dataTable20.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num19.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag76 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag76)
								{
									string cmdText21 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand21 = new SqlCommand(cmdText21, bd.cnn);
									sqlCommand21.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand21.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand21.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(sqlCommand21);
									DataTable dataTable21 = new DataTable();
									sqlDataAdapter21.Fill(dataTable21);
									bool flag77 = dataTable21.Rows.Count != 0;
									if (flag77)
									{
										fonction fonction20 = new fonction();
										double num20 = 0.0;
										bool flag78 = fonction20.is_reel(Convert.ToString(dataTable21.Rows[0].ItemArray[0]));
										if (flag78)
										{
											num20 = Convert.ToDouble(dataTable21.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num20.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag79 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag79)
								{
									string cmdText22 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille not in (select id_categorie from budget_categorie where id_budget = @i)))";
									SqlCommand sqlCommand22 = new SqlCommand(cmdText22, bd.cnn);
									sqlCommand22.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand22.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand22.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(sqlCommand22);
									DataTable dataTable22 = new DataTable();
									sqlDataAdapter22.Fill(dataTable22);
									bool flag80 = dataTable22.Rows.Count != 0;
									if (flag80)
									{
										fonction fonction21 = new fonction();
										double num21 = 0.0;
										bool flag81 = fonction21.is_reel(Convert.ToString(dataTable22.Rows[0].ItemArray[0]));
										if (flag81)
										{
											num21 = Convert.ToDouble(dataTable22.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num21.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag82 = dataTable.Rows[i].ItemArray[4].ToString() == "2";
							if (flag82)
							{
								bool flag83 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag83)
								{
									string cmdText23 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand23 = new SqlCommand(cmdText23, bd.cnn);
									sqlCommand23.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand23.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand23.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(sqlCommand23);
									DataTable dataTable23 = new DataTable();
									sqlDataAdapter23.Fill(dataTable23);
									bool flag84 = dataTable23.Rows.Count != 0;
									if (flag84)
									{
										fonction fonction22 = new fonction();
										double num22 = 0.0;
										bool flag85 = fonction22.is_reel(Convert.ToString(dataTable23.Rows[0].ItemArray[0]));
										if (flag85)
										{
											num22 = Convert.ToDouble(dataTable23.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num22.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag86 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag86)
								{
									string cmdText24 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id_categorie from budget_categorie where id_budget = @i))";
									SqlCommand sqlCommand24 = new SqlCommand(cmdText24, bd.cnn);
									sqlCommand24.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand24.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand24.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(sqlCommand24);
									DataTable dataTable24 = new DataTable();
									sqlDataAdapter24.Fill(dataTable24);
									bool flag87 = dataTable24.Rows.Count != 0;
									if (flag87)
									{
										fonction fonction23 = new fonction();
										double num23 = 0.0;
										bool flag88 = fonction23.is_reel(Convert.ToString(dataTable24.Rows[0].ItemArray[0]));
										if (flag88)
										{
											num23 = Convert.ToDouble(dataTable24.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num23.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag89 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag89)
								{
									string cmdText25 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and  bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i))) and id_article in (select id_article from tableau_article_sous_famille where id_sous_famille not in (select id_categorie from budget_categorie where id_budget = @i))";
									SqlCommand sqlCommand25 = new SqlCommand(cmdText25, bd.cnn);
									sqlCommand25.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand25.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand25.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(sqlCommand25);
									DataTable dataTable25 = new DataTable();
									sqlDataAdapter25.Fill(dataTable25);
									bool flag90 = dataTable25.Rows.Count != 0;
									if (flag90)
									{
										fonction fonction24 = new fonction();
										double num24 = 0.0;
										bool flag91 = fonction24.is_reel(Convert.ToString(dataTable25.Rows[0].ItemArray[0]));
										if (flag91)
										{
											num24 = Convert.ToDouble(dataTable25.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num24.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
							bool flag92 = dataTable.Rows[i].ItemArray[4].ToString() == "3";
							if (flag92)
							{
								bool flag93 = dataTable.Rows[i].ItemArray[6].ToString() == "1";
								if (flag93)
								{
									string cmdText26 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))";
									SqlCommand sqlCommand26 = new SqlCommand(cmdText26, bd.cnn);
									sqlCommand26.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand26.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand26.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(sqlCommand26);
									DataTable dataTable26 = new DataTable();
									sqlDataAdapter26.Fill(dataTable26);
									bool flag94 = dataTable26.Rows.Count != 0;
									if (flag94)
									{
										fonction fonction25 = new fonction();
										double num25 = 0.0;
										bool flag95 = fonction25.is_reel(Convert.ToString(dataTable26.Rows[0].ItemArray[0]));
										if (flag95)
										{
											num25 = Convert.ToDouble(dataTable26.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num25.ToString("0.000"),
											Convert.ToString(dataTable.Rows[i].ItemArray[8])
										});
									}
								}
								bool flag96 = dataTable.Rows[i].ItemArray[6].ToString() == "2";
								if (flag96)
								{
									string cmdText27 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and  id_article in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand27 = new SqlCommand(cmdText27, bd.cnn);
									sqlCommand27.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand27.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand27.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(sqlCommand27);
									DataTable dataTable27 = new DataTable();
									sqlDataAdapter27.Fill(dataTable27);
									bool flag97 = dataTable27.Rows.Count != 0;
									if (flag97)
									{
										fonction fonction26 = new fonction();
										double num26 = 0.0;
										bool flag98 = fonction26.is_reel(Convert.ToString(dataTable27.Rows[0].ItemArray[0]));
										if (flag98)
										{
											num26 = Convert.ToDouble(dataTable27.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num26.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
								bool flag99 = dataTable.Rows[i].ItemArray[6].ToString() == "3";
								if (flag99)
								{
									string cmdText28 = "select sum(qt*prix_ht - (qt*prix_ht*remise/100)) from livraison_article inner join bon_livraison on livraison_article.id_livraison = bon_livraison.id where bon_livraison.date_livraison between @d1 and @d2 and bon_livraison.id_reception in (select reception_commande.id_reception from reception_commande where id_commande in (select commande.id from commande where commande.id_fournisseur not in (select budget_fournisseur.id_fournisseur from budget_fournisseur where id_budget =@i)))  and id_article not in (select id_categorie from budget_categorie where id_budget = @i)";
									SqlCommand sqlCommand28 = new SqlCommand(cmdText28, bd.cnn);
									sqlCommand28.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[i].ItemArray[2];
									sqlCommand28.Parameters.Add("@d2", SqlDbType.Date).Value = dateTime;
									sqlCommand28.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(sqlCommand28);
									DataTable dataTable28 = new DataTable();
									sqlDataAdapter28.Fill(dataTable28);
									bool flag100 = dataTable28.Rows.Count != 0;
									if (flag100)
									{
										fonction fonction27 = new fonction();
										double num27 = 0.0;
										bool flag101 = fonction27.is_reel(Convert.ToString(dataTable28.Rows[0].ItemArray[0]));
										if (flag101)
										{
											num27 = Convert.ToDouble(dataTable28.Rows[0].ItemArray[0]);
										}
										this.radGridView1.Rows.Add(new object[]
										{
											dataTable.Rows[i].ItemArray[0],
											dataTable.Rows[i].ItemArray[1],
											fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
											dataTable.Rows[i].ItemArray[7],
											Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
											num27.ToString("0.000"),
											dataTable.Rows[i].ItemArray[8]
										});
									}
								}
							}
						}
					}
				}
			}
			bool flag102 = this.radGridView1.Rows.Count != 0;
			if (flag102)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
				liste_budget.id_budget = this.radGridView1.Rows[0].Cells[0].Value.ToString();
				for (int j = 0; j < this.radGridView1.Rows.Count; j++)
				{
					this.radGridView1.Rows[j].Cells[7].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				}
				liste_budget_general_tous liste_budget_general_tous = new liste_budget_general_tous();
				liste_budget_general_tous.TopLevel = false;
				this.panel4.Controls.Clear();
				this.panel4.Controls.Add(liste_budget_general_tous);
				liste_budget_general_tous.Show();
			}
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0010BF68 File Offset: 0x0010A168
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.remplissage_tableau2();
			}
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0010BF90 File Offset: 0x0010A190
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				this.remplissage_tableau2();
			}
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0010BFB8 File Offset: 0x0010A1B8
		private void radButton8_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0010C008 File Offset: 0x0010A208
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x0400084A RID: 2122
		public static string id_budget;
	}
}
