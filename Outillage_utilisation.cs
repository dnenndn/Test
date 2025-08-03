using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x020000EA RID: 234
	public partial class Outillage_utilisation : Form
	{
		// Token: 0x06000A30 RID: 2608 RVA: 0x00195868 File Offset: 0x00193A68
		public Outillage_utilisation()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00195880 File Offset: 0x00193A80
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x001958BC File Offset: 0x00193ABC
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			Outillage_utilisation_lancement outillage_utilisation_lancement = new Outillage_utilisation_lancement();
			outillage_utilisation_lancement.TopLevel = false;
			this.panel1.Controls.Add(outillage_utilisation_lancement);
			outillage_utilisation_lancement.Show();
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00195946 File Offset: 0x00193B46
		private void Outillage_utilisation_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00195954 File Offset: 0x00193B54
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			outillage_utilisation_historique outillage_utilisation_historique = new outillage_utilisation_historique();
			outillage_utilisation_historique.TopLevel = false;
			this.panel1.Controls.Add(outillage_utilisation_historique);
			outillage_utilisation_historique.Show();
		}
	}
}
