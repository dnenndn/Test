using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000144 RID: 324
	public partial class menu_livraison : Form
	{
		// Token: 0x06000E78 RID: 3704 RVA: 0x002321AC File Offset: 0x002303AC
		public menu_livraison()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x002321C4 File Offset: 0x002303C4
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			creer_bl creer_bl = new creer_bl();
			creer_bl.TopLevel = false;
			livraison.panel3.Controls.Clear();
			livraison.panel3.Controls.Add(creer_bl);
			creer_bl.Show();
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x00232290 File Offset: 0x00230490
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			bl_non_facture bl_non_facture = new bl_non_facture();
			bl_non_facture.TopLevel = false;
			livraison.panel3.Controls.Clear();
			livraison.panel3.Controls.Add(bl_non_facture);
			bl_non_facture.Show();
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x0023235C File Offset: 0x0023055C
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.BackColor = Color.White;
			this.button3.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			bl_facture bl_facture = new bl_facture();
			bl_facture.TopLevel = false;
			livraison.panel3.Controls.Clear();
			livraison.panel3.Controls.Add(bl_facture);
			bl_facture.Show();
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00232428 File Offset: 0x00230628
		private void menu_livraison_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Magasin";
			if (!flag)
			{
				this.button1.Visible = false;
			}
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x0023246C File Offset: 0x0023066C
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.BackColor = Color.White;
			this.button4.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			livraison_sous_traitant livraison_sous_traitant = new livraison_sous_traitant();
			livraison_sous_traitant.TopLevel = false;
			livraison.panel3.Controls.Clear();
			livraison.panel3.Controls.Add(livraison_sous_traitant);
			livraison_sous_traitant.Show();
		}
	}
}
