using System;
using System.Collections.Generic;
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
	// Token: 0x0200005A RID: 90
	public partial class créer_dop : Form
	{
		// Token: 0x0600044E RID: 1102 RVA: 0x000B7EBC File Offset: 0x000B60BC
		public créer_dop()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000B7F1A File Offset: 0x000B611A
		private void créer_dop_Load(object sender, EventArgs e)
		{
			this.select_article();
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000B7F24 File Offset: 0x000B6124
		private void select_article()
		{
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.Rows.Clear();
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select article.id, article.code_article, article.designation, sum(qt_restant) from da_article inner join demande_achat on da_article.id_da = demande_achat.id inner join article on da_article.id_article = article.id where demande_achat.statut = @d group by article.id, article.code_article, article.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select dop_article.id from dop_article inner join article on dop_article.id_article = article.id inner join dop on dop_article.id_dop = dop.id where id_article = @i1 and dop.statut = @i2";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count == 0;
					if (flag2)
					{
						bool flag3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[3]) > 0.0;
						if (flag3)
						{
							this.radGridView1.Rows.Add(new object[]
							{
								dataTable.Rows[i].ItemArray[0].ToString(),
								dataTable.Rows[i].ItemArray[1].ToString(),
								dataTable.Rows[i].ItemArray[2].ToString(),
								dataTable.Rows[i].ItemArray[3].ToString()
							});
						}
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x000B8170 File Offset: 0x000B6370
		private int test_cochez()
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[4].Value) == "True";
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x000B8204 File Offset: 0x000B6404
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			bool flag = this.test_cochez() == 1;
			if (flag)
			{
				List<string> list = new List<string>();
				List<double> list2 = new List<double>();
				list.Clear();
				list2.Clear();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[4].Value) == "True";
					if (flag2)
					{
						list.Add(this.radGridView1.Rows[i].Cells[0].Value.ToString());
						list2.Add(Convert.ToDouble(this.radGridView1.Rows[i].Cells[3].Value));
					}
				}
				bd bd = new bd();
				string cmdText = "insert into dop (date_dop, heure_dop, createur, statut) values (@i1, @i2, @i3, @i4)SELECT CAST(scope_identity() AS int)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
				sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
				sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
				bd.ouverture_bd(bd.cnn);
				int num = (int)sqlCommand.ExecuteScalar();
				bd.cnn.Close();
				for (int j = 0; j < list.Count; j++)
				{
					string cmdText2 = "insert into dop_article(id_dop, id_article, qt) values (@i1, @i2, @i3)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = list[j];
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = list2[j];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
				MessageBox.Show("Création avec succés");
				this.select_article();
			}
			else
			{
				MessageBox.Show("Erreur : Il faut cochez au moin un article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
