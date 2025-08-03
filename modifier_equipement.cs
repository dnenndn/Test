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
	// Token: 0x02000147 RID: 327
	public partial class modifier_equipement : Form
	{
		// Token: 0x06000E95 RID: 3733 RVA: 0x00234DA4 File Offset: 0x00232FA4
		public modifier_equipement()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00234DBC File Offset: 0x00232FBC
		private void modifier_equipement_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label7.Text = "";
			this.guna2NumericUpDown1.Minimum = 1m;
			this.label6.Text = Arbre_Equipement.id_modifier;
			string cmdText = "select code, designation, ordre, id_parent from equipement where id= @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.guna2NumericUpDown1.Value = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]);
				this.a_ord = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]);
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[1].ToString();
				this.label7.Text = dataTable.Rows[0].ItemArray[1].ToString();
				int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]);
				modifier_equipement.id_prn = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]);
				string cmdText2 = "select max(ordre) from equipement where id_parent = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = num;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					this.guna2NumericUpDown1.Maximum = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
				}
			}
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00234FFC File Offset: 0x002331FC
		private void update_ordre(int ord, int id_p, int n_ord, int id_e)
		{
			bool flag = n_ord > ord;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "update equipement set ordre = ordre - @v where id_parent = @i1 and id <> @i2 and ((ordre <=@v1) and (ordre >@v2) and deleted = @d)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = 1;
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_p;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = id_e;
				sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = n_ord;
				sqlCommand.Parameters.Add("@v2", SqlDbType.Int).Value = ord;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool flag2 = n_ord < ord;
			if (flag2)
			{
				bd bd2 = new bd();
				string cmdText2 = "update equipement set ordre = ordre + @v where id_parent = @i1 and id <> @i2 and ((ordre >=@v1) and (ordre <@v2) and deleted = @d)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
				sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_p;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = id_e;
				sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = n_ord;
				sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = ord;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				bd2.ouverture_bd(bd2.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd2.cnn.Close();
			}
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00235208 File Offset: 0x00233408
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				int num = this.test_existe_equipement();
				bool flag2 = num == 1;
				if (flag2)
				{
					int num2 = this.test_ordre_vrai();
					int num3 = Convert.ToInt32(this.guna2NumericUpDown1.Value);
					bool flag3 = num3 <= num2;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update equipement set code = @i1, designation = @i2, ordre = @i3 where id = @i4";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = this.label6.Text;
						sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = num3;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.update_ordre(this.a_ord, modifier_equipement.id_prn, num3, Convert.ToInt32(this.label6.Text));
						Arbre_Equipement.mise_jour_modifier(num3, Arbre_Equipement.parent_modifier, Convert.ToInt32(this.label6.Text), this.TextBox1.Text, this.TextBox2.Text, this.a_ord, modifier_equipement.id_prn, Arbre_Equipement.nd_modifier);
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

		// Token: 0x06000E99 RID: 3737 RVA: 0x0023540C File Offset: 0x0023360C
		private int test_existe_equipement()
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

		// Token: 0x06000E9A RID: 3738 RVA: 0x002354D8 File Offset: 0x002336D8
		private int test_ordre_vrai()
		{
			bd bd = new bd();
			string cmdText = "select id_parent from equipement where id= @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			int result = 1;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select max(ordre) from equipement where id_parent = @i and deleted = @d";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					bool flag3 = Convert.ToString(dataTable2.Rows[0].ItemArray[0]) != "";
					if (flag3)
					{
						result = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]) + 1;
					}
				}
			}
			return result;
		}

		// Token: 0x0400124E RID: 4686
		private int a_ord;

		// Token: 0x0400124F RID: 4687
		private static int id_prn;
	}
}
