using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200009B RID: 155
	public partial class modifier_caracteristique_textbox : Form
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x00134765 File Offset: 0x00132965
		public modifier_caracteristique_textbox()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00134780 File Offset: 0x00132980
		private void modifier_caracteristique_textbox_Load(object sender, EventArgs e)
		{
			this.label6.Text = Sous_Famille.id_cr;
			this.select_type_donnee();
			string cmdText = "select nom, champ_obligatoire, caracteristique_textbox.type, caracteristique_textbox.valeur_defaut from caracteristique inner join caracteristique_textbox on caracteristique.id = caracteristique_textbox.id_caracteristique where caracteristique.id = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Sous_Famille.id_cr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				bool flag2 = dataTable.Rows[0].ItemArray[1].ToString() == "0";
				if (flag2)
				{
					this.radCheckBox1.Checked = false;
				}
				else
				{
					this.radCheckBox1.Checked = true;
				}
				this.ComboBox2.Text = dataTable.Rows[0].ItemArray[2].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[3].ToString();
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x001348C4 File Offset: 0x00132AC4
		private void select_type_donnee()
		{
			this.ComboBox2.Items.Clear();
			this.ComboBox2.Items.Add("Chaîne de caractères");
			this.ComboBox2.Items.Add("Entier");
			this.ComboBox2.Items.Add("Réel");
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00134928 File Offset: 0x00132B28
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "";
			if (flag)
			{
				int num = 0;
				bool @checked = this.radCheckBox1.Checked;
				if (@checked)
				{
					num = 1;
				}
				bool flag2 = this.ComboBox2.Text != "";
				if (flag2)
				{
					int num2 = 0;
					bool flag3 = fonction.DeleteSpace(this.TextBox2.Text) == "";
					if (flag3)
					{
						num2 = 1;
					}
					else
					{
						bool flag4 = this.ComboBox2.Text == "Chaîne de caractères";
						if (flag4)
						{
							num2 = 1;
						}
						bool flag5 = this.ComboBox2.Text == "Entier";
						if (flag5)
						{
							bool flag6 = fonction.isnumeric(this.TextBox2.Text);
							if (flag6)
							{
								num2 = 1;
							}
						}
						bool flag7 = this.ComboBox2.Text == "Réel";
						if (flag7)
						{
							bool flag8 = fonction.is_reel(this.TextBox2.Text);
							if (flag8)
							{
								num2 = 1;
							}
						}
					}
					bool flag9 = num2 == 1;
					if (flag9)
					{
						string cmdText = "update caracteristique set champ_obligatoire = @i3, nom = @i2 where id = @i1";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = num;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText2 = "update caracteristique_textbox set type = @i2, valeur_defaut = @i3 where id_caracteristique = @i1";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.ComboBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Succés");
						Sous_Famille.select_caracteristique(Sous_Famille.id_sous_famille);
						base.Close();
					}
					else
					{
						MessageBox.Show("Erreur : Valeur par défaut est incompatible avec le type de données", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : il faut préciser le type de text", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
