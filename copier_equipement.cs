using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200004F RID: 79
	public partial class copier_equipement : Form
	{
		// Token: 0x06000373 RID: 883 RVA: 0x0009215E File Offset: 0x0009035E
		public copier_equipement()
		{
			this.InitializeComponent();
			this.arbre.NodeExpandedChanged += new RadTreeView.TreeViewEventHandler(this.select_expand);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00092190 File Offset: 0x00090390
		private void copier_equipement_Load(object sender, EventArgs e)
		{
			this.arbre.ShowNodeToolTips = true;
			this.arbre.CheckBoxes = true;
			this.arbre.ShowLines = true;
			this.arbre_cloner.ShowNodeToolTips = true;
			this.arbre_cloner.ShowLines = true;
			this.guna2NumericUpDown1.Minimum = 1m;
			this.arbre.TreeViewElement.AllowAlternatingRowColor = true;
			this.arbre_cloner.TreeViewElement.AllowAlternatingRowColor = true;
			this.load_arbre();
			this.load_arbre_cloner(Arbre_Equipement.id_copier);
			this.arbre_cloner.ExpandAll();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00092234 File Offset: 0x00090434
		private void select_arbre(int r, RadTreeNode n)
		{
			bd bd = new bd();
			string cmdText = "select id, code, designation from equipement where id_parent = @r and deleted = @d order by ordre";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = r;
			sqlCommand.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					RadTreeNode radTreeNode = n.Nodes.Add("");
					radTreeNode.Value = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = num.ToString();
					radTreeNode.ImageIndex = 1;
				}
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0009237C File Offset: 0x0009057C
		private void select_arbre_coppier(int r, RadTreeNode n)
		{
			bd bd = new bd();
			string cmdText = "select id, code, designation from equipement where id_parent = @r and deleted = @d order by ordre";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = r;
			sqlCommand.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int r2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					RadTreeNode radTreeNode = n.Nodes.Add("");
					radTreeNode.Value = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = r2.ToString();
					radTreeNode.ImageIndex = 1;
					this.select_arbre_coppier(r2, radTreeNode);
				}
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000924D0 File Offset: 0x000906D0
		public void load_arbre()
		{
			this.arbre.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, code, designation from equipement where id_parent = @r and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				RadTreeNode radTreeNode = this.arbre.Nodes.Add("");
				radTreeNode.Value = dataTable.Rows[0].ItemArray[2].ToString();
				radTreeNode.ToolTipText = dataTable.Rows[0].ItemArray[1].ToString();
				radTreeNode.Tag = dataTable.Rows[0].ItemArray[0].ToString();
				radTreeNode.ImageIndex = 1;
				int r = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				this.select_arbre(r, radTreeNode);
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00092620 File Offset: 0x00090820
		public void load_arbre_cloner(string ss)
		{
			this.arbre_cloner.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, code, designation from equipement where id = @r and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = ss;
			sqlCommand.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				RadTreeNode radTreeNode = this.arbre_cloner.Nodes.Add("");
				radTreeNode.Value = dataTable.Rows[0].ItemArray[2].ToString();
				radTreeNode.ToolTipText = dataTable.Rows[0].ItemArray[1].ToString();
				radTreeNode.Tag = dataTable.Rows[0].ItemArray[0].ToString();
				radTreeNode.ImageIndex = 1;
				int r = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				this.select_arbre_coppier(r, radTreeNode);
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00092768 File Offset: 0x00090968
		private void couleur_node_checked(object sender, TreeNodeCheckedEventArgs e)
		{
			bool @checked = e.Node.Checked;
			if (@checked)
			{
				e.Node.BackColor = Color.Yellow;
			}
			else
			{
				e.Node.BackColor = Color.White;
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000927B0 File Offset: 0x000909B0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.guna2NumericUpDown1.Value);
			List<RadTreeNode> list = this.CheckedNodes(this.arbre);
			int count = list.Count;
			bool flag = count != 0;
			if (flag)
			{
				bd bd = new bd();
				foreach (RadTreeNode radTreeNode in list)
				{
					int num2 = 1;
					string value = radTreeNode.Tag.ToString();
					string cmdText = "select max(ordre) from equipement where id_parent = @i and deleted =@d";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						bool flag3 = dataTable.Rows[0].ItemArray[0].ToString() != "";
						if (flag3)
						{
							num2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) + 1;
						}
					}
					for (int i = 0; i < num; i++)
					{
						string cmdText2 = "select code, designation, id from equipement where deleted = @d and id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.nd_cloner.Tag;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							string cmdText3 = "insert into equipement (id_parent, code, designation, ordre, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = value;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = dataTable2.Rows[0].ItemArray[0];
							sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = dataTable2.Rows[0].ItemArray[1];
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = num2;
							sqlCommand3.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							int id_pr = (int)sqlCommand3.ExecuteScalar();
							bd.cnn.Close();
							this.save_copier(id_pr, Convert.ToInt32(Arbre_Equipement.id_copier));
							num2++;
						}
					}
				}
				MessageBox.Show("Cloner avec succès");
				base.Close();
			}
			else
			{
				MessageBox.Show("Erreur : Choisir au moin un equipement parent");
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00092AFC File Offset: 0x00090CFC
		private void FindCheckedNodes(List<RadTreeNode> checked_nodes, RadTreeNodeCollection nodes)
		{
			foreach (RadTreeNode radTreeNode in nodes)
			{
				bool @checked = radTreeNode.Checked;
				if (@checked)
				{
					checked_nodes.Add(radTreeNode);
				}
				this.FindCheckedNodes(checked_nodes, radTreeNode.Nodes);
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00092B64 File Offset: 0x00090D64
		private List<RadTreeNode> CheckedNodes(RadTreeView trv)
		{
			List<RadTreeNode> list = new List<RadTreeNode>();
			this.FindCheckedNodes(list, trv.Nodes);
			return list;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00092B8C File Offset: 0x00090D8C
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			List<RadTreeNode> list = this.ClonedNodes(Arbre_Equipement.nd_cloner);
			foreach (RadTreeNode radTreeNode in list)
			{
				MessageBox.Show(radTreeNode.Tag.ToString());
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00092BF8 File Offset: 0x00090DF8
		private void save_copier(int id_pr, int id_p)
		{
			bd bd = new bd();
			string cmdText = "select code, designation, ordre, id from equipement where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_p;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "insert into equipement (id_parent, code, designation, ordre, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_pr;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = dataTable.Rows[i].ItemArray[0];
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = dataTable.Rows[i].ItemArray[1];
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[2];
					sqlCommand2.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					int id_pr2 = (int)sqlCommand2.ExecuteScalar();
					bd.cnn.Close();
					this.save_copier(id_pr2, Convert.ToInt32(dataTable.Rows[i].ItemArray[3]));
				}
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00092DD8 File Offset: 0x00090FD8
		private void FindcloneNodes(List<RadTreeNode> checked_nodes, RadTreeNodeCollection nodes)
		{
			foreach (RadTreeNode radTreeNode in nodes)
			{
				checked_nodes.Add(radTreeNode);
				this.FindcloneNodes(checked_nodes, radTreeNode.Nodes);
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00092E34 File Offset: 0x00091034
		private List<RadTreeNode> ClonedNodes(RadTreeNode trv)
		{
			List<RadTreeNode> list = new List<RadTreeNode>();
			this.FindcloneNodes(list, trv.Nodes);
			return list;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00092E5C File Offset: 0x0009105C
		private void select_expand(object sender, RadTreeViewEventArgs e)
		{
			e.Node.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, code, designation from equipement where id_parent = @r and deleted = @d order by ordre";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = e.Node.Tag.ToString();
			sqlCommand.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = e.Node.Nodes.Add("");
					radTreeNode.Value = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ImageIndex = 1;
					int r = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					this.select_arbre(r, radTreeNode);
				}
			}
		}
	}
}
