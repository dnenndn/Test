using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200007C RID: 124
	public partial class historique_brm : Form
	{
		// Token: 0x060005B5 RID: 1461 RVA: 0x000EE7D8 File Offset: 0x000EC9D8
		public historique_brm()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x000EE8A4 File Offset: 0x000ECAA4
		private void panel6_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1082, 1);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000EE8DE File Offset: 0x000ECADE
		private void historique_brm_Load(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radGridView1.Location = new Point(13, 31);
			this.radGridView1.Size = new Size(1104, 510);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x000EE920 File Offset: 0x000ECB20
		private void label1_Click(object sender, EventArgs e)
		{
			bool visible = this.panel1.Visible;
			if (visible)
			{
				this.panel1.Visible = false;
				this.radGridView1.Location = new Point(13, 31);
				this.radGridView1.Size = new Size(1104, 510);
			}
			else
			{
				this.panel1.Visible = true;
				this.radGridView1.Location = new Point(13, 197);
				this.radGridView1.Size = new Size(1104, 349);
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x000EE9C0 File Offset: 0x000ECBC0
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 8;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select brm.id,  date_retour, heure_retour, n_bsm, intervenant.nom, type_stock, type_retour from brm inner join intervenant on brm.retour_par = intervenant.id where (type_stock = @i1 or type_stock = @i2 or type_stock = @i3) and (date_retour between @d1 and @d2) and (n_bsm like '%' + @k + '%' or @k = @vide) and (intervenant.nom like '%' + @h + '%' ) and (type_retour = @m1 or type_retour = @m2 or type_retour = @m3 or type_retour = @m4 or type_retour = @m5) order by date_retour, heure_retour";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			bool @checked = this.radCheckBox1.Checked;
			if (@checked)
			{
				num = 1;
			}
			bool checked2 = this.radCheckBox2.Checked;
			if (checked2)
			{
				num2 = 2;
			}
			bool checked3 = this.radCheckBox6.Checked;
			if (checked3)
			{
				num3 = 3;
			}
			bool checked4 = this.radCheckBox7.Checked;
			if (checked4)
			{
				num4 = 4;
			}
			bool checked5 = this.radCheckBox8.Checked;
			if (checked5)
			{
				num5 = 5;
			}
			bool flag = this.radCheckBox4.Checked & this.radCheckBox3.Checked & this.radCheckBox5.Checked;
			if (flag)
			{
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
				sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
			}
			else
			{
				bool flag2 = this.radCheckBox4.Checked & this.radCheckBox3.Checked & !this.radCheckBox5.Checked;
				if (flag2)
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
					sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Neuf";
				}
				else
				{
					bool flag3 = this.radCheckBox4.Checked & !this.radCheckBox3.Checked & this.radCheckBox5.Checked;
					if (flag3)
					{
						sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Neuf";
						sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
					}
					else
					{
						bool flag4 = !this.radCheckBox4.Checked & this.radCheckBox3.Checked & this.radCheckBox5.Checked;
						if (flag4)
						{
							sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Usé";
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
							sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Rebuté";
						}
						else
						{
							bool flag5 = this.radCheckBox4.Checked & !this.radCheckBox3.Checked & !this.radCheckBox5.Checked;
							if (flag5)
							{
								sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Neuf";
								sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Neuf";
								sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Neuf";
							}
							else
							{
								bool flag6 = !this.radCheckBox4.Checked & this.radCheckBox3.Checked & !this.radCheckBox5.Checked;
								if (flag6)
								{
									sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Usé";
									sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Usé";
									sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Usé";
								}
								else
								{
									bool flag7 = !this.radCheckBox4.Checked & !this.radCheckBox3.Checked & this.radCheckBox5.Checked;
									if (flag7)
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
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = this.TextBox1.Text;
			sqlCommand.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
			sqlCommand.Parameters.Add("@h", SqlDbType.VarChar).Value = this.guna2TextBox2.Text;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand.Parameters.Add("@m1", SqlDbType.Int).Value = num;
			sqlCommand.Parameters.Add("@m2", SqlDbType.Int).Value = num2;
			sqlCommand.Parameters.Add("@m3", SqlDbType.Int).Value = num3;
			sqlCommand.Parameters.Add("@m4", SqlDbType.Int).Value = num4;
			sqlCommand.Parameters.Add("@m5", SqlDbType.Int).Value = num5;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag8 = dataTable.Rows.Count != 0;
			if (flag8)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						this.afficher_type_retour(Convert.ToInt32(dataTable.Rows[i].ItemArray[6].ToString())),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			bool flag9 = this.radGridView1.Rows.Count != 0;
			if (flag9)
			{
				bool flag10 = o == 0;
				if (flag10)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag11 = o == 1;
				if (flag11)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag12 = o == 2;
				if (flag12)
				{
					this.radGridView1.Rows[historique_brm.row_act].IsCurrent = true;
				}
				bool flag13 = o == 3;
				if (flag13)
				{
					bool flag14 = historique_brm.row_act != 0;
					if (flag14)
					{
						this.radGridView1.Rows[historique_brm.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.LoadArticle();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x000EF2C4 File Offset: 0x000ED4C4
		private string afficher_type_retour(int l)
		{
			string result = "";
			bool flag = l == 1;
			if (flag)
			{
				result = "Ancienne Pièce lors de la sortie d'une nouvelle pièce";
			}
			bool flag2 = l == 2;
			if (flag2)
			{
				result = "Pièce sortie non utilisée";
			}
			bool flag3 = l == 3;
			if (flag3)
			{
				result = "Pièce trouvée dans l'usine";
			}
			bool flag4 = l == 4;
			if (flag4)
			{
				result = "Retour Pièce pour réparation";
			}
			bool flag5 = l == 5;
			if (flag5)
			{
				result = "Retour qualité";
			}
			return result;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x000EF333 File Offset: 0x000ED533
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x000EF33E File Offset: 0x000ED53E
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x000EF349 File Offset: 0x000ED549
		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000EF354 File Offset: 0x000ED554
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x000EF35F File Offset: 0x000ED55F
		private void radCheckBox4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x000EF36A File Offset: 0x000ED56A
		private void radCheckBox3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x000EF375 File Offset: 0x000ED575
		private void radCheckBox5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x000EF380 File Offset: 0x000ED580
		private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x000EF38B File Offset: 0x000ED58B
		private void radCheckBox2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x000EF396 File Offset: 0x000ED596
		private void radCheckBox6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x000EF3A1 File Offset: 0x000ED5A1
		private void radCheckBox7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x000EF3AC File Offset: 0x000ED5AC
		private void radCheckBox8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000EF3B8 File Offset: 0x000ED5B8
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						historique_brm.row_act = e.RowIndex;
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "select type_stock from brm where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag5 = dataTable.Rows.Count != 0;
							if (flag5)
							{
								bool flag6 = dataTable.Rows[0].ItemArray[0].ToString() == "Neuf";
								if (flag6)
								{
									string cmdText2 = "select id_article, quantite from brm_article where id_brm = @i";
									SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
									sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
									SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
									DataTable dataTable2 = new DataTable();
									sqlDataAdapter2.Fill(dataTable2);
									bool flag7 = dataTable2.Rows.Count != 0;
									if (flag7)
									{
										for (int i = 0; i < dataTable2.Rows.Count; i++)
										{
											string cmdText3 = "update article set stock_neuf = stock_neuf - @v where id = @h";
											SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
											sqlCommand3.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable2.Rows[i].ItemArray[1]);
											sqlCommand3.Parameters.Add("@h", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
											bd.ouverture_bd(bd.cnn);
											sqlCommand3.ExecuteNonQuery();
											bd.cnn.Close();
											string cmdText4 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
											SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
											sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
											SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
											DataTable dataTable3 = new DataTable();
											sqlDataAdapter3.Fill(dataTable3);
											string cmdText5 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
											SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
											sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
											sqlCommand5.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
											sqlCommand5.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[1]);
											sqlCommand5.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[2]);
											sqlCommand5.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[3]);
											sqlCommand5.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[4]);
											sqlCommand5.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
											bd.ouverture_bd(bd.cnn);
											sqlCommand5.ExecuteNonQuery();
											bd.cnn.Close();
										}
									}
								}
								bool flag8 = dataTable.Rows[0].ItemArray[0].ToString() == "Usé";
								if (flag8)
								{
									string cmdText6 = "select id_article, quantite from brm_article where id_brm = @i";
									SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
									sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value;
									SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand6);
									DataTable dataTable4 = new DataTable();
									sqlDataAdapter4.Fill(dataTable4);
									bool flag9 = dataTable4.Rows.Count != 0;
									if (flag9)
									{
										for (int j = 0; j < dataTable4.Rows.Count; j++)
										{
											string cmdText7 = "update article set stock_use = stock_use - @v where id = @h";
											SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
											sqlCommand7.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable4.Rows[j].ItemArray[1]);
											sqlCommand7.Parameters.Add("@h", SqlDbType.Int).Value = dataTable4.Rows[j].ItemArray[0];
											bd.ouverture_bd(bd.cnn);
											sqlCommand7.ExecuteNonQuery();
											bd.cnn.Close();
											string cmdText8 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
											SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
											sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = dataTable4.Rows[j].ItemArray[0];
											SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand8);
											DataTable dataTable5 = new DataTable();
											sqlDataAdapter5.Fill(dataTable5);
											string cmdText9 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
											SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
											sqlCommand9.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable4.Rows[j].ItemArray[0];
											sqlCommand9.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[0]);
											sqlCommand9.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[1]);
											sqlCommand9.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[2]);
											sqlCommand9.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[3]);
											sqlCommand9.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable5.Rows[0].ItemArray[4]);
											sqlCommand9.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
											bd.ouverture_bd(bd.cnn);
											sqlCommand9.ExecuteNonQuery();
											bd.cnn.Close();
										}
									}
								}
								bool flag10 = dataTable.Rows[0].ItemArray[0].ToString() == "Rebuté";
								if (flag10)
								{
									string cmdText10 = "select id_article, quantite from brm_article where id_brm = @i";
									SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd.cnn);
									sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = value;
									SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand10);
									DataTable dataTable6 = new DataTable();
									sqlDataAdapter6.Fill(dataTable6);
									bool flag11 = dataTable6.Rows.Count != 0;
									if (flag11)
									{
										for (int k = 0; k < dataTable6.Rows.Count; k++)
										{
											string cmdText11 = "update article set stock_rebute = stock_rebute - @v where id = @h";
											SqlCommand sqlCommand11 = new SqlCommand(cmdText11, bd.cnn);
											sqlCommand11.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(dataTable6.Rows[k].ItemArray[1]);
											sqlCommand11.Parameters.Add("@h", SqlDbType.Int).Value = dataTable6.Rows[k].ItemArray[0];
											bd.ouverture_bd(bd.cnn);
											sqlCommand11.ExecuteNonQuery();
											bd.cnn.Close();
											string cmdText12 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
											SqlCommand sqlCommand12 = new SqlCommand(cmdText12, bd.cnn);
											sqlCommand12.Parameters.Add("@i", SqlDbType.Int).Value = dataTable6.Rows[k].ItemArray[0];
											SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand12);
											DataTable dataTable7 = new DataTable();
											sqlDataAdapter7.Fill(dataTable7);
											string cmdText13 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
											SqlCommand sqlCommand13 = new SqlCommand(cmdText13, bd.cnn);
											sqlCommand13.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable6.Rows[k].ItemArray[0];
											sqlCommand13.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[0]);
											sqlCommand13.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[1]);
											sqlCommand13.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[2]);
											sqlCommand13.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[3]);
											sqlCommand13.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable7.Rows[0].ItemArray[4]);
											sqlCommand13.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
											bd.ouverture_bd(bd.cnn);
											sqlCommand13.ExecuteNonQuery();
											bd.cnn.Close();
										}
									}
								}
							}
							string cmdText14 = "delete brm where id = @i";
							string cmdText15 = "delete brm_article where id_brm = @i";
							SqlCommand sqlCommand14 = new SqlCommand(cmdText14, bd.cnn);
							SqlCommand sqlCommand15 = new SqlCommand(cmdText15, bd.cnn);
							sqlCommand14.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand15.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand14.ExecuteNonQuery();
							sqlCommand15.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
				}
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x000EFF3C File Offset: 0x000EE13C
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select id_brm, article.designation, quantite from brm_article inner join article on brm_article.id_article = article.id inner join brm on brm_article.id_brm = brm.id  where date_retour between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 300;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Désignation";
				gridViewTemplate.Columns[2].HeaderText = "Quantité";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x040007A8 RID: 1960
		private static int row_act;
	}
}
