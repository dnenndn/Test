using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200010F RID: 271
	public partial class prod_rapport_anomalie : Form
	{
		// Token: 0x06000C1D RID: 3101 RVA: 0x001DB600 File Offset: 0x001D9800
		public prod_rapport_anomalie()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x001DB66C File Offset: 0x001D986C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 3;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete prod_rapport_anomalie where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_tableau();
					}
				}
			}
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x001DB74A File Offset: 0x001D994A
		private void prod_rapport_anomalie_Load(object sender, EventArgs e)
		{
			this.select_anomalie();
			this.select_tableau();
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x001DB75C File Offset: 0x001D995C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.TextBox1.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.TextBox1.Text) > 0;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "insert into prod_rapport_anomalie (id_rapport, id_unite, id_anomalie, duree) values (@v1, @v2, @v3, @v4)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = prod_rapport.id_rpr;
						sqlCommand.Parameters.Add("@v2", SqlDbType.Int).Value = prod_rapport_anomalie.id_unite;
						sqlCommand.Parameters.Add("@v3", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
						sqlCommand.Parameters.Add("@v4", SqlDbType.Int).Value = this.TextBox1.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.select_anomalie();
						this.select_tableau();
						this.TextBox1.Clear();
						MessageBox.Show("Ajout avec succés");
					}
					else
					{
						MessageBox.Show("Erreur : Vérifier", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x001DB900 File Offset: 0x001D9B00
		private void select_anomalie()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select prod_anomalie.id, anomalie from prod_anomalie where unite_production in (select unite_production from prod_equipement where id_equipement = @i)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport_anomalie.id_unite;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x001DBA0C File Offset: 0x001D9C0C
		private void select_tableau()
		{
			bd bd = new bd();
			this.radGridView1.Rows.Clear();
			string cmdText = "select prod_rapport_anomalie.id, prod_anomalie.anomalie, duree from prod_rapport_anomalie inner join prod_anomalie on prod_rapport_anomalie.id_anomalie = prod_anomalie.id where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_anomalie.id_unite;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x04000FC0 RID: 4032
		public static int id_unite;
	}
}
