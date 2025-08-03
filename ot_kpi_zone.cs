using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI.Gauges;

namespace GMAO
{
	// Token: 0x020000C4 RID: 196
	public partial class ot_kpi_zone : Form
	{
		// Token: 0x060008BD RID: 2237 RVA: 0x00173276 File Offset: 0x00171476
		public ot_kpi_zone()
		{
			this.InitializeComponent();
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00173290 File Offset: 0x00171490
		private void ot_kpi_zone_Load(object sender, EventArgs e)
		{
			this.panel1.Controls.Clear();
			bool flag = ordre_travail.id_atelier != 0;
			if (flag)
			{
				bd bd = new bd();
				List<int> list = new List<int>();
				string cmdText = "select id, designation from equipement where deleted = @d and id_parent = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ordre_travail.id_atelier;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string text = string.Join<int>(",", ordre_travail.id_ort.ToArray());
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					int num = 0;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						List<int> list2 = new List<int>();
						this.telecharger_tous_id_enfant(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]), list2);
						string text2 = string.Join<int>(",", list2.ToArray());
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
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							double ttr = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
							double num2 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[1]);
							int nbr_ot = Convert.ToInt32(dataTable2.Rows[0].ItemArray[2]);
							double tbf = Convert.ToDouble(dataTable2.Rows[0].ItemArray[3]);
							double num3 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[4]);
							double da = num3 / (num3 + num2) * 100.0;
							bool flag4 = num3 == 0.0;
							if (flag4)
							{
								da = 100.0;
							}
							double taux_def = 1.0 / num3;
							double taux_maint = 1.0 / num2;
							string esm = dataTable.Rows[i].ItemArray[1].ToString();
							this.creer_panel_zone(num, ttr, num2, tbf, num3, da, taux_def, taux_maint, nbr_ot, esm);
							num++;
						}
					}
				}
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x001735D4 File Offset: 0x001717D4
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

		// Token: 0x060008C0 RID: 2240 RVA: 0x001736B0 File Offset: 0x001718B0
		private void creer_panel_zone(int k, double ttr, double mttr, double tbf, double mtfb, double da, double taux_def, double taux_maint, int nbr_ot, string esm)
		{
			Panel panel = new Panel();
			panel.Location = new Point(328 * k + 23);
			panel.Size = new Size(328, 440);
			RadRadialGauge radRadialGauge = new RadRadialGauge();
			radRadialGauge.BackColor = Color.White;
			radRadialGauge.CausesValidation = false;
			radRadialGauge.Location = new Point(5, 4);
			radRadialGauge.Size = new Size(280, 202);
			radRadialGauge.StartAngle = 180.0;
			radRadialGauge.SweepAngle = 180.0;
			RadialGaugeArc radialGaugeArc = new RadialGaugeArc();
			RadialGaugeArc radialGaugeArc2 = new RadialGaugeArc();
			RadialGaugeSingleLabel radialGaugeSingleLabel = new RadialGaugeSingleLabel();
			radRadialGauge.Items.AddRange(new RadItem[]
			{
				radialGaugeArc,
				radialGaugeArc2,
				radialGaugeSingleLabel
			});
			this.propert_arc1(k, radialGaugeArc);
			this.propertie_arc2(radialGaugeArc2);
			this.propertie_label_single(k, radialGaugeSingleLabel);
			BunifuCards bunifuCards = new BunifuCards();
			this.propert_card(k, bunifuCards);
			Label label = new Label();
			Label label2 = new Label();
			Label label3 = new Label();
			Label label4 = new Label();
			Label label5 = new Label();
			Label label6 = new Label();
			Label label7 = new Label();
			Label label8 = new Label();
			Label label9 = new Label();
			Label label10 = new Label();
			Label label11 = new Label();
			Label label12 = new Label();
			Label label13 = new Label();
			Label label14 = new Label();
			Label label15 = new Label();
			this.propertie_label(label, 6, 35, "TTR :");
			this.propertie_label(label2, 6, 53, "MTTR :");
			this.propertie_label(label3, 6, 71, "TBF :");
			this.propertie_label(label4, 6, 89, "MTBF :");
			this.propertie_label(label5, 6, 107, "Da :");
			this.propertie_label(label6, 6, 125, "λ :");
			this.propertie_label(label7, 6, 143, "µ :");
			this.propertie_label(label15, 6, 10, esm);
			this.couleur_label(k, label);
			this.couleur_label(k, label2);
			this.couleur_label(k, label3);
			this.couleur_label(k, label4);
			this.couleur_label(k, label5);
			this.couleur_label(k, label6);
			this.couleur_label(k, label7);
			this.couleur_label(k, label15);
			this.propertie_label(label8, 48, 35, Math.Round(ttr, 2).ToString() + " H");
			this.propertie_label(label9, 48, 53, Math.Round(mttr, 2).ToString() + " H");
			this.propertie_label(label10, 48, 71, Math.Round(tbf, 2).ToString() + " H");
			this.propertie_label(label11, 48, 89, Math.Round(mtfb, 2).ToString() + " H");
			this.propertie_label(label12, 48, 107, Math.Round(da, 4).ToString() + " %");
			this.propertie_label(label13, 48, 125, Math.Round(taux_def, 4).ToString() + " H^-1");
			this.propertie_label(label14, 48, 143, Math.Round(taux_maint, 4).ToString() + " H^-1");
			bool flag = tbf == 0.0;
			if (flag)
			{
				label10.Text = "-";
				label11.Text = "-";
				label13.Text = "-";
			}
			bunifuCards.Controls.Add(label15);
			bunifuCards.Controls.Add(label);
			bunifuCards.Controls.Add(label2);
			bunifuCards.Controls.Add(label3);
			bunifuCards.Controls.Add(label4);
			bunifuCards.Controls.Add(label5);
			bunifuCards.Controls.Add(label6);
			bunifuCards.Controls.Add(label7);
			bunifuCards.Controls.Add(label8);
			bunifuCards.Controls.Add(label9);
			bunifuCards.Controls.Add(label10);
			bunifuCards.Controls.Add(label11);
			bunifuCards.Controls.Add(label12);
			bunifuCards.Controls.Add(label13);
			bunifuCards.Controls.Add(label14);
			Label label16 = new Label();
			label16.AutoSize = true;
			label16.Font = new Font("Calibri", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			label16.Location = new Point(6, 194);
			label16.Size = new Size(69, 23);
			label16.Text = nbr_ot.ToString() + " OT";
			this.couleur_label(k, label16);
			bunifuCards.Controls.Add(label16);
			double num = da * 100.0;
			radRadialGauge.Value = (float)Math.Round(da, 3);
			panel.Controls.Add(radRadialGauge);
			panel.Controls.Add(bunifuCards);
			this.panel1.Controls.Add(panel);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00173BF0 File Offset: 0x00171DF0
		private void propert_arc1(int k, RadialGaugeArc arc)
		{
			arc.BindEndRange = true;
			arc.DisabledTextRenderingHint = TextRenderingHint.SystemDefault;
			arc.RangeEnd = 60.0;
			arc.TextRenderingHint = TextRenderingHint.SystemDefault;
			arc.UseCompatibleTextRendering = false;
			arc.Width = 40.0;
			bool flag = k == 0;
			if (flag)
			{
				arc.BackColor = Color.Crimson;
				arc.BackColor2 = Color.Crimson;
			}
			bool flag2 = k == 1;
			if (flag2)
			{
				arc.BackColor = Color.Olive;
				arc.BackColor2 = Color.Olive;
			}
			bool flag3 = k == 2;
			if (flag3)
			{
				arc.BackColor = Color.DodgerBlue;
				arc.BackColor2 = Color.DodgerBlue;
			}
			bool flag4 = k == 3;
			if (flag4)
			{
				arc.BackColor = Color.LimeGreen;
				arc.BackColor2 = Color.LimeGreen;
			}
			bool flag5 = k == 4;
			if (flag5)
			{
				arc.BackColor = Color.Tomato;
				arc.BackColor2 = Color.Tomato;
			}
			bool flag6 = k == 5;
			if (flag6)
			{
				arc.BackColor = Color.DarkOrchid;
				arc.BackColor2 = Color.DarkOrchid;
			}
			bool flag7 = k == 6;
			if (flag7)
			{
				arc.BackColor = Color.Magenta;
				arc.BackColor2 = Color.Magenta;
			}
			bool flag8 = k == 7;
			if (flag8)
			{
				arc.BackColor = Color.DarkOrange;
				arc.BackColor2 = Color.DarkOrange;
			}
			bool flag9 = k == 8;
			if (flag9)
			{
				arc.BackColor = Color.Green;
				arc.BackColor2 = Color.Green;
			}
			bool flag10 = k == 9;
			if (flag10)
			{
				arc.BackColor = Color.Blue;
				arc.BackColor2 = Color.Blue;
			}
			bool flag11 = k == 10;
			if (flag11)
			{
				arc.BackColor = Color.Red;
				arc.BackColor2 = Color.Red;
			}
			bool flag12 = k == 11;
			if (flag12)
			{
				arc.BackColor = Color.Teal;
				arc.BackColor2 = Color.Teal;
			}
			bool flag13 = k == 12;
			if (flag13)
			{
				arc.BackColor = Color.Orchid;
				arc.BackColor2 = Color.Orchid;
			}
			bool flag14 = k == 12;
			if (flag14)
			{
				arc.BackColor = Color.Chocolate;
				arc.BackColor2 = Color.Chocolate;
			}
			bool flag15 = k > 12;
			if (flag15)
			{
				bool flag16 = k % 3 == 0;
				if (flag16)
				{
					arc.BackColor = Color.Crimson;
					arc.BackColor2 = Color.Crimson;
				}
				bool flag17 = k % 3 == 1;
				if (flag17)
				{
					arc.BackColor = Color.Olive;
					arc.BackColor2 = Color.Olive;
				}
				bool flag18 = k % 3 == 2;
				if (flag18)
				{
					arc.BackColor = Color.DodgerBlue;
					arc.BackColor2 = Color.DodgerBlue;
				}
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00173EB4 File Offset: 0x001720B4
		private void couleur_label(int k, Label l)
		{
			bool flag = k == 0;
			if (flag)
			{
				l.ForeColor = Color.Crimson;
			}
			bool flag2 = k == 1;
			if (flag2)
			{
				l.ForeColor = Color.Olive;
			}
			bool flag3 = k == 2;
			if (flag3)
			{
				l.ForeColor = Color.DodgerBlue;
			}
			bool flag4 = k == 3;
			if (flag4)
			{
				l.ForeColor = Color.LimeGreen;
			}
			bool flag5 = k == 4;
			if (flag5)
			{
				l.ForeColor = Color.Tomato;
			}
			bool flag6 = k == 5;
			if (flag6)
			{
				l.ForeColor = Color.DarkOrchid;
			}
			bool flag7 = k == 6;
			if (flag7)
			{
				l.ForeColor = Color.Magenta;
			}
			bool flag8 = k == 7;
			if (flag8)
			{
				l.ForeColor = Color.DarkOrange;
			}
			bool flag9 = k == 8;
			if (flag9)
			{
				l.ForeColor = Color.Green;
			}
			bool flag10 = k == 9;
			if (flag10)
			{
				l.ForeColor = Color.Blue;
			}
			bool flag11 = k == 10;
			if (flag11)
			{
				l.ForeColor = Color.Red;
			}
			bool flag12 = k == 11;
			if (flag12)
			{
				l.ForeColor = Color.Teal;
			}
			bool flag13 = k == 12;
			if (flag13)
			{
				l.ForeColor = Color.Orchid;
			}
			bool flag14 = k == 12;
			if (flag14)
			{
				l.ForeColor = Color.Chocolate;
			}
			bool flag15 = k > 12;
			if (flag15)
			{
				bool flag16 = k % 3 == 0;
				if (flag16)
				{
					l.ForeColor = Color.Crimson;
				}
				bool flag17 = k % 3 == 1;
				if (flag17)
				{
					l.ForeColor = Color.Olive;
				}
				bool flag18 = k % 3 == 2;
				if (flag18)
				{
					l.ForeColor = Color.DodgerBlue;
				}
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0017406C File Offset: 0x0017226C
		private void propertie_arc2(RadialGaugeArc arc)
		{
			arc.BackColor = Color.FromArgb(193, 193, 193);
			arc.BackColor2 = Color.FromArgb(194, 194, 194);
			arc.BindStartRange = true;
			arc.DisabledTextRenderingHint = TextRenderingHint.SystemDefault;
			arc.RangeEnd = 100.0;
			arc.RangeStart = 60.0;
			arc.TextRenderingHint = TextRenderingHint.SystemDefault;
			arc.UseCompatibleTextRendering = false;
			arc.Width = 40.0;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00174100 File Offset: 0x00172300
		private void propertie_label_single(int k, RadialGaugeSingleLabel l)
		{
			l.BindValue = true;
			l.DisabledTextRenderingHint = TextRenderingHint.SystemDefault;
			l.LabelFontSize = 10f;
			l.LabelText = "Text";
			l.LocationPercentage = new SizeF(0f, -0.1f);
			l.TextRenderingHint = TextRenderingHint.SystemDefault;
			l.UseCompatibleTextRendering = false;
			bool flag = k == 0;
			if (flag)
			{
				l.ForeColor = Color.Crimson;
			}
			bool flag2 = k == 1;
			if (flag2)
			{
				l.ForeColor = Color.Olive;
			}
			bool flag3 = k == 2;
			if (flag3)
			{
				l.ForeColor = Color.DodgerBlue;
			}
			bool flag4 = k == 3;
			if (flag4)
			{
				l.ForeColor = Color.LimeGreen;
			}
			bool flag5 = k == 4;
			if (flag5)
			{
				l.ForeColor = Color.Tomato;
			}
			bool flag6 = k == 5;
			if (flag6)
			{
				l.ForeColor = Color.DarkOrchid;
			}
			bool flag7 = k == 6;
			if (flag7)
			{
				l.ForeColor = Color.Magenta;
			}
			bool flag8 = k == 7;
			if (flag8)
			{
				l.ForeColor = Color.DarkOrange;
			}
			bool flag9 = k == 8;
			if (flag9)
			{
				l.ForeColor = Color.Green;
			}
			bool flag10 = k == 9;
			if (flag10)
			{
				l.ForeColor = Color.Blue;
			}
			bool flag11 = k == 10;
			if (flag11)
			{
				l.ForeColor = Color.Red;
			}
			bool flag12 = k == 11;
			if (flag12)
			{
				l.ForeColor = Color.Teal;
			}
			bool flag13 = k == 12;
			if (flag13)
			{
				l.ForeColor = Color.Orchid;
			}
			bool flag14 = k == 12;
			if (flag14)
			{
				l.ForeColor = Color.Chocolate;
			}
			bool flag15 = k > 12;
			if (flag15)
			{
				bool flag16 = k % 3 == 0;
				if (flag16)
				{
					l.ForeColor = Color.Crimson;
				}
				bool flag17 = k % 3 == 1;
				if (flag17)
				{
					l.ForeColor = Color.Olive;
				}
				bool flag18 = k % 3 == 2;
				if (flag18)
				{
					l.ForeColor = Color.DodgerBlue;
				}
			}
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00174304 File Offset: 0x00172504
		private void propert_card(int k, BunifuCards c)
		{
			c.BackColor = Color.White;
			c.BorderRadius = 5;
			c.BottomSahddow = true;
			c.LeftSahddow = false;
			c.Location = new Point(37, 212);
			c.RightSahddow = true;
			c.ShadowDepth = 20;
			c.Size = new Size(274, 225);
			bool flag = k == 0;
			if (flag)
			{
				c.color = Color.Crimson;
			}
			bool flag2 = k == 1;
			if (flag2)
			{
				c.color = Color.Olive;
			}
			bool flag3 = k == 2;
			if (flag3)
			{
				c.color = Color.DodgerBlue;
			}
			bool flag4 = k == 3;
			if (flag4)
			{
				c.color = Color.LimeGreen;
			}
			bool flag5 = k == 4;
			if (flag5)
			{
				c.color = Color.Tomato;
			}
			bool flag6 = k == 5;
			if (flag6)
			{
				c.color = Color.DarkOrchid;
			}
			bool flag7 = k == 6;
			if (flag7)
			{
				c.color = Color.Magenta;
			}
			bool flag8 = k == 7;
			if (flag8)
			{
				c.color = Color.DarkOrange;
			}
			bool flag9 = k == 8;
			if (flag9)
			{
				c.color = Color.Green;
			}
			bool flag10 = k == 9;
			if (flag10)
			{
				c.color = Color.Blue;
			}
			bool flag11 = k == 10;
			if (flag11)
			{
				c.color = Color.Red;
			}
			bool flag12 = k == 11;
			if (flag12)
			{
				c.color = Color.Teal;
			}
			bool flag13 = k == 12;
			if (flag13)
			{
				c.color = Color.Orchid;
			}
			bool flag14 = k == 12;
			if (flag14)
			{
				c.color = Color.Chocolate;
			}
			bool flag15 = k > 12;
			if (flag15)
			{
				bool flag16 = k % 3 == 0;
				if (flag16)
				{
					c.color = Color.Crimson;
				}
				bool flag17 = k % 3 == 1;
				if (flag17)
				{
					c.color = Color.Olive;
				}
				bool flag18 = k % 3 == 2;
				if (flag18)
				{
					c.color = Color.DodgerBlue;
				}
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00174518 File Offset: 0x00172718
		private void propertie_label(Label l, int x, int y, string esm)
		{
			l.AutoSize = true;
			l.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			l.ForeColor = Color.DimGray;
			l.Location = new Point(x, y);
			l.Size = new Size(19, 15);
			l.Text = esm;
		}
	}
}
