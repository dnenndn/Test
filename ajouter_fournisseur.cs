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
	// Token: 0x02000011 RID: 17
	public partial class ajouter_fournisseur : Form
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x00029CD4 File Offset: 0x00027ED4
		public ajouter_fournisseur()
		{
			this.InitializeComponent();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList2.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList3.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00029D4C File Offset: 0x00027F4C
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00029D88 File Offset: 0x00027F88
		private void ajouter_fournisseur_Load(object sender, EventArgs e)
		{
			this.pictureBox2.Hide();
			menu_fournisseur menu_fournisseur = new menu_fournisseur();
			menu_fournisseur.TopLevel = false;
			menu_fournisseur.button1.BackColor = Color.White;
			menu_fournisseur.button1.ForeColor = Color.Firebrick;
			menu_fournisseur.button2.BackColor = Color.Firebrick;
			menu_fournisseur.button2.ForeColor = Color.White;
			menu_fournisseur.button3.BackColor = Color.Firebrick;
			menu_fournisseur.button3.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_fournisseur);
			menu_fournisseur.Show();
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
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00029F8C File Offset: 0x0002818C
		private void panel5_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 516, 1);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00029FC8 File Offset: 0x000281C8
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

		// Token: 0x060000EB RID: 235 RVA: 0x0002A064 File Offset: 0x00028264
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

		// Token: 0x060000EC RID: 236 RVA: 0x0002A100 File Offset: 0x00028300
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

		// Token: 0x060000ED RID: 237 RVA: 0x0002A19C File Offset: 0x0002839C
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

		// Token: 0x060000EE RID: 238 RVA: 0x0002A270 File Offset: 0x00028470
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

		// Token: 0x060000EF RID: 239 RVA: 0x0002A344 File Offset: 0x00028544
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

		// Token: 0x060000F0 RID: 240 RVA: 0x0002A418 File Offset: 0x00028618
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

		// Token: 0x060000F1 RID: 241 RVA: 0x0002A4EC File Offset: 0x000286EC
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

		// Token: 0x060000F2 RID: 242 RVA: 0x0002A5C0 File Offset: 0x000287C0
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

		// Token: 0x060000F3 RID: 243 RVA: 0x0002A624 File Offset: 0x00028824
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

		// Token: 0x060000F4 RID: 244 RVA: 0x0002AA04 File Offset: 0x00028C04
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

		// Token: 0x060000F5 RID: 245 RVA: 0x0002AA64 File Offset: 0x00028C64
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

		// Token: 0x060000F6 RID: 246 RVA: 0x0002AAC4 File Offset: 0x00028CC4
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

		// Token: 0x060000F7 RID: 247 RVA: 0x0002AB04 File Offset: 0x00028D04
		private void save_livraison(int id)
		{
			bd bd = new bd();
			bool flag = this.radCheckedDropDownList2.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList2.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList2.Items[i].Checked;
					if (@checked)
					{
						string cmdText = "select id from parametre_livraison_fournisseur where designation = @a and deleted = @d";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radCheckedDropDownList2.Items[i].Text;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag2 = dataTable.Rows.Count != 0;
						if (flag2)
						{
							string cmdText2 = "insert into tableau_fournisseur_livraison(id_fournisseur, id_livraison) values (@i1, @i2)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0002AC94 File Offset: 0x00028E94
		private void save_reglement(int id)
		{
			bd bd = new bd();
			bool flag = this.radCheckedDropDownList3.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList3.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList3.Items[i].Checked;
					if (@checked)
					{
						string cmdText = "select id from parametre_reglement_fournisseur where designation = @a and deleted = @d";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radCheckedDropDownList3.Items[i].Text;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag2 = dataTable.Rows.Count != 0;
						if (flag2)
						{
							string cmdText2 = "insert into tableau_fournisseur_reglement(id_fournisseur, id_reglement) values (@i1, @i2)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0002AE24 File Offset: 0x00029024
		private void save_compte(int id)
		{
			bd bd = new bd();
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
					if (@checked)
					{
						string cmdText = "select id from parametre_compte_fournisseur where designation = @a and deleted = @d";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag2 = dataTable.Rows.Count != 0;
						if (flag2)
						{
							string cmdText2 = "insert into tableau_fournisseur_compte(id_fournisseur, id_compte) values (@i1, @i2)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0002AFB4 File Offset: 0x000291B4
		private void save_activite(int id)
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
					string cmdText2 = "insert into tableau_fournisseur_activite(id_fournisseur, id_activite) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0002B100 File Offset: 0x00029300
		private void save_devise(int id)
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
					string cmdText2 = "insert into tableau_fournisseur_devise(id_fournisseur, id_devise) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0002B24C File Offset: 0x0002944C
		private void save_fichier(int id)
		{
			bd bd = new bd();
			bool flag = this.liste_adresse.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.liste_adresse.Count; i++)
				{
					string cmdText = "insert into tableau_fournisseur_fichier (id_fournisseur, adresse) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.liste_adresse[i];
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0002B310 File Offset: 0x00029510
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

		// Token: 0x060000FE RID: 254 RVA: 0x0002B384 File Offset: 0x00029584
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
					string cmdText = "select id from fournisseur where (code_fournisseur = @a1 or nom = @a2) and deleted = @d";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@a1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand.Parameters.Add("@a2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
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
						string cmdText2 = "insert into fournisseur(code_fournisseur, nom, type, activite, commentaire, tva_defaut, delai, remise_defaut, pays, ville, code_postal, adresse, telephone_1, telephone_2, fax_1, fax_2, email, site_web, nom_banque, domiciliation, iban, rib, deleted, fodec) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i12, @i13, @i14, @i15, @i16, @i17, @i18, @i19, @i20, @i21, @i22, @i23, @i24)SELECT CAST(scope_identity() AS int)";
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
						sqlCommand2.Parameters.Add("@i23", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						int id = (int)sqlCommand2.ExecuteScalar();
						bd.cnn.Close();
						this.save_activite(id);
						this.save_compte(id);
						this.save_devise(id);
						this.save_livraison(id);
						this.save_reglement(id);
						this.save_fichier(id);
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.guna2TextBox1.Clear();
						this.guna2TextBox2.Clear();
						this.guna2TextBox3.Clear();
						this.guna2TextBox4.Clear();
						this.guna2TextBox5.Clear();
						this.guna2TextBox6.Clear();
						fournisseur_adresse.select_pays();
						fournisseur_adresse.TextBox1.Clear();
						fournisseur_adresse.TextBox2.Clear();
						fournisseur_adresse.TextBox3.Clear();
						Fournisseur_contact.TextBox1.Clear();
						Fournisseur_contact.TextBox2.Clear();
						Fournisseur_contact.TextBox3.Clear();
						Fournisseur_contact.TextBox4.Clear();
						Fournisseur_contact.TextBox5.Clear();
						Fournisseur_contact.TextBox6.Clear();
						fournisseur_banque.TextBox1.Clear();
						fournisseur_banque.TextBox2.Clear();
						fournisseur_banque.TextBox3.Clear();
						fournisseur_banque.TextBox4.Clear();
						this.select_mode_livraison();
						this.select_mode_reglement();
						this.select_type_activite();
						this.select_devise();
						this.select_compte();
						this.liste_adresse.Clear();
						this.recherche_fichier();
						MessageBox.Show("Le Fournisseur est ajouté avec succés");
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

		// Token: 0x060000FF RID: 255 RVA: 0x0002BA90 File Offset: 0x00029C90
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

		// Token: 0x06000100 RID: 256 RVA: 0x0002BACC File Offset: 0x00029CCC
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

		// Token: 0x0400014F RID: 335
		private List<string> liste_adresse = new List<string>();
	}
}
