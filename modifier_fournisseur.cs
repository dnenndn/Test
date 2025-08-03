using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000148 RID: 328
	public partial class modifier_fournisseur : Form
	{
		// Token: 0x06000E9D RID: 3741 RVA: 0x002363B8 File Offset: 0x002345B8
		public modifier_fournisseur()
		{
			this.InitializeComponent();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList2.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList3.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x00236430 File Offset: 0x00234630
		private void panel5_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 516, 1);
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x0023646C File Offset: 0x0023466C
		private void modifier_fournisseur_Load(object sender, EventArgs e)
		{
			this.pictureBox2.Hide();
			this.p1.Controls.Clear();
			this.p2.Controls.Clear();
			this.p3.Controls.Clear();
			fournisseur_adresse fournisseur_adresse = new fournisseur_adresse();
			fournisseur_adresse.TopLevel = false;
			Fournisseur_contact fournisseur_contact = new Fournisseur_contact();
			fournisseur_contact.TopLevel = false;
			fournisseur_banque fournisseur_banque = new fournisseur_banque();
			fournisseur_banque.TopLevel = false;
			this.p1.Controls.Add(fournisseur_adresse);
			this.p2.Controls.Add(fournisseur_contact);
			this.p3.Controls.Add(fournisseur_banque);
			this.radPanel2.Controls.Add(this.p1);
			this.radPanel2.Controls.Add(this.p2);
			this.radPanel2.Controls.Add(this.p3);
			fournisseur_adresse.Show();
			fournisseur_contact.Show();
			fournisseur_banque.Show();
			this.p2.Visible = false;
			this.p3.Visible = false;
			this.button2.ForeColor = Color.Gray;
			this.button2.BackColor = Color.White;
			this.select_mode_livraison();
			this.select_mode_reglement();
			this.select_type_activite();
			this.select_devise();
			this.select_compte();
			this.get_fournisseur();
			string cmdText = "select adresse from tableau_fournisseur_fichier where id_fournisseur = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = liste_fournisseur.id_modifier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.liste_adresse.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
			this.recherche_fichier();
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x00236694 File Offset: 0x00234894
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Gray;
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.p2.Visible = false;
			this.p3.Visible = false;
			this.p1.Visible = true;
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00236730 File Offset: 0x00234930
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Gray;
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.p1.Visible = false;
			this.p3.Visible = false;
			this.p2.Visible = true;
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x002367CC File Offset: 0x002349CC
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Gray;
			this.button3.BackColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.p1.Visible = false;
			this.p2.Visible = false;
			this.p3.Visible = true;
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x00236868 File Offset: 0x00234A68
		private void select_mode_livraison()
		{
			this.radCheckedDropDownList2.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_livraison_fournisseur where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.VarChar).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList2.Items.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x0023693C File Offset: 0x00234B3C
		private void select_type_activite()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_activite_fournisseur where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.VarChar).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x00236A10 File Offset: 0x00234C10
		private void select_mode_reglement()
		{
			this.radCheckedDropDownList3.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_reglement_fournisseur where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.VarChar).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList3.Items.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x00236AE4 File Offset: 0x00234CE4
		private void select_devise()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_devise_fournisseur where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.VarChar).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x00236BB8 File Offset: 0x00234DB8
		private void select_compte()
		{
			this.radCheckedDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_compte_fournisseur where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.VarChar).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList1.Items.Add(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
				}
			}
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x00236C8C File Offset: 0x00234E8C
		private void get_fournisseur()
		{
			bd bd = new bd();
			string cmdText = "select * from fournisseur where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[1].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[2].ToString();
				bool flag2 = dataTable.Rows[0].ItemArray[3].ToString() == "Fournisseur";
				if (flag2)
				{
					this.radRadioButton1.IsChecked = true;
				}
				else
				{
					this.radRadioButton2.IsChecked = true;
				}
				this.guna2TextBox1.Text = dataTable.Rows[0].ItemArray[4].ToString();
				this.guna2TextBox2.Text = dataTable.Rows[0].ItemArray[5].ToString();
				this.guna2TextBox3.Text = dataTable.Rows[0].ItemArray[6].ToString();
				this.guna2TextBox6.Text = dataTable.Rows[0].ItemArray[7].ToString();
				this.guna2TextBox4.Text = dataTable.Rows[0].ItemArray[8].ToString();
				this.guna2TextBox5.Text = dataTable.Rows[0].ItemArray[9].ToString();
				fournisseur_adresse.radDropDownList1.Text = dataTable.Rows[0].ItemArray[10].ToString();
				fournisseur_adresse.TextBox1.Text = dataTable.Rows[0].ItemArray[11].ToString();
				fournisseur_adresse.TextBox2.Text = dataTable.Rows[0].ItemArray[12].ToString();
				fournisseur_adresse.TextBox3.Text = dataTable.Rows[0].ItemArray[13].ToString();
				Fournisseur_contact.TextBox1.Text = dataTable.Rows[0].ItemArray[14].ToString();
				Fournisseur_contact.TextBox2.Text = dataTable.Rows[0].ItemArray[15].ToString();
				Fournisseur_contact.TextBox3.Text = dataTable.Rows[0].ItemArray[16].ToString();
				Fournisseur_contact.TextBox4.Text = dataTable.Rows[0].ItemArray[17].ToString();
				Fournisseur_contact.TextBox5.Text = dataTable.Rows[0].ItemArray[18].ToString();
				Fournisseur_contact.TextBox6.Text = dataTable.Rows[0].ItemArray[19].ToString();
				fournisseur_banque.TextBox1.Text = dataTable.Rows[0].ItemArray[20].ToString();
				fournisseur_banque.TextBox2.Text = dataTable.Rows[0].ItemArray[21].ToString();
				fournisseur_banque.TextBox3.Text = dataTable.Rows[0].ItemArray[22].ToString();
				fournisseur_banque.TextBox4.Text = dataTable.Rows[0].ItemArray[23].ToString();
				string cmdText2 = "select designation from parametre_activite_fournisseur inner join tableau_fournisseur_activite on parametre_activite_fournisseur.id = tableau_fournisseur_activite.id_activite where tableau_fournisseur_activite.id_fournisseur = @i and parametre_activite_fournisseur.deleted = @d";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag3 = dataTable2.Rows.Count != 0;
				if (flag3)
				{
					this.radDropDownList1.Text = dataTable2.Rows[0].ItemArray[0].ToString();
				}
				string cmdText3 = "select designation from parametre_devise_fournisseur inner join tableau_fournisseur_devise on parametre_devise_fournisseur.id = tableau_fournisseur_devise.id_devise where tableau_fournisseur_devise.id_fournisseur = @i and parametre_devise_fournisseur.deleted = @d";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
				sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				bool flag4 = dataTable3.Rows.Count != 0;
				if (flag4)
				{
					this.radDropDownList6.Text = dataTable3.Rows[0].ItemArray[0].ToString();
				}
				string cmdText4 = "select designation from parametre_compte_fournisseur inner join tableau_fournisseur_compte on parametre_compte_fournisseur.id = tableau_fournisseur_compte.id_compte where tableau_fournisseur_compte.id_fournisseur = @i and parametre_compte_fournisseur.deleted = @d";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
				sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag5 = dataTable4.Rows.Count != 0;
				if (flag5)
				{
					bool flag6 = this.radCheckedDropDownList1.Items.Count != 0;
					if (flag6)
					{
						for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
						{
							int num = this.recherche_data_table(dataTable4, this.radCheckedDropDownList1.Items[i].Text);
							bool flag7 = num == 1;
							if (flag7)
							{
								this.radCheckedDropDownList1.Items[i].Checked = true;
							}
						}
					}
				}
			}
			string cmdText5 = "select designation from parametre_livraison_fournisseur inner join tableau_fournisseur_livraison on parametre_livraison_fournisseur.id = tableau_fournisseur_livraison.id_livraison where tableau_fournisseur_livraison.id_fournisseur = @i and parametre_livraison_fournisseur.deleted = @d";
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
			sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
			sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
			DataTable dataTable5 = new DataTable();
			sqlDataAdapter5.Fill(dataTable5);
			bool flag8 = dataTable5.Rows.Count != 0;
			if (flag8)
			{
				bool flag9 = this.radCheckedDropDownList2.Items.Count != 0;
				if (flag9)
				{
					for (int j = 0; j < this.radCheckedDropDownList2.Items.Count; j++)
					{
						int num2 = this.recherche_data_table(dataTable5, this.radCheckedDropDownList2.Items[j].Text);
						bool flag10 = num2 == 1;
						if (flag10)
						{
							this.radCheckedDropDownList2.Items[j].Checked = true;
						}
					}
				}
			}
			string cmdText6 = "select designation from parametre_reglement_fournisseur inner join tableau_fournisseur_reglement on parametre_reglement_fournisseur.id = tableau_fournisseur_reglement.id_reglement where tableau_fournisseur_reglement.id_fournisseur = @i and parametre_reglement_fournisseur.deleted = @d";
			SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
			sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
			sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
			DataTable dataTable6 = new DataTable();
			sqlDataAdapter6.Fill(dataTable6);
			bool flag11 = dataTable6.Rows.Count != 0;
			if (flag11)
			{
				bool flag12 = this.radCheckedDropDownList3.Items.Count != 0;
				if (flag12)
				{
					for (int k = 0; k < this.radCheckedDropDownList3.Items.Count; k++)
					{
						int num3 = this.recherche_data_table(dataTable6, this.radCheckedDropDownList3.Items[k].Text);
						bool flag13 = num3 == 1;
						if (flag13)
						{
							this.radCheckedDropDownList3.Items[k].Checked = true;
						}
					}
				}
			}
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x002374F0 File Offset: 0x002356F0
		private int recherche_data_table(DataTable table, string s)
		{
			int result = 0;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				bool flag = s == table.Rows[i].ItemArray[0].ToString();
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x0023754C File Offset: 0x0023574C
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(openFileDialog.FileName) != "";
			if (flag)
			{
				this.liste_adresse.Add(openFileDialog.FileName);
			}
			this.recherche_fichier();
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x002375B0 File Offset: 0x002357B0
		private void recherche_fichier()
		{
			fonction fonction = new fonction();
			this.radPanel1.Controls.Clear();
			bool flag = this.liste_adresse.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.liste_adresse.Count; i++)
				{
					PictureBox pictureBox = new PictureBox();
					pictureBox.Size = new Size(48, 30);
					pictureBox.Cursor = Cursors.Hand;
					pictureBox.Location = new Point(5 + 100 * i, 7);
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					string h = Convert.ToString(this.liste_adresse[i]);
					bool flag2 = this.n_fichier(h) == "dwg";
					if (flag2)
					{
						pictureBox.Image = this.imageList1.Images[8];
					}
					else
					{
						bool flag3 = this.n_fichier(h) == "png" | this.n_fichier(h) == "jpeg" | this.n_fichier(h) == "jpg";
						if (flag3)
						{
							pictureBox.Image = this.imageList1.Images[7];
						}
						else
						{
							bool flag4 = this.n_fichier(h) == "xlsx" | this.n_fichier(h) == "xls";
							if (flag4)
							{
								pictureBox.Image = this.imageList1.Images[3];
							}
							else
							{
								bool flag5 = this.n_fichier(h) == "pdf";
								if (flag5)
								{
									pictureBox.Image = this.imageList1.Images[4];
								}
								else
								{
									bool flag6 = this.n_fichier(h) == "txt";
									if (flag6)
									{
										pictureBox.Image = this.imageList1.Images[5];
									}
									else
									{
										bool flag7 = this.n_fichier(h) == "docx";
										if (flag7)
										{
											pictureBox.Image = this.imageList1.Images[2];
										}
										else
										{
											bool flag8 = this.n_fichier(h) == "rar" | this.n_fichier(h) == "zip";
											if (flag8)
											{
												pictureBox.Image = this.imageList1.Images[6];
											}
											else
											{
												pictureBox.Image = this.imageList1.Images[9];
											}
										}
									}
								}
							}
						}
					}
					PictureBox pictureBox2 = new PictureBox();
					pictureBox2.Size = new Size(15, 15);
					pictureBox2.Cursor = Cursors.Hand;
					pictureBox2.Location = new Point(56 + 100 * i, 7);
					pictureBox2.Image = this.pictureBox2.Image;
					pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
					pictureBox2.Click += delegate(object s, EventArgs e)
					{
						this.supprimer_file(h);
					};
					this.radPanel1.Controls.Add(pictureBox);
					this.radPanel1.Controls.Add(pictureBox2);
					Label label = new Label();
					label.AutoSize = true;
					label.BackColor = Color.Transparent;
					label.ForeColor = Color.Black;
					label.Location = new Point(5 + 100 * i, 45);
					label.Cursor = Cursors.Default;
					label.Text = this.nom_fichier(h);
					this.radPanel1.Controls.Add(label);
				}
			}
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00237990 File Offset: 0x00235B90
		public string n_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == ".";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x002379F0 File Offset: 0x00235BF0
		public string nom_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == "\\";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00237A50 File Offset: 0x00235C50
		private void supprimer_file(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				this.liste_adresse.Remove(x);
				this.recherche_fichier();
			}
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00237A90 File Offset: 0x00235C90
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.radDropDownList6.Text) != "" & this.controle_compte() == 1;
			if (flag)
			{
				bool flag2 = this.controle_nombre(this.guna2TextBox3.Text) == 1 & this.controle_nombre(this.guna2TextBox4.Text) == 1 & this.controle_nombre(this.guna2TextBox5.Text) == 1 & this.controle_nombre(this.guna2TextBox6.Text) == 1;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select id from fournisseur where (code_fournisseur = @a1 or nom = @a2) and deleted = @d and id <> @o";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@a1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand.Parameters.Add("@a2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand.Parameters.Add("@o", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						string value = "Fournisseur";
						bool isChecked = this.radRadioButton2.IsChecked;
						if (isChecked)
						{
							value = "Sous_Traitant";
						}
						string cmdText2 = "update fournisseur set code_fournisseur = @i1, nom = @i2, type = @i3, activite = @i4, commentaire = @i5, tva_defaut = @i6, delai = @i7, remise_defaut = @i8, pays = @i9, ville = @i10, code_postal = @i11, adresse = @i12, telephone_1 = @i13, telephone_2 = @i14, fax_1 = @i15, fax_2 = @i16, email = @i17, site_web = @i18, nom_banque = @i19, domiciliation = @i20, iban = @i21, rib = @i22, fodec = @i24 where id = @i23";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = value;
						sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.guna2TextBox2.Text;
						sqlCommand2.Parameters.Add("@i6", SqlDbType.Real).Value = this.conversiontoreal(this.guna2TextBox3.Text);
						sqlCommand2.Parameters.Add("@i7", SqlDbType.Real).Value = this.conversiontoreal(this.guna2TextBox4.Text);
						sqlCommand2.Parameters.Add("@i8", SqlDbType.Real).Value = this.conversiontoreal(this.guna2TextBox5.Text);
						sqlCommand2.Parameters.Add("@i9", SqlDbType.VarChar).Value = fournisseur_adresse.radDropDownList1.Text;
						sqlCommand2.Parameters.Add("@i10", SqlDbType.VarChar).Value = fournisseur_adresse.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i11", SqlDbType.VarChar).Value = fournisseur_adresse.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i12", SqlDbType.VarChar).Value = fournisseur_adresse.TextBox3.Text;
						sqlCommand2.Parameters.Add("@i13", SqlDbType.VarChar).Value = Fournisseur_contact.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i14", SqlDbType.VarChar).Value = Fournisseur_contact.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i15", SqlDbType.VarChar).Value = Fournisseur_contact.TextBox3.Text;
						sqlCommand2.Parameters.Add("@i16", SqlDbType.VarChar).Value = Fournisseur_contact.TextBox4.Text;
						sqlCommand2.Parameters.Add("@i17", SqlDbType.VarChar).Value = Fournisseur_contact.TextBox5.Text;
						sqlCommand2.Parameters.Add("@i18", SqlDbType.VarChar).Value = Fournisseur_contact.TextBox6.Text;
						sqlCommand2.Parameters.Add("@i19", SqlDbType.VarChar).Value = fournisseur_banque.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i20", SqlDbType.VarChar).Value = fournisseur_banque.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i21", SqlDbType.VarChar).Value = fournisseur_banque.TextBox3.Text;
						sqlCommand2.Parameters.Add("@i22", SqlDbType.VarChar).Value = fournisseur_banque.TextBox4.Text;
						sqlCommand2.Parameters.Add("@i24", SqlDbType.VarChar).Value = this.conversiontoreal(this.guna2TextBox6.Text);
						sqlCommand2.Parameters.Add("@i23", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						this.save_activite(liste_fournisseur.id_modifier);
						this.save_compte();
						this.save_devise(liste_fournisseur.id_modifier);
						this.save_livraison();
						this.save_reglement();
						this.save_fichier();
						MessageBox.Show("Le Fournisseur est modifié avec succés");
						Form1.Panel2.Controls.Clear();
						liste_fournisseur liste_fournisseur = new liste_fournisseur();
						liste_fournisseur.TopLevel = false;
						Form1.Panel2.Controls.Add(liste_fournisseur);
						liste_fournisseur.Show();
					}
					else
					{
						MessageBox.Show("Erreur : Le Fournisseur déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : TVA, Remise et délai sont des réels ou vides", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x002380C0 File Offset: 0x002362C0
		private int controle_nombre(string l)
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(l) == "" | fonction.is_reel(l);
			if (flag)
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x002380FC File Offset: 0x002362FC
		private double conversiontoreal(string s)
		{
			double result = 0.0;
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(s);
			if (flag)
			{
				result = Convert.ToDouble(s);
			}
			return result;
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00238134 File Offset: 0x00236334
		private int controle_compte()
		{
			int result = 0;
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
					if (@checked)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x002381A8 File Offset: 0x002363A8
		private void save_activite(string id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_activite_fournisseur where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select id from tableau_fournisseur_activite where id_fournisseur = @h";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = id;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						string cmdText3 = "update tableau_fournisseur_activite set id_activite = @i2 where id_fournisseur = @i1";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
					else
					{
						string cmdText4 = "insert into tableau_fournisseur_activite (id_fournisseur, id_activite) values (@i1, @i2)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x002383D0 File Offset: 0x002365D0
		private void save_devise(string id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList6.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_devise_fournisseur where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "update tableau_fournisseur_devise set id_devise = @i2 where id_fournisseur = @i1";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00238514 File Offset: 0x00236714
		private void save_fichier()
		{
			bd bd = new bd();
			bool flag = this.liste_adresse.Count != 0;
			if (flag)
			{
				string cmdText = "select adresse, id from tableau_fournisseur_fichier where id_fournisseur = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < this.liste_adresse.Count; i++)
				{
					bool flag2 = this.recherche_data_table(dataTable, this.liste_adresse[i].ToString()) == 0;
					if (flag2)
					{
						string cmdText2 = "insert into tableau_fournisseur_fichier (id_fournisseur, adresse) values (@i1, @i2)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.liste_adresse[i];
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
				bool flag3 = dataTable.Rows.Count != 0;
				if (flag3)
				{
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						bool flag4 = this.recherche_dt_in_liste(this.liste_adresse, dataTable.Rows[j].ItemArray[0].ToString()) == 0;
						if (flag4)
						{
							string cmdText3 = "delete tableau_fournisseur_fichier where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[j].ItemArray[1];
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00238728 File Offset: 0x00236928
		private void save_compte()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_compte_fournisseur inner join tableau_fournisseur_compte on parametre_compte_fournisseur.id = tableau_fournisseur_compte.id_compte where tableau_fournisseur_compte.id_fournisseur = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool flag2 = this.radCheckedDropDownList1.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList1.Items[i].Text) == 0;
					if (flag2)
					{
						string cmdText2 = "select id from parametre_compte_fournisseur where designation = @v and deleted = @d";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							string cmdText3 = "insert into tableau_fournisseur_compte (id_fournisseur, id_compte) values (@i1, @i2)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable2.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					bool flag4 = !this.radCheckedDropDownList1.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList1.Items[i].Text) == 1;
					if (flag4)
					{
						string cmdText4 = "select id from parametre_compte_fournisseur where designation = @v and deleted = @d";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag5 = dataTable3.Rows.Count != 0;
						if (flag5)
						{
							string cmdText5 = "delete tableau_fournisseur_compte where id_fournisseur = @i1 and id_compte = @i2";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
							sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00238A94 File Offset: 0x00236C94
		private void save_livraison()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_livraison_fournisseur inner join tableau_fournisseur_livraison on parametre_livraison_fournisseur.id = tableau_fournisseur_livraison.id_livraison where tableau_fournisseur_livraison.id_fournisseur = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = this.radCheckedDropDownList2.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList2.Items.Count; i++)
				{
					bool flag2 = this.radCheckedDropDownList2.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList2.Items[i].Text) == 0;
					if (flag2)
					{
						string cmdText2 = "select id from parametre_livraison_fournisseur where designation = @v and deleted = @d";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList2.Items[i].Text;
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							string cmdText3 = "insert into tableau_fournisseur_livraison (id_fournisseur, id_livraison) values (@i1, @i2)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable2.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					bool flag4 = !this.radCheckedDropDownList2.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList2.Items[i].Text) == 1;
					if (flag4)
					{
						string cmdText4 = "select id from parametre_livraison_fournisseur where designation = @v and deleted = @d";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList2.Items[i].Text;
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag5 = dataTable3.Rows.Count != 0;
						if (flag5)
						{
							string cmdText5 = "delete tableau_fournisseur_livraison where id_fournisseur = @i1 and id_livraison = @i2";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
							sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00238E00 File Offset: 0x00237000
		private void save_reglement()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_reglement_fournisseur inner join tableau_fournisseur_reglement on parametre_reglement_fournisseur.id = tableau_fournisseur_reglement.id_reglement where tableau_fournisseur_reglement.id_fournisseur = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = this.radCheckedDropDownList3.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList3.Items.Count; i++)
				{
					bool flag2 = this.radCheckedDropDownList3.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList3.Items[i].Text) == 0;
					if (flag2)
					{
						string cmdText2 = "select id from parametre_reglement_fournisseur where designation = @v and deleted = @d";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList3.Items[i].Text;
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							string cmdText3 = "insert into tableau_fournisseur_reglement (id_fournisseur, id_reglement) values (@i1, @i2)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable2.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					bool flag4 = !this.radCheckedDropDownList3.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList3.Items[i].Text) == 1;
					if (flag4)
					{
						string cmdText4 = "select id from parametre_reglement_fournisseur where designation = @v and deleted = @d";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag5 = dataTable3.Rows.Count != 0;
						if (flag5)
						{
							string cmdText5 = "delete tableau_fournisseur_reglement where id_fournisseur = @i1 and id_reglement = @i2";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = liste_fournisseur.id_modifier;
							sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0023916C File Offset: 0x0023736C
		private int recherche_dt_in_liste(List<string> l, string s)
		{
			int result = 0;
			for (int i = 0; i < l.Count; i++)
			{
				bool flag = s == l[i].ToString();
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x0400125C RID: 4700
		private List<string> liste_adresse = new List<string>();
	}
}
