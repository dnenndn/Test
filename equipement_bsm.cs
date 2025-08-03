using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000070 RID: 112
	public partial class equipement_bsm : Form
	{
		// Token: 0x0600053A RID: 1338 RVA: 0x000DF548 File Offset: 0x000DD748
		public equipement_bsm()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x000DF5C0 File Offset: 0x000DD7C0
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

		// Token: 0x0600053C RID: 1340 RVA: 0x000DF675 File Offset: 0x000DD875
		private void equipement_bsm_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x000DF678 File Offset: 0x000DD878
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

		// Token: 0x0600053E RID: 1342 RVA: 0x000DF94C File Offset: 0x000DDB4C
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x000DF9B4 File Offset: 0x000DDBB4
		private void click_ajouter(object sender, EventArgs e)
		{
			creer_bsm.radGridView2.Rows.Clear();
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				string text = this.arbre.SelectedNode.Tag.ToString();
				string text2 = this.arbre.SelectedNode.Text.ToString();
				creer_bsm.radGridView2.Rows.Add(new object[]
				{
					text,
					text2
				});
				base.Close();
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x000DFA37 File Offset: 0x000DDC37
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.ExpandAll();
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000DFA60 File Offset: 0x000DDC60
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
