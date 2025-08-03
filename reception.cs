using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200015C RID: 348
	public partial class reception : Form
	{
		// Token: 0x06000F57 RID: 3927 RVA: 0x002512E6 File Offset: 0x0024F4E6
		public reception()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00251300 File Offset: 0x0024F500
		private void reception_Load(object sender, EventArgs e)
		{
			menu_reception menu_reception = new menu_reception();
			menu_reception.TopLevel = false;
			menu_reception.button1.BackColor = Color.White;
			menu_reception.button1.ForeColor = Color.Firebrick;
			menu_reception.button2.BackColor = Color.Firebrick;
			menu_reception.button2.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_reception);
			menu_reception.Show();
			bool flag = page_loginn.stat_user == "Responsable Magasin" | page_loginn.stat_user == "Magasinier" | page_loginn.stat_user == "Responsable Achat";
			if (flag)
			{
				creer_reception creer_reception = new creer_reception();
				creer_reception.TopLevel = false;
				reception.panel3.Controls.Clear();
				reception.panel3.Controls.Add(creer_reception);
				creer_reception.Show();
			}
			else
			{
				reception_historique reception_historique = new reception_historique();
				reception_historique.TopLevel = false;
				reception.panel3.Controls.Clear();
				reception.panel3.Controls.Add(reception_historique);
				reception_historique.Show();
			}
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00251430 File Offset: 0x0024F630
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}
	}
}
