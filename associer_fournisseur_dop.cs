using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000026 RID: 38
	public partial class associer_fournisseur_dop : Form
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x00053024 File Offset: 0x00051224
		public associer_fournisseur_dop()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0005309A File Offset: 0x0005129A
		private void associer_fournisseur_dop_Load(object sender, EventArgs e)
		{
			this.label3.Text = liste_dop.id_dop;
			this.select_list_fournisseur();
			this.select_tableau_fournisseur();
			this.select_article();
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000530C4 File Offset: 0x000512C4
		private void select_list_fournisseur()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id_article from dop_article where id_dop = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select fournisseur.nom, fournisseur.id from tableau_article_fournisseur inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id where id_article = @a and fournisseur.deleted = @d";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@a", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							bool flag3 = this.fournisseur_existe(dataTable2.Rows[j].ItemArray[0].ToString()) == 0;
							if (flag3)
							{
								this.radDropDownList6.Items.Add(dataTable2.Rows[j].ItemArray[0].ToString());
								this.radDropDownList6.Items[this.radDropDownList6.Items.Count - 1].Tag = dataTable2.Rows[j].ItemArray[1].ToString();
							}
						}
					}
				}
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000532D4 File Offset: 0x000514D4
		private int fournisseur_existe(string s)
		{
			int result = 0;
			bool flag = this.radDropDownList6.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radDropDownList6.Items.Count; i++)
				{
					bool flag2 = this.radDropDownList6.Items[i].Text == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0005334C File Offset: 0x0005154C
		private void select_tableau_fournisseur()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select fournisseur.nom, fournisseur.id from dop_fournisseur inner join fournisseur on dop_fournisseur.id_fournisseur = fournisseur.id where id_dop = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[0].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00053450 File Offset: 0x00051650
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				int num = 0;
				bool flag2 = this.radGridView1.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < this.radGridView1.Rows.Count; i++)
					{
						bool flag3 = this.radDropDownList6.SelectedItem.Tag.ToString() == this.radGridView1.Rows[i].Cells[0].Value.ToString();
						if (flag3)
						{
							num = 1;
						}
					}
				}
				bool flag4 = num == 0;
				if (flag4)
				{
					bd bd = new bd();
					string cmdText = "insert into dop_fournisseur (id_dop, id_fournisseur) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label3.Text;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag.ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_tableau_fournisseur();
				}
				else
				{
					MessageBox.Show("Erreur : Le fournisseur est déja associé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Choisir un fournisseur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000535DC File Offset: 0x000517DC
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex >= 0 && e.ColumnIndex == 2;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer la demande offre de prix ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "select devis_fournisseur.id_devis from devis_fournisseur inner join devis on devis_fournisseur.id_devis = devis.id where devis_fournisseur.id_fournisseur = @i1 and devis.id_dop = @i2";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = liste_dop.id_dop;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count != 0;
						if (flag4)
						{
							string cmdText2 = "delete devis where id = @i";
							string cmdText3 = "delete devis_fournisseur where id_devis = @i";
							string cmdText4 = "delete devis_article where id_devis = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							sqlCommand3.ExecuteNonQuery();
							sqlCommand4.ExecuteNonQuery();
							bd.cnn.Close();
						}
						string cmdText5 = "delete dop_fournisseur where id_dop = @i and id_fournisseur = @i1";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = liste_dop.id_dop;
						sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand5.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_tableau_fournisseur();
					}
				}
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000538A4 File Offset: 0x00051AA4
		private void select_article()
		{
			this.radDropDownList2.Items.Clear();
			bd bd = new bd();
			string cmdText = "select article.designation, article.id from article where article.id in (select id_article from dop_article where id_dop = @i) and article.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label3.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000539CC File Offset: 0x00051BCC
		private void radDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			bool flag = this.radDropDownList2.Text != "";
			if (flag)
			{
				string cmdText = "select distinct fournisseur.nom, fournisseur.id from fournisseur where fournisseur.deleted = @d and fournisseur.id not in (select id_fournisseur from tableau_article_fournisseur where id_article = @i)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
						this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
					}
				}
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00053B1C File Offset: 0x00051D1C
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "" & this.radDropDownList2.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "insert into tableau_article_fournisseur (id_article, id_fournisseur) values (@i1, @i2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList2.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Enregistrement avec succés");
				this.select_list_fournisseur();
				this.select_article();
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
