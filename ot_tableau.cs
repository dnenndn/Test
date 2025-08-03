using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000D2 RID: 210
	public partial class ot_tableau : Form
	{
		// Token: 0x0600096A RID: 2410 RVA: 0x0018416E File Offset: 0x0018236E
		public ot_tableau()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00184188 File Offset: 0x00182388
		private void button1_Click(object sender, EventArgs e)
		{
			ot_tableau.p = 1;
			this.panel1.Controls.Clear();
			ot_tabl_intervention ot_tabl_intervention = new ot_tabl_intervention();
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			this.button6.BackColor = Color.WhiteSmoke;
			ot_tabl_intervention.TopLevel = false;
			this.panel1.Controls.Add(ot_tabl_intervention);
			ot_tabl_intervention.Show();
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0018423C File Offset: 0x0018243C
		private void ot_tableau_Load(object sender, EventArgs e)
		{
			bool flag = ot_tableau.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_tableau.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = ot_tableau.p == 3;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
			bool flag4 = ot_tableau.p == 4;
			if (flag4)
			{
				this.button4_Click(sender, e);
			}
			bool flag5 = ot_tableau.p == 5;
			if (flag5)
			{
				this.button5_Click(sender, e);
			}
			bool flag6 = ot_tableau.p == 6;
			if (flag6)
			{
				this.button6_Click(sender, e);
			}
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x001842D8 File Offset: 0x001824D8
		private void button2_Click(object sender, EventArgs e)
		{
			ot_tableau.p = 2;
			this.panel1.Controls.Clear();
			ot_tabl_bsm ot_tabl_bsm = new ot_tabl_bsm();
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			this.button6.BackColor = Color.WhiteSmoke;
			ot_tabl_bsm.TopLevel = false;
			this.panel1.Controls.Add(ot_tabl_bsm);
			ot_tabl_bsm.Show();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0018438C File Offset: 0x0018258C
		private void button3_Click(object sender, EventArgs e)
		{
			ot_tableau.p = 3;
			this.panel1.Controls.Clear();
			ot_tabl_reservation ot_tabl_reservation = new ot_tabl_reservation();
			this.button3.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			this.button6.BackColor = Color.WhiteSmoke;
			ot_tabl_reservation.TopLevel = false;
			this.panel1.Controls.Add(ot_tabl_reservation);
			ot_tabl_reservation.Show();
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00184440 File Offset: 0x00182640
		private void button4_Click(object sender, EventArgs e)
		{
			ot_tableau.p = 4;
			this.panel1.Controls.Clear();
			ot_tabl_externe ot_tabl_externe = new ot_tabl_externe();
			this.button4.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			this.button6.BackColor = Color.WhiteSmoke;
			ot_tabl_externe.TopLevel = false;
			this.panel1.Controls.Add(ot_tabl_externe);
			ot_tabl_externe.Show();
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x001844F4 File Offset: 0x001826F4
		private void button5_Click(object sender, EventArgs e)
		{
			ot_tableau.p = 5;
			this.panel1.Controls.Clear();
			ot_tabl_projet ot_tabl_projet = new ot_tabl_projet();
			this.button5.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			this.button6.BackColor = Color.WhiteSmoke;
			ot_tabl_projet.TopLevel = false;
			this.panel1.Controls.Add(ot_tabl_projet);
			ot_tabl_projet.Show();
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x001845A8 File Offset: 0x001827A8
		private void button6_Click(object sender, EventArgs e)
		{
			ot_tableau.p = 6;
			this.panel1.Controls.Clear();
			ot_tabl_outillage ot_tabl_outillage = new ot_tabl_outillage();
			this.button6.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			this.button3.BackColor = Color.WhiteSmoke;
			this.button4.BackColor = Color.WhiteSmoke;
			this.button5.BackColor = Color.WhiteSmoke;
			this.button1.BackColor = Color.WhiteSmoke;
			ot_tabl_outillage.TopLevel = false;
			this.panel1.Controls.Add(ot_tabl_outillage);
			ot_tabl_outillage.Show();
		}

		// Token: 0x04000C80 RID: 3200
		private static int p = 1;
	}
}
