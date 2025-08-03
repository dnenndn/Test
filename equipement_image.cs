using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200012E RID: 302
	public partial class equipement_image : Form
	{
		// Token: 0x06000D51 RID: 3409 RVA: 0x00206C09 File Offset: 0x00204E09
		public equipement_image()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x00206C24 File Offset: 0x00204E24
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
				MemoryStream memoryStream = new MemoryStream();
				PictureBox pictureBox = new PictureBox();
				pictureBox.Image = new Bitmap(openFileDialog.FileName);
				pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
				byte[] value = new byte[0];
				value = memoryStream.ToArray();
				string cmdText = "insert into equipement_image(id_equipement, photo) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Image).Value = value;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.select_image();
			}
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00206D40 File Offset: 0x00204F40
		private void select_image()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			this.radPanel1.Controls.Clear();
			string cmdText = "select photo, id from equipement_image where id_equipement = @i";
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
					pictureBox.Size = new Size(291, 302);
					pictureBox.Cursor = Cursors.Hand;
					pictureBox.Location = new Point(5 + 310 * i, 2);
					pictureBox.BorderStyle = BorderStyle.FixedSingle;
					pictureBox.Image = this.PictureBox7.Image;
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					PictureBox pictureBox2 = new PictureBox();
					byte[] buffer = (byte[])dataTable.Rows[i].ItemArray[0];
					MemoryStream stream = new MemoryStream(buffer);
					pictureBox2.Image = Image.FromStream(stream);
					pictureBox.Click += delegate(object s, EventArgs e)
					{
					};
					pictureBox.Image = pictureBox2.Image;
					PictureBox pictureBox3 = new PictureBox();
					pictureBox3.Size = new Size(15, 15);
					pictureBox3.Cursor = Cursors.Hand;
					pictureBox3.Location = new Point(298 + 310 * i, 2);
					pictureBox3.Image = this.PictureBox8.Image;
					pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
					string h = dataTable.Rows[i].ItemArray[1].ToString();
					pictureBox3.Click += delegate(object s, EventArgs ee)
					{
						this.supprimer_image(h);
					};
					this.radPanel1.Controls.Add(pictureBox);
					this.radPanel1.Controls.Add(pictureBox3);
				}
			}
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00206F9C File Offset: 0x0020519C
		private void equipement_image_Load(object sender, EventArgs e)
		{
			this.select_image();
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00206FA8 File Offset: 0x002051A8
		private void supprimer_image(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				bd bd = new bd();
				fonction fonction = new fonction();
				string cmdText = "delete equipement_image where id_equipement = @i1 and id = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = x;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.select_image();
			}
		}
	}
}
