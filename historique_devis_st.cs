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
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200007E RID: 126
	public partial class historique_devis_st : Form
	{
		// Token: 0x060005EB RID: 1515 RVA: 0x000F7A2C File Offset: 0x000F5C2C
		public historique_devis_st()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ContextMenuOpening += new ContextMenuOpeningEventHandler(this.radGridView1_ContextMenuOpening);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau(0);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x000F7AF8 File Offset: 0x000F5CF8
		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x000F7B03 File Offset: 0x000F5D03
		private void historique_devis_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000F7B08 File Offset: 0x000F5D08
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

		// Token: 0x060005EF RID: 1519 RVA: 0x000F7BA0 File Offset: 0x000F5DA0
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select ds_devis.id, id_ds, date_devis, heure_devis, ds_devis.createur, fournisseur.nom, livr from ds_devis inner join ds_devis_fournisseur on ds_devis.id = ds_devis_fournisseur.id_devis inner join fournisseur on ds_devis_fournisseur.id_fournisseur = fournisseur.id inner join demande_sous_traitance on ds_devis.id_ds = demande_sous_traitance.id where date_devis between @d1 and @d2 and (ds_devis.id like '%' + @k2 + '%' or @k2 = @vide) and (id_ds like '%' + @k1 + '%' or @k1 = @vide) and demande_sous_traitance.statut <> @i  ";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand.Parameters.Add("@k1", SqlDbType.VarChar).Value = this.TextBox3.Text;
			sqlCommand.Parameters.Add("@k2", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
			sqlCommand.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
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
						dataTable.Rows[i].ItemArray[1].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString(),
						this.select_utilisateur(dataTable.Rows[i].ItemArray[4].ToString()),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.loadarticle();
			this.Loadfichier();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x000F7E89 File Offset: 0x000F6089
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x000F7E94 File Offset: 0x000F6094
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x000F7E9F File Offset: 0x000F609F
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x000F7EAC File Offset: 0x000F60AC
		private void loadarticle()
		{
			bd bd = new bd();
			string cmdText = "select ds_devis_article.id_devis,ref_interne, article.code_article, article.designation, activite.designation, ds_devis_article.qt, ds_devis_article.prix_ht, ds_devis_article.remise from ds_devis_article inner join magasin_sous_traitance on ds_devis_article.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id inner join activite on ds_devis_article.id_activite = activite.id   inner join ds_devis on ds_devis_article.id_devis = ds_devis.id  inner join demande_sous_traitance on ds_devis.id_ds = demande_sous_traitance.id where demande_sous_traitance.statut <> @i and ds_devis_article.source = @s  and ds_devis.date_devis between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select ds_devis_article.id_devis,article.code_article, article.designation,  activite.designation, ds_devis_article.qt, ds_devis_article.prix_ht, ds_devis_article.remise from ds_devis_article inner join ds_nv_article on ds_devis_article.id_t = ds_nv_article.id inner join article on ds_nv_article.id_article = article.id inner join activite on ds_devis_article.id_activite = activite.id   inner join ds_devis on ds_devis_article.id_devis = ds_devis.id inner join demande_sous_traitance on ds_devis.id_ds = demande_sous_traitance.id where ds_devis_article.source = @s and demande_sous_traitance.statut <> @i and ds_devis.date_devis between @d1 and @d2";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@s", SqlDbType.VarChar).Value = "nv";
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			DataTable dataTable3 = new DataTable();
			dataTable3.Columns.Add("column1");
			dataTable3.Columns.Add("column2");
			dataTable3.Columns.Add("column3");
			dataTable3.Columns.Add("column4");
			dataTable3.Columns.Add("column5");
			dataTable3.Columns.Add("column6");
			dataTable3.Columns.Add("column7");
			dataTable3.Columns.Add("column8");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[6]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[7].ToString()
					});
				}
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					dataTable3.Rows.Add(new object[]
					{
						dataTable2.Rows[j].ItemArray[0].ToString(),
						"-",
						dataTable2.Rows[j].ItemArray[1].ToString(),
						dataTable2.Rows[j].ItemArray[2].ToString(),
						dataTable2.Rows[j].ItemArray[3].ToString(),
						dataTable2.Rows[j].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable2.Rows[j].ItemArray[5]).ToString("0.000"),
						dataTable2.Rows[j].ItemArray[6].ToString()
					});
				}
			}
			GridViewTemplate gridViewTemplate = new GridViewTemplate();
			gridViewTemplate.Caption = "Articles";
			gridViewTemplate.DataSource = dataTable3;
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
			gridViewTemplate.Columns["column8"].Width = 200;
			gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[0].IsVisible = false;
			gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;
			gridViewTemplate.Columns[1].HeaderText = "Réference interne";
			gridViewTemplate.Columns[2].HeaderText = "Code Article";
			gridViewTemplate.Columns[3].HeaderText = "Désignation";
			gridViewTemplate.Columns[4].HeaderText = "Activité";
			gridViewTemplate.Columns[5].HeaderText = "Quantité";
			gridViewTemplate.Columns[6].HeaderText = "Prix U HT";
			gridViewTemplate.Columns[7].HeaderText = "Remise";
			this.radGridView1.Templates.Insert(0, gridViewTemplate);
			GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
			gridViewRelation.ChildTemplate = gridViewTemplate;
			gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
			gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
			this.radGridView1.Relations.Add(gridViewRelation);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x000F86DC File Offset: 0x000F68DC
		private void Loadfichier()
		{
			bd bd = new bd();
			string cmdText = "select id_devis, adresse from ds_devis_fichier inner join ds_devis on ds_devis_fichier.id_devis = ds_devis.id where ds_devis.date_devis between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2", typeof(Image));
			dataTable2.Columns.Add("column3");
			int index = 9;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "docx";
					if (flag2)
					{
						index = 3;
					}
					bool flag3 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "xlsx" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "xls";
					if (flag3)
					{
						index = 4;
					}
					bool flag4 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "pdf";
					if (flag4)
					{
						index = 5;
					}
					bool flag5 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "txt";
					if (flag5)
					{
						index = 6;
					}
					bool flag6 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "jpeg" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "png" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "jpg";
					if (flag6)
					{
						index = 7;
					}
					bool flag7 = this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "rar" | this.n_fichier(dataTable.Rows[i].ItemArray[1].ToString()) == "zip";
					if (flag7)
					{
						index = 8;
					}
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						this.imageList1.Images[index],
						dataTable.Rows[i].ItemArray[1].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Fichiers";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 80;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns[1].ImageLayout = ImageLayout.Zoom;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[2].HeaderText = "";
				gridViewTemplate.ShowColumnHeaders = false;
				gridViewTemplate.AllowCellContextMenu = true;
				int count = this.radGridView1.Templates.Count;
				this.radGridView1.Templates.Insert(count, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000F8BAC File Offset: 0x000F6DAC
		private void radGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			GridDataCellElement targetCell = e.ContextMenuProvider as GridDataCellElement;
			bool flag = targetCell != null && targetCell.RowInfo.HierarchyLevel == 1 && targetCell.ColumnIndex == 2;
			if (flag)
			{
				e.ContextMenu.Items.Clear();
				bool flag2 = targetCell.RowInfo.ViewTemplate.Caption == "Fichiers";
				if (flag2)
				{
					RadMenuItem radMenuItem = new RadMenuItem("Ouvrir");
					e.ContextMenu.Items.Add(radMenuItem);
					radMenuItem.Click += delegate(object s, EventArgs f)
					{
						fonction.ouvrir_fichier(targetCell.Value.ToString());
					};
				}
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000F8C6C File Offset: 0x000F6E6C
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
	}
}
