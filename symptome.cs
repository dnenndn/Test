using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
	// Token: 0x02000128 RID: 296
	public partial class symptome : Form
	{
		// Token: 0x06000D11 RID: 3345 RVA: 0x001FA578 File Offset: 0x001F8778
		public symptome()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.remplissage_tableau(0);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x001FA60E File Offset: 0x001F880E
		private void symptome_Load(object sender, EventArgs e)
		{
			this.guna2Button2.Hide();
			this.select_defaillance();
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x001FA624 File Offset: 0x001F8824
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Text = "Ajouter";
			this.label2.Text = "Ajouter Symptôme";
			this.radCheckedDropDownList1.Enabled = true;
			this.guna2Button2.Hide();
			this.TextBox1.Clear();
			this.TextBox2.Clear();
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x001FA688 File Offset: 0x001F8888
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
			string cmdText = "select symptome.id, symptome.code, designation from symptome  where symptome.deleted = @d";
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
					this.radGridView1.Rows[symptome.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = symptome.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[symptome.row_act - 1].IsCurrent = true;
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
			this.afficher_defaillance();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x001FA950 File Offset: 0x001F8B50
		private void select_defaillance()
		{
			this.radCheckedDropDownList1.Items.Clear();
			string cmdText = "select code, id from parametre_anomalie where deleted = @d order by code";
			bd bd = new bd();
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
					this.radCheckedDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x001FAA58 File Offset: 0x001F8C58
		private void save_symptome()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				string cmdText = "select id from symptome where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into symptome (code, designation, deleted) values (@i2, @i3, @i4)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					int num = (int)sqlCommand2.ExecuteScalar();
					bd.cnn.Close();
					List<string> list = new List<string>();
					list.Clear();
					list = this.list_id_def();
					bool flag3 = list.Count != 0;
					if (flag3)
					{
						for (int i = 0; i < list.Count; i++)
						{
							string cmdText3 = "insert into symptome_defaillance (id_symptome, id_defaillance) values (@i1, @i2)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = list[i];
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					MessageBox.Show("Ajout avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.remplissage_tableau(0);
				}
				else
				{
					MessageBox.Show("Erreur : Code Symptôme déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x001FACE0 File Offset: 0x001F8EE0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.Text == "Ajouter";
			if (flag)
			{
				this.save_symptome();
			}
			else
			{
				this.update_symptome();
			}
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x001FAD1C File Offset: 0x001F8F1C
		private void update_symptome()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				string cmdText = "select id from symptome where code = @v and id <> @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_c;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "update symptome set code = @i2, designation = @i3 where id = @i4";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = this.id_c;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.remplissage_tableau(2);
					this.guna2Button1.Text = "Ajouter";
					this.label2.Text = "Ajouter Symptôme";
					string cmdText3 = "delete symptome_defaillance where id_symptome = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.id_c;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
					List<string> list = new List<string>();
					list.Clear();
					list = this.list_id_def();
					bool flag3 = list.Count != 0;
					if (flag3)
					{
						for (int i = 0; i < list.Count; i++)
						{
							string cmdText4 = "insert into symptome_defaillance (id_symptome, id_defaillance) values (@i1, @i2)";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = this.id_c;
							sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = list[i];
							bd.ouverture_bd(bd.cnn);
							sqlCommand4.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					this.guna2Button2.Hide();
				}
				else
				{
					MessageBox.Show("Erreur : Code Symptôme déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x001FB03C File Offset: 0x001F923C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					symptome.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update symptome set deleted = @d where id = @i";
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
						this.label2.Text = "Modifier Symptôme";
						this.guna2Button2.Show();
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
						bd bd2 = new bd();
						string cmdText2 = "select id_defaillance from symptome_defaillance where id_symptome = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_c;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
						{
							this.radCheckedDropDownList1.Items[i].Checked = false;
						}
						for (int j = 0; j < dataTable.Rows.Count; j++)
						{
							for (int k = 0; k < this.radCheckedDropDownList1.Items.Count; k++)
							{
								bool flag6 = dataTable.Rows[j].ItemArray[0].ToString() == this.radCheckedDropDownList1.Items[k].Tag.ToString();
								if (flag6)
								{
									this.radCheckedDropDownList1.Items[k].Checked = true;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x001FB3A8 File Offset: 0x001F95A8
		private List<string> list_id_def()
		{
			List<string> list = new List<string>();
			list.Clear();
			bd bd = new bd();
			for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
			{
				bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
				if (@checked)
				{
					list.Add(this.radCheckedDropDownList1.Items[i].Tag.ToString());
				}
			}
			return list;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x001FB434 File Offset: 0x001F9634
		private void afficher_defaillance()
		{
			this.radGridView1.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select symptome_defaillance.id_symptome, parametre_anomalie.code, parametre_anomalie.anomalie from symptome_defaillance inner join parametre_anomalie on symptome_defaillance.id_defaillance = parametre_anomalie.id where parametre_anomalie.deleted = @d";
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

		// Token: 0x0400109C RID: 4252
		private string id_c;

		// Token: 0x0400109D RID: 4253
		private static int row_act;
	}
}
