using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000CE RID: 206
	public partial class ot_ressources : Form
	{
		// Token: 0x06000941 RID: 2369 RVA: 0x0017F2CF File Offset: 0x0017D4CF
		public ot_ressources()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0017F2E8 File Offset: 0x0017D4E8
		private void ot_ressources_Load(object sender, EventArgs e)
		{
			bool flag = ot_ressources.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_ressources.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_ressources.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0017F33C File Offset: 0x0017D53C
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

		// Token: 0x06000944 RID: 2372 RVA: 0x0017F3E4 File Offset: 0x0017D5E4
		private void button1_Click(object sender, EventArgs e)
		{
			ot_ressources.p = 1;
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_ressources_pdr ot_ressources_pdr = new ot_ressources_pdr();
			ot_ressources_pdr.TopLevel = false;
			this.panel1.Controls.Add(ot_ressources_pdr);
			ot_ressources_pdr.Show();
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0017F440 File Offset: 0x0017D640
		private void button2_Click(object sender, EventArgs e)
		{
			ot_ressources.p = 2;
			this.couleur_button(this.button2);
			this.panel1.Controls.Clear();
			ot_ressources_fonction ot_ressources_fonction = new ot_ressources_fonction();
			ot_ressources_fonction.TopLevel = false;
			this.panel1.Controls.Add(ot_ressources_fonction);
			ot_ressources_fonction.Show();
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0017F49C File Offset: 0x0017D69C
		private void button3_Click(object sender, EventArgs e)
		{
			ot_ressources.p = 3;
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_ressources_outillage ot_ressources_outillage = new ot_ressources_outillage();
			ot_ressources_outillage.TopLevel = false;
			this.panel1.Controls.Add(ot_ressources_outillage);
			ot_ressources_outillage.Show();
		}

		// Token: 0x04000C4D RID: 3149
		private static int p = 1;
	}
}
