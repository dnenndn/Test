using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200008C RID: 140
	public partial class liste_facture : Form
	{
		// Token: 0x06000688 RID: 1672 RVA: 0x0011C2B0 File Offset: 0x0011A4B0
		public liste_facture()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radDateTimePicker1.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
			this.radDateTimePicker2.ValueChanged += delegate(object s, EventArgs f)
			{
				this.remplissage_tableau(0);
			};
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0011C358 File Offset: 0x0011A558
		private void liste_facture_Load(object sender, EventArgs e)
		{
			design.design_datagridview(this.dataGridView2);
			this.radGridView1.Size = new Size(978, 470);
			this.radPanel1.Hide();
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0011C3F0 File Offset: 0x0011A5F0
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

		// Token: 0x0600068B RID: 1675 RVA: 0x0011C488 File Offset: 0x0011A688
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_facture, article.code_article, article.designation, sum(livraison_article.qt), livraison_article.prix_ht, livraison_article.remise from facture_livraison inner join livraison_article on facture_livraison.id_livraison = livraison_article.id_livraison inner join facture on facture_livraison.id_facture = facture.id inner join article on livraison_article.id_article = article.id where facture.date_reel between @d1 and @d2 group by article.code_article, article.designation, livraison_article.prix_ht, livraison_article.remise, id_facture";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			dataTable2.Columns.Add("column4");
			dataTable2.Columns.Add("column5");
			dataTable2.Columns.Add("column6");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 150;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 200;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.Columns["column6"].Width = 150;
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				gridViewTemplate.Columns[4].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[5].HeaderText = "Remise";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0011C8F8 File Offset: 0x0011AAF8
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select distinct facture.id ,date_facture, heure_facture, createur, fournisseur.nom, facture.date_reel, n_facture, sum((livraison_article.qt*livraison_article.prix_ht) - ((livraison_article.qt*livraison_article.prix_ht*livraison_article.remise)/100)) from facture inner join fournisseur on facture.id_fournisseur = fournisseur.id inner join facture_livraison on facture.id = facture_livraison.id_facture inner join livraison_article on facture_livraison.id_livraison = livraison_article.id_livraison where facture.date_reel between @d1 and @d2 group by facture.id ,date_facture, heure_facture, createur, fournisseur.nom, facture.date_reel, n_facture";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[6].ToString()),
						fonction.Mid(dataTable.Rows[i].ItemArray[5].ToString(), 1, 10),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[3].ToString()),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[7]).ToString("0.000"),
						Resources.icons8_visible_96,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
				bool flag2 = page_loginn.stat_user != "Responsable Achat";
				if (flag2)
				{
					this.radGridView1.Columns[9].IsVisible = false;
				}
			}
			bool flag3 = this.radGridView1.Rows.Count != 0;
			if (flag3)
			{
				bool flag4 = o == 0;
				if (flag4)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag5 = o == 1;
				if (flag5)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag6 = o == 2;
				if (flag6)
				{
					this.radGridView1.Rows[liste_facture.row_act].IsCurrent = true;
				}
				bool flag7 = o == 3;
				if (flag7)
				{
					bool flag8 = liste_facture.row_act != 0;
					if (flag8)
					{
						this.radGridView1.Rows[liste_facture.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.loadarticle();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0011CCF0 File Offset: 0x0011AEF0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 9;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
							bd bd = new bd();
							string cmdText = "select id_livraison from facture_livraison where id_facture = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag5 = dataTable.Rows.Count != 0;
							if (flag5)
							{
								for (int i = 0; i < dataTable.Rows.Count; i++)
								{
									string cmdText2 = "update bon_livraison set statut = @v where id = @i";
									SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
									sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 0;
									sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
									bd.ouverture_bd(bd.cnn);
									sqlCommand2.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							string cmdText3 = "delete facture_livraison where id_facture = @i";
							string cmdText4 = "delete facture where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							sqlCommand4.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag6 = e.RowIndex >= 0 && e.ColumnIndex == 8;
					if (flag6)
					{
						this.dataGridView2.Rows.Clear();
						this.label8.Text = "";
						this.label5.Text = "";
						this.label4.Text = "";
						this.label6.Text = "";
						this.label11.Text = "";
						string value2 = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						this.radGridView1.Hide();
						this.label10.Hide();
						this.label19.Hide();
						this.label20.Hide();
						this.radDateTimePicker1.Hide();
						this.radDateTimePicker2.Hide();
						this.radPanel1.Location = new Point(20, 31);
						this.radPanel1.Size = new Size(1000, 500);
						this.radPanel2.Size = new Size(260, 100);
						this.radPanel3.Location = new Point(550, this.radPanel3.Location.Y);
						this.radPanel3.Size = new Size(400, 100);
						this.dataGridView2.Size = new Size(985, 366);
						this.label8.Text = this.radGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
						bd bd2 = new bd();
						string cmdText5 = "select  article.code_article, article.designation, sum(livraison_article.qt), livraison_article.prix_ht, livraison_article.remise from facture_livraison inner join livraison_article on facture_livraison.id_livraison = livraison_article.id_livraison inner join facture on facture_livraison.id_facture = facture.id inner join article on livraison_article.id_article = article.id where facture.id = @i  group by article.code_article, article.designation, livraison_article.prix_ht, livraison_article.remise, id_facture";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						double num = 0.0;
						bool flag7 = dataTable2.Rows.Count != 0;
						if (flag7)
						{
							for (int j = 0; j < dataTable2.Rows.Count; j++)
							{
								double num2 = Convert.ToDouble(dataTable2.Rows[j].ItemArray[3].ToString()) * Convert.ToDouble(dataTable2.Rows[j].ItemArray[2].ToString());
								num2 -= Convert.ToDouble(dataTable2.Rows[j].ItemArray[4].ToString()) / 100.0 * num2;
								num2 = Math.Round(num2, 3);
								num += num2;
								this.dataGridView2.Rows.Add(new object[]
								{
									dataTable2.Rows[j].ItemArray[0].ToString(),
									dataTable2.Rows[j].ItemArray[1].ToString(),
									dataTable2.Rows[j].ItemArray[2].ToString(),
									Convert.ToDouble(dataTable2.Rows[j].ItemArray[3]).ToString("0.000"),
									dataTable2.Rows[j].ItemArray[4].ToString(),
									num2.ToString("0.000")
								});
							}
						}
						string cmdText6 = "select date_reel, tva from facture where id=@i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand6);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag8 = dataTable3.Rows.Count != 0;
						if (flag8)
						{
							this.label11.Text = fonction.Mid(dataTable3.Rows[0].ItemArray[0].ToString(), 1, 10);
							this.label5.Text = dataTable3.Rows[0].ItemArray[1].ToString() + " %";
						}
						double num3 = num + num * Convert.ToDouble(dataTable3.Rows[0].ItemArray[1].ToString()) / 100.0;
						this.label4.Text = num.ToString("0.000");
						this.label6.Text = num3.ToString("0.000");
						this.radPanel1.Show();
					}
				}
			}
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0011D448 File Offset: 0x0011B648
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Show();
			this.radDateTimePicker2.Show();
			this.label10.Show();
			this.label20.Show();
			this.label19.Show();
			this.radGridView1.Show();
			this.radGridView1.Size = new Size(978, 470);
			this.radPanel1.Hide();
		}

		// Token: 0x040008AB RID: 2219
		private static int row_act;
	}
}
