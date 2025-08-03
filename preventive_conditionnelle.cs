using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x02000103 RID: 259
	public partial class preventive_conditionnelle : Form
	{
		// Token: 0x06000B60 RID: 2912 RVA: 0x001B69BC File Offset: 0x001B4BBC
		public preventive_conditionnelle()
		{
			this.InitializeComponent();
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(preventive_conditionnelle.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(preventive_conditionnelle.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(preventive_conditionnelle.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(preventive_conditionnelle.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(preventive_conditionnelle.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(preventive_conditionnelle.select_changee);
			this.radGridView4.ViewCellFormatting += new CellFormattingEventHandler(preventive_conditionnelle.select_change);
			this.radGridView4.ViewRowFormatting += new RowFormattingEventHandler(preventive_conditionnelle.select_changee);
			this.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
			this.radMenuItem1.Click += this.click_atelier;
			this.radMenuItem2.Click += this.click_equipement;
			this.radMenuItem3.Click += this.click_sous_equipement;
			this.radMenuItem4.Click += this.click_organe;
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			this.radGridView2.CellClick += new GridViewCellEventHandler(this.RadGridView2_CellClick);
			this.radGridView4.CellClick += new GridViewCellEventHandler(this.RadGridView4_CellClick);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x001B6BA4 File Offset: 0x001B4DA4
		private void RadGridView4_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 6;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string value = this.radGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
						string cmdText = "delete prev_mesure where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_lesmesures(preventive_conditionnelle.id_frequence);
					}
				}
			}
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x001B6C8C File Offset: 0x001B4E8C
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 7;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						this.panel8.Visible = false;
						this.panel2.Visible = false;
						this.panel4.Visible = false;
						bd bd = new bd();
						string cmdText = "delete prev_conditionnelle where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_frequence(preventive_conditionnelle.id_gamme);
						bool flag4 = this.radGridView2.Rows.Count == 0;
						if (flag4)
						{
							this.panel7.Visible = false;
							this.remplissage_tableau(0);
						}
					}
				}
				bool flag5 = e.ColumnIndex == 6;
				if (flag5)
				{
					int num = Convert.ToInt32(this.radGridView2.Rows[e.RowIndex].Cells[8].Value.ToString());
					bool flag6 = num == 0;
					if (flag6)
					{
						DialogResult dialogResult2 = MessageBox.Show("Vous voulez arrêter ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag7 = dialogResult2 == DialogResult.Yes;
						if (flag7)
						{
							bd bd2 = new bd();
							string cmdText2 = "update prev_conditionnelle set arr = @d where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd2.cnn.Close();
							this.radGridView2.Rows[e.RowIndex].Cells[6].Value = Resources.icons8_jouer_52;
							this.radGridView2.Rows[e.RowIndex].Cells[8].Value = 1;
							this.select_frequence(preventive_conditionnelle.id_gamme);
						}
					}
					bool flag8 = num == 1;
					if (flag8)
					{
						DialogResult dialogResult3 = MessageBox.Show("Vous voulez démarrer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag9 = dialogResult3 == DialogResult.Yes;
						if (flag9)
						{
							bd bd3 = new bd();
							string cmdText3 = "update prev_conditionnelle set arr = @d where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							bd3.ouverture_bd(bd3.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd3.cnn.Close();
							this.radGridView2.Rows[e.RowIndex].Cells[6].Value = Resources.icons8_arrêter_96;
							this.radGridView2.Rows[e.RowIndex].Cells[8].Value = 0;
						}
					}
				}
				bool flag10 = e.ColumnIndex == 5;
				if (flag10)
				{
					this.label13.Text = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
					this.label14.Text = this.radGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
					this.label16.Text = this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
					this.panel8.Visible = true;
					this.panel2.Visible = true;
					this.panel4.Visible = true;
					bool flag11 = this.button1.BackColor == Color.White;
					if (flag11)
					{
						preventive_conditionnelle.id_frequence = Convert.ToInt32(this.radGridView2.Rows[e.RowIndex].Cells[0].Value);
						this.select_mesure(preventive_conditionnelle.id_frequence);
						this.panel3.Visible = false;
						this.panel9.Visible = true;
					}
					else
					{
						preventive_conditionnelle.id_frequence = Convert.ToInt32(this.radGridView2.Rows[e.RowIndex].Cells[0].Value);
						this.select_general(preventive_conditionnelle.id_frequence);
						this.panel3.Visible = true;
						this.panel9.Visible = false;
					}
				}
			}
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x001B7228 File Offset: 0x001B5428
		private void select_general(int l)
		{
			bd bd = new bd();
			string cmdText = "select mesure, unite, valeur_lancement, type_valeur from prev_conditionnelle where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = l;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.guna2TextBox7.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.guna2TextBox6.Text = dataTable.Rows[0].ItemArray[1].ToString();
				this.guna2TextBox5.Text = dataTable.Rows[0].ItemArray[2].ToString();
				bool flag2 = dataTable.Rows[0].ItemArray[3].ToString() == "Sup";
				if (flag2)
				{
					this.radRadioButton4.IsChecked = true;
				}
				else
				{
					this.radRadioButton3.IsChecked = true;
				}
			}
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x001B7358 File Offset: 0x001B5558
		private void select_mesure(int l)
		{
			bd bd = new bd();
			string cmdText = "select unite from prev_conditionnelle where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = l;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.guna2TextBox8.Clear();
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.guna2TextBox10.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
			}
			this.radDropDownList6.Items.Clear();
			this.radDropDownList6.Items.Add("");
			string cmdText2 = "select id, nom from intervenant where deleted = @d";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable2.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i + 1].Tag = dataTable2.Rows[i].ItemArray[0].ToString();
				}
			}
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker2.Value = value;
			this.radDateTimePicker3.Value = value.AddMonths(1).AddDays(-1.0);
			this.select_lesmesures(l);
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x001B758C File Offset: 0x001B578C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 5;
			if (flag)
			{
				this.radGridView2.Rows.Clear();
				this.panel7.Visible = false;
				this.panel8.Visible = false;
				this.panel2.Visible = false;
				this.panel4.Visible = false;
				this.label24.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
				preventive_conditionnelle.id_gamme = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
				this.select_frequence(preventive_conditionnelle.id_gamme);
				this.panel7.Visible = true;
				this.radGridView2.Focus();
			}
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x001B7688 File Offset: 0x001B5888
		private void preventive_conditionnelle_Load(object sender, EventArgs e)
		{
			this.panel7.Visible = false;
			this.panel8.Visible = false;
			this.panel2.Visible = false;
			this.panel4.Visible = false;
			this.remplissage_grid_equipement();
			this.select_gamme();
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x001B76D8 File Offset: 0x001B58D8
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x001B76F4 File Offset: 0x001B58F4
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

		// Token: 0x06000B69 RID: 2921 RVA: 0x001B7778 File Offset: 0x001B5978
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

		// Token: 0x06000B6A RID: 2922 RVA: 0x001B787C File Offset: 0x001B5A7C
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

		// Token: 0x06000B6B RID: 2923 RVA: 0x001B7934 File Offset: 0x001B5B34
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

		// Token: 0x06000B6C RID: 2924 RVA: 0x001B7C08 File Offset: 0x001B5E08
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x001B7C70 File Offset: 0x001B5E70
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

		// Token: 0x06000B6E RID: 2926 RVA: 0x001B7DE4 File Offset: 0x001B5FE4
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
					this.radGridView3.Rows[i].Cells[1].Value = 0;
				}
			}
			this.radGridView3.Rows[1].Cells[1].Value = 0;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x001B7F18 File Offset: 0x001B6118
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
				this.radGridView3.Rows[0].Cells[1].Value = value;
				this.radGridView3.Rows[0].Cells[2].Value = value2;
				this.radGridView3.Rows[0].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x001B8040 File Offset: 0x001B6240
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
				this.radGridView3.Rows[1].Cells[1].Value = value;
				this.radGridView3.Rows[1].Cells[2].Value = value2;
				this.radGridView3.Rows[1].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x001B8168 File Offset: 0x001B6368
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
				this.radGridView3.Rows[2].Cells[1].Value = value;
				this.radGridView3.Rows[2].Cells[2].Value = value2;
				this.radGridView3.Rows[2].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x001B8290 File Offset: 0x001B6490
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
				this.radGridView3.Rows[3].Cells[1].Value = value;
				this.radGridView3.Rows[3].Cells[2].Value = value2;
				this.radGridView3.Rows[3].Cells[3].Value = value3;
			}
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x001B83B8 File Offset: 0x001B65B8
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
						this.radGridView3.Rows[e.RowIndex].Cells[1].Value = 0;
						this.radGridView3.Rows[e.RowIndex].Cells[2].Value = "";
						this.radGridView3.Rows[e.RowIndex].Cells[3].Value = "";
					}
				}
			}
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x001B84A0 File Offset: 0x001B66A0
		private void select_gamme()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select code,designation from gamme_operatoire where deleted = @d and type = @t order by code";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Préventive Conditionnelle";
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

		// Token: 0x06000B75 RID: 2933 RVA: 0x001B85C4 File Offset: 0x001B67C4
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.guna2TextBox2.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x001B8610 File Offset: 0x001B6810
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bool flag2 = this.TextBox1.Text != "";
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.is_reel(this.guna2TextBox4.Text);
					if (flag3)
					{
						bool flag4 = Convert.ToInt32(this.radGridView3.Rows[1].Cells[1].Value) != 0;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "select id from gamme_operatoire where code = @v";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
							string value = "Sup";
							bool isChecked = this.radRadioButton2.IsChecked;
							if (isChecked)
							{
								value = "Inf";
							}
							string cmdText2 = "insert into prev_conditionnelle (id_gamme, mesure, unite, valeur_lancement,type_valeur, atelier, equipement, sous_equipement, organe, arr) values (@i1, @i2, @i3, @i4, @i5, @i7, @i8, @i9, @i10, @i11) ";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.guna2TextBox3.Text;
							sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = this.guna2TextBox4.Text;
							sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
							sqlCommand2.Parameters.Add("@i7", SqlDbType.Int).Value = this.radGridView3.Rows[0].Cells[1].Value.ToString();
							sqlCommand2.Parameters.Add("@i8", SqlDbType.Int).Value = this.radGridView3.Rows[1].Cells[1].Value.ToString();
							sqlCommand2.Parameters.Add("@i9", SqlDbType.Int).Value = this.radGridView3.Rows[2].Cells[1].Value.ToString();
							sqlCommand2.Parameters.Add("@i10", SqlDbType.Int).Value = this.radGridView3.Rows[3].Cells[1].Value.ToString();
							sqlCommand2.Parameters.Add("@i11", SqlDbType.Int).Value = 0;
							this.TextBox1.Clear();
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Enregistrement avec succés");
							this.panel7.Visible = false;
							this.remplissage_tableau(0);
						}
						else
						{
							MessageBox.Show("Erreur : Choisir l'équipement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Valeur Lancement OT doit être un réel", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Choisir la mesure", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Choisir la gamme opératoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x001B89C8 File Offset: 0x001B6BC8
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel7.Visible = false;
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x001B89D8 File Offset: 0x001B6BD8
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel8.Visible = false;
			this.panel2.Visible = false;
			this.panel4.Visible = false;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x001B8A04 File Offset: 0x001B6C04
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.PageSize = 14;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select gamme_operatoire.id, plan_maintenance.designation, gamme_operatoire.code, gamme_operatoire.designation, operation from gamme_operatoire inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where gamme_operatoire.deleted = @d and type = @t and gamme_operatoire.id in (select distinct id_gamme from prev_conditionnelle)";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Préventive Conditionnelle";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Resources.icons8_visible_96
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x001B8C0C File Offset: 0x001B6E0C
		private void select_frequence(int l)
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select prev_conditionnelle.id, equipement.id, equipement.designation, mesure,unite,valeur_lancement, type_valeur, arr from prev_conditionnelle inner join equipement on prev_conditionnelle.equipement = equipement.id  where id_gamme = @l";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@l", SqlDbType.Int).Value = l;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[7]);
					bool flag2 = num == 0;
					if (flag2)
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString() + " (" + dataTable.Rows[i].ItemArray[4].ToString() + ")",
							dataTable.Rows[i].ItemArray[5].ToString() + " " + dataTable.Rows[i].ItemArray[4].ToString(),
							Resources.icons8_approuver_et_mettre_à_jour_96__4_,
							Resources.icons8_arrêter_96,
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable.Rows[i].ItemArray[7].ToString()
						});
					}
					else
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString() + " (" + dataTable.Rows[i].ItemArray[4].ToString() + ")",
							dataTable.Rows[i].ItemArray[5].ToString() + " (" + dataTable.Rows[i].ItemArray[4].ToString() + ")",
							Resources.icons8_approuver_et_mettre_à_jour_96__4_,
							Resources.icons8_jouer_52,
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable.Rows[i].ItemArray[7].ToString()
						});
					}
				}
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x001B8F4C File Offset: 0x001B714C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.select_general(preventive_conditionnelle.id_frequence);
			this.panel9.Visible = false;
			this.panel3.Visible = true;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x001B8FC4 File Offset: 0x001B71C4
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.select_mesure(preventive_conditionnelle.id_frequence);
			this.panel3.Visible = false;
			this.panel9.Visible = true;
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x001B903C File Offset: 0x001B723C
		private void panel10_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 969, 1);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x001B9078 File Offset: 0x001B7278
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.guna2TextBox7.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.guna2TextBox5.Text);
				if (flag2)
				{
					bd bd = new bd();
					string value = "Sup";
					bool isChecked = this.radRadioButton3.IsChecked;
					if (isChecked)
					{
						value = "Inf";
					}
					string cmdText = "update prev_conditionnelle set mesure = @v1, unite = @v2, valeur_lancement = @v3, type_valeur = @v4 where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label13.Text;
					sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.guna2TextBox7.Text;
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.guna2TextBox6.Text;
					sqlCommand.Parameters.Add("@v3", SqlDbType.Real).Value = this.guna2TextBox5.Text;
					sqlCommand.Parameters.Add("@v4", SqlDbType.VarChar).Value = value;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					this.select_frequence(preventive_conditionnelle.id_gamme);
				}
				else
				{
					MessageBox.Show("Erreur : Valeur Lancement OT doit être un réel", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Choisir la mesure", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x001B9218 File Offset: 0x001B7418
		private void select_lesmesures(int l)
		{
			bd bd = new bd();
			this.radGridView4.Rows.Clear();
			string cmdText = "select prev_mesure.id, date_mesure, heure_mesure, valeur, utilisateur.login, intervenant.nom from prev_mesure left join utilisateur on prev_mesure.creer_par = utilisateur.id left join intervenant on prev_mesure.mesure_par = intervenant.id where id_prev = @l and date_mesure between @d1 and @d2 order by date_mesure desc, heure_mesure desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@l", SqlDbType.Int).Value = l;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker3.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView4.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[4]),
						Convert.ToString(dataTable.Rows[i].ItemArray[5]),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x001B93EC File Offset: 0x001B75EC
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.is_reel(this.guna2TextBox8.Text);
			if (flag)
			{
				int num = 0;
				bool flag2 = this.radDropDownList6.Text != "";
				if (flag2)
				{
					num = Convert.ToInt32(this.radDropDownList6.SelectedItem.Tag);
				}
				string cmdText = "insert into prev_mesure (id_prev, mesure_par, creer_par, date_mesure, heure_mesure, valeur) values (@i1, @i2, @i3, @i4, @i5, @i6)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = preventive_conditionnelle.id_frequence;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = num;
				sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = page_loginn.id_user;
				sqlCommand.Parameters.Add("@i4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand.Parameters.Add("@i5", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
				sqlCommand.Parameters.Add("@i6", SqlDbType.Real).Value = this.guna2TextBox8.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Ajout avec succés");
				this.select_lesmesures(preventive_conditionnelle.id_frequence);
				lancement_ot_preventive.creation_ot_mesure(preventive_conditionnelle.id_frequence, Convert.ToDouble(this.guna2TextBox8.Text));
				this.guna2TextBox8.Clear();
			}
			else
			{
				MessageBox.Show("Erreur : Valeur  doit être un réel", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x001B95CB File Offset: 0x001B77CB
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.select_lesmesures(preventive_conditionnelle.id_frequence);
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x001B95DA File Offset: 0x001B77DA
		private void radDateTimePicker3_ValueChanged(object sender, EventArgs e)
		{
			this.select_lesmesures(preventive_conditionnelle.id_frequence);
		}

		// Token: 0x04000E84 RID: 3716
		private static int id_gamme;

		// Token: 0x04000E85 RID: 3717
		private static int id_frequence;
	}
}
