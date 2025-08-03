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
	// Token: 0x02000105 RID: 261
	public partial class preventive_syst_compteur : Form
	{
		// Token: 0x06000BA2 RID: 2978 RVA: 0x001C71BC File Offset: 0x001C53BC
		public preventive_syst_compteur()
		{
			this.InitializeComponent();
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(preventive_syst_compteur.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(preventive_syst_compteur.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(preventive_syst_compteur.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(preventive_syst_compteur.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(preventive_syst_compteur.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(preventive_syst_compteur.select_changee);
			this.arbre.NodeMouseMove += new RadTreeView.TreeViewMouseEventHandler(this.Arbre_NodeMouseMove);
			this.radMenuItem1.Click += this.click_atelier;
			this.radMenuItem2.Click += this.click_equipement;
			this.radMenuItem3.Click += this.click_sous_equipement;
			this.radMenuItem4.Click += this.click_organe;
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			this.radGridView2.CellClick += new GridViewCellEventHandler(this.RadGridView2_CellClick);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x001C735C File Offset: 0x001C555C
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 10;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						this.panel3.Visible = false;
						bd bd = new bd();
						string cmdText = "delete prev_compteur where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_frequence(preventive_syst_compteur.id_gamme);
						bool flag4 = this.radGridView2.Rows.Count == 0;
						if (flag4)
						{
							this.panel7.Visible = false;
							this.remplissage_tableau(0);
						}
					}
				}
				bool flag5 = e.ColumnIndex == 9;
				if (flag5)
				{
					int num = Convert.ToInt32(this.radGridView2.Rows[e.RowIndex].Cells[11].Value.ToString());
					bool flag6 = num == 0;
					if (flag6)
					{
						DialogResult dialogResult2 = MessageBox.Show("Vous voulez arrêter ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag7 = dialogResult2 == DialogResult.Yes;
						if (flag7)
						{
							bd bd2 = new bd();
							string cmdText2 = "update prev_compteur set arr = @d where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd2.cnn.Close();
							this.radGridView2.Rows[e.RowIndex].Cells[9].Value = Resources.icons8_jouer_52;
							this.radGridView2.Rows[e.RowIndex].Cells[11].Value = 1;
							this.select_frequence(preventive_syst_compteur.id_gamme);
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
							string cmdText3 = "update prev_compteur set arr = @d where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							bd3.ouverture_bd(bd3.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd3.cnn.Close();
							this.radGridView2.Rows[e.RowIndex].Cells[9].Value = Resources.icons8_arrêter_96;
							this.radGridView2.Rows[e.RowIndex].Cells[11].Value = 0;
						}
					}
				}
				bool flag10 = e.ColumnIndex == 8;
				if (flag10)
				{
					this.label13.Text = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
					this.label14.Text = this.radGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
					this.label16.Text = this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
					this.panel8.Visible = true;
					bd bd4 = new bd();
					string cmdText4 = "select valeur_lancement, type_valeur, reinitialisation, initial, type_initial from prev_compteur where id = @i";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd4.cnn);
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag11 = dataTable.Rows.Count != 0;
					if (flag11)
					{
						this.guna2TextBox6.Text = dataTable.Rows[0].ItemArray[0].ToString();
						this.guna2TextBox4.Text = dataTable.Rows[0].ItemArray[3].ToString();
						bool flag12 = dataTable.Rows[0].ItemArray[1].ToString() == "Sup";
						if (flag12)
						{
							this.radRadioButton8.IsChecked = true;
						}
						else
						{
							this.radRadioButton7.IsChecked = true;
						}
						bool flag13 = dataTable.Rows[0].ItemArray[2].ToString() == "Non";
						if (flag13)
						{
							this.radRadioButton12.IsChecked = true;
							this.panel9.Visible = false;
						}
						else
						{
							this.radRadioButton11.IsChecked = true;
							this.panel9.Visible = true;
						}
						bool flag14 = dataTable.Rows[0].ItemArray[4].ToString() == "Au Lancement de l'OT";
						if (flag14)
						{
							this.radRadioButton10.IsChecked = true;
						}
						else
						{
							this.radRadioButton9.IsChecked = true;
						}
					}
				}
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x001C79D0 File Offset: 0x001C5BD0
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 5;
			if (flag)
			{
				this.radGridView2.Rows.Clear();
				this.panel7.Visible = false;
				this.panel8.Visible = false;
				this.label24.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
				preventive_syst_compteur.id_gamme = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
				this.select_frequence(preventive_syst_compteur.id_gamme);
				this.panel7.Visible = true;
				this.radGridView2.Focus();
			}
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x001C7AB1 File Offset: 0x001C5CB1
		private void preventive_syst_compteur_Load(object sender, EventArgs e)
		{
			this.panel3.Visible = false;
			this.panel7.Visible = false;
			this.remplissage_grid_equipement();
			this.select_gamme();
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x001C7ADC File Offset: 0x001C5CDC
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x001C7AF8 File Offset: 0x001C5CF8
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

		// Token: 0x06000BA8 RID: 2984 RVA: 0x001C7B7C File Offset: 0x001C5D7C
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

		// Token: 0x06000BA9 RID: 2985 RVA: 0x001C7C80 File Offset: 0x001C5E80
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

		// Token: 0x06000BAA RID: 2986 RVA: 0x001C7D38 File Offset: 0x001C5F38
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

		// Token: 0x06000BAB RID: 2987 RVA: 0x001C800C File Offset: 0x001C620C
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x001C8074 File Offset: 0x001C6274
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

		// Token: 0x06000BAD RID: 2989 RVA: 0x001C81E8 File Offset: 0x001C63E8
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

		// Token: 0x06000BAE RID: 2990 RVA: 0x001C831C File Offset: 0x001C651C
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

		// Token: 0x06000BAF RID: 2991 RVA: 0x001C8444 File Offset: 0x001C6644
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

		// Token: 0x06000BB0 RID: 2992 RVA: 0x001C856C File Offset: 0x001C676C
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

		// Token: 0x06000BB1 RID: 2993 RVA: 0x001C8694 File Offset: 0x001C6894
		private void click_organe(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				string text = this.arbre.SelectedNode.Tag.ToString();
				bd bd = new bd();
				string cmdText = "select code from equipement where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string value = dataTable.Rows[0].ItemArray[0].ToString();
				string value2 = this.arbre.SelectedNode.Text.ToString();
				this.radGridView3.Rows[3].Cells[1].Value = text;
				this.radGridView3.Rows[3].Cells[2].Value = value;
				this.radGridView3.Rows[3].Cells[3].Value = value2;
				this.select_compteur(text);
			}
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x001C87C4 File Offset: 0x001C69C4
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

		// Token: 0x06000BB3 RID: 2995 RVA: 0x001C88AC File Offset: 0x001C6AAC
		private void select_gamme()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select code,designation from gamme_operatoire where deleted = @d and type = @t order by code";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Préventive Syst Compteur";
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

		// Token: 0x06000BB4 RID: 2996 RVA: 0x001C89D0 File Offset: 0x001C6BD0
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.guna2TextBox2.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x001C8A1C File Offset: 0x001C6C1C
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.panel3.Visible = false;
			}
			else
			{
				this.panel3.Visible = true;
			}
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x001C8A5C File Offset: 0x001C6C5C
		private void select_compteur(string id)
		{
			bd bd = new bd();
			this.radDropDownList2.Items.Clear();
			string cmdText = "select id, designation from equipement_compteur where deleted = @d and id_equipement = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x001C8B7C File Offset: 0x001C6D7C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bool flag2 = this.radDropDownList2.Text != "";
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.is_reel(this.TextBox1.Text);
					if (flag3)
					{
						bd bd = new bd();
						int num = 0;
						string cmdText = "select id from gamme_operatoire where code = @v";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
						string value = "Sup";
						bool isChecked = this.radRadioButton2.IsChecked;
						if (isChecked)
						{
							value = "Inf";
						}
						double num2 = 0.0;
						bool flag4 = fonction.is_reel(this.guna2TextBox3.Text);
						if (flag4)
						{
							num2 = Convert.ToDouble(this.guna2TextBox3.Text);
						}
						string value2 = "Non";
						bool isChecked2 = this.radRadioButton3.IsChecked;
						if (isChecked2)
						{
							value2 = "Oui";
						}
						string value3 = "";
						foreach (object obj in this.panel4.Controls)
						{
							RadRadioButton radRadioButton = (RadRadioButton)obj;
							bool isChecked3 = radRadioButton.IsChecked;
							if (isChecked3)
							{
								value3 = radRadioButton.Text;
							}
						}
						string cmdText2 = "select id from prev_compteur where id_gamme = @i1 and id_compteur = @i2 and atelier = @i8 and equipement = @i9 and sous_equipement = @i10 and organe = @i11";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag.ToString();
						sqlCommand2.Parameters.Add("@i8", SqlDbType.Int).Value = this.radGridView3.Rows[0].Cells[1].Value.ToString();
						sqlCommand2.Parameters.Add("@i9", SqlDbType.Int).Value = this.radGridView3.Rows[1].Cells[1].Value.ToString();
						sqlCommand2.Parameters.Add("@i10", SqlDbType.Int).Value = this.radGridView3.Rows[2].Cells[1].Value.ToString();
						sqlCommand2.Parameters.Add("@i11", SqlDbType.Int).Value = this.radGridView3.Rows[3].Cells[1].Value.ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag5 = dataTable2.Rows.Count == 0;
						if (flag5)
						{
							string cmdText3 = "insert into prev_compteur (id_gamme, id_compteur, valeur_lancement,type_valeur,reinitialisation, initial, type_initial, atelier, equipement, sous_equipement, organe, arr) values (@i1, @i2, @i3, @i4, @i5,@i6, @i7, @i8, @i9, @i10, @i11, @i12) ";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag.ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox1.Text;
							sqlCommand3.Parameters.Add("@i4", SqlDbType.VarChar).Value = value;
							sqlCommand3.Parameters.Add("@i5", SqlDbType.VarChar).Value = value2;
							sqlCommand3.Parameters.Add("@i6", SqlDbType.Real).Value = num2;
							sqlCommand3.Parameters.Add("@i7", SqlDbType.VarChar).Value = value3;
							sqlCommand3.Parameters.Add("@i8", SqlDbType.Int).Value = this.radGridView3.Rows[0].Cells[1].Value.ToString();
							sqlCommand3.Parameters.Add("@i9", SqlDbType.Int).Value = this.radGridView3.Rows[1].Cells[1].Value.ToString();
							sqlCommand3.Parameters.Add("@i10", SqlDbType.Int).Value = this.radGridView3.Rows[2].Cells[1].Value.ToString();
							sqlCommand3.Parameters.Add("@i11", SqlDbType.Int).Value = this.radGridView3.Rows[3].Cells[1].Value.ToString();
							sqlCommand3.Parameters.Add("@i12", SqlDbType.Int).Value = 0;
							this.TextBox1.Clear();
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Enregistrement avec succés");
							this.panel7.Visible = false;
							this.remplissage_tableau(0);
						}
						else
						{
							MessageBox.Show("Erreur : Action Préventive déja paramètrée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Valeur Lancement OT doit être un réel", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Choisir le compteur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Choisir la gamme opératoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x001C9198 File Offset: 0x001C7398
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.PageSize = 14;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select gamme_operatoire.id, plan_maintenance.designation, gamme_operatoire.code, gamme_operatoire.designation, operation from gamme_operatoire inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where gamme_operatoire.deleted = @d and type = @t and gamme_operatoire.id in (select distinct id_gamme from prev_compteur)";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Préventive Syst Compteur";
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

		// Token: 0x06000BB9 RID: 3001 RVA: 0x001C939D File Offset: 0x001C759D
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel8.Visible = false;
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x001C93AD File Offset: 0x001C75AD
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel7.Visible = false;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x001C93C0 File Offset: 0x001C75C0
		private void select_frequence(int l)
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select prev_compteur.id, equipement.id, equipement.designation, equipement_compteur.designation,valeur_lancement, type_valeur, reinitialisation, initial, type_initial, arr from prev_compteur inner join equipement on prev_compteur.equipement = equipement.id inner join equipement_compteur on prev_compteur.id_compteur = equipement_compteur.id where id_gamme = @l";
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
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[9]);
					string text = "";
					string text2 = "";
					bool flag2 = dataTable.Rows[i].ItemArray[6].ToString() == "Oui";
					if (flag2)
					{
						text2 = dataTable.Rows[i].ItemArray[7].ToString();
						text = dataTable.Rows[i].ItemArray[8].ToString();
					}
					bool flag3 = num == 0;
					if (flag3)
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString(),
							dataTable.Rows[i].ItemArray[4].ToString() + " (" + dataTable.Rows[i].ItemArray[5].ToString() + ")",
							dataTable.Rows[i].ItemArray[6].ToString(),
							text2,
							text,
							Resources.icons8_approuver_et_mettre_à_jour_96__4_,
							Resources.icons8_arrêter_96,
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable.Rows[i].ItemArray[9].ToString()
						});
					}
					else
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString(),
							dataTable.Rows[i].ItemArray[4].ToString() + " (" + dataTable.Rows[i].ItemArray[5].ToString() + ")",
							dataTable.Rows[i].ItemArray[6].ToString(),
							text2,
							text,
							Resources.icons8_approuver_et_mettre_à_jour_96__4_,
							Resources.icons8_jouer_52,
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable.Rows[i].ItemArray[9].ToString()
						});
					}
				}
			}
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x001C977C File Offset: 0x001C797C
		private void radRadioButton12_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton12.IsChecked;
			if (isChecked)
			{
				this.panel9.Visible = false;
			}
			else
			{
				this.panel9.Visible = true;
			}
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x001C97BC File Offset: 0x001C79BC
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.guna2TextBox6.Text);
			if (flag)
			{
				string value = "Sup";
				bool isChecked = this.radRadioButton7.IsChecked;
				if (isChecked)
				{
					value = "Inf";
				}
				double num = 0.0;
				bool flag2 = fonction.is_reel(this.guna2TextBox4.Text);
				if (flag2)
				{
					num = Convert.ToDouble(this.guna2TextBox4.Text);
				}
				string value2 = "Non";
				bool isChecked2 = this.radRadioButton11.IsChecked;
				if (isChecked2)
				{
					value2 = "Oui";
				}
				string value3 = "";
				foreach (object obj in this.panel10.Controls)
				{
					RadRadioButton radRadioButton = (RadRadioButton)obj;
					bool isChecked3 = radRadioButton.IsChecked;
					if (isChecked3)
					{
						value3 = radRadioButton.Text;
					}
				}
				bd bd = new bd();
				string cmdText = "update prev_compteur set valeur_lancement = @v1, type_valeur = @v2, reinitialisation = @v3, initial = @v4, type_initial = @v5 where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label13.Text;
				sqlCommand.Parameters.Add("@v1", SqlDbType.Real).Value = this.guna2TextBox6.Text;
				sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = value;
				sqlCommand.Parameters.Add("@v3", SqlDbType.VarChar).Value = value2;
				sqlCommand.Parameters.Add("@v4", SqlDbType.Real).Value = num;
				sqlCommand.Parameters.Add("@v5", SqlDbType.VarChar).Value = value3;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Modification avec succés");
				this.select_frequence(preventive_syst_compteur.id_gamme);
			}
			else
			{
				MessageBox.Show("Erreur : Valeur Lancement OT doit être un réel", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000F11 RID: 3857
		private static int id_gamme;
	}
}
