using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x020000B3 RID: 179
	public partial class ot_diagnostic : Form
	{
		// Token: 0x06000813 RID: 2067 RVA: 0x0015E189 File Offset: 0x0015C389
		public ot_diagnostic()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0015E1A4 File Offset: 0x0015C3A4
		private void couleur_button(Button b)
		{
			foreach (object obj in this.panel4.Controls)
			{
				Control control = (Control)obj;
				bool flag = !control.Name.Contains("guna");
				if (flag)
				{
					bool flag2 = control.Name != b.Name;
					if (flag2)
					{
						control.BackColor = Color.WhiteSmoke;
						control.ForeColor = Color.Black;
					}
					else
					{
						control.BackColor = Color.White;
						control.ForeColor = Color.Firebrick;
					}
				}
			}
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0015E268 File Offset: 0x0015C468
		private void button1_Click(object sender, EventArgs e)
		{
			ot_diagnostic.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_diagnostic_saisie ot_diagnostic_saisie = new ot_diagnostic_saisie();
			ot_diagnostic_saisie.TopLevel = false;
			this.panel1.Controls.Add(ot_diagnostic_saisie);
			ot_diagnostic_saisie.Show();
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0015E2C4 File Offset: 0x0015C4C4
		private void ot_diagnostic_Load(object sender, EventArgs e)
		{
			bool flag = ot_diagnostic.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_diagnostic.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_diagnostic.p == 4;
			if (flag3)
			{
				this.button4_Click(sender, e);
			}
			bool flag4 = ot_diagnostic.p == 3;
			if (flag4)
			{
				this.button3_Click(sender, e);
			}
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0015E330 File Offset: 0x0015C530
		private void button2_Click(object sender, EventArgs e)
		{
			ot_diagnostic.p = 2;
			this.couleur_button(this.button2);
			this.panel1.Controls.Clear();
			ot_diagnostic_arbre ot_diagnostic_arbre = new ot_diagnostic_arbre();
			ot_diagnostic_arbre.TopLevel = false;
			this.panel1.Controls.Add(ot_diagnostic_arbre);
			ot_diagnostic_arbre.Show();
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0015E38C File Offset: 0x0015C58C
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			rapport_fiche_diagnostic rapport_fiche_diagnostic = new rapport_fiche_diagnostic();
			rapport_fiche_diagnostic.Show();
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0015E3A8 File Offset: 0x0015C5A8
		private void button4_Click(object sender, EventArgs e)
		{
			ot_diagnostic.p = 4;
			this.couleur_button(this.button4);
			this.panel1.Controls.Clear();
			ot_diagnostic_final ot_diagnostic_final = new ot_diagnostic_final();
			ot_diagnostic_final.TopLevel = false;
			this.panel1.Controls.Add(ot_diagnostic_final);
			ot_diagnostic_final.Show();
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0015E404 File Offset: 0x0015C604
		private void button3_Click(object sender, EventArgs e)
		{
			ot_diagnostic.p = 3;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_diagnostic_ishikawa ot_diagnostic_ishikawa = new ot_diagnostic_ishikawa();
			ot_diagnostic_ishikawa.TopLevel = false;
			this.panel1.Controls.Add(ot_diagnostic_ishikawa);
			ot_diagnostic_ishikawa.Show();
		}

		// Token: 0x04000B16 RID: 2838
		private static int p = 1;
	}
}
