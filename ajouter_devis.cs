using System;
using System.Collections.Generic;
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
	// Token: 0x0200000D RID: 13
	public partial class ajouter_devis : Form
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x0002224C File Offset: 0x0002044C
		public ajouter_devis()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellValueChanged += new GridViewCellEventHandler(this.RadGridView1_CellValueChanged);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000222D0 File Offset: 0x000204D0
		private void RadGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(this.radGridView1.Rows[i].Cells[4].Value.ToString()) & fonction.is_reel(this.radGridView1.Rows[i].Cells[5].Value.ToString()) & fonction.is_reel(this.radGridView1.Rows[i].Cells[6].Value.ToString());
					if (flag2)
					{
						double num2 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(this.radGridView1.Rows[i].Cells[5].Value);
						num2 -= num2 * Convert.ToDouble(this.radGridView1.Rows[i].Cells[6].Value) / 100.0;
						num += num2;
						this.radGridView1.Rows[i].Cells[7].Value = num2.ToString("0.000");
					}
				}
				this.label6.Text = num.ToString("0.000");
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00022498 File Offset: 0x00020698
		private void ajouter_devis_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.pictureBox2.Hide();
			this.label3.Text = liste_dop.id_dop;
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Oui");
			this.radDropDownList1.Items.Add("Non");
			this.radDropDownList1.Text = "Oui";
			this.select_fournisseur();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0002252C File Offset: 0x0002072C
		private void select_fournisseur()
		{
			this.radDropDownList6.Items.Clear();
			string cmdText = "select fournisseur.nom, fournisseur.id from dop_fournisseur inner join fournisseur on dop_fournisseur.id_fournisseur = fournisseur.id  where id_dop = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_dop.id_dop;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select devis_fournisseur.id from devis_fournisseur inner join devis on devis_fournisseur.id_devis = devis.id inner join dop on devis.id_dop = dop.id where id_fournisseur = @i1 and dop.id = @i2";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[1].ToString();
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = liste_dop.id_dop;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count == 0;
					if (flag2)
					{
						this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
						this.radDropDownList6.Items[this.radDropDownList6.Items.Count - 1].Tag = dataTable.Rows[i].ItemArray[1].ToString();
					}
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000226E0 File Offset: 0x000208E0
		private void select_article()
		{
			this.radGridView1.Rows.Clear();
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				string cmdText = "select article.id, article.code_article, article.designation, qt from dop_article inner join article on dop_article.id_article = article.id where id_dop = @i";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						string cmdText2 = "select id from tableau_article_fournisseur where id_article = @i1 and id_fournisseur = @i2";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag.ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							this.radGridView1.Rows.Add(new object[]
							{
								dataTable.Rows[i].ItemArray[0].ToString(),
								dataTable.Rows[i].ItemArray[1].ToString(),
								dataTable.Rows[i].ItemArray[2].ToString(),
								dataTable.Rows[i].ItemArray[3].ToString(),
								dataTable.Rows[i].ItemArray[3].ToString(),
								0,
								0
							});
						}
					}
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00022917 File Offset: 0x00020B17
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.select_article();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00022924 File Offset: 0x00020B24
		private int format_qt()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(this.radGridView1.Rows[i].Cells[4].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000229B8 File Offset: 0x00020BB8
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
					bool flag2 = !fonction.is_reel(this.radGridView1.Rows[i].Cells[5].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00022A4C File Offset: 0x00020C4C
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
					bool flag2 = !fonction.is_reel(this.radGridView1.Rows[i].Cells[6].Value.ToString());
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00022AE0 File Offset: 0x00020CE0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.format_qt() == 1;
				if (flag2)
				{
					bool flag3 = this.format_prix() == 1;
					if (flag3)
					{
						bool flag4 = this.format_remise() == 1;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "insert into devis (date_devis, heure_devis, createur, id_dop, statut, livr) values (@i1, @i2, @i3, @i4, @i5, @i6)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
							sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.label3.Text;
							sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
							sqlCommand.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
							bd.ouverture_bd(bd.cnn);
							int num = (int)sqlCommand.ExecuteScalar();
							bd.cnn.Close();
							string cmdText2 = "insert into devis_fournisseur (id_devis, id_fournisseur) values (@i1, @i2)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag.ToString();
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							for (int i = 0; i < this.radGridView1.Rows.Count; i++)
							{
								string cmdText3 = "insert into devis_article (id_devis, id_article, qt_disponible, prix_ht, remise) values (@i1, @i2, @i3, @i4, @i5)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[4].Value.ToString();
								sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[5].Value.ToString();
								sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[6].Value.ToString();
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
							}
							this.save_fichier(num);
							MessageBox.Show("Succés");
							this.select_fournisseur();
							this.radGridView1.Rows.Clear();
							this.liste_adresse.Clear();
							this.recherche_fichier();
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
					MessageBox.Show("Erreur : Vérifier le format des cellules quantité disponible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Le tableau est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00022F0C File Offset: 0x0002110C
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

		// Token: 0x060000C0 RID: 192 RVA: 0x00022F70 File Offset: 0x00021170
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

		// Token: 0x060000C1 RID: 193 RVA: 0x00023350 File Offset: 0x00021550
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

		// Token: 0x060000C2 RID: 194 RVA: 0x000233B0 File Offset: 0x000215B0
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

		// Token: 0x060000C3 RID: 195 RVA: 0x00023410 File Offset: 0x00021610
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

		// Token: 0x060000C4 RID: 196 RVA: 0x00023450 File Offset: 0x00021650
		private void save_fichier(int id)
		{
			bd bd = new bd();
			bool flag = this.liste_adresse.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.liste_adresse.Count; i++)
				{
					string cmdText = "insert into devis_fichier (id_devis, adresse) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.liste_adresse[i];
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x04000112 RID: 274
		private List<string> liste_adresse = new List<string>();
	}
}
