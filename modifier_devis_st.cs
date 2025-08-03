using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200009D RID: 157
	public partial class modifier_devis_st : Form
	{
		// Token: 0x06000720 RID: 1824 RVA: 0x00138BF4 File Offset: 0x00136DF4
		public modifier_devis_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellValueChanged += new GridViewCellEventHandler(this.RadGridView1_CellValueChanged);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00138C6C File Offset: 0x00136E6C
		private void modifier_devis_st_Load(object sender, EventArgs e)
		{
			this.label14.Text = "";
			this.label8.Text = "";
			this.label9.Text = "";
			this.label10.Text = "";
			this.label11.Text = "";
			this.label4.Hide();
			this.label5.Hide();
			this.label6.Hide();
			this.label7.Hide();
			this.label12.Hide();
			this.label15.Hide();
			this.pictureBox2.Hide();
			this.radDropDownList1.Hide();
			this.label6.Text = "";
			this.label3.Text = creer_devis_st.id_ds;
			this.select_sous_traitant();
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00138D58 File Offset: 0x00136F58
		private void RadGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[5].Value)) & fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[7].Value)) & fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[8].Value));
					if (flag2)
					{
						double num2 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(this.radGridView1.Rows[i].Cells[7].Value);
						num2 -= num2 * Convert.ToDouble(this.radGridView1.Rows[i].Cells[8].Value) / 100.0;
						num += num2;
						this.radGridView1.Rows[i].Cells[9].Value = num2.ToString("0.000");
					}
				}
				this.label6.Text = num.ToString("0.000");
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00138F20 File Offset: 0x00137120
		private void select_sous_traitant()
		{
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			string cmdText = "select fournisseur.nom, id from fournisseur where type = @t and id  in (select id_fournisseur from ds_devis_fournisseur inner join ds_devis on ds_devis_fournisseur.id_devis = ds_devis.id where ds_devis.id_ds = @o )";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Sous_Traitant";
			sqlCommand.Parameters.Add("@o", SqlDbType.Int).Value = this.label3.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList6.Items[this.radDropDownList6.Items.Count - 1].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0013905C File Offset: 0x0013725C
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				this.radDropDownList1.Items.Clear();
				this.radDropDownList1.Items.Add("Oui");
				this.radDropDownList1.Items.Add("Non");
				bd bd = new bd();
				string cmdText = "select ds_devis_fournisseur.id_devis, ds_devis.createur, ds_devis.date_devis, ds_devis.heure_devis, ds_devis.livr from ds_devis_fournisseur inner join ds_devis on ds_devis_fournisseur.id_devis = ds_devis.id where ds_devis.id_ds = @i1 and ds_devis_fournisseur.id_fournisseur = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label3.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					this.label4.Show();
					this.label5.Show();
					this.label6.Show();
					this.label7.Show();
					this.label12.Show();
					this.label15.Show();
					this.radDropDownList1.Show();
					this.label8.Text = dataTable.Rows[0].ItemArray[0].ToString();
					this.label9.Text = this.select_utilisateur(dataTable.Rows[0].ItemArray[1].ToString());
					this.label10.Text = fonction.Mid(dataTable.Rows[0].ItemArray[2].ToString(), 1, 10);
					this.label11.Text = dataTable.Rows[0].ItemArray[3].ToString();
					this.radDropDownList1.Text = dataTable.Rows[0].ItemArray[4].ToString();
					this.select_article();
					this.recherche_fichier();
				}
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00139284 File Offset: 0x00137484
		private string select_utilisateur(string i)
		{
			bd bd = new bd();
			string result = "";
			string cmdText = "select login from utilisateur where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = i;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = dataTable.Rows[0].ItemArray[0].ToString();
			}
			return result;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0013931C File Offset: 0x0013751C
		private void recherche_fichier()
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			string cmdText = "select adresse from ds_devis_fichier where id_devis = @l";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@l", SqlDbType.Int).Value = this.label8.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radPanel1.Controls.Clear();
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					PictureBox pictureBox = new PictureBox();
					pictureBox.Size = new Size(48, 30);
					pictureBox.Cursor = Cursors.Hand;
					pictureBox.Location = new Point(5 + 100 * i, 7);
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					string h = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
					pictureBox.Click += delegate(object s, EventArgs e)
					{
						fonction.ouvrir_fichier(h);
					};
					bool flag2 = this.n_fichier(h) == "dwg";
					if (flag2)
					{
						pictureBox.Image = this.imageList1.Images[9];
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
								pictureBox.Image = this.imageList1.Images[4];
							}
							else
							{
								bool flag5 = this.n_fichier(h) == "pdf";
								if (flag5)
								{
									pictureBox.Image = this.imageList1.Images[5];
								}
								else
								{
									bool flag6 = this.n_fichier(h) == "txt";
									if (flag6)
									{
										pictureBox.Image = this.imageList1.Images[6];
									}
									else
									{
										bool flag7 = this.n_fichier(h) == "docx";
										if (flag7)
										{
											pictureBox.Image = this.imageList1.Images[3];
										}
										else
										{
											bool flag8 = this.n_fichier(h) == "rar" | this.n_fichier(h) == "zip";
											if (flag8)
											{
												pictureBox.Image = this.imageList1.Images[8];
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

		// Token: 0x06000727 RID: 1831 RVA: 0x0013978C File Offset: 0x0013798C
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

		// Token: 0x06000728 RID: 1832 RVA: 0x001397EC File Offset: 0x001379EC
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

		// Token: 0x06000729 RID: 1833 RVA: 0x0013984C File Offset: 0x00137A4C
		private void supprimer_file(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "delete ds_devis_fichier where id_devis = @a and adresse = @x";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = this.label8.Text;
				sqlCommand.Parameters.Add("@x", SqlDbType.VarChar).Value = x;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.recherche_fichier();
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x001398FC File Offset: 0x00137AFC
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(openFileDialog.FileName) != "";
			if (flag)
			{
				string cmdText = "insert into ds_devis_fichier (id_devis, adresse) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label8.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = openFileDialog.FileName;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
			this.recherche_fichier();
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x001399CC File Offset: 0x00137BCC
		private void select_article()
		{
			this.radGridView1.Rows.Clear();
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select article.id,ref_interne, article.code_article, article.designation, activite.designation, magasin_sous_traitance.id from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id inner join activite on magasin_sous_traitance.activite_actuel = activite.id inner join demande_sous_traitance on magasin_sous_traitance.demande_actuel = demande_sous_traitance.id where demande_sous_traitance.id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string cmdText2 = "select article.id,article.code_article, article.designation,quantite,  activite.designation, ds_nv_article.id from ds_nv_article inner join article on ds_nv_article.id_article = article.id inner join activite on ds_nv_article.id_activite = activite.id inner join demande_sous_traitance on ds_nv_article.id_demande = demande_sous_traitance.id where demande_sous_traitance.id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						string cmdText3 = "select prix_ht, remise from ds_devis_article inner join ds_devis on ds_devis_article.id_devis = ds_devis.id where id_devis = @i1 and source = @i2 and ds_devis_article.id_t = @i3";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = this.label8.Text;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = "ex";
						sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[5].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[5].ToString(),
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString(),
							"1",
							dataTable.Rows[i].ItemArray[4].ToString(),
							dataTable3.Rows[0].ItemArray[0],
							dataTable3.Rows[0].ItemArray[1]
						});
					}
				}
				bool flag3 = dataTable2.Rows.Count != 0;
				if (flag3)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						string cmdText4 = "select prix_ht, remise from ds_devis_article inner join ds_devis on ds_devis_article.id_devis = ds_devis.id where id_devis = @i1 and source = @i2 and ds_devis_article.id_t = @i3";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = this.label8.Text;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = "nv";
						sqlCommand4.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[5].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable2.Rows[j].ItemArray[5].ToString(),
							dataTable2.Rows[j].ItemArray[0].ToString(),
							"-",
							dataTable2.Rows[j].ItemArray[1].ToString(),
							dataTable2.Rows[j].ItemArray[2].ToString(),
							dataTable2.Rows[j].ItemArray[3].ToString(),
							dataTable2.Rows[j].ItemArray[4].ToString(),
							dataTable4.Rows[0].ItemArray[0],
							dataTable4.Rows[0].ItemArray[1]
						});
					}
				}
				bool flag4 = this.radGridView1.Rows.Count != 0;
				if (flag4)
				{
					double num = 0.0;
					fonction fonction = new fonction();
					for (int k = 0; k < this.radGridView1.Rows.Count; k++)
					{
						bool flag5 = fonction.is_reel(this.radGridView1.Rows[k].Cells[7].Value.ToString()) & fonction.is_reel(this.radGridView1.Rows[k].Cells[8].Value.ToString());
						if (flag5)
						{
							double num2 = Convert.ToDouble(this.radGridView1.Rows[k].Cells[5].Value) * Convert.ToDouble(this.radGridView1.Rows[k].Cells[7].Value);
							num2 -= num2 * Convert.ToDouble(this.radGridView1.Rows[k].Cells[8].Value) / 100.0;
							num += num2;
							this.radGridView1.Rows[k].Cells[9].Value = num2.ToString("0.000");
						}
					}
					this.label14.Text = num.ToString("0.000");
				}
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0013A014 File Offset: 0x00138214
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bool flag2 = this.format_prix() == 1;
				if (flag2)
				{
					bool flag3 = this.format_remise() == 1;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update devis set livr = @i1 where id = @i2";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.label8.Text;
						sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						for (int i = 0; i < this.radGridView1.Rows.Count; i++)
						{
							string value = "ex";
							bool flag4 = this.radGridView1.Rows[i].Cells[2].Value.ToString() == "-";
							if (flag4)
							{
								value = "nv";
							}
							string cmdText2 = "update ds_devis_article set prix_ht = @v2, remise = @v3 where id_devis = @i and id_t = @i2 and source = @i3";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@v2", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[7].Value.ToString();
							sqlCommand2.Parameters.Add("@v3", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[8].Value.ToString();
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label8.Text;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
							sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
						MessageBox.Show("Modification avec succés");
					}
					else
					{
						MessageBox.Show("Erreur : Vérifier le format des cellules remise", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier le format des cellules prix ht", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Erreur: Il faut choisir un sous traitant", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0013A2E0 File Offset: 0x001384E0
		private int format_prix()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[7].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0013A374 File Offset: 0x00138574
		private int format_remise()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[8].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}
	}
}
