using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000121 RID: 289
	public partial class retour_magasin : Form
	{
		// Token: 0x06000CD7 RID: 3287 RVA: 0x001F38DF File Offset: 0x001F1ADF
		public retour_magasin()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x001F38F8 File Offset: 0x001F1AF8
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x001F3934 File Offset: 0x001F1B34
		private void retour_magasin_Load(object sender, EventArgs e)
		{
			menu_brm menu_brm = new menu_brm();
			menu_brm.TopLevel = false;
			menu_brm.button1.BackColor = Color.White;
			menu_brm.button1.ForeColor = Color.Firebrick;
			menu_brm.button2.BackColor = Color.Firebrick;
			menu_brm.button2.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_brm);
			menu_brm.Show();
			bool flag = page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				menu_brm.button2.BackColor = Color.White;
				menu_brm.button2.ForeColor = Color.Firebrick;
				menu_brm.button1.BackColor = Color.Firebrick;
				menu_brm.button1.ForeColor = Color.White;
				historique_brm historique_brm = new historique_brm();
				historique_brm.TopLevel = false;
				retour_magasin.panel3.Controls.Clear();
				retour_magasin.panel3.Controls.Add(historique_brm);
				historique_brm.Show();
			}
			else
			{
				creer_brm creer_brm = new creer_brm();
				creer_brm.TopLevel = false;
				retour_magasin.panel3.Controls.Clear();
				retour_magasin.panel3.Controls.Add(creer_brm);
				creer_brm.Show();
			}
		}
	}
}
