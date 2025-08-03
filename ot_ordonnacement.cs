using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000C7 RID: 199
	public partial class ot_ordonnacement : Form
	{
		// Token: 0x060008E2 RID: 2274 RVA: 0x00177B54 File Offset: 0x00175D54
		public ot_ordonnacement()
		{
			this.InitializeComponent();
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00177B6C File Offset: 0x00175D6C
		private void ot_ordonnacement_Load(object sender, EventArgs e)
		{
			this.affichage_menu();
			bool flag = ot_ordonnacement.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_ordonnacement.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_ordonnacement.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00177BC8 File Offset: 0x00175DC8
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

		// Token: 0x060008E5 RID: 2277 RVA: 0x00177C70 File Offset: 0x00175E70
		private void button1_Click(object sender, EventArgs e)
		{
			ot_ordonnacement.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_ordonnancement_employe ot_ordonnancement_employe = new ot_ordonnancement_employe();
			ot_ordonnancement_employe.TopLevel = false;
			this.panel1.Controls.Add(ot_ordonnancement_employe);
			ot_ordonnancement_employe.Show();
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00177CCC File Offset: 0x00175ECC
		private void button2_Click(object sender, EventArgs e)
		{
			ot_ordonnacement.p = 2;
			this.couleur_button(this.button2);
			this.panel1.Controls.Clear();
			ot_ordonnancement_intervention ot_ordonnancement_intervention = new ot_ordonnancement_intervention();
			ot_ordonnancement_intervention.TopLevel = false;
			this.panel1.Controls.Add(ot_ordonnancement_intervention);
			ot_ordonnancement_intervention.Show();
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00177D28 File Offset: 0x00175F28
		private void button3_Click(object sender, EventArgs e)
		{
			ot_ordonnacement.p = 3;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_ordonnacement_gantt ot_ordonnacement_gantt = new ot_ordonnacement_gantt();
			ot_ordonnacement_gantt.TopLevel = false;
			this.panel1.Controls.Add(ot_ordonnacement_gantt);
			ot_ordonnacement_gantt.Show();
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00177D84 File Offset: 0x00175F84
		private void affichage_menu()
		{
			bool flag = ot_liste.type_ot_tr.Contains("Préventive");
			if (flag)
			{
				this.button2.Visible = false;
				bool flag2 = ot_ordonnacement.p == 2;
				if (flag2)
				{
					ot_ordonnacement.p = 1;
				}
			}
		}

		// Token: 0x04000C08 RID: 3080
		private static int p = 1;
	}
}
