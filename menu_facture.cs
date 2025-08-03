using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000097 RID: 151
	public partial class menu_facture : Form
	{
		// Token: 0x060006EE RID: 1774 RVA: 0x0012E8A4 File Offset: 0x0012CAA4
		public menu_facture()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0012E8BC File Offset: 0x0012CABC
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			liste_facture liste_facture = new liste_facture();
			liste_facture.TopLevel = false;
			facture.panel3.Controls.Clear();
			facture.panel3.Controls.Add(liste_facture);
			liste_facture.Show();
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0012E944 File Offset: 0x0012CB44
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			facture_st facture_st = new facture_st();
			facture_st.TopLevel = false;
			facture.panel3.Controls.Clear();
			facture.panel3.Controls.Add(facture_st);
			facture_st.Show();
		}
	}
}
