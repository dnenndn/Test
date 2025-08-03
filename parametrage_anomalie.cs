using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x020000EE RID: 238
	public partial class parametrage_anomalie : Form
	{
		// Token: 0x06000A51 RID: 2641 RVA: 0x00199F8C File Offset: 0x0019818C
		public parametrage_anomalie()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0019A00A File Offset: 0x0019820A
		private void parametrage_anomalie_Load(object sender, EventArgs e)
		{
			this.guna2Button2.Hide();
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0019A01C File Offset: 0x0019821C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.Text == "Ajouter";
			if (flag)
			{
				this.save_anomalie();
			}
			else
			{
				this.update_anomalie();
			}
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0019A058 File Offset: 0x00198258
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Text = "Ajouter";
			this.label2.Text = "Ajouter Anomalie";
			this.guna2Button2.Hide();
			this.TextBox1.Clear();
			this.TextBox2.Clear();
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0019A0AC File Offset: 0x001982AC
		private void save_anomalie()
		{
			fonction fonction = new fonction();
			bool flag = this.TextBox1.Text != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_anomalie where code = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into parametre_anomalie (code, anomalie, deleted, operateur) values (@v1, @v2, @v3, @v4)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@v3", SqlDbType.Int).Value = 0;
					sqlCommand2.Parameters.Add("@v4", SqlDbType.VarChar).Value = "OU";
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					MessageBox.Show("Enregistrement avec succés");
					this.remplissage_tableau(0);
				}
				else
				{
					MessageBox.Show("Erreur : Code de défaillance déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0019A280 File Offset: 0x00198480
		private void update_anomalie()
		{
			fonction fonction = new fonction();
			bool flag = this.TextBox1.Text != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_anomalie where code = @i and id <> @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = this.id_c;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "update parametre_anomalie set code = @v1, anomalie = @v2 where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_c;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					MessageBox.Show("Modification avec succés");
					this.remplissage_tableau(2);
					this.guna2Button1.Text = "Ajouter";
					this.label2.Text = "Ajouter Anomalie";
					this.guna2Button2.Hide();
				}
				else
				{
					MessageBox.Show("Erreur : Code de défaillance déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0019A484 File Offset: 0x00198684
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 8;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select * from parametre_anomalie where deleted = @d";
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
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			bool flag2 = this.radGridView1.Rows.Count != 0;
			if (flag2)
			{
				bool flag3 = o == 0;
				if (flag3)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag4 = o == 1;
				if (flag4)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag5 = o == 2;
				if (flag5)
				{
					this.radGridView1.Rows[parametrage_anomalie.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = parametrage_anomalie.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[parametrage_anomalie.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.afficher_symptome();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0019A74C File Offset: 0x0019894C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					parametrage_anomalie.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update parametre_anomalie set deleted = @d where id = @i";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 3;
					if (flag5)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						this.id_c = text;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Anomalie";
						this.guna2Button2.Show();
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0019A978 File Offset: 0x00198B78
		private void afficher_symptome()
		{
			this.radGridView1.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select symptome_defaillance.id_defaillance, symptome.code, symptome.designation from symptome_defaillance inner join symptome on symptome_defaillance.id_symptome = symptome.id where symptome.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Défaillance";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 550;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[2].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Défaillance";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x04000D57 RID: 3415
		private string id_c;

		// Token: 0x04000D58 RID: 3416
		private static int row_act;
	}
}
