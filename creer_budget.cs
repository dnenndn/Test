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

namespace GMAO
{
	// Token: 0x02000054 RID: 84
	public partial class creer_budget : Form
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x000A2158 File Offset: 0x000A0358
		public creer_budget()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
			this.radMenuItem2.Click += this.click_ajouter_frn;
			this.dataGridView1.CellClick += this.DataGridView1_CellClick;
			this.dataGridView2.CellClick += this.DataGridView2_CellClick;
			this.panel5.Visible = false;
			this.label8.Text = "";
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x000A21FC File Offset: 0x000A03FC
		private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 2;
			if (flag)
			{
				string text = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					this.dataGridView2.Rows.RemoveAt(e.RowIndex);
				}
			}
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000A2288 File Offset: 0x000A0488
		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 2;
			if (flag)
			{
				string text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bool flag3 = !this.radRadioButton10.IsChecked;
					if (flag3)
					{
						this.dataGridView1.Rows.RemoveAt(e.RowIndex);
					}
					else
					{
						MessageBox.Show("Erreur : Vous cochez Tous, la suppression est impossible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000A2342 File Offset: 0x000A0542
		private void creer_budget_Load(object sender, EventArgs e)
		{
			this.label8.Text = "Famille";
			this.select_famille();
			this.select_fournisseur();
			this.radDateTimePicker1.Value = DateTime.Today;
			this.select_duree();
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000A237C File Offset: 0x000A057C
		private void select_duree()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Chaque Jour");
			this.radDropDownList1.Items.Add("Chaque Semaine");
			this.radDropDownList1.Items.Add("Chaque 2 Semaine");
			this.radDropDownList1.Items.Add("Chaque Mois");
			this.radDropDownList1.Items.Add("Chaque 2 Mois");
			this.radDropDownList1.Items.Add("Chaque Trimestre");
			this.radDropDownList1.Items.Add("Chaque Simestre");
			this.radDropDownList1.Items.Add("Chaque Année");
			this.radDropDownList1.Text = "Chaque Mois";
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000A245C File Offset: 0x000A065C
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton8.IsChecked;
			if (isChecked)
			{
				this.panel5.Visible = false;
			}
			else
			{
				this.panel5.Visible = true;
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000A249C File Offset: 0x000A069C
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.panel5.Visible = true;
			}
			else
			{
				this.panel5.Visible = false;
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000A24DC File Offset: 0x000A06DC
		private void changement_label_categorie()
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.label8.Text = "Famille";
				this.select_famille();
			}
			else
			{
				bool isChecked2 = this.radRadioButton3.IsChecked;
				if (isChecked2)
				{
					this.label8.Text = "Sous Famille";
					this.select_sous_famille();
				}
				else
				{
					this.label8.Text = "Article";
					this.select_article();
				}
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000A255A File Offset: 0x000A075A
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.changement_label_categorie();
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000A2564 File Offset: 0x000A0764
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.changement_label_categorie();
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000A256E File Offset: 0x000A076E
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.changement_label_categorie();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000A2578 File Offset: 0x000A0778
		private void select_article()
		{
			this.radTreeView1.Nodes.Clear();
			this.dataGridView1.Rows.Clear();
			this.radRadioButton9.IsChecked = true;
			bd bd = new bd();
			string cmdText = "select id, reference, designation from article where deleted = @d";
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

		// Token: 0x060003DE RID: 990 RVA: 0x000A26E8 File Offset: 0x000A08E8
		private void select_fournisseur()
		{
			this.radTreeView2.Nodes.Clear();
			this.dataGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, code_fournisseur, nom from fournisseur where deleted = @d";
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
					this.radTreeView2.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000A284C File Offset: 0x000A0A4C
		private void select_sous_famille()
		{
			this.radTreeView1.Nodes.Clear();
			this.dataGridView1.Rows.Clear();
			this.radRadioButton9.IsChecked = true;
			bd bd = new bd();
			string cmdText = "select id, code_sous_famille, designation from sous_famille where deleted = @d";
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

		// Token: 0x060003E0 RID: 992 RVA: 0x000A29BC File Offset: 0x000A0BBC
		private void select_famille()
		{
			this.radTreeView1.Nodes.Clear();
			this.dataGridView1.Rows.Clear();
			this.radRadioButton9.IsChecked = true;
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

		// Token: 0x060003E1 RID: 993 RVA: 0x000A2B2C File Offset: 0x000A0D2C
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.Text
					});
				}
				else
				{
					bool isChecked = this.radRadioButton4.IsChecked;
					if (isChecked)
					{
						MessageBox.Show("Erreur : La Famille est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					bool isChecked2 = this.radRadioButton3.IsChecked;
					if (isChecked2)
					{
						MessageBox.Show("Erreur : La Sous Famille est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					bool isChecked3 = this.radRadioButton5.IsChecked;
					if (isChecked3)
					{
						MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000A2C1C File Offset: 0x000A0E1C
		private void click_ajouter_frn(object sender, EventArgs e)
		{
			bool flag = this.radTreeView2.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView2.SelectedNode;
				bool flag2 = this.search_tableau_frn(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.dataGridView2.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.Text
					});
				}
				else
				{
					MessageBox.Show("Erreur : Le fournisseur est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000A2CAC File Offset: 0x000A0EAC
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = this.dataGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.dataGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x000A2D34 File Offset: 0x000A0F34
		private int search_tableau_frn(string s)
		{
			int result = 0;
			bool flag = this.dataGridView2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.dataGridView2.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000A2DBC File Offset: 0x000A0FBC
		private void radRadioButton10_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton10.IsChecked;
			if (isChecked)
			{
				this.dataGridView1.Rows.Clear();
				foreach (RadTreeNode radTreeNode in this.radTreeView1.Nodes)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						Convert.ToString(radTreeNode.Tag),
						radTreeNode.Text
					});
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000A2E5C File Offset: 0x000A105C
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000A2E76 File Offset: 0x000A1076
		private void guna2TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView2.Filter = this.guna2TextBox3.Text;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000A2E90 File Offset: 0x000A1090
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "";
			if (flag)
			{
				string cmdText = "select id from budget where nom = @n";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					bool flag3 = fonction.DeleteSpace(this.guna2TextBox1.Text) != "";
					if (flag3)
					{
						bool flag4 = fonction.is_reel(this.guna2TextBox1.Text);
						if (flag4)
						{
							bool flag5 = Convert.ToDouble(this.guna2TextBox1.Text) > 0.0;
							if (flag5)
							{
								string value = "Oui";
								bool isChecked = this.radRadioButton2.IsChecked;
								if (isChecked)
								{
									value = "Non";
								}
								int num = 1;
								int num2 = 1;
								int num3 = 1;
								bool isChecked2 = this.radRadioButton3.IsChecked;
								if (isChecked2)
								{
									num = 2;
								}
								bool isChecked3 = this.radRadioButton5.IsChecked;
								if (isChecked3)
								{
									num = 3;
								}
								bool isChecked4 = this.radRadioButton7.IsChecked;
								if (isChecked4)
								{
									num2 = 2;
									bool isChecked5 = this.radRadioButton11.IsChecked;
									if (isChecked5)
									{
										num2 = 3;
									}
								}
								bool isChecked6 = this.radRadioButton9.IsChecked;
								if (isChecked6)
								{
									num3 = 2;
								}
								bool isChecked7 = this.radRadioButton6.IsChecked;
								if (isChecked7)
								{
									num3 = 3;
								}
								string cmdText2 = "insert into budget (nom, description, date_creation, duree, montant, creation_auto, categorie, fournisseur_choix, categorie_choix, creer_nv) values (@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9, @v10)SELECT CAST(scope_identity() AS int)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
								sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
								sqlCommand2.Parameters.Add("@v3", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
								sqlCommand2.Parameters.Add("@v4", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
								sqlCommand2.Parameters.Add("@v5", SqlDbType.Real).Value = this.guna2TextBox1.Text;
								sqlCommand2.Parameters.Add("@v6", SqlDbType.VarChar).Value = value;
								sqlCommand2.Parameters.Add("@v7", SqlDbType.Int).Value = num;
								sqlCommand2.Parameters.Add("@v8", SqlDbType.Int).Value = num2;
								sqlCommand2.Parameters.Add("@v9", SqlDbType.Int).Value = num3;
								sqlCommand2.Parameters.Add("@v10", SqlDbType.Int).Value = 0;
								bd.ouverture_bd(bd.cnn);
								int num4 = (int)sqlCommand2.ExecuteScalar();
								bd.cnn.Close();
								bool flag6 = !this.radRadioButton10.IsChecked;
								if (flag6)
								{
									bool flag7 = this.dataGridView1.Rows.Count != 0;
									if (flag7)
									{
										for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
										{
											string cmdText3 = "insert into budget_categorie (id_budget, id_categorie) values(@v1, @v2)";
											SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
											sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = num4;
											sqlCommand3.Parameters.Add("@v2", SqlDbType.Int).Value = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
											bd.ouverture_bd(bd.cnn);
											sqlCommand3.ExecuteNonQuery();
											bd.cnn.Close();
										}
									}
								}
								bool flag8 = !this.radRadioButton8.IsChecked;
								if (flag8)
								{
									bool flag9 = this.dataGridView2.Rows.Count != 0;
									if (flag9)
									{
										for (int j = 0; j < this.dataGridView2.Rows.Count; j++)
										{
											string cmdText4 = "insert into budget_fournisseur (id_budget, id_fournisseur) values(@v1, @v2)";
											SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
											sqlCommand4.Parameters.Add("@v1", SqlDbType.Int).Value = num4;
											sqlCommand4.Parameters.Add("@v2", SqlDbType.Int).Value = this.dataGridView2.Rows[j].Cells[0].Value.ToString();
											bd.ouverture_bd(bd.cnn);
											sqlCommand4.ExecuteNonQuery();
											bd.cnn.Close();
										}
									}
								}
								MessageBox.Show("Création de budget avec succés");
								this.label8.Text = "Famille";
								this.radRadioButton4.IsChecked = true;
								this.select_famille();
								this.select_fournisseur();
								this.select_duree();
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.guna2TextBox1.Clear();
								this.guna2TextBox2.Clear();
								this.guna2TextBox3.Clear();
							}
							else
							{
								MessageBox.Show("Erreur : le montant de budget doit être un réel strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : le montant de budget doit être un réel strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Veuillez choisir le montant de budget", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Le nom de budget est déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Veuillez choisir le nom de budget", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
