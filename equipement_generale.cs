using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200012D RID: 301
	public partial class equipement_generale : Form
	{
		// Token: 0x06000D4B RID: 3403 RVA: 0x0020401B File Offset: 0x0020221B
		public equipement_generale()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00204034 File Offset: 0x00202234
		private void equipement_generale_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = this.radDateTimePicker1.MinDate.Date;
			this.radDateTimePicker2.Value = this.radDateTimePicker2.MinDate.Date;
			this.radDateTimePicker3.Value = this.radDateTimePicker3.MinDate.Date;
			this.radDateTimePicker4.Value = this.radDateTimePicker4.MinDate.Date;
			this.select_equipement();
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x002040C8 File Offset: 0x002022C8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select id  from equipement_generale where id_equipement = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count == 0;
			string cmdText2;
			if (flag)
			{
				cmdText2 = "insert into equipement_generale(id_equipement, reference, marque, n_serie, n_modele, n_contrat, n_immobilisation, fabricant, cout_achat, date_achat, date_mise_en_service, date_fin_garentie, date_fin_amortissement) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i12, @i13)";
			}
			else
			{
				cmdText2 = "update equipement_generale set reference = @i2, marque = @i3, n_serie = @i4, n_modele = @i5, n_contrat = @i6, n_immobilisation = @i7, fabricant = @i8, cout_achat = @i9, date_achat = @i10, date_mise_en_service = @i11, date_fin_garentie = @i12, date_fin_amortissement = @i13 where id_equipement = @i1";
			}
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
			sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
			sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.TextBox3.Text;
			sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.TextBox4.Text;
			sqlCommand2.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.TextBox5.Text;
			sqlCommand2.Parameters.Add("@i7", SqlDbType.VarChar).Value = this.TextBox6.Text;
			sqlCommand2.Parameters.Add("@i8", SqlDbType.VarChar).Value = this.TextBox7.Text;
			sqlCommand2.Parameters.Add("@i9", SqlDbType.VarChar).Value = this.TextBox8.Text;
			sqlCommand2.Parameters.Add("@i10", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand2.Parameters.Add("@i11", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			sqlCommand2.Parameters.Add("@i12", SqlDbType.Date).Value = this.radDateTimePicker4.Value;
			sqlCommand2.Parameters.Add("@i13", SqlDbType.Date).Value = this.radDateTimePicker3.Value;
			bd.ouverture_bd(bd.cnn);
			sqlCommand2.ExecuteNonQuery();
			bd.cnn.Close();
			MessageBox.Show("Modification avec succès");
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00204378 File Offset: 0x00202578
		private void select_equipement()
		{
			bd bd = new bd();
			string cmdText = "select * from equipement_generale where id_equipement = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[2].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[3].ToString();
				this.TextBox3.Text = dataTable.Rows[0].ItemArray[4].ToString();
				this.TextBox4.Text = dataTable.Rows[0].ItemArray[5].ToString();
				this.TextBox5.Text = dataTable.Rows[0].ItemArray[6].ToString();
				this.TextBox6.Text = dataTable.Rows[0].ItemArray[7].ToString();
				this.TextBox7.Text = dataTable.Rows[0].ItemArray[8].ToString();
				this.TextBox8.Text = dataTable.Rows[0].ItemArray[9].ToString();
				this.radDateTimePicker1.Text = dataTable.Rows[0].ItemArray[10].ToString();
				this.radDateTimePicker2.Text = dataTable.Rows[0].ItemArray[11].ToString();
				this.radDateTimePicker4.Text = dataTable.Rows[0].ItemArray[12].ToString();
				this.radDateTimePicker3.Text = dataTable.Rows[0].ItemArray[13].ToString();
			}
		}
	}
}
