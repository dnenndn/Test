using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000023 RID: 35
	public partial class article_image : Form
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x0004E32A File Offset: 0x0004C52A
		public article_image()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0004E344 File Offset: 0x0004C544
		private void article_image_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Méthode";
			if (flag)
			{
				this.pictureBox2.Visible = false;
			}
			this.select_image();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0004E37C File Offset: 0x0004C57C
		private void select_image()
		{
			bd bd = new bd();
			string cmdText = "select photo from article where id  = @to";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@to", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
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

		// Token: 0x060001D9 RID: 473 RVA: 0x0004E424 File Offset: 0x0004C624
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
				bd bd = new bd();
				string cmdText = "update article set photo = @i2 where id = @i1";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				MemoryStream memoryStream = new MemoryStream();
				this.pictureBox1.Image.Save(memoryStream, this.pictureBox1.Image.RawFormat);
				byte[] value = new byte[0];
				value = memoryStream.ToArray();
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = liste_article.id_article;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Image).Value = value;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}
	}
}
