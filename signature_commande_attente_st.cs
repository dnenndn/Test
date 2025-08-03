using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000122 RID: 290
	public partial class signature_commande_attente_st : Form
	{
		// Token: 0x06000CDC RID: 3292 RVA: 0x001F3C99 File Offset: 0x001F1E99
		public signature_commande_attente_st()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x001F3CBC File Offset: 0x001F1EBC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select designation from signature where id_utilisateur = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = page_loginn.id_user;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					bool flag3 = dataTable.Rows[0].ItemArray[0].ToString() == fonction.chiffrage_signature(this.TextBox2.Text);
					if (flag3)
					{
						string cmdText2 = "update ds_commande set statut = @v, date_signature = @d where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_cmnd;
						sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 1;
						sqlCommand2.Parameters.Add("@d", SqlDbType.DateTime).Value = DateTime.Today;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText3 = "select id_t from ds_commande_article where id_commande = @i and source = @s";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.id_cmnd;
						sqlCommand3.Parameters.Add("@s", SqlDbType.VarChar).Value = "ex";
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							for (int i = 0; i < dataTable2.Rows.Count; i++)
							{
								string cmdText4 = "insert into ds_historique_mvt (id_t, id_mvt, date_mvt, heure_mvt, mvt) values (@i1, @i2, @i3, @i4, @i5)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = this.id_cmnd;
								sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0].ToString();
								sqlCommand4.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
								sqlCommand4.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
								sqlCommand4.Parameters.Add("@i5", SqlDbType.VarChar).Value = "Commande";
								string cmdText5 = "update magasin_sous_traitance set emplacement_actuel = @e, equipement_actuel = @h where id = @i";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
								sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0].ToString();
								sqlCommand5.Parameters.Add("@e", SqlDbType.VarChar).Value = "Reparation";
								sqlCommand5.Parameters.Add("@h", SqlDbType.Int).Value = 0;
								bd.ouverture_bd(bd.cnn);
								sqlCommand4.ExecuteNonQuery();
								sqlCommand5.ExecuteNonQuery();
								bd.cnn.Close();
							}
						}
						int n_commande = this.select_n_commande(Convert.ToInt32(this.id_cmnd));
						this.creer_notif(this.id_cmnd, n_commande);
						MessageBox.Show("La commande n° " + n_commande.ToString() + " est maintenant en cours");
						commande_attente_st.panel1.Hide();
						commande_attente_st.remplissage_tableau(3);
						base.Close();
					}
					else
					{
						MessageBox.Show("Erreur : La signature est incorrecte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Absence de signature , Créer une signature tout d'abort", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x001F4100 File Offset: 0x001F2300
		private void creer_notif(string id_c, int n_commande)
		{
			bd bd = new bd();
			string cmdText = "select fournisseur.nom from ds_commande inner join fournisseur on ds_commande.id_fournisseur = fournisseur.id where ds_commande.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_c;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string text = dataTable.Rows[0].ItemArray[0].ToString();
			string cmdText2 = "select id from utilisateur where fonction = @i1 or fonction = @i2 or fonction = @i3";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = "Responsable Méthode";
			sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = "Responsable Achat";
			sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = "Responsable Magasin";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					string cmdText3 = "insert into notification (id_n, type, id_utilisateur, description, vue, date_creation) values (@v1, @v2, @v3, @v4, @v5, @v6)";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@v1", SqlDbType.Int).Value = id_c;
					sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = "Signature Commande";
					sqlCommand3.Parameters.Add("@v3", SqlDbType.Int).Value = dataTable2.Rows[i].ItemArray[0];
					sqlCommand3.Parameters.Add("@v4", SqlDbType.VarChar).Value = string.Concat(new string[]
					{
						page_loginn.esm,
						" a signé la commande Sous Traitant N° ",
						n_commande.ToString(),
						"   le : ",
						DateTime.Now.ToString(),
						" de fournisseur : ",
						text
					});
					sqlCommand3.Parameters.Add("@v5", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@v6", SqlDbType.Date).Value = DateTime.Today;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x001F4380 File Offset: 0x001F2580
		private int select_n_commande(int id_c)
		{
			int result = 1;
			bd bd = new bd();
			string cmdText = "select n_commande from ds_commande where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_c;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				result = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
			}
			return result;
		}

		// Token: 0x0400106D RID: 4205
		private string id_cmnd = commande_attente_st.id_commande;
	}
}
