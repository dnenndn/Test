using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000143 RID: 323
	public partial class menu_fournisseur : Form
	{
		// Token: 0x06000E71 RID: 3697 RVA: 0x00231C1B File Offset: 0x0022FE1B
		public menu_fournisseur()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x00231C34 File Offset: 0x0022FE34
		private void button1_Click(object sender, EventArgs e)
		{
			ajouter_fournisseur ajouter_fournisseur = new ajouter_fournisseur();
			ajouter_fournisseur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(ajouter_fournisseur);
			ajouter_fournisseur.Show();
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00231C78 File Offset: 0x0022FE78
		private void button3_Click(object sender, EventArgs e)
		{
			param_fournisseur param_fournisseur = new param_fournisseur();
			param_fournisseur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(param_fournisseur);
			param_fournisseur.Show();
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00231CBC File Offset: 0x0022FEBC
		private void button2_Click(object sender, EventArgs e)
		{
			liste_fournisseur liste_fournisseur = new liste_fournisseur();
			liste_fournisseur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(liste_fournisseur);
			liste_fournisseur.Show();
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x00231D00 File Offset: 0x0022FF00
		private void menu_fournisseur_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Administrateur";
			if (flag)
			{
				this.button1.Visible = false;
				this.button3.Visible = false;
			}
		}
	}
}
