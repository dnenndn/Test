using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000020 RID: 32
	public partial class article_commentaire : Form
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x0004A582 File Offset: 0x00048782
		public article_commentaire()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0004A59C File Offset: 0x0004879C
		private void article_commentaire_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Méthode";
			if (flag)
			{
				this.guna2Button1.Visible = false;
			}
			this.label2.Text = "";
			bd bd = new bd();
			string cmdText = "select code_article, commentaire from article where id=@i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				this.label2.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
				this.TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0004A68C File Offset: 0x0004888C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "update article set commentaire = @v where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
			sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = liste_article.id_article;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			MessageBox.Show("Modification avec succés");
		}
	}
}
