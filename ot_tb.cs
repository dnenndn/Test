using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000D9 RID: 217
	public partial class ot_tb : Form
	{
		// Token: 0x060009A3 RID: 2467 RVA: 0x0018919D File Offset: 0x0018739D
		public ot_tb()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x001891B8 File Offset: 0x001873B8
		private void button1_Click(object sender, EventArgs e)
		{
			ot_tb.p = 1;
			this.panel1.Controls.Clear();
			ot_tb_general ot_tb_general = new ot_tb_general();
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			ot_tb_general.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_general);
			ot_tb_general.Show();
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0018925C File Offset: 0x0018745C
		private void ot_tb_Load(object sender, EventArgs e)
		{
			bool flag = ot_tb.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_tb.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_tb.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
			bool flag4 = ot_tb.p == 4;
			if (flag4)
			{
				this.button4_Click(sender, e);
			}
			bool flag5 = ot_tb.p == 5;
			if (flag5)
			{
				this.button5_Click(sender, e);
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x001892E0 File Offset: 0x001874E0
		private void button2_Click(object sender, EventArgs e)
		{
			ot_tb.p = 2;
			this.panel1.Controls.Clear();
			ot_tb_kpi ot_tb_kpi = new ot_tb_kpi();
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			ot_tb_kpi.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_kpi);
			ot_tb_kpi.Show();
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x00189384 File Offset: 0x00187584
		private void button4_Click(object sender, EventArgs e)
		{
			ot_tb.p = 4;
			this.panel1.Controls.Clear();
			ot_tb_realisation ot_tb_realisation = new ot_tb_realisation();
			this.button4.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			ot_tb_realisation.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_realisation);
			ot_tb_realisation.Show();
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00189428 File Offset: 0x00187628
		private void button3_Click(object sender, EventArgs e)
		{
			ot_tb.p = 3;
			this.panel1.Controls.Clear();
			ot_tb_type_maintenance ot_tb_type_maintenance = new ot_tb_type_maintenance();
			this.button3.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			ot_tb_type_maintenance.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_type_maintenance);
			ot_tb_type_maintenance.Show();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x001894CC File Offset: 0x001876CC
		private void button5_Click(object sender, EventArgs e)
		{
			ot_tb.p = 5;
			this.panel1.Controls.Clear();
			ot_tb_cout ot_tb_cout = new ot_tb_cout();
			this.button3.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			ot_tb_cout.TopLevel = false;
			this.panel1.Controls.Add(ot_tb_cout);
			ot_tb_cout.Show();
		}

		// Token: 0x04000CA5 RID: 3237
		private static int p = 1;
	}
}
