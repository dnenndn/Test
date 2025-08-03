using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000079 RID: 121
	public partial class gamme_operatoire : Form
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x000EB542 File Offset: 0x000E9742
		public gamme_operatoire()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x000EB55C File Offset: 0x000E975C
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x000EB598 File Offset: 0x000E9798
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			Ajouter_Gamme_Opératoire ajouter_Gamme_Opératoire = new Ajouter_Gamme_Opératoire();
			ajouter_Gamme_Opératoire.TopLevel = false;
			this.panel1.Controls.Add(ajouter_Gamme_Opératoire);
			ajouter_Gamme_Opératoire.Show();
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x000EB688 File Offset: 0x000E9888
		private void gamme_operatoire_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x000EB694 File Offset: 0x000E9894
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			liste_gamme_operatoire liste_gamme_operatoire = new liste_gamme_operatoire();
			liste_gamme_operatoire.TopLevel = false;
			this.panel1.Controls.Add(liste_gamme_operatoire);
			liste_gamme_operatoire.Show();
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x000EB784 File Offset: 0x000E9984
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			preventive_systematique preventive_systematique = new preventive_systematique();
			preventive_systematique.TopLevel = false;
			this.panel1.Controls.Add(preventive_systematique);
			preventive_systematique.Show();
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x000EB874 File Offset: 0x000E9A74
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			preventive_syst_compteur preventive_syst_compteur = new preventive_syst_compteur();
			preventive_syst_compteur.TopLevel = false;
			this.panel1.Controls.Add(preventive_syst_compteur);
			preventive_syst_compteur.Show();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000EB964 File Offset: 0x000E9B64
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			preventive_conditionnelle preventive_conditionnelle = new preventive_conditionnelle();
			preventive_conditionnelle.TopLevel = false;
			this.panel1.Controls.Add(preventive_conditionnelle);
			preventive_conditionnelle.Show();
		}
	}
}
