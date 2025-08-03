using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200000C RID: 12
	public partial class ajouter_caractéristique : Form
	{
		// Token: 0x060000AC RID: 172 RVA: 0x000209F0 File Offset: 0x0001EBF0
		public ajouter_caractéristique()
		{
			this.InitializeComponent();
			ajouter_caractéristique.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00020A20 File Offset: 0x0001EC20
		private void ajouter_caractéristique_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label7.Text = "";
			this.label6.Text = Sous_Famille.id_sous_famille;
			this.label7.Text = Sous_Famille.designation_sous_famille;
			this.select_type();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00020A7C File Offset: 0x0001EC7C
		private void select_type()
		{
			ajouter_caractéristique.radGridView1.Hide();
			this.ComboBox1.Items.Clear();
			this.ComboBox1.Items.Add("TextBox");
			this.ComboBox1.Items.Add("Select Unique");
			this.ComboBox1.Items.Add("Select Multiple");
			this.ComboBox1.Items.Add("CheckBox");
			this.ComboBox1.Items.Add("Radio Button");
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00020B14 File Offset: 0x0001ED14
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.ComboBox1.Text == "TextBox";
			if (flag)
			{
				ajouter_caractéristique.radGridView1.Hide();
				this.panel2.Controls.Clear();
				caractéristique_textbox caractéristique_textbox = new caractéristique_textbox();
				caractéristique_textbox.TopLevel = false;
				this.panel2.Controls.Add(caractéristique_textbox);
				caractéristique_textbox.Show();
			}
			else
			{
				this.panel2.Controls.Clear();
				caracteristique_autre caracteristique_autre = new caracteristique_autre();
				caracteristique_autre.TopLevel = false;
				this.panel2.Controls.Add(caracteristique_autre);
				caracteristique_autre.Show();
				ajouter_caractéristique.radGridView1.Show();
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00020BC8 File Offset: 0x0001EDC8
		public static void remplir_tableau(string s)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(s) != "";
			if (flag)
			{
				ajouter_caractéristique.radGridView1.Rows.Add(new object[]
				{
					s
				});
				ajouter_caractéristique.radGridView1.Rows[ajouter_caractéristique.radGridView1.Rows.Count - 1].Cells[2].Value = ajouter_caractéristique.imageList1.Images[0];
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00020C50 File Offset: 0x0001EE50
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = ajouter_caractéristique.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 2;
					if (flag3)
					{
						ajouter_caractéristique.radGridView1.Rows.RemoveAt(e.RowIndex);
					}
				}
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00020CBC File Offset: 0x0001EEBC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & this.ComboBox1.Text != "";
			if (flag)
			{
				int num = 0;
				bool @checked = this.radCheckBox1.Checked;
				if (@checked)
				{
					num = 1;
				}
				bool flag2 = this.ComboBox1.Text == "TextBox";
				if (flag2)
				{
					bool flag3 = caractéristique_textbox.ComboBox2.Text != "";
					if (flag3)
					{
						int num2 = 0;
						bool flag4 = fonction.DeleteSpace(caractéristique_textbox.TextBox2.Text) == "";
						if (flag4)
						{
							num2 = 1;
						}
						else
						{
							bool flag5 = caractéristique_textbox.ComboBox2.Text == "Chaîne de caractères";
							if (flag5)
							{
								num2 = 1;
							}
							bool flag6 = caractéristique_textbox.ComboBox2.Text == "Entier";
							if (flag6)
							{
								bool flag7 = fonction.isnumeric(caractéristique_textbox.TextBox2.Text);
								if (flag7)
								{
									num2 = 1;
								}
							}
							bool flag8 = caractéristique_textbox.ComboBox2.Text == "Réel";
							if (flag8)
							{
								bool flag9 = fonction.is_reel(caractéristique_textbox.TextBox2.Text);
								if (flag9)
								{
									num2 = 1;
								}
							}
						}
						bool flag10 = num2 == 1;
						if (flag10)
						{
							string cmdText = "insert into caracteristique (id_sous_famille, nom, type, champ_obligatoire, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.ComboBox1.Text;
							sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = num;
							sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							int num3 = (int)sqlCommand.ExecuteScalar();
							string cmdText2 = "insert into caracteristique_textbox (id_caracteristique, type, valeur_defaut) values (@i1, @i2, @i3)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num3;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = caractéristique_textbox.ComboBox2.Text;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = caractéristique_textbox.TextBox2.Text.ToString();
							sqlCommand2.ExecuteNonQuery();
							MessageBox.Show("Succés");
							Sous_Famille.id_sous_famille = this.label6.Text;
							Sous_Famille.select_caracteristique(this.label6.Text);
							this.select_type();
							this.TextBox1.Clear();
							bd.cnn.Close();
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
					string cmdText3 = "insert into caracteristique (id_sous_famille, nom, type, champ_obligatoire, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
					sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.ComboBox1.Text;
					sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = num;
					sqlCommand3.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					int num4 = (int)sqlCommand3.ExecuteScalar();
					bool flag11 = ajouter_caractéristique.radGridView1.Rows.Count != 0;
					if (flag11)
					{
						for (int i = 0; i < ajouter_caractéristique.radGridView1.Rows.Count; i++)
						{
							bool flag12 = fonction.DeleteSpace(Convert.ToString(ajouter_caractéristique.radGridView1.Rows[i].Cells[0].Value)) != "";
							if (flag12)
							{
								int num5 = 0;
								bool flag13 = Convert.ToString(ajouter_caractéristique.radGridView1.Rows[i].Cells[1].Value) == "True";
								if (flag13)
								{
									num5 = 1;
								}
								string cmdText4 = "insert into caracteristique_option (id_caracteristique, valeur_option, defaut) values (@i1, @i2, @i3)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = num4;
								sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = Convert.ToString(ajouter_caractéristique.radGridView1.Rows[i].Cells[0].Value);
								sqlCommand4.Parameters.Add("@i3", SqlDbType.Int).Value = num5;
								sqlCommand4.ExecuteNonQuery();
							}
						}
					}
					MessageBox.Show("Succés");
					Sous_Famille.id_sous_famille = this.label6.Text;
					Sous_Famille.select_caracteristique(this.label6.Text);
					this.select_type();
					this.TextBox1.Clear();
					bd.cnn.Close();
					ajouter_caractéristique.radGridView1.Rows.Clear();
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
