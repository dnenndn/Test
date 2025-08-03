using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000021 RID: 33
	public partial class article_equipement : Form
	{
		// Token: 0x060001BD RID: 445 RVA: 0x0004AD70 File Offset: 0x00048F70
		public article_equipement()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radMenuItem1.Click += this.click_ajouter;
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.select_equipement();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0004AE05 File Offset: 0x00049005
		private void article_equipement_Load(object sender, EventArgs e)
		{
			this.get_equipement();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0004AE0F File Offset: 0x0004900F
		private void select_equipement()
		{
			this.arbre.ShowNodeToolTips = true;
			this.arbre.ShowLines = true;
			this.arbre.TreeViewElement.AllowAlternatingRowColor = true;
			this.load_arbre(0);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0004AE48 File Offset: 0x00049048
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

		// Token: 0x060001C1 RID: 449 RVA: 0x0004B11C File Offset: 0x0004931C
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0004B184 File Offset: 0x00049384
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

		// Token: 0x060001C3 RID: 451 RVA: 0x0004B2CC File Offset: 0x000494CC
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

		// Token: 0x060001C4 RID: 452 RVA: 0x0004B450 File Offset: 0x00049650
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

		// Token: 0x060001C5 RID: 453 RVA: 0x0004B58C File Offset: 0x0004978C
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

		// Token: 0x060001C6 RID: 454 RVA: 0x0004B6DC File Offset: 0x000498DC
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.arbre.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					string cmdText = "insert into tableau_article_equipement(id_article, id_equipement) values (@i2, @i1)";
					bd bd = new bd();
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = selectedNode.Tag;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = liste_article.id_article;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.get_equipement();
				}
				else
				{
					MessageBox.Show("Erreur : L'équipement est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0004B7C4 File Offset: 0x000499C4
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

		// Token: 0x060001C8 RID: 456 RVA: 0x0004B84B File Offset: 0x00049A4B
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.ExpandAll();
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0004B874 File Offset: 0x00049A74
		private void get_equipement()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select equipement.id, designation from equipement inner join tableau_article_equipement on equipement.id = tableau_article_equipement.id_equipement where equipement.deleted = @d and tableau_article_equipement.id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
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
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0004B990 File Offset: 0x00049B90
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
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "delete tableau_article_equipement where id_equipement = @i1 and id_article = @i2";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = liste_article.id_article;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.get_equipement();
						}
					}
				}
			}
		}
	}
}
