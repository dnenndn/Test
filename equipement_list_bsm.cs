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
	// Token: 0x02000073 RID: 115
	public partial class equipement_list_bsm : Form
	{
		// Token: 0x0600055C RID: 1372 RVA: 0x000E25A0 File Offset: 0x000E07A0
		public equipement_list_bsm()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x000E2618 File Offset: 0x000E0818
		private void Arbre_NodeMouseMove(object sender, RadTreeViewMouseEventArgs e)
		{
			bool flag = e.Node.ToolTipText == null;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select code from equipement where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = e.Node.Tag;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					e.Node.ToolTipText = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
				}
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x000E26CD File Offset: 0x000E08CD
		private void equipement_list_bsm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x000E26D0 File Offset: 0x000E08D0
		public void load_arbre(int r)
		{
			this.arbre.DataSource = null;
			this.arbre.Nodes.Clear();
			DataTable dataTable = new DataTable();
			bd bd = new bd();
			string cmdText = "select id, designation from equipement where id_parent = @d and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			string cmdText2 = "select id, code, designation, id_parent from equipement where deleted = @d and id_parent <> @d order by ordre";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter2.Fill(dataTable3);
			dataTable.Columns.Clear();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("ParentID", typeof(int));
			dataTable.Columns.Add("Name", typeof(string));
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				dataTable.Rows.Add(new object[]
				{
					dataTable2.Rows[0].ItemArray[0].ToString(),
					null,
					dataTable2.Rows[0].ItemArray[1].ToString()
				});
				for (int i = 0; i < dataTable3.Rows.Count; i++)
				{
					dataTable.Rows.Add(new object[]
					{
						dataTable3.Rows[i].ItemArray[0].ToString(),
						dataTable3.Rows[i].ItemArray[3].ToString(),
						dataTable3.Rows[i].ItemArray[2].ToString()
					});
				}
				this.arbre.DataSource = dataTable;
				this.arbre.DisplayMember = "Name";
				this.arbre.ChildMember = "ID";
				this.arbre.ParentMember = "ParentID";
				this.arbre.ValueMember = "ID";
				this.arbre.Nodes[0].ImageIndex = 1;
				this.arbre.Nodes[0].Tag = dataTable.Rows[0].ItemArray[0].ToString();
				RadTreeNode n = this.arbre.Nodes[0];
				this.chargement_arbre(n);
			}
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x000E29A4 File Offset: 0x000E0BA4
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000E2A0C File Offset: 0x000E0C0C
		private void click_ajouter(object sender, EventArgs e)
		{
			historique_bsm.radGridView2.Rows.Clear();
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				string text = this.arbre.SelectedNode.Tag.ToString();
				string text2 = this.arbre.SelectedNode.Text.ToString();
				historique_bsm.radGridView2.Rows.Add(new object[]
				{
					text,
					text2,
					Resources.icons8_supprimer_pour_toujours_100__4_
				});
				base.Close();
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x000E2A97 File Offset: 0x000E0C97
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.ExpandAll();
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000E2AC0 File Offset: 0x000E0CC0
		private void TreeViewElement_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.guna2TextBox1.Text) != "";
			if (flag)
			{
				this.arbre.TreeViewElement.AllowAlternatingRowColor = false;
				bool flag2 = e.Node.Text.ToString().ToLower().Contains(this.guna2TextBox1.Text);
				if (flag2)
				{
					e.NodeElement.BorderColor = Color.Firebrick;
					e.NodeElement.BorderBoxStyle = 0;
					e.NodeElement.BorderGradientStyle = 0;
					e.NodeElement.ContentElement.ForeColor = Color.Firebrick;
				}
				else
				{
					e.NodeElement.ResetValue(LightVisualElement.BorderColorProperty, 32);
					e.NodeElement.ResetValue(LightVisualElement.BorderBoxStyleProperty, 32);
					e.NodeElement.ResetValue(LightVisualElement.BorderGradientStyleProperty, 32);
					e.NodeElement.ContentElement.ResetValue(VisualElement.ForeColorProperty, 32);
				}
			}
			else
			{
				this.arbre.TreeViewElement.AllowAlternatingRowColor = true;
				e.NodeElement.ResetValue(LightVisualElement.BorderColorProperty, 32);
				e.NodeElement.ResetValue(LightVisualElement.BorderBoxStyleProperty, 32);
				e.NodeElement.ResetValue(LightVisualElement.BorderGradientStyleProperty, 32);
				e.NodeElement.ContentElement.ResetValue(VisualElement.ForeColorProperty, 32);
			}
		}
	}
}
