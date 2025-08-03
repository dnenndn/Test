using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000067 RID: 103
	public partial class devis_classement_fournisseur : Form
	{
		// Token: 0x060004E4 RID: 1252 RVA: 0x000D26D0 File Offset: 0x000D08D0
		public devis_classement_fournisseur()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change1);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee1);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000D272E File Offset: 0x000D092E
		private void label3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x000D2734 File Offset: 0x000D0934
		private void devis_classement_fournisseur_Load(object sender, EventArgs e)
		{
			this.label3.Text = tableau_comparatif.id_dop;
			this.remplissage_tableau();
			this.TextBox1.Text = "1";
			this.TextBox2.Text = "1";
			this.TextBox3.Text = "1";
			this.TextBox4.Text = "5";
			this.note_total();
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000D27A8 File Offset: 0x000D09A8
		private void remplissage_tableau()
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select date_dop from dop where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = tableau_comparatif.id_dop;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select fournisseur.nom ,fournisseur.id from dop_fournisseur inner join fournisseur on dop_fournisseur.id_fournisseur = fournisseur.id where id_dop = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = tableau_comparatif.id_dop;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					string cmdText3 = "select date_devis, devis.id, devis.livr from devis inner join devis_fournisseur on devis.id = devis_fournisseur.id_devis where devis.id_dop = @i1 and devis_fournisseur.id_fournisseur = @i2";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = tableau_comparatif.id_dop;
					sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[1].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					this.radGridView2.Rows.Add(new object[]
					{
						"",
						dataTable2.Rows[i].ItemArray[0].ToString()
					});
					bool flag2 = dataTable3.Rows.Count != 0;
					if (flag2)
					{
						this.radGridView2.Rows[this.radGridView2.Rows.Count - 1].Cells[4].Value = dataTable3.Rows[0].ItemArray[2].ToString();
						this.radGridView2.Rows[i].Cells[0].Value = dataTable3.Rows[0].ItemArray[1].ToString();
						this.radGridView2.Rows[i].Cells[2].Value = fonction.Mid(dataTable3.Rows[0].ItemArray[0].ToString(), 1, 10);
						DateTime d = Convert.ToDateTime(dataTable3.Rows[0].ItemArray[0].ToString());
						DateTime d2 = Convert.ToDateTime(dataTable.Rows[0].ItemArray[0].ToString());
						int days = (d2 - d).Days;
						this.radGridView2.Rows[i].Cells[3].Value = days.ToString() + " Jours ";
					}
					else
					{
						this.radGridView2.Rows[i].Cells[2].Value = "Pas de réponse";
						this.radGridView2.Rows[i].Cells[3].Value = "Pas de réponse";
					}
				}
			}
			bool flag3 = this.radGridView2.Rows.Count != 0;
			if (flag3)
			{
				for (int j = 0; j < this.radGridView2.Rows.Count; j++)
				{
					bool flag4 = this.radGridView2.Rows[j].Cells[0].Value.ToString() != "";
					if (flag4)
					{
						string cmdText4 = "select qt_disponible, id_article from devis_article where id_devis = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[j].Cells[0].Value.ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						int num = 0;
						for (int k = 0; k < dataTable4.Rows.Count; k++)
						{
							string cmdText5 = "select id from dop_article where qt> @v and id_article = @i and id_dop = @i1";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = tableau_comparatif.id_dop;
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable4.Rows[k].ItemArray[1].ToString();
							sqlCommand5.Parameters.Add("@v", SqlDbType.Real).Value = dataTable4.Rows[k].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							bool flag5 = dataTable5.Rows.Count != 0;
							if (flag5)
							{
								num++;
							}
						}
						this.radGridView2.Rows[j].Cells[5].Value = num.ToString();
					}
					else
					{
						this.radGridView2.Rows[j].Cells[5].Value = "-";
					}
				}
				this.ordre_reactivite();
				this.ordre_disponibilite();
				this.ordre_prix();
				this.radGridView2.Templates.Clear();
				bool flag6 = this.radGridView2.Rows.Count != 0;
				if (flag6)
				{
					this.LoadArticle();
				}
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000D2DB0 File Offset: 0x000D0FB0
		private void ordre_reactivite()
		{
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				List<DateTime> list = new List<DateTime>();
				List<int> list2 = new List<int>();
				List<int> list3 = new List<int>();
				fonction fonction = new fonction();
				int num = 1;
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = fonction.isdate(this.radGridView2.Rows[i].Cells[2].Value.ToString());
					if (flag2)
					{
						list3.Add(i);
						list.Add(Convert.ToDateTime(this.radGridView2.Rows[i].Cells[2].Value.ToString()));
						list2.Add(num);
						num++;
					}
				}
				bool flag3 = list3.Count != 1;
				if (flag3)
				{
					for (int j = 0; j < list3.Count - 1; j++)
					{
						bool flag4 = list[j] > list[j + 1];
						if (flag4)
						{
							int value = list3[j + 1];
							list3[j + 1] = list3[j];
							list3[j] = value;
							DateTime value2 = list[j + 1];
							list[j + 1] = list[j];
							list[j] = value2;
						}
					}
					while (this.test_fin_tri(list) == 1)
					{
						for (int k = 0; k < list3.Count - 1; k++)
						{
							bool flag5 = list[k] > list[k + 1];
							if (flag5)
							{
								int value3 = list3[k + 1];
								list3[k + 1] = list3[k];
								list3[k] = value3;
								DateTime value4 = list[k + 1];
								list[k + 1] = list[k];
								list[k] = value4;
							}
						}
					}
					int value5 = 1;
					int num2 = 2;
					for (int l = 0; l < list3.Count - 1; l++)
					{
						bool flag6 = list[l] == list[l + 1];
						if (flag6)
						{
							num2++;
							list2[l + 1] = value5;
						}
						else
						{
							list2[l + 1] = num2;
							value5 = num2;
							num2++;
						}
					}
					for (int m = 0; m < list3.Count; m++)
					{
						this.radGridView2.Rows[list3[m]].Cells[6].Value = this.radGridView2.Rows.Count - list2[m] + 1;
					}
					for (int n = 0; n < this.radGridView2.Rows.Count; n++)
					{
						bool flag7 = Convert.ToString(this.radGridView2.Rows[n].Cells[6].Value) == "";
						if (flag7)
						{
							this.radGridView2.Rows[n].Cells[6].Value = 0;
						}
					}
				}
				else
				{
					for (int num3 = 0; num3 < this.radGridView2.Rows.Count; num3++)
					{
						this.radGridView2.Rows[num3].Cells[6].Value = "0";
					}
				}
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000D31B8 File Offset: 0x000D13B8
		private int test_fin_tri(List<DateTime> l)
		{
			int result = 0;
			for (int i = 0; i < l.Count - 1; i++)
			{
				bool flag = l[i] > l[i + 1];
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000D3208 File Offset: 0x000D1408
		private int test_fin_tri_d(List<int> l)
		{
			int result = 0;
			for (int i = 0; i < l.Count - 1; i++)
			{
				bool flag = l[i] > l[i + 1];
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000D3254 File Offset: 0x000D1454
		private void ordre_disponibilite()
		{
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				List<int> list3 = new List<int>();
				fonction fonction = new fonction();
				int num = 1;
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					bool flag2 = fonction.isnumeric(this.radGridView2.Rows[i].Cells[5].Value.ToString());
					if (flag2)
					{
						list3.Add(i);
						list.Add(Convert.ToInt32(this.radGridView2.Rows[i].Cells[5].Value.ToString()));
						list2.Add(num);
						num++;
					}
				}
				bool flag3 = list3.Count != 1;
				if (flag3)
				{
					for (int j = 0; j < list3.Count - 1; j++)
					{
						bool flag4 = list[j] > list[j + 1];
						if (flag4)
						{
							int value = list[j + 1];
							list[j + 1] = list[j];
							list[j] = value;
							int value2 = list3[j + 1];
							list3[j + 1] = list3[j];
							list3[j] = value2;
						}
					}
					while (this.test_fin_tri_d(list) == 1)
					{
						for (int k = 0; k < list3.Count - 1; k++)
						{
							bool flag5 = list[k] > list[k + 1];
							if (flag5)
							{
								int value3 = list[k + 1];
								list[k + 1] = list[k];
								list[k] = value3;
								int value4 = list3[k + 1];
								list3[k + 1] = list3[k];
								list3[k] = value4;
							}
						}
					}
					int value5 = 1;
					int num2 = 2;
					for (int l = 0; l < list3.Count - 1; l++)
					{
						bool flag6 = list[l] == list[l + 1];
						if (flag6)
						{
							num2++;
							list2[l + 1] = value5;
						}
						else
						{
							list2[l + 1] = num2;
							value5 = num2;
							num2++;
						}
					}
					for (int m = 0; m < list3.Count; m++)
					{
						this.radGridView2.Rows[list3[m]].Cells[7].Value = this.radGridView2.Rows.Count - list2[m] + 1;
					}
					for (int n = 0; n < this.radGridView2.Rows.Count; n++)
					{
						bool flag7 = Convert.ToString(this.radGridView2.Rows[n].Cells[7].Value) == "";
						if (flag7)
						{
							this.radGridView2.Rows[n].Cells[7].Value = 0;
						}
					}
				}
				else
				{
					for (int num3 = 0; num3 < this.radGridView2.Rows.Count; num3++)
					{
						this.radGridView2.Rows[num3].Cells[7].Value = "0";
					}
				}
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x000D3654 File Offset: 0x000D1854
		private void LoadArticle()
		{
			bd bd = new bd();
			string cmdText = "select devis_article.id_devis, article.code_article, article.designation, devis_article.qt_disponible, devis_article.prix_ht, devis_article.remise from devis_article inner join devis on devis_article.id_devis = devis.id inner join article on devis_article.id_article = article.id  where devis.id_dop = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
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
				gridViewTemplate.Caption = "Articles";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 200;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.Columns["column6"].Width = 150;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				gridViewTemplate.Columns[3].HeaderText = "Quantité";
				gridViewTemplate.Columns[4].HeaderText = "Prix U HT";
				gridViewTemplate.Columns[5].HeaderText = "Remise (%)";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView2.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView2.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView2.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView2.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x000D3B00 File Offset: 0x000D1D00
		private void ordre_prix()
		{
			bd bd = new bd();
			bool flag = this.radGridView2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView2.Rows.Count; i++)
				{
					string cmdText = "select id_devis from devis_fournisseur inner join devis on devis_fournisseur.id_devis = devis.id inner join fournisseur on devis_fournisseur.id_fournisseur = fournisseur.id where devis.id_dop = @i1 and fournisseur.nom = @i2";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = tableau_comparatif.id_dop;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.radGridView2.Rows[i].Cells[1].Value.ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						double num = 0.0;
						string cmdText2 = "select id_article, prix_ht, remise from devis_article where id_devis = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							for (int j = 0; j < dataTable2.Rows.Count; j++)
							{
								double num2 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[1].ToString());
								num2 -= Convert.ToDouble(dataTable2.Rows[0].ItemArray[1].ToString()) * Convert.ToDouble(dataTable2.Rows[0].ItemArray[2].ToString()) / 100.0;
								string cmdText3 = "select devis_article.id from devis_article inner join devis on devis_article.id_devis = devis.id where devis.id_dop = @i1 and id_article = @i2 and prix_ht - (prix_ht*remise)/@i4 < @i3 and devis.id <> @i5";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = tableau_comparatif.id_dop;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = num2;
								sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = 100;
								sqlCommand3.Parameters.Add("@i5", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
								DataTable dataTable3 = new DataTable();
								sqlDataAdapter3.Fill(dataTable3);
								num += (double)(this.radGridView2.Rows.Count - dataTable3.Rows.Count + 1);
							}
							num /= (double)dataTable2.Rows.Count;
							num = Math.Round(num, 1);
							this.radGridView2.Rows[i].Cells[8].Value = num;
						}
						else
						{
							this.radGridView2.Rows[i].Cells[8].Value = 0;
						}
					}
					else
					{
						this.radGridView2.Rows[i].Cells[8].Value = 0;
					}
				}
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x000D3ECC File Offset: 0x000D20CC
		private void note_total()
		{
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.TextBox1.Text) & fonction.is_reel(this.TextBox2.Text) & fonction.is_reel(this.TextBox3.Text) & fonction.is_reel(this.TextBox4.Text);
			if (flag)
			{
				bool flag2 = this.radGridView2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < this.radGridView2.Rows.Count; i++)
					{
						bool flag3 = Convert.ToString(this.radGridView2.Rows[i].Cells[4].Value) == "Oui";
						if (flag3)
						{
							this.radGridView2.Rows[i].Cells[9].Value = Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value) * Convert.ToDouble(this.TextBox1.Text) + Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value) * Convert.ToDouble(this.TextBox2.Text) + Convert.ToDouble(this.radGridView2.Rows[i].Cells[8].Value) * Convert.ToDouble(this.TextBox3.Text) + Convert.ToDouble(this.TextBox4.Text);
						}
						else
						{
							this.radGridView2.Rows[i].Cells[9].Value = Convert.ToDouble(this.radGridView2.Rows[i].Cells[6].Value) * Convert.ToDouble(this.TextBox1.Text) + Convert.ToDouble(this.radGridView2.Rows[i].Cells[7].Value) * Convert.ToDouble(this.TextBox2.Text) + Convert.ToDouble(this.radGridView2.Rows[i].Cells[8].Value) * Convert.ToDouble(this.TextBox3.Text);
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : Tableau est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier que toutes les champs du poids sont des réels", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000D4194 File Offset: 0x000D2394
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			this.remplissage_tableau();
			this.note_total();
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000D41A8 File Offset: 0x000D23A8
		private void RunExportToPDF(string fileName)
		{
			new ExportToPDF(this.radGridView2)
			{
				PdfExportSettings = 
				{
					Title = "Tableau comparatif",
					PageWidth = 297,
					PageHeight = 210
				},
				FitToPageWidth = true,
				ExportVisualSettings = true,
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				FileExtension = "pdf",
				PagingExportOption = 1,
				HiddenRowOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView2.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000D4260 File Offset: 0x000D2460
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			bool flag = this.saveFileDialog1.ShowDialog() != DialogResult.OK;
			if (!flag)
			{
				bool flag2 = this.saveFileDialog1.FileName.Equals(string.Empty);
				if (flag2)
				{
					MessageBox.Show("choisir le nom de fichier");
				}
				else
				{
					string fileName = this.saveFileDialog1.FileName;
					this.RunExportToPDF(fileName);
				}
			}
		}
	}
}
