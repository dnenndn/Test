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
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x02000007 RID: 7
	public partial class action_ajouter : Form
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000A339 File Offset: 0x00008539
		public action_ajouter()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000A354 File Offset: 0x00008554
		private void afficher_panel()
		{
			bool isChecked = this.radRadioButton3.IsChecked;
			if (isChecked)
			{
				this.panel2.Show();
				this.panel3.Hide();
				this.panel2.Location = new Point(16, 168);
				this.panel3.Location = new Point(16, 275);
			}
			else
			{
				this.panel2.Hide();
				this.panel3.Show();
				this.panel2.Location = new Point(16, 275);
				this.panel3.Location = new Point(16, 168);
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000A407 File Offset: 0x00008607
		private void action_ajouter_Load(object sender, EventArgs e)
		{
			this.afficher_panel();
			this.select_defaillance();
			this.select_intervention();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000A420 File Offset: 0x00008620
		private void select_defaillance()
		{
			this.radDropDownList6.Items.Clear();
			string cmdText = "select code, anomalie from parametre_anomalie where deleted = @d order by code";
			bd bd = new bd();
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
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000A528 File Offset: 0x00008728
		private void select_intervention()
		{
			this.radDropDownList1.Items.Clear();
			string cmdText = "select code, intervention from parametre_intervention where deleted = @d order by code";
			bd bd = new bd();
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
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000A630 File Offset: 0x00008830
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				this.TextBox3.Text = this.radDropDownList6.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000A67A File Offset: 0x0000887A
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.afficher_panel();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000A684 File Offset: 0x00008884
		private void save_add_diagnostic()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & this.radDropDownList6.Text != "";
			if (flag)
			{
				string cmdText = "select id from operation_diagnostic where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "select id from parametre_anomalie where code = @v";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					int num = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
					string cmdText3 = "insert into operation_diagnostic (id_defaillance, code, designation, deleted) values (@i1, @i2, @i3, @i4)";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
					sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Ajout avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
				}
				else
				{
					MessageBox.Show("Erreur : Code d'opération déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000A8DC File Offset: 0x00008ADC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool isChecked = this.radRadioButton3.IsChecked;
			if (isChecked)
			{
				this.save_add_diagnostic();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000A904 File Offset: 0x00008B04
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				this.guna2TextBox1.Text = this.radDropDownList1.SelectedItem.Tag.ToString();
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000A950 File Offset: 0x00008B50
		private void save_add_maintenance()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & this.radDropDownList1.Text != "";
			if (flag)
			{
				string cmdText = "select id from operation_maintenance where code = @v";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "select id from parametre_intervention where code = @v";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					int num = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
					string value = "Test";
					bool isChecked = this.radRadioButton1.IsChecked;
					if (isChecked)
					{
						value = "Réparation";
					}
					string cmdText3 = "insert into operation_maintenance (id_intervention, code, designation, deleted, type) values (@i1, @i2, @i3, @i4, @i5)";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num;
					sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
					sqlCommand3.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
					bd.ouverture_bd(bd.cnn);
					sqlCommand3.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Ajout avec succés");
					this.TextBox1.Clear();
					this.TextBox2.Clear();
				}
				else
				{
					MessageBox.Show("Erreur : Code d'opération déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000ABE4 File Offset: 0x00008DE4
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.save_add_maintenance();
		}
	}
}
