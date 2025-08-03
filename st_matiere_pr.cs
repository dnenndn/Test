using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000127 RID: 295
	public partial class st_matiere_pr : Form
	{
		// Token: 0x06000D05 RID: 3333 RVA: 0x001F8C9C File Offset: 0x001F6E9C
		public st_matiere_pr()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.select_article();
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x001F8D31 File Offset: 0x001F6F31
		private void st_matiere_pr_Load(object sender, EventArgs e)
		{
			this.label2.Text = st_matiere_pr.id_ds;
			this.select_mp();
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x001F8D4C File Offset: 0x001F6F4C
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select id, designation  from article where deleted =@d order by designation";
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
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x001F8E6C File Offset: 0x001F706C
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					bd bd = new bd();
					string text = "";
					string cmdText = "select parametre_unite_article.designation from article inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where article.id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode.Tag;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
					}
					this.radGridView1.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.ToolTipText,
						0,
						text,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
					this.radGridView1.Templates.Clear();
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x001F8FB4 File Offset: 0x001F71B4
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x001F903C File Offset: 0x001F723C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string b = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.radGridView1.Rows.RemoveAt(e.RowIndex);
							bool flag5 = creer_da.table.Rows.Count != 0;
							if (flag5)
							{
								for (int i = 0; i < creer_da.table.Rows.Count; i++)
								{
									bool flag6 = creer_da.table.Rows[i].ItemArray[0].ToString() == b;
									if (flag6)
									{
										creer_da.table.Rows.Remove(creer_da.table.Rows[i]);
										i--;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x001F9192 File Offset: 0x001F7392
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x001F91AC File Offset: 0x001F73AC
		private void select_mp()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select article.id, article.designation, qt, parametre_unite_article.designation from ds_mp inner join article on ds_mp.id_article = article.id inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where id_demande = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label2.Text;
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
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x001F92F4 File Offset: 0x001F74F4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				int num = 1;
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(this.radGridView1.Rows[i].Cells[2].Value.ToString());
					if (flag2)
					{
						bool flag3 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[2].Value.ToString()) <= 0.0;
						if (flag3)
						{
							num = 0;
						}
					}
					else
					{
						num = 0;
					}
				}
				bool flag4 = num == 1;
				if (flag4)
				{
					string cmdText = "update article set stock_neuf = stock_neuf + t2.qt from article t1 inner join ds_mp t2 on t1.id = t2.id_article where t2.id_demande = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label2.Text;
					string cmdText2 = "delete ds_mp where id_demande = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label2.Text;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					for (int j = 0; j < this.radGridView1.Rows.Count; j++)
					{
						string cmdText3 = "update article set stock_neuf = stock_neuf - @v where id in (select id_article from ds_mp where id_demande = @i and id_article = @l)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@v", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView1.Rows[j].Cells[2].Value);
						sqlCommand3.Parameters.Add("@l", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value;
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.label2.Text;
						string cmdText4 = "insert into ds_mp (id_demande, id_article, qt) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = this.label2.Text;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value;
						sqlCommand4.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView1.Rows[j].Cells[2].Value);
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
					MessageBox.Show("Enregistrement avec succés");
				}
				else
				{
					MessageBox.Show("Erreur : La quantité doit être un réel strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				string cmdText5 = "update article set stock_neuf = stock_neuf + t2.qt from article t1 inner join ds_mp t2 on t1.id = t2.id_article where t2.id_demande = @i";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = this.label2.Text;
				string cmdText6 = "delete ds_mp where id_demande = @i";
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
				sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = this.label2.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand5.ExecuteNonQuery();
				sqlCommand6.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Enregistrement avec succés");
			}
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x001F9717 File Offset: 0x001F7917
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.select_mp();
		}

		// Token: 0x0400108B RID: 4235
		public static string id_ds;
	}
}
