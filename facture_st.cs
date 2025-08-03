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
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000076 RID: 118
	public partial class facture_st : Form
	{
		// Token: 0x06000573 RID: 1395 RVA: 0x000E3D78 File Offset: 0x000E1F78
		public facture_st()
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

		// Token: 0x06000574 RID: 1396 RVA: 0x000E3E20 File Offset: 0x000E2020
		private void facture_st_Load(object sender, EventArgs e)
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

		// Token: 0x06000575 RID: 1397 RVA: 0x000E3EB8 File Offset: 0x000E20B8
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

		// Token: 0x06000576 RID: 1398 RVA: 0x000E3F50 File Offset: 0x000E2150
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select id_facture, article.code_article, article.designation, activite.designation,sum(ds_livraison_article.qt) ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_facture_livraison inner join ds_livraison_article on ds_facture_livraison.id_livraison = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s group by article.code_article, article.designation, ds_livraison_article.prix_ht, ds_livraison_article.remise, id_facture, activite.designation ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
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
			dataTable2.Columns.Add("column7");
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
						Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
				}
			}
			string cmdText2 = "select id_facture, article.code_article, article.designation, activite.designation,sum(ds_livraison_article.qt) ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_facture_livraison inner join ds_livraison_article on ds_facture_livraison.id_livraison = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join magasin_sous_traitance on ds_commande_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s group by article.code_article, article.designation, ds_livraison_article.prix_ht, ds_livraison_article.remise, id_facture, activite.designation ";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter2.Fill(dataTable3);
			bool flag2 = dataTable3.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < dataTable3.Rows.Count; j++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable3.Rows[j].ItemArray[0].ToString(),
						dataTable3.Rows[j].ItemArray[1].ToString(),
						dataTable3.Rows[j].ItemArray[2].ToString(),
						dataTable3.Rows[j].ItemArray[3].ToString(),
						dataTable3.Rows[j].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable3.Rows[j].ItemArray[5]).ToString("0.000"),
						dataTable3.Rows[j].ItemArray[6].ToString()
					});
				}
			}
			GridViewTemplate gridViewTemplate = new GridViewTemplate();
			gridViewTemplate.Caption = "Facture";
			gridViewTemplate.DataSource = dataTable2;
			gridViewTemplate.AllowRowResize = false;
			gridViewTemplate.ShowColumnHeaders = true;
			gridViewTemplate.AllowAddNewRow = false;
			gridViewTemplate.AllowEditRow = false;
			gridViewTemplate.Columns["column1"].Width = 200;
			gridViewTemplate.Columns["column2"].Width = 200;
			gridViewTemplate.Columns["column3"].Width = 200;
			gridViewTemplate.Columns["column4"].Width = 200;
			gridViewTemplate.Columns["column5"].Width = 200;
			gridViewTemplate.Columns["column6"].Width = 200;
			gridViewTemplate.Columns["column7"].Width = 200;
			gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[0].IsVisible = false;
			gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[1].HeaderText = "Code Article";
			gridViewTemplate.Columns[2].HeaderText = "Désignation";
			gridViewTemplate.Columns[3].HeaderText = "Activité";
			gridViewTemplate.Columns[4].HeaderText = "Quantité";
			gridViewTemplate.Columns[5].HeaderText = "Prix U HT";
			gridViewTemplate.Columns[6].HeaderText = "Remise";
			this.radGridView1.Templates.Insert(0, gridViewTemplate);
			GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
			gridViewRelation.ChildTemplate = gridViewTemplate;
			gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
			gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
			this.radGridView1.Relations.Add(gridViewRelation);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x000E4648 File Offset: 0x000E2848
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select distinct ds_facture.id ,date_facture, heure_facture, createur, fournisseur.nom, ds_facture.date_reel, n_facture, sum((ds_livraison_article.qt*ds_livraison_article.prix_ht) - ((ds_livraison_article.qt*ds_livraison_article.prix_ht*ds_livraison_article.remise)/100)) from ds_facture inner join fournisseur on ds_facture.id_fournisseur = fournisseur.id  inner join ds_facture_livraison on ds_facture.id = ds_facture_livraison.id_facture inner join ds_livraison_article on ds_facture_livraison.id_livraison = ds_livraison_article.id_livraison where ds_facture.date_reel between @d1 and @d2 group by ds_facture.id ,date_facture, heure_facture, createur, fournisseur.nom, ds_facture.date_reel, n_facture";
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
					this.radGridView1.Rows[facture_st.row_act].IsCurrent = true;
				}
				bool flag7 = o == 3;
				if (flag7)
				{
					bool flag8 = facture_st.row_act != 0;
					if (flag8)
					{
						this.radGridView1.Rows[facture_st.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000578 RID: 1400 RVA: 0x000E4A40 File Offset: 0x000E2C40
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
							string cmdText = "select id_livraison from ds_facture_livraison where id_facture = @i";
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
									string cmdText2 = "update ds_bon_livraison set statut = @v where id = @i";
									SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
									sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 0;
									sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
									bd.ouverture_bd(bd.cnn);
									sqlCommand2.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							string cmdText3 = "delete ds_facture_livraison where id_facture = @i";
							string cmdText4 = "delete ds_facture where id = @i";
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
						string cmdText5 = "select article.code_article, article.designation, activite.designation,sum(ds_livraison_article.qt) ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_facture_livraison inner join ds_livraison_article on ds_facture_livraison.id_livraison = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s and id_facture = @i group by article.code_article, article.designation, ds_livraison_article.prix_ht, ds_livraison_article.remise, id_facture, activite.designation ";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
						sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand5.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						string cmdText6 = "select article.code_article, article.designation, activite.designation,sum(ds_livraison_article.qt) ,ds_livraison_article.prix_ht, ds_livraison_article.remise from ds_facture_livraison inner join ds_livraison_article on ds_facture_livraison.id_livraison = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id inner join activite on ds_commande_article.id_activite = activite.id inner join ds_nv_article on ds_commande_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id where ds_commande_article.source = @s and id_facture = @i group by article.code_article, article.designation, ds_livraison_article.prix_ht, ds_livraison_article.remise, id_facture, activite.designation ";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
						sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand6.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand6);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						double num = 0.0;
						DataTable dataTable4 = new DataTable();
						dataTable4.Columns.Add("Column1");
						dataTable4.Columns.Add("Column2");
						dataTable4.Columns.Add("Column3");
						dataTable4.Columns.Add("Column4");
						dataTable4.Columns.Add("Column5");
						dataTable4.Columns.Add("Column6");
						bool flag7 = dataTable2.Rows.Count != 0;
						if (flag7)
						{
							for (int j = 0; j < dataTable2.Rows.Count; j++)
							{
								dataTable4.Rows.Add(new object[]
								{
									dataTable2.Rows[j].ItemArray[0],
									dataTable2.Rows[j].ItemArray[1],
									dataTable2.Rows[j].ItemArray[2],
									dataTable2.Rows[j].ItemArray[3],
									dataTable2.Rows[j].ItemArray[4],
									dataTable2.Rows[j].ItemArray[5]
								});
							}
						}
						bool flag8 = dataTable3.Rows.Count != 0;
						if (flag8)
						{
							for (int k = 0; k < dataTable3.Rows.Count; k++)
							{
								dataTable4.Rows.Add(new object[]
								{
									dataTable3.Rows[k].ItemArray[0],
									dataTable3.Rows[k].ItemArray[1],
									dataTable3.Rows[k].ItemArray[2],
									dataTable3.Rows[k].ItemArray[3],
									dataTable3.Rows[k].ItemArray[4],
									dataTable3.Rows[k].ItemArray[5]
								});
							}
						}
						bool flag9 = dataTable4.Rows.Count != 0;
						if (flag9)
						{
							for (int l = 0; l < dataTable4.Rows.Count; l++)
							{
								double num2 = Convert.ToDouble(dataTable4.Rows[l].ItemArray[3].ToString()) * Convert.ToDouble(dataTable4.Rows[l].ItemArray[4].ToString());
								num2 -= Convert.ToDouble(dataTable4.Rows[l].ItemArray[5].ToString()) / 100.0 * num2;
								num2 = Math.Round(num2, 3);
								num += num2;
								this.dataGridView2.Rows.Add(new object[]
								{
									dataTable4.Rows[l].ItemArray[0].ToString(),
									dataTable4.Rows[l].ItemArray[1].ToString(),
									dataTable4.Rows[l].ItemArray[2].ToString(),
									dataTable4.Rows[l].ItemArray[3].ToString(),
									Convert.ToDouble(dataTable4.Rows[l].ItemArray[4]).ToString("0.000"),
									dataTable4.Rows[l].ItemArray[5],
									num2.ToString("0.000")
								});
							}
						}
						string cmdText7 = "select date_reel, tva from ds_facture where id=@i";
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd2.cnn);
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand7);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter4.Fill(dataTable5);
						bool flag10 = dataTable5.Rows.Count != 0;
						if (flag10)
						{
							this.label11.Text = fonction.Mid(dataTable5.Rows[0].ItemArray[0].ToString(), 1, 10);
							this.label5.Text = dataTable5.Rows[0].ItemArray[1].ToString() + " %";
						}
						double num3 = num + num * Convert.ToDouble(dataTable5.Rows[0].ItemArray[1].ToString()) / 100.0;
						this.label4.Text = num.ToString("0.000");
						this.label6.Text = num3.ToString("0.000");
						this.radPanel1.Show();
					}
				}
			}
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000E54B4 File Offset: 0x000E36B4
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

		// Token: 0x0400073C RID: 1852
		private static int row_act;
	}
}
