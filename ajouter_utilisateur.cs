using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000013 RID: 19
	public partial class ajouter_utilisateur : Form
	{
		// Token: 0x06000118 RID: 280 RVA: 0x000368ED File Offset: 0x00034AED
		public ajouter_utilisateur()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00036908 File Offset: 0x00034B08
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DimGray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00036942 File Offset: 0x00034B42
		private void ajouter_utilisateur_Load(object sender, EventArgs e)
		{
			this.pictureBox2.Hide();
			this.select_fonction();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00036958 File Offset: 0x00034B58
		private void select_fonction()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Administrateur");
			this.radDropDownList1.Items.Add("Responsable Méthode");
			this.radDropDownList1.Items.Add("Agent de Méthode");
			this.radDropDownList1.Items.Add("Responsable Achat");
			this.radDropDownList1.Items.Add("Responsable Magasin");
			this.radDropDownList1.Items.Add("Magasinier");
			this.radDropDownList1.Items.Add("Responsable Technique");
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00036A14 File Offset: 0x00034C14
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.TextBox3.Text) != "" & fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				bool flag2 = this.TextBox2.Text.ToLower() == this.TextBox3.Text.ToLower();
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select id from utilisateur where login = @a";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.TextBox1.Text;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						MemoryStream memoryStream = new MemoryStream();
						this.pictureBox1.Image.Save(memoryStream, this.pictureBox1.Image.RawFormat);
						byte[] value = new byte[0];
						value = memoryStream.ToArray();
						string cmdText2 = "insert into utilisateur (login, mot_passe, fonction, photo, mail, telephone, deleted) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						sqlCommand2.Parameters.Add("@i4", SqlDbType.Image).Value = value;
						sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand2.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.guna2TextBox2.Text;
						sqlCommand2.Parameters.Add("@i7", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Enregistrement avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.TextBox3.Clear();
						this.guna2TextBox1.Clear();
						this.guna2TextBox2.Clear();
						this.select_fonction();
						this.pictureBox1.Image = this.pictureBox2.Image;
					}
					else
					{
						MessageBox.Show("Erreur : Nom d'utilisateur déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Votre mot de passe n'est pas correctement confirmé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00036D4C File Offset: 0x00034F4C
		private void PictureBox6_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
			}
		}
	}
}
