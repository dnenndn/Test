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
	// Token: 0x02000112 RID: 274
	public partial class prod_rapport_fabrication : Form
	{
		// Token: 0x06000C31 RID: 3121 RVA: 0x001DD961 File Offset: 0x001DBB61
		public prod_rapport_fabrication()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x001DD97C File Offset: 0x001DBB7C
		private void prod_rapport_fabrication_Load(object sender, EventArgs e)
		{
			this.label1.Text = "Date : " + prod_rapport.date_rpr;
			this.label2.Text = "Poste : " + prod_rapport.poste_rpr;
			this.select_unite();
			this.load_button(sender, e);
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x001DD9D0 File Offset: 0x001DBBD0
		private void select_unite()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select distinct id_unite, equipement.designation from prod_rapport_fab_produit inner join equipement on prod_rapport_fab_produit.id_unite = equipement.id where id_rapport = @i";
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

		// Token: 0x06000C34 RID: 3124 RVA: 0x001DDADC File Offset: 0x001DBCDC
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

		// Token: 0x06000C35 RID: 3125 RVA: 0x001DDB78 File Offset: 0x001DBD78
		private void load_button(object sender, EventArgs e)
		{
			prod_rapport_fabrication.id_unite = 0;
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				prod_rapport_fabrication.id_unite = Convert.ToInt32(this.radDropDownList1.SelectedItem.Tag);
			}
			prod_rapport_anomalie.id_unite = prod_rapport_fabrication.id_unite;
			bool flag2 = prod_rapport_fabrication.p == 1;
			if (flag2)
			{
				this.button1_Click(sender, e);
			}
			bool flag3 = prod_rapport_fabrication.p == 2;
			if (flag3)
			{
				this.button2_Click(sender, e);
			}
			bool flag4 = prod_rapport_fabrication.p == 3;
			if (flag4)
			{
				this.button3_Click(sender, e);
			}
			bool flag5 = prod_rapport_fabrication.p == 4;
			if (flag5)
			{
				this.button4_Click(sender, e);
			}
			bool flag6 = prod_rapport_fabrication.p == 5;
			if (flag6)
			{
				this.button5_Click(sender, e);
			}
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x001DDC44 File Offset: 0x001DBE44
		private void button1_Click(object sender, EventArgs e)
		{
			prod_rapport_fabrication.p = 1;
			this.button_couleur(this.button1);
			prod_rapport_fabrication_cf prod_rapport_fabrication_cf = new prod_rapport_fabrication_cf();
			prod_rapport_fabrication_cf.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_fabrication_cf);
			prod_rapport_fabrication_cf.Show();
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x001DDC9D File Offset: 0x001DBE9D
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.load_button(sender, e);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x001DDCAC File Offset: 0x001DBEAC
		private void button2_Click(object sender, EventArgs e)
		{
			prod_rapport_fabrication.p = 2;
			this.button_couleur(this.button2);
			prod_rapport_fabrication_produit prod_rapport_fabrication_produit = new prod_rapport_fabrication_produit();
			prod_rapport_fabrication_produit.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_fabrication_produit);
			prod_rapport_fabrication_produit.Show();
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x001DDD08 File Offset: 0x001DBF08
		private void button3_Click(object sender, EventArgs e)
		{
			prod_rapport_fabrication.p = 3;
			this.button_couleur(this.button3);
			prod_rapport_fabrication_horaire prod_rapport_fabrication_horaire = new prod_rapport_fabrication_horaire();
			prod_rapport_fabrication_horaire.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_fabrication_horaire);
			prod_rapport_fabrication_horaire.Show();
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x001DDD64 File Offset: 0x001DBF64
		private void button4_Click(object sender, EventArgs e)
		{
			prod_rapport_fabrication.p = 4;
			this.button_couleur(this.button4);
			prod_rapport_fabrication_detail prod_rapport_fabrication_detail = new prod_rapport_fabrication_detail();
			prod_rapport_fabrication_detail.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_fabrication_detail);
			prod_rapport_fabrication_detail.Show();
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x001DDDC0 File Offset: 0x001DBFC0
		private void button5_Click(object sender, EventArgs e)
		{
			prod_rapport_fabrication.p = 5;
			this.button_couleur(this.button5);
			prod_rapport_anomalie prod_rapport_anomalie = new prod_rapport_anomalie();
			prod_rapport_anomalie.TopLevel = false;
			this.panel1.Controls.Clear();
			this.panel1.Controls.Add(prod_rapport_anomalie);
			prod_rapport_anomalie.Show();
		}

		// Token: 0x04000FD4 RID: 4052
		public static int p = 1;

		// Token: 0x04000FD5 RID: 4053
		public static int id_unite = 0;
	}
}
