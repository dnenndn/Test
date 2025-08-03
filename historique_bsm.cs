using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200007D RID: 125
	public partial class historique_bsm : Form
	{
		// Token: 0x060005CB RID: 1483 RVA: 0x000F1FEC File Offset: 0x000F01EC
		public historique_bsm()
		{
			this.InitializeComponent();
			historique_bsm.ProgressBar1.Hide();
			historique_bsm.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			historique_bsm.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			historique_bsm.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			historique_bsm.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			historique_bsm.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			historique_bsm.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			historique_bsm.radGridView2.RowsChanged += new GridViewCollectionChangedEventHandler(this.RadGridView2_RowsChanged);
			historique_bsm.radGridView2.CellClick += new GridViewCellEventHandler(this.RadGridView2_CellClick);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			historique_bsm.radDateTimePicker1.Value = value;
			historique_bsm.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			historique_bsm.remplissage_tableau(0);
			this.button1.Click += this.Button1_Click;
			this.button2.Click += this.Button2_Click;
			this.button3.Click += this.Button3_Click;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x000F2178 File Offset: 0x000F0378
		private void Button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.panel5.Controls.Clear();
			bsm_equipement bsm_equipement = new bsm_equipement();
			bsm_equipement.TopLevel = false;
			this.panel5.Controls.Add(bsm_equipement);
			bsm_equipement.Show();
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x000F2224 File Offset: 0x000F0424
		private void Button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel5.Controls.Clear();
			bsm_general bsm_general = new bsm_general();
			bsm_general.TopLevel = false;
			this.panel5.Controls.Add(bsm_general);
			bsm_general.Show();
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x000F22D0 File Offset: 0x000F04D0
		private void Button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel5.Controls.Clear();
			bsm_article bsm_article = new bsm_article();
			bsm_article.TopLevel = false;
			this.panel5.Controls.Add(bsm_article);
			bsm_article.Show();
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x000F237C File Offset: 0x000F057C
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex == 0 & e.ColumnIndex == 2;
			if (flag)
			{
				historique_bsm.radGridView2.Rows.Clear();
			}
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x000F23B3 File Offset: 0x000F05B3
		private void RadGridView2_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000F23C0 File Offset: 0x000F05C0
		private void panel6_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1082, 1);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x000F23FC File Offset: 0x000F05FC
		private void label1_Click(object sender, EventArgs e)
		{
			bool flag = !this.panel1.Visible;
			if (flag)
			{
				this.panel4.Visible = false;
				this.panel1.Visible = true;
				historique_bsm.radGridView1.Location = new Point(12, 177);
				historique_bsm.radGridView1.Size = new Size(1104, 377);
			}
			else
			{
				this.panel1.Visible = false;
				this.panel4.Visible = false;
				historique_bsm.radGridView1.Location = new Point(12, 21);
				historique_bsm.radGridView1.Size = new Size(1104, 530);
			}
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x000F24B8 File Offset: 0x000F06B8
		private void panel7_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1082, 1);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x000F24F4 File Offset: 0x000F06F4
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel1.Hide();
			this.panel4.Hide();
			historique_bsm.radGridView1.Location = new Point(12, 21);
			historique_bsm.radGridView1.Size = new Size(1104, 530);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x000F2548 File Offset: 0x000F0748
		private void historique_bsm_Load(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.panel4.Visible = false;
			historique_bsm.radGridView1.Location = new Point(12, 21);
			historique_bsm.radGridView1.Size = new Size(1104, 530);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x000F25A0 File Offset: 0x000F07A0
		public static void remplissage_tableau(int o)
		{
			historique_bsm.radGridView1.Rows.Clear();
			historique_bsm.radGridView1.AllowDragToGroup = false;
			historique_bsm.radGridView1.AllowAddNewRow = false;
			historique_bsm.radGridView1.EnablePaging = true;
			historique_bsm.radGridView1.PageSize = 14;
			historique_bsm.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			List<int> list = new List<int>();
			int id_prn = -1;
			bool flag = historique_bsm.radGridView2.Rows.Count != 0;
			if (flag)
			{
				id_prn = Convert.ToInt32(historique_bsm.radGridView2.Rows[0].Cells[0].Value);
			}
			string str = "(@un = @un)";
			fonction.telecharger_tous_id_enfant(id_prn, list);
			string text = string.Join<int>(",", list.ToArray());
			historique_bsm.ProgressBar1.Hide();
			bool flag2 = historique_bsm.radGridView2.Rows.Count != 0;
			if (flag2)
			{
				str = "(equipement.id in (" + text + ") or @tag_equip = @dvarc1)";
			}
			string str2 = "and " + str;
			string cmdText = "select bsm.id,  date_bsm, heure_bsm,utilisateur.login, n_ot, equipement.designation, intervenant.nom, type_stock, bsm_maintenance, equipement.id, bsm.validation, equipement.code from bsm inner join utilisateur on bsm.createur = utilisateur.id left join intervenant on bsm.id_receptionniste = intervenant.id left join bsm_equipement on bsm.id = bsm_equipement.id_bsm left join equipement on bsm_equipement.id_equipement = equipement.id where (bsm_maintenance = @v1 or  bsm_maintenance = @v2) and (type_stock = @i1 or type_stock = @i2 or type_stock = @i3 or type_stock = @i4) and (date_bsm between @d1 and @d2) and (n_ot like '%' + @k + '%' or @k = @vide) and (intervenant.nom like '%' + @h + '%' ) " + str2 + " order by date_bsm, heure_bsm ";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@dvarc1", SqlDbType.VarChar).Value = "-1";
			sqlCommand.Parameters.Add("@un", SqlDbType.VarChar).Value = 1;
			sqlCommand.Parameters.Add("@deux", SqlDbType.VarChar).Value = 2;
			sqlCommand.Parameters.Add("@tag_equip", SqlDbType.VarChar).Value = text;
			bool flag3 = historique_bsm.radCheckBox1.Checked & historique_bsm.radCheckBox2.Checked;
			if (flag3)
			{
				sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = "Oui";
				sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = "Non";
			}
			else
			{
				bool flag4 = historique_bsm.radCheckBox1.Checked & !historique_bsm.radCheckBox2.Checked;
				if (flag4)
				{
					sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = "Oui";
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = "Oui";
				}
				else
				{
					bool flag5 = !historique_bsm.radCheckBox1.Checked & historique_bsm.radCheckBox2.Checked;
					if (flag5)
					{
						sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = "Non";
						sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = "Non";
					}
					else
					{
						sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = "N";
						sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = "N";
					}
				}
			}
			bool flag6 = historique_bsm.radCheckBox4.Checked & historique_bsm.radCheckBox3.Checked & historique_bsm.radCheckBox5.Checked;
			if (flag6)
			{
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
				sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
			}
			else
			{
				bool flag7 = historique_bsm.radCheckBox4.Checked & historique_bsm.radCheckBox3.Checked & !historique_bsm.radCheckBox5.Checked;
				if (flag7)
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
					sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Neuf";
				}
				else
				{
					bool flag8 = historique_bsm.radCheckBox4.Checked & !historique_bsm.radCheckBox3.Checked & historique_bsm.radCheckBox5.Checked;
					if (flag8)
					{
						sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Neuf";
						sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
					}
					else
					{
						bool flag9 = !historique_bsm.radCheckBox4.Checked & historique_bsm.radCheckBox3.Checked & historique_bsm.radCheckBox5.Checked;
						if (flag9)
						{
							sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Usé";
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
							sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
						}
						else
						{
							bool flag10 = historique_bsm.radCheckBox4.Checked & !historique_bsm.radCheckBox3.Checked & !historique_bsm.radCheckBox5.Checked;
							if (flag10)
							{
								sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
								sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Neuf";
								sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Neuf";
							}
							else
							{
								bool flag11 = !historique_bsm.radCheckBox4.Checked & historique_bsm.radCheckBox3.Checked & !historique_bsm.radCheckBox5.Checked;
								if (flag11)
								{
									sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Usé";
									sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
									sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Usé";
								}
								else
								{
									bool flag12 = !historique_bsm.radCheckBox4.Checked & !historique_bsm.radCheckBox3.Checked & historique_bsm.radCheckBox5.Checked;
									if (flag12)
									{
										sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Rebuté";
										sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Rebuté";
										sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
									}
									else
									{
										sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "N";
										sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "N";
										sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "N";
									}
								}
							}
						}
					}
				}
			}
			bool @checked = historique_bsm.radCheckBox6.Checked;
			if (@checked)
			{
				sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = "Réparable";
			}
			else
			{
				sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = "N";
			}
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = historique_bsm.TextBox1.Text;
			sqlCommand.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
			sqlCommand.Parameters.Add("@h", SqlDbType.VarChar).Value = historique_bsm.guna2TextBox2.Text;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = historique_bsm.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = historique_bsm.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag13 = dataTable.Rows.Count != 0;
			if (flag13)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					historique_bsm.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString() + "-" + dataTable.Rows[i].ItemArray[11].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[8].ToString(),
						dataTable.Rows[i].ItemArray[10].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_,
						dataTable.Rows[i].ItemArray[9].ToString()
					});
					bool flag14 = historique_bsm.radGridView1.Rows[i].Cells[9].Value.ToString() == "Oui";
					if (flag14)
					{
						historique_bsm.radGridView1.Rows[i].Cells[13].Value = "Retourner non validé";
					}
					else
					{
						historique_bsm.radGridView1.Rows[i].Cells[13].Value = "Valider";
					}
				}
				bool flag15 = page_loginn.stat_user != "Agent de Méthode" & page_loginn.stat_user != "Responsable Méthode";
				if (flag15)
				{
					historique_bsm.radGridView1.Columns[13].IsVisible = false;
					historique_bsm.radGridView1.Columns[10].IsVisible = false;
				}
				bool flag16 = page_loginn.stat_user != "Responsable Méthode";
				if (flag16)
				{
					historique_bsm.radGridView1.Columns[14].IsVisible = false;
				}
			}
			bool flag17 = historique_bsm.radGridView1.Rows.Count != 0;
			if (flag17)
			{
				bool flag18 = o == 0;
				if (flag18)
				{
					historique_bsm.radGridView1.MasterTemplate.MoveToFirstPage();
					historique_bsm.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag19 = o == 1;
				if (flag19)
				{
					historique_bsm.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag20 = o == 2;
				if (flag20)
				{
					historique_bsm.radGridView1.Rows[historique_bsm.row_act].IsCurrent = true;
				}
				bool flag21 = o == 3;
				if (flag21)
				{
					bool flag22 = historique_bsm.row_act != 0;
					if (flag22)
					{
						historique_bsm.radGridView1.Rows[historique_bsm.row_act - 1].IsCurrent = true;
					}
					else
					{
						historique_bsm.radGridView1.MasterTemplate.MoveToFirstPage();
						historique_bsm.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			historique_bsm.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			historique_bsm.radGridView1.Templates.Clear();
			historique_bsm.LoadArticle();
			historique_bsm.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			historique_bsm.radGridView1.MasterView.TableSearchRow.SelectNextSearchResult();
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x000F322A File Offset: 0x000F142A
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x000F3234 File Offset: 0x000F1434
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x000F323E File Offset: 0x000F143E
		private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x000F3248 File Offset: 0x000F1448
		private void radCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x000F3252 File Offset: 0x000F1452
		private void radCheckBox4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x000F325C File Offset: 0x000F145C
		private void radCheckBox3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000F3266 File Offset: 0x000F1466
		private void radCheckBox5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x000F3270 File Offset: 0x000F1470
		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x000F327A File Offset: 0x000F147A
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x000F3284 File Offset: 0x000F1484
		private static void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_bsm, article.designation, quantite, bsm.type_stock, magasin_sous_traitance.ref_interne, bsm_article.prix_ht, quantite * bsm_article.prix_ht from bsm_article inner join article on bsm_article.id_article = article.id inner join bsm on bsm_article.id_bsm = bsm.id inner join magasin_sous_traitance on bsm_article.id_article = magasin_sous_traitance.id_article inner join ds_historique_mvt h on bsm_article.id_bsm =  h.id_mvt and magasin_sous_traitance.id = h.id_t  and h.mvt = @r   where date_bsm between @d1 and @d2 and bsm_article.quantite <> @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = historique_bsm.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = historique_bsm.radDateTimePicker2.Value;
			sqlCommand.Parameters.Add("@r", SqlDbType.VarChar).Value = "BSM";
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select id_bsm, article.designation, quantite, bsm.type_stock, bsm_article.prix_ht, quantite * bsm_article.prix_ht from bsm_article inner join article on bsm_article.id_article = article.id inner join bsm on bsm_article.id_bsm = bsm.id  where date_bsm between @d1 and @d2 and bsm.type_stock <> @s and bsm_article.quantite <> @d";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = historique_bsm.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = historique_bsm.radDateTimePicker2.Value;
			sqlCommand2.Parameters.Add("@s", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			DataTable dataTable3 = new DataTable();
			dataTable3.Columns.Add("column1");
			dataTable3.Columns.Add("column2");
			dataTable3.Columns.Add("column3");
			dataTable3.Columns.Add("column4");
			dataTable3.Columns.Add("column5");
			bool flag = dataTable.Rows.Count != 0 | dataTable2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString() + " - " + dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000")
					});
				}
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					dataTable3.Rows.Add(new object[]
					{
						dataTable2.Rows[j].ItemArray[0].ToString(),
						dataTable2.Rows[j].ItemArray[1].ToString(),
						dataTable2.Rows[j].ItemArray[2].ToString(),
						Convert.ToDouble(dataTable2.Rows[j].ItemArray[4]).ToString("0.000"),
						Convert.ToDouble(dataTable2.Rows[j].ItemArray[5]).ToString("0.000")
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable3;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 300;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Désignation";
				gridViewTemplate.Columns[2].HeaderText = "Quantité";
				gridViewTemplate.Columns[3].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[4].HeaderText = "Prix Tot HT";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].ExcelExportType = 2;
				gridViewTemplate.Columns[4].ExcelExportType = 2;
				historique_bsm.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(historique_bsm.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(historique_bsm.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				historique_bsm.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000F3920 File Offset: 0x000F1B20
		private static void remplissage_id_equip(List<int> l, int p)
		{
			bd bd = new bd();
			string cmdText = "select id from equipement where id_parent = @p and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@p", SqlDbType.Int).Value = p;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					l.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
					historique_bsm.remplissage_id_equip(l, Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000F3A14 File Offset: 0x000F1C14
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			equipement_list_bsm equipement_list_bsm = new equipement_list_bsm();
			equipement_list_bsm.Show();
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000F3A30 File Offset: 0x000F1C30
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			historique_bsm.row_act = e.RowIndex;
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 13;
			if (flag)
			{
				string value = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				bool flag2 = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() == "Oui";
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Retourner non validé ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update bsm set validation = @n where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = "Non";
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						historique_bsm.radGridView1.Rows[e.RowIndex].Cells[9].Value = "Non";
						historique_bsm.radGridView1.Rows[e.RowIndex].Cells[13].Value = "Valider";
					}
				}
				else
				{
					DialogResult dialogResult2 = MessageBox.Show("Vous voulez Valider ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag4 = dialogResult2 == DialogResult.Yes;
					if (flag4)
					{
						bd bd2 = new bd();
						string cmdText2 = "update bsm set validation = @n where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
						sqlCommand2.Parameters.Add("@n", SqlDbType.VarChar).Value = "Oui";
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd2.cnn.Close();
						historique_bsm.radGridView1.Rows[e.RowIndex].Cells[9].Value = "Oui";
						historique_bsm.radGridView1.Rows[e.RowIndex].Cells[13].Value = "Retourner non validé";
					}
				}
			}
			bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 11;
			if (flag5)
			{
				string value2 = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				historique_bsm.row_act = e.RowIndex;
				DialogResult dialogResult3 = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag6 = dialogResult3 == DialogResult.Yes;
				if (flag6)
				{
					bd bd3 = new bd();
					string cmdText3 = "select type_stock from bsm where id = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value2;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag7 = dataTable.Rows.Count != 0;
					if (flag7)
					{
						bool flag8 = dataTable.Rows[0].ItemArray[0].ToString() == "Neuf";
						if (flag8)
						{
							string cmdText4 = "select id_article, quantite from bsm_article where id_bsm = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd3.cnn);
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag9 = dataTable2.Rows.Count != 0;
							if (flag9)
							{
								for (int i = 0; i < dataTable2.Rows.Count; i++)
								{
									string cmdText5 = "update article set stock_neuf = stock_neuf + @v where id = @h";
									SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd3.cnn);
									sqlCommand5.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable2.Rows[i].ItemArray[1]);
									sqlCommand5.Parameters.Add("@h", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
									bd3.ouverture_bd(bd3.cnn);
									sqlCommand5.ExecuteNonQuery();
									bd3.cnn.Close();
									string cmdText6 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
									SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd3.cnn);
									sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
									SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand6);
									DataTable dataTable3 = new DataTable();
									sqlDataAdapter3.Fill(dataTable3);
									string cmdText7 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
									SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd3.cnn);
									sqlCommand7.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
									sqlCommand7.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
									sqlCommand7.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[1]);
									sqlCommand7.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[2]);
									sqlCommand7.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[3]);
									sqlCommand7.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[4]);
									sqlCommand7.Parameters.Add("@i7", SqlDbType.Date).Value = historique_bsm.radDateTimePicker1.Value;
									bd3.ouverture_bd(bd3.cnn);
									sqlCommand7.ExecuteNonQuery();
									bd3.cnn.Close();
								}
							}
						}
						bool flag10 = dataTable.Rows[0].ItemArray[0].ToString() == "Usé";
						if (flag10)
						{
							string cmdText8 = "select id_article, quantite from bsm_article where id_bsm = @i";
							SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd3.cnn);
							sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand8);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							bool flag11 = dataTable4.Rows.Count != 0;
							if (flag11)
							{
								for (int j = 0; j < dataTable4.Rows.Count; j++)
								{
									string cmdText9 = "update article set stock_use = stock_use + @v where id = @h";
									SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd3.cnn);
									sqlCommand9.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable4.Rows[j].ItemArray[1]);
									sqlCommand9.Parameters.Add("@h", SqlDbType.Int).Value = dataTable4.Rows[j].ItemArray[0];
									bd3.ouverture_bd(bd3.cnn);
									sqlCommand9.ExecuteNonQuery();
									bd3.cnn.Close();
									string cmdText10 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
									SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd3.cnn);
									sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = dataTable4.Rows[j].ItemArray[0];
									SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand10);
									DataTable dataTable5 = new DataTable();
									sqlDataAdapter5.Fill(dataTable5);
									string cmdText11 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
									SqlCommand sqlCommand11 = new SqlCommand(cmdText11, bd3.cnn);
									sqlCommand11.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable4.Rows[j].ItemArray[0];
									sqlCommand11.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[0]);
									sqlCommand11.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[1]);
									sqlCommand11.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[2]);
									sqlCommand11.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[3]);
									sqlCommand11.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[4]);
									sqlCommand11.Parameters.Add("@i7", SqlDbType.Date).Value = historique_bsm.radDateTimePicker1.Value;
									bd3.ouverture_bd(bd3.cnn);
									sqlCommand11.ExecuteNonQuery();
									bd3.cnn.Close();
								}
							}
						}
						bool flag12 = dataTable.Rows[0].ItemArray[0].ToString() == "Rebuté";
						if (flag12)
						{
							string cmdText12 = "select id_article, quantite from bsm_article where id_bsm = @i";
							SqlCommand sqlCommand12 = new SqlCommand(cmdText12, bd3.cnn);
							sqlCommand12.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand12);
							DataTable dataTable6 = new DataTable();
							sqlDataAdapter6.Fill(dataTable6);
							bool flag13 = dataTable6.Rows.Count != 0;
							if (flag13)
							{
								for (int k = 0; k < dataTable6.Rows.Count; k++)
								{
									string cmdText13 = "update article set stock_rebute = stock_rebute + @v where id = @h";
									SqlCommand sqlCommand13 = new SqlCommand(cmdText13, bd3.cnn);
									sqlCommand13.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable6.Rows[k].ItemArray[1]);
									sqlCommand13.Parameters.Add("@h", SqlDbType.Int).Value = dataTable6.Rows[k].ItemArray[0];
									bd3.ouverture_bd(bd3.cnn);
									sqlCommand13.ExecuteNonQuery();
									bd3.cnn.Close();
									string cmdText14 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
									SqlCommand sqlCommand14 = new SqlCommand(cmdText14, bd3.cnn);
									sqlCommand14.Parameters.Add("@i", SqlDbType.Int).Value = dataTable6.Rows[k].ItemArray[0];
									SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand14);
									DataTable dataTable7 = new DataTable();
									sqlDataAdapter7.Fill(dataTable7);
									string cmdText15 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
									SqlCommand sqlCommand15 = new SqlCommand(cmdText15, bd3.cnn);
									sqlCommand15.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable6.Rows[k].ItemArray[0];
									sqlCommand15.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[0]);
									sqlCommand15.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[1]);
									sqlCommand15.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[2]);
									sqlCommand15.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[3]);
									sqlCommand15.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[4]);
									sqlCommand15.Parameters.Add("@i7", SqlDbType.Date).Value = historique_bsm.radDateTimePicker1.Value;
									bd3.ouverture_bd(bd3.cnn);
									sqlCommand15.ExecuteNonQuery();
									bd3.cnn.Close();
								}
							}
						}
						bool flag14 = dataTable.Rows[0].ItemArray[0].ToString() == "Réparable";
						if (flag14)
						{
							string cmdText16 = "update magasin_sous_traitance set emplacement_actuel = @u, equipement_actuel = @e where id in (select id_t from ds_historique_mvt where id_mvt = @i and mvt = @m)";
							SqlCommand sqlCommand16 = new SqlCommand(cmdText16, bd3.cnn);
							sqlCommand16.Parameters.Add("@u", SqlDbType.VarChar).Value = "Magasin";
							sqlCommand16.Parameters.Add("@e", SqlDbType.Int).Value = 0;
							sqlCommand16.Parameters.Add("@i", SqlDbType.Int).Value = value2;
							sqlCommand16.Parameters.Add("@m", SqlDbType.VarChar).Value = "BSM";
							bd3.ouverture_bd(bd3.cnn);
							sqlCommand16.ExecuteNonQuery();
							bd3.cnn.Close();
							string cmdText17 = "delete ds_historique_mvt where id_mvt = @i1 and mvt = @m";
							SqlCommand sqlCommand17 = new SqlCommand(cmdText17, bd3.cnn);
							sqlCommand17.Parameters.Add("@i1", SqlDbType.Int).Value = value2;
							sqlCommand17.Parameters.Add("@m", SqlDbType.VarChar).Value = "BSM";
							bd3.ouverture_bd(bd3.cnn);
							sqlCommand17.ExecuteNonQuery();
							bd3.cnn.Close();
						}
					}
					string cmdText18 = "delete bsm where id = @i";
					string cmdText19 = "delete bsm_article where id_bsm = @i";
					string cmdText20 = "delete bsm_equipement where id_bsm = @i";
					SqlCommand sqlCommand18 = new SqlCommand(cmdText18, bd3.cnn);
					SqlCommand sqlCommand19 = new SqlCommand(cmdText19, bd3.cnn);
					SqlCommand sqlCommand20 = new SqlCommand(cmdText20, bd3.cnn);
					sqlCommand18.Parameters.Add("@i", SqlDbType.Int).Value = value2;
					sqlCommand19.Parameters.Add("@i", SqlDbType.Int).Value = value2;
					sqlCommand20.Parameters.Add("@i", SqlDbType.Int).Value = value2;
					bd3.ouverture_bd(bd3.cnn);
					sqlCommand18.ExecuteNonQuery();
					sqlCommand19.ExecuteNonQuery();
					sqlCommand20.ExecuteNonQuery();
					bd3.cnn.Close();
					historique_bsm.remplissage_tableau(3);
				}
			}
			bool flag15 = e.RowIndex >= 0 && e.ColumnIndex == 14;
			if (flag15)
			{
				bool flag16 = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() != "Réparable";
				if (flag16)
				{
					string value3 = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					historique_bsm.row_act = e.RowIndex;
					DialogResult dialogResult4 = MessageBox.Show("Vous voulez Mettre à jour les prix ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag17 = dialogResult4 == DialogResult.Yes;
					if (flag17)
					{
						bd bd4 = new bd();
						string cmdText21 = "update bsm_article set bsm_article.prix_ht = article.prix_ht from bsm_article inner join article on bsm_article.id_article = article.id where id_bsm = @i";
						SqlCommand sqlCommand21 = new SqlCommand(cmdText21, bd4.cnn);
						sqlCommand21.Parameters.Add("@i", SqlDbType.Int).Value = value3;
						bd4.ouverture_bd(bd4.cnn);
						sqlCommand21.ExecuteNonQuery();
						bd4.cnn.Close();
						MessageBox.Show("Mise à jour avec succés");
					}
				}
				else
				{
					MessageBox.Show("Erreur : Impossible de faire un mise à jour d'un BSM des articles réparables", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool flag18 = e.RowIndex >= 0 && e.ColumnIndex == 10;
			if (flag18)
			{
				this.panel1.Visible = false;
				this.panel4.Visible = true;
				historique_bsm.radGridView1.Location = new Point(12, 21);
				historique_bsm.radGridView1.Size = new Size(1104, 330);
				historique_bsm.id_bsm = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				this.panel5.Controls.Clear();
				bsm_general bsm_general = new bsm_general();
				bsm_general.TopLevel = false;
				this.panel5.Controls.Add(bsm_general);
				bsm_general.Show();
				this.button2.ForeColor = Color.Firebrick;
				this.button2.BackColor = Color.White;
				this.button1.ForeColor = Color.White;
				this.button1.BackColor = Color.Firebrick;
				this.button3.ForeColor = Color.White;
				this.button3.BackColor = Color.Firebrick;
				bool flag19 = historique_bsm.radGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Réparable";
				if (flag19)
				{
					this.button2.Dock = DockStyle.Left;
					this.button1.Dock = DockStyle.Left;
					this.button3.Dock = DockStyle.Left;
					this.button1.Hide();
				}
				else
				{
					this.button1.Show();
					this.button2.Dock = DockStyle.None;
					this.button1.Dock = DockStyle.None;
					this.button3.Dock = DockStyle.None;
				}
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x000F4CA8 File Offset: 0x000F2EA8
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 13;
			if (flag)
			{
				bool flag2 = e.CellElement.Value != null;
				if (flag2)
				{
					bool flag3 = e.CellElement.Value.ToString() == "Valider";
					if (flag3)
					{
						RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
						radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
						radButtonElement.ForeColor = Color.White;
						radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
					}
					else
					{
						RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
						radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
						radButtonElement2.ForeColor = Color.White;
						radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
					}
				}
			}
			bool flag4 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 14;
			if (flag4)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.Text = "Mise à jour";
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Goldenrod, "", typeof(FillPrimitive));
				radButtonElement3.ForeColor = Color.White;
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000F4EBC File Offset: 0x000F30BC
		private void radCheckBox6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			historique_bsm.remplissage_tableau(0);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000F4EC8 File Offset: 0x000F30C8
		private static void telecharger_tous_id_enfant(int id_prn, List<int> l)
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
					historique_bsm.telecharger_tous_id_enfant(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]), l);
				}
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000F4FA4 File Offset: 0x000F31A4
		private void radButton3_Click(object sender, EventArgs e)
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

		// Token: 0x060005E8 RID: 1512 RVA: 0x000F4FF4 File Offset: 0x000F31F4
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(historique_bsm.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(historique_bsm.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x040007C3 RID: 1987
		private static int row_act;

		// Token: 0x040007C4 RID: 1988
		public static string id_bsm;
	}
}
