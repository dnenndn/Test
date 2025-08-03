using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200013A RID: 314
	public partial class liste_article : Form
	{
		// Token: 0x06000E08 RID: 3592 RVA: 0x00224374 File Offset: 0x00222574
		public liste_article()
		{
			this.InitializeComponent();
			this.label3.Text = "";
			this.remplissage_tableau(0);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.article_formatting);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x0022441C File Offset: 0x0022261C
		private void panel5_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1082, 1);
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00224458 File Offset: 0x00222658
		private void liste_article_Load(object sender, EventArgs e)
		{
			this.panel1.Hide();
			this.panel2.Hide();
			this.radGridView1.Location = new Point(12, 21);
			this.radGridView1.Size = new Size(1104, 530);
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x002244B0 File Offset: 0x002226B0
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 8;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select photo, id, code_article, reference,designation, marque, stock_neuf, prix_ht, tva, stock_use, stock_rebute from article where deleted = @i order by designation";
			bd bd = new bd();
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
					string cmdText2 = "select id from magasin_sous_traitance where id_article = @i and emplacement_actuel = @m";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[i].ItemArray[1]);
					sqlCommand2.Parameters.Add("@m", SqlDbType.VarChar).Value = "Magasin";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					int count = dataTable2.Rows.Count;
					byte[] buffer = (byte[])dataTable.Rows[i].ItemArray[0];
					MemoryStream stream = new MemoryStream(buffer);
					this.radGridView1.Rows.Add(new object[]
					{
						Image.FromStream(stream),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[7]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[8].ToString(),
						dataTable.Rows[i].ItemArray[9].ToString(),
						dataTable.Rows[i].ItemArray[10].ToString(),
						count
					});
					this.radGridView1.Rows[i].Cells[12].Value = this.imageList1.Images[1];
					this.radGridView1.Rows[i].Cells[13].Value = this.imageList1.Images[0];
					this.radGridView1.Rows[i].Height = 50;
				}
				bool flag2 = page_loginn.stat_user != "Responsable Méthode";
				if (flag2)
				{
					this.radGridView1.Columns[12].IsVisible = false;
				}
				bool flag3 = page_loginn.stat_user == "Magasinier" | page_loginn.stat_user == "Responsable Magasin";
				if (flag3)
				{
					this.radGridView1.Columns[7].IsVisible = false;
					this.radGridView1.Columns[8].IsVisible = false;
					this.radGridView1.Columns[12].IsVisible = false;
				}
				bool flag4 = page_loginn.stat_user == "Responsable Magasin";
				if (flag4)
				{
					this.radGridView1.Columns[12].IsVisible = true;
				}
			}
			this.label3.Text = this.radGridView1.Rows.Count.ToString() + " Articles";
			bool flag5 = this.radGridView1.Rows.Count != 0;
			if (flag5)
			{
				bool flag6 = o == 0;
				if (flag6)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag7 = o == 1;
				if (flag7)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag8 = o == 2;
				if (flag8)
				{
					this.radGridView1.Rows[liste_article.row_act].IsCurrent = true;
				}
				bool flag9 = o == 3;
				if (flag9)
				{
					bool flag10 = liste_article.row_act != 0;
					if (flag10)
					{
						this.radGridView1.Rows[liste_article.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00224A74 File Offset: 0x00222C74
		private void button2_Click(object sender, EventArgs e)
		{
			article_generale article_generale = new article_generale();
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_generale.TopLevel = false;
			this.panel3.Controls.Add(article_generale);
			article_generale.Show();
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00224BCC File Offset: 0x00222DCC
		private void button1_Click(object sender, EventArgs e)
		{
			article_stock article_stock = new article_stock();
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_stock.TopLevel = false;
			this.panel3.Controls.Add(article_stock);
			article_stock.Show();
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x00224D24 File Offset: 0x00222F24
		private void button3_Click(object sender, EventArgs e)
		{
			article_commentaire article_commentaire = new article_commentaire();
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_commentaire.TopLevel = false;
			this.panel3.Controls.Add(article_commentaire);
			article_commentaire.Show();
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00224E7C File Offset: 0x0022307C
		private void button4_Click(object sender, EventArgs e)
		{
			article_parametre article_parametre = new article_parametre();
			this.button4.ForeColor = Color.Firebrick;
			this.button4.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_parametre.TopLevel = false;
			this.panel3.Controls.Add(article_parametre);
			article_parametre.Show();
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00224FD4 File Offset: 0x002231D4
		private void button5_Click(object sender, EventArgs e)
		{
			article_equipement article_equipement = new article_equipement();
			this.button5.ForeColor = Color.Firebrick;
			this.button5.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_equipement.TopLevel = false;
			this.panel3.Controls.Add(article_equipement);
			article_equipement.Show();
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x0022512C File Offset: 0x0022332C
		private void button6_Click(object sender, EventArgs e)
		{
			article_fichier article_fichier = new article_fichier();
			this.button6.ForeColor = Color.Firebrick;
			this.button6.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_fichier.TopLevel = false;
			this.panel3.Controls.Add(article_fichier);
			article_fichier.Show();
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00225284 File Offset: 0x00223484
		private void button7_Click(object sender, EventArgs e)
		{
			article_image article_image = new article_image();
			this.button7.ForeColor = Color.Firebrick;
			this.button7.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button8.ForeColor = Color.White;
			this.button8.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_image.TopLevel = false;
			this.panel3.Controls.Add(article_image);
			article_image.Show();
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x002253DC File Offset: 0x002235DC
		private void panel6_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1059, 1);
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00225418 File Offset: 0x00223618
		private void label1_Click(object sender, EventArgs e)
		{
			bool flag = !this.panel1.Visible;
			if (flag)
			{
				this.panel2.Hide();
				this.panel1.Show();
				this.radGridView1.Location = new Point(12, 177);
				this.radGridView1.Size = new Size(1104, 377);
			}
			else
			{
				this.panel1.Hide();
				this.panel2.Hide();
				this.radGridView1.Location = new Point(12, 21);
				this.radGridView1.Size = new Size(1104, 530);
			}
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x002254D4 File Offset: 0x002236D4
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					liste_article.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 13;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update article set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 12;
					if (flag5)
					{
						this.panel1.Hide();
						this.radGridView1.Location = new Point(12, 21);
						this.radGridView1.Size = new Size(1104, 355);
						liste_article.id_article = value;
						bool flag6 = !this.panel2.Visible;
						if (flag6)
						{
							this.button2_Click(sender, e);
						}
						else
						{
							bool flag7 = this.button1.BackColor == Color.White;
							if (flag7)
							{
								this.button1_Click(sender, e);
							}
							bool flag8 = this.button2.BackColor == Color.White;
							if (flag8)
							{
								this.button2_Click(sender, e);
							}
							bool flag9 = this.button3.BackColor == Color.White;
							if (flag9)
							{
								this.button3_Click(sender, e);
							}
							bool flag10 = this.button4.BackColor == Color.White;
							if (flag10)
							{
								this.button4_Click(sender, e);
							}
							bool flag11 = this.button5.BackColor == Color.White;
							if (flag11)
							{
								this.button5_Click(sender, e);
							}
							bool flag12 = this.button6.BackColor == Color.White;
							if (flag12)
							{
								this.button6_Click(sender, e);
							}
							bool flag13 = this.button7.BackColor == Color.White;
							if (flag13)
							{
								this.button7_Click(sender, e);
							}
							bool flag14 = this.button8.BackColor == Color.White;
							if (flag14)
							{
								this.button8_Click(sender, e);
							}
						}
						this.panel2.Show();
					}
				}
			}
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x002257D4 File Offset: 0x002239D4
		private void button8_Click(object sender, EventArgs e)
		{
			article_caracteristique article_caracteristique = new article_caracteristique();
			this.button8.ForeColor = Color.Firebrick;
			this.button8.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			article_caracteristique.TopLevel = false;
			this.panel3.Controls.Add(article_caracteristique);
			article_caracteristique.Show();
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x0022592A File Offset: 0x00223B2A
		private void panel4_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00225930 File Offset: 0x00223B30
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel1.Hide();
			this.panel2.Hide();
			this.radGridView1.Location = new Point(12, 21);
			this.radGridView1.Size = new Size(1104, 530);
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00225988 File Offset: 0x00223B88
		private void article_formatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.RowInfo is GridViewDataRowInfo;
			if (flag)
			{
				double num = Convert.ToDouble(e.CellElement.RowInfo.Cells["Column8"].Value);
				bool flag2 = num <= 0.0;
				if (flag2)
				{
					e.CellElement.DrawFill = true;
					e.CellElement.GradientStyle = 0;
					e.CellElement.BackColor = Color.Goldenrod;
				}
			}
		}

		// Token: 0x040011D5 RID: 4565
		private static int row_act;

		// Token: 0x040011D6 RID: 4566
		public static string id_article;
	}
}
