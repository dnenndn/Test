using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000A9 RID: 169
	public partial class ot_bt : Form
	{
		// Token: 0x060007B8 RID: 1976 RVA: 0x00154A55 File Offset: 0x00152C55
		public ot_bt()
		{
			this.InitializeComponent();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00154A70 File Offset: 0x00152C70
		private void ot_bt_Load(object sender, EventArgs e)
		{
			bool flag = ot_bt.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_bt.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_bt.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
			bool flag4 = ot_bt.p == 4;
			if (flag4)
			{
				this.button4_Click(sender, e);
			}
			bool flag5 = ot_bt.p == 5;
			if (flag5)
			{
				this.button5_Click(sender, e);
			}
			bool flag6 = ot_bt.p == 7;
			if (flag6)
			{
				this.button7_Click(sender, e);
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00154B0C File Offset: 0x00152D0C
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

		// Token: 0x060007BB RID: 1979 RVA: 0x00154BB4 File Offset: 0x00152DB4
		private void button2_Click(object sender, EventArgs e)
		{
			ot_bt.p = 2;
			this.couleur_button(this.button2);
			this.panel1.Controls.Clear();
			ot_bt_bsm ot_bt_bsm = new ot_bt_bsm();
			ot_bt_bsm.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_bsm);
			ot_bt_bsm.Show();
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00154C10 File Offset: 0x00152E10
		private void button3_Click(object sender, EventArgs e)
		{
			ot_bt.p = 3;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_bt_outil ot_bt_outil = new ot_bt_outil();
			ot_bt_outil.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_outil);
			ot_bt_outil.Show();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00154C6C File Offset: 0x00152E6C
		private void button4_Click(object sender, EventArgs e)
		{
			ot_bt.p = 4;
			this.couleur_button(this.button4);
			this.panel1.Controls.Clear();
			ot_bt_st ot_bt_st = new ot_bt_st();
			ot_bt_st.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_st);
			ot_bt_st.Show();
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00154CC8 File Offset: 0x00152EC8
		private void button5_Click(object sender, EventArgs e)
		{
			ot_bt.p = 5;
			this.couleur_button(this.button5);
			this.panel1.Controls.Clear();
			ot_bt_projet ot_bt_projet = new ot_bt_projet();
			ot_bt_projet.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_projet);
			ot_bt_projet.Show();
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00154D24 File Offset: 0x00152F24
		private void button1_Click(object sender, EventArgs e)
		{
			ot_bt.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_bt_intervention ot_bt_intervention = new ot_bt_intervention();
			ot_bt_intervention.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_intervention);
			ot_bt_intervention.Show();
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00154D80 File Offset: 0x00152F80
		private void button7_Click(object sender, EventArgs e)
		{
			ot_bt.p = 7;
			this.couleur_button(this.button7);
			this.panel1.Controls.Clear();
			ot_bt_cout ot_bt_cout = new ot_bt_cout();
			ot_bt_cout.TopLevel = false;
			this.panel1.Controls.Add(ot_bt_cout);
			ot_bt_cout.Show();
		}

		// Token: 0x04000AB6 RID: 2742
		private static int p = 1;
	}
}
