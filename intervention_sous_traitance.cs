using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000081 RID: 129
	public partial class intervention_sous_traitance : Form
	{
		// Token: 0x06000614 RID: 1556 RVA: 0x000FD35C File Offset: 0x000FB55C
		public intervention_sous_traitance()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x000FD374 File Offset: 0x000FB574
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x000FD3B0 File Offset: 0x000FB5B0
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			DIST dist = new DIST();
			dist.TopLevel = false;
			this.panel3.Controls.Clear();
			this.panel3.Controls.Add(dist);
			dist.Show();
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x000FD47E File Offset: 0x000FB67E
		private void intervention_sous_traitance_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x000FD48C File Offset: 0x000FB68C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			dist_encours dist_encours = new dist_encours();
			dist_encours.TopLevel = false;
			this.panel3.Controls.Clear();
			this.panel3.Controls.Add(dist_encours);
			dist_encours.Show();
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x000FD55C File Offset: 0x000FB75C
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			dist_annule dist_annule = new dist_annule();
			dist_annule.TopLevel = false;
			this.panel3.Controls.Clear();
			this.panel3.Controls.Add(dist_annule);
			dist_annule.Show();
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x000FD62C File Offset: 0x000FB82C
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Firebrick;
			this.button4.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			dist_cloture dist_cloture = new dist_cloture();
			dist_cloture.TopLevel = false;
			this.panel3.Controls.Clear();
			this.panel3.Controls.Add(dist_cloture);
			dist_cloture.Show();
		}
	}
}
