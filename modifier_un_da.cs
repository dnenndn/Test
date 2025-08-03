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
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000149 RID: 329
	public partial class modifier_un_da : Form
	{
		// Token: 0x06000EBC RID: 3772 RVA: 0x0023CC30 File Offset: 0x0023AE30
		public modifier_un_da()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			modifier_un_da.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			modifier_un_da.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			modifier_un_da.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0023CCBC File Offset: 0x0023AEBC
		private void modifier_un_da_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label6.Text = liste_da.id_da;
			this.select_periode();
			this.select_da();
			this.select_article();
			modifier_un_da.table.Columns.Clear();
			modifier_un_da.table.Columns.Add("column1");
			modifier_un_da.table.Columns.Add("column2");
			modifier_un_da.table.Columns.Add("column3");
			modifier_un_da.table.Rows.Clear();
			string cmdText = "select id_article, equipement.id, equipement.designation from da_article_equipement inner join equipement on da_article_equipement.id_equipement = equipement.id where id_da = @l";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@l", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					modifier_un_da.table.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
			}
			modifier_un_da.select_equipement();
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x0023CE65 File Offset: 0x0023B065
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0023CE80 File Offset: 0x0023B080
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = modifier_un_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string cmdText = "select id from tableau_article_equipement where id_article = @i";
						bd bd = new bd();
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = modifier_un_da.radGridView1.Rows[e.RowIndex].Cells[0].Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count != 0;
						if (flag4)
						{
							modifier_un_da.id_article = modifier_un_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
							modifier_un_da.designation_article = modifier_un_da.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
							da_add_equipement_modifier_encour da_add_equipement_modifier_encour = new da_add_equipement_modifier_encour();
							da_add_equipement_modifier_encour.Show();
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 5;
					if (flag5)
					{
						string b = modifier_un_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag6 = dialogResult == DialogResult.Yes;
						if (flag6)
						{
							modifier_un_da.radGridView1.Rows.RemoveAt(e.RowIndex);
							bool flag7 = creer_da.table.Rows.Count != 0;
							if (flag7)
							{
								for (int i = 0; i < creer_da.table.Rows.Count; i++)
								{
									bool flag8 = creer_da.table.Rows[i].ItemArray[0].ToString() == b;
									if (flag8)
									{
										creer_da.table.Rows.Remove(creer_da.table.Rows[i]);
										i--;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x0023D0EC File Offset: 0x0023B2EC
		private int test_validation_tableau()
		{
			int result = 0;
			bool flag = modifier_un_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < modifier_un_da.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(modifier_un_da.radGridView1.Rows[i].Cells[2].Value.ToString()) | modifier_un_da.radGridView1.Rows[i].Cells[2].Value.ToString() == "0";
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x0023D1B4 File Offset: 0x0023B3B4
		private void select_periode()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Jour");
			this.radDropDownList1.Items.Add("Semaine");
			this.radDropDownList1.Items.Add("Mois");
			this.radDropDownList1.Items.Add("Année");
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0023D22C File Offset: 0x0023B42C
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select id, designation ,stock_neuf from article where deleted =@d order by designation";
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
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString() + "- qt: " + dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0023D370 File Offset: 0x0023B570
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select id from tableau_article_equipement where id_article = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode.Tag;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						modifier_un_da.radGridView1.Rows.Add(new object[]
						{
							Convert.ToString(selectedNode.Tag),
							selectedNode.ToolTipText,
							0,
							""
						});
						modifier_un_da.radGridView1.Rows[modifier_un_da.radGridView1.Rows.Count - 1].Cells[5].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					}
					else
					{
						modifier_un_da.radGridView1.Rows.Add(new object[]
						{
							Convert.ToString(selectedNode.Tag),
							selectedNode.ToolTipText,
							0,
							"",
							Resources.icons8_structure_en_arbre_80,
							Resources.icons8_supprimer_pour_toujours_100__4_
						});
					}
					modifier_un_da.radGridView1.Templates.Clear();
					modifier_un_da.select_equipement();
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x0023D51C File Offset: 0x0023B71C
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = modifier_un_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < modifier_un_da.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(modifier_un_da.radGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0023D5A0 File Offset: 0x0023B7A0
		private void select_da()
		{
			bd bd = new bd();
			modifier_un_da.radGridView1.Rows.Clear();
			string cmdText = "select delai, periode from demande_achat where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox5.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.radDropDownList1.Text = dataTable.Rows[0].ItemArray[1].ToString();
			}
			string cmdText2 = "select id_article, article.designation, qt, motif from da_article inner join article on da_article.id_article = article.id where id_da = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					string cmdText3 = "select id from tableau_article_equipement where id_article = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						modifier_un_da.radGridView1.Rows.Add(new object[]
						{
							dataTable2.Rows[i].ItemArray[0],
							dataTable2.Rows[i].ItemArray[1],
							dataTable2.Rows[i].ItemArray[2],
							dataTable2.Rows[i].ItemArray[3],
							Resources.icons8_structure_en_arbre_80,
							Resources.icons8_supprimer_pour_toujours_100__4_
						});
					}
					else
					{
						modifier_un_da.radGridView1.Rows.Add(new object[]
						{
							dataTable2.Rows[i].ItemArray[0],
							dataTable2.Rows[i].ItemArray[1],
							dataTable2.Rows[i].ItemArray[2],
							dataTable2.Rows[i].ItemArray[3]
						});
						modifier_un_da.radGridView1.Rows[modifier_un_da.radGridView1.Rows.Count - 1].Cells[5].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					}
				}
			}
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x0023D8BC File Offset: 0x0023BABC
		private void save_da_article(int id)
		{
			bd bd = new bd();
			string cmdText = "delete da_article where id_da = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			string cmdText2 = "delete da_article_equipement where id_da = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id;
			bd.ouverture_bd(bd.cnn);
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			for (int i = 0; i < modifier_un_da.radGridView1.Rows.Count; i++)
			{
				string cmdText3 = "insert into da_article (id_da, id_article, qt, motif, qt_restant) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
				sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = modifier_un_da.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = modifier_un_da.radGridView1.Rows[i].Cells[2].Value.ToString();
				sqlCommand3.Parameters.Add("@i4", SqlDbType.VarChar).Value = modifier_un_da.radGridView1.Rows[i].Cells[3].Value.ToString();
				sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = modifier_un_da.radGridView1.Rows[i].Cells[2].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				int id_lis = (int)sqlCommand3.ExecuteScalar();
				bd.cnn.Close();
				this.save_da_article_equipement(id, id_lis, modifier_un_da.radGridView1.Rows[i].Cells[0].Value.ToString());
			}
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x0023DB28 File Offset: 0x0023BD28
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox5.Text) != "" & fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				bool flag2 = this.test_validation_tableau() == 1;
				if (flag2)
				{
					bool flag3 = this.test_obligatoire_equipement() == 1;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update demande_achat set delai = @i1, periode = @i2 where id = @i3";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Real).Value = this.TextBox5.Text;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = this.label6.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.save_da_article(Convert.ToInt32(this.label6.Text));
						this.modifier_da(Convert.ToInt32(this.label6.Text));
						MessageBox.Show("DA est modifié avec succés");
						liste_da.remplissage_tableau(0);
						base.Close();
					}
					else
					{
						MessageBox.Show("Erreur : Choisir les différentes liaisons articles-équipements ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier le tableau des articles ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x0023DCDC File Offset: 0x0023BEDC
		private void modifier_da(int i)
		{
			bd bd = new bd();
			string cmdText = "insert into da_modifier (id_da, modifier_par, date_modifier, heure_modifier) values (@i1, @i2, @i3, @i4)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = i;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
			sqlCommand.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
			sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x0023DDB0 File Offset: 0x0023BFB0
		public static void select_equipement()
		{
			modifier_un_da.radGridView1.Templates.Clear();
			GridViewTemplate gridViewTemplate = new GridViewTemplate();
			gridViewTemplate.Caption = "Liaison Equipement";
			gridViewTemplate.DataSource = modifier_un_da.table;
			gridViewTemplate.AllowRowResize = false;
			gridViewTemplate.ShowColumnHeaders = true;
			gridViewTemplate.AllowAddNewRow = false;
			gridViewTemplate.Columns["column1"].Width = 200;
			gridViewTemplate.Columns["column2"].Width = 200;
			gridViewTemplate.Columns["column3"].Width = 400;
			gridViewTemplate.Columns[0].IsVisible = false;
			gridViewTemplate.AllowEditRow = false;
			gridViewTemplate.Columns[1].HeaderText = "ID Equipement";
			gridViewTemplate.Columns[2].HeaderText = "Désignation";
			gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			modifier_un_da.radGridView1.Templates.Insert(0, gridViewTemplate);
			GridViewRelation gridViewRelation = new GridViewRelation(modifier_un_da.radGridView1.MasterTemplate);
			gridViewRelation.ChildTemplate = gridViewTemplate;
			gridViewRelation.ParentColumnNames.Add(modifier_un_da.radGridView1.MasterTemplate.Columns[0].Name);
			gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
			modifier_un_da.radGridView1.Relations.Add(gridViewRelation);
			modifier_un_da.radGridView1.MasterTemplate.CollapseAll();
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x0023DF54 File Offset: 0x0023C154
		private int test_obligatoire_equipement()
		{
			bd bd = new bd();
			int result = 1;
			bool flag = modifier_un_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < modifier_un_da.radGridView1.Rows.Count; i++)
				{
					string cmdText = "select id from tableau_article_equipement where id_article = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = modifier_un_da.radGridView1.Rows[i].Cells[0].Value.ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						bool flag3 = this.recherche_data_table(modifier_un_da.table, modifier_un_da.radGridView1.Rows[i].Cells[0].Value.ToString()) == 0;
						if (flag3)
						{
							result = 0;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x0023E078 File Offset: 0x0023C278
		private int recherche_data_table(DataTable table, string s)
		{
			int result = 0;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				bool flag = s == table.Rows[i].ItemArray[0].ToString();
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x0023E0D4 File Offset: 0x0023C2D4
		private void save_da_article_equipement(int id, int id_lis, string id_art)
		{
			bd bd = new bd();
			bool flag = modifier_un_da.table.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < modifier_un_da.table.Rows.Count; i++)
				{
					bool flag2 = modifier_un_da.table.Rows[i].ItemArray[0].ToString() == id_art;
					if (flag2)
					{
						string cmdText = "insert into da_article_equipement (id_da, id_article, id_equipement, id_lis) values (@i1, @i2, @i3, @i4)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = modifier_un_da.table.Rows[i].ItemArray[0];
						sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = modifier_un_da.table.Rows[i].ItemArray[1];
						sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = id_lis;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x04001291 RID: 4753
		public static DataTable table = new DataTable();

		// Token: 0x04001292 RID: 4754
		public static string id_article;

		// Token: 0x04001293 RID: 4755
		public static string designation_article;
	}
}
