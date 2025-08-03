using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000E6 RID: 230
	public partial class outillage_parametre : Form
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x0019242E File Offset: 0x0019062E
		public outillage_parametre()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00192448 File Offset: 0x00190648
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00192484 File Offset: 0x00190684
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			outillage_parametre_secteur outillage_parametre_secteur = new outillage_parametre_secteur();
			outillage_parametre_secteur.TopLevel = false;
			this.panel1.Controls.Add(outillage_parametre_secteur);
			outillage_parametre_secteur.Show();
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00192530 File Offset: 0x00190730
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			outillage_parametre_type outillage_parametre_type = new outillage_parametre_type();
			outillage_parametre_type.TopLevel = false;
			this.panel1.Controls.Add(outillage_parametre_type);
			outillage_parametre_type.Show();
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x001925DC File Offset: 0x001907DC
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			outillage_parametre_utilisation outillage_parametre_utilisation = new outillage_parametre_utilisation();
			outillage_parametre_utilisation.TopLevel = false;
			this.panel1.Controls.Add(outillage_parametre_utilisation);
			outillage_parametre_utilisation.Show();
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00192688 File Offset: 0x00190888
		private void outillage_parametre_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}
	}
}
