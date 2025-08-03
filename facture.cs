using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000075 RID: 117
	public partial class facture : Form
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x000E3A50 File Offset: 0x000E1C50
		public facture()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000E3A68 File Offset: 0x000E1C68
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000E3AA4 File Offset: 0x000E1CA4
		private void facture_Load(object sender, EventArgs e)
		{
			menu_facture menu_facture = new menu_facture();
			menu_facture.TopLevel = false;
			menu_facture.button1.BackColor = Color.White;
			menu_facture.button1.ForeColor = Color.Firebrick;
			menu_facture.button2.BackColor = Color.Firebrick;
			menu_facture.button2.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_facture);
			menu_facture.Show();
			liste_facture liste_facture = new liste_facture();
			liste_facture.TopLevel = false;
			facture.panel3.Controls.Clear();
			facture.panel3.Controls.Add(liste_facture);
			liste_facture.Show();
		}
	}
}
