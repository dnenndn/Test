using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000068 RID: 104
	public partial class Devis_sous_traitant : Form
	{
		// Token: 0x060004F4 RID: 1268 RVA: 0x000D5A64 File Offset: 0x000D3C64
		public Devis_sous_traitant()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000D5A7C File Offset: 0x000D3C7C
		private void Devis_sous_traitant_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x000D5A88 File Offset: 0x000D3C88
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x000D5AC4 File Offset: 0x000D3CC4
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			creer_devis_st creer_devis_st = new creer_devis_st();
			creer_devis_st.TopLevel = false;
			this.panel1.Controls.Add(creer_devis_st);
			creer_devis_st.Show();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x000D5B50 File Offset: 0x000D3D50
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			historique_devis_st historique_devis_st = new historique_devis_st();
			historique_devis_st.TopLevel = false;
			this.panel1.Controls.Add(historique_devis_st);
			historique_devis_st.Show();
		}
	}
}
