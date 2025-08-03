using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200003E RID: 62
	public partial class commande : Form
	{
		// Token: 0x060002B4 RID: 692 RVA: 0x00072D1E File Offset: 0x00070F1E
		public commande()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00072D38 File Offset: 0x00070F38
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00072D74 File Offset: 0x00070F74
		private void commande_Load(object sender, EventArgs e)
		{
			menu_commande menu_commande = new menu_commande();
			menu_commande.TopLevel = false;
			menu_commande.button1.BackColor = Color.White;
			menu_commande.button1.ForeColor = Color.Firebrick;
			menu_commande.button2.BackColor = Color.Firebrick;
			menu_commande.button2.ForeColor = Color.White;
			menu_commande.button3.BackColor = Color.Firebrick;
			menu_commande.button3.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_commande);
			menu_commande.Show();
			if (UserSession.CurrentUser.Statut == "Responsable Achat")
			{
				creer_commande creer_commande = new creer_commande();
				creer_commande.TopLevel = false;
				commande.panel3.Controls.Clear();
				commande.panel3.Controls.Add(creer_commande);
				creer_commande.Show();
			}
			else
			{
				commande_attente commande_attente = new commande_attente();
				commande_attente.TopLevel = false;
				commande.panel3.Controls.Clear();
				commande.panel3.Controls.Add(commande_attente);
				commande_attente.Show();
			}
		}
	}
}
