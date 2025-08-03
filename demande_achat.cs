using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000063 RID: 99
	public partial class demande_achat : Form
	{
		// Token: 0x060004A2 RID: 1186 RVA: 0x000C5289 File Offset: 0x000C3489
		public demande_achat()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x000C52A4 File Offset: 0x000C34A4
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x000C52E0 File Offset: 0x000C34E0
		private void demande_achat_Load(object sender, EventArgs e)
		{
			menu_demande_achat menu_demande_achat = new menu_demande_achat();
			menu_demande_achat.TopLevel = false;
			menu_demande_achat.button1.BackColor = Color.White;
			menu_demande_achat.button1.ForeColor = Color.Firebrick;
			menu_demande_achat.button2.BackColor = Color.Firebrick;
			menu_demande_achat.button2.ForeColor = Color.White;
			menu_demande_achat.button3.BackColor = Color.Firebrick;
			menu_demande_achat.button3.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_demande_achat);
			menu_demande_achat.Show();
			bool flag = page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				menu_demande_achat.button3.BackColor = Color.White;
				menu_demande_achat.button3.ForeColor = Color.Firebrick;
				menu_demande_achat.button1.BackColor = Color.Firebrick;
				menu_demande_achat.button1.ForeColor = Color.White;
				menu_demande_achat.button2.BackColor = Color.Firebrick;
				menu_demande_achat.button2.ForeColor = Color.White;
				da_confirmer da_confirmer = new da_confirmer();
				da_confirmer.TopLevel = false;
				demande_achat.panel3.Controls.Clear();
				demande_achat.panel3.Controls.Add(da_confirmer);
				da_confirmer.Show();
			}
			else
			{
				creer_da creer_da = new creer_da();
				creer_da.TopLevel = false;
				demande_achat.panel3.Controls.Clear();
				demande_achat.panel3.Controls.Add(creer_da);
				creer_da.Show();
			}
		}
	}
}
