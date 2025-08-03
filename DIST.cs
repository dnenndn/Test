using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000069 RID: 105
	public partial class DIST : Form
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x000D6024 File Offset: 0x000D4224
		public DIST()
		{
			this.InitializeComponent();
			this.radTreeView1.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(this.RadTreeView1_SelectedNodeChanged);
			this.radTreeView2.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(this.RadTreeView2_SelectedNodeChanged);
			this.radTreeView3.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(this.RadTreeView3_SelectedNodeChanged);
			this.select_article();
			this.select_article_ref();
			this.dataGridView1.CellClick += this.DataGridView1_CellClick;
			this.dataGridView2.CellClick += this.DataGridView2_CellClick;
			this.dataGridView3.CellClick += this.DataGridView3_CellClick;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x000D60E5 File Offset: 0x000D42E5
		private void DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			this.action_tableau_3(sender, e);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x000D60F4 File Offset: 0x000D42F4
		private void RadTreeView3_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
		{
			bool flag = this.radTreeView3.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView3.SelectedNode;
				this.select_activite_3(selectedNode);
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x000D612A File Offset: 0x000D432A
		private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			this.action_tableau_2(sender, e);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000D6138 File Offset: 0x000D4338
		private void RadTreeView2_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
		{
			bool flag = this.radTreeView2.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView2.SelectedNode;
				this.select_activite_2(selectedNode);
			}
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000D616E File Offset: 0x000D436E
		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			this.action_tableau_1(sender, e);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x000D617C File Offset: 0x000D437C
		private void RadTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				this.select_activite(selectedNode);
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x000D61B2 File Offset: 0x000D43B2
		private void DIST_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000D61B8 File Offset: 0x000D43B8
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select id, designation from article where deleted =@d order by designation";
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
					RadTreeNode radTreeNode2 = new RadTreeNode();
					radTreeNode.Text = (dataTable.Rows[i].ItemArray[1].ToString() ?? "");
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode2.Text = (dataTable.Rows[i].ItemArray[1].ToString() ?? "");
					radTreeNode2.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode2.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
					this.radTreeView2.Nodes.Add(radTreeNode2);
				}
			}
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000D6368 File Offset: 0x000D4568
		private void select_article_ref()
		{
			this.radTreeView3.ShowNodeToolTips = true;
			bd bd = new bd();
			string cmdText = "select magasin_sous_traitance.id, article.designation, ref_interne from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = (dataTable.Rows[i].ItemArray[2].ToString() ?? "");
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView3.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x000D6480 File Offset: 0x000D4680
		private void select_activite(RadTreeNode n)
		{
			this.radContextMenu1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from activite where type_article = @i and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select id from activite_famille where id_activite = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count == 0;
					if (flag2)
					{
						RadMenuItem m = new RadMenuItem();
						m.Text = dataTable.Rows[i].ItemArray[1].ToString();
						m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						this.radContextMenu1.Items.Add(m);
						RadMenuItem radMenuItem = new RadMenuItem();
						radMenuItem.Text = "Neuf";
						RadMenuItem radMenuItem2 = new RadMenuItem();
						radMenuItem2.Text = "Usé";
						RadMenuItem radMenuItem3 = new RadMenuItem();
						radMenuItem3.Text = "Rebuté";
						m.Items.Add(radMenuItem);
						m.Items.Add(radMenuItem2);
						m.Items.Add(radMenuItem3);
						radMenuItem.Click += delegate(object s, EventArgs f)
						{
							this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Neuf");
						};
						radMenuItem2.Click += delegate(object s, EventArgs f)
						{
							this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Usé");
						};
						radMenuItem3.Click += delegate(object s, EventArgs f)
						{
							this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Rebuté");
						};
					}
					else
					{
						string cmdText3 = "select id from activite_sous_famille where id_activite = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag3 = dataTable3.Rows.Count == 0;
						if (flag3)
						{
							string cmdText4 = "select id from activite_famille where id_famille in (select famille.id from tableau_article_sous_famille inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where id_article = @n) and id_activite = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@n", SqlDbType.Int).Value = n.Tag;
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							bool flag4 = dataTable4.Rows.Count != 0;
							if (flag4)
							{
								RadMenuItem m = new RadMenuItem();
								m.Text = dataTable.Rows[i].ItemArray[1].ToString();
								m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
								this.radContextMenu1.Items.Add(m);
								RadMenuItem radMenuItem4 = new RadMenuItem();
								radMenuItem4.Text = "Neuf";
								RadMenuItem radMenuItem5 = new RadMenuItem();
								radMenuItem5.Text = "Usé";
								RadMenuItem radMenuItem6 = new RadMenuItem();
								radMenuItem6.Text = "Rebuté";
								m.Items.Add(radMenuItem4);
								m.Items.Add(radMenuItem5);
								m.Items.Add(radMenuItem6);
								radMenuItem4.Click += delegate(object s, EventArgs f)
								{
									this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Neuf");
								};
								radMenuItem5.Click += delegate(object s, EventArgs f)
								{
									this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Usé");
								};
								radMenuItem6.Click += delegate(object s, EventArgs f)
								{
									this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Rebuté");
								};
							}
						}
						else
						{
							string cmdText5 = "select id from activite_sous_famille where id_sous_famille in (select sous_famille.id from tableau_article_sous_famille inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id where id_article = @n) and id_activite = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@n", SqlDbType.Int).Value = n.Tag;
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							bool flag5 = dataTable5.Rows.Count != 0;
							if (flag5)
							{
								RadMenuItem m = new RadMenuItem();
								m.Text = dataTable.Rows[i].ItemArray[1].ToString();
								m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
								this.radContextMenu1.Items.Add(m);
								RadMenuItem radMenuItem7 = new RadMenuItem();
								radMenuItem7.Text = "Neuf";
								RadMenuItem radMenuItem8 = new RadMenuItem();
								radMenuItem8.Text = "Usé";
								RadMenuItem radMenuItem9 = new RadMenuItem();
								radMenuItem9.Text = "Rebuté";
								m.Items.Add(radMenuItem7);
								m.Items.Add(radMenuItem8);
								m.Items.Add(radMenuItem9);
								radMenuItem7.Click += delegate(object s, EventArgs f)
								{
									this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Neuf");
								};
								radMenuItem8.Click += delegate(object s, EventArgs f)
								{
									this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Usé");
								};
								radMenuItem9.Click += delegate(object s, EventArgs f)
								{
									this.click_item(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text, "Rebuté");
								};
							}
						}
					}
				}
			}
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x000D6B50 File Offset: 0x000D4D50
		private void select_activite_3(RadTreeNode n)
		{
			this.radContextMenu3.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from activite where type_article = @i and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select id from activite_famille where id_activite = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count == 0;
					if (flag2)
					{
						string cmdText3 = "select id_article, article.designation from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id  where magasin_sous_traitance.id = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = n.Tag;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dt5 = new DataTable();
						sqlDataAdapter3.Fill(dt5);
						RadMenuItem m = new RadMenuItem();
						m.Text = dataTable.Rows[i].ItemArray[1].ToString();
						m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						this.radContextMenu3.Items.Add(m);
						m.Click += delegate(object s, EventArgs f)
						{
							this.click_item_3(m.Tag.ToString(), n.Tag.ToString(), m.Text, n.Text.ToString(), dt5.Rows[0].ItemArray[1].ToString());
						};
					}
					else
					{
						string cmdText4 = "select id from activite_sous_famille where id_activite = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter4.Fill(dataTable3);
						bool flag3 = dataTable3.Rows.Count == 0;
						if (flag3)
						{
							string cmdText5 = "select id_article, article.designation from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id  where magasin_sous_traitance.id = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = n.Tag;
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							DataTable dt5 = new DataTable();
							sqlDataAdapter5.Fill(dt5);
							string cmdText6 = "select id from activite_famille where id_famille in (select famille.id from tableau_article_sous_famille inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where id_article = @n) and id_activite = @i";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand6.Parameters.Add("@n", SqlDbType.Int).Value = dt5.Rows[0].ItemArray[0].ToString();
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter6.Fill(dataTable4);
							bool flag4 = dataTable4.Rows.Count != 0;
							if (flag4)
							{
								RadMenuItem m = new RadMenuItem();
								m.Text = dataTable.Rows[i].ItemArray[1].ToString();
								m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
								this.radContextMenu3.Items.Add(m);
								m.Click += delegate(object s, EventArgs f)
								{
									this.click_item_3(m.Tag.ToString(), n.Tag.ToString(), m.Text, n.Text.ToString(), dt5.Rows[0].ItemArray[1].ToString());
								};
							}
						}
						else
						{
							string cmdText7 = "select id_article, article.designation from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id  where magasin_sous_traitance.id = @i";
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
							sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = n.Tag;
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
							DataTable dt5 = new DataTable();
							sqlDataAdapter7.Fill(dt5);
							string cmdText8 = "select id from activite_sous_famille where id_sous_famille in (select sous_famille.id from tableau_article_sous_famille inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id where id_article = @n) and id_activite = @i";
							SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
							sqlCommand8.Parameters.Add("@n", SqlDbType.Int).Value = dt5.Rows[0].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(sqlCommand8);
							sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter8.Fill(dataTable5);
							bool flag5 = dataTable5.Rows.Count != 0;
							if (flag5)
							{
								RadMenuItem m = new RadMenuItem();
								m.Text = dataTable.Rows[i].ItemArray[1].ToString();
								m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
								this.radContextMenu3.Items.Add(m);
								m.Click += delegate(object s, EventArgs f)
								{
									this.click_item_3(m.Tag.ToString(), n.Tag.ToString(), m.Text, n.Text.ToString(), dt5.Rows[0].ItemArray[1].ToString());
								};
							}
						}
					}
				}
			}
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x000D71B6 File Offset: 0x000D53B6
		private void click_item(string id_art, string des_art, string id_act, string des_activ, string type_stock)
		{
			this.dataGridView1.Rows.Add(new object[]
			{
				id_act,
				id_art,
				des_activ,
				des_art,
				"",
				type_stock
			});
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000D71EE File Offset: 0x000D53EE
		private void click_item_2(string id_art, string des_art, string id_act, string des_activ)
		{
			this.dataGridView2.Rows.Add(new object[]
			{
				id_act,
				id_art,
				des_activ,
				des_art
			});
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x000D7219 File Offset: 0x000D5419
		private void click_item_3(string id_act, string id_ref, string act, string ref_interne, string art)
		{
			this.dataGridView3.Rows.Add(new object[]
			{
				id_act,
				id_ref,
				act,
				ref_interne,
				art
			});
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x000D724C File Offset: 0x000D544C
		private void action_tableau_1(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						string text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.dataGridView1.Rows.RemoveAt(e.RowIndex);
						}
					}
				}
			}
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x000D730C File Offset: 0x000D550C
		private void action_tableau_3(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.dataGridView3.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag3)
					{
						string text = this.dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.dataGridView3.Rows.RemoveAt(e.RowIndex);
						}
					}
				}
			}
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x000D73CC File Offset: 0x000D55CC
		private void action_tableau_2(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.dataGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag3)
					{
						string text = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.dataGridView2.Rows.RemoveAt(e.RowIndex);
						}
					}
				}
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000D748C File Offset: 0x000D568C
		private void select_activite_2(RadTreeNode n)
		{
			this.radContextMenu2.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from activite where type_article = @i and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 2;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select id from activite_famille where id_activite = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count == 0;
					if (flag2)
					{
						RadMenuItem m = new RadMenuItem();
						m.Text = dataTable.Rows[i].ItemArray[1].ToString();
						m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
						this.radContextMenu2.Items.Add(m);
						m.Click += delegate(object s, EventArgs f)
						{
							this.click_item_2(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text);
						};
					}
					else
					{
						string cmdText3 = "select id from activite_sous_famille where id_activite = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag3 = dataTable3.Rows.Count == 0;
						if (flag3)
						{
							string cmdText4 = "select id from activite_famille where id_famille in (select famille.id from tableau_article_sous_famille inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id inner join famille on sous_famille.id_famille = famille.id where id_article = @n) and id_activite = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@n", SqlDbType.Int).Value = n.Tag;
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							bool flag4 = dataTable4.Rows.Count != 0;
							if (flag4)
							{
								RadMenuItem m = new RadMenuItem();
								m.Text = dataTable.Rows[i].ItemArray[1].ToString();
								m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
								this.radContextMenu2.Items.Add(m);
								m.Click += delegate(object s, EventArgs f)
								{
									this.click_item_2(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text);
								};
							}
						}
						else
						{
							string cmdText5 = "select id from activite_sous_famille where id_sous_famille in (select sous_famille.id from tableau_article_sous_famille inner join sous_famille on tableau_article_sous_famille.id_sous_famille = sous_famille.id where id_article = @n) and id_activite = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@n", SqlDbType.Int).Value = n.Tag;
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							bool flag5 = dataTable5.Rows.Count != 0;
							if (flag5)
							{
								RadMenuItem m = new RadMenuItem();
								m.Text = dataTable.Rows[i].ItemArray[1].ToString();
								m.Tag = dataTable.Rows[i].ItemArray[0].ToString();
								this.radContextMenu2.Items.Add(m);
								m.Click += delegate(object s, EventArgs f)
								{
									this.click_item_2(n.Tag.ToString(), n.Text, m.Tag.ToString(), m.Text);
								};
							}
						}
					}
				}
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x000D7983 File Offset: 0x000D5B83
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x000D799D File Offset: 0x000D5B9D
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView2.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x000D79B8 File Offset: 0x000D5BB8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.dataGridView1.Rows.Count != 0 | this.dataGridView2.Rows.Count != 0 | this.dataGridView3.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = this.test_grid1() == 1;
				if (flag2)
				{
					bool flag3 = this.test_grid2() == 1;
					if (flag3)
					{
						bool flag4 = this.test_existe_ref() == 0;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "insert into demande_sous_traitance (date_creation, heure_creation, createur, statut) values (@i3, @i4, @i5, @i6)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(Convert.ToString(DateTime.Now), 12, 8);
							sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							int num = (int)sqlCommand.ExecuteScalar();
							bd.cnn.Close();
							bool flag5 = this.dataGridView2.Rows.Count != 0;
							if (flag5)
							{
								for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
								{
									string cmdText2 = "insert into ds_nv_article (id_demande, id_article, quantite, id_activite, description) values (@i1, @i2, @i3, @i4, @i5)";
									SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
									sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
									sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
									sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.dataGridView2.Rows[i].Cells[4].Value.ToString();
									sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
									sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = Convert.ToString(this.dataGridView2.Rows[i].Cells[5].Value);
									bd.ouverture_bd(bd.cnn);
									sqlCommand2.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							bool flag6 = this.dataGridView1.Rows.Count != 0;
							if (flag6)
							{
								for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
								{
									string cmdText3 = "insert into magasin_sous_traitance (id_article, ref_interne, reception, nbr_reparation, demande_actuel, activite_actuel, description, emplacement_actuel) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8)";
									SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
									sqlCommand3.Parameters.Add("@i5", SqlDbType.Int).Value = num;
									sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
									sqlCommand3.Parameters.Add("@i6", SqlDbType.Int).Value = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
									sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
									sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
									sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
									sqlCommand3.Parameters.Add("@i7", SqlDbType.VarChar).Value = Convert.ToString(this.dataGridView1.Rows[j].Cells[6].Value);
									sqlCommand3.Parameters.Add("@i8", SqlDbType.VarChar).Value = "Magasin";
									string cmdText4 = "";
									bool flag7 = this.dataGridView1.Rows[j].Cells[5].Value.ToString() == "Neuf";
									if (flag7)
									{
										cmdText4 = "update article set stock_neuf = stock_neuf - 1 where id = @i";
									}
									bool flag8 = this.dataGridView1.Rows[j].Cells[5].Value.ToString() == "Usé";
									if (flag8)
									{
										cmdText4 = "update article set stock_use = stock_use - 1 where id = @i";
									}
									bool flag9 = this.dataGridView1.Rows[j].Cells[5].Value.ToString() == "Rebuté";
									if (flag9)
									{
										cmdText4 = "update article set stock_rebute = stock_rebute - 1 where id = @i";
									}
									SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
									sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
									bd.ouverture_bd(bd.cnn);
									sqlCommand3.ExecuteNonQuery();
									sqlCommand4.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							bool flag10 = this.dataGridView3.Rows.Count != 0;
							if (flag10)
							{
								for (int k = 0; k < this.dataGridView3.Rows.Count; k++)
								{
									string cmdText5 = "update magasin_sous_traitance set reception = @d, demande_actuel = @i1, activite_actuel = @i2, description = @i3 where id = @i4";
									SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
									sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = num;
									sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = this.dataGridView3.Rows[k].Cells[0].Value.ToString();
									sqlCommand5.Parameters.Add("@i4", SqlDbType.Int).Value = this.dataGridView3.Rows[k].Cells[1].Value.ToString();
									sqlCommand5.Parameters.Add("@i3", SqlDbType.VarChar).Value = Convert.ToString(this.dataGridView3.Rows[k].Cells[5].Value);
									sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
									bd.ouverture_bd(bd.cnn);
									sqlCommand5.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							MessageBox.Show("La demande sous traitance est enregistrée avec succés");
							this.dataGridView1.Rows.Clear();
							this.dataGridView2.Rows.Clear();
						}
						else
						{
							MessageBox.Show("Erreur : le référence interne de la ligne " + this.test_existe_ref().ToString() + " du tableau est déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Il faut choisir la quantité de chaque article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Il faut choisir un référence interne pour chaque article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Il faut choisir au moin un article", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x000D81F8 File Offset: 0x000D63F8
		private int test_grid1()
		{
			int result = 1;
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					bool flag2 = fonction.DeleteSpace(Convert.ToString(this.dataGridView1.Rows[i].Cells[4].Value)) == "";
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x000D8294 File Offset: 0x000D6494
		private int test_grid2()
		{
			int result = 1;
			bool flag = this.dataGridView2.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.dataGridView2.Rows[i].Cells[4].Value));
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000D8328 File Offset: 0x000D6528
		private int test_existe_ref()
		{
			int result = 0;
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				bd bd = new bd();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					string cmdText = "select id from magasin_sous_traitance where ref_interne = @v";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						result = i + 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000D8414 File Offset: 0x000D6614
		private void guna2TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView3.Filter = this.guna2TextBox3.Text;
		}
	}
}
