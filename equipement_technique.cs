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
	// Token: 0x02000132 RID: 306
	public partial class equipement_technique : Form
	{
		// Token: 0x06000D6F RID: 3439 RVA: 0x00209754 File Offset: 0x00207954
		public equipement_technique()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x002097CA File Offset: 0x002079CA
		private void equipement_technique_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x002097D4 File Offset: 0x002079D4
		private void select_change(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement is GridTableHeaderCellElement;
			if (flag)
			{
				e.CellElement.BackColor = Color.Firebrick;
			}
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x00209808 File Offset: 0x00207A08
		private void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.ForeColor = Color.Firebrick;
			}
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x0020983C File Offset: 0x00207A3C
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 5;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id,designation, observation from equipement_technique where id_equipement = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
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
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00209A28 File Offset: 0x00207C28
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				bool flag2 = this.guna2Button1.Text == "Ajouter";
				if (flag2)
				{
					string cmdText = "insert into equipement_technique (id_equipement, designation, observation) values(@i1, @i2, @i3)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.remplissage_tableau();
				}
				bool flag3 = this.guna2Button1.Text == "Modifier";
				if (flag3)
				{
					string cmdText2 = "update equipement_technique set designation = @i2, observation = @i3 where id = @i1";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = equipement_technique.id_modifier;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
					this.label1.Text = "Ajouter donnée technique";
					this.guna2Button1.Text = "Ajouter";
					this.remplissage_tableau();
				}
			}
			else
			{
				MessageBox.Show("Erreur :Un champs obligatoire est vide");
			}
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00209C84 File Offset: 0x00207E84
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "delete equipement_technique where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau();
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 3;
					if (flag5)
					{
						equipement_technique.id_modifier = value;
						this.guna2Button1.Text = "Modifier";
						this.label1.Text = "Modifier donnée technique";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					}
				}
			}
		}

		// Token: 0x0400111B RID: 4379
		private static string id_modifier;
	}
}
