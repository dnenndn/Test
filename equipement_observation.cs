using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x0200012F RID: 303
	public partial class equipement_observation : Form
	{
		// Token: 0x06000D58 RID: 3416 RVA: 0x00207507 File Offset: 0x00205707
		public equipement_observation()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x00207520 File Offset: 0x00205720
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select id  from equipement_observation where id_equipement = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count == 0;
			string cmdText2;
			if (flag)
			{
				cmdText2 = "insert into equipement_observation(id_equipement, observation) values (@i1, @i2)";
			}
			else
			{
				cmdText2 = "update equipement_observation set observation = @i2 where id_equipement = @i1";
			}
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.guna2TextBox9.Text;
			bd.ouverture_bd(bd.cnn);
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			MessageBox.Show("Modification avec succès");
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x00207630 File Offset: 0x00205830
		private void select_equipement()
		{
			bd bd = new bd();
			string cmdText = "select observation from equipement_observation where id_equipement = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.guna2TextBox9.Text = dataTable.Rows[0].ItemArray[0].ToString();
			}
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x002076CB File Offset: 0x002058CB
		private void equipement_observation_Load(object sender, EventArgs e)
		{
			this.select_equipement();
		}
	}
}
