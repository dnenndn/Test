using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200011B RID: 283
	public partial class prod_rapport_fuel : Form
	{
		// Token: 0x06000C7D RID: 3197 RVA: 0x001E6415 File Offset: 0x001E4615
		public prod_rapport_fuel()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x001E642D File Offset: 0x001E462D
		private void prod_rapport_fuel_Load(object sender, EventArgs e)
		{
			this.label1.Text = "Date : " + prod_rapport.date_rpr;
			this.label2.Text = "Poste : " + prod_rapport.poste_rpr;
			this.select_fuel();
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x001E6470 File Offset: 0x001E4670
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			string cmdText = "delete prod_fuel where id_rapport = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport.id_rpr;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			bool flag = fonction.is_reel(this.radTextBox1.Text);
			if (flag)
			{
				string cmdText2 = "insert into prod_fuel (id_rapport, type_saisie, quantite) values (@i1, @i2, @i3)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.radTextBox1.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool flag2 = fonction.is_reel(this.radTextBox2.Text);
			if (flag2)
			{
				string cmdText3 = "insert into prod_fuel (id_rapport, type_saisie, quantite) values (@i1, @i2, @i3)";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
				sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = 2;
				sqlCommand3.Parameters.Add("@i3", SqlDbType.Real).Value = this.radTextBox2.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand3.ExecuteNonQuery();
				bd.cnn.Close();
			}
			bool flag3 = fonction.is_reel(this.radTextBox3.Text);
			if (flag3)
			{
				string cmdText4 = "insert into prod_fuel (id_rapport, type_saisie, quantite) values (@i1, @i2, @i3)";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
				sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = 3;
				sqlCommand4.Parameters.Add("@i3", SqlDbType.Real).Value = this.radTextBox3.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand4.ExecuteNonQuery();
				bd.cnn.Close();
			}
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x001E6710 File Offset: 0x001E4910
		private void select_fuel()
		{
			bd bd = new bd();
			string cmdText = "select quantite from prod_fuel where id_rapport = @i1 and type_saisie = @i2";
			string cmdText2 = "select quantite from prod_fuel where id_rapport = @i1 and type_saisie = @i2";
			string cmdText3 = "select quantite from prod_fuel where id_rapport = @i1 and type_saisie = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = 1;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = 2;
			sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = 3;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter2.Fill(dataTable2);
			sqlDataAdapter3.Fill(dataTable3);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radTextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				this.radTextBox2.Text = Convert.ToString(dataTable2.Rows[0].ItemArray[0]);
			}
			bool flag3 = dataTable3.Rows.Count != 0;
			if (flag3)
			{
				this.radTextBox3.Text = Convert.ToString(dataTable3.Rows[0].ItemArray[0]);
			}
		}
	}
}
