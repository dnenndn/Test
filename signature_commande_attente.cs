using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000160 RID: 352
	public partial class signature_commande_attente : Form
	{
		// Token: 0x06000F6D RID: 3949 RVA: 0x002542AC File Offset: 0x002524AC
		public signature_commande_attente()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x002542D0 File Offset: 0x002524D0
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
						string cmdText2 = "update commande set statut = @v, date_signature = @d where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_cmnd;
						sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 1;
						sqlCommand2.Parameters.Add("@d", SqlDbType.DateTime).Value = DateTime.Today;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						int n_commande = this.select_n_commande(Convert.ToInt32(this.id_cmnd));
						this.creer_notif(this.id_cmnd, n_commande);
						MessageBox.Show("La commande n° " + n_commande.ToString() + " est maintenant en cours");
						commande_attente.radPanel1.Hide();
						commande_attente.remplissage_tableau(3);
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

		// Token: 0x06000F6F RID: 3951 RVA: 0x002544E4 File Offset: 0x002526E4
		private void creer_notif(string id_c, int n_commande)
		{
			bd bd = new bd();
			string cmdText = "select fournisseur.nom from commande inner join fournisseur on commande.id_fournisseur = fournisseur.id where commande.id = @i";
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
						" a signé la commande N° ",
						n_commande.ToString(),
						"   le : ",
						DateTime.Now.ToString(),
						" de fournisseur :  ",
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

		// Token: 0x06000F70 RID: 3952 RVA: 0x00254764 File Offset: 0x00252964
		private int select_n_commande(int id_c)
		{
			int result = 1;
			bd bd = new bd();
			string cmdText = "select n_commande from commande where id = @i";
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

		// Token: 0x0400138A RID: 5002
		private string id_cmnd = commande_attente.id_commande;
	}
}
