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
	// Token: 0x02000155 RID: 341
	public partial class parametre_fournisseur_devise : Form
	{
		// Token: 0x06000F2A RID: 3882 RVA: 0x0024B3AC File Offset: 0x002495AC
		public parametre_fournisseur_devise()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x0024B422 File Offset: 0x00249622
		private void parametre_fournisseur_devise_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x0024B430 File Offset: 0x00249630
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 9;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id,designation, conversion from parametre_devise_fournisseur where deleted = @i";
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
					this.radGridView1.Rows[parametre_fournisseur_devise.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = parametre_fournisseur_devise.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[parametre_fournisseur_devise.row_act - 1].IsCurrent = true;
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

		// Token: 0x06000F2D RID: 3885 RVA: 0x0024B72C File Offset: 0x0024992C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.TextBox2.Text);
				if (flag2)
				{
					bool flag3 = this.guna2Button1.Text == "Ajouter";
					if (flag3)
					{
						string cmdText = "select id from parametre_devise_fournisseur where designation = @v1 and deleted = @d";
						bd bd = new bd();
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count == 0;
						if (flag4)
						{
							string cmdText2 = "insert into parametre_devise_fournisseur (designation, conversion, deleted) values (@i1, @i2, @i3)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.TextBox2.Text));
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Devise est ajouté avec succés");
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.remplissage_tableau(1);
						}
						else
						{
							MessageBox.Show("Erreur : Devise déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					bool flag5 = this.guna2Button1.Text == "Modifier";
					if (flag5)
					{
						string cmdText3 = "select id from parametre_devise_fournisseur where designation = @v1 and deleted = @d and id <> @i";
						bd bd2 = new bd();
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd2.cnn);
						sqlCommand3.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand3.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.id_modifier;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag6 = dataTable2.Rows.Count == 0;
						if (flag6)
						{
							string cmdText4 = "update parametre_devise_fournisseur set designation = @i1, conversion = @i2 where id = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
							sqlCommand4.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand4.Parameters.Add("@i2", SqlDbType.Real).Value = Math.Abs(Convert.ToDouble(this.TextBox2.Text));
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = this.id_modifier;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand4.ExecuteNonQuery();
							bd2.cnn.Close();
							MessageBox.Show("Devise est modifié avec succés");
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.guna2Button1.Text = "Ajouter";
							this.label2.Text = "Ajouter Devise";
							this.remplissage_tableau(2);
						}
						else
						{
							MessageBox.Show("Erreur : Devise déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : Conversion doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0024BB54 File Offset: 0x00249D54
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					parametre_fournisseur_devise.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update parametre_devise_fournisseur set deleted = @d where id = @a";
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
						this.id_modifier = value;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Devise";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x04001324 RID: 4900
		private string id_modifier;

		// Token: 0x04001325 RID: 4901
		private static int row_act;
	}
}
