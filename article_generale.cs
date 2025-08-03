using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000022 RID: 34
	public partial class article_generale : Form
	{
		// Token: 0x060001CD RID: 461 RVA: 0x0004C45B File Offset: 0x0004A65B
		public article_generale()
		{
			this.InitializeComponent();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0004C48C File Offset: 0x0004A68C
		private void article_generale_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Méthode";
			if (flag)
			{
				this.guna2Button1.Visible = false;
			}
			this.label2.Text = "";
			bd bd = new bd();
			this.select_fournisseur();
			string cmdText = "select code_article, reference, designation, marque, methode_gestion from article where id=@i";
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
				bool flag3 = Convert.ToString(dataTable.Rows[0].ItemArray[4]) == "Réapprovisionnement";
				if (flag3)
				{
					this.radRadioButton1.IsChecked = true;
				}
				bool flag4 = Convert.ToString(dataTable.Rows[0].ItemArray[4]) == "Gestion à point commande";
				if (flag4)
				{
					this.radRadioButton2.IsChecked = true;
				}
				bool flag5 = Convert.ToString(dataTable.Rows[0].ItemArray[4]) == "Recomplètement";
				if (flag5)
				{
					this.radRadioButton3.IsChecked = true;
				}
				bool flag6 = Convert.ToString(dataTable.Rows[0].ItemArray[4]) == "Réapprovisionnement à la commande";
				if (flag6)
				{
					this.radRadioButton4.IsChecked = true;
				}
			}
			string cmdText2 = "select nom from fournisseur inner join tableau_article_fournisseur on fournisseur.id = tableau_article_fournisseur.id_fournisseur where fournisseur.deleted = @d and tableau_article_fournisseur.id_article = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag7 = dataTable2.Rows.Count != 0;
			if (flag7)
			{
				bool flag8 = this.radCheckedDropDownList1.Items.Count != 0;
				if (flag8)
				{
					for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
					{
						int num = this.recherche_data_table(dataTable2, this.radCheckedDropDownList1.Items[i].Text);
						bool flag9 = num == 1;
						if (flag9)
						{
							this.radCheckedDropDownList1.Items[i].Checked = true;
						}
					}
				}
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0004C7BC File Offset: 0x0004A9BC
		private void select_fournisseur()
		{
			this.radCheckedDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select nom from fournisseur where deleted =@d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0004C890 File Offset: 0x0004AA90
		private int recherche_data_table(DataTable table, string s)
		{
			int result = 0;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				bool flag = s == table.Rows[i].ItemArray[0].ToString();
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0004C8EC File Offset: 0x0004AAEC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & this.controle_fournisseur() == 1;
			if (flag)
			{
				bd bd = new bd();
				string value = "";
				foreach (object obj in this.panel3.Controls)
				{
					Control control = (Control)obj;
					RadRadioButton radRadioButton = (RadRadioButton)control;
					bool isChecked = radRadioButton.IsChecked;
					if (isChecked)
					{
						value = radRadioButton.Text;
					}
				}
				string cmdText = "update article set reference = @i1, designation = @i2, marque = @i3, methode_gestion = @i4 where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
				sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox3.Text;
				sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = value;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.update_fournisseur();
				MessageBox.Show("Modification avec succés");
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0004CAD0 File Offset: 0x0004ACD0
		private int controle_fournisseur()
		{
			int result = 0;
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
					if (@checked)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0004CB44 File Offset: 0x0004AD44
		private void update_fournisseur()
		{
			bd bd = new bd();
			string cmdText = "select nom from fournisseur inner join tableau_article_fournisseur on fournisseur.id = tableau_article_fournisseur.id_fournisseur where tableau_article_fournisseur.id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = this.radCheckedDropDownList1.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool flag2 = this.radCheckedDropDownList1.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList1.Items[i].Text) == 0;
					if (flag2)
					{
						string cmdText2 = "select id from fournisseur where nom = @v and deleted = @d";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag3 = dataTable2.Rows.Count != 0;
						if (flag3)
						{
							string cmdText3 = "insert into tableau_article_fournisseur (id_article, id_fournisseur) values (@i1, @i2)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = liste_article.id_article;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable2.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					bool flag4 = !this.radCheckedDropDownList1.Items[i].Checked & this.recherche_data_table(dataTable, this.radCheckedDropDownList1.Items[i].Text) == 1;
					if (flag4)
					{
						string cmdText4 = "select id from fournisseur where nom = @v and deleted = @d";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radCheckedDropDownList1.Items[i].Text;
						sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag5 = dataTable3.Rows.Count != 0;
						if (flag5)
						{
							string cmdText5 = "delete tableau_article_fournisseur where id_article = @i1 and id_fournisseur = @i2";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = liste_article.id_article;
							sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}
	}
}
