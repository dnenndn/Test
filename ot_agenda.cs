using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000A2 RID: 162
	public partial class ot_agenda : Form
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x0014D401 File Offset: 0x0014B601
		public ot_agenda()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0014D41C File Offset: 0x0014B61C
		private void ot_agenda_Load(object sender, EventArgs e)
		{
			bool flag = ot_agenda.p == 1;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = ot_agenda.p == 2;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0014D458 File Offset: 0x0014B658
		private void button1_Click(object sender, EventArgs e)
		{
			ot_agenda.p = 1;
			this.panel1.Controls.Clear();
			ot_agenda_travaux ot_agenda_travaux = new ot_agenda_travaux();
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.WhiteSmoke;
			ot_agenda_travaux.TopLevel = false;
			this.panel1.Controls.Add(ot_agenda_travaux);
			ot_agenda_travaux.Show();
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0014D4C8 File Offset: 0x0014B6C8
		private void button2_Click(object sender, EventArgs e)
		{
			ot_agenda.p = 2;
			this.panel1.Controls.Clear();
			ot_agenda_employe ot_agenda_employe = new ot_agenda_employe();
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.WhiteSmoke;
			ot_agenda_employe.TopLevel = false;
			this.panel1.Controls.Add(ot_agenda_employe);
			ot_agenda_employe.Show();
		}

		// Token: 0x04000A55 RID: 2645
		private static int p = 1;
	}
}
