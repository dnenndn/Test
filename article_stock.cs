using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000025 RID: 37
	public partial class article_stock : Form
	{
		// Token: 0x060001ED RID: 493 RVA: 0x00050C47 File Offset: 0x0004EE47
		public article_stock()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00050C60 File Offset: 0x0004EE60
		private void article_stock_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Méthode";
			if (flag)
			{
				this.guna2Button1.Visible = false;
			}
			this.label2.Text = "";
			bd bd = new bd();
			string cmdText = "select code_article, prix_ht, tva, stock_neuf,stock_use ,stock_rebute, stock_mini, stock_maxi, stock_securite from article where id=@i";
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
				this.TextBox2.Text = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
				this.TextBox3.Text = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
				this.TextBox4.Text = Convert.ToString(dataTable.Rows[0].ItemArray[4]);
				this.TextBox5.Text = Convert.ToString(dataTable.Rows[0].ItemArray[5]);
				this.TextBox6.Text = Convert.ToString(dataTable.Rows[0].ItemArray[6]);
				this.TextBox7.Text = Convert.ToString(dataTable.Rows[0].ItemArray[7]);
				this.TextBox8.Text = Convert.ToString(dataTable.Rows[0].ItemArray[8]);
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00050E58 File Offset: 0x0004F058
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(this.TextBox1.Text) & fonction.is_reel(this.TextBox2.Text) & fonction.is_reel(this.TextBox3.Text) & fonction.is_reel(this.TextBox4.Text) & fonction.is_reel(this.TextBox5.Text) & this.controle_nombre(this.TextBox6.Text) == 1 & this.controle_nombre(this.TextBox7.Text) == 1 & this.controle_nombre(this.TextBox8.Text) == 1;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "update article set prix_ht = @i1, tva = @i2, stock_neuf = @i3, stock_use = @i4, stock_rebute = @i5, stock_mini = @i6, stock_maxi = @i7, stock_securite = @i8 where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
				sqlCommand.Parameters.Add("@i1", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox1.Text);
				sqlCommand.Parameters.Add("@i2", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox2.Text);
				sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox3.Text);
				sqlCommand.Parameters.Add("@i4", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox4.Text);
				sqlCommand.Parameters.Add("@i5", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox5.Text);
				sqlCommand.Parameters.Add("@i6", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox6.Text);
				sqlCommand.Parameters.Add("@i7", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox7.Text);
				sqlCommand.Parameters.Add("@i8", SqlDbType.Real).Value = this.conversiontoreal(this.TextBox8.Text);
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.save_modification(liste_article.id_article);
				MessageBox.Show("Modification avec succés");
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0005110C File Offset: 0x0004F30C
		private int controle_nombre(string l)
		{
			int result = 0;
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(l) == "" | fonction.is_reel(l);
			if (flag)
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00051148 File Offset: 0x0004F348
		private double conversiontoreal(string s)
		{
			double result = 0.0;
			fonction fonction = new fonction();
			bool flag = fonction.is_reel(s);
			if (flag)
			{
				result = Convert.ToDouble(s);
			}
			return result;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00051180 File Offset: 0x0004F380
		private void save_modification(string id)
		{
			bd bd = new bd();
			string cmdText = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox2.Text;
			sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox1.Text;
			sqlCommand.Parameters.Add("@i4", SqlDbType.Real).Value = this.TextBox3.Text;
			sqlCommand.Parameters.Add("@i5", SqlDbType.Real).Value = this.TextBox4.Text;
			sqlCommand.Parameters.Add("@i6", SqlDbType.Real).Value = this.TextBox5.Text;
			sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = DateTime.Today;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}
	}
}
