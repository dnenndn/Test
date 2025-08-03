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
	// Token: 0x02000072 RID: 114
	public partial class Equipement_di : Form
	{
		// Token: 0x0600054E RID: 1358 RVA: 0x000E0F24 File Offset: 0x000DF124
		public Equipement_di()
		{
			this.InitializeComponent();
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
			this.radMenuItem1.Click += this.click_secteur;
			this.radMenuItem2.Click += this.click_equipement;
			this.radMenuItem3.Click += this.click_sous_equipement;
			this.radMenuItem4.Click += this.click_organe;
			this.radMenuItem5.Click += this.click_filtre;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000E0FFC File Offset: 0x000DF1FC
		private void Equipement_di_Load(object sender, EventArgs e)
		{
			bool flag = Demande_Intervention.insr_or_filtre == "insr";
			if (flag)
			{
				this.radMenuItem1.Visibility = 0;
				this.radMenuItem2.Visibility = 0;
				this.radMenuItem3.Visibility = 0;
				this.radMenuItem4.Visibility = 0;
				this.radMenuItem5.Visibility = 2;
			}
			else
			{
				this.radMenuItem1.Visibility = 2;
				this.radMenuItem2.Visibility = 2;
				this.radMenuItem3.Visibility = 2;
				this.radMenuItem4.Visibility = 2;
				this.radMenuItem5.Visibility = 0;
			}
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x000E10A8 File Offset: 0x000DF2A8
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

		// Token: 0x06000551 RID: 1361 RVA: 0x000E1160 File Offset: 0x000DF360
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

		// Token: 0x06000552 RID: 1362 RVA: 0x000E1434 File Offset: 0x000DF634
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x000E149C File Offset: 0x000DF69C
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

		// Token: 0x06000554 RID: 1364 RVA: 0x000E160E File Offset: 0x000DF80E
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.ExpandAll();
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x000E1634 File Offset: 0x000DF834
		private void click_secteur(object sender, EventArgs e)
		{
			bool flag = Demande_Intervention.insr_or_filtre == "insr";
			if (flag)
			{
				bool flag2 = this.arbre.SelectedNode != null;
				if (flag2)
				{
					string value = this.arbre.SelectedNode.Tag.ToString();
					bd bd = new bd();
					string cmdText = "select code from equipement where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					string value2 = dataTable.Rows[0].ItemArray[0].ToString();
					string value3 = this.arbre.SelectedNode.Text.ToString();
					Demande_Intervention.radGridView3.Rows[0].Cells[1].Value = value;
					Demande_Intervention.radGridView3.Rows[0].Cells[2].Value = value2;
					Demande_Intervention.radGridView3.Rows[0].Cells[3].Value = value3;
				}
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x000E1770 File Offset: 0x000DF970
		private void click_equipement(object sender, EventArgs e)
		{
			bool flag = Demande_Intervention.insr_or_filtre == "insr";
			if (flag)
			{
				bool flag2 = this.arbre.SelectedNode != null;
				if (flag2)
				{
					string value = this.arbre.SelectedNode.Tag.ToString();
					bd bd = new bd();
					string cmdText = "select code from equipement where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					string value2 = dataTable.Rows[0].ItemArray[0].ToString();
					string value3 = this.arbre.SelectedNode.Text.ToString();
					Demande_Intervention.radGridView3.Rows[1].Cells[1].Value = value;
					Demande_Intervention.radGridView3.Rows[1].Cells[2].Value = value2;
					Demande_Intervention.radGridView3.Rows[1].Cells[3].Value = value3;
				}
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000E18AC File Offset: 0x000DFAAC
		private void click_sous_equipement(object sender, EventArgs e)
		{
			bool flag = Demande_Intervention.insr_or_filtre == "insr";
			if (flag)
			{
				bool flag2 = this.arbre.SelectedNode != null;
				if (flag2)
				{
					string value = this.arbre.SelectedNode.Tag.ToString();
					bd bd = new bd();
					string cmdText = "select code from equipement where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					string value2 = dataTable.Rows[0].ItemArray[0].ToString();
					string value3 = this.arbre.SelectedNode.Text.ToString();
					Demande_Intervention.radGridView3.Rows[2].Cells[1].Value = value;
					Demande_Intervention.radGridView3.Rows[2].Cells[2].Value = value2;
					Demande_Intervention.radGridView3.Rows[2].Cells[3].Value = value3;
				}
			}
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x000E19E8 File Offset: 0x000DFBE8
		private void click_organe(object sender, EventArgs e)
		{
			bool flag = Demande_Intervention.insr_or_filtre == "insr";
			if (flag)
			{
				bool flag2 = this.arbre.SelectedNode != null;
				if (flag2)
				{
					string value = this.arbre.SelectedNode.Tag.ToString();
					bd bd = new bd();
					string cmdText = "select code from equipement where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					string value2 = dataTable.Rows[0].ItemArray[0].ToString();
					string value3 = this.arbre.SelectedNode.Text.ToString();
					Demande_Intervention.radGridView3.Rows[3].Cells[1].Value = value;
					Demande_Intervention.radGridView3.Rows[3].Cells[2].Value = value2;
					Demande_Intervention.radGridView3.Rows[3].Cells[3].Value = value3;
				}
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x000E1B24 File Offset: 0x000DFD24
		private void click_filtre(object sender, EventArgs e)
		{
			bool flag = Demande_Intervention.insr_or_filtre == "filtre";
			if (flag)
			{
				bool flag2 = this.arbre.SelectedNode != null;
				if (flag2)
				{
					Demande_Intervention.radGridView2.Rows.Add(new object[]
					{
						"",
						"",
						"",
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
					string value = this.arbre.SelectedNode.Tag.ToString();
					bd bd = new bd();
					string cmdText = "select code from equipement where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					string value2 = dataTable.Rows[0].ItemArray[0].ToString();
					string value3 = this.arbre.SelectedNode.Text.ToString();
					int num = Demande_Intervention.radGridView2.Rows.Count - 1;
					Demande_Intervention.radGridView2.Rows[num].Cells[0].Value = value;
					Demande_Intervention.radGridView2.Rows[num].Cells[1].Value = value2;
					Demande_Intervention.radGridView2.Rows[num].Cells[2].Value = value3;
					Demande_Intervention.id_eq_filtre.Add(Convert.ToInt32(value));
					base.Close();
				}
			}
			bool flag3 = Demande_Intervention.insr_or_filtre == "filtre_ot";
			if (flag3)
			{
				bool flag4 = this.arbre.SelectedNode != null;
				if (flag4)
				{
					ordre_travail.radGridView2.Rows.Add(new object[]
					{
						"",
						"",
						"",
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
					string value4 = this.arbre.SelectedNode.Tag.ToString();
					bd bd2 = new bd();
					string cmdText2 = "select code from equipement where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value4;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string value5 = dataTable2.Rows[0].ItemArray[0].ToString();
					string value6 = this.arbre.SelectedNode.Text.ToString();
					int num2 = ordre_travail.radGridView2.Rows.Count - 1;
					ordre_travail.radGridView2.Rows[num2].Cells[0].Value = value4;
					ordre_travail.radGridView2.Rows[num2].Cells[1].Value = value5;
					ordre_travail.radGridView2.Rows[num2].Cells[2].Value = value6;
					ordre_travail.id_eq_filtre.Add(Convert.ToInt32(value4));
					base.Close();
				}
			}
		}
	}
}
