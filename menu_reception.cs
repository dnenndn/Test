using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000145 RID: 325
	public partial class menu_reception : Form
	{
		// Token: 0x06000E80 RID: 3712 RVA: 0x00232AB5 File Offset: 0x00230CB5
		public menu_reception()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x00232AD0 File Offset: 0x00230CD0
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.BackColor = Color.White;
			this.button1.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			creer_reception creer_reception = new creer_reception();
			creer_reception.TopLevel = false;
			reception.panel3.Controls.Clear();
			reception.panel3.Controls.Add(creer_reception);
			creer_reception.Show();
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x00232B58 File Offset: 0x00230D58
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.BackColor = Color.White;
			this.button2.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			reception_historique reception_historique = new reception_historique();
			reception_historique.TopLevel = false;
			reception.panel3.Controls.Clear();
			reception.panel3.Controls.Add(reception_historique);
			reception_historique.Show();
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x00232BE0 File Offset: 0x00230DE0
		private void menu_reception_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Responsable Magasin" | page_loginn.stat_user == "Magasinier" | page_loginn.stat_user == "Responsable Achat";
			if (!flag)
			{
				this.button1.Hide();
			}
		}
	}
}
