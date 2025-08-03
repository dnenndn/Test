using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000154 RID: 340
	public partial class parametre_fournisseur_compte : Form
	{
		// Token: 0x06000F22 RID: 3874 RVA: 0x002490E0 File Offset: 0x002472E0
		public parametre_fournisseur_compte()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x00249156 File Offset: 0x00247356
		private void parametre_fournisseur_compte_Load(object sender, EventArgs e)
		{
			this.select_periode();
			this.remplissage_tableau(0);
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x00249168 File Offset: 0x00247368
		private void select_periode()
		{
			this.guna2ComboBox1.Items.Clear();
			this.guna2ComboBox1.Items.Add("Jour");
			this.guna2ComboBox1.Items.Add("Semaine");
			this.guna2ComboBox1.Items.Add("Mois");
			this.guna2ComboBox1.Items.Add("Année");
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x002491E0 File Offset: 0x002473E0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.guna2ComboBox1.Text) != "" & fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox3.Text) != "" & fonction.DeleteSpace(this.TextBox4.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.TextBox1.Text);
				if (flag2)
				{
					bool flag3 = fonction.is_reel(this.TextBox3.Text) & fonction.is_reel(this.TextBox4.Text);
					if (flag3)
					{
						bool flag4 = this.guna2Button1.Text == "Ajouter";
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "select id from parametre_compte_fournisseur where (numero = @v1 or designation = @v2) and deleted = @d";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = this.TextBox1.Text;
							sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag5 = dataTable.Rows.Count == 0;
							if (flag5)
							{
								string cmdText2 = "insert into parametre_compte_fournisseur(numero, designation, estimation, periode_nbre, periode, deleted) values(@i1, @i2, @i3, @i4, @i5, @i6)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.TextBox1.Text;
								sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
								sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox3.Text;
								sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = this.TextBox4.Text;
								sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.guna2ComboBox1.Text;
								sqlCommand2.Parameters.Add("@i6", SqlDbType.Int).Value = 0;
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								bd.cnn.Close();
								MessageBox.Show("Compte est ajouté avec succés");
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.TextBox3.Clear();
								this.TextBox4.Clear();
								this.select_periode();
								this.remplissage_tableau(1);
							}
							else
							{
								MessageBox.Show("Erreur : Compte déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						bool flag6 = this.guna2Button1.Text == "Modifier";
						if (flag6)
						{
							bd bd2 = new bd();
							string cmdText3 = "select id from parametre_compte_fournisseur where (numero = @v1 or designation = @v2) and deleted = @d and id <> @v";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
							sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = this.TextBox1.Text;
							sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
							sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = this.id_modifier;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag7 = dataTable2.Rows.Count == 0;
							if (flag7)
							{
								string cmdText4 = "update parametre_compte_fournisseur set numero = @i1, designation = @i2, estimation = @i3, periode_nbre = @i4, periode = @i5 where id = @i6";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
								sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = this.TextBox1.Text;
								sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
								sqlCommand4.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox3.Text;
								sqlCommand4.Parameters.Add("@i4", SqlDbType.Real).Value = this.TextBox4.Text;
								sqlCommand4.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.guna2ComboBox1.Text;
								sqlCommand4.Parameters.Add("@i6", SqlDbType.Int).Value = this.id_modifier;
								bd2.ouverture_bd(bd2.cnn);
								sqlCommand4.ExecuteNonQuery();
								bd2.cnn.Close();
								MessageBox.Show("Compte est modifié avec succés");
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.TextBox3.Clear();
								this.TextBox4.Clear();
								this.guna2Button1.Text = "Ajouter";
								this.label2.Text = "Ajouter Compte Fournisseur";
								this.select_periode();
								this.remplissage_tableau(2);
							}
							else
							{
								MessageBox.Show("Erreur : Compte déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
					}
					else
					{
						MessageBox.Show("Erreur : Estimation et Période sont des réels strictements positifs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : N° Compte doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x002497DC File Offset: 0x002479DC
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 8;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select * from parametre_compte_fournisseur where deleted = @i";
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
					string text = dataTable.Rows[i].ItemArray[4].ToString() + " " + dataTable.Rows[i].ItemArray[5].ToString();
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						text
					});
					this.radGridView1.Rows[i].Cells[5].Value = this.imageList1.Images[1];
					this.radGridView1.Rows[i].Cells[6].Value = this.imageList1.Images[0];
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
					this.radGridView1.Rows[parametre_fournisseur_compte.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = parametre_fournisseur_compte.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[parametre_fournisseur_compte.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x00249B3C File Offset: 0x00247D3C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					parametre_fournisseur_compte.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update parametre_compte_fournisseur set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 5;
					if (flag5)
					{
						this.id_modifier = value;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Compte Fournisseur";
						string cmdText2 = "select periode_nbre, periode from parametre_compte_fournisseur where id = @i";
						bd bd2 = new bd();
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_modifier;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
						this.TextBox3.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
						this.TextBox4.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
						this.guna2ComboBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
					}
				}
			}
		}

		// Token: 0x04001310 RID: 4880
		private string id_modifier;

		// Token: 0x04001311 RID: 4881
		private static int row_act;
	}
}
