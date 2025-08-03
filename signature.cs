using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x0200015F RID: 351
	public partial class signature : Form
	{
		// Token: 0x06000F66 RID: 3942 RVA: 0x00252723 File Offset: 0x00250923
		public signature()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x0025273C File Offset: 0x0025093C
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DimGray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x00252778 File Offset: 0x00250978
		private void signature_Load(object sender, EventArgs e)
		{
			this.panel2.Hide();
			this.panel3.Hide();
			bd bd = new bd();
			string cmdText = "select id from signature where id_utilisateur = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = page_loginn.id_user;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count == 0;
			if (flag)
			{
				this.panel2.Show();
			}
			else
			{
				this.panel3.Location = new Point(12, 58);
				this.panel3.Show();
			}
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x00252838 File Offset: 0x00250A38
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.guna2TextBox1.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.TextBox2.Text) & fonction.isnumeric(this.guna2TextBox1.Text);
				if (flag2)
				{
					bool flag3 = this.TextBox2.Text.Length <= 8 & this.TextBox2.Text.Length >= 4;
					if (flag3)
					{
						bool flag4 = this.TextBox2.Text == this.guna2TextBox1.Text;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "insert into signature (id_utilisateur,designation) values (@i1, @i2)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.chiffrage_signature(this.TextBox2.Text);
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Création d'une signature avec succés");
							this.TextBox2.Clear();
							this.guna2TextBox1.Clear();
							this.signature_Load(sender, e);
						}
						else
						{
							MessageBox.Show("Erreur : La confirmation de signature est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : La signature doit contenir entre 4 et 8 chiffres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : La signature doit contenir entre 4 et 8 chiffres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00252A2C File Offset: 0x00250C2C
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.guna2TextBox3.Text) != "" & fonction.DeleteSpace(this.guna2TextBox2.Text) != "" & fonction.DeleteSpace(this.guna2TextBox4.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.guna2TextBox3.Text) & fonction.isnumeric(this.guna2TextBox2.Text);
				if (flag2)
				{
					bool flag3 = this.guna2TextBox3.Text.Length <= 8 & this.guna2TextBox3.Text.Length >= 4;
					if (flag3)
					{
						bool flag4 = this.guna2TextBox3.Text == this.guna2TextBox2.Text;
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "select designation from signature where id_utilisateur = @i and designation = @v";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = page_loginn.id_user;
							sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = fonction.chiffrage_signature(this.guna2TextBox4.Text);
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag5 = dataTable.Rows.Count != 0;
							if (flag5)
							{
								string cmdText2 = "update signature set designation = @i2 where id_utilisateur = @i1";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = page_loginn.id_user;
								sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.chiffrage_signature(this.guna2TextBox3.Text);
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								bd.cnn.Close();
								MessageBox.Show("Modification d'une signature avec succés");
								this.guna2TextBox4.Clear();
								this.guna2TextBox3.Clear();
								this.guna2TextBox2.Clear();
							}
							else
							{
								MessageBox.Show("Erreur : L'ancienne signature est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : La confirmation de signature est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : La signature doit contenir entre 4 et 8 chiffres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : La signature doit contenir entre 4 et 8 chiffres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
