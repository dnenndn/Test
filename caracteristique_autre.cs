using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000035 RID: 53
	public partial class caracteristique_autre : Form
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0006A182 File Offset: 0x00068382
		public caracteristique_autre()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0006A19A File Offset: 0x0006839A
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			ajouter_caractéristique.remplir_tableau(this.guna2TextBox1.Text);
			this.guna2TextBox1.Clear();
		}
	}
}
