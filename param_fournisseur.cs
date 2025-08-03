using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000159 RID: 345
	public partial class param_fournisseur : Form
	{
		// Token: 0x06000F48 RID: 3912 RVA: 0x002502FB File Offset: 0x0024E4FB
		public param_fournisseur()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x00250314 File Offset: 0x0024E514
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x00250350 File Offset: 0x0024E550
		private void param_fournisseur_Load(object sender, EventArgs e)
		{
			menu_fournisseur menu_fournisseur = new menu_fournisseur();
			menu_fournisseur.TopLevel = false;
			menu_fournisseur.button3.BackColor = Color.White;
			menu_fournisseur.button3.ForeColor = Color.Firebrick;
			menu_fournisseur.button2.BackColor = Color.Firebrick;
			menu_fournisseur.button2.ForeColor = Color.White;
			menu_fournisseur.button1.BackColor = Color.Firebrick;
			menu_fournisseur.button1.ForeColor = Color.White;
			this.panel2.Controls.Clear();
			this.panel2.Controls.Add(menu_fournisseur);
			menu_fournisseur.Show();
			this.button2.ForeColor = Color.Gray;
			this.button2.BackColor = Color.White;
			parametre_fournisseur_activite parametre_fournisseur_activite = new parametre_fournisseur_activite();
			parametre_fournisseur_activite.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_fournisseur_activite);
			parametre_fournisseur_activite.Show();
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x00250458 File Offset: 0x0024E658
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x00250494 File Offset: 0x0024E694
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Gray;
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Gray;
			this.button5.ForeColor = Color.White;
			parametre_fournisseur_activite parametre_fournisseur_activite = new parametre_fournisseur_activite();
			parametre_fournisseur_activite.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_fournisseur_activite);
			parametre_fournisseur_activite.Show();
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x00250584 File Offset: 0x0024E784
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Gray;
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Gray;
			this.button5.ForeColor = Color.White;
			parametre_fournisseur_reglement parametre_fournisseur_reglement = new parametre_fournisseur_reglement();
			parametre_fournisseur_reglement.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_fournisseur_reglement);
			parametre_fournisseur_reglement.Show();
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x00250674 File Offset: 0x0024E874
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Gray;
			this.button3.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			this.button5.BackColor = Color.Gray;
			this.button5.ForeColor = Color.White;
			parametre_fournisseur_livraison parametre_fournisseur_livraison = new parametre_fournisseur_livraison();
			parametre_fournisseur_livraison.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_fournisseur_livraison);
			parametre_fournisseur_livraison.Show();
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x00250764 File Offset: 0x0024E964
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Gray;
			this.button4.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.button5.BackColor = Color.Gray;
			this.button5.ForeColor = Color.White;
			parametre_fournisseur_compte parametre_fournisseur_compte = new parametre_fournisseur_compte();
			parametre_fournisseur_compte.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_fournisseur_compte);
			parametre_fournisseur_compte.Show();
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x00250854 File Offset: 0x0024EA54
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.ForeColor = Color.Gray;
			this.button5.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			parametre_fournisseur_devise parametre_fournisseur_devise = new parametre_fournisseur_devise();
			parametre_fournisseur_devise.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_fournisseur_devise);
			parametre_fournisseur_devise.Show();
		}
	}
}
