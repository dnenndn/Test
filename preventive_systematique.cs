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
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000104 RID: 260
	public partial class preventive_systematique : Form
	{
		// Token: 0x06000B85 RID: 2949 RVA: 0x001BF43C File Offset: 0x001BD63C
		public preventive_systematique()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.panel2.Visible = false;
			this.arbre.TreeViewElement.NodeFormatting += new TreeNodeFormattingEventHandler(this.TreeViewElement_NodeFormatting);
			this.load_arbre(0);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(preventive_systematique.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(preventive_systematique.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(preventive_systematique.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(preventive_systematique.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(preventive_systematique.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(preventive_systematique.select_changee);
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

		// Token: 0x06000B86 RID: 2950 RVA: 0x001BF5F4 File Offset: 0x001BD7F4
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 8;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						this.panel3.Visible = false;
						bd bd = new bd();
						string cmdText = "delete prev_systematique where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_frequence(preventive_systematique.id_gamme);
						bool flag4 = this.radGridView2.Rows.Count == 0;
						if (flag4)
						{
							this.panel2.Visible = false;
							this.remplissage_tableau(0);
						}
					}
				}
				bool flag5 = e.ColumnIndex == 7;
				if (flag5)
				{
					int num = Convert.ToInt32(this.radGridView2.Rows[e.RowIndex].Cells[9].Value.ToString());
					bool flag6 = num == 0;
					if (flag6)
					{
						DialogResult dialogResult2 = MessageBox.Show("Vous voulez arrêter ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag7 = dialogResult2 == DialogResult.Yes;
						if (flag7)
						{
							bd bd2 = new bd();
							string cmdText2 = "update prev_systematique set arr = @d where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
							sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd2.cnn.Close();
							this.radGridView2.Rows[e.RowIndex].Cells[7].Value = Resources.icons8_jouer_52;
							this.radGridView2.Rows[e.RowIndex].Cells[9].Value = 1;
							this.select_frequence(preventive_systematique.id_gamme);
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
							string cmdText3 = "update prev_systematique set arr = @d where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd3.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							bd3.ouverture_bd(bd3.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd3.cnn.Close();
							this.radGridView2.Rows[e.RowIndex].Cells[7].Value = Resources.icons8_arrêter_96;
							this.radGridView2.Rows[e.RowIndex].Cells[9].Value = 0;
						}
					}
				}
				bool flag10 = e.ColumnIndex == 6;
				if (flag10)
				{
					this.label13.Text = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
					this.label14.Text = this.radGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
					this.label16.Text = this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
					this.panel3.Visible = true;
					bd bd4 = new bd();
					string cmdText4 = "select frequence, periode, date_debut, heure_debut, lancer_ot_avant from prev_systematique where id = @i";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd4.cnn);
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					this.select_periode_2();
					bool flag11 = dataTable.Rows.Count != 0;
					if (flag11)
					{
						this.radDateTimePicker2.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[2]);
						this.radTimePicker2.Value = new DateTime?(Convert.ToDateTime(dataTable.Rows[0].ItemArray[3]));
						this.guna2TextBox5.Text = dataTable.Rows[0].ItemArray[4].ToString();
						this.guna2TextBox4.Text = dataTable.Rows[0].ItemArray[0].ToString();
						this.radDropDownList3.Text = dataTable.Rows[0].ItemArray[1].ToString();
					}
				}
			}
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x001BFBEC File Offset: 0x001BDDEC
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 5;
			if (flag)
			{
				this.radGridView2.Rows.Clear();
				this.panel3.Visible = false;
				this.panel2.Visible = false;
				this.label11.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
				preventive_systematique.id_gamme = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
				this.select_frequence(preventive_systematique.id_gamme);
				this.panel2.Visible = true;
				this.radGridView2.Focus();
			}
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x001BFCCD File Offset: 0x001BDECD
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x001BFCE8 File Offset: 0x001BDEE8
		private void preventive_systematique_Load(object sender, EventArgs e)
		{
			this.remplissage_grid_equipement();
			this.select_periode();
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.select_gamme();
			this.panel2.Visible = false;
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x001BFD40 File Offset: 0x001BDF40
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

		// Token: 0x06000B8B RID: 2955 RVA: 0x001BFDC4 File Offset: 0x001BDFC4
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

		// Token: 0x06000B8C RID: 2956 RVA: 0x001BFEC8 File Offset: 0x001BE0C8
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

		// Token: 0x06000B8D RID: 2957 RVA: 0x001BFF80 File Offset: 0x001BE180
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

		// Token: 0x06000B8E RID: 2958 RVA: 0x001C0254 File Offset: 0x001BE454
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x001C02BC File Offset: 0x001BE4BC
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

		// Token: 0x06000B90 RID: 2960 RVA: 0x001C0430 File Offset: 0x001BE630
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

		// Token: 0x06000B91 RID: 2961 RVA: 0x001C0564 File Offset: 0x001BE764
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

		// Token: 0x06000B92 RID: 2962 RVA: 0x001C068C File Offset: 0x001BE88C
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

		// Token: 0x06000B93 RID: 2963 RVA: 0x001C07B4 File Offset: 0x001BE9B4
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

		// Token: 0x06000B94 RID: 2964 RVA: 0x001C08DC File Offset: 0x001BEADC
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

		// Token: 0x06000B95 RID: 2965 RVA: 0x001C0A04 File Offset: 0x001BEC04
		private void select_periode()
		{
			this.radDropDownList2.Items.Clear();
			this.radDropDownList2.Items.Add("Jour");
			this.radDropDownList2.Items.Add("Semaine");
			this.radDropDownList2.Items.Add("Mois");
			this.radDropDownList2.Items.Add("Année");
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x001C0A7C File Offset: 0x001BEC7C
		private void select_periode_2()
		{
			this.radDropDownList3.Items.Clear();
			this.radDropDownList3.Items.Add("Jour");
			this.radDropDownList3.Items.Add("Semaine");
			this.radDropDownList3.Items.Add("Mois");
			this.radDropDownList3.Items.Add("Année");
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x001C0AF4 File Offset: 0x001BECF4
		private void select_gamme()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select code,designation from gamme_operatoire where deleted = @d and type = @t order by code";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Préventive Systématique";
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

		// Token: 0x06000B98 RID: 2968 RVA: 0x001C0C18 File Offset: 0x001BEE18
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.guna2TextBox2.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x001C0C64 File Offset: 0x001BEE64
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

		// Token: 0x06000B9A RID: 2970 RVA: 0x001C0D4C File Offset: 0x001BEF4C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bool flag2 = this.radDropDownList2.Text != "";
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.isnumeric(this.TextBox1.Text);
					if (flag3)
					{
						bool flag4 = Convert.ToInt32(this.TextBox1.Text) > 0;
						if (flag4)
						{
							int num = 0;
							bool flag5 = fonction.isnumeric(this.guna2TextBox3.Text);
							if (flag5)
							{
								bool flag6 = Convert.ToInt32(this.guna2TextBox3.Text) > 0;
								if (flag6)
								{
									num = Convert.ToInt32(this.guna2TextBox3.Text);
								}
							}
							bool flag7 = Convert.ToInt32(this.radGridView3.Rows[1].Cells[1].Value) != 0;
							if (flag7)
							{
								bd bd = new bd();
								string cmdText = "select id from gamme_operatoire where code = @v";
								SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
								sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
								SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
								DataTable dataTable = new DataTable();
								sqlDataAdapter.Fill(dataTable);
								int num2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
								string cmdText2 = "select id from prev_systematique where id_gamme = @i1 and atelier = @i8 and equipement = @i9 and sous_equipement = @i10 and organe = @i11";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num2;
								sqlCommand2.Parameters.Add("@i8", SqlDbType.Int).Value = this.radGridView3.Rows[0].Cells[1].Value.ToString();
								sqlCommand2.Parameters.Add("@i9", SqlDbType.Int).Value = this.radGridView3.Rows[1].Cells[1].Value.ToString();
								sqlCommand2.Parameters.Add("@i10", SqlDbType.Int).Value = this.radGridView3.Rows[2].Cells[1].Value.ToString();
								sqlCommand2.Parameters.Add("@i11", SqlDbType.Int).Value = this.radGridView3.Rows[3].Cells[1].Value.ToString();
								SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
								DataTable dataTable2 = new DataTable();
								sqlDataAdapter2.Fill(dataTable2);
								bool flag8 = dataTable2.Rows.Count == 0;
								if (flag8)
								{
									string cmdText3 = "insert into prev_systematique (id_gamme, frequence, periode, date_debut, heure_debut, lancer_ot_avant, atelier, equipement, sous_equipement, organe, arr) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11) ";
									SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
									sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num2;
									sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = this.TextBox1.Text;
									sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
									sqlCommand3.Parameters.Add("@i4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
									sqlCommand3.Parameters.Add("@i5", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
									sqlCommand3.Parameters.Add("@i6", SqlDbType.Int).Value = num;
									sqlCommand3.Parameters.Add("@i7", SqlDbType.Int).Value = this.radGridView3.Rows[0].Cells[1].Value.ToString();
									sqlCommand3.Parameters.Add("@i8", SqlDbType.Int).Value = this.radGridView3.Rows[1].Cells[1].Value.ToString();
									sqlCommand3.Parameters.Add("@i9", SqlDbType.Int).Value = this.radGridView3.Rows[2].Cells[1].Value.ToString();
									sqlCommand3.Parameters.Add("@i10", SqlDbType.Int).Value = this.radGridView3.Rows[3].Cells[1].Value.ToString();
									sqlCommand3.Parameters.Add("@i11", SqlDbType.Int).Value = 0;
									this.TextBox1.Clear();
									bd.ouverture_bd(bd.cnn);
									sqlCommand3.ExecuteNonQuery();
									bd.cnn.Close();
									MessageBox.Show("Enregistrement avec succés");
									this.panel2.Visible = false;
									this.remplissage_tableau(0);
								}
								else
								{
									MessageBox.Show("Erreur : Action Préventive déja paramètrée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								MessageBox.Show("Erreur : Choisir l'équipement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : La fréquence doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : La fréquence doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Choisir la fréquence", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Choisir la gamme opératoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x001C1320 File Offset: 0x001BF520
		public void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.PageSize = 14;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select gamme_operatoire.id, plan_maintenance.designation, gamme_operatoire.code, gamme_operatoire.designation, operation from gamme_operatoire inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where gamme_operatoire.deleted = @d and type = @t and gamme_operatoire.id in (select distinct id_gamme from prev_systematique)";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Préventive Systématique";
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

		// Token: 0x06000B9C RID: 2972 RVA: 0x001C1525 File Offset: 0x001BF725
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel2.Visible = false;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x001C1535 File Offset: 0x001BF735
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel3.Visible = false;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x001C1548 File Offset: 0x001BF748
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.isnumeric(this.guna2TextBox4.Text);
			if (flag)
			{
				bool flag2 = Convert.ToInt32(this.guna2TextBox4.Text) > 0;
				if (flag2)
				{
					bd bd = new bd();
					int num = 0;
					bool flag3 = fonction.isnumeric(this.guna2TextBox5.Text);
					if (flag3)
					{
						bool flag4 = Convert.ToInt32(this.guna2TextBox5.Text) > 0;
						if (flag4)
						{
							num = Convert.ToInt32(this.guna2TextBox5.Text);
						}
					}
					string cmdText = "update prev_systematique set frequence = @v1, periode = @v2, date_debut = @v3, heure_debut = @v4, lancer_ot_avant = @v5 where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label13.Text;
					sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = this.guna2TextBox4.Text;
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.radDropDownList3.Text;
					sqlCommand.Parameters.Add("@v3", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
					sqlCommand.Parameters.Add("@v4", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 5);
					sqlCommand.Parameters.Add("@v5", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					this.select_frequence(preventive_systematique.id_gamme);
				}
				else
				{
					MessageBox.Show("Erreur : La fréquence doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : La fréquence doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x001C174C File Offset: 0x001BF94C
		private void select_frequence(int l)
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select prev_systematique.id, equipement.id, equipement.designation, frequence, periode, date_debut, heure_debut, lancer_ot_avant, arr from prev_systematique inner join equipement on prev_systematique.equipement = equipement.id where id_gamme = @l";
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
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[8]);
					bool flag2 = num == 0;
					if (flag2)
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString() + " " + dataTable.Rows[i].ItemArray[4].ToString(),
							fonction.Mid(dataTable.Rows[i].ItemArray[5].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[6].ToString(),
							dataTable.Rows[i].ItemArray[7].ToString() + " Jours",
							Resources.icons8_approuver_et_mettre_à_jour_96__4_,
							Resources.icons8_arrêter_96,
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable.Rows[i].ItemArray[8].ToString()
						});
					}
					else
					{
						this.radGridView2.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString() + " " + dataTable.Rows[i].ItemArray[4].ToString(),
							fonction.Mid(dataTable.Rows[i].ItemArray[5].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[6].ToString(),
							dataTable.Rows[i].ItemArray[7].ToString() + " Jours",
							Resources.icons8_approuver_et_mettre_à_jour_96__4_,
							Resources.icons8_jouer_52,
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable.Rows[i].ItemArray[8].ToString()
						});
					}
				}
			}
		}

		// Token: 0x04000ED6 RID: 3798
		private static int id_gamme;
	}
}
