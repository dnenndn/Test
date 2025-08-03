using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;

namespace GMAO
{
	// Token: 0x020000B8 RID: 184
	public partial class ot_general : Form
	{
		// Token: 0x0600084E RID: 2126 RVA: 0x0016607F File Offset: 0x0016427F
		public ot_general()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00166098 File Offset: 0x00164298
		private void ot_general_Load(object sender, EventArgs e)
		{
			this.affichage_menu();
			bool flag = ot_general.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_general.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_general.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
			bool flag4 = ot_general.p == 6;
			if (flag4)
			{
				this.button6_Click(sender, e);
			}
			bool flag5 = ot_general.p == 4;
			if (flag5)
			{
				this.button4_Click(sender, e);
			}
			bool flag6 = ot_general.p == 5;
			if (flag6)
			{
				this.button5_Click(sender, e);
			}
			bool flag7 = ot_general.p == 7;
			if (flag7)
			{
				this.button7_Click(sender, e);
			}
			bool flag8 = ot_general.p == 8;
			if (flag8)
			{
				this.button8_Click(sender, e);
			}
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00166170 File Offset: 0x00164370
		private void couleur_button(Button b)
		{
			foreach (object obj in this.panel4.Controls)
			{
				Button button = (Button)obj;
				bool flag = button.Name != b.Name;
				if (flag)
				{
					button.BackColor = Color.WhiteSmoke;
					button.ForeColor = Color.Black;
				}
				else
				{
					button.BackColor = Color.White;
					button.ForeColor = Color.Firebrick;
				}
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00166218 File Offset: 0x00164418
		private void button1_Click(object sender, EventArgs e)
		{
			ot_general.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_general_detail ot_general_detail = new ot_general_detail();
			ot_general_detail.TopLevel = false;
			this.panel1.Controls.Add(ot_general_detail);
			ot_general_detail.Show();
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00166274 File Offset: 0x00164474
		private void button2_Click(object sender, EventArgs e)
		{
			ot_general.p = 2;
			this.couleur_button(this.button2);
			this.panel1.Controls.Clear();
			ot_general_defaillance ot_general_defaillance = new ot_general_defaillance();
			ot_general_defaillance.TopLevel = false;
			this.panel1.Controls.Add(ot_general_defaillance);
			ot_general_defaillance.Show();
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x001662D0 File Offset: 0x001644D0
		private void affichage_menu()
		{
			bool flag = ot_liste.type_ot_tr.Contains("Préventive");
			if (flag)
			{
				this.button2.Visible = false;
				this.button4.Visible = false;
				bool flag2 = ot_general.p == 2 | ot_general.p == 4;
				if (flag2)
				{
					ot_general.p = 1;
				}
			}
			else
			{
				this.button5.Visible = false;
				bool flag3 = ot_general.p == 5;
				if (flag3)
				{
					ot_general.p = 1;
				}
			}
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00166350 File Offset: 0x00164550
		private void button3_Click(object sender, EventArgs e)
		{
			ot_general.p = 3;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_general_equipement ot_general_equipement = new ot_general_equipement();
			ot_general_equipement.TopLevel = false;
			this.panel1.Controls.Add(ot_general_equipement);
			ot_general_equipement.Show();
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x001663AC File Offset: 0x001645AC
		private void button6_Click(object sender, EventArgs e)
		{
			ot_general.p = 6;
			this.couleur_button(this.button6);
			this.panel1.Controls.Clear();
			ot_general_commentaire ot_general_commentaire = new ot_general_commentaire();
			ot_general_commentaire.TopLevel = false;
			this.panel1.Controls.Add(ot_general_commentaire);
			ot_general_commentaire.Show();
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00166408 File Offset: 0x00164608
		private void button4_Click(object sender, EventArgs e)
		{
			ot_general.p = 4;
			this.couleur_button(this.button4);
			this.panel1.Controls.Clear();
			ot_general_intervention ot_general_intervention = new ot_general_intervention();
			ot_general_intervention.TopLevel = false;
			this.panel1.Controls.Add(ot_general_intervention);
			ot_general_intervention.Show();
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00166464 File Offset: 0x00164664
		private void button5_Click(object sender, EventArgs e)
		{
			ot_general.p = 5;
			this.couleur_button(this.button5);
			this.panel1.Controls.Clear();
			ot_general_gamme ot_general_gamme = new ot_general_gamme();
			ot_general_gamme.TopLevel = false;
			this.panel1.Controls.Add(ot_general_gamme);
			ot_general_gamme.Show();
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x001664C0 File Offset: 0x001646C0
		private void button7_Click(object sender, EventArgs e)
		{
			ot_general.p = 7;
			this.couleur_button(this.button7);
			this.panel1.Controls.Clear();
			ot_general_cause ot_general_cause = new ot_general_cause();
			ot_general_cause.TopLevel = false;
			this.panel1.Controls.Add(ot_general_cause);
			ot_general_cause.Show();
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0016651C File Offset: 0x0016471C
		private void button8_Click(object sender, EventArgs e)
		{
			ot_general.p = 8;
			this.couleur_button(this.button8);
			this.panel1.Controls.Clear();
			ot_general_bsm ot_general_bsm = new ot_general_bsm();
			ot_general_bsm.TopLevel = false;
			this.panel1.Controls.Add(ot_general_bsm);
			ot_general_bsm.Show();
		}

		// Token: 0x04000B68 RID: 2920
		private static int p = 1;
	}
}
