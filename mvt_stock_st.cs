using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x0200009F RID: 159
	public partial class mvt_stock_st : Form
	{
		// Token: 0x0600073C RID: 1852 RVA: 0x0013DCA0 File Offset: 0x0013BEA0
		public mvt_stock_st()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.select_reference();
			this.remplissage_tableau(0);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0013DD50 File Offset: 0x0013BF50
		private void mvt_stock_st_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0013DD54 File Offset: 0x0013BF54
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 14;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select ds_historique_mvt.id, mvt, date_mvt, heure_mvt, article.designation, magasin_sous_traitance.ref_interne from ds_historique_mvt inner join magasin_sous_traitance on ds_historique_mvt.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id where date_mvt between @d1 and @d2 and (magasin_sous_traitance.ref_interne = @i1 or @i1 = @f) order by magasin_sous_traitance.ref_interne";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand.Parameters.Add("i1", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
			sqlCommand.Parameters.Add("f", SqlDbType.VarChar).Value = "Tous";
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
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString()
					});
				}
			}
			bool flag2 = this.radGridView1.Rows.Count != 0;
			if (flag2)
			{
				bool flag3 = o == 0;
				if (flag3)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag4 = o == 1;
				if (flag4)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag5 = o == 2;
				if (flag5)
				{
					this.radGridView1.Rows[mvt_stock_st.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = mvt_stock_st.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[mvt_stock_st.row_act - 1].IsCurrent = true;
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
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0013E0CC File Offset: 0x0013C2CC
		private void select_reference()
		{
			this.radDropDownList6.Items.Clear();
			this.radDropDownList6.Items.Add("Tous");
			bd bd = new bd();
			string cmdText = "select id, ref_interne from magasin_sous_traitance";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
				}
			}
			this.radDropDownList6.Text = "Tous";
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0013E1A7 File Offset: 0x0013C3A7
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0013E1B2 File Offset: 0x0013C3B2
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0013E1BD File Offset: 0x0013C3BD
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x040009D3 RID: 2515
		private static int row_act;
	}
}
