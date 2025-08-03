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
	// Token: 0x02000024 RID: 36
	public partial class article_parametre : Form
	{
		// Token: 0x060001DC RID: 476 RVA: 0x0004E79D File Offset: 0x0004C99D
		public article_parametre()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0004E7B8 File Offset: 0x0004C9B8
		private void article_parametre_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Méthode";
			if (flag)
			{
				this.guna2Button1.Visible = false;
			}
			this.label2.Text = "";
			this.select_classification();
			this.select_unite();
			this.select_stockage();
			this.select_emplacement();
			this.get_classification();
			this.get_emplacement();
			this.get_unite();
			this.get_stockage();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0004E834 File Offset: 0x0004CA34
		private void select_unite()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_unite_article where deleted =@d";
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
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0004E908 File Offset: 0x0004CB08
		private void select_stockage()
		{
			this.radDropDownList4.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_stockage_article where deleted =@d";
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
					this.radDropDownList4.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0004E9DC File Offset: 0x0004CBDC
		private void select_classification()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_classification_article where deleted =@d";
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
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0004EAB0 File Offset: 0x0004CCB0
		private void select_emplacement()
		{
			this.radDropDownList5.Items.Clear();
			bd bd = new bd();
			string cmdText = "select designation from parametre_emplacement_article where deleted =@d";
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
					this.radDropDownList5.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0004EB84 File Offset: 0x0004CD84
		private void get_classification()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_classification_article inner join tableau_article_classification on parametre_classification_article.id = tableau_article_classification.id_classification where parametre_classification_article.deleted = @d and tableau_article_classification.id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList6.Text = dataTable.Rows[0].ItemArray[0].ToString();
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0004EC38 File Offset: 0x0004CE38
		private void get_emplacement()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_emplacement_article inner join tableau_article_emplacement on parametre_emplacement_article.id = tableau_article_emplacement.id_emplacement where parametre_emplacement_article.deleted = @d and tableau_article_emplacement.id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList5.Text = dataTable.Rows[0].ItemArray[0].ToString();
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0004ECEC File Offset: 0x0004CEEC
		private void get_unite()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_unite_article inner join tableau_article_unite on parametre_unite_article.id = tableau_article_unite.id_unite where parametre_unite_article.deleted = @d and tableau_article_unite.id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList1.Text = dataTable.Rows[0].ItemArray[0].ToString();
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0004EDA0 File Offset: 0x0004CFA0
		private void get_stockage()
		{
			bd bd = new bd();
			string cmdText = "select designation from parametre_stockage_article inner join tableau_article_stockage on parametre_stockage_article.id = tableau_article_stockage.id_stockage where parametre_stockage_article.deleted = @d and tableau_article_stockage.id_article = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_article.id_article;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList4.Text = dataTable.Rows[0].ItemArray[0].ToString();
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0004EE54 File Offset: 0x0004D054
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				this.save_classification(liste_article.id_article);
				this.save_emplacement(liste_article.id_article);
				this.save_stockage(liste_article.id_article);
				this.save_unite(liste_article.id_article);
				MessageBox.Show("Modification avec succés");
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0004EEDC File Offset: 0x0004D0DC
		private void save_unite(string id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_unite_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select id from tableau_article_unite where id_article = @h";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = id;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						string cmdText3 = "update tableau_article_unite set id_unite = @i2 where id_article = @i1";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
					else
					{
						string cmdText4 = "insert into tableau_article_unite (id_article, id_unite) values (@i1, @i2)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0004F104 File Offset: 0x0004D304
		private void save_classification(string id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList6.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_classification_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select id from tableau_article_classification where id_article = @h";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = id;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						string cmdText3 = "update tableau_article_classification set id_classification = @i2 where id_article = @i1";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
					else
					{
						string cmdText4 = "insert into tableau_article_classification (id_article, id_classification) values (@i1, @i2)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0004F32C File Offset: 0x0004D52C
		private void save_stockage(string id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList4.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_stockage_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select id from tableau_article_stockage where id_article = @h";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = id;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						string cmdText3 = "update tableau_article_stockage set id_stockage = @i2 where id_article = @i1";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
					else
					{
						string cmdText4 = "insert into tableau_article_stockage(id_article, id_stockage) values (@i1, @i2)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0004F554 File Offset: 0x0004D754
		private void save_emplacement(string id)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.radDropDownList5.Text) != "";
			if (flag)
			{
				string cmdText = "select id from parametre_emplacement_article where designation = @a and deleted = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.radDropDownList5.Text;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select id from tableau_article_emplacement where id_article = @h";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = id;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						string cmdText3 = "update tableau_article_emplacement set id_emplacement = @i2 where id_article = @i1";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
					}
					else
					{
						string cmdText4 = "insert into tableau_article_emplacement(id_article, id_emplacement) values (@i1, @i2)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}
	}
}
