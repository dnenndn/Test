using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000096 RID: 150
	public partial class menu_bsm : Form
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x0012E1A5 File Offset: 0x0012C3A5
		public menu_bsm()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0012E1C0 File Offset: 0x0012C3C0
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			creer_bsm creer_bsm = new creer_bsm();
			creer_bsm.TopLevel = false;
			bsm.panel3.Controls.Clear();
			bsm.panel3.Controls.Add(creer_bsm);
			creer_bsm.Show();
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0012E26C File Offset: 0x0012C46C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			historique_bsm historique_bsm = new historique_bsm();
			historique_bsm.TopLevel = false;
			bsm.panel3.Controls.Clear();
			bsm.panel3.Controls.Add(historique_bsm);
			historique_bsm.Show();
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0012E318 File Offset: 0x0012C518
		private void menu_bsm_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				this.button1.Visible = false;
			}
			bool flag2 = page_loginn.stat_user != "Responsable Achat" & page_loginn.stat_user != "Responsable Méthode" & page_loginn.stat_user != "Administrateur";
			if (flag2)
			{
				this.button4.Visible = false;
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0012E38C File Offset: 0x0012C58C
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.BackColor = Color.White;
			this.button4.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			tb_bsm tb_bsm = new tb_bsm();
			tb_bsm.TopLevel = false;
			bsm.panel3.Controls.Clear();
			bsm.panel3.Controls.Add(tb_bsm);
			tb_bsm.Show();
		}
	}
}
