using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000EF RID: 239
	public partial class parametrage_corrective : Form
	{
		// Token: 0x06000A5C RID: 2652 RVA: 0x0019BB38 File Offset: 0x00199D38
		public parametrage_corrective()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0019BB50 File Offset: 0x00199D50
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0019BB8C File Offset: 0x00199D8C
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
			centre_charge centre_charge = new centre_charge();
			centre_charge.TopLevel = false;
			this.panel3.Controls.Add(centre_charge);
			centre_charge.Show();
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0019BCC0 File Offset: 0x00199EC0
		private void parametrage_corrective_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0019BCCC File Offset: 0x00199ECC
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
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			classe_intervention classe_intervention = new classe_intervention();
			classe_intervention.TopLevel = false;
			this.panel3.Controls.Add(classe_intervention);
			classe_intervention.Show();
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0019BE00 File Offset: 0x0019A000
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
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			parametrage_diagnostic parametrage_diagnostic = new parametrage_diagnostic();
			parametrage_diagnostic.TopLevel = false;
			this.panel3.Controls.Add(parametrage_diagnostic);
			parametrage_diagnostic.Show();
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0019BF34 File Offset: 0x0019A134
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
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			parametrage_intervention parametrage_intervention = new parametrage_intervention();
			parametrage_intervention.TopLevel = false;
			this.panel3.Controls.Add(parametrage_intervention);
			parametrage_intervention.Show();
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0019C068 File Offset: 0x0019A268
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.ForeColor = Color.Firebrick;
			this.button5.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			plan_maintenance plan_maintenance = new plan_maintenance();
			plan_maintenance.TopLevel = false;
			this.panel3.Controls.Add(plan_maintenance);
			plan_maintenance.Show();
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0019C19C File Offset: 0x0019A39C
		private void button6_Click(object sender, EventArgs e)
		{
			this.button6.ForeColor = Color.Firebrick;
			this.button6.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.button7.ForeColor = Color.White;
			this.button7.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			gamme_operatoire gamme_operatoire = new gamme_operatoire();
			gamme_operatoire.TopLevel = false;
			this.panel3.Controls.Add(gamme_operatoire);
			gamme_operatoire.Show();
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0019C2D0 File Offset: 0x0019A4D0
		private void button7_Click(object sender, EventArgs e)
		{
			this.button7.ForeColor = Color.Firebrick;
			this.button7.BackColor = Color.White;
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
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			cause_non_realisation cause_non_realisation = new cause_non_realisation();
			cause_non_realisation.TopLevel = false;
			this.panel3.Controls.Add(cause_non_realisation);
			cause_non_realisation.Show();
		}
	}
}
