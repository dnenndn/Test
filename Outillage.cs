using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000E4 RID: 228
	public partial class Outillage : Form
	{
		// Token: 0x060009F8 RID: 2552 RVA: 0x00190F11 File Offset: 0x0018F111
		public Outillage()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00190F2C File Offset: 0x0018F12C
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00190F68 File Offset: 0x0018F168
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			liste_outillage liste_outillage = new liste_outillage();
			liste_outillage.TopLevel = false;
			this.panel3.Controls.Add(liste_outillage);
			liste_outillage.Show();
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00191014 File Offset: 0x0018F214
		private void Outillage_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00191020 File Offset: 0x0018F220
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			outillage_parametre outillage_parametre = new outillage_parametre();
			outillage_parametre.TopLevel = false;
			this.panel3.Controls.Add(outillage_parametre);
			outillage_parametre.Show();
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x001910CC File Offset: 0x0018F2CC
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			Outillage_utilisation outillage_utilisation = new Outillage_utilisation();
			outillage_utilisation.TopLevel = false;
			this.panel3.Controls.Add(outillage_utilisation);
			outillage_utilisation.Show();
		}
	}
}
