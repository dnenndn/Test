using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200005B RID: 91
	public partial class da_add_equipement : Form
	{
		// Token: 0x06000455 RID: 1109 RVA: 0x000B8BC4 File Offset: 0x000B6DC4
		public da_add_equipement()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000B8C24 File Offset: 0x000B6E24
		private void da_add_equipement_Load(object sender, EventArgs e)
		{
			this.radGridView1.Rows.Clear();
			this.label6.Text = creer_da.id_article;
			this.label7.Text = creer_da.designation_article;
			string cmdText = "select equipement.id, equipement.designation from tableau_article_equipement inner join equipement on tableau_article_equipement.id_equipement = equipement.id where equipement.deleted = @d and tableau_article_equipement.id_article = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = creer_da.id_article;
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
						dataTable.Rows[i].ItemArray[1].ToString()
					});
				}
			}
			this.dt_grid(this.radGridView1, creer_da.table);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000B8D6C File Offset: 0x000B6F6C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = creer_da.table.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < creer_da.table.Rows.Count; i++)
				{
					bool flag2 = creer_da.table.Rows[i].ItemArray[0].ToString() == this.label6.Text;
					if (flag2)
					{
						creer_da.table.Rows.Remove(creer_da.table.Rows[i]);
						i--;
					}
				}
			}
			bool flag3 = this.radGridView1.Rows.Count != 0;
			if (flag3)
			{
				for (int j = 0; j < this.radGridView1.Rows.Count; j++)
				{
					bool flag4 = Convert.ToString(this.radGridView1.Rows[j].Cells[2].Value) == "True";
					if (flag4)
					{
						creer_da.table.Rows.Add(new object[]
						{
							this.label6.Text,
							this.radGridView1.Rows[j].Cells[0].Value.ToString(),
							this.radGridView1.Rows[j].Cells[1].Value.ToString()
						});
					}
				}
			}
			creer_da.select_equipement();
			base.Close();
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x000B8F14 File Offset: 0x000B7114
		private void dt_grid(RadGridView rd, DataTable dt)
		{
			bool flag = rd.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < rd.Rows.Count; i++)
				{
					bool flag2 = dt.Rows.Count != 0;
					if (flag2)
					{
						for (int j = 0; j < dt.Rows.Count; j++)
						{
							bool flag3 = rd.Rows[i].Cells[0].Value.ToString() == dt.Rows[j].ItemArray[1].ToString() & dt.Rows[j].ItemArray[0].ToString() == this.label6.Text;
							if (flag3)
							{
								rd.Rows[i].Cells[2].Value = "True";
							}
						}
					}
				}
			}
		}
	}
}
