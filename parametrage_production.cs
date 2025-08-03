using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000F2 RID: 242
	public partial class parametrage_production : Form
	{
		// Token: 0x06000A77 RID: 2679 RVA: 0x0019DB1D File Offset: 0x0019BD1D
		public parametrage_production()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0019DB38 File Offset: 0x0019BD38
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0019DB74 File Offset: 0x0019BD74
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
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			prod_param_brique prod_param_brique = new prod_param_brique();
			prod_param_brique.TopLevel = false;
			this.panel3.Controls.Add(prod_param_brique);
			prod_param_brique.Show();
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0019DCA8 File Offset: 0x0019BEA8
		private void parametrage_production_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0019DCB4 File Offset: 0x0019BEB4
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Firebrick;
			this.button4.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			prod_param_equipement prod_param_equipement = new prod_param_equipement();
			prod_param_equipement.TopLevel = false;
			this.panel3.Controls.Add(prod_param_equipement);
			prod_param_equipement.Show();
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0019DDE8 File Offset: 0x0019BFE8
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			prod_param_compteur prod_param_compteur = new prod_param_compteur();
			prod_param_compteur.TopLevel = false;
			this.panel3.Controls.Add(prod_param_compteur);
			prod_param_compteur.Show();
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0019DF1C File Offset: 0x0019C11C
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.ForeColor = Color.Firebrick;
			this.button5.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			prod_param_saisie prod_param_saisie = new prod_param_saisie();
			prod_param_saisie.TopLevel = false;
			this.panel3.Controls.Add(prod_param_saisie);
			prod_param_saisie.Show();
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0019E050 File Offset: 0x0019C250
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			prod_param_mesure prod_param_mesure = new prod_param_mesure();
			prod_param_mesure.TopLevel = false;
			this.panel3.Controls.Add(prod_param_mesure);
			prod_param_mesure.Show();
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0019E184 File Offset: 0x0019C384
		private void button6_Click(object sender, EventArgs e)
		{
			this.button6.ForeColor = Color.Firebrick;
			this.button6.BackColor = Color.White;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			prod_param_anomalie prod_param_anomalie = new prod_param_anomalie();
			prod_param_anomalie.TopLevel = false;
			this.panel3.Controls.Add(prod_param_anomalie);
			prod_param_anomalie.Show();
		}
	}
}
