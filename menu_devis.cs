using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000142 RID: 322
	public partial class menu_devis : Form
	{
		// Token: 0x06000E66 RID: 3686 RVA: 0x00230A20 File Offset: 0x0022EC20
		public menu_devis()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00230A38 File Offset: 0x0022EC38
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			créer_dop créer_dop = new créer_dop();
			créer_dop.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(créer_dop);
			créer_dop.Show();
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x00230B6C File Offset: 0x0022ED6C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			liste_dop liste_dop = new liste_dop();
			liste_dop.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(liste_dop);
			liste_dop.Show();
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00230CA0 File Offset: 0x0022EEA0
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.BackColor = Color.White;
			this.button5.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			dop_annule dop_annule = new dop_annule();
			dop_annule.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(dop_annule);
			dop_annule.Show();
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00230DD4 File Offset: 0x0022EFD4
		private void button7_Click(object sender, EventArgs e)
		{
			this.button7.BackColor = Color.White;
			this.button7.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			historique_dop historique_dop = new historique_dop();
			historique_dop.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(historique_dop);
			historique_dop.Show();
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00230F08 File Offset: 0x0022F108
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.BackColor = Color.White;
			this.button4.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			historique_tableau_comparatif historique_tableau_comparatif = new historique_tableau_comparatif();
			historique_tableau_comparatif.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(historique_tableau_comparatif);
			historique_tableau_comparatif.Show();
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x0023103C File Offset: 0x0022F23C
		private void button6_Click(object sender, EventArgs e)
		{
			this.button6.BackColor = Color.White;
			this.button6.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			tableau_comparatif tableau_comparatif = new tableau_comparatif();
			tableau_comparatif.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(tableau_comparatif);
			tableau_comparatif.Show();
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x00231170 File Offset: 0x0022F370
		private void menu_devis_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user != "Responsable Achat";
			if (flag)
			{
				this.button1.Visible = false;
			}
			bool flag2 = page_loginn.stat_user == "Administrateur";
			if (flag2)
			{
				this.button2.Visible = false;
				this.button6.Visible = false;
				this.button7.BackColor = Color.White;
				this.button7.ForeColor = Color.Firebrick;
			}
			bool flag3 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Administrateur";
			if (flag3)
			{
				this.button2.BackColor = Color.White;
				this.button2.ForeColor = Color.Firebrick;
			}
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00231238 File Offset: 0x0022F438
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.BackColor = Color.White;
			this.button3.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			Devis_sous_traitant devis_sous_traitant = new Devis_sous_traitant();
			devis_sous_traitant.TopLevel = false;
			devis.panel3.Controls.Clear();
			devis.panel3.Controls.Add(devis_sous_traitant);
			devis_sous_traitant.Show();
		}
	}
}
