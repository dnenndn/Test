using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000092 RID: 146
	public partial class livraison_sous_traitant : Form
	{
		// Token: 0x060006D5 RID: 1749 RVA: 0x0012B1B3 File Offset: 0x001293B3
		public livraison_sous_traitant()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0012B1CC File Offset: 0x001293CC
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0012B208 File Offset: 0x00129408
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			creer_bl_st creer_bl_st = new creer_bl_st();
			creer_bl_st.TopLevel = false;
			this.panel1.Controls.Add(creer_bl_st);
			creer_bl_st.Show();
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0012B2B4 File Offset: 0x001294B4
		private void livraison_sous_traitant_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0012B2C0 File Offset: 0x001294C0
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			bl_non_facture_st bl_non_facture_st = new bl_non_facture_st();
			bl_non_facture_st.TopLevel = false;
			this.panel1.Controls.Add(bl_non_facture_st);
			bl_non_facture_st.Show();
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0012B36C File Offset: 0x0012956C
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			bl_facture_st bl_facture_st = new bl_facture_st();
			bl_facture_st.TopLevel = false;
			this.panel1.Controls.Add(bl_facture_st);
			bl_facture_st.Show();
		}
	}
}
