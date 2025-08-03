using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000085 RID: 133
	public partial class liste_article_simple : Form
	{
		// Token: 0x0600063C RID: 1596 RVA: 0x00102C1A File Offset: 0x00100E1A
		public liste_article_simple()
		{
			this.InitializeComponent();
			this.dataGridView2.CellDoubleClick += this.DataGridView2_CellDoubleClick;
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00102C4C File Offset: 0x00100E4C
		private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Achat";
			if (flag)
			{
				liste_article_simple.id_article = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
				Modifier_article modifier_article = new Modifier_article();
				modifier_article.Show();
			}
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00102CBC File Offset: 0x00100EBC
		private void liste_article_simple_Load(object sender, EventArgs e)
		{
			design.design_datagridview(this.dataGridView2);
			this.select_article();
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00102CD4 File Offset: 0x00100ED4
		private void select_article()
		{
			this.dataGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, code_article, reference, designation, marque, stock_neuf, stock_use, stock_rebute, prix_ht from article where deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
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
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					sqlCommand2.Parameters.Add("@m", SqlDbType.VarChar).Value = "Magasin";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					int count = dataTable2.Rows.Count;
					this.dataGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0],
						dataTable.Rows[i].ItemArray[1],
						dataTable.Rows[i].ItemArray[2],
						dataTable.Rows[i].ItemArray[3],
						dataTable.Rows[i].ItemArray[4],
						dataTable.Rows[i].ItemArray[5],
						dataTable.Rows[i].ItemArray[6],
						dataTable.Rows[i].ItemArray[7],
						count,
						dataTable.Rows[i].ItemArray[8]
					});
				}
				bool flag2 = page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Administrateur";
				if (flag2)
				{
					this.dataGridView2.Columns[9].Visible = false;
				}
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00102F64 File Offset: 0x00101164
		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.dataGridView2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.DeleteSpace(this.TextBox1.Text) != "";
				if (flag2)
				{
					for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
					{
						bool flag3 = this.dataGridView2.Rows[i].Cells[3].Value.ToString().ToUpper().Contains(this.TextBox1.Text.ToUpper()) | this.dataGridView2.Rows[i].Cells[0].Value.ToString().ToUpper().Contains(this.TextBox1.Text.ToUpper()) | this.dataGridView2.Rows[i].Cells[1].Value.ToString().ToUpper().Contains(this.TextBox1.Text.ToUpper()) | this.dataGridView2.Rows[i].Cells[2].Value.ToString().ToUpper().Contains(this.TextBox1.Text.ToUpper()) | this.dataGridView2.Rows[i].Cells[4].Value.ToString().ToUpper().Contains(this.TextBox1.Text.ToUpper());
						if (flag3)
						{
							this.dataGridView2.Rows[i].Visible = true;
						}
						else
						{
							this.dataGridView2.Rows[i].Visible = false;
						}
					}
				}
				else
				{
					for (int j = 0; j < this.dataGridView2.Rows.Count; j++)
					{
						this.dataGridView2.Rows[j].Visible = true;
					}
				}
			}
		}

		// Token: 0x0400083B RID: 2107
		public static string id_article;
	}
}
