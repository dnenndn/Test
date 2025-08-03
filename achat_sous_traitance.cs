using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000005 RID: 5
	public partial class achat_sous_traitance : Form
	{
		// Token: 0x06000038 RID: 56 RVA: 0x000094BD File Offset: 0x000076BD
		public achat_sous_traitance()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000094D8 File Offset: 0x000076D8
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00009514 File Offset: 0x00007714
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
			this.panel3.Controls.Clear();
			Devis_sous_traitant devis_sous_traitant = new Devis_sous_traitant();
			devis_sous_traitant.TopLevel = false;
			this.panel3.Controls.Add(devis_sous_traitant);
			devis_sous_traitant.Show();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000095E2 File Offset: 0x000077E2
		private void achat_sous_traitance_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000095F0 File Offset: 0x000077F0
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
			this.panel3.Controls.Clear();
			commande_sous_traitant commande_sous_traitant = new commande_sous_traitant();
			commande_sous_traitant.TopLevel = false;
			this.panel3.Controls.Add(commande_sous_traitant);
			commande_sous_traitant.Show();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000096C0 File Offset: 0x000078C0
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
			this.panel3.Controls.Clear();
			livraison_sous_traitant livraison_sous_traitant = new livraison_sous_traitant();
			livraison_sous_traitant.TopLevel = false;
			this.panel3.Controls.Add(livraison_sous_traitant);
			livraison_sous_traitant.Show();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00009790 File Offset: 0x00007990
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
			this.panel3.Controls.Clear();
			facture_st facture_st = new facture_st();
			facture_st.TopLevel = false;
			this.panel3.Controls.Add(facture_st);
			facture_st.Show();
		}
	}
}
