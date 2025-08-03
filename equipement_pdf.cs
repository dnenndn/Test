using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000130 RID: 304
	public partial class equipement_pdf : Form
	{
		// Token: 0x06000D5E RID: 3422 RVA: 0x00207BC5 File Offset: 0x00205DC5
		public equipement_pdf()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00207BDD File Offset: 0x00205DDD
		private void equipement_pdf_Load(object sender, EventArgs e)
		{
			this.PictureBox10.Hide();
			this.PictureBox7.Hide();
			this.PictureBox8.Hide();
			this.recherche_fichier();
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00207C0C File Offset: 0x00205E0C
		private void PictureBox6_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(openFileDialog.FileName) != "";
			if (flag)
			{
				string cmdText = "insert into equipement_pdf(id_equipement, adresse) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = openFileDialog.FileName;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.recherche_fichier();
				Arbre_Equipement.list_fichier();
			}
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00207CE4 File Offset: 0x00205EE4
		private void recherche_fichier()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			this.radPanel1.Controls.Clear();
			string cmdText = "select adresse from equipement_pdf where id_equipement = @i";
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
					PictureBox pictureBox = new PictureBox();
					pictureBox.Size = new Size(48, 30);
					pictureBox.Cursor = Cursors.Hand;
					pictureBox.Location = new Point(5 + 100 * i, 7);
					pictureBox.Image = this.PictureBox7.Image;
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					string h = Convert.ToString(dataTable.Rows[i].ItemArray[0]);
					pictureBox.Click += delegate(object s, EventArgs e)
					{
						this.ouvrir(h);
					};
					pictureBox.Image = this.PictureBox10.Image;
					PictureBox pictureBox2 = new PictureBox();
					pictureBox2.Size = new Size(15, 15);
					pictureBox2.Cursor = Cursors.Hand;
					pictureBox2.Location = new Point(56 + 100 * i, 7);
					pictureBox2.Image = this.PictureBox8.Image;
					pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
					pictureBox2.Click += delegate(object s, EventArgs ee)
					{
						this.supprimer_file(h);
					};
					this.radPanel1.Controls.Add(pictureBox);
					this.radPanel1.Controls.Add(pictureBox2);
					Label label = new Label();
					label.AutoSize = true;
					label.BackColor = Color.Transparent;
					label.ForeColor = Color.Black;
					label.Location = new Point(5 + 100 * i, 45);
					label.Cursor = Cursors.Default;
					label.Text = this.nom_fichier(h);
					this.radPanel1.Controls.Add(label);
				}
			}
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x00207F54 File Offset: 0x00206154
		public string n_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == ".";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x00207FB4 File Offset: 0x002061B4
		public string nom_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == "\\";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x00208014 File Offset: 0x00206214
		private void supprimer_file(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				bd bd = new bd();
				fonction fonction = new fonction();
				string cmdText = "delete equipement_pdf where id_equipement = @i1 and adresse = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = x;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.recherche_fichier();
			}
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x002080C8 File Offset: 0x002062C8
		private void ouvrir(string h)
		{
			string newValue = "\\";
			string oldValue = "\\";
			h = h.Replace(oldValue, newValue);
			equipement_pdf.id_adresse = h;
			open_pdf_equipement open_pdf_equipement = new open_pdf_equipement();
			open_pdf_equipement.TopLevel = false;
			foreach (object obj in Arbre_Equipement.Panel10.Controls)
			{
				Control control = (Control)obj;
				control.Visible = false;
			}
			Arbre_Equipement.Panel10.Controls.Add(open_pdf_equipement);
			open_pdf_equipement.Show();
		}

		// Token: 0x04001108 RID: 4360
		public static string id_adresse;
	}
}
