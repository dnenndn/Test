using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000125 RID: 293
	public partial class stock_sous_traitance : Form
	{
		// Token: 0x06000CF4 RID: 3316 RVA: 0x001F706F File Offset: 0x001F526F
		public stock_sous_traitance()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x001F7088 File Offset: 0x001F5288
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x001F70C4 File Offset: 0x001F52C4
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			etat_stock_st etat_stock_st = new etat_stock_st();
			etat_stock_st.TopLevel = false;
			this.panel3.Controls.Add(etat_stock_st);
			etat_stock_st.Show();
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x001F7170 File Offset: 0x001F5370
		private void stock_sous_traitance_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x001F717C File Offset: 0x001F537C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			mvt_stock_st mvt_stock_st = new mvt_stock_st();
			mvt_stock_st.TopLevel = false;
			this.panel3.Controls.Add(mvt_stock_st);
			mvt_stock_st.Show();
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x001F7228 File Offset: 0x001F5428
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			liste_mp_st liste_mp_st = new liste_mp_st();
			liste_mp_st.TopLevel = false;
			this.panel3.Controls.Add(liste_mp_st);
			liste_mp_st.Show();
		}
	}
}
