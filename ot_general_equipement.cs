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
	// Token: 0x020000BE RID: 190
	public partial class ot_general_equipement : Form
	{
		// Token: 0x0600088C RID: 2188 RVA: 0x0016D130 File Offset: 0x0016B330
		public ot_general_equipement()
		{
			this.InitializeComponent();
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_general_equipement.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_general_equipement.select_changee);
			this.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
			this.radMenuItem1.Click += this.click_atelier;
			this.radMenuItem2.Click += this.click_equipement;
			this.radMenuItem3.Click += this.click_sous_equipement;
			this.radMenuItem4.Click += this.click_organe;
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0016D238 File Offset: 0x0016B438
		private void ot_general_equipement_Load(object sender, EventArgs e)
		{
			this.remplissage_grid_equipement();
			this.select_les_machines();
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0016D24C File Offset: 0x0016B44C
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0016D2D0 File Offset: 0x0016B4D0
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0016D3D4 File Offset: 0x0016B5D4
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

		// Token: 0x06000891 RID: 2193 RVA: 0x0016D48C File Offset: 0x0016B68C
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

		// Token: 0x06000892 RID: 2194 RVA: 0x0016D760 File Offset: 0x0016B960
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0016D7C8 File Offset: 0x0016B9C8
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

		// Token: 0x06000894 RID: 2196 RVA: 0x0016D93C File Offset: 0x0016BB3C
		private void remplissage_grid_equipement()
		{
			this.radGridView3.Rows.Clear();
			this.radGridView3.Rows.Add(new object[]
			{
				"Atelier"
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Equipement *"
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Sous Equipement"
			});
			this.radGridView3.Rows.Add(new object[]
			{
				"Organe"
			});
			for (int i = 0; i < 4; i++)
			{
				bool flag = i != 1;
				if (flag)
				{
					this.radGridView3.Rows[i].Cells[4].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				}
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0016DA20 File Offset: 0x0016BC20
		private void click_atelier(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
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
				string cmdText2 = "update ordre_travail set atelier = @v where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				this.radGridView3.Rows[0].Cells[1].Value = value;
				this.radGridView3.Rows[0].Cells[2].Value = value2;
				this.radGridView3.Rows[0].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0016DBB8 File Offset: 0x0016BDB8
		private void click_equipement(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
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
				string cmdText2 = "update ordre_travail set equipement = @v where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				this.radGridView3.Rows[1].Cells[1].Value = value;
				this.radGridView3.Rows[1].Cells[2].Value = value2;
				this.radGridView3.Rows[1].Cells[3].Value = value3;
				ot_liste.remplissage_tableau(0);
			}
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0016DD58 File Offset: 0x0016BF58
		private void click_sous_equipement(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
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
				string cmdText2 = "update ordre_travail set sous_equipement = @v where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				this.radGridView3.Rows[2].Cells[1].Value = value;
				this.radGridView3.Rows[2].Cells[2].Value = value2;
				this.radGridView3.Rows[2].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0016DEF0 File Offset: 0x0016C0F0
		private void click_organe(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
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
				string cmdText2 = "update ordre_travail set organe = @v where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = value;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				this.radGridView3.Rows[3].Cells[1].Value = value;
				this.radGridView3.Rows[3].Cells[2].Value = value2;
				this.radGridView3.Rows[3].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0016E088 File Offset: 0x0016C288
		private void select_les_machines()
		{
			bd bd = new bd();
			string cmdText = "select atelier, equipement, sous_equipement, organe from ordre_travail where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) != 0;
				if (flag2)
				{
					string cmdText2 = "select id,  code, designation from equipement where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						this.radGridView3.Rows[0].Cells[1].Value = dataTable2.Rows[0].ItemArray[0].ToString();
						this.radGridView3.Rows[0].Cells[2].Value = dataTable2.Rows[0].ItemArray[1].ToString();
						this.radGridView3.Rows[0].Cells[3].Value = dataTable2.Rows[0].ItemArray[2].ToString();
					}
				}
				bool flag4 = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]) != 0;
				if (flag4)
				{
					string cmdText3 = "select id,  code, designation from equipement where id = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag5 = dataTable3.Rows.Count != 0;
					if (flag5)
					{
						this.radGridView3.Rows[1].Cells[1].Value = dataTable3.Rows[0].ItemArray[0].ToString();
						this.radGridView3.Rows[1].Cells[2].Value = dataTable3.Rows[0].ItemArray[1].ToString();
						this.radGridView3.Rows[1].Cells[3].Value = dataTable3.Rows[0].ItemArray[2].ToString();
					}
				}
				bool flag6 = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]) != 0;
				if (flag6)
				{
					string cmdText4 = "select id,  code, designation from equipement where id = @i";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					bool flag7 = dataTable4.Rows.Count != 0;
					if (flag7)
					{
						this.radGridView3.Rows[2].Cells[1].Value = dataTable4.Rows[0].ItemArray[0].ToString();
						this.radGridView3.Rows[2].Cells[2].Value = dataTable4.Rows[0].ItemArray[1].ToString();
						this.radGridView3.Rows[2].Cells[3].Value = dataTable4.Rows[0].ItemArray[2].ToString();
					}
				}
				bool flag8 = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]) != 0;
				if (flag8)
				{
					string cmdText5 = "select id,  code, designation from equipement where id = @i";
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
					sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
					DataTable dataTable5 = new DataTable();
					sqlDataAdapter5.Fill(dataTable5);
					bool flag9 = dataTable5.Rows.Count != 0;
					if (flag9)
					{
						this.radGridView3.Rows[3].Cells[1].Value = dataTable5.Rows[0].ItemArray[0].ToString();
						this.radGridView3.Rows[3].Cells[2].Value = dataTable5.Rows[0].ItemArray[1].ToString();
						this.radGridView3.Rows[3].Cells[3].Value = dataTable5.Rows[0].ItemArray[2].ToString();
					}
				}
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0016E664 File Offset: 0x0016C864
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 4;
			if (flag)
			{
				bool flag2 = e.RowIndex != 1;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "";
						bool flag4 = e.RowIndex == 0;
						if (flag4)
						{
							cmdText = "update ordre_travail set atelier = @d where id = @i";
						}
						bool flag5 = e.RowIndex == 2;
						if (flag5)
						{
							cmdText = "update ordre_travail set sous_equipement = @d where id = @i";
						}
						bool flag6 = e.RowIndex == 3;
						if (flag6)
						{
							cmdText = "update ordre_travail set organe = @d where id = @i";
						}
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.radGridView3.Rows[e.RowIndex].Cells[1].Value = 0;
						this.radGridView3.Rows[e.RowIndex].Cells[2].Value = "";
						this.radGridView3.Rows[e.RowIndex].Cells[3].Value = "";
					}
				}
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0016E814 File Offset: 0x0016CA14
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.Filter = this.guna2TextBox1.Text;
		}
	}
}
