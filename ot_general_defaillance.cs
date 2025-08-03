using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000BC RID: 188
	public partial class ot_general_defaillance : Form
	{
		// Token: 0x06000875 RID: 2165 RVA: 0x00168F9F File Offset: 0x0016719F
		public ot_general_defaillance()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00168FBE File Offset: 0x001671BE
		private void ot_general_defaillance_Load(object sender, EventArgs e)
		{
			this.id_def = 0;
			this.select_defaillance();
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00168FD0 File Offset: 0x001671D0
		private void select_defaillance()
		{
			this.radDropDownList1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select code, anomalie, parametre_anomalie.id from ordre_travail inner join parametre_anomalie on ordre_travail.id_defaillance = parametre_anomalie.id where ordre_travail.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			int num = 0;
			int num2 = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList1.Items.Add(dataTable.Rows[0].ItemArray[0].ToString());
				this.radDropDownList1.Items[0].Tag = dataTable.Rows[0].ItemArray[1].ToString();
				num++;
				num2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]);
				this.id_def = num2;
			}
			string cmdText2 = "select code, anomalie from parametre_anomalie where deleted = @d and id <> @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = num2;
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable2.Rows[i].ItemArray[0].ToString());
					this.radDropDownList1.Items[i + num].Tag = dataTable2.Rows[i].ItemArray[1].ToString();
				}
			}
			bool flag3 = num == 1;
			if (flag3)
			{
				this.radDropDownList1.Items[0].Selected = true;
			}
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00169214 File Offset: 0x00167414
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.TextBox1.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00169260 File Offset: 0x00167460
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from parametre_anomalie where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "update ordre_travail set id_defaillance = @v where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					bool flag3 = this.id_def != Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
					if (flag3)
					{
						string cmdText3 = "delete ot_diagnostic_def where id_ot = @i2";
						string cmdText4 = "delete ot_diagnostic_m where id_ot = @i2";
						string cmdText5 = "delete ot_diagnostic_detection where id_ot = @i2";
						string cmdText6 = "delete ot_diagnostic_operation where id_ot = @i2";
						string cmdText7 = "delete ot_diagnostic_symptome where id_ot = @i2";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand5.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand6.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand7.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						sqlCommand4.ExecuteNonQuery();
						sqlCommand5.ExecuteNonQuery();
						sqlCommand6.ExecuteNonQuery();
						sqlCommand7.ExecuteNonQuery();
						bd.cnn.Close();
					}
					MessageBox.Show("Modification avec succés");
				}
			}
			else
			{
				MessageBox.Show("Erreur :Veuillez choisir la défaillance", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000B85 RID: 2949
		private int id_def = 0;
	}
}
