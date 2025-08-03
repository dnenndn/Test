using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000087 RID: 135
	public partial class liste_budget_categorie : Form
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x0010DA24 File Offset: 0x0010BC24
		public liste_budget_categorie()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
			this.dataGridView1.CellClick += this.DataGridView1_CellClick;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0010DA84 File Offset: 0x0010BC84
		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 2;
			if (flag)
			{
				string text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bool flag3 = !this.radRadioButton10.IsChecked;
					if (flag3)
					{
						this.dataGridView1.Rows.RemoveAt(e.RowIndex);
					}
					else
					{
						MessageBox.Show("Erreur : Vous cochez Tous, la suppression est impossible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0010DB40 File Offset: 0x0010BD40
		private void liste_budget_categorie_Load(object sender, EventArgs e)
		{
			this.label8.Text = "";
			this.id_bud = liste_budget.id_budget;
			bd bd = new bd();
			string cmdText = "select categorie, categorie_choix from budget where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]) == 1;
				if (flag2)
				{
					this.radRadioButton10.IsChecked = true;
				}
				bool flag3 = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]) == 2;
				if (flag3)
				{
					this.radRadioButton9.IsChecked = true;
				}
				bool flag4 = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]) == 3;
				if (flag4)
				{
					this.radRadioButton6.IsChecked = true;
				}
				bool flag5 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 1;
				if (flag5)
				{
					this.label8.Text = "Famille";
					this.select_famille();
					this.select_famille_choisit();
				}
				bool flag6 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 2;
				if (flag6)
				{
					this.label8.Text = "Sous Famille";
					this.select_sous_famille();
					this.select_sous_famille_choisit();
				}
				bool flag7 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 3;
				if (flag7)
				{
					this.label8.Text = "Article";
					this.select_article();
					this.select_article_choisit();
				}
			}
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0010DD30 File Offset: 0x0010BF30
		private void select_famille_choisit()
		{
			bool isChecked = this.radRadioButton10.IsChecked;
			if (isChecked)
			{
				this.dataGridView1.Rows.Clear();
				foreach (RadTreeNode radTreeNode in this.radTreeView1.Nodes)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(radTreeNode.Tag),
						radTreeNode.Text
					});
				}
			}
			else
			{
				bd bd = new bd();
				string cmdText = "select id, designation from famille where id in (select id_categorie from budget_categorie where id_budget = @i)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.dataGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0],
							dataTable.Rows[i].ItemArray[1]
						});
					}
				}
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0010DEAC File Offset: 0x0010C0AC
		private void select_sous_famille_choisit()
		{
			bool isChecked = this.radRadioButton10.IsChecked;
			if (isChecked)
			{
				this.dataGridView1.Rows.Clear();
				foreach (RadTreeNode radTreeNode in this.radTreeView1.Nodes)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(radTreeNode.Tag),
						radTreeNode.Text
					});
				}
			}
			else
			{
				bd bd = new bd();
				string cmdText = "select id, designation from sous_famille where id in (select id_categorie from budget_categorie where id_budget = @i)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.dataGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0],
							dataTable.Rows[i].ItemArray[1]
						});
					}
				}
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0010E028 File Offset: 0x0010C228
		private void select_article_choisit()
		{
			bool isChecked = this.radRadioButton10.IsChecked;
			if (isChecked)
			{
				this.dataGridView1.Rows.Clear();
				foreach (RadTreeNode radTreeNode in this.radTreeView1.Nodes)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(radTreeNode.Tag),
						radTreeNode.Text
					});
				}
			}
			else
			{
				bd bd = new bd();
				string cmdText = "select id, designation from article where id in (select id_categorie from budget_categorie where id_budget = @i)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.dataGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0],
							dataTable.Rows[i].ItemArray[1]
						});
					}
				}
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0010E1A4 File Offset: 0x0010C3A4
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0010E1C0 File Offset: 0x0010C3C0
		private void select_article()
		{
			this.radTreeView1.Nodes.Clear();
			this.dataGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, reference, designation from article where deleted = @d";
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
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.Value = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0010E324 File Offset: 0x0010C524
		private void select_sous_famille()
		{
			this.radTreeView1.Nodes.Clear();
			this.dataGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, code_sous_famille, designation from sous_famille where deleted = @d";
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
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.Value = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0010E488 File Offset: 0x0010C688
		private void select_famille()
		{
			this.radTreeView1.Nodes.Clear();
			this.dataGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, code_famille, designation from famille where deleted = @d";
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
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.Value = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0010E5EC File Offset: 0x0010C7EC
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.Text
					});
				}
				else
				{
					bool flag3 = this.label8.Text == "Famille";
					if (flag3)
					{
						MessageBox.Show("Erreur : La Famille est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					bool flag4 = this.label8.Text == "Sous Famille";
					if (flag4)
					{
						MessageBox.Show("Erreur : La Sous Famille est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					bool flag5 = this.label8.Text == "Article";
					if (flag5)
					{
						MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0010E6FC File Offset: 0x0010C8FC
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.dataGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0010E784 File Offset: 0x0010C984
		private void radRadioButton10_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton10.IsChecked;
			if (isChecked)
			{
				this.dataGridView1.Rows.Clear();
				foreach (RadTreeNode radTreeNode in this.radTreeView1.Nodes)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(radTreeNode.Tag),
						radTreeNode.Text
					});
				}
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0010E824 File Offset: 0x0010CA24
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "delete budget_categorie where id_budget = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			int num = 1;
			bool isChecked = this.radRadioButton9.IsChecked;
			if (isChecked)
			{
				num = 2;
			}
			bool isChecked2 = this.radRadioButton6.IsChecked;
			if (isChecked2)
			{
				num = 3;
			}
			string cmdText2 = "update budget set categorie_choix = @z where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			sqlCommand2.Parameters.Add("@z", SqlDbType.Int).Value = num;
			bd.ouverture_bd(bd.cnn);
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			bool flag = !this.radRadioButton10.IsChecked;
			if (flag)
			{
				bool flag2 = this.dataGridView1.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string cmdText3 = "insert into budget_categorie (id_budget, id_categorie) values(@v1, @v2)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = this.id_bud;
						sqlCommand3.Parameters.Add("@v2", SqlDbType.Int).Value = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
			MessageBox.Show("Modification avec succés");
			base.Close();
		}

		// Token: 0x04000864 RID: 2148
		private string id_bud = "";
	}
}
