using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000074 RID: 116
	public partial class etat_stock_st : Form
	{
		// Token: 0x06000566 RID: 1382 RVA: 0x000E329D File Offset: 0x000E149D
		public etat_stock_st()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x000E32B8 File Offset: 0x000E14B8
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x000E32F4 File Offset: 0x000E14F4
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			stock_magasin_st stock_magasin_st = new stock_magasin_st();
			stock_magasin_st.TopLevel = false;
			this.panel1.Controls.Add(stock_magasin_st);
			stock_magasin_st.Show();
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x000E33A0 File Offset: 0x000E15A0
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			stock_usine_st stock_usine_st = new stock_usine_st();
			stock_usine_st.TopLevel = false;
			this.panel1.Controls.Add(stock_usine_st);
			stock_usine_st.Show();
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x000E344C File Offset: 0x000E164C
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			stock_reparation_st stock_reparation_st = new stock_reparation_st();
			stock_reparation_st.TopLevel = false;
			this.panel1.Controls.Add(stock_reparation_st);
			stock_reparation_st.Show();
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x000E34F8 File Offset: 0x000E16F8
		private void etat_stock_st_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}
	}
}
