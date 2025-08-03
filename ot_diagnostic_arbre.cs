using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace GMAO
{
	// Token: 0x020000B4 RID: 180
	public partial class ot_diagnostic_arbre : Form
	{
		// Token: 0x0600081E RID: 2078 RVA: 0x0015EBC8 File Offset: 0x0015CDC8
		public ot_diagnostic_arbre()
		{
			this.InitializeComponent();
			this.radDiagram1.ThemeName = "Crystal";
			this.radDiagram1.ShapeClicked += this.RadDiagram1_ShapeClicked;
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0015EC14 File Offset: 0x0015CE14
		private void RadDiagram1_ShapeClicked(object sender, ShapeRoutedEventArgs e)
		{
			string name = e.Shape.Name;
			bd bd = new bd();
			string cmdText = "select code from parametre_anomalie where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = name;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.label1.Text = name;
			this.label3.Text = dataTable.Rows[0].ItemArray[0].ToString();
			this.select_m(name);
			this.select_detection(name);
			this.panel1.Show();
			this.radDiagram1.Size = new Size(781, 227);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0015ECE4 File Offset: 0x0015CEE4
		private void ot_diagnostic_arbre_Load(object sender, EventArgs e)
		{
			this.pictureBox3_Click(sender, e);
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
				int id_a = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				string code_a = dataTable.Rows[0].ItemArray[2].ToString();
				string defaillance_a = dataTable.Rows[0].ItemArray[1].ToString();
				this.construire_arbre(id_a, code_a, defaillance_a);
			}
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0015EDC4 File Offset: 0x0015CFC4
		private void get_relation(string id_parent, RadDiagramShape an_d)
		{
			bd bd = new bd();
			string cmdText = "select id_anomalie, code, anomalie from relation_anomalie inner join parametre_anomalie on relation_anomalie.id_anomalie = parametre_anomalie.id where deleted = @d and id_parent = @i and id_anomalie in (select id_defaillance from ot_diagnostic_def where id_ot = @v)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_parent;
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = dataTable.Rows[i].ItemArray[0].ToString();
					RadDiagramShape radDiagramShape = new RadDiagramShape();
					radDiagramShape.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radDiagramShape.Tag = text;
					radDiagramShape.Name = text;
					radDiagramShape.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					radDiagramShape.Size = new Size(120, 30);
					radDiagramShape.BackColor = Color.White;
					radDiagramShape.ForeColor = Color.Firebrick;
					radDiagramShape.Cursor = Cursors.Hand;
					radDiagramShape.BorderBrush = new SolidBrush(Color.Firebrick);
					radDiagramShape.DrawBorder = true;
					radDiagramShape.ElementShape = new RoundRectShape(4);
					RadDiagramConnection radDiagramConnection = new RadDiagramConnection();
					radDiagramConnection.Source = an_d;
					radDiagramConnection.Target = radDiagramShape;
					radDiagramConnection.TargetCapType = 2;
					this.radDiagram1.Items.Add(radDiagramShape);
					this.radDiagram1.Items.Add(radDiagramConnection);
					this.get_relation(text, radDiagramShape);
				}
			}
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0015EFCC File Offset: 0x0015D1CC
		private void construire_arbre(int id_a, string code_a, string defaillance_a)
		{
			this.radDiagram1.Items.Clear();
			TreeLayoutSettings treeLayoutSettings = new TreeLayoutSettings
			{
				TreeLayoutType = 2,
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
			radDiagramShape.Name = text;
			this.get_relation(text, radDiagramShape);
			treeLayoutSettings.Roots.Add(this.radDiagram1.Shapes[0]);
			this.radDiagram1.SetLayout(1, treeLayoutSettings);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0015F0F5 File Offset: 0x0015D2F5
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radDiagram1.Size = new Size(1054, 227);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0015F120 File Offset: 0x0015D320
		private void select_m(string id_def)
		{
			this.radCheckBox1.Checked = false;
			this.radCheckBox2.Checked = false;
			this.radCheckBox3.Checked = false;
			this.radCheckBox4.Checked = false;
			this.radCheckBox5.Checked = false;
			bd bd = new bd();
			string cmdText = "select type_m from ot_diagnostic_m where id_defaillance = @i1 and id_ot = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_def;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = dataTable.Rows[i].ItemArray[0].ToString() == "Milieu";
					if (flag2)
					{
						this.radCheckBox1.Checked = true;
					}
					bool flag3 = dataTable.Rows[i].ItemArray[0].ToString() == "Main-d'œuvre";
					if (flag3)
					{
						this.radCheckBox2.Checked = true;
					}
					bool flag4 = dataTable.Rows[i].ItemArray[0].ToString() == "Méthode";
					if (flag4)
					{
						this.radCheckBox3.Checked = true;
					}
					bool flag5 = dataTable.Rows[i].ItemArray[0].ToString() == "Matériel";
					if (flag5)
					{
						this.radCheckBox4.Checked = true;
					}
					bool flag6 = dataTable.Rows[i].ItemArray[0].ToString() == "Matière";
					if (flag6)
					{
						this.radCheckBox5.Checked = true;
					}
				}
			}
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0015F338 File Offset: 0x0015D538
		private void select_detection(string id_def)
		{
			this.radRadioButton1.IsChecked = false;
			this.radRadioButton2.IsChecked = false;
			this.radRadioButton3.IsChecked = false;
			this.radRadioButton4.IsChecked = false;
			bd bd = new bd();
			string cmdText = "select type_d from ot_diagnostic_detection where id_defaillance = @i1 and id_ot = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_def;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]) == 1;
					if (flag2)
					{
						this.radRadioButton4.IsChecked = true;
					}
					bool flag3 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]) == 2;
					if (flag3)
					{
						this.radRadioButton3.IsChecked = true;
					}
					bool flag4 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]) == 3;
					if (flag4)
					{
						this.radRadioButton2.IsChecked = true;
					}
					bool flag5 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]) == 4;
					if (flag5)
					{
						this.radRadioButton1.IsChecked = true;
					}
				}
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0015F4F0 File Offset: 0x0015D6F0
		private void radButton1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "delete ot_diagnostic_m where id_ot = @i1 and id_defaillance = @i2";
			string cmdText2 = "delete ot_diagnostic_detection where id_ot = @i1 and id_defaillance = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.label1.Text;
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.label1.Text;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			bool @checked = this.radCheckBox1.Checked;
			if (@checked)
			{
				string cmdText3 = "insert into ot_diagnostic_m (id_ot, id_defaillance, type_m) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand3.Parameters.Add("@v2", SqlDbType.Int).Value = this.label1.Text;
				sqlCommand3.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.radCheckBox1.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand3.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool checked2 = this.radCheckBox2.Checked;
			if (checked2)
			{
				string cmdText4 = "insert into ot_diagnostic_m (id_ot, id_defaillance, type_m) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand4.Parameters.Add("@v2", SqlDbType.Int).Value = this.label1.Text;
				sqlCommand4.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.radCheckBox2.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand4.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool checked3 = this.radCheckBox3.Checked;
			if (checked3)
			{
				string cmdText5 = "insert into ot_diagnostic_m (id_ot, id_defaillance, type_m) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand5.Parameters.Add("@v2", SqlDbType.Int).Value = this.label1.Text;
				sqlCommand5.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.radCheckBox3.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand5.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool checked4 = this.radCheckBox4.Checked;
			if (checked4)
			{
				string cmdText6 = "insert into ot_diagnostic_m (id_ot, id_defaillance, type_m) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
				sqlCommand6.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand6.Parameters.Add("@v2", SqlDbType.Int).Value = this.label1.Text;
				sqlCommand6.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.radCheckBox4.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand6.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool checked5 = this.radCheckBox5.Checked;
			if (checked5)
			{
				string cmdText7 = "insert into ot_diagnostic_m (id_ot, id_defaillance, type_m) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
				sqlCommand7.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand7.Parameters.Add("@v2", SqlDbType.Int).Value = this.label1.Text;
				sqlCommand7.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.radCheckBox5.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand7.ExecuteNonQuery();
				bd.cnn.Close();
			}
			int num = 0;
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				num = 4;
			}
			bool isChecked2 = this.radRadioButton2.IsChecked;
			if (isChecked2)
			{
				num = 3;
			}
			bool isChecked3 = this.radRadioButton3.IsChecked;
			if (isChecked3)
			{
				num = 2;
			}
			bool isChecked4 = this.radRadioButton4.IsChecked;
			if (isChecked4)
			{
				num = 1;
			}
			bool flag = num != 0;
			if (flag)
			{
				string cmdText8 = "insert into ot_diagnostic_detection (id_ot, id_defaillance, type_d) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
				sqlCommand8.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand8.Parameters.Add("@v2", SqlDbType.Int).Value = this.label1.Text;
				sqlCommand8.Parameters.Add("@v3", SqlDbType.Int).Value = num;
				bd.ouverture_bd(bd.cnn);
				sqlCommand8.ExecuteNonQuery();
				bd.cnn.Close();
			}
			MessageBox.Show("Enregistrement avec succés");
		}
	}
}
