using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000140 RID: 320
	public partial class menu_commande : Form
	{
		// Token: 0x06000E51 RID: 3665 RVA: 0x0022EA6C File Offset: 0x0022CC6C
		public menu_commande()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x0022EA84 File Offset: 0x0022CC84
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			creer_commande creer_commande = new creer_commande();
			creer_commande.TopLevel = false;
			commande.panel3.Controls.Clear();
			commande.panel3.Controls.Add(creer_commande);
			creer_commande.Show();
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x0022EB94 File Offset: 0x0022CD94
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			commande_attente commande_attente = new commande_attente();
			commande_attente.TopLevel = false;
			commande.panel3.Controls.Clear();
			commande.panel3.Controls.Add(commande_attente);
			commande_attente.Show();
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x0022ECA4 File Offset: 0x0022CEA4
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.BackColor = Color.White;
			this.button3.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			commande_encour commande_encour = new commande_encour();
			commande_encour.TopLevel = false;
			commande.panel3.Controls.Clear();
			commande.panel3.Controls.Add(commande_encour);
			commande_encour.Show();
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x0022EDB4 File Offset: 0x0022CFB4
		private void button6_Click(object sender, EventArgs e)
		{
			this.button6.BackColor = Color.White;
			this.button6.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			commande_annule commande_annule = new commande_annule();
			commande_annule.TopLevel = false;
			commande.panel3.Controls.Clear();
			commande.panel3.Controls.Add(commande_annule);
			commande_annule.Show();
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x0022EEC4 File Offset: 0x0022D0C4
		private void button7_Click(object sender, EventArgs e)
		{
			this.button7.BackColor = Color.White;
			this.button7.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			commande_cloture commande_cloture = new commande_cloture();
			commande_cloture.TopLevel = false;
			commande.panel3.Controls.Clear();
			commande.panel3.Controls.Add(commande_cloture);
			commande_cloture.Show();
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x0022EFD4 File Offset: 0x0022D1D4
		private void menu_commande_Load(object sender, EventArgs e)
		{
			if (UserSession.stat_user != "Responsable Achat")
			{
				this.button1.Visible = false;
			}
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x0022F004 File Offset: 0x0022D204
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.BackColor = Color.White;
			this.button4.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			commande_sous_traitant commande_sous_traitant = new commande_sous_traitant();
			commande_sous_traitant.TopLevel = false;
			commande.panel3.Controls.Clear();
			commande.panel3.Controls.Add(commande_sous_traitant);
			commande_sous_traitant.Show();
		}
	}
}
