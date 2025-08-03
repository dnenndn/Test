using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000DB RID: 219
	public partial class ot_tb_cout : Form
	{
		// Token: 0x060009B0 RID: 2480 RVA: 0x00189D45 File Offset: 0x00187F45
		public ot_tb_cout()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00189D60 File Offset: 0x00187F60
		private void ot_tb_cout_Load(object sender, EventArgs e)
		{
			bool flag = ot_tb_cout.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_tb_cout.p == 2;
			if (flag2)
			{
				this.button3_Click(sender, e);
			}
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00189D9C File Offset: 0x00187F9C
		private void button1_Click(object sender, EventArgs e)
		{
			ot_tb_cout.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_tb_cout_total ot_tb_cout_total = new ot_tb_cout_total();
			ot_tb_cout_total.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_cout_total);
			ot_tb_cout_total.Show();
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00189DF8 File Offset: 0x00187FF8
		private void couleur_button(Button b)
		{
			foreach (object obj in this.panel4.Controls)
			{
				Button button = (Button)obj;
				bool flag = button.Name != b.Name;
				if (flag)
				{
					button.BackColor = Color.WhiteSmoke;
					button.ForeColor = Color.Black;
				}
				else
				{
					button.BackColor = Color.White;
					button.ForeColor = Color.Firebrick;
				}
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00189EA0 File Offset: 0x001880A0
		private void button3_Click(object sender, EventArgs e)
		{
			ot_tb_cout.p = 2;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_tb_cout_mo ot_tb_cout_mo = new ot_tb_cout_mo();
			ot_tb_cout_mo.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_cout_mo);
			ot_tb_cout_mo.Show();
		}

		// Token: 0x04000CAF RID: 3247
		private static int p = 1;
	}
}
