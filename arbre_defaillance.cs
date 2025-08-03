using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.Windows.Diagrams.Core;

namespace GMAO
{
	// Token: 0x0200001B RID: 27
	public partial class arbre_defaillance : Form
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00041A0C File Offset: 0x0003FC0C
		public arbre_defaillance()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
			this.radMenuItem2.Click += this.click_supprimer;
			this.select_defaillance();
			this.radDiagram1.ThemeName = "Crystal";
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00041A82 File Offset: 0x0003FC82
		private void arbre_defaillance_Load(object sender, EventArgs e)
		{
			this.radDiagram1.Size = new Size(1000, 420);
			this.panel1.Visible = false;
			this.panel2.Visible = false;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00041ABC File Offset: 0x0003FCBC
		private void construire_arbre(string code_a, string defaillance_a)
		{
			this.radDiagram1.Items.Clear();
			TreeLayoutSettings treeLayoutSettings = new TreeLayoutSettings
			{
				TreeLayoutType = 5,
				VerticalDistance = 15.0
			};
			RadDiagramShape radDiagramShape = new RadDiagramShape();
			radDiagramShape.Text = code_a;
			radDiagramShape.ToolTipText = defaillance_a;
			radDiagramShape.Size = new Size(120, 30);
			radDiagramShape.BackColor = Color.White;
			radDiagramShape.ForeColor = Color.Firebrick;
			radDiagramShape.Cursor = Cursors.Hand;
			radDiagramShape.BorderBrush = new SolidBrush(Color.Firebrick);
			radDiagramShape.DrawBorder = true;
			radDiagramShape.ElementShape = new RoundRectShape(4);
			radDiagramShape.Position = new Point(394.0, 10.0);
			this.radDiagram1.Items.Add(radDiagramShape);
			bd bd = new bd();
			string cmdText = "select id from parametre_anomalie where code = @v";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = code_a;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string text = dataTable.Rows[0].ItemArray[0].ToString();
				this.id_pr = text;
				radDiagramShape.Tag = text;
				this.get_relation(text, radDiagramShape);
			}
			treeLayoutSettings.Roots.Add(this.radDiagram1.Shapes[0]);
			this.radDiagram1.SetLayout(1, treeLayoutSettings);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00041C5F File Offset: 0x0003FE5F
		private void Lyt(object sender, RoutedEventArgs e)
		{
			this.radDiagram1.LayoutAsync(0, null);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00041C70 File Offset: 0x0003FE70
		private void select_defaillance()
		{
			this.radDropDownList6.Items.Clear();
			string cmdText = "select code, anomalie from parametre_anomalie where deleted = @d order by code";
			bd bd = new bd();
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
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00041D78 File Offset: 0x0003FF78
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.panel2.Visible = false;
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				this.TextBox2.Text = this.radDropDownList6.SelectedItem.Tag.ToString();
				this.construire_arbre(this.radDropDownList6.Text, this.radDropDownList6.SelectedItem.Tag.ToString());
				this.load_arbre();
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00041E00 File Offset: 0x00040000
		private void get_relation(string id_parent, RadDiagramShape an_d)
		{
			bd bd = new bd();
			string cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_parent;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select operateur from parametre_anomalie where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id_parent;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string text = dataTable2.Rows[0].ItemArray[0].ToString();
				RadDiagramShape radDiagramShape = new RadDiagramShape();
				radDiagramShape.Text = text;
				radDiagramShape.Size = new Size(30, 30);
				radDiagramShape.BackColor = Color.White;
				radDiagramShape.ForeColor = Color.Blue;
				radDiagramShape.Cursor = Cursors.Hand;
				radDiagramShape.BorderBrush = new SolidBrush(Color.Blue);
				radDiagramShape.DrawBorder = true;
				radDiagramShape.ElementShape = new CircleShape();
				RadDiagramConnection radDiagramConnection = new RadDiagramConnection();
				radDiagramConnection.Source = an_d;
				radDiagramConnection.Target = radDiagramShape;
				radDiagramConnection.TargetCapType = 2;
				this.radDiagram1.Items.Add(radDiagramShape);
				this.radDiagram1.Items.Add(radDiagramConnection);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text2 = dataTable.Rows[i].ItemArray[0].ToString();
					RadDiagramShape radDiagramShape2 = new RadDiagramShape();
					radDiagramShape2.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radDiagramShape2.Tag = text2;
					radDiagramShape2.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					radDiagramShape2.Size = new Size(120, 30);
					radDiagramShape2.BackColor = Color.White;
					radDiagramShape2.ForeColor = Color.Firebrick;
					radDiagramShape2.Cursor = Cursors.Hand;
					radDiagramShape2.BorderBrush = new SolidBrush(Color.Firebrick);
					radDiagramShape2.DrawBorder = true;
					radDiagramShape2.ElementShape = new RoundRectShape(4);
					RadDiagramConnection radDiagramConnection2 = new RadDiagramConnection();
					radDiagramConnection2.Source = radDiagramShape;
					radDiagramConnection2.Target = radDiagramShape2;
					radDiagramConnection2.TargetCapType = 2;
					this.radDiagram1.Items.Add(radDiagramShape2);
					this.radDiagram1.Items.Add(radDiagramConnection2);
					this.get_relation(text2, radDiagramShape2);
				}
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000420FC File Offset: 0x000402FC
		private double position_levelx(double y, double a_x)
		{
			int num = 0;
			foreach (IShape shape in this.radDiagram1.Shapes)
			{
				RadDiagramShape radDiagramShape = (RadDiagramShape)shape;
				bool flag = radDiagramShape.Position.Y == y;
				if (flag)
				{
					num++;
				}
			}
			double num2 = (double)(10 * (num + 1) + 150 * num);
			bool flag2 = num2 < a_x;
			if (flag2)
			{
				num2 = a_x - 70.0;
			}
			return num2;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000421A0 File Offset: 0x000403A0
		private void selectionner_info_parent(string id_parent, RadDiagramShape s)
		{
			this.panel1.Show();
			this.label3.Text = s.Tag.ToString();
			this.label4.Text = s.Text;
			this.radDropDownList1.Items.Clear();
			string cmdText = "select code, anomalie from parametre_anomalie where deleted = @d and id <> @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_parent;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000422F3 File Offset: 0x000404F3
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.panel2.Visible = false;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00042304 File Offset: 0x00040504
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.guna2TextBox1.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00042350 File Offset: 0x00040550
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				this.radDiagram1.Size = new Size(439, 390);
				this.panel1.Show();
				this.load_arbre();
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000423A8 File Offset: 0x000405A8
		private void load_arbre()
		{
			this.arbre.TreeViewElement.AllowAlternatingRowColor = true;
			this.arbre.ShowNodeToolTips = true;
			this.arbre.ShowLines = true;
			this.arbre.Nodes.Clear();
			RadTreeNode radTreeNode = new RadTreeNode();
			radTreeNode.Tag = this.id_pr;
			radTreeNode.Text = this.radDropDownList6.Text;
			radTreeNode.ToolTipText = this.radDropDownList6.SelectedItem.Tag.ToString();
			this.arbre.Nodes.Add(radTreeNode);
			this.select_arbre(Convert.ToInt32(this.id_pr), radTreeNode);
			this.arbre.ExpandAll();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00042468 File Offset: 0x00040668
		private void select_arbre(int r, RadTreeNode n)
		{
			n.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = r;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select operateur from parametre_anomalie where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = r;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int r2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = r2.ToString();
					n.Nodes.Add(radTreeNode);
					this.select_arbre(r2, radTreeNode);
				}
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0004260C File Offset: 0x0004080C
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				this.panel2.Visible = true;
				RadTreeNode selectedNode = this.arbre.SelectedNode;
				string text = this.arbre.SelectedNode.Tag.ToString();
				string text2 = this.arbre.SelectedNode.Text.ToString();
				this.label3.Text = text;
				this.label4.Text = text2;
				this.select_possible_defaillance(text, selectedNode);
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00042698 File Offset: 0x00040898
		private void click_supprimer(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					RadTreeNode selectedNode = this.arbre.SelectedNode;
					RadTreeNode parent = this.arbre.SelectedNode.Parent;
					bool flag3 = parent != null;
					if (flag3)
					{
						string value = this.arbre.SelectedNode.Tag.ToString();
						string value2 = parent.Tag.ToString();
						bd bd = new bd();
						string cmdText = "delete relation_anomalie where id_parent = @i1 and id_anomalie = @i2";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = value2;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.panel2.Visible = false;
						this.construire_arbre(this.radDropDownList6.Text, this.radDropDownList6.SelectedItem.Tag.ToString());
						this.load_arbre();
					}
					else
					{
						MessageBox.Show("Erreur : Impossible de supprimer la défaillance racine", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000427F8 File Offset: 0x000409F8
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radDiagram1.Size = new Size(1000, 420);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00042824 File Offset: 0x00040A24
		private void select_possible_defaillance(string id_parent, RadTreeNode h)
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			List<string> list = new List<string>();
			foreach (RadTreeNode radTreeNode in h.Nodes)
			{
				list.Add(radTreeNode.Tag.ToString());
			}
			List<RadTreeNode> list2 = this.TagedNodes(this.arbre, id_parent);
			foreach (RadTreeNode radTreeNode2 in list2)
			{
				list.Add(radTreeNode2.Tag.ToString());
				this.all_parent(radTreeNode2, list);
			}
			string str = string.Join(",", list.ToArray());
			string cmdText = "select code, anomalie from parametre_anomalie where deleted = @d and id not in (" + str + ") order by code";
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
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00042A10 File Offset: 0x00040C10
		private void all_parent(RadTreeNode n, List<string> l)
		{
			bool flag = n.Parent != null;
			if (flag)
			{
				RadTreeNode parent = n.Parent;
				l.Add(parent.Tag.ToString());
				this.all_parent(parent, l);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00042A50 File Offset: 0x00040C50
		private void FindBytag(List<RadTreeNode> checked_nodes, RadTreeNodeCollection nodes, string id_parent)
		{
			foreach (RadTreeNode radTreeNode in nodes)
			{
				bool flag = radTreeNode.Tag.ToString() == id_parent;
				if (flag)
				{
					checked_nodes.Add(radTreeNode);
				}
				this.FindBytag(checked_nodes, radTreeNode.Nodes, id_parent);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00042AC4 File Offset: 0x00040CC4
		private List<RadTreeNode> TagedNodes(RadTreeView trv, string id_parent)
		{
			List<RadTreeNode> list = new List<RadTreeNode>();
			this.FindBytag(list, trv.Nodes, id_parent);
			return list;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00042AEC File Offset: 0x00040CEC
		private void radDropDownList1_SelectedIndexChanged_1(object sender, PositionChangedEventArgs e)
		{
			this.guna2TextBox1.Clear();
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.guna2TextBox1.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00042B44 File Offset: 0x00040D44
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				string cmdText = "select id from parametre_anomalie where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string value = dataTable.Rows[0].ItemArray[0].ToString();
				string cmdText2 = "insert into relation_anomalie (id_anomalie, id_parent) values (@v1, @v2)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = this.label3.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Enregistrement avec succés");
				this.panel2.Visible = false;
				this.construire_arbre(this.radDropDownList6.Text, this.radDropDownList6.SelectedItem.Tag.ToString());
				this.load_arbre();
			}
			else
			{
				MessageBox.Show("Erreur : Veuillez choisir la cause de défaillance", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00042CB4 File Offset: 0x00040EB4
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "My Files(*.PNG)|*.png|All files (*.*)|*.*";
			saveFileDialog.ShowDialog();
			bool flag = saveFileDialog.FileName != "";
			if (flag)
			{
				Image image = this.radDiagram1.ExportToImage();
				image.Save(saveFileDialog.FileName);
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00042D0A File Offset: 0x00040F0A
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			this.radDiagram1.PrintPreview();
		}

		// Token: 0x0400021F RID: 543
		private string id_pr = "";
	}
}
