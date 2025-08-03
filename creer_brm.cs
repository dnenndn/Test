using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000052 RID: 82
	public partial class creer_brm : Form
	{
		// Token: 0x060003A5 RID: 933 RVA: 0x00099AC0 File Offset: 0x00097CC0
		public creer_brm()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00099B4E File Offset: 0x00097D4E
		private void creer_brm_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.select_intervenant();
			this.select_article();
			this.affichage_n_bsm();
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00099B90 File Offset: 0x00097D90
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
					radTreeNode.Text = (dataTable.Rows[i].ItemArray[1].ToString() ?? "");
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00099CC8 File Offset: 0x00097EC8
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select parametre_unite_article.designation from tableau_article_unite inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where id_article = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode.Tag;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					this.radGridView1.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.ToolTipText,
						0,
						Convert.ToString(dataTable.Rows[0].ItemArray[0])
					});
					this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[4].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					this.radGridView1.Templates.Clear();
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00099E20 File Offset: 0x00098020
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00099EA8 File Offset: 0x000980A8
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.radGridView1.Rows.RemoveAt(e.RowIndex);
						}
					}
				}
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00099F68 File Offset: 0x00098168
		private void select_intervenant()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, nom from intervenant where deleted = @i order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0009A06E File Offset: 0x0009826E
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0009A088 File Offset: 0x00098288
		private void affichage_n_bsm()
		{
			bool flag = this.radRadioButton1.IsChecked | this.radRadioButton2.IsChecked | this.radRadioButton7.IsChecked;
			if (flag)
			{
				this.label10.Show();
				this.label14.Show();
				this.TextBox1.Show();
			}
			else
			{
				this.label10.Hide();
				this.label14.Hide();
				this.TextBox1.Hide();
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0009A10B File Offset: 0x0009830B
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_n_bsm();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0009A115 File Offset: 0x00098315
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_n_bsm();
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0009A11F File Offset: 0x0009831F
		private void radRadioButton6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_n_bsm();
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0009A129 File Offset: 0x00098329
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_n_bsm();
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0009A133 File Offset: 0x00098333
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage_n_bsm();
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0009A140 File Offset: 0x00098340
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.radDropDownList6.Text != "";
				if (flag2)
				{
					int num = 0;
					bool flag3 = this.radRadioButton1.IsChecked | this.radRadioButton2.IsChecked | this.radRadioButton7.IsChecked;
					if (flag3)
					{
						fonction fonction = new fonction();
						bool flag4 = fonction.isnumeric(this.TextBox1.Text);
						if (flag4)
						{
							bool flag5 = Convert.ToInt32(this.TextBox1.Text) > 0;
							if (flag5)
							{
								num = 1;
							}
						}
					}
					else
					{
						num = 1;
					}
					bool flag6 = num == 1;
					if (flag6)
					{
						bool flag7 = this.radRadioButton1.IsChecked | this.radRadioButton2.IsChecked | this.radRadioButton7.IsChecked;
						if (flag7)
						{
							bd bd = new bd();
							string cmdText = "select date_bsm, heure_bsm from bsm where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.TextBox1.Text;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag8 = dataTable.Rows.Count != 0;
							if (flag8)
							{
								DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0].ItemArray[0]);
								int num2 = 0;
								bool flag9 = this.radDateTimePicker1.Value > dateTime.Date;
								if (flag9)
								{
									num2 = 2;
								}
								else
								{
									bool flag10 = this.radDateTimePicker1.Value == dateTime.Date;
									if (flag10)
									{
										num2 = this.compare_heure(Convert.ToString(dataTable.Rows[0].ItemArray[1]), Convert.ToString(fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 8)));
									}
								}
								bool flag11 = num2 == 2;
								if (flag11)
								{
									int num3 = 1;
									string str = "";
									for (int i = 0; i < this.radGridView1.Rows.Count; i++)
									{
										bool flag12 = num3 == 0;
										if (flag12)
										{
											break;
										}
										string cmdText2 = "select id from bsm_article where id_article = @i and id_bsm = @h";
										SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
										sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value;
										sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = this.TextBox1.Text;
										SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
										DataTable dataTable2 = new DataTable();
										sqlDataAdapter2.Fill(dataTable2);
										bool flag13 = dataTable2.Rows.Count == 0;
										if (flag13)
										{
											num3 = 0;
											str = this.radGridView1.Rows[i].Cells[1].Value.ToString();
										}
									}
									bool flag14 = num3 == 1;
									if (flag14)
									{
										int num4 = 1;
										for (int j = 0; j < this.radGridView1.Rows.Count; j++)
										{
											fonction fonction2 = new fonction();
											bool flag15 = !fonction2.is_reel(this.radGridView1.Rows[j].Cells[2].Value.ToString());
											if (flag15)
											{
												num4 = 0;
											}
										}
										bool flag16 = num4 == 1;
										if (flag16)
										{
											int num5 = 1;
											for (int k = 0; k < this.radGridView1.Rows.Count; k++)
											{
												bool flag17 = Convert.ToDouble(this.radGridView1.Rows[k].Cells[2].Value.ToString()) <= 0.0;
												if (flag17)
												{
													num5 = 0;
												}
											}
											bool flag18 = num5 == 1;
											if (flag18)
											{
												bool flag19 = this.radRadioButton2.IsChecked | this.radRadioButton7.IsChecked;
												if (flag19)
												{
													int num6 = 1;
													for (int l = 0; l < this.radGridView1.Rows.Count; l++)
													{
														string cmdText3 = "select id from bsm_article where id_article = @i and id_bsm = @h and quantite < @j";
														SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
														sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[l].Cells[0].Value;
														sqlCommand3.Parameters.Add("@h", SqlDbType.Int).Value = this.TextBox1.Text;
														sqlCommand3.Parameters.Add("@j", SqlDbType.Int).Value = Convert.ToDouble(this.radGridView1.Rows[l].Cells[2].Value.ToString());
														SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
														DataTable dataTable3 = new DataTable();
														sqlDataAdapter3.Fill(dataTable3);
														bool flag20 = dataTable3.Rows.Count != 0;
														if (flag20)
														{
															num6 = 0;
															string text = this.radGridView1.Rows[l].Cells[0].Value.ToString();
														}
													}
													bool flag21 = num6 == 1;
													if (flag21)
													{
														this.save_brm();
													}
													else
													{
														MessageBox.Show("Erreur : La quantité de l'article " + str + " dans le Bon de retour doit être inférieure ou égale à son quantité dans le BSM", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													}
												}
												else
												{
													this.save_brm();
												}
											}
											else
											{
												MessageBox.Show("Erreur : Vérifier le format du champs quantité dans le tableau, la quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											}
										}
										else
										{
											MessageBox.Show("Erreur : Vérifier le format du champs quantité dans le tableau, la quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										}
									}
									else
									{
										MessageBox.Show("Erreur : L'article " + str + " inexiste dans la BSM", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
								else
								{
									MessageBox.Show("Erreur : Date de bon retour doit être supérieure à la date du BSM", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								MessageBox.Show("Erreur : BSM introuvable dans la Liste des BSM", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							int num7 = 1;
							for (int m = 0; m < this.radGridView1.Rows.Count; m++)
							{
								fonction fonction3 = new fonction();
								bool flag22 = !fonction3.is_reel(this.radGridView1.Rows[m].Cells[2].Value.ToString());
								if (flag22)
								{
									num7 = 0;
								}
							}
							bool flag23 = num7 == 1;
							if (flag23)
							{
								int num8 = 1;
								for (int n = 0; n < this.radGridView1.Rows.Count; n++)
								{
									bool flag24 = Convert.ToDouble(this.radGridView1.Rows[n].Cells[2].Value.ToString()) <= 0.0;
									if (flag24)
									{
										num8 = 0;
									}
								}
								bool flag25 = num8 == 1;
								if (flag25)
								{
									this.save_brm();
								}
								else
								{
									MessageBox.Show("Erreur : Vérifier le format du champs quantité dans le tableau, la quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								MessageBox.Show("Erreur : Vérifier le format du champs quantité dans le tableau, la quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
					}
					else
					{
						MessageBox.Show("Erreur : Le numéro de BSM doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Il faut choisir le champs Retour par", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Il faut choisir au moin un article dans le bon retour magasin", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0009A938 File Offset: 0x00098B38
		private int compare_heure(string l1, string l2)
		{
			int result = 1;
			bool flag = l1.Length == 8 & l2.Length == 8;
			if (flag)
			{
				int num = Convert.ToInt32(fonction.Mid(l1, 1, 2));
				int num2 = Convert.ToInt32(fonction.Mid(l2, 1, 2));
				int num3 = Convert.ToInt32(fonction.Mid(l1, 4, 2));
				int num4 = Convert.ToInt32(fonction.Mid(l2, 4, 2));
				bool flag2 = num2 > num;
				if (flag2)
				{
					result = 2;
				}
				bool flag3 = num2 == num;
				if (flag3)
				{
					bool flag4 = num4 >= num3;
					if (flag4)
					{
						result = 2;
					}
				}
			}
			return result;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0009A9D0 File Offset: 0x00098BD0
		private void save_brm()
		{
			bd bd = new bd();
			bool isChecked = this.radRadioButton1.IsChecked;
			int num;
			if (isChecked)
			{
				num = 1;
			}
			else
			{
				bool isChecked2 = this.radRadioButton2.IsChecked;
				if (isChecked2)
				{
					num = 2;
				}
				else
				{
					bool isChecked3 = this.radRadioButton6.IsChecked;
					if (isChecked3)
					{
						num = 3;
					}
					else
					{
						bool isChecked4 = this.radRadioButton8.IsChecked;
						if (isChecked4)
						{
							num = 4;
						}
						else
						{
							num = 5;
						}
					}
				}
			}
			string text = "";
			bool isChecked5 = this.radRadioButton4.IsChecked;
			if (isChecked5)
			{
				text = "Neuf";
			}
			bool isChecked6 = this.radRadioButton3.IsChecked;
			if (isChecked6)
			{
				text = "Usé";
			}
			bool isChecked7 = this.radRadioButton5.IsChecked;
			if (isChecked7)
			{
				text = "Rebuté";
			}
			bool flag = this.radRadioButton1.IsChecked | this.radRadioButton2.IsChecked | this.radRadioButton7.IsChecked;
			int num2;
			if (flag)
			{
				string cmdText = "insert into brm (type_retour, type_stock, retour_par, date_retour, heure_retour, n_bsm) values (@i1, @i2, @i3, @i4, @i5, @i6)SELECT CAST(scope_identity() AS int)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = num;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = text;
				sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@i4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand.Parameters.Add("@i5", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 8);
				sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = this.TextBox1.Text;
				bd.ouverture_bd(bd.cnn);
				num2 = (int)sqlCommand.ExecuteScalar();
				bd.cnn.Close();
			}
			else
			{
				string cmdText2 = "insert into brm (type_retour, type_stock, retour_par, date_retour, heure_retour) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = text;
				sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				sqlCommand2.Parameters.Add("@i4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 8);
				bd.ouverture_bd(bd.cnn);
				num2 = (int)sqlCommand2.ExecuteScalar();
				bd.cnn.Close();
			}
			for (int i = 0; i < this.radGridView1.Rows.Count; i++)
			{
				string cmdText3 = "insert into brm_article (id_brm, id_article, quantite) values (@i1, @i2, @i3)";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num2;
				sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[2].Value.ToString();
				string cmdText4 = "";
				bool flag2 = text == "Neuf";
				if (flag2)
				{
					cmdText4 = "update article set stock_neuf = stock_neuf + @v where id = @i";
				}
				bool flag3 = text == "Usé";
				if (flag3)
				{
					cmdText4 = "update article set stock_use = stock_use + @v where id = @i";
				}
				bool flag4 = text == "Rebuté";
				if (flag4)
				{
					cmdText4 = "update article set stock_rebute = stock_rebute + @v where id = @i";
				}
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand4.Parameters.Add("@v", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[2].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				sqlCommand3.ExecuteNonQuery();
				sqlCommand4.ExecuteNonQuery();
				bd.cnn.Close();
				string cmdText5 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand5);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string cmdText6 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
				sqlCommand6.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand6.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
				sqlCommand6.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
				sqlCommand6.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
				sqlCommand6.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
				sqlCommand6.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[4]);
				sqlCommand6.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				bd.ouverture_bd(bd.cnn);
				sqlCommand6.ExecuteNonQuery();
				bd.cnn.Close();
				bool flag5 = this.radRadioButton2.IsChecked | this.radRadioButton7.IsChecked;
				if (flag5)
				{
					string cmdText7 = "update bsm_article set quantite = quantite -  @v where id_bsm = @i and id_article = @i1";
					SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
					sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = this.TextBox1.Text;
					sqlCommand7.Parameters.Add("@v", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[2].Value.ToString();
					sqlCommand7.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand7.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
			MessageBox.Show("Enregistrement du Bon de retour avec succés");
			this.TextBox1.Clear();
			this.radGridView1.Rows.Clear();
			this.select_article();
			this.select_intervenant();
		}
	}
}
