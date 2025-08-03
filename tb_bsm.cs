using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000164 RID: 356
	public partial class tb_bsm : Form
	{
		// Token: 0x06000F98 RID: 3992 RVA: 0x0025AC4C File Offset: 0x00258E4C
		public tb_bsm()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau();
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0025ACFF File Offset: 0x00258EFF
		private void tb_bsm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0025AD04 File Offset: 0x00258F04
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			fonction fonction = new fonction();
			string cmdText = "select sum(quantite*prix_ht), count(distinct id_bsm), count(distinct id_article) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id where bsm.date_bsm between @d1 and @d2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = fonction.is_reel(dataTable.Rows[0].ItemArray[0].ToString());
				if (flag2)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						"0",
						"Total",
						Convert.ToDouble(dataTable.Rows[0].ItemArray[0]).ToString("0.000"),
						dataTable.Rows[0].ItemArray[1].ToString(),
						dataTable.Rows[0].ItemArray[2].ToString()
					});
				}
			}
			string cmdText2 = "select famille.id, famille.designation,  sum(quantite*prix_ht), count(distinct id_bsm), count(distinct bsm_article.id_article) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join tableau_article_sous_famille on bsm_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where bsm.date_bsm between @d1 and @d2 group by famille.id, famille.designation order by sum(quantite*prix_ht) desc ";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag3 = dataTable2.Rows.Count != 0;
			if (flag3)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					bool flag4 = fonction.is_reel(Convert.ToString(dataTable2.Rows[i].ItemArray[2]));
					if (flag4)
					{
						this.radGridView1.Rows.Add(new object[]
						{
							Convert.ToString(dataTable2.Rows[i].ItemArray[0]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[1]),
							Convert.ToDouble(dataTable2.Rows[i].ItemArray[2]).ToString("0.000"),
							Convert.ToString(dataTable2.Rows[i].ItemArray[3]),
							Convert.ToString(dataTable2.Rows[i].ItemArray[4])
						});
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.loadsousfamille();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0025B093 File Offset: 0x00259293
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0025B09D File Offset: 0x0025929D
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0025B0A8 File Offset: 0x002592A8
		private void loadsousfamille()
		{
			bd bd = new bd();
			string cmdText = "select avg(sous_famille.id_famille),sous_famille.id, sous_famille.designation, sum(quantite*prix_ht), count(distinct id_bsm), count(distinct bsm_article.id_article) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join tableau_article_sous_famille on bsm_article.id_article = tableau_article_sous_famille.id_article inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id where bsm.date_bsm between @d1 and @d2 group by sous_famille.id, sous_famille.designation order by sum(quantite*prix_ht) desc ";
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
			fonction fonction = new fonction();
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(dataTable.Rows[i].ItemArray[3].ToString());
					if (flag2)
					{
						dataTable2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000"),
							dataTable.Rows[i].ItemArray[4].ToString(),
							dataTable.Rows[i].ItemArray[5].ToString()
						});
					}
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Sous Famille";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 300;
				gridViewTemplate.Columns["column3"].Width = 200;
				gridViewTemplate.Columns["column4"].Width = 150;
				gridViewTemplate.Columns["column5"].Width = 150;
				gridViewTemplate.AllowAddNewRow = false;
				gridViewTemplate.AllowEditRow = false;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Sous Famille";
				gridViewTemplate.Columns[2].HeaderText = "Tot HT (Dinars)";
				gridViewTemplate.Columns[3].HeaderText = "Nombre BSM";
				gridViewTemplate.Columns[4].HeaderText = "Nbre Articles";
				gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].TextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				gridViewTemplate.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleLeft;
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}
	}
}
