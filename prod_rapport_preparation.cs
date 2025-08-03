using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x0200011C RID: 284
	public partial class prod_rapport_preparation : Form
	{
		// Token: 0x06000C83 RID: 3203 RVA: 0x001E70AE File Offset: 0x001E52AE
		public prod_rapport_preparation()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x001E70C8 File Offset: 0x001E52C8
		private void prod_rapport_preparation_Load(object sender, EventArgs e)
		{
			this.label1.Text = "Date : " + prod_rapport.date_rpr;
			this.label2.Text = "Poste : " + prod_rapport.poste_rpr;
			this.select_unite();
			this.load_button(sender, e);
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x001E711C File Offset: 0x001E531C
		private void select_unite()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select distinct id_unite, equipement.designation from prod_rapport_prep_qualite inner join equipement on prod_rapport_prep_qualite.id_unite = equipement.id where id_rapport = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport.id_rpr;
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

		// Token: 0x06000C86 RID: 3206 RVA: 0x001E7228 File Offset: 0x001E5428
		private void button_couleur(Button b)
		{
			foreach (object obj in this.panel4.Controls)
			{
				Button button = (Button)obj;
				bool flag = button == b;
				if (flag)
				{
					button.ForeColor = Color.Firebrick;
					button.BackColor = Color.White;
				}
				else
				{
					button.BackColor = Color.Firebrick;
					button.ForeColor = Color.White;
				}
			}
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x001E72C4 File Offset: 0x001E54C4
		private void load_button(object sender, EventArgs e)
		{
			prod_rapport_preparation.id_unite = 0;
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				prod_rapport_preparation.id_unite = Convert.ToInt32(this.radDropDownList1.SelectedItem.Tag);
			}
			prod_rapport_anomalie.id_unite = prod_rapport_preparation.id_unite;
			bool flag2 = prod_rapport_preparation.p == 1;
			if (flag2)
			{
				this.button1_Click(sender, e);
			}
			bool flag3 = prod_rapport_preparation.p == 2;
			if (flag3)
			{
				this.button2_Click(sender, e);
			}
			bool flag4 = prod_rapport_preparation.p == 3;
			if (flag4)
			{
				this.button3_Click(sender, e);
			}
			bool flag5 = prod_rapport_preparation.p == 5;
			if (flag5)
			{
				this.button5_Click(sender, e);
			}
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x001E7378 File Offset: 0x001E5578
		private void button2_Click(object sender, EventArgs e)
		{
			prod_rapport_preparation.p = 2;
			this.button_couleur(this.button2);
			prod_rapport_detail prod_rapport_detail = new prod_rapport_detail();
			prod_rapport_detail.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_detail);
			prod_rapport_detail.Show();
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x001E73D4 File Offset: 0x001E55D4
		private void button1_Click(object sender, EventArgs e)
		{
			prod_rapport_preparation.p = 1;
			this.button_couleur(this.button1);
			prod_rapport_as prod_rapport_as = new prod_rapport_as();
			prod_rapport_as.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_as);
			prod_rapport_as.Show();
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x001E7430 File Offset: 0x001E5630
		private void button3_Click(object sender, EventArgs e)
		{
			prod_rapport_preparation.p = 3;
			this.button_couleur(this.button3);
			prod_rapport_prep_general prod_rapport_prep_general = new prod_rapport_prep_general();
			prod_rapport_prep_general.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_prep_general);
			prod_rapport_prep_general.Show();
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x001E7489 File Offset: 0x001E5689
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.load_button(sender, e);
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x001E7498 File Offset: 0x001E5698
		private void button5_Click(object sender, EventArgs e)
		{
			prod_rapport_preparation.p = 5;
			this.button_couleur(this.button5);
			prod_rapport_anomalie prod_rapport_anomalie = new prod_rapport_anomalie();
			prod_rapport_anomalie.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_anomalie);
			prod_rapport_anomalie.Show();
		}

		// Token: 0x04001024 RID: 4132
		public static int p = 1;

		// Token: 0x04001025 RID: 4133
		public static int id_unite = 0;
	}
}
