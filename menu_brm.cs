using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000095 RID: 149
	public partial class menu_brm : Form
	{
		// Token: 0x060006E1 RID: 1761 RVA: 0x0012DCEE File Offset: 0x0012BEEE
		public menu_brm()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0012DD08 File Offset: 0x0012BF08
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			creer_brm creer_brm = new creer_brm();
			creer_brm.TopLevel = false;
			retour_magasin.panel3.Controls.Clear();
			retour_magasin.panel3.Controls.Add(creer_brm);
			creer_brm.Show();
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0012DD90 File Offset: 0x0012BF90
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			historique_brm historique_brm = new historique_brm();
			historique_brm.TopLevel = false;
			retour_magasin.panel3.Controls.Clear();
			retour_magasin.panel3.Controls.Add(historique_brm);
			historique_brm.Show();
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0012DE18 File Offset: 0x0012C018
		private void menu_brm_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				this.button1.Visible = false;
			}
		}
	}
}
