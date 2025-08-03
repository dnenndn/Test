using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200001F RID: 31
	public partial class article_caracteristique : Form
	{
		// Token: 0x060001B2 RID: 434 RVA: 0x00049245 File Offset: 0x00047445
		public article_caracteristique()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00049260 File Offset: 0x00047460
		private void article_caracteristique_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Méthode";
			if (flag)
			{
				this.guna2Button1.Visible = false;
			}
			bd bd = new bd();
			string cmdText = "select id_sous_famille from tableau_article_sous_famille where id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				article_caracteristique.select_caracteristique(dataTable.Rows[0].ItemArray[0].ToString());
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00049314 File Offset: 0x00047514
		public static void select_caracteristique(string id)
		{
			article_caracteristique.radPanel1.Controls.Clear();
			bd bd = new bd();
			string cmdText = "select * from caracteristique where id_sous_famille = @i and deleted =@d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Label label = new Label();
					label.AutoSize = true;
					label.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
					label.ForeColor = Color.Blue;
					label.Text = dataTable.Rows[i].ItemArray[2].ToString();
					label.Location = new Point(13, 12 + 62 * i);
					article_caracteristique.radPanel1.Controls.Add(label);
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[4]) == 1;
					if (flag2)
					{
						Label label2 = new Label();
						label2.AutoSize = true;
						label2.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						label2.ForeColor = Color.Red;
						label2.Text = "*";
						label2.Location = new Point(11 + label.Size.Width, 12 + 62 * i);
						article_caracteristique.radPanel1.Controls.Add(label2);
					}
					bool flag3 = dataTable.Rows[i].ItemArray[3].ToString() == "TextBox";
					if (flag3)
					{
						Guna2TextBox guna2TextBox = new Guna2TextBox();
						guna2TextBox.BorderRadius = 2;
						guna2TextBox.Cursor = Cursors.IBeam;
						guna2TextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
						guna2TextBox.ForeColor = Color.FromArgb(138, 138, 138);
						guna2TextBox.BorderColor = Color.FromArgb(94, 148, 255);
						guna2TextBox.Font = new Font("Calibri", 9f);
						guna2TextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
						guna2TextBox.Location = new Point(17, 34 + 62 * i);
						guna2TextBox.PasswordChar = '\0';
						guna2TextBox.SelectedText = "";
						guna2TextBox.Size = new Size(318, 29);
						guna2TextBox.BackColor = Color.White;
						string cmdText2 = "select valeur from tableau_article_caracteristique where id_caracteristique = @i and id_article = @j";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						sqlCommand2.Parameters.Add("@j", SqlDbType.Int).Value = liste_article.id_article;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							guna2TextBox.Text = dataTable2.Rows[0].ItemArray[0].ToString();
						}
						article_caracteristique.radPanel1.Controls.Add(guna2TextBox);
					}
					bool flag5 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Unique";
					if (flag5)
					{
						Guna2ComboBox guna2ComboBox = new Guna2ComboBox();
						guna2ComboBox.BackColor = Color.Transparent;
						guna2ComboBox.BorderRadius = 2;
						guna2ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
						guna2ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
						guna2ComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
						guna2ComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
						guna2ComboBox.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						guna2ComboBox.ForeColor = Color.FromArgb(125, 137, 149);
						guna2ComboBox.ItemHeight = 24;
						guna2ComboBox.Location = new Point(17, 34 + 62 * i);
						guna2ComboBox.Size = new Size(318, 30);
						article_caracteristique.radPanel1.Controls.Add(guna2ComboBox);
						string cmdText3 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							guna2ComboBox.Controls.Clear();
							for (int j = 0; j < dataTable3.Rows.Count; j++)
							{
								guna2ComboBox.Items.Add(Convert.ToString(dataTable3.Rows[j].ItemArray[0]));
							}
							string cmdText4 = "select valeur from tableau_article_caracteristique where id_caracteristique = @i and id_article = @j";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand4.Parameters.Add("@j", SqlDbType.Int).Value = liste_article.id_article;
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							bool flag7 = dataTable4.Rows.Count != 0;
							if (flag7)
							{
								guna2ComboBox.Text = dataTable4.Rows[0].ItemArray[0].ToString();
							}
						}
					}
					bool flag8 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Multiple";
					if (flag8)
					{
						RadCheckedDropDownList radCheckedDropDownList = new RadCheckedDropDownList();
						radCheckedDropDownList.Location = new Point(17, 34 + 62 * i);
						radCheckedDropDownList.Size = new Size(318, 30);
						radCheckedDropDownList.ThemeName = "Crystal";
						article_caracteristique.radPanel1.Controls.Add(radCheckedDropDownList);
						string cmdText5 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag9 = dataTable5.Rows.Count != 0;
						if (flag9)
						{
							radCheckedDropDownList.Controls.Clear();
							for (int k = 0; k < dataTable5.Rows.Count; k++)
							{
								radCheckedDropDownList.Items.Add(Convert.ToString(dataTable5.Rows[k].ItemArray[0]));
							}
							string cmdText6 = "select valeur from tableau_article_caracteristique where id_caracteristique = @i and id_article = @j";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand6.Parameters.Add("@j", SqlDbType.Int).Value = liste_article.id_article;
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
							DataTable dataTable6 = new DataTable();
							sqlDataAdapter6.Fill(dataTable6);
							bool flag10 = dataTable6.Rows.Count != 0;
							if (flag10)
							{
								for (int l = 0; l < radCheckedDropDownList.Items.Count; l++)
								{
									for (int m = 0; m < dataTable6.Rows.Count; m++)
									{
										bool flag11 = radCheckedDropDownList.Items[l].ToString() == dataTable6.Rows[m].ItemArray[0].ToString();
										if (flag11)
										{
											radCheckedDropDownList.Items[l].Checked = true;
										}
									}
								}
							}
						}
					}
					bool flag12 = dataTable.Rows[i].ItemArray[3].ToString() == "CheckBox";
					if (flag12)
					{
						string cmdText7 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
						DataTable dataTable7 = new DataTable();
						sqlDataAdapter7.Fill(dataTable7);
						bool flag13 = dataTable7.Rows.Count != 0;
						if (flag13)
						{
							int num = 17;
							for (int n = 0; n < dataTable7.Rows.Count; n++)
							{
								RadCheckBox radCheckBox = new RadCheckBox();
								radCheckBox.CheckAlignment = ContentAlignment.MiddleRight;
								radCheckBox.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
								radCheckBox.Location = new Point(num, 34 + 62 * i);
								radCheckBox.Text = Convert.ToString(dataTable7.Rows[n].ItemArray[0]);
								radCheckBox.ThemeName = "Crystal";
								radCheckBox.AutoSize = true;
								int num2 = 0;
								for (int num3 = 1; num3 <= radCheckBox.Text.Length; num3++)
								{
									bool flag14 = fonction.Mid(radCheckBox.Text, num3, 1) == fonction.Mid(radCheckBox.Text, num3, 1).ToUpper();
									if (flag14)
									{
										num2++;
									}
								}
								num = num + 42 + radCheckBox.Text.Length * 6 + num2 * 2;
								article_caracteristique.radPanel1.Controls.Add(radCheckBox);
								string cmdText8 = "select valeur from tableau_article_caracteristique where id_caracteristique = @i and id_article = @j";
								SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
								sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
								sqlCommand8.Parameters.Add("@j", SqlDbType.Int).Value = liste_article.id_article;
								SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
								DataTable dataTable8 = new DataTable();
								sqlDataAdapter8.Fill(dataTable8);
								bool flag15 = dataTable8.Rows.Count != 0;
								if (flag15)
								{
									for (int num4 = 0; num4 < dataTable8.Rows.Count; num4++)
									{
										bool flag16 = dataTable8.Rows[num4].ItemArray[0].ToString() == radCheckBox.Text;
										if (flag16)
										{
											radCheckBox.Checked = true;
										}
									}
								}
							}
						}
					}
					bool flag17 = dataTable.Rows[i].ItemArray[3].ToString() == "Radio Button";
					if (flag17)
					{
						FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
						flowLayoutPanel.AutoScroll = true;
						flowLayoutPanel.Location = new Point(17, 34 + 62 * i);
						flowLayoutPanel.Size = new Size(1086, 40);
						string cmdText9 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
						sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(sqlCommand9);
						DataTable dataTable9 = new DataTable();
						sqlDataAdapter9.Fill(dataTable9);
						bool flag18 = dataTable9.Rows.Count != 0;
						if (flag18)
						{
							int num5 = 17;
							for (int num6 = 0; num6 < dataTable9.Rows.Count; num6++)
							{
								RadRadioButton radRadioButton = new RadRadioButton();
								radRadioButton.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
								radRadioButton.Location = new Point(num5, 34 + 62 * i);
								radRadioButton.Text = Convert.ToString(dataTable9.Rows[num6].ItemArray[0]);
								radRadioButton.ThemeName = "Crystal";
								radRadioButton.AutoSize = true;
								int num7 = 0;
								for (int num8 = 1; num8 <= radRadioButton.Text.Length; num8++)
								{
									bool flag19 = fonction.Mid(radRadioButton.Text, num8, 1) == fonction.Mid(radRadioButton.Text, num8, 1).ToUpper();
									if (flag19)
									{
										num7++;
									}
								}
								num5 = num5 + 42 + radRadioButton.Text.Length * 6 + num7 * 2;
								flowLayoutPanel.Controls.Add(radRadioButton);
								string cmdText10 = "select valeur from tableau_article_caracteristique where id_caracteristique = @i and id_article = @j";
								SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd.cnn);
								sqlCommand10.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
								sqlCommand10.Parameters.Add("@j", SqlDbType.Int).Value = liste_article.id_article;
								SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(sqlCommand10);
								DataTable dataTable10 = new DataTable();
								sqlDataAdapter10.Fill(dataTable10);
								bool flag20 = dataTable10.Rows.Count != 0;
								if (flag20)
								{
									for (int num9 = 0; num9 < dataTable10.Rows.Count; num9++)
									{
										bool flag21 = dataTable10.Rows[num9].ItemArray[0].ToString() == radRadioButton.Text;
										if (flag21)
										{
											radRadioButton.IsChecked = true;
										}
									}
								}
							}
							article_caracteristique.radPanel1.Controls.Add(flowLayoutPanel);
						}
					}
					Label label3 = new Label();
					label3.Text = "";
					label3.Location = new Point(13, 12 + 62 * dataTable.Rows.Count);
					article_caracteristique.radPanel1.Controls.Add(label3);
				}
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0004A234 File Offset: 0x00048434
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			modifier_caracteristique_article modifier_caracteristique_article = new modifier_caracteristique_article();
			modifier_caracteristique_article.Show();
		}
	}
}
