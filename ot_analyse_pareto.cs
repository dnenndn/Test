using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000A8 RID: 168
	public partial class ot_analyse_pareto : Form
	{
		// Token: 0x060007B1 RID: 1969 RVA: 0x00154548 File Offset: 0x00152748
		public ot_analyse_pareto()
		{
			this.InitializeComponent();
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00154560 File Offset: 0x00152760
		private void button1_Click(object sender, EventArgs e)
		{
			ot_analyse_pareto.p = 1;
			this.panel1.Controls.Clear();
			ot_pareto_fiabilité ot_pareto_fiabilité = new ot_pareto_fiabilité();
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			ot_pareto_fiabilité.TopLevel = false;
			this.panel1.Controls.Add(ot_pareto_fiabilité);
			ot_pareto_fiabilité.Show();
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x001545D0 File Offset: 0x001527D0
		private void ot_analyse_pareto_Load(object sender, EventArgs e)
		{
			bool flag = ot_analyse_pareto.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_analyse_pareto.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0015460C File Offset: 0x0015280C
		private void button2_Click(object sender, EventArgs e)
		{
			ot_analyse_pareto.p = 2;
			this.panel1.Controls.Clear();
			ot_pareto_cout ot_pareto_cout = new ot_pareto_cout();
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.WhiteSmoke;
			ot_pareto_cout.TopLevel = false;
			this.panel1.Controls.Add(ot_pareto_cout);
			ot_pareto_cout.Show();
		}

		// Token: 0x04000AB0 RID: 2736
		private static int p = 1;
	}
}
