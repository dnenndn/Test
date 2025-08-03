using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;

namespace GMAO
{
	// Token: 0x0200000F RID: 15
	public partial class ajouter_equipement : Form
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x000275CF File Offset: 0x000257CF
		public ajouter_equipement()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000275E8 File Offset: 0x000257E8
		private void ajouter_equipement_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label7.Text = "";
			this.label6.Text = Arbre_Equipement.id_parent;
			this.label7.Text = Arbre_Equipement.des_parent;
			this.guna2NumericUpDown1.Maximum = Arbre_Equipement.ordre + 1;
			this.guna2NumericUpDown1.Minimum = 1m;
			this.guna2NumericUpDown1.Value = Arbre_Equipement.ordre + 1;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0002767C File Offset: 0x0002587C
		private int test_ordre_vrai()
		{
			int result = 1;
			string cmdText = "select max(ordre) from equipement where id_parent = @i and deleted = @d";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = Convert.ToString(dataTable.Rows[0].ItemArray[0]) != "";
				if (flag2)
				{
					result = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]) + 1;
				}
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00027764 File Offset: 0x00025964
		private int test_existe_parent()
		{
			int result = 0;
			string cmdText = "select id from equipement where id = @i and deleted = @d";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = Convert.ToString(dataTable.Rows[0].ItemArray[0]) != "";
				if (flag2)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00027830 File Offset: 0x00025A30
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				int num = this.test_existe_parent();
				bool flag2 = num == 1;
				if (flag2)
				{
					int num2 = this.test_ordre_vrai();
					int num3 = Convert.ToInt32(this.guna2NumericUpDown1.Value);
					bool flag3 = num3 <= num2;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "insert into equipement (id_parent, code, designation, ordre, deleted) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = num3;
						sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						int id_m = (int)sqlCommand.ExecuteScalar();
						bd.cnn.Close();
						this.update_ordre(Convert.ToInt32(this.label6.Text), num3, id_m);
						Arbre_Equipement.mise_jour_arbre(num3, Arbre_Equipement.nd_ajouter, id_m, this.TextBox1.Text, this.TextBox2.Text);
						base.Close();
					}
					else
					{
						MessageBox.Show("Erreur : Un equipement de même niveau est supprimé, l'ordre est inférieure à cette valeur");
					}
				}
				else
				{
					MessageBox.Show("Erreur : L'equipement est supprimé");
					base.Close();
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs Obligatoire est vide");
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00027A34 File Offset: 0x00025C34
		private void update_ordre(int id_pr, int ord, int id_m)
		{
			bd bd = new bd();
			string cmdText = "update equipement set ordre = ordre + @v where id_parent =@i and deleted = @d and ordre >=@o and id<> @l";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_pr;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@o", SqlDbType.Int).Value = ord;
			sqlCommand.Parameters.Add("@l", SqlDbType.Int).Value = id_m;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}
	}
}
