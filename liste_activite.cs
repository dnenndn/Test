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
	// Token: 0x02000083 RID: 131
	public partial class liste_activite : Form
	{
		// Token: 0x06000622 RID: 1570 RVA: 0x000FF617 File Offset: 0x000FD817
		public liste_activite()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000FF630 File Offset: 0x000FD830
		private void liste_activite_Load(object sender, EventArgs e)
		{
			this.select_famille();
			this.radMenuItem1.Click += this.click_ajouter;
			this.radMenuItem2.Click += this.click_ajouter_sf;
			this.radMenuItem3.Click += this.click_supprimer;
			this.radMenuItem4.Click += this.click_supprimer_sf;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x000FF6A8 File Offset: 0x000FD8A8
		private void select_famille()
		{
			this.radTreeView1.Nodes.Clear();
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

		// Token: 0x06000625 RID: 1573 RVA: 0x000FF7FC File Offset: 0x000FD9FC
		private void select_sous_famille(int id_f)
		{
			bd bd = new bd();
			string cmdText = "select id, code_sous_famille, designation from sous_famille where deleted = @d and id_famille = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_f;
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

		// Token: 0x06000626 RID: 1574 RVA: 0x000FF95C File Offset: 0x000FDB5C
		private void add_operation(object sender, EventArgs e)
		{
			int height = this.panel2.Size.Height;
			this.panel2.Size = new Size(this.panel2.Size.Width, height + 35);
			this.guna2Button1.Location = new Point(this.guna2Button1.Location.X, this.guna2Button1.Location.Y + 35);
			RadTextBox radTextBox = new RadTextBox();
			radTextBox.Location = new Point(13, height + 4);
			radTextBox.Size = new Size(531, 24);
			radTextBox.ThemeName = "Crystal";
			this.panel2.Controls.Add(radTextBox);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000FFA28 File Offset: 0x000FDC28
		private void delete_operation(object sender, EventArgs e)
		{
			int num = 0;
			foreach (object obj in this.panel2.Controls)
			{
				Control control = (Control)obj;
				bool flag = control is RadTextBox;
				if (flag)
				{
					num++;
				}
			}
			int num2 = 0;
			foreach (object obj2 in this.panel2.Controls)
			{
				Control control2 = (Control)obj2;
				bool flag2 = control2 is RadTextBox;
				if (flag2)
				{
					num2++;
					bool flag3 = num2 == num & num2 != 1;
					if (flag3)
					{
						int height = this.panel2.Size.Height;
						this.panel2.Size = new Size(this.panel2.Size.Width, height - 35);
						this.panel2.Controls.Remove(control2);
						this.guna2Button1.Location = new Point(this.guna2Button1.Location.X, this.guna2Button1.Location.Y - 35);
						break;
					}
				}
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000FFBB8 File Offset: 0x000FDDB8
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.add_operation(sender, e);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000FFBC4 File Offset: 0x000FDDC4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from activite where designation = @i1 or code = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox2.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					int num = 1;
					bool isChecked = this.radRadioButton2.IsChecked;
					if (isChecked)
					{
						num = 2;
					}
					int num2 = 1;
					bool isChecked2 = this.radRadioButton3.IsChecked;
					if (isChecked2)
					{
						num2 = 2;
					}
					string cmdText2 = "insert into activite (code, designation, type_st, type_article, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = num;
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = num2;
					sqlCommand2.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					int id_ac = (int)sqlCommand2.ExecuteScalar();
					bd.cnn.Close();
					this.save_activite_famille(id_ac);
					this.save_activite_sous_famille(id_ac);
					this.save_operation(id_ac);
					MessageBox.Show("L'activité est enregistrée avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.radTreeView2.Nodes.Clear();
					this.radTreeView3.Nodes.Clear();
					this.radTreeView4.Nodes.Clear();
					foreach (object obj in this.panel2.Controls)
					{
						Control control = (Control)obj;
						bool flag3 = control is RadTextBox;
						if (flag3)
						{
							((RadTextBox)control).Clear();
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : L'activité est déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x000FFED8 File Offset: 0x000FE0D8
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			this.delete_operation(sender, e);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x000FFEE4 File Offset: 0x000FE0E4
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tree(Convert.ToString(selectedNode.Tag), this.radTreeView3) == 0;
				if (flag2)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = selectedNode.Text;
					radTreeNode.Tag = selectedNode.Tag;
					this.radTreeView3.Nodes.Add(radTreeNode);
					this.select_sous_famille(Convert.ToInt32(selectedNode.Tag));
				}
				else
				{
					MessageBox.Show("Erreur : La Famille est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x000FFF90 File Offset: 0x000FE190
		private void click_ajouter_sf(object sender, EventArgs e)
		{
			bool flag = this.radTreeView2.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView2.SelectedNode;
				bool flag2 = this.search_tree(Convert.ToString(selectedNode.Tag), this.radTreeView4) == 0;
				if (flag2)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = selectedNode.Text;
					radTreeNode.Tag = selectedNode.Tag;
					this.radTreeView4.Nodes.Add(radTreeNode);
				}
				else
				{
					MessageBox.Show("Erreur : La Sous Famille est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00100028 File Offset: 0x000FE228
		private void click_supprimer(object sender, EventArgs e)
		{
			bool flag = this.radTreeView3.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView3.SelectedNode;
				bd bd = new bd();
				for (int i = 0; i < this.radTreeView4.Nodes.Count; i++)
				{
					string cmdText = "select id_famille from sous_famille where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radTreeView4.Nodes[i].Tag;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						int num = Convert.ToInt32(selectedNode.Tag);
						int num2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
						bool flag3 = num == num2;
						if (flag3)
						{
							this.radTreeView4.Nodes.RemoveAt(i);
							i--;
						}
					}
				}
				for (int j = 0; j < this.radTreeView2.Nodes.Count; j++)
				{
					string cmdText2 = "select id_famille from sous_famille where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radTreeView2.Nodes[j].Tag;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag4 = dataTable2.Rows.Count != 0;
					if (flag4)
					{
						int num3 = Convert.ToInt32(selectedNode.Tag);
						int num4 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
						bool flag5 = num3 == num4;
						if (flag5)
						{
							this.radTreeView2.Nodes.RemoveAt(j);
							j--;
						}
					}
				}
				this.radTreeView3.Nodes.Remove(selectedNode);
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00100250 File Offset: 0x000FE450
		private void click_supprimer_sf(object sender, EventArgs e)
		{
			bool flag = this.radTreeView4.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView4.SelectedNode;
				this.radTreeView4.Nodes.Remove(selectedNode);
			}
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00100290 File Offset: 0x000FE490
		private int search_tree(string s, RadTreeView t)
		{
			int result = 0;
			bool flag = t.Nodes.Count != 0;
			if (flag)
			{
				for (int i = 0; i < t.Nodes.Count; i++)
				{
					bool flag2 = Convert.ToString(t.Nodes[i].Tag) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x001002FD File Offset: 0x000FE4FD
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00100317 File Offset: 0x000FE517
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView2.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00100334 File Offset: 0x000FE534
		private void save_activite_famille(int id_ac)
		{
			bool flag = this.radTreeView3.Nodes.Count != 0;
			if (flag)
			{
				bd bd = new bd();
				foreach (RadTreeNode radTreeNode in this.radTreeView3.Nodes)
				{
					string cmdText = "insert into activite_famille (id_activite, id_famille) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_ac;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = radTreeNode.Tag;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0010041C File Offset: 0x000FE61C
		private void save_activite_sous_famille(int id_ac)
		{
			bool flag = this.radTreeView4.Nodes.Count != 0;
			if (flag)
			{
				bd bd = new bd();
				foreach (RadTreeNode radTreeNode in this.radTreeView4.Nodes)
				{
					string cmdText = "insert into activite_sous_famille (id_activite, id_sous_famille) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_ac;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = radTreeNode.Tag;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00100504 File Offset: 0x000FE704
		private void save_operation(int id_ac)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			foreach (object obj in this.panel2.Controls)
			{
				Control control = (Control)obj;
				bool flag = control is RadTextBox;
				if (flag)
				{
					bool flag2 = fonction.DeleteSpace(control.Text) != "";
					if (flag2)
					{
						string cmdText = "insert into activite_operation (id_activite, operation) values (@i1, @i2)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_ac;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = control.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}
	}
}
