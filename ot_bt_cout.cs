using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000AB RID: 171
	public partial class ot_bt_cout : Form
	{
		// Token: 0x060007CB RID: 1995 RVA: 0x0015601C File Offset: 0x0015421C
		public ot_bt_cout()
		{
			this.InitializeComponent();
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00156034 File Offset: 0x00154234
		private void button1_Click(object sender, EventArgs e)
		{
			ot_bt_cout.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_bt_cout_total ot_bt_cout_total = new ot_bt_cout_total();
			ot_bt_cout_total.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_cout_total);
			ot_bt_cout_total.Show();
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00156090 File Offset: 0x00154290
		private void ot_bt_cout_Load(object sender, EventArgs e)
		{
			bool flag = ot_bt_cout.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_bt_cout.p == 2;
			if (flag2)
			{
				this.button3_Click(sender, e);
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x001560CC File Offset: 0x001542CC
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

		// Token: 0x060007CF RID: 1999 RVA: 0x00156174 File Offset: 0x00154374
		private void button3_Click(object sender, EventArgs e)
		{
			ot_bt_cout.p = 2;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_bt_cout_mo ot_bt_cout_mo = new ot_bt_cout_mo();
			ot_bt_cout_mo.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_cout_mo);
			ot_bt_cout_mo.Show();
		}

		// Token: 0x04000AC4 RID: 2756
		private static int p = 1;
	}
}
