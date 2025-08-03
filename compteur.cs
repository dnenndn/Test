using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200004A RID: 74
	public partial class compteur : Form
	{
		// Token: 0x06000348 RID: 840 RVA: 0x0008D857 File Offset: 0x0008BA57
		public compteur()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0008D870 File Offset: 0x0008BA70
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0008D8AC File Offset: 0x0008BAAC
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			compteur_actuel compteur_actuel = new compteur_actuel();
			compteur_actuel.TopLevel = false;
			this.panel3.Controls.Add(compteur_actuel);
			compteur_actuel.Show();
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0008D97A File Offset: 0x0008BB7A
		private void compteur_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0008D988 File Offset: 0x0008BB88
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			compteur_historique compteur_historique = new compteur_historique();
			compteur_historique.TopLevel = false;
			this.panel3.Controls.Add(compteur_historique);
			compteur_historique.Show();
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0008DA58 File Offset: 0x0008BC58
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			compteur_variation compteur_variation = new compteur_variation();
			compteur_variation.TopLevel = false;
			this.panel3.Controls.Add(compteur_variation);
			compteur_variation.Show();
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0008DB28 File Offset: 0x0008BD28
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Firebrick;
			this.button4.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			compteur_laision compteur_laision = new compteur_laision();
			compteur_laision.TopLevel = false;
			this.panel3.Controls.Add(compteur_laision);
			compteur_laision.Show();
		}
	}
}
