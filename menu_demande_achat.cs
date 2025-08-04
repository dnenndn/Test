using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000141 RID: 321
	public partial class menu_demande_achat : Form
	{
		// Token: 0x06000E5B RID: 3675 RVA: 0x0022F8B0 File Offset: 0x0022DAB0
		public menu_demande_achat()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x0022F8C8 File Offset: 0x0022DAC8
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			liste_da liste_da = new liste_da();
			liste_da.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(liste_da);
			liste_da.Show();
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x0022F9FC File Offset: 0x0022DBFC
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			creer_da creer_da = new creer_da();
			creer_da.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(creer_da);
			creer_da.Show();
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x0022FB30 File Offset: 0x0022DD30
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.BackColor = Color.White;
			this.button3.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			da_confirmer da_confirmer = new da_confirmer();
			da_confirmer.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(da_confirmer);
			da_confirmer.Show();
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x0022FC64 File Offset: 0x0022DE64
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.BackColor = Color.White;
			this.button4.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			da_refuser da_refuser = new da_refuser();
			da_refuser.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(da_refuser);
			da_refuser.Show();
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x0022FD98 File Offset: 0x0022DF98
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.BackColor = Color.White;
			this.button5.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			da_reporter da_reporter = new da_reporter();
			da_reporter.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(da_reporter);
			da_reporter.Show();
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x0022FECC File Offset: 0x0022E0CC
		private void button6_Click(object sender, EventArgs e)
		{
			this.button6.BackColor = Color.White;
			this.button6.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			da_admin da_admin = new da_admin();
			da_admin.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(da_admin);
			da_admin.Show();
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x00230000 File Offset: 0x0022E200
		private void button7_Click_1(object sender, EventArgs e)
		{
			this.button7.BackColor = Color.White;
			this.button7.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			da_cloturer da_cloturer = new da_cloturer();
			da_cloturer.TopLevel = false;
			demande_achat.panel3.Controls.Clear();
			demande_achat.panel3.Controls.Add(da_cloturer);
			da_cloturer.Show();
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x00230134 File Offset: 0x0022E334
		private void menu_demande_achat_Load(object sender, EventArgs e)
		{
			if (UserSession.stat_user == "Administrateur")
			{
				this.button1.Visible = false;
				this.button2.Visible = false;
			}
		}
	}
}
