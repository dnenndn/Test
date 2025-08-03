using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000133 RID: 307
	public partial class Famille : Form
	{
		// Token: 0x06000D78 RID: 3448 RVA: 0x0020AAE8 File Offset: 0x00208CE8
		public Famille()
		{
			this.InitializeComponent();
			this.remplissage_tableau();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0020AB68 File Offset: 0x00208D68
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DimGray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x0020ABA4 File Offset: 0x00208DA4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = this.guna2Button1.Text == "Ajouter";
				if (flag2)
				{
					string cmdText = "select id from famille where (code_famille = @v1 or designation = @v2) and deleted = @d";
					bd bd = new bd();
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						string cmdText2 = "insert into famille (code_famille, designation, deleted) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("La famille est ajoutée avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.remplissage_tableau();
					}
					else
					{
						MessageBox.Show("Erreur : La famille déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				bool flag4 = this.guna2Button1.Text == "Modifier";
				if (flag4)
				{
					string cmdText3 = "select id from famille where (code_famille = @v1 or designation = @v2) and deleted = @d and id <> @i";
					bd bd2 = new bd();
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
					sqlCommand3.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = Famille.id_modifier;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag5 = dataTable2.Rows.Count == 0;
					if (flag5)
					{
						string cmdText4 = "update famille set code_famille = @i1, designation = @i2 where id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = Famille.id_modifier;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd2.cnn.Close();
						MessageBox.Show("La famille est modifié avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.guna2Button1.Text = "Ajouter";
						this.label2.Text = "Ajouter Famille";
						this.remplissage_tableau();
					}
					else
					{
						MessageBox.Show("Erreur : La famille déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0020AFC0 File Offset: 0x002091C0
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 12;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id,code_famille, designation from famille where deleted = @i order by designation";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
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
				this.radGridView1.MasterTemplate.MoveToFirstPage();
				this.radGridView1.Rows[0].IsCurrent = true;
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.afficher_sous_famille();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0020B1B0 File Offset: 0x002093B0
		private void Famille_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0020B1B4 File Offset: 0x002093B4
		private void select_change(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement is GridTableHeaderCellElement;
			if (flag)
			{
				e.CellElement.BackColor = Color.Firebrick;
			}
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0020B1E8 File Offset: 0x002093E8
		private void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.ForeColor = Color.Firebrick;
			}
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0020B21C File Offset: 0x0020941C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update famille set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau();
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 3;
					if (flag5)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						Famille.id_modifier = text;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Famille";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x0020B430 File Offset: 0x00209630
		private void afficher_sous_famille()
		{
			this.radGridView1.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select id_famille, sous_famille.designation, sous_famille.id from sous_famille inner join famille on sous_famille.id_famille = famille.id where sous_famille.deleted = @d and famille.deleted = @d";
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
				gridViewTemplate.Caption = "Sous_Famille";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 350;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[2].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Sous Famille";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
				this.afficher_article(gridViewTemplate);
			}
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x0020B6C0 File Offset: 0x002098C0
		private void afficher_article(GridViewTemplate ta)
		{
			ta.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select tableau_article_sous_famille.id_sous_famille, article.code_article, article.designation from tableau_article_sous_famille inner join article on tableau_article_sous_famille.id_article = article.id where article.deleted = @d";
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
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 250;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				ta.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(ta);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(ta.Columns[2].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x0020B948 File Offset: 0x00209B48
		private void coppier_equip(string id_coppier, string id_coller)
		{
			bd bd = new bd();
			string cmdText = "select id_test, reference, Designation from test_equip where parentid = @s1";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@s1", SqlDbType.VarChar).Value = id_coppier;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "insert into equipement (id_parent, code, designation, ordre, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_coller;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = dataTable.Rows[i].ItemArray[1];
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = dataTable.Rows[i].ItemArray[2];
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = i + 1;
					sqlCommand2.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					int num = (int)sqlCommand2.ExecuteScalar();
					bd.cnn.Close();
					this.coppier_equip(dataTable.Rows[i].ItemArray[0].ToString(), num.ToString());
				}
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x0020BB18 File Offset: 0x00209D18
		private int count_equip(string id_coppier, int u)
		{
			bd bd = new bd();
			string cmdText = "select id from equipement where id_parent = @s1";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@s1", SqlDbType.VarChar).Value = id_coppier;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					u++;
					this.count_equip(dataTable.Rows[i].ItemArray[0].ToString(), u);
				}
			}
			return u;
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x0020BBF4 File Offset: 0x00209DF4
		private void test_equipement()
		{
			bd bd = new bd();
			string cmdText = "select designation, ordre from equipement where id_parent = @i and deleted  = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.radGridView1.Rows.Add(new object[]
				{
					"",
					dataTable.Rows[i].ItemArray[0],
					dataTable.Rows[i].ItemArray[1]
				});
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x0020BCE0 File Offset: 0x00209EE0
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			page_codification_equipement page_codification_equipement = new page_codification_equipement();
			page_codification_equipement.Show();
		}

		// Token: 0x04001126 RID: 4390
		private static string id_modifier;
	}
}
