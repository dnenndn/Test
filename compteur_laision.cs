using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200004D RID: 77
	public partial class compteur_laision : Form
	{
		// Token: 0x06000361 RID: 865 RVA: 0x0008FB80 File Offset: 0x0008DD80
		public compteur_laision()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(compteur_laision.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(compteur_laision.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			this.remplissage_tableau();
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0008FBF4 File Offset: 0x0008DDF4
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 4;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete compteur_liaison where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau();
					}
				}
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0008FCD4 File Offset: 0x0008DED4
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0008FD58 File Offset: 0x0008DF58
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0008FE5B File Offset: 0x0008E05B
		private void compteur_laision_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0008FE60 File Offset: 0x0008E060
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select compteur_liaison.id, equipement.designation, equipement_compteur.designation, intervention from compteur_liaison inner join equipement on compteur_liaison.id_organe = equipement.id inner join equipement_compteur on compteur_liaison.id_compteur = equipement_compteur.id inner join parametre_intervention on compteur_liaison.id_intervention = parametre_intervention.id";
			bd bd = new bd();
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
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
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00090000 File Offset: 0x0008E200
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.isnumeric(this.TextBox1.Text);
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.guna2TextBox1.Text);
				if (flag2)
				{
					bool flag3 = fonction.isnumeric(this.guna2TextBox2.Text);
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "select id from compteur_liaison where id_organe = @i1 and id_compteur = @i2 and id_intervention = @i3";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.guna2TextBox1.Text;
						sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox2.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count == 0;
						if (flag4)
						{
							string cmdText2 = "insert into compteur_liaison (id_organe, id_compteur, id_intervention) values (@i1, @i2, @i3)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.TextBox1.Text;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.guna2TextBox1.Text;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox2.Text;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Ajout avec succés");
							this.TextBox1.Clear();
							this.guna2TextBox1.Clear();
							this.guna2TextBox2.Clear();
							this.remplissage_tableau();
						}
						else
						{
							MessageBox.Show("Erreur : Liaison déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Vérifier le champ ID Intervention", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier le champ ID Compteur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier le champ ID Organe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
