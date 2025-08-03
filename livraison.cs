using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200013E RID: 318
	public partial class livraison : Form
	{
		// Token: 0x06000E45 RID: 3653 RVA: 0x0022DF61 File Offset: 0x0022C161
		public livraison()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0022DF7C File Offset: 0x0022C17C
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x0022DFB8 File Offset: 0x0022C1B8
		private void livraison_Load(object sender, EventArgs e)
		{
			menu_livraison menu_livraison = new menu_livraison();
			menu_livraison.TopLevel = false;
			menu_livraison.button1.BackColor = Color.White;
			menu_livraison.button1.ForeColor = Color.Firebrick;
			menu_livraison.button2.BackColor = Color.Firebrick;
			menu_livraison.button2.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_livraison);
			menu_livraison.Show();
			bool flag = page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				creer_bl creer_bl = new creer_bl();
				creer_bl.TopLevel = false;
				livraison.panel3.Controls.Clear();
				livraison.panel3.Controls.Add(creer_bl);
				creer_bl.Show();
			}
			else
			{
				bl_non_facture bl_non_facture = new bl_non_facture();
				bl_non_facture.TopLevel = false;
				livraison.panel3.Controls.Clear();
				livraison.panel3.Controls.Add(bl_non_facture);
				bl_non_facture.Show();
			}
		}
	}
}
