using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000099 RID: 153
	public partial class modifier_caracteristique_article : Form
	{
		// Token: 0x060006F8 RID: 1784 RVA: 0x00130CA3 File Offset: 0x0012EEA3
		public modifier_caracteristique_article()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00130CD4 File Offset: 0x0012EED4
		private void modifier_caracteristique_article_Load(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select id_sous_famille from tableau_article_sous_famille where id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.id_art = liste_article.id_article;
			this.id_sous_famille = dataTable.Rows[0].ItemArray[0].ToString();
			this.select_caracteristique(this.id_sous_famille);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00130D68 File Offset: 0x0012EF68
		private void select_caracteristique(string id)
		{
			this.radPanel1.Controls.Clear();
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
					label.ForeColor = Color.Black;
					label.Text = dataTable.Rows[i].ItemArray[2].ToString();
					label.Location = new Point(13, 12 + 62 * i);
					this.radPanel1.Controls.Add(label);
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[4]) == 1;
					if (flag2)
					{
						Label label2 = new Label();
						label2.AutoSize = true;
						label2.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						label2.ForeColor = Color.Red;
						label2.Text = "*";
						label2.Location = new Point(11 + label.Size.Width, 12 + 62 * i);
						this.radPanel1.Controls.Add(label2);
					}
					bool flag3 = dataTable.Rows[i].ItemArray[3].ToString() == "TextBox";
					if (flag3)
					{
						RadTextBox radTextBox = new RadTextBox();
						radTextBox.ThemeName = "Crystal";
						radTextBox.Name = "t";
						radTextBox.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						radTextBox.Cursor = Cursors.IBeam;
						radTextBox.ForeColor = Color.FromArgb(138, 138, 138);
						radTextBox.Font = new Font("Calibri", 9f);
						radTextBox.Location = new Point(17, 34 + 62 * i);
						radTextBox.PasswordChar = '\0';
						radTextBox.SelectedText = "";
						radTextBox.Size = new Size(318, 29);
						radTextBox.BackColor = Color.White;
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
							radTextBox.Text = dataTable2.Rows[0].ItemArray[0].ToString();
						}
						this.radPanel1.Controls.Add(radTextBox);
					}
					bool flag5 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Unique";
					if (flag5)
					{
						Guna2ComboBox guna2ComboBox = new Guna2ComboBox();
						guna2ComboBox.BackColor = Color.Transparent;
						guna2ComboBox.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						guna2ComboBox.Name = "su";
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
						this.radPanel1.Controls.Add(guna2ComboBox);
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
						radCheckedDropDownList.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						radCheckedDropDownList.Name = "sm";
						radCheckedDropDownList.ThemeName = "Crystal";
						this.radPanel1.Controls.Add(radCheckedDropDownList);
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
							FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
							flowLayoutPanel.AutoScroll = true;
							flowLayoutPanel.Location = new Point(17, 34 + 62 * i);
							flowLayoutPanel.Size = new Size(1086, 40);
							flowLayoutPanel.Tag = dataTable.Rows[i].ItemArray[0].ToString();
							flowLayoutPanel.Name = "p1";
							for (int n = 0; n < dataTable7.Rows.Count; n++)
							{
								RadCheckBox radCheckBox = new RadCheckBox();
								radCheckBox.Name = "cb";
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
								flowLayoutPanel.Controls.Add(radCheckBox);
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
							this.radPanel1.Controls.Add(flowLayoutPanel);
						}
					}
					bool flag17 = dataTable.Rows[i].ItemArray[3].ToString() == "Radio Button";
					if (flag17)
					{
						FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
						flowLayoutPanel2.AutoScroll = true;
						flowLayoutPanel2.Location = new Point(17, 34 + 62 * i);
						flowLayoutPanel2.Size = new Size(1086, 40);
						flowLayoutPanel2.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						flowLayoutPanel2.Name = "p2";
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
								radRadioButton.Name = "rb";
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
								flowLayoutPanel2.Controls.Add(radRadioButton);
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
							this.radPanel1.Controls.Add(flowLayoutPanel2);
						}
					}
					Label label3 = new Label();
					label3.Text = "";
					label3.Location = new Point(13, 12 + 62 * dataTable.Rows.Count);
					this.radPanel1.Controls.Add(label3);
				}
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00131D8C File Offset: 0x0012FF8C
		private void save_caracteristique(int id)
		{
			bd bd = new bd();
			foreach (object obj in this.radPanel1.Controls)
			{
				Control control = (Control)obj;
				bool flag = control.Name == "t" | control.Name == "su" | control.Name == "sm" | control.Name == "p1" | control.Name == "p2";
				if (flag)
				{
					bool flag2 = control.Name == "t";
					if (flag2)
					{
						string cmdText = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
						sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = control.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
					}
					bool flag3 = control.Name == "su";
					if (flag3)
					{
						string cmdText2 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = control.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
					}
					bool flag4 = control.Name == "sm";
					if (flag4)
					{
						bool flag5 = control is RadCheckedDropDownList;
						if (flag5)
						{
							RadCheckedDropDownList radCheckedDropDownList = (RadCheckedDropDownList)control;
							bool flag6 = radCheckedDropDownList.Items.Count != 0;
							if (flag6)
							{
								for (int i = 0; i < radCheckedDropDownList.Items.Count; i++)
								{
									bool @checked = radCheckedDropDownList.Items[i].Checked;
									if (@checked)
									{
										string cmdText3 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
										SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
										sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
										sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
										sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = radCheckedDropDownList.Items[i].Text;
										bd.ouverture_bd(bd.cnn);
										sqlCommand3.ExecuteNonQuery();
										bd.cnn.Close();
									}
								}
							}
						}
					}
					bool flag7 = control.Name == "p1";
					if (flag7)
					{
						foreach (object obj2 in control.Controls)
						{
							Control control2 = (Control)obj2;
							bool flag8 = control2.Name == "cb";
							if (flag8)
							{
								RadCheckBox radCheckBox = (RadCheckBox)control2;
								bool checked2 = radCheckBox.Checked;
								if (checked2)
								{
									string cmdText4 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
									SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
									sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
									sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
									sqlCommand4.Parameters.Add("@i3", SqlDbType.VarChar).Value = radCheckBox.Text;
									bd.ouverture_bd(bd.cnn);
									sqlCommand4.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
						}
					}
					bool flag9 = control.Name == "p2";
					if (flag9)
					{
						foreach (object obj3 in control.Controls)
						{
							Control control3 = (Control)obj3;
							bool flag10 = control3.Name == "rb";
							if (flag10)
							{
								RadRadioButton radRadioButton = (RadRadioButton)control3;
								bool isChecked = radRadioButton.IsChecked;
								if (isChecked)
								{
									string cmdText5 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
									SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
									sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = id;
									sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
									sqlCommand5.Parameters.Add("@i3", SqlDbType.VarChar).Value = radRadioButton.Text;
									bd.ouverture_bd(bd.cnn);
									sqlCommand5.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0013237C File Offset: 0x0013057C
		private int test_validite_caracteristique()
		{
			int result = 1;
			foreach (object obj in this.radPanel1.Controls)
			{
				Control control = (Control)obj;
				bool flag = control.Name == "t" | control.Name == "su" | control.Name == "sm" | control.Name == "p1" | control.Name == "p2";
				if (flag)
				{
					string value = Convert.ToString(control.Tag);
					bd bd = new bd();
					fonction fonction = new fonction();
					bool flag2 = control.Name == "t";
					if (flag2)
					{
						string cmdText = "select champ_obligatoire, caracteristique_textbox.type from caracteristique inner join caracteristique_textbox on caracteristique.id = caracteristique_textbox.id_caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							bool flag4 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 1;
							if (flag4)
							{
								bool flag5 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Entier";
								if (flag5)
								{
									bool flag6 = !fonction.isnumeric(control.Text);
									if (flag6)
									{
										result = 0;
									}
								}
								bool flag7 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Réel";
								if (flag7)
								{
									bool flag8 = !fonction.is_reel(control.Text);
									if (flag8)
									{
										result = 0;
									}
								}
								bool flag9 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Chaîne de caractères";
								if (flag9)
								{
									bool flag10 = fonction.DeleteSpace(control.Text) == "";
									if (flag10)
									{
										result = 0;
									}
								}
							}
							bool flag11 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 0;
							if (flag11)
							{
								bool flag12 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Entier" & fonction.DeleteSpace(control.Text) != "";
								if (flag12)
								{
									bool flag13 = !fonction.isnumeric(control.Text);
									if (flag13)
									{
										result = 0;
									}
								}
								bool flag14 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Réel" & fonction.DeleteSpace(control.Text) != "";
								if (flag14)
								{
									bool flag15 = !fonction.is_reel(control.Text);
									if (flag15)
									{
										result = 0;
									}
								}
							}
						}
					}
					bool flag16 = control.Name == "su";
					if (flag16)
					{
						string cmdText2 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag17 = dataTable2.Rows.Count != 0;
						if (flag17)
						{
							bool flag18 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]) == 1 & fonction.DeleteSpace(control.Text) == "";
							if (flag18)
							{
								result = 0;
							}
						}
					}
					bool flag19 = control.Name == "sm";
					if (flag19)
					{
						string cmdText3 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag20 = dataTable3.Rows.Count != 0;
						if (flag20)
						{
							bool flag21 = control is RadCheckedDropDownList;
							if (flag21)
							{
								RadCheckedDropDownList radCheckedDropDownList = (RadCheckedDropDownList)control;
								int num = 0;
								bool flag22 = radCheckedDropDownList.Items.Count != 0;
								if (flag22)
								{
									for (int i = 0; i < radCheckedDropDownList.Items.Count; i++)
									{
										bool @checked = radCheckedDropDownList.Items[i].Checked;
										if (@checked)
										{
											num = 1;
										}
									}
									bool flag23 = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0]) == 1 & num == 0;
									if (flag23)
									{
										result = 0;
									}
								}
							}
						}
					}
					bool flag24 = control.Name == "p1";
					if (flag24)
					{
						string cmdText4 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag25 = dataTable4.Rows.Count != 0;
						if (flag25)
						{
							bool flag26 = Convert.ToInt32(dataTable4.Rows[0].ItemArray[0]) == 1;
							if (flag26)
							{
								int num2 = 0;
								foreach (object obj2 in control.Controls)
								{
									Control control2 = (Control)obj2;
									bool flag27 = control2.Name == "cb";
									if (flag27)
									{
										RadCheckBox radCheckBox = (RadCheckBox)control2;
										bool checked2 = radCheckBox.Checked;
										if (checked2)
										{
											num2 = 1;
										}
									}
								}
								bool flag28 = num2 == 0;
								if (flag28)
								{
									result = 0;
								}
							}
						}
					}
					bool flag29 = control.Name == "p2";
					if (flag29)
					{
						string cmdText5 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag30 = dataTable5.Rows.Count != 0;
						if (flag30)
						{
							bool flag31 = Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]) == 1;
							if (flag31)
							{
								int num3 = 0;
								foreach (object obj3 in control.Controls)
								{
									Control control3 = (Control)obj3;
									bool flag32 = control3.Name == "rb";
									if (flag32)
									{
										RadRadioButton radRadioButton = (RadRadioButton)control3;
										bool isChecked = radRadioButton.IsChecked;
										if (isChecked)
										{
											num3 = 1;
										}
									}
								}
								bool flag33 = num3 == 0;
								if (flag33)
								{
									result = 0;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00132B38 File Offset: 0x00130D38
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "delete tableau_article_caracteristique where id_article = @i1";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.id_art;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			this.save_caracteristique(Convert.ToInt32(this.id_art));
			MessageBox.Show("Modification avec succés");
			article_caracteristique.select_caracteristique(this.id_sous_famille);
			base.Close();
		}

		// Token: 0x04000970 RID: 2416
		private string id_art = "";

		// Token: 0x04000971 RID: 2417
		private string id_sous_famille = "";
	}
}
