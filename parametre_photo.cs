using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x020000F3 RID: 243
	public partial class parametre_photo : Form
	{
		// Token: 0x06000A82 RID: 2690 RVA: 0x0019EC36 File Offset: 0x0019CE36
		public parametre_photo()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0019EC4E File Offset: 0x0019CE4E
		private void parametre_photo_Load(object sender, EventArgs e)
		{
			this.select_usine();
			this.select_parc();
			this.select_atelier();
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0019EC68 File Offset: 0x0019CE68
		private void guna2Button1_Click(object sender, EventArgs e)
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

		// Token: 0x06000A85 RID: 2693 RVA: 0x0019ECBC File Offset: 0x0019CEBC
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox2.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0019ED10 File Offset: 0x0019CF10
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox3.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0019ED64 File Offset: 0x0019CF64
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			bool flag = this.pictureBox1.Image != null;
			if (flag)
			{
				string cmdText = "update  parametre_image set photo_usine = @img";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				MemoryStream memoryStream = new MemoryStream();
				this.pictureBox1.Image.Save(memoryStream, this.pictureBox1.Image.RawFormat);
				byte[] value = new byte[0];
				value = memoryStream.ToArray();
				sqlCommand.Parameters.Add("@img", SqlDbType.Image).Value = value;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool flag2 = this.pictureBox2.Image != null;
			if (flag2)
			{
				string cmdText2 = "update  parametre_image set photo_parc = @img";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				MemoryStream memoryStream2 = new MemoryStream();
				this.pictureBox2.Image.Save(memoryStream2, this.pictureBox2.Image.RawFormat);
				byte[] value2 = new byte[0];
				value2 = memoryStream2.ToArray();
				sqlCommand2.Parameters.Add("@img", SqlDbType.Image).Value = value2;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool flag3 = this.pictureBox3.Image != null;
			if (flag3)
			{
				string cmdText3 = "update  parametre_image set photo_atelier = @img";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				MemoryStream memoryStream3 = new MemoryStream();
				this.pictureBox3.Image.Save(memoryStream3, this.pictureBox3.Image.RawFormat);
				byte[] value3 = new byte[0];
				value3 = memoryStream3.ToArray();
				sqlCommand3.Parameters.Add("@img", SqlDbType.Image).Value = value3;
				bd.ouverture_bd(bd.cnn);
				sqlCommand3.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0019EF60 File Offset: 0x0019D160
		public void select_usine()
		{
			bd bd = new bd();
			string cmdText = "select photo_usine from parametre_image where photo_usine is not null ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
				MemoryStream stream = new MemoryStream(buffer);
				this.pictureBox1.Image = Image.FromStream(stream);
			}
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0019EFEC File Offset: 0x0019D1EC
		public void select_parc()
		{
			bd bd = new bd();
			string cmdText = "select photo_parc from parametre_image where photo_parc is not null ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
				MemoryStream stream = new MemoryStream(buffer);
				this.pictureBox2.Image = Image.FromStream(stream);
			}
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0019F078 File Offset: 0x0019D278
		public void select_atelier()
		{
			bd bd = new bd();
			string cmdText = "select photo_atelier from parametre_image where photo_atelier is not null ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
				MemoryStream stream = new MemoryStream(buffer);
				this.pictureBox3.Image = Image.FromStream(stream);
			}
		}
	}
}
