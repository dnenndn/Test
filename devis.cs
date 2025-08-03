using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000066 RID: 102
	public partial class devis : Form
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x000D22FD File Offset: 0x000D04FD
		public devis()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x000D2318 File Offset: 0x000D0518
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x000D2354 File Offset: 0x000D0554
		private void devis_Load(object sender, EventArgs e)
		{
			menu_devis menu_devis = new menu_devis();
			menu_devis.TopLevel = false;
			menu_devis.button1.BackColor = Color.White;
			menu_devis.button1.ForeColor = Color.Firebrick;
			menu_devis.button2.BackColor = Color.Firebrick;
			menu_devis.button2.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_devis);
			menu_devis.Show();
			bool flag = page_loginn.stat_user == "Responsable Achat";
			if (flag)
			{
				créer_dop créer_dop = new créer_dop();
				créer_dop.TopLevel = false;
				devis.panel3.Controls.Clear();
				devis.panel3.Controls.Add(créer_dop);
				créer_dop.Show();
			}
			else
			{
				bool flag2 = page_loginn.stat_user == "Administrateur";
				if (flag2)
				{
					historique_dop historique_dop = new historique_dop();
					historique_dop.TopLevel = false;
					devis.panel3.Controls.Clear();
					devis.panel3.Controls.Add(historique_dop);
					historique_dop.Show();
				}
				else
				{
					liste_dop liste_dop = new liste_dop();
					liste_dop.TopLevel = false;
					devis.panel3.Controls.Clear();
					devis.panel3.Controls.Add(liste_dop);
					liste_dop.Show();
				}
			}
		}
	}
}
