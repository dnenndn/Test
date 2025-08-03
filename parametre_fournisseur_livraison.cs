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
	// Token: 0x02000156 RID: 342
	public partial class parametre_fournisseur_livraison : Form
	{
		// Token: 0x06000F31 RID: 3889 RVA: 0x0024CAB0 File Offset: 0x0024ACB0
		public parametre_fournisseur_livraison()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0024CB26 File Offset: 0x0024AD26
		private void parametre_fournisseur_livraison_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0024CB34 File Offset: 0x0024AD34
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 9;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id,code_livraison, designation from parametre_livraison_fournisseur where deleted = @i";
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
						dataTable.Rows[i].ItemArray[2].ToString()
					});
					this.radGridView1.Rows[i].Cells[3].Value = this.imageList1.Images[1];
					this.radGridView1.Rows[i].Cells[4].Value = this.imageList1.Images[0];
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
					this.radGridView1.Rows[parametre_fournisseur_livraison.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = parametre_fournisseur_livraison.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[parametre_fournisseur_livraison.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000F34 RID: 3892 RVA: 0x0024CE30 File Offset: 0x0024B030
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					parametre_fournisseur_livraison.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update parametre_livraison_fournisseur set deleted = @d where id = @a";
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
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 3;
					if (flag5)
					{
						parametre_fournisseur_livraison.id_modifier = value;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Mode de livraison";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0024D020 File Offset: 0x0024B220
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = this.guna2Button1.Text == "Ajouter";
				if (flag2)
				{
					string cmdText = "select id from parametre_livraison_fournisseur where (code_livraison = @v1 or designation = @v2) and deleted = @d";
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
						string cmdText2 = "insert into parametre_livraison_fournisseur (code_livraison, designation, deleted) values (@i1, @i2, @i3)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Mode de livraison est ajouté avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.remplissage_tableau(1);
					}
					else
					{
						MessageBox.Show("Erreur : Mode de livraison déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				bool flag4 = this.guna2Button1.Text == "Modifier";
				if (flag4)
				{
					string cmdText3 = "select id from parametre_livraison_fournisseur where (code_livraison = @v1 or designation = @v2) and deleted = @d and id <> @i";
					bd bd2 = new bd();
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
					sqlCommand3.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = parametre_fournisseur_livraison.id_modifier;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag5 = dataTable2.Rows.Count == 0;
					if (flag5)
					{
						string cmdText4 = "update parametre_livraison_fournisseur set code_livraison = @i1, designation = @i2 where id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = parametre_fournisseur_livraison.id_modifier;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd2.cnn.Close();
						MessageBox.Show("Mode de livraison est modifié avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.guna2Button1.Text = "Ajouter";
						this.label2.Text = "Ajouter Mode de livraison";
						this.remplissage_tableau(2);
					}
					else
					{
						MessageBox.Show("Erreur : Mode de livraison déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04001332 RID: 4914
		private static string id_modifier;

		// Token: 0x04001333 RID: 4915
		private static int row_act;
	}
}
