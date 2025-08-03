using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000131 RID: 305
	public partial class equipement_prevision : Form
	{
		// Token: 0x06000D68 RID: 3432 RVA: 0x00208706 File Offset: 0x00206906
		public equipement_prevision()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x0020871E File Offset: 0x0020691E
		private void equipement_prevision_Load(object sender, EventArgs e)
		{
			this.select_periode();
			this.select_equipement();
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00208730 File Offset: 0x00206930
		private void select_periode()
		{
			this.guna2ComboBox1.Items.Clear();
			this.guna2ComboBox1.Items.Add("Jour");
			this.guna2ComboBox1.Items.Add("Semaine");
			this.guna2ComboBox1.Items.Add("Mois");
			this.guna2ComboBox1.Items.Add("Année");
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x002087A8 File Offset: 0x002069A8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = this.guna2ComboBox1.Text != "" & fonction.is_reel(this.TextBox1.Text) & fonction.is_reel(this.TextBox3.Text) & fonction.is_reel(this.TextBox2.Text);
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id  from equipement_prevision where id_equipement = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				string cmdText2;
				if (flag2)
				{
					cmdText2 = "insert into equipement_prevision(id_equipement, cout_arrêt, nbre_arrêt, periode_nbr, periode) values (@i1, @i2, @i3, @i4, @i5)";
				}
				else
				{
					cmdText2 = "update equipement_prevision set cout_arrêt = @i2, nbre_arrêt = @i3, periode_nbr = @i4, periode = @i5 where id_equipement = @i1";
				}
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox1.Text;
				sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox2.Text;
				sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = this.TextBox3.Text;
				sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.guna2ComboBox1.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Modification avec succès");
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier les champs");
			}
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00208994 File Offset: 0x00206B94
		private void select_equipement()
		{
			bd bd = new bd();
			string cmdText = "select cout_arrêt, nbre_arrêt, periode_nbr, periode from equipement_prevision where id_equipement = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[1].ToString();
				this.TextBox3.Text = dataTable.Rows[0].ItemArray[2].ToString();
				this.guna2ComboBox1.Text = dataTable.Rows[0].ItemArray[3].ToString();
			}
		}
	}
}
