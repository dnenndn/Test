using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200008A RID: 138
	public partial class liste_budget_modifier : Form
	{
		// Token: 0x0600067C RID: 1660 RVA: 0x00116782 File Offset: 0x00114982
		public liste_budget_modifier()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x001167A8 File Offset: 0x001149A8
		private void liste_budget_modifier_Load(object sender, EventArgs e)
		{
			this.id_bud = liste_budget.id_budget;
			this.select_duree();
			bd bd = new bd();
			string cmdText = "select nom, description, date_creation, duree, montant, creation_auto from budget where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
				this.TextBox2.Text = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
				this.radDateTimePicker1.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[2]);
				this.radDropDownList1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
				this.guna2TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[4]);
				bool flag2 = Convert.ToString(dataTable.Rows[0].ItemArray[5]) == "Oui";
				if (flag2)
				{
					this.radRadioButton1.IsChecked = true;
				}
				else
				{
					this.radRadioButton2.IsChecked = true;
				}
			}
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00116934 File Offset: 0x00114B34
		private void select_duree()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Chaque Jour");
			this.radDropDownList1.Items.Add("Chaque Semaine");
			this.radDropDownList1.Items.Add("Chaque 2 Semaine");
			this.radDropDownList1.Items.Add("Chaque Mois");
			this.radDropDownList1.Items.Add("Chaque 2 Mois");
			this.radDropDownList1.Items.Add("Chaque Trimestre");
			this.radDropDownList1.Items.Add("Chaque Simestre");
			this.radDropDownList1.Items.Add("Chaque Année");
			this.radDropDownList1.Text = "Chaque Mois";
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00116A14 File Offset: 0x00114C14
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.guna2TextBox1.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.guna2TextBox1.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToDouble(this.guna2TextBox1.Text) > 0.0;
					if (flag3)
					{
						string cmdText = "select id from budget where nom = @n and id <> @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count == 0;
						if (flag4)
						{
							string value = "Oui";
							bool isChecked = this.radRadioButton2.IsChecked;
							if (isChecked)
							{
								value = "Non";
							}
							string cmdText2 = "update budget set nom = @v1, description = @v2, date_creation = @v3, duree = @v4, montant = @v5, creation_auto = @v6 where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
							sqlCommand2.Parameters.Add("@v3", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
							sqlCommand2.Parameters.Add("@v4", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
							sqlCommand2.Parameters.Add("@v5", SqlDbType.Real).Value = this.guna2TextBox1.Text;
							sqlCommand2.Parameters.Add("@v6", SqlDbType.VarChar).Value = value;
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_bud;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Modification avec succés");
							base.Close();
						}
						else
						{
							MessageBox.Show("Erreur : Le nom de budget est déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : le montant de budget doit être un réel strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : le montant de budget doit être un réel strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000891 RID: 2193
		private string id_bud = "";
	}
}
