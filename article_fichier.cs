using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000152 RID: 338
	public partial class article_fichier : Form
	{
		// Token: 0x06000F12 RID: 3858 RVA: 0x00246D1E File Offset: 0x00244F1E
		public article_fichier()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x00246D38 File Offset: 0x00244F38
		private void PictureBox6_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(openFileDialog.FileName) != "";
			if (flag)
			{
				string cmdText = "insert into tableau_article_fichier(id_article, adresse) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = liste_article.id_article;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = openFileDialog.FileName;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.recherche_fichier();
			}
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x00246E04 File Offset: 0x00245004
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

		// Token: 0x06000F15 RID: 3861 RVA: 0x00246E64 File Offset: 0x00245064
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

		// Token: 0x06000F16 RID: 3862 RVA: 0x00246EC4 File Offset: 0x002450C4
		private void supprimer_file(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				bd bd = new bd();
				fonction fonction = new fonction();
				string cmdText = "delete tableau_article_fichier where id_article = @i1 and adresse = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = liste_article.id_article;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = x;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.recherche_fichier();
			}
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x00246F74 File Offset: 0x00245174
		private void recherche_fichier()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			this.radPanel1.Controls.Clear();
			string cmdText = "select adresse from tableau_article_fichier where id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					PictureBox pictureBox = new PictureBox();
					pictureBox.Size = new Size(48, 30);
					pictureBox.Cursor = Cursors.Hand;
					pictureBox.Location = new Point(5 + 100 * i, 7);
					pictureBox.Image = this.PictureBox7.Image;
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					string h = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
					pictureBox.Click += delegate(object s, EventArgs e)
					{
						fonction.ouvrir_fichier(h);
					};
					bool flag2 = this.n_fichier(h) == "dwg";
					if (flag2)
					{
						pictureBox.Image = this.PictureBox7.Image;
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
									bool flag6 = this.n_fichier(h) == "docx";
									if (flag6)
									{
										pictureBox.Image = this.imageList1.Images[2];
									}
									else
									{
										bool flag7 = this.n_fichier(h) == "txt";
										if (flag7)
										{
											pictureBox.Image = this.imageList1.Images[5];
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
												pictureBox.Image = this.imageList1.Images[8];
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
					pictureBox2.Image = this.PictureBox8.Image;
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

		// Token: 0x06000F18 RID: 3864 RVA: 0x002473E6 File Offset: 0x002455E6
		private void article_fichier_Load(object sender, EventArgs e)
		{
			this.PictureBox7.Hide();
			this.PictureBox8.Hide();
			this.recherche_fichier();
		}
	}
}
