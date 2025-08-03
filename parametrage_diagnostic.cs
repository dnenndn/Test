using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000F0 RID: 240
	public partial class parametrage_diagnostic : Form
	{
		// Token: 0x06000A68 RID: 2664 RVA: 0x0019CD9A File Offset: 0x0019AF9A
		public parametrage_diagnostic()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0019CDB4 File Offset: 0x0019AFB4
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0019CDF0 File Offset: 0x0019AFF0
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			parametrage_anomalie parametrage_anomalie = new parametrage_anomalie();
			parametrage_anomalie.TopLevel = false;
			this.panel1.Controls.Add(parametrage_anomalie);
			parametrage_anomalie.Show();
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0019CE9C File Offset: 0x0019B09C
		private void parametrage_diagnostic_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0019CEA8 File Offset: 0x0019B0A8
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			arbre_defaillance arbre_defaillance = new arbre_defaillance();
			arbre_defaillance.TopLevel = false;
			this.panel1.Controls.Add(arbre_defaillance);
			arbre_defaillance.Show();
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0019CF54 File Offset: 0x0019B154
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			symptome symptome = new symptome();
			symptome.TopLevel = false;
			this.panel1.Controls.Add(symptome);
			symptome.Show();
		}
	}
}
