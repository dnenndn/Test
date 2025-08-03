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
	// Token: 0x02000118 RID: 280
	public partial class prod_rapport_four : Form
	{
		// Token: 0x06000C64 RID: 3172 RVA: 0x001E38D1 File Offset: 0x001E1AD1
		public prod_rapport_four()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x001E38EC File Offset: 0x001E1AEC
		private void prod_rapport_four_Load(object sender, EventArgs e)
		{
			this.label1.Text = "Date : " + prod_rapport.date_rpr;
			this.label2.Text = "Poste : " + prod_rapport.poste_rpr;
			this.select_unite();
			this.load_button(sender, e);
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x001E3940 File Offset: 0x001E1B40
		private void select_unite()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select distinct id_unite, equipement.designation from prod_rapport_four_entre inner join equipement on prod_rapport_four_entre.id_unite = equipement.id where id_rapport = @i";
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

		// Token: 0x06000C67 RID: 3175 RVA: 0x001E3A4C File Offset: 0x001E1C4C
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

		// Token: 0x06000C68 RID: 3176 RVA: 0x001E3AE8 File Offset: 0x001E1CE8
		private void load_button(object sender, EventArgs e)
		{
			prod_rapport_four.id_unite = 0;
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				prod_rapport_four.id_unite = Convert.ToInt32(this.radDropDownList1.SelectedItem.Tag);
			}
			prod_rapport_anomalie.id_unite = prod_rapport_four.id_unite;
			bool flag2 = prod_rapport_four.p == 1;
			if (flag2)
			{
				this.button1_Click(sender, e);
			}
			bool flag3 = prod_rapport_four.p == 2;
			if (flag3)
			{
				this.button2_Click(sender, e);
			}
			bool flag4 = prod_rapport_four.p == 3;
			if (flag4)
			{
				this.button3_Click(sender, e);
			}
			bool flag5 = prod_rapport_four.p == 5;
			if (flag5)
			{
				this.button5_Click(sender, e);
			}
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x001E3B9C File Offset: 0x001E1D9C
		private void button1_Click(object sender, EventArgs e)
		{
			prod_rapport_four.p = 1;
			this.button_couleur(this.button1);
			prod_rapport_fabrication_entre prod_rapport_fabrication_entre = new prod_rapport_fabrication_entre();
			prod_rapport_fabrication_entre.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_fabrication_entre);
			prod_rapport_fabrication_entre.Show();
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x001E3BF5 File Offset: 0x001E1DF5
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.load_button(sender, e);
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x001E3C04 File Offset: 0x001E1E04
		private void button2_Click(object sender, EventArgs e)
		{
			prod_rapport_four.p = 2;
			this.button_couleur(this.button2);
			prod_rapport_four_sortie prod_rapport_four_sortie = new prod_rapport_four_sortie();
			prod_rapport_four_sortie.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_four_sortie);
			prod_rapport_four_sortie.Show();
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x001E3C60 File Offset: 0x001E1E60
		private void button3_Click(object sender, EventArgs e)
		{
			prod_rapport_four.p = 3;
			this.button_couleur(this.button3);
			prod_rapport_four_champ prod_rapport_four_champ = new prod_rapport_four_champ();
			prod_rapport_four_champ.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_four_champ);
			prod_rapport_four_champ.Show();
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x001E3CBC File Offset: 0x001E1EBC
		private void button5_Click(object sender, EventArgs e)
		{
			prod_rapport_four.p = 5;
			this.button_couleur(this.button5);
			prod_rapport_anomalie prod_rapport_anomalie = new prod_rapport_anomalie();
			prod_rapport_anomalie.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_anomalie);
			prod_rapport_anomalie.Show();
		}

		// Token: 0x04000FFF RID: 4095
		public static int p = 1;

		// Token: 0x04001000 RID: 4096
		public static int id_unite = 0;
	}
}
