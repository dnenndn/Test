using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.Windows.Diagrams.Core;

namespace GMAO
{
	// Token: 0x020000B7 RID: 183
	public partial class ot_diagnostic_saisie : Form
	{
		// Token: 0x06000844 RID: 2116 RVA: 0x00164848 File Offset: 0x00162A48
		public ot_diagnostic_saisie()
		{
			this.InitializeComponent();
			this.radDiagram1.ThemeName = "Crystal";
			this.radMenuItem1.Click += this.click_ajouter_1;
			this.radMenuItem2.Click += this.click_supprimer;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x001648AC File Offset: 0x00162AAC
		private void ot_diagnostic_saisie_Load(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select id_defaillance, anomalie, code from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id =@i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				string text = dataTable.Rows[0].ItemArray[2].ToString();
				string text2 = dataTable.Rows[0].ItemArray[1].ToString();
				this.construire_arbre(num, text, text2);
				this.arbre.TreeViewElement.AllowAlternatingRowColor = true;
				this.arbre.ShowNodeToolTips = true;
				this.arbre.ShowLines = true;
				this.arbre.Nodes.Clear();
				RadTreeNode radTreeNode = new RadTreeNode();
				radTreeNode.Tag = num;
				radTreeNode.Text = text;
				radTreeNode.ToolTipText = text2;
				this.arbre.Nodes.Add(radTreeNode);
				this.radTreeView1.TreeViewElement.AllowAlternatingRowColor = true;
				this.radTreeView1.ShowNodeToolTips = true;
				this.radTreeView1.ShowLines = true;
				this.radTreeView1.Nodes.Clear();
				RadTreeNode radTreeNode2 = new RadTreeNode();
				radTreeNode2.Tag = num;
				radTreeNode2.Text = text;
				radTreeNode2.ToolTipText = text2;
				this.radTreeView1.Nodes.Add(radTreeNode2);
				this.select_arbre(Convert.ToInt32(num), radTreeNode);
				this.select_arbre_1(Convert.ToInt32(num), radTreeNode2);
				this.arbre.ExpandAll();
				this.radTreeView1.ExpandAll();
			}
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00164AB0 File Offset: 0x00162CB0
		private void get_relation(string id_parent, RadDiagramShape an_d)
		{
			bd bd = new bd();
			string cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_parent;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select operateur from parametre_anomalie where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = id_parent;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string text = dataTable2.Rows[0].ItemArray[0].ToString();
				RadDiagramShape radDiagramShape = new RadDiagramShape();
				radDiagramShape.Text = text;
				radDiagramShape.Size = new Size(30, 30);
				radDiagramShape.BackColor = Color.White;
				radDiagramShape.ForeColor = Color.Blue;
				radDiagramShape.Cursor = Cursors.Hand;
				radDiagramShape.BorderBrush = new SolidBrush(Color.Blue);
				radDiagramShape.DrawBorder = true;
				radDiagramShape.ElementShape = new CircleShape();
				RadDiagramConnection radDiagramConnection = new RadDiagramConnection();
				radDiagramConnection.Source = an_d;
				radDiagramConnection.Target = radDiagramShape;
				radDiagramConnection.TargetCapType = 2;
				this.radDiagram1.Items.Add(radDiagramShape);
				this.radDiagram1.Items.Add(radDiagramConnection);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text2 = dataTable.Rows[i].ItemArray[0].ToString();
					RadDiagramShape radDiagramShape2 = new RadDiagramShape();
					radDiagramShape2.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radDiagramShape2.Tag = text2;
					radDiagramShape2.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					radDiagramShape2.Size = new Size(120, 30);
					radDiagramShape2.BackColor = Color.White;
					radDiagramShape2.ForeColor = Color.Firebrick;
					radDiagramShape2.Cursor = Cursors.Hand;
					radDiagramShape2.BorderBrush = new SolidBrush(Color.Firebrick);
					radDiagramShape2.DrawBorder = true;
					radDiagramShape2.ElementShape = new RoundRectShape(4);
					RadDiagramConnection radDiagramConnection2 = new RadDiagramConnection();
					radDiagramConnection2.Source = radDiagramShape;
					radDiagramConnection2.Target = radDiagramShape2;
					radDiagramConnection2.TargetCapType = 2;
					this.radDiagram1.Items.Add(radDiagramShape2);
					this.radDiagram1.Items.Add(radDiagramConnection2);
					this.get_relation(text2, radDiagramShape2);
				}
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00164DAC File Offset: 0x00162FAC
		private void construire_arbre(int id_a, string code_a, string defaillance_a)
		{
			this.radDiagram1.Items.Clear();
			TreeLayoutSettings treeLayoutSettings = new TreeLayoutSettings
			{
				TreeLayoutType = 5,
				VerticalDistance = 15.0
			};
			RadDiagramShape radDiagramShape = new RadDiagramShape();
			radDiagramShape.Text = code_a;
			radDiagramShape.ToolTipText = defaillance_a;
			radDiagramShape.Size = new Size(120, 30);
			radDiagramShape.BackColor = Color.White;
			radDiagramShape.ForeColor = Color.Firebrick;
			radDiagramShape.Cursor = Cursors.Hand;
			radDiagramShape.BorderBrush = new SolidBrush(Color.Firebrick);
			radDiagramShape.DrawBorder = true;
			radDiagramShape.ElementShape = new RoundRectShape(4);
			radDiagramShape.Position = new Point(394.0, 10.0);
			this.radDiagram1.Items.Add(radDiagramShape);
			string text = id_a.ToString();
			radDiagramShape.Tag = text;
			this.get_relation(text, radDiagramShape);
			treeLayoutSettings.Roots.Add(this.radDiagram1.Shapes[0]);
			this.radDiagram1.SetLayout(1, treeLayoutSettings);
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00164ED0 File Offset: 0x001630D0
		private void select_arbre(int r, RadTreeNode n)
		{
			n.Nodes.Clear();
			bd bd = new bd();
			bool flag = n.Parent != null;
			string cmdText;
			if (flag)
			{
				cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where deleted = @d and id_parent = @i and id_parent in (select id_defaillance from ot_diagnostic_def where id_ot = @v1 and id_defaillance = @i)";
			}
			else
			{
				cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where deleted = @d and id_parent = @i";
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = r;
			sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select operateur from parametre_anomalie where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = r;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int r2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = r2.ToString();
					n.Nodes.Add(radTreeNode);
					this.select_arbre(r2, radTreeNode);
				}
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x001650B8 File Offset: 0x001632B8
		private void select_arbre_1(int r, RadTreeNode n)
		{
			n.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id  where deleted = @d and id_parent = @i and id_anomalie in (select id_defaillance from ot_diagnostic_def where id_ot = @v1)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = r;
			sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select operateur from parametre_anomalie where id = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = r;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int r2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = r2.ToString();
					n.Nodes.Add(radTreeNode);
					this.select_arbre_1(r2, radTreeNode);
				}
			}
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00165280 File Offset: 0x00163480
		private void click_ajouter_1(object sender, EventArgs e)
		{
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.arbre.SelectedNode;
				RadTreeNode parent = this.arbre.SelectedNode.Parent;
				bool flag2 = parent != null;
				if (flag2)
				{
					string value = this.arbre.SelectedNode.Tag.ToString();
					string text = parent.Tag.ToString();
					bd bd = new bd();
					string cmdText = "select id from ot_diagnostic_def where id_ot = @i1 and id_defaillance = @i2";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						string cmdText2 = "insert into ot_diagnostic_def (id_ot, id_defaillance) values(@v1, @v2)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = value;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						this.ot_diagnostic_saisie_Load(sender, e);
					}
					else
					{
						MessageBox.Show("Erreur : La défaillance  est déja ajoutée ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : La défaillance principale est déja ajoutée par défaut", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00165430 File Offset: 0x00163630
		private void click_supprimer(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
					RadTreeNode parent = this.radTreeView1.SelectedNode.Parent;
					bool flag3 = parent != null;
					if (flag3)
					{
						string value = this.radTreeView1.SelectedNode.Tag.ToString();
						string text = parent.Tag.ToString();
						bd bd = new bd();
						string cmdText = "delete ot_diagnostic_def where id_defaillance = @i1 and id_ot = @i2";
						string cmdText2 = "delete ot_diagnostic_m where id_defaillance = @i1 and id_ot = @i2";
						string cmdText3 = "delete ot_diagnostic_detection where id_defaillance = @i1 and id_ot = @i2";
						string cmdText4 = "delete ot_diagnostic_operation where id_ot = @i2 and id_operation in (select id from operation_diagnostic where id_defaillance = @i1)";
						string cmdText5 = "delete ot_diagnostic_symptome where id_ot = @i2 and id_symptome in (select id from symptome where id_defaillance = @i1)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = value;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = value;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = value;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = value;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = value;
						sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						sqlCommand2.ExecuteNonQuery();
						sqlCommand3.ExecuteNonQuery();
						sqlCommand4.ExecuteNonQuery();
						sqlCommand5.ExecuteNonQuery();
						bd.cnn.Close();
						this.ot_diagnostic_saisie_Load(sender, e);
					}
					else
					{
						MessageBox.Show("Erreur : Impossible de supprimer la défaillance racine", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}
	}
}
