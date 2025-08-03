using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000F1 RID: 241
	public partial class parametrage_intervention : Form
	{
		// Token: 0x06000A70 RID: 2672 RVA: 0x0019D55A File Offset: 0x0019B75A
		public parametrage_intervention()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0019D574 File Offset: 0x0019B774
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0019D5B0 File Offset: 0x0019B7B0
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			intervention intervention = new intervention();
			intervention.TopLevel = false;
			this.panel1.Controls.Add(intervention);
			intervention.Show();
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0019D63A File Offset: 0x0019B83A
		private void parametrage_intervention_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0019D648 File Offset: 0x0019B848
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			action action = new action();
			action.TopLevel = false;
			this.panel1.Controls.Add(action);
			action.Show();
		}
	}
}
