using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000060 RID: 96
	public partial class da_eyes : Form
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x000BFE18 File Offset: 0x000BE018
		public da_eyes()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change1);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee1);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000BFE76 File Offset: 0x000BE076
		private void da_eyes_Load(object sender, EventArgs e)
		{
			this.label3.Text = "";
			this.pictureBox2.Hide();
			this.label3.Text = Form1.id_daa;
			this.select_action();
			this.recherche_fichier();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x000BFEB8 File Offset: 0x000BE0B8
		private static string select_utilisateur(string i)
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

		// Token: 0x06000486 RID: 1158 RVA: 0x000BFF50 File Offset: 0x000BE150
		private void select_action()
		{
			bd bd = new bd();
			string cmdText = "select envoyer_par, date_envoyer, heure_envoyer from da_administrateur where id_da = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Envoyer vers l'administrateur",
						da_eyes.select_utilisateur(dataTable.Rows[i].ItemArray[0].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
			}
			string cmdText2 = "select cloturer_par, date_cloture, heure_cloture from da_cloturer where id_da = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Cloturer",
						da_eyes.select_utilisateur(dataTable2.Rows[j].ItemArray[0].ToString()),
						fonction.Mid(dataTable2.Rows[j].ItemArray[1].ToString(), 1, 10) + " " + dataTable2.Rows[j].ItemArray[2].ToString()
					});
				}
			}
			string cmdText3 = "select confirmer_par, date_confirmer, heure_confirmer from da_confirmer where id_da = @i";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			bool flag3 = dataTable3.Rows.Count != 0;
			if (flag3)
			{
				for (int k = 0; k < dataTable3.Rows.Count; k++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Confirmer",
						da_eyes.select_utilisateur(dataTable3.Rows[k].ItemArray[0].ToString()),
						fonction.Mid(dataTable3.Rows[k].ItemArray[1].ToString(), 1, 10) + " " + dataTable3.Rows[k].ItemArray[2].ToString()
					});
				}
			}
			string cmdText4 = "select modifier_par, date_modifier, heure_modifier from da_modifier where id_da = @i";
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
			sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
			DataTable dataTable4 = new DataTable();
			sqlDataAdapter4.Fill(dataTable4);
			bool flag4 = dataTable4.Rows.Count != 0;
			if (flag4)
			{
				for (int l = 0; l < dataTable4.Rows.Count; l++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Modifier",
						da_eyes.select_utilisateur(dataTable4.Rows[l].ItemArray[0].ToString()),
						fonction.Mid(dataTable4.Rows[l].ItemArray[1].ToString(), 1, 10) + " " + dataTable4.Rows[l].ItemArray[2].ToString()
					});
				}
			}
			string cmdText5 = "select reenvoyer_par, date_reenvoyer, heure_reenvoyer from da_reenvoyer where id_da = @i";
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
			sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
			DataTable dataTable5 = new DataTable();
			sqlDataAdapter5.Fill(dataTable5);
			bool flag5 = dataTable5.Rows.Count != 0;
			if (flag5)
			{
				for (int m = 0; m < dataTable5.Rows.Count; m++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Reenvoyer après refus",
						da_eyes.select_utilisateur(dataTable5.Rows[m].ItemArray[0].ToString()),
						fonction.Mid(dataTable5.Rows[m].ItemArray[1].ToString(), 1, 10) + " " + dataTable5.Rows[m].ItemArray[2].ToString()
					});
				}
			}
			string cmdText6 = "select refuser_par, date_refus, heure_refus from da_refuser where id_da = @i";
			SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
			sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
			DataTable dataTable6 = new DataTable();
			sqlDataAdapter6.Fill(dataTable6);
			bool flag6 = dataTable6.Rows.Count != 0;
			if (flag6)
			{
				for (int n = 0; n < dataTable6.Rows.Count; n++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Refuser",
						da_eyes.select_utilisateur(dataTable6.Rows[n].ItemArray[0].ToString()),
						fonction.Mid(dataTable6.Rows[n].ItemArray[1].ToString(), 1, 10) + " " + dataTable6.Rows[n].ItemArray[2].ToString()
					});
				}
			}
			string cmdText7 = "select reporter_par, date_report, heure_report from da_reporter where id_da = @i";
			SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
			sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
			DataTable dataTable7 = new DataTable();
			sqlDataAdapter7.Fill(dataTable7);
			bool flag7 = dataTable7.Rows.Count != 0;
			if (flag7)
			{
				for (int num = 0; num < dataTable7.Rows.Count; num++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Reporter",
						da_eyes.select_utilisateur(dataTable7.Rows[num].ItemArray[0].ToString()),
						fonction.Mid(dataTable7.Rows[num].ItemArray[1].ToString(), 1, 10) + " " + dataTable7.Rows[num].ItemArray[2].ToString()
					});
				}
			}
			string cmdText8 = "select retourner_par, date_retourner, heure_retourner from da_retourner where id_da = @i";
			SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
			sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
			DataTable dataTable8 = new DataTable();
			sqlDataAdapter8.Fill(dataTable8);
			bool flag8 = dataTable8.Rows.Count != 0;
			if (flag8)
			{
				for (int num2 = 0; num2 < dataTable8.Rows.Count; num2++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Retourner",
						da_eyes.select_utilisateur(dataTable8.Rows[num2].ItemArray[0].ToString()),
						fonction.Mid(dataTable8.Rows[num2].ItemArray[1].ToString(), 1, 10) + " " + dataTable8.Rows[num2].ItemArray[2].ToString()
					});
				}
			}
			string cmdText9 = "select vue_par, date_vue, heure_vue from da_vue where id_da = @i";
			SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
			sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = Form1.id_daa;
			SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(sqlCommand9);
			DataTable dataTable9 = new DataTable();
			sqlDataAdapter9.Fill(dataTable9);
			bool flag9 = dataTable9.Rows.Count != 0;
			if (flag9)
			{
				for (int num3 = 0; num3 < dataTable9.Rows.Count; num3++)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						"Vue",
						da_eyes.select_utilisateur(dataTable9.Rows[num3].ItemArray[0].ToString()),
						fonction.Mid(dataTable9.Rows[num3].ItemArray[1].ToString(), 1, 10) + " " + dataTable9.Rows[num3].ItemArray[2].ToString()
					});
				}
			}
			ListSortDirection listSortDirection = ListSortDirection.Descending;
			this.radGridView2.EnableSorting = true;
			this.radGridView2.MasterTemplate.SortDescriptors.Add("column2", listSortDirection);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x000C0974 File Offset: 0x000BEB74
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
				string cmdText = "insert into da_fichier (id_da, adresse) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label3.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = openFileDialog.FileName;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
			this.recherche_fichier();
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000C0A44 File Offset: 0x000BEC44
		private void recherche_fichier()
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			string cmdText = "select adresse from da_fichier where id_da = @l";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@l", SqlDbType.Int).Value = this.label3.Text;
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

		// Token: 0x06000489 RID: 1161 RVA: 0x000C0EB4 File Offset: 0x000BF0B4
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

		// Token: 0x0600048A RID: 1162 RVA: 0x000C0F14 File Offset: 0x000BF114
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

		// Token: 0x0600048B RID: 1163 RVA: 0x000C0F74 File Offset: 0x000BF174
		private void supprimer_file(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "delete da_fichier where id_da = @a and adresse = @x";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = this.label3.Text;
				sqlCommand.Parameters.Add("@x", SqlDbType.VarChar).Value = x;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.recherche_fichier();
			}
		}
	}
}
