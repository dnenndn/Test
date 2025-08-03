using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000A5 RID: 165
	public partial class ot_analyse : Form
	{
		// Token: 0x0600079A RID: 1946 RVA: 0x00151218 File Offset: 0x0014F418
		public ot_analyse()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00151230 File Offset: 0x0014F430
		private void button1_Click(object sender, EventArgs e)
		{
			ot_analyse.p = 1;
			this.panel1.Controls.Clear();
			ot_analyse_pareto ot_analyse_pareto = new ot_analyse_pareto();
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			ot_analyse_pareto.TopLevel = false;
			this.panel1.Controls.Add(ot_analyse_pareto);
			ot_analyse_pareto.Show();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x001512B0 File Offset: 0x0014F4B0
		private void ot_analyse_Load(object sender, EventArgs e)
		{
			bool flag = ot_analyse.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_analyse.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_analyse.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00151304 File Offset: 0x0014F504
		private void button2_Click(object sender, EventArgs e)
		{
			ot_analyse.p = 2;
			this.panel1.Controls.Clear();
			ot_analyse_amdec ot_analyse_amdec = new ot_analyse_amdec();
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			ot_analyse_amdec.TopLevel = false;
			this.panel1.Controls.Add(ot_analyse_amdec);
			ot_analyse_amdec.Show();
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00151384 File Offset: 0x0014F584
		private void button3_Click(object sender, EventArgs e)
		{
			ot_analyse.p = 3;
			this.panel1.Controls.Clear();
			ot_analyse_ishikawa ot_analyse_ishikawa = new ot_analyse_ishikawa();
			this.button3.BackColor = Color.White;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button2.BackColor = Color.WhiteSmoke;
			ot_analyse_ishikawa.TopLevel = false;
			this.panel1.Controls.Add(ot_analyse_ishikawa);
			ot_analyse_ishikawa.Show();
		}

		// Token: 0x04000A7A RID: 2682
		private static int p = 1;
	}
}
