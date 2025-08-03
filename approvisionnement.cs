using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000014 RID: 20
	public partial class approvisionnement : Form
	{
		// Token: 0x06000120 RID: 288 RVA: 0x000388AF File Offset: 0x00036AAF
		public approvisionnement()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000388C8 File Offset: 0x00036AC8
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00038904 File Offset: 0x00036B04
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
			app_reapprovisionnement app_reapprovisionnement = new app_reapprovisionnement();
			app_reapprovisionnement.TopLevel = false;
			this.panel3.Controls.Add(app_reapprovisionnement);
			app_reapprovisionnement.Show();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000389D2 File Offset: 0x00036BD2
		private void approvisionnement_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000389E0 File Offset: 0x00036BE0
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
			app_point_commande app_point_commande = new app_point_commande();
			app_point_commande.TopLevel = false;
			this.panel3.Controls.Add(app_point_commande);
			app_point_commande.Show();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00038AB0 File Offset: 0x00036CB0
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			app_recompletement app_recompletement = new app_recompletement();
			app_recompletement.TopLevel = false;
			this.panel3.Controls.Add(app_recompletement);
			app_recompletement.Show();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00038B80 File Offset: 0x00036D80
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Firebrick;
			this.button4.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			app_gerer_planning app_gerer_planning = new app_gerer_planning();
			app_gerer_planning.TopLevel = false;
			this.panel3.Controls.Add(app_gerer_planning);
			app_gerer_planning.Show();
		}
	}
}
