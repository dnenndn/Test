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
	// Token: 0x02000088 RID: 136
	public partial class liste_budget_fournisseur : Form
	{
		// Token: 0x06000668 RID: 1640 RVA: 0x0010F6BC File Offset: 0x0010D8BC
		public liste_budget_fournisseur()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter_frn;
			this.dataGridView2.CellClick += this.DataGridView2_CellClick;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0010F71C File Offset: 0x0010D91C
		private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 2;
			if (flag)
			{
				string text = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					this.dataGridView2.Rows.RemoveAt(e.RowIndex);
				}
			}
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0010F7A8 File Offset: 0x0010D9A8
		private void liste_budget_fournisseur_Load(object sender, EventArgs e)
		{
			this.select_fournisseur();
			this.id_bud = liste_budget.id_budget;
			bd bd = new bd();
			string cmdText = "select fournisseur_choix from budget where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 1;
				if (flag2)
				{
					this.radRadioButton8.IsChecked = true;
					this.panel5.Visible = false;
				}
				bool flag3 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 2;
				if (flag3)
				{
					this.radRadioButton7.IsChecked = true;
					this.radRadioButton12.IsChecked = true;
					this.panel5.Visible = true;
					this.liste_fournisseur_choix();
				}
				bool flag4 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 3;
				if (flag4)
				{
					this.radRadioButton7.IsChecked = true;
					this.radRadioButton11.IsChecked = true;
					this.panel5.Visible = true;
					this.liste_fournisseur_choix();
				}
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0010F914 File Offset: 0x0010DB14
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton8.IsChecked;
			if (isChecked)
			{
				this.panel5.Visible = false;
			}
			else
			{
				this.panel5.Visible = true;
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0010F954 File Offset: 0x0010DB54
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.panel5.Visible = true;
			}
			else
			{
				this.panel5.Visible = false;
			}
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0010F994 File Offset: 0x0010DB94
		private void select_fournisseur()
		{
			this.radTreeView2.Nodes.Clear();
			this.dataGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, code_fournisseur, nom from fournisseur where deleted = @d";
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
					this.radTreeView2.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0010FAF8 File Offset: 0x0010DCF8
		private void click_ajouter_frn(object sender, EventArgs e)
		{
			bool flag = this.radTreeView2.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView2.SelectedNode;
				bool flag2 = this.search_tableau_frn(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.dataGridView2.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.Text
					});
				}
				else
				{
					MessageBox.Show("Erreur : Le fournisseur est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0010FB88 File Offset: 0x0010DD88
		private int search_tableau_frn(string s)
		{
			int result = 0;
			bool flag = this.dataGridView2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.dataGridView2.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0010FC0F File Offset: 0x0010DE0F
		private void guna2TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView2.Filter = this.guna2TextBox3.Text;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0010FC2C File Offset: 0x0010DE2C
		private void liste_fournisseur_choix()
		{
			bd bd = new bd();
			string cmdText = "select id, nom from fournisseur where id in (select id_fournisseur from budget_fournisseur where id_budget = @i)";
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
					this.dataGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0],
						dataTable.Rows[i].ItemArray[1]
					});
				}
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0010FD08 File Offset: 0x0010DF08
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "delete budget_fournisseur where id_budget = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			int num = 1;
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				num = 2;
				bool isChecked2 = this.radRadioButton11.IsChecked;
				if (isChecked2)
				{
					num = 3;
				}
			}
			string cmdText2 = "update budget set fournisseur_choix = @z where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			sqlCommand2.Parameters.Add("@z", SqlDbType.Int).Value = num;
			bd.ouverture_bd(bd.cnn);
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			bool flag = !this.radRadioButton8.IsChecked;
			if (flag)
			{
				bool flag2 = this.dataGridView2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
					{
						string cmdText3 = "insert into budget_fournisseur (id_budget, id_fournisseur) values(@v1, @v2)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = this.id_bud;
						sqlCommand3.Parameters.Add("@v2", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
			MessageBox.Show("Modification avec succés");
			base.Close();
		}

		// Token: 0x04000878 RID: 2168
		private string id_bud = "";
	}
}
