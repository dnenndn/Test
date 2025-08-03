using System;
using System.Collections.Generic;
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
	// Token: 0x0200001C RID: 28
	public partial class Arbre_Equipement : Form
	{
		// Token: 0x0600017A RID: 378 RVA: 0x00044C78 File Offset: 0x00042E78
		public Arbre_Equipement()
		{
			this.InitializeComponent();
			Arbre_Equipement.arbre.Size = new Size(700, Arbre_Equipement.arbre.Size.Height);
			Arbre_Equipement.list_fichier();
			Arbre_Equipement.load_arbre(0);
			Arbre_Equipement.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			Arbre_Equipement.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
			Arbre_Equipement.arbre.CreateNodeElement += new CreateTreeNodeElementEventHandler(Arbre_Equipement.radTreeView1_CreateNodeElement);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00044D20 File Offset: 0x00042F20
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

		// Token: 0x0600017C RID: 380 RVA: 0x00044DD5 File Offset: 0x00042FD5
		private static void radTreeView1_CreateNodeElement(object sender, CreateTreeNodeElementEventArgs e)
		{
			e.NodeElement = new HostNodeElement();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00044DE4 File Offset: 0x00042FE4
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DimGray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00044E20 File Offset: 0x00043020
		private void Asrbre_Equipement_Load(object sender, EventArgs e)
		{
			Arbre_Equipement.Panel10.Hide();
			Arbre_Equipement.guna2Button2.Hide();
			Arbre_Equipement.arbre.TreeViewElement.AllowAlternatingRowColor = true;
			Arbre_Equipement.arbre.ShowNodeToolTips = true;
			Arbre_Equipement.arbre.ShowLines = true;
			this.radMenuItem1.Click += this.click_ajouter;
			this.radMenuItem2.Click += this.click_modifier;
			this.radMenuItem3.Click += Arbre_Equipement.click_afficher;
			this.radMenuItem5.Click += this.click_supprimer;
			this.radMenuItem4.Click += this.click_copier;
			this.x_test = 1;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00044EEC File Offset: 0x000430EC
		private static void select_arbre(int r, RadTreeNode n)
		{
			n.Nodes.Clear();
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
					radTreeNode.Value = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = num.ToString();
					radTreeNode.ImageIndex = 1;
				}
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00045060 File Offset: 0x00043260
		private void radContextMenu1_DropDownOpening(object sender, CancelEventArgs e)
		{
			Point point = Arbre_Equipement.arbre.PointToClient(Control.MousePosition);
			TreeNodeElement treeNodeElement = Arbre_Equipement.arbre.ElementTree.GetElementAtPoint(point) as TreeNodeElement;
			bool flag = treeNodeElement == null;
			if (!flag)
			{
				RadTreeNode data = treeNodeElement.Data;
				bool flag2 = data == null;
				if (!flag2)
				{
					this.clickedNode = data;
					this.radMenuItem1.Enabled = this.clickedNode.Enabled;
					this.radMenuItem2.Enabled = this.clickedNode.Enabled;
					this.radMenuItem3.Enabled = this.clickedNode.Enabled;
				}
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00045100 File Offset: 0x00043300
		private void button1_Click(object sender, EventArgs e)
		{
			ajouter_equipement ajouter_equipement = new ajouter_equipement();
			ajouter_equipement.Show();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0004511C File Offset: 0x0004331C
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = Arbre_Equipement.arbre.SelectedNode != null;
			if (flag)
			{
				Arbre_Equipement.guna2Button2_Click(sender, e);
				Arbre_Equipement.nd_ajouter = Arbre_Equipement.arbre.SelectedNode;
				Arbre_Equipement.id_parent = Arbre_Equipement.arbre.SelectedNode.Tag.ToString();
				Arbre_Equipement.des_parent = Arbre_Equipement.arbre.SelectedNode.Value.ToString();
				Arbre_Equipement.ordre = 0;
				string cmdText = "select max(ordre) from equipement where id_parent =@i and deleted = @d";
				bd bd = new bd();
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_parent;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					bool flag3 = Convert.ToString(dataTable.Rows[0].ItemArray[0]) != "";
					if (flag3)
					{
						Arbre_Equipement.ordre = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
					}
				}
				ajouter_equipement ajouter_equipement = new ajouter_equipement();
				ajouter_equipement.Show();
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0004526C File Offset: 0x0004346C
		public static void load_arbre(int r)
		{
			Arbre_Equipement.arbre.DataSource = null;
			Arbre_Equipement.arbre.Nodes.Clear();
			DataTable dataTable = new DataTable();
			bd bd = new bd();
			string cmdText = "select id, designation, code from equipement where id_parent = @d and deleted = @d";
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
			dataTable.Columns.Add("code", typeof(string));
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				dataTable.Rows.Add(new object[]
				{
					dataTable2.Rows[0].ItemArray[0].ToString(),
					null,
					dataTable2.Rows[0].ItemArray[1].ToString(),
					dataTable2.Rows[0].ItemArray[2].ToString()
				});
				for (int i = 0; i < dataTable3.Rows.Count; i++)
				{
					dataTable.Rows.Add(new object[]
					{
						dataTable3.Rows[i].ItemArray[0].ToString(),
						dataTable3.Rows[i].ItemArray[3].ToString(),
						dataTable3.Rows[i].ItemArray[2].ToString(),
						dataTable3.Rows[i].ItemArray[1].ToString()
					});
				}
				Arbre_Equipement.arbre.DataSource = dataTable;
				bool isChecked = Arbre_Equipement.radRadioButton1.IsChecked;
				if (isChecked)
				{
					Arbre_Equipement.arbre.DisplayMember = "Name";
				}
				else
				{
					bool isChecked2 = Arbre_Equipement.radRadioButton2.IsChecked;
					if (isChecked2)
					{
						Arbre_Equipement.arbre.DisplayMember = "code";
					}
					else
					{
						Arbre_Equipement.arbre.DisplayMember = "ID";
					}
				}
				Arbre_Equipement.arbre.ChildMember = "ID";
				Arbre_Equipement.arbre.ParentMember = "ParentID";
				Arbre_Equipement.arbre.ValueMember = "ID";
				Arbre_Equipement.arbre.Nodes[0].ImageIndex = 1;
				Arbre_Equipement.arbre.Nodes[0].Tag = dataTable.Rows[0].ItemArray[0].ToString();
				RadTreeNode n = Arbre_Equipement.arbre.Nodes[0];
				Arbre_Equipement.chargement_arbre(n);
				Arbre_Equipement.list_fichier();
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000455DC File Offset: 0x000437DC
		private static void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				Arbre_Equipement.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00045644 File Offset: 0x00043844
		private void radCheckBoxFormatting_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			Arbre_Equipement.arbre.TreeViewElement.Update(9);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0004565C File Offset: 0x0004385C
		private void TreeViewElement_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(Arbre_Equipement.guna2TextBox1.Text) != "";
			if (flag)
			{
				Arbre_Equipement.arbre.TreeViewElement.AllowAlternatingRowColor = false;
				bool flag2 = e.Node.Text.ToString().ToLower().Contains(Arbre_Equipement.guna2TextBox1.Text);
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
				Arbre_Equipement.arbre.TreeViewElement.AllowAlternatingRowColor = true;
				e.NodeElement.ResetValue(LightVisualElement.BorderColorProperty, 32);
				e.NodeElement.ResetValue(LightVisualElement.BorderBoxStyleProperty, 32);
				e.NodeElement.ResetValue(LightVisualElement.BorderGradientStyleProperty, 32);
				e.NodeElement.ContentElement.ResetValue(VisualElement.ForeColorProperty, 32);
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000457CC File Offset: 0x000439CC
		public static void mise_jour_arbre(int ord, RadTreeNode c, int id_m, string code_m, string des_m)
		{
			RadTreeNode radTreeNode = new RadTreeNode();
			radTreeNode.Text = des_m;
			radTreeNode.Value = id_m;
			radTreeNode.ToolTipText = code_m;
			radTreeNode.Tag = id_m;
			radTreeNode.ImageIndex = 1;
			c.Nodes.Insert(ord - 1, radTreeNode);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00045824 File Offset: 0x00043A24
		public static void mise_jour_modifier(int ord, RadTreeNode c, int id_m, string code_m, string des_m, int an_or, int id_prn, RadTreeNode h)
		{
			RadTreeNode radTreeNode = new RadTreeNode();
			radTreeNode.Text = des_m;
			radTreeNode.Value = id_m;
			radTreeNode.Tag = id_m;
			radTreeNode.ImageIndex = 1;
			bool flag = id_prn != 0;
			if (flag)
			{
				bool flag2 = an_or != ord;
				if (flag2)
				{
					c.Nodes.Remove(h);
					c.Nodes.Insert(ord - 1, radTreeNode);
				}
				else
				{
					h.Text = des_m;
					h.ToolTipText = code_m;
				}
			}
			else
			{
				Arbre_Equipement.load_arbre(0);
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000458BC File Offset: 0x00043ABC
		private void click_modifier(object sender, EventArgs e)
		{
			bool flag = Arbre_Equipement.arbre.SelectedNode != null;
			if (flag)
			{
				Arbre_Equipement.guna2Button2_Click(sender, e);
				Arbre_Equipement.nd_modifier = Arbre_Equipement.arbre.SelectedNode;
				Arbre_Equipement.parent_modifier = Arbre_Equipement.nd_modifier.Parent;
				Arbre_Equipement.id_modifier = Arbre_Equipement.arbre.SelectedNode.Tag.ToString();
				modifier_equipement modifier_equipement = new modifier_equipement();
				modifier_equipement.Show();
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0004592C File Offset: 0x00043B2C
		public static void click_afficher(object sender, EventArgs e)
		{
			bool flag = Arbre_Equipement.arbre.SelectedNode != null;
			if (flag)
			{
				Arbre_Equipement.id_eqp = Convert.ToInt32(Arbre_Equipement.arbre.SelectedNode.Tag.ToString());
				bd bd = new bd();
				string cmdText = "select code, designation from equipement where id=@i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					Arbre_Equipement.label5.Text = Arbre_Equipement.id_eqp.ToString();
					Arbre_Equipement.label6.Text = dataTable.Rows[0].ItemArray[0].ToString();
					Arbre_Equipement.label7.Text = dataTable.Rows[0].ItemArray[1].ToString();
					bool visible = Arbre_Equipement.Panel10.Visible;
					if (visible)
					{
						Arbre_Equipement.arbre.Size = new Size(424, Arbre_Equipement.arbre.Size.Height);
						bool flag3 = Arbre_Equipement.button1.BackColor == Color.White;
						if (flag3)
						{
							Arbre_Equipement.button1_Click_1(sender, e);
						}
						bool flag4 = Arbre_Equipement.button2.BackColor == Color.White;
						if (flag4)
						{
							Arbre_Equipement.button2_Click(sender, e);
						}
						bool flag5 = Arbre_Equipement.button3.BackColor == Color.White;
						if (flag5)
						{
							Arbre_Equipement.button3_Click(sender, e);
						}
						bool flag6 = Arbre_Equipement.button4.BackColor == Color.White;
						if (flag6)
						{
							Arbre_Equipement.button4_Click(sender, e);
						}
						bool flag7 = Arbre_Equipement.button5.BackColor == Color.White;
						if (flag7)
						{
							Arbre_Equipement.button5_Click(sender, e);
						}
						bool flag8 = Arbre_Equipement.button6.BackColor == Color.White;
						if (flag8)
						{
							Arbre_Equipement.button6_Click(sender, e);
						}
						bool flag9 = Arbre_Equipement.button7.BackColor == Color.White;
						if (flag9)
						{
							Arbre_Equipement.button7_Click(sender, e);
						}
					}
					else
					{
						Arbre_Equipement.button1_Click_1(sender, e);
					}
					Arbre_Equipement.Panel10.Show();
					Arbre_Equipement.guna2Button2.Show();
					Arbre_Equipement.arbre.Size = new Size(424, Arbre_Equipement.arbre.Size.Height);
				}
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00045BBC File Offset: 0x00043DBC
		private void click_supprimer(object sender, EventArgs e)
		{
			bool flag = Arbre_Equipement.arbre.SelectedNode != null;
			if (flag)
			{
				Arbre_Equipement.nd_supprimer = Arbre_Equipement.arbre.SelectedNode;
				Arbre_Equipement.parent_supprimer = Arbre_Equipement.arbre.SelectedNode.Parent;
				string text = Arbre_Equipement.nd_supprimer.Tag.ToString();
				bool flag2 = text != "1";
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						Arbre_Equipement.guna2Button2_Click(sender, e);
						Arbre_Equipement.update_supprimer_ordre(text);
						Arbre_Equipement.supprimer_equipement(text);
						Arbre_Equipement.parent_supprimer.Nodes.Remove(Arbre_Equipement.nd_supprimer);
					}
				}
				else
				{
					MessageBox.Show("La suppression est impossible");
				}
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00045C80 File Offset: 0x00043E80
		private static void supprimer_equipement(string a)
		{
			bd bd = new bd();
			string cmdText = "update equipement set deleted = @d  where id=@i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = a;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			string cmdText2 = "select id from equipement where id_parent = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = a;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(dataTable.Rows[i].ItemArray[0]) != "";
					if (flag2)
					{
						string a2 = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
						Arbre_Equipement.supprimer_equipement(a2);
					}
				}
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00045DD0 File Offset: 0x00043FD0
		private static void update_supprimer_ordre(string id_m)
		{
			bd bd = new bd();
			string cmdText = "select id_parent, ordre from equipement where id=@i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_m;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string value = dataTable.Rows[0].ItemArray[0].ToString();
				string value2 = dataTable.Rows[0].ItemArray[1].ToString();
				string cmdText2 = "update equipement set ordre = ordre - @v where id_parent =@i and deleted = @d and ordre >=@o and id<> @l";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@o", SqlDbType.Int).Value = value2;
				sqlCommand2.Parameters.Add("@l", SqlDbType.Int).Value = id_m;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00045F38 File Offset: 0x00044138
		private void click_copier(object sender, EventArgs e)
		{
			bool flag = Arbre_Equipement.arbre.SelectedNode != null;
			if (flag)
			{
				Arbre_Equipement.guna2Button2_Click(sender, e);
				Arbre_Equipement.nd_cloner = Arbre_Equipement.arbre.SelectedNode;
				Arbre_Equipement.id_copier = Arbre_Equipement.nd_cloner.Tag.ToString();
				copier_equipement copier_equipement = new copier_equipement();
				copier_equipement.Show();
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00045F91 File Offset: 0x00044191
		private static void select_expand(object sender, RadTreeViewEventArgs e)
		{
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00045F94 File Offset: 0x00044194
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			Arbre_Equipement.arbre.ExpandAll();
			Arbre_Equipement.arbre.Filter = Arbre_Equipement.guna2TextBox1.Text;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00045FB8 File Offset: 0x000441B8
		private void load_arbre_recherche(int r)
		{
			bd bd = new bd();
			string cmdText = "select  id, code, designation from equipement where id = @r and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@r", SqlDbType.Int).Value = r;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				RadTreeNode radTreeNode = Arbre_Equipement.arbre.Nodes.Add("");
				radTreeNode.Value = dataTable.Rows[0].ItemArray[2].ToString();
				radTreeNode.ToolTipText = dataTable.Rows[0].ItemArray[1].ToString();
				radTreeNode.Tag = dataTable.Rows[0].ItemArray[0].ToString();
				radTreeNode.ImageIndex = 1;
				int r2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				Arbre_Equipement.select_arbre(r2, radTreeNode);
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000460F1 File Offset: 0x000442F1
		private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000460F4 File Offset: 0x000442F4
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 620, 1);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00046130 File Offset: 0x00044330
		private static void button1_Click_1(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_generale equipement_generale = new equipement_generale();
			equipement_generale.TopLevel = false;
			Arbre_Equipement.button1.BackColor = Color.White;
			Arbre_Equipement.button1.ForeColor = Color.Firebrick;
			Arbre_Equipement.button2.BackColor = Color.Firebrick;
			Arbre_Equipement.button2.ForeColor = Color.White;
			Arbre_Equipement.button3.BackColor = Color.Firebrick;
			Arbre_Equipement.button3.ForeColor = Color.White;
			Arbre_Equipement.button4.BackColor = Color.Firebrick;
			Arbre_Equipement.button4.ForeColor = Color.White;
			Arbre_Equipement.button5.BackColor = Color.Firebrick;
			Arbre_Equipement.button5.ForeColor = Color.White;
			Arbre_Equipement.button6.BackColor = Color.Firebrick;
			Arbre_Equipement.button6.ForeColor = Color.White;
			Arbre_Equipement.button7.BackColor = Color.Firebrick;
			Arbre_Equipement.button7.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_generale);
			equipement_generale.Show();
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00046254 File Offset: 0x00044454
		private static void button2_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_observation equipement_observation = new equipement_observation();
			equipement_observation.TopLevel = false;
			Arbre_Equipement.button2.BackColor = Color.White;
			Arbre_Equipement.button2.ForeColor = Color.Firebrick;
			Arbre_Equipement.button1.BackColor = Color.Firebrick;
			Arbre_Equipement.button1.ForeColor = Color.White;
			Arbre_Equipement.button3.BackColor = Color.Firebrick;
			Arbre_Equipement.button3.ForeColor = Color.White;
			Arbre_Equipement.button4.BackColor = Color.Firebrick;
			Arbre_Equipement.button4.ForeColor = Color.White;
			Arbre_Equipement.button5.BackColor = Color.Firebrick;
			Arbre_Equipement.button5.ForeColor = Color.White;
			Arbre_Equipement.button6.BackColor = Color.Firebrick;
			Arbre_Equipement.button6.ForeColor = Color.White;
			Arbre_Equipement.button7.BackColor = Color.Firebrick;
			Arbre_Equipement.button7.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_observation);
			equipement_observation.Show();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00046378 File Offset: 0x00044578
		private static void button3_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_prevision equipement_prevision = new equipement_prevision();
			equipement_prevision.TopLevel = false;
			Arbre_Equipement.button3.BackColor = Color.White;
			Arbre_Equipement.button3.ForeColor = Color.Firebrick;
			Arbre_Equipement.button2.BackColor = Color.Firebrick;
			Arbre_Equipement.button2.ForeColor = Color.White;
			Arbre_Equipement.button1.BackColor = Color.Firebrick;
			Arbre_Equipement.button1.ForeColor = Color.White;
			Arbre_Equipement.button4.BackColor = Color.Firebrick;
			Arbre_Equipement.button4.ForeColor = Color.White;
			Arbre_Equipement.button5.BackColor = Color.Firebrick;
			Arbre_Equipement.button5.ForeColor = Color.White;
			Arbre_Equipement.button6.BackColor = Color.Firebrick;
			Arbre_Equipement.button6.ForeColor = Color.White;
			Arbre_Equipement.button7.BackColor = Color.Firebrick;
			Arbre_Equipement.button7.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_prevision);
			equipement_prevision.Show();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0004649C File Offset: 0x0004469C
		private static void button4_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_compteur equipement_compteur = new equipement_compteur();
			equipement_compteur.TopLevel = false;
			Arbre_Equipement.button4.BackColor = Color.White;
			Arbre_Equipement.button4.ForeColor = Color.Firebrick;
			Arbre_Equipement.button2.BackColor = Color.Firebrick;
			Arbre_Equipement.button2.ForeColor = Color.White;
			Arbre_Equipement.button3.BackColor = Color.Firebrick;
			Arbre_Equipement.button3.ForeColor = Color.White;
			Arbre_Equipement.button1.BackColor = Color.Firebrick;
			Arbre_Equipement.button1.ForeColor = Color.White;
			Arbre_Equipement.button5.BackColor = Color.Firebrick;
			Arbre_Equipement.button5.ForeColor = Color.White;
			Arbre_Equipement.button6.BackColor = Color.Firebrick;
			Arbre_Equipement.button6.ForeColor = Color.White;
			Arbre_Equipement.button7.BackColor = Color.Firebrick;
			Arbre_Equipement.button7.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_compteur);
			equipement_compteur.Show();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000465C0 File Offset: 0x000447C0
		private static void button5_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_technique equipement_technique = new equipement_technique();
			equipement_technique.TopLevel = false;
			Arbre_Equipement.button5.BackColor = Color.White;
			Arbre_Equipement.button5.ForeColor = Color.Firebrick;
			Arbre_Equipement.button2.BackColor = Color.Firebrick;
			Arbre_Equipement.button2.ForeColor = Color.White;
			Arbre_Equipement.button3.BackColor = Color.Firebrick;
			Arbre_Equipement.button3.ForeColor = Color.White;
			Arbre_Equipement.button4.BackColor = Color.Firebrick;
			Arbre_Equipement.button4.ForeColor = Color.White;
			Arbre_Equipement.button1.BackColor = Color.Firebrick;
			Arbre_Equipement.button1.ForeColor = Color.White;
			Arbre_Equipement.button6.BackColor = Color.Firebrick;
			Arbre_Equipement.button6.ForeColor = Color.White;
			Arbre_Equipement.button7.BackColor = Color.Firebrick;
			Arbre_Equipement.button7.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_technique);
			equipement_technique.Show();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000466E4 File Offset: 0x000448E4
		private static void button6_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_image equipement_image = new equipement_image();
			equipement_image.TopLevel = false;
			Arbre_Equipement.button6.BackColor = Color.White;
			Arbre_Equipement.button6.ForeColor = Color.Firebrick;
			Arbre_Equipement.button2.BackColor = Color.Firebrick;
			Arbre_Equipement.button2.ForeColor = Color.White;
			Arbre_Equipement.button3.BackColor = Color.Firebrick;
			Arbre_Equipement.button3.ForeColor = Color.White;
			Arbre_Equipement.button4.BackColor = Color.Firebrick;
			Arbre_Equipement.button4.ForeColor = Color.White;
			Arbre_Equipement.button5.BackColor = Color.Firebrick;
			Arbre_Equipement.button5.ForeColor = Color.White;
			Arbre_Equipement.button1.BackColor = Color.Firebrick;
			Arbre_Equipement.button1.ForeColor = Color.White;
			Arbre_Equipement.button7.BackColor = Color.Firebrick;
			Arbre_Equipement.button7.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_image);
			equipement_image.Show();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00046808 File Offset: 0x00044A08
		public static void button7_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.panel4.Controls.Clear();
			equipement_pdf equipement_pdf = new equipement_pdf();
			equipement_pdf.TopLevel = false;
			Arbre_Equipement.button7.BackColor = Color.White;
			Arbre_Equipement.button7.ForeColor = Color.Firebrick;
			Arbre_Equipement.button2.BackColor = Color.Firebrick;
			Arbre_Equipement.button2.ForeColor = Color.White;
			Arbre_Equipement.button3.BackColor = Color.Firebrick;
			Arbre_Equipement.button3.ForeColor = Color.White;
			Arbre_Equipement.button4.BackColor = Color.Firebrick;
			Arbre_Equipement.button4.ForeColor = Color.White;
			Arbre_Equipement.button5.BackColor = Color.Firebrick;
			Arbre_Equipement.button5.ForeColor = Color.White;
			Arbre_Equipement.button6.BackColor = Color.Firebrick;
			Arbre_Equipement.button6.ForeColor = Color.White;
			Arbre_Equipement.button1.BackColor = Color.Firebrick;
			Arbre_Equipement.button1.ForeColor = Color.White;
			Arbre_Equipement.panel4.Controls.Add(equipement_pdf);
			equipement_pdf.Show();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0004692C File Offset: 0x00044B2C
		public static void list_fichier()
		{
			Arbre_Equipement.list_id.Clear();
			Arbre_Equipement.count_id.Clear();
			bd bd = new bd();
			string cmdText = "select distinct id_equipement, count(id) from equipement_pdf group by id_equipement";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Arbre_Equipement.list_id.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]));
					Arbre_Equipement.count_id.Add(Convert.ToInt32(dataTable.Rows[i].ItemArray[1]));
				}
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00046A04 File Offset: 0x00044C04
		private static void guna2Button2_Click(object sender, EventArgs e)
		{
			Arbre_Equipement.Panel10.Hide();
			Arbre_Equipement.guna2Button2.Hide();
			Arbre_Equipement.arbre.Size = new Size(700, Arbre_Equipement.arbre.Size.Height);
			foreach (object obj in Arbre_Equipement.Panel10.Controls)
			{
				Control control = (Control)obj;
				bool flag = control.Name == "open_pdf_equipement";
				if (flag)
				{
					Arbre_Equipement.Panel10.Controls.Remove(control);
				}
				else
				{
					control.Visible = true;
				}
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00046AD4 File Offset: 0x00044CD4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = Arbre_Equipement.guna2Button1.Text == "Afficher Joints";
			if (flag)
			{
				Arbre_Equipement.arbre.DataSource = null;
				DataTable dataTable = new DataTable();
				bd bd = new bd();
				string cmdText = "select id, designation from equipement where id_parent = @d and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter.Fill(dataTable2);
				string cmdText2 = "select id, code, designation from equipement where deleted = @d and id in (select distinct id_equipement from equipement_pdf) order by id";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter2.Fill(dataTable3);
				dataTable.Columns.Clear();
				dataTable.Columns.Add("ID", typeof(int));
				dataTable.Columns.Add("ParentID", typeof(int));
				dataTable.Columns.Add("Name", typeof(string));
				bool flag2 = dataTable3.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable3.Rows.Count; i++)
					{
						dataTable.Rows.Add(new object[]
						{
							dataTable3.Rows[i].ItemArray[0].ToString(),
							null,
							dataTable3.Rows[i].ItemArray[2].ToString()
						});
					}
					Arbre_Equipement.arbre.DataSource = dataTable;
					Arbre_Equipement.arbre.DisplayMember = "Name";
					Arbre_Equipement.arbre.ChildMember = "ID";
					Arbre_Equipement.arbre.ParentMember = "ParentID";
					Arbre_Equipement.arbre.ValueMember = "ID";
					foreach (RadTreeNode radTreeNode in Arbre_Equipement.arbre.Nodes)
					{
						radTreeNode.ImageIndex = 1;
						radTreeNode.Tag = radTreeNode.Value;
					}
				}
				Arbre_Equipement.arbre.ExpandAll();
				Arbre_Equipement.guna2Button1.Text = "Annuler";
			}
			else
			{
				Arbre_Equipement.load_arbre(0);
				Arbre_Equipement.guna2Button1.Text = "Afficher Joints";
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00046D7C File Offset: 0x00044F7C
		private void afficher_joint(RadTreeNode m)
		{
			RadTreeNode radTreeNode = this.FindNodeByValue(4, Arbre_Equipement.arbre.Nodes);
			radTreeNode.Visible = true;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00046DAC File Offset: 0x00044FAC
		private RadTreeNode FindNodeByValue(object value, RadTreeNodeCollection nodes)
		{
			foreach (RadTreeNode radTreeNode in nodes)
			{
				radTreeNode.Visible = false;
				bool flag = radTreeNode.Value.Equals(value);
				if (flag)
				{
					radTreeNode.Visible = true;
					return radTreeNode;
				}
				RadTreeNode radTreeNode2 = this.FindNodeByValue(value, radTreeNode.Nodes);
				bool flag2 = radTreeNode2 != null;
				if (flag2)
				{
					radTreeNode2.Visible = true;
					return radTreeNode2;
				}
			}
			return null;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00046E48 File Offset: 0x00045048
		private void annuler_joint(RadTreeNode m)
		{
			foreach (RadTreeNode radTreeNode in m.Nodes)
			{
				radTreeNode.Visible = false;
				this.annuler_joint(radTreeNode);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00046EA4 File Offset: 0x000450A4
		private void hide_joint(RadTreeNodeCollection nodes)
		{
			foreach (RadTreeNode radTreeNode in nodes)
			{
				radTreeNode.Visible = false;
				this.hide_joint(radTreeNode.Nodes);
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00046F00 File Offset: 0x00045100
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			Arbre_Equipement.load_arbre(0);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00046F0A File Offset: 0x0004510A
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			Arbre_Equipement.load_arbre(0);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00046F14 File Offset: 0x00045114
		private void panel5_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0400023D RID: 573
		private RadTreeNode clickedNode;

		// Token: 0x0400023E RID: 574
		public static string id_parent = "";

		// Token: 0x0400023F RID: 575
		public static string des_parent = "";

		// Token: 0x04000240 RID: 576
		public static string id_copier = "";

		// Token: 0x04000241 RID: 577
		public static int id_eqp;

		// Token: 0x04000242 RID: 578
		public static int ordre = 0;

		// Token: 0x04000243 RID: 579
		public static RadTreeNode nd_ajouter;

		// Token: 0x04000244 RID: 580
		public static RadTreeNode nd_modifier;

		// Token: 0x04000245 RID: 581
		public static RadTreeNode nd_cloner;

		// Token: 0x04000246 RID: 582
		public static RadTreeNode parent_modifier;

		// Token: 0x04000247 RID: 583
		public static RadTreeNode parent_supprimer;

		// Token: 0x04000248 RID: 584
		public static RadTreeNode nd_supprimer;

		// Token: 0x04000249 RID: 585
		public static string id_modifier = "";

		// Token: 0x0400024A RID: 586
		public static List<int> list_id = new List<int>();

		// Token: 0x0400024B RID: 587
		public static List<int> count_id = new List<int>();

		// Token: 0x0400024C RID: 588
		private int x_test = 0;
	}
}
