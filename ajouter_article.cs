using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
	// Token: 0x0200000B RID: 11
	public partial class ajouter_article : Form
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00016E00 File Offset: 0x00015000
		public ajouter_article()
		{
			this.InitializeComponent();
			this.select_classification();
			this.select_emplacement();
			this.select_unite();
			this.select_stockage();
			this.select_fournisseur();
			this.select_famille();
			this.select_equipement();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00016ED7 File Offset: 0x000150D7
		private void guna2TextBox9_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00016EDA File Offset: 0x000150DA
		private void ajouter_article_Load(object sender, EventArgs e)
		{
			this.radDropDownList1.AutoSize = false;
			this.radDropDownList1.Size = new Size(152, 30);
			this.pictureBox3.Hide();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00016F10 File Offset: 0x00015110
		private void select_unite()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_unite_article where deleted =@d order by designation";
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
				}
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00016FE4 File Offset: 0x000151E4
		private void select_stockage()
		{
			this.radDropDownList4.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_stockage_article where deleted =@d order by designation";
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
					this.radDropDownList4.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000170B8 File Offset: 0x000152B8
		private void select_classification()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_classification_article where deleted =@d order by designation";
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
				}
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0001718C File Offset: 0x0001538C
		private void select_emplacement()
		{
			this.radDropDownList5.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_emplacement_article where deleted =@d order by designation";
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
					this.radDropDownList5.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00017260 File Offset: 0x00015460
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000172B4 File Offset: 0x000154B4
		private void select_fournisseur()
		{
			this.radCheckedDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select nom from fournisseur where deleted =@d order by nom";
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
					this.radCheckedDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00017388 File Offset: 0x00015588
		private void select_famille()
		{
			this.radDropDownList2.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from famille where deleted =@d order by designation";
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
					this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00017459 File Offset: 0x00015659
		private void select_equipement()
		{
			this.arbre.ShowNodeToolTips = true;
			this.arbre.ShowLines = true;
			this.arbre.TreeViewElement.AllowAlternatingRowColor = true;
			this.load_arbre(0);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00017490 File Offset: 0x00015690
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

		// Token: 0x0600008A RID: 138 RVA: 0x00017764 File Offset: 0x00015964
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000177CC File Offset: 0x000159CC
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

		// Token: 0x0600008C RID: 140 RVA: 0x00017914 File Offset: 0x00015B14
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

		// Token: 0x0600008D RID: 141 RVA: 0x0001797C File Offset: 0x00015B7C
		private List<RadTreeNode> CheckedNodes(RadTreeView trv)
		{
			List<RadTreeNode> list = new List<RadTreeNode>();
			this.FindCheckedNodes(list, trv.Nodes);
			return list;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000179A4 File Offset: 0x00015BA4
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

		// Token: 0x0600008F RID: 143 RVA: 0x00017B28 File Offset: 0x00015D28
		private void guna2TextBox10_TextChanged(object sender, EventArgs e)
		{
			this.arbre.ExpandAll();
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00017B50 File Offset: 0x00015D50
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
				RadTreeNode radTreeNode = this.arbre.Nodes.Add("");
				radTreeNode.Value = dataTable.Rows[0].ItemArray[2].ToString();
				radTreeNode.ToolTipText = dataTable.Rows[0].ItemArray[1].ToString();
				radTreeNode.Tag = dataTable.Rows[0].ItemArray[0].ToString();
				radTreeNode.ImageIndex = 1;
				int r2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				this.select_arbre(r2, radTreeNode);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00017C8C File Offset: 0x00015E8C
		public void tload_arbre(int r)
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
				int r2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				this.select_arbre(r2, radTreeNode);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00017DDC File Offset: 0x00015FDC
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.arbre.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.Text,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
				else
				{
					MessageBox.Show("Erreur : L'équipement est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00017E74 File Offset: 0x00016074
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00017EFC File Offset: 0x000160FC
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 2;
					if (flag3)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.radGridView1.Rows.RemoveAt(e.RowIndex);
						}
					}
				}
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00017FBC File Offset: 0x000161BC
		private void select_caracteristique(string id)
		{
			this.radPanel1.Controls.Clear();
			bd bd = new bd();
			string cmdText = "select * from caracteristique where id_sous_famille = @i and deleted =@d";
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
					Label label = new Label();
					label.AutoSize = true;
					label.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
					label.ForeColor = Color.Black;
					label.Text = dataTable.Rows[i].ItemArray[2].ToString();
					label.Location = new Point(13, 12 + 62 * i);
					this.radPanel1.Controls.Add(label);
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[4]) == 1;
					if (flag2)
					{
						Label label2 = new Label();
						label2.AutoSize = true;
						label2.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						label2.ForeColor = Color.Red;
						label2.Text = "*";
						label2.Location = new Point(11 + label.Size.Width, 12 + 62 * i);
						this.radPanel1.Controls.Add(label2);
					}
					bool flag3 = dataTable.Rows[i].ItemArray[3].ToString() == "TextBox";
					if (flag3)
					{
						RadTextBox radTextBox = new RadTextBox();
						radTextBox.ThemeName = "Crystal";
						radTextBox.Name = "t";
						radTextBox.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						radTextBox.Cursor = Cursors.IBeam;
						radTextBox.ForeColor = Color.FromArgb(138, 138, 138);
						radTextBox.Font = new Font("Calibri", 9f);
						radTextBox.Location = new Point(17, 34 + 62 * i);
						radTextBox.PasswordChar = '\0';
						radTextBox.SelectedText = "";
						radTextBox.Size = new Size(318, 29);
						radTextBox.BackColor = Color.White;
						string cmdText2 = "select valeur_defaut from caracteristique_textbox where id_caracteristique = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							radTextBox.Text = dataTable2.Rows[0].ItemArray[0].ToString();
						}
						this.radPanel1.Controls.Add(radTextBox);
					}
					bool flag5 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Unique";
					if (flag5)
					{
						Guna2ComboBox guna2ComboBox = new Guna2ComboBox();
						guna2ComboBox.BackColor = Color.Transparent;
						guna2ComboBox.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						guna2ComboBox.Name = "su";
						guna2ComboBox.BorderRadius = 2;
						guna2ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
						guna2ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
						guna2ComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
						guna2ComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
						guna2ComboBox.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						guna2ComboBox.ForeColor = Color.FromArgb(125, 137, 149);
						guna2ComboBox.ItemHeight = 24;
						guna2ComboBox.Location = new Point(17, 34 + 62 * i);
						guna2ComboBox.Size = new Size(318, 30);
						this.radPanel1.Controls.Add(guna2ComboBox);
						string cmdText3 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							guna2ComboBox.Controls.Clear();
							for (int j = 0; j < dataTable3.Rows.Count; j++)
							{
								guna2ComboBox.Items.Add(Convert.ToString(dataTable3.Rows[j].ItemArray[0]));
								bool flag7 = Convert.ToInt32(dataTable3.Rows[j].ItemArray[1]) == 1;
								if (flag7)
								{
									guna2ComboBox.Text = Convert.ToString(dataTable3.Rows[j].ItemArray[0]);
								}
							}
						}
					}
					bool flag8 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Multiple";
					if (flag8)
					{
						RadCheckedDropDownList radCheckedDropDownList = new RadCheckedDropDownList();
						radCheckedDropDownList.Location = new Point(17, 34 + 62 * i);
						radCheckedDropDownList.Size = new Size(318, 30);
						radCheckedDropDownList.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						radCheckedDropDownList.Name = "sm";
						radCheckedDropDownList.ThemeName = "Crystal";
						this.radPanel1.Controls.Add(radCheckedDropDownList);
						string cmdText4 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag9 = dataTable4.Rows.Count != 0;
						if (flag9)
						{
							radCheckedDropDownList.Controls.Clear();
							for (int k = 0; k < dataTable4.Rows.Count; k++)
							{
								radCheckedDropDownList.Items.Add(Convert.ToString(dataTable4.Rows[k].ItemArray[0]));
								bool flag10 = Convert.ToInt32(dataTable4.Rows[k].ItemArray[1]) == 1;
								if (flag10)
								{
									radCheckedDropDownList.Items[k].Checked = true;
								}
								else
								{
									radCheckedDropDownList.Items[k].Checked = false;
								}
							}
						}
					}
					bool flag11 = dataTable.Rows[i].ItemArray[3].ToString() == "CheckBox";
					if (flag11)
					{
						string cmdText5 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag12 = dataTable5.Rows.Count != 0;
						if (flag12)
						{
							int num = 17;
							FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
							flowLayoutPanel.AutoScroll = true;
							flowLayoutPanel.Location = new Point(17, 34 + 62 * i);
							flowLayoutPanel.Size = new Size(1086, 40);
							flowLayoutPanel.Tag = dataTable.Rows[i].ItemArray[0].ToString();
							flowLayoutPanel.Name = "p1";
							for (int l = 0; l < dataTable5.Rows.Count; l++)
							{
								RadCheckBox radCheckBox = new RadCheckBox();
								radCheckBox.Name = "cb";
								radCheckBox.CheckAlignment = ContentAlignment.MiddleRight;
								radCheckBox.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
								radCheckBox.Location = new Point(num, 34 + 62 * i);
								radCheckBox.Text = Convert.ToString(dataTable5.Rows[l].ItemArray[0]);
								radCheckBox.ThemeName = "Crystal";
								radCheckBox.AutoSize = true;
								int num2 = 0;
								for (int m = 1; m <= radCheckBox.Text.Length; m++)
								{
									bool flag13 = fonction.Mid(radCheckBox.Text, m, 1) == fonction.Mid(radCheckBox.Text, m, 1).ToUpper();
									if (flag13)
									{
										num2++;
									}
								}
								num = num + 42 + radCheckBox.Text.Length * 6 + num2 * 2;
								flowLayoutPanel.Controls.Add(radCheckBox);
								bool flag14 = Convert.ToInt32(dataTable5.Rows[l].ItemArray[1]) == 1;
								if (flag14)
								{
									radCheckBox.Checked = true;
								}
								else
								{
									radCheckBox.Checked = false;
								}
							}
							this.radPanel1.Controls.Add(flowLayoutPanel);
						}
					}
					bool flag15 = dataTable.Rows[i].ItemArray[3].ToString() == "Radio Button";
					if (flag15)
					{
						FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
						flowLayoutPanel2.AutoScroll = true;
						flowLayoutPanel2.Location = new Point(17, 34 + 62 * i);
						flowLayoutPanel2.Size = new Size(1086, 40);
						flowLayoutPanel2.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						flowLayoutPanel2.Name = "p2";
						string cmdText6 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
						DataTable dataTable6 = new DataTable();
						sqlDataAdapter6.Fill(dataTable6);
						bool flag16 = dataTable6.Rows.Count != 0;
						if (flag16)
						{
							int num3 = 17;
							for (int n = 0; n < dataTable6.Rows.Count; n++)
							{
								RadRadioButton radRadioButton = new RadRadioButton();
								radRadioButton.Name = "rb";
								radRadioButton.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
								radRadioButton.Location = new Point(num3, 34 + 62 * i);
								radRadioButton.Text = Convert.ToString(dataTable6.Rows[n].ItemArray[0]);
								radRadioButton.ThemeName = "Crystal";
								radRadioButton.AutoSize = true;
								int num4 = 0;
								for (int num5 = 1; num5 <= radRadioButton.Text.Length; num5++)
								{
									bool flag17 = fonction.Mid(radRadioButton.Text, num5, 1) == fonction.Mid(radRadioButton.Text, num5, 1).ToUpper();
									if (flag17)
									{
										num4++;
									}
								}
								num3 = num3 + 42 + radRadioButton.Text.Length * 6 + num4 * 2;
								flowLayoutPanel2.Controls.Add(radRadioButton);
								bool flag18 = Convert.ToInt32(dataTable6.Rows[n].ItemArray[1]) == 1;
								if (flag18)
								{
									radRadioButton.IsChecked = true;
								}
								else
								{
									radRadioButton.IsChecked = false;
								}
							}
							this.radPanel1.Controls.Add(flowLayoutPanel2);
						}
					}
					Label label3 = new Label();
					label3.Text = "";
					label3.Location = new Point(13, 12 + 62 * dataTable.Rows.Count);
					this.radPanel1.Controls.Add(label3);
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00018D12 File Offset: 0x00016F12
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00018D18 File Offset: 0x00016F18
		private void save_caracteristique(int id)
		{
			bd bd = new bd();
			foreach (object obj in this.radPanel1.Controls)
			{
				Control control = (Control)obj;
				bool flag = control.Name == "t" | control.Name == "su" | control.Name == "sm" | control.Name == "p1" | control.Name == "p2";
				if (flag)
				{
					bool flag2 = control.Name == "t";
					if (flag2)
					{
						string cmdText = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
						sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = control.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
					}
					bool flag3 = control.Name == "su";
					if (flag3)
					{
						string cmdText2 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = control.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
					}
					bool flag4 = control.Name == "sm";
					if (flag4)
					{
						bool flag5 = control is RadCheckedDropDownList;
						if (flag5)
						{
							RadCheckedDropDownList radCheckedDropDownList = (RadCheckedDropDownList)control;
							bool flag6 = radCheckedDropDownList.Items.Count != 0;
							if (flag6)
							{
								for (int i = 0; i < radCheckedDropDownList.Items.Count; i++)
								{
									bool @checked = radCheckedDropDownList.Items[i].Checked;
									if (@checked)
									{
										string cmdText3 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
										SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
										sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
										sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
										sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = radCheckedDropDownList.Items[i].Text;
										bd.ouverture_bd(bd.cnn);
										sqlCommand3.ExecuteNonQuery();
										bd.cnn.Close();
									}
								}
							}
						}
					}
					bool flag7 = control.Name == "p1";
					if (flag7)
					{
						foreach (object obj2 in control.Controls)
						{
							Control control2 = (Control)obj2;
							bool flag8 = control2.Name == "cb";
							if (flag8)
							{
								RadCheckBox radCheckBox = (RadCheckBox)control2;
								bool checked2 = radCheckBox.Checked;
								if (checked2)
								{
									string cmdText4 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
									SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
									sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
									sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
									sqlCommand4.Parameters.Add("@i3", SqlDbType.VarChar).Value = radCheckBox.Text;
									bd.ouverture_bd(bd.cnn);
									sqlCommand4.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
						}
					}
					bool flag9 = control.Name == "p2";
					if (flag9)
					{
						foreach (object obj3 in control.Controls)
						{
							Control control3 = (Control)obj3;
							bool flag10 = control3.Name == "rb";
							if (flag10)
							{
								RadRadioButton radRadioButton = (RadRadioButton)control3;
								bool isChecked = radRadioButton.IsChecked;
								if (isChecked)
								{
									string cmdText5 = "insert into tableau_article_caracteristique (id_article, id_caracteristique, valeur) values (@i1, @i2, @i3)";
									SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
									sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = id;
									sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = control.Tag;
									sqlCommand5.Parameters.Add("@i3", SqlDbType.VarChar).Value = radRadioButton.Text;
									bd.ouverture_bd(bd.cnn);
									sqlCommand5.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00019308 File Offset: 0x00017508
		private int test_validite_caracteristique()
		{
			int result = 1;
			foreach (object obj in this.radPanel1.Controls)
			{
				Control control = (Control)obj;
				bool flag = control.Name == "t" | control.Name == "su" | control.Name == "sm" | control.Name == "p1" | control.Name == "p2";
				if (flag)
				{
					string value = Convert.ToString(control.Tag);
					bd bd = new bd();
					fonction fonction = new fonction();
					bool flag2 = control.Name == "t";
					if (flag2)
					{
						string cmdText = "select champ_obligatoire, caracteristique_textbox.type from caracteristique inner join caracteristique_textbox on caracteristique.id = caracteristique_textbox.id_caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag3 = dataTable.Rows.Count != 0;
						if (flag3)
						{
							bool flag4 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 1;
							if (flag4)
							{
								bool flag5 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Entier";
								if (flag5)
								{
									bool flag6 = !fonction.isnumeric(control.Text);
									if (flag6)
									{
										result = 0;
									}
								}
								bool flag7 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Réel";
								if (flag7)
								{
									bool flag8 = !fonction.is_reel(control.Text);
									if (flag8)
									{
										result = 0;
									}
								}
								bool flag9 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Chaîne de caractères";
								if (flag9)
								{
									bool flag10 = fonction.DeleteSpace(control.Text) == "";
									if (flag10)
									{
										result = 0;
									}
								}
							}
							bool flag11 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) == 0;
							if (flag11)
							{
								bool flag12 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Entier" & fonction.DeleteSpace(control.Text) != "";
								if (flag12)
								{
									bool flag13 = !fonction.isnumeric(control.Text);
									if (flag13)
									{
										result = 0;
									}
								}
								bool flag14 = Convert.ToString(dataTable.Rows[0].ItemArray[1]) == "Réel" & fonction.DeleteSpace(control.Text) != "";
								if (flag14)
								{
									bool flag15 = !fonction.is_reel(control.Text);
									if (flag15)
									{
										result = 0;
									}
								}
							}
						}
					}
					bool flag16 = control.Name == "su";
					if (flag16)
					{
						string cmdText2 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag17 = dataTable2.Rows.Count != 0;
						if (flag17)
						{
							bool flag18 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]) == 1 & fonction.DeleteSpace(control.Text) == "";
							if (flag18)
							{
								result = 0;
							}
						}
					}
					bool flag19 = control.Name == "sm";
					if (flag19)
					{
						string cmdText3 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag20 = dataTable3.Rows.Count != 0;
						if (flag20)
						{
							bool flag21 = control is RadCheckedDropDownList;
							if (flag21)
							{
								RadCheckedDropDownList radCheckedDropDownList = (RadCheckedDropDownList)control;
								int num = 0;
								bool flag22 = radCheckedDropDownList.Items.Count != 0;
								if (flag22)
								{
									for (int i = 0; i < radCheckedDropDownList.Items.Count; i++)
									{
										bool @checked = radCheckedDropDownList.Items[i].Checked;
										if (@checked)
										{
											num = 1;
										}
									}
									bool flag23 = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0]) == 1 & num == 0;
									if (flag23)
									{
										result = 0;
									}
								}
							}
						}
					}
					bool flag24 = control.Name == "p1";
					if (flag24)
					{
						string cmdText4 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag25 = dataTable4.Rows.Count != 0;
						if (flag25)
						{
							bool flag26 = Convert.ToInt32(dataTable4.Rows[0].ItemArray[0]) == 1;
							if (flag26)
							{
								int num2 = 0;
								foreach (object obj2 in control.Controls)
								{
									Control control2 = (Control)obj2;
									bool flag27 = control2.Name == "cb";
									if (flag27)
									{
										RadCheckBox radCheckBox = (RadCheckBox)control2;
										bool checked2 = radCheckBox.Checked;
										if (checked2)
										{
											num2 = 1;
										}
									}
								}
								bool flag28 = num2 == 0;
								if (flag28)
								{
									result = 0;
								}
							}
						}
					}
					bool flag29 = control.Name == "p2";
					if (flag29)
					{
						string cmdText5 = "select champ_obligatoire from caracteristique where caracteristique.id = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = value;
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag30 = dataTable5.Rows.Count != 0;
						if (flag30)
						{
							bool flag31 = Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]) == 1;
							if (flag31)
							{
								int num3 = 0;
								foreach (object obj3 in control.Controls)
								{
									Control control3 = (Control)obj3;
									bool flag32 = control3.Name == "rb";
									if (flag32)
									{
										RadRadioButton radRadioButton = (RadRadioButton)control3;
										bool isChecked = radRadioButton.IsChecked;
										if (isChecked)
										{
											num3 = 1;
										}
									}
								}
								bool flag33 = num3 == 0;
								if (flag33)
								{
									result = 0;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00019AC4 File Offset: 0x00017CC4
		private void button1_Click_1(object sender, EventArgs e)
		{
			int num = this.test_validite_caracteristique();
			bool flag = num == 1;
			if (flag)
			{
				MessageBox.Show("Bravo");
			}
			bool flag2 = num == 0;
			if (flag2)
			{
				MessageBox.Show("Echec");
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00019B04 File Offset: 0x00017D04
		private int controle_nombre(string l)
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(l) == "" | fonction.is_reel(l);
			if (flag)
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00019B40 File Offset: 0x00017D40
		private void save_fournisseur(int id)
		{
			bd bd = new bd();
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
					if (@checked)
					{
						string cmdText = "select id from fournisseur where nom = @a and deleted = @d";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag2 = dataTable.Rows.Count != 0;
						if (flag2)
						{
							string cmdText2 = "insert into tableau_article_fournisseur(id_article, id_fournisseur) values (@i1, @i2)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00019CD0 File Offset: 0x00017ED0
		private void save_unite(int id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_unite_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "insert into tableau_article_unite(id_article, id_unite) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00019E1C File Offset: 0x0001801C
		private void save_classification(int id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList6.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_classification_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "insert into tableau_article_classification(id_article, id_classification) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00019F68 File Offset: 0x00018168
		private void save_stockage(int id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList4.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_stockage_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "insert into tableau_article_stockage(id_article, id_stockage) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0001A0B4 File Offset: 0x000182B4
		private void save_emplacement(int id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList5.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_emplacement_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList5.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "insert into tableau_article_emplacement(id_article, id_emplacement) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0001A200 File Offset: 0x00018400
		private void save_sous_famille(int id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList3.Text) != "";
			if (flag)
			{
				string cmdText = "select id from sous_famille where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList3.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "insert into tableau_article_sous_famille(id_article, id_sous_famille) values (@i1, @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0001A34C File Offset: 0x0001854C
		private void save_equipement(int id)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bd bd = new bd();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					string cmdText = "insert into tableau_article_equipement (id_article, id_equipement) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0001A434 File Offset: 0x00018634
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.TextBox3.Text) != "" & fonction.DeleteSpace(this.TextBox4.Text) != "" & fonction.DeleteSpace(this.TextBox5.Text) != "" & fonction.DeleteSpace(this.TextBox6.Text) != "" & fonction.DeleteSpace(this.TextBox7.Text) != "" & fonction.DeleteSpace(this.radDropDownList1.Text) != "" & fonction.DeleteSpace(this.radDropDownList3.Text) != "" & this.controle_fournisseur() == 1;
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.TextBox4.Text) & fonction.is_reel(this.TextBox5.Text) & fonction.is_reel(this.TextBox6.Text) & fonction.is_reel(this.TextBox7.Text) & fonction.is_reel(this.TextBox3.Text);
				if (flag2)
				{
					bool flag3 = this.controle_nombre(this.TextBox8.Text) == 1 & this.controle_nombre(this.TextBox9.Text) == 1 & this.controle_nombre(this.TextBox10.Text) == 1;
					if (flag3)
					{
						bool flag4 = this.test_validite_caracteristique() == 1;
						if (flag4)
						{
							string value = "";
							foreach (object obj in this.panel3.Controls)
							{
								Control control = (Control)obj;
								RadRadioButton radRadioButton = (RadRadioButton)control;
								bool isChecked = radRadioButton.IsChecked;
								if (isChecked)
								{
									value = radRadioButton.Text;
								}
							}
							bd bd = new bd();
							MemoryStream memoryStream = new MemoryStream();
							this.pictureBox1.Image.Save(memoryStream, this.pictureBox1.Image.RawFormat);
							byte[] value2 = new byte[0];
							value2 = memoryStream.ToArray();
							string cmdText = "insert into article (code_article, reference, designation, tva, prix_ht, stock_neuf, stock_use, stock_rebute, stock_mini, stock_maxi, stock_securite, marque, methode_gestion, commentaire, photo, deleted) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i12, @i13, @i14, @i15, @i16)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.create_code_articte(this.radDropDownList2.Text, this.radDropDownList3.Text);
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
							sqlCommand.Parameters.Add("@i4", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox3.Text);
							sqlCommand.Parameters.Add("@i5", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox4.Text);
							sqlCommand.Parameters.Add("@i6", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox5.Text);
							sqlCommand.Parameters.Add("@i7", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox6.Text);
							sqlCommand.Parameters.Add("@i8", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox7.Text);
							sqlCommand.Parameters.Add("@i9", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox8.Text);
							sqlCommand.Parameters.Add("@i10", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox9.Text);
							sqlCommand.Parameters.Add("@i11", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox10.Text);
							sqlCommand.Parameters.Add("@i12", SqlDbType.VarChar).Value = this.guna2TextBox2.Text;
							sqlCommand.Parameters.Add("@i13", SqlDbType.VarChar).Value = value;
							sqlCommand.Parameters.Add("@i14", SqlDbType.VarChar).Value = this.TextBox11.Text;
							sqlCommand.Parameters.Add("@i15", SqlDbType.Image).Value = value2;
							sqlCommand.Parameters.Add("@i16", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							int id = (int)sqlCommand.ExecuteScalar();
							bd.cnn.Close();
							this.save_caracteristique(id);
							this.save_classification(id);
							this.save_emplacement(id);
							this.save_stockage(id);
							this.save_unite(id);
							this.save_fournisseur(id);
							this.save_sous_famille(id);
							this.save_equipement(id);
							this.save_modification(id);
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.TextBox3.Clear();
							this.TextBox4.Clear();
							this.TextBox5.Clear();
							this.TextBox6.Clear();
							this.TextBox7.Clear();
							this.TextBox8.Clear();
							this.TextBox9.Clear();
							this.TextBox10.Clear();
							this.TextBox11.Clear();
							this.guna2TextBox1.Clear();
							this.guna2TextBox2.Clear();
							this.radPanel1.Controls.Clear();
							this.pictureBox1.Image = this.pictureBox3.Image;
							this.select_classification();
							this.select_emplacement();
							this.select_unite();
							this.select_stockage();
							this.select_fournisseur();
							this.select_famille();
							this.select_equipement();
							this.radGridView1.Rows.Clear();
							MessageBox.Show("L'article est ajouté avec succés");
						}
						else
						{
							MessageBox.Show("Erreur : Vérifier les caractéristiques de sous famille", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Stock mini, maxi et de sécurité sont des réels ou vides", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : TVA, Prix unitaire et quantités en stock sont des réels", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0001AB64 File Offset: 0x00018D64
		private int controle_fournisseur()
		{
			int result = 0;
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
					if (@checked)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0001ABD8 File Offset: 0x00018DD8
		private string create_code_articte(string f, string sf)
		{
			string result = "";
			bd bd = new bd();
			string cmdText = "select code_sous_famille, famille.code_famille, sous_famille.id from sous_famille inner join famille on sous_famille.id_famille = famille.id where famille.designation = @v1 and sous_famille.designation = @v2 and famille.deleted = @d and sous_famille.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = f;
			sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = sf;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id from tableau_article_sous_famille where id_sous_famille = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				int num = dataTable2.Rows.Count + 1;
				string[] array = new string[5];
				int num2 = 0;
				object obj = dataTable.Rows[0].ItemArray[1];
				array[num2] = ((obj != null) ? obj.ToString() : null);
				array[1] = "-";
				int num3 = 2;
				object obj2 = dataTable.Rows[0].ItemArray[0];
				array[num3] = ((obj2 != null) ? obj2.ToString() : null);
				array[3] = "-";
				array[4] = num.ToString();
				result = string.Concat(array);
			}
			return result;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0001AD6C File Offset: 0x00018F6C
		private double conversiontoreal(string s)
		{
			double result = 0.0;
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(s);
			if (flag)
			{
				result = Convert.ToDouble(s);
			}
			return result;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0001ADA4 File Offset: 0x00018FA4
		private void save_modification(int id)
		{
			bd bd = new bd();
			string cmdText = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox3.Text;
			sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox4.Text;
			sqlCommand.Parameters.Add("@i4", SqlDbType.Real).Value = this.TextBox5.Text;
			sqlCommand.Parameters.Add("@i5", SqlDbType.Real).Value = this.TextBox6.Text;
			sqlCommand.Parameters.Add("@i6", SqlDbType.Real).Value = this.TextBox7.Text;
			sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = DateTime.Today;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0001AEDC File Offset: 0x000190DC
		private void radDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.radDropDownList3.Items.Clear();
			this.radPanel1.Controls.Clear();
			bd bd = new bd();
			string cmdText = "select sous_famille.designation from sous_famille inner join famille on sous_famille.id_famille = famille.id where sous_famille.deleted =@d and famille.deleted = @d and famille.designation = @k order by sous_famille.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList3.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0001AFE4 File Offset: 0x000191E4
		private void radDropDownList3_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select id from sous_famille where deleted=@d and designation = @k";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = this.radDropDownList3.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.select_caracteristique(dataTable.Rows[0].ItemArray[0].ToString());
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0001B099 File Offset: 0x00019299
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}
	}
}
