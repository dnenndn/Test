using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000008 RID: 8
	public partial class activite_sous_traitance : Form
	{
		// Token: 0x06000054 RID: 84 RVA: 0x0000C76D File Offset: 0x0000A96D
		public activite_sous_traitance()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000C788 File Offset: 0x0000A988
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000C7C2 File Offset: 0x0000A9C2
		private void activite_sous_traitance_Load(object sender, EventArgs e)
		{
			this.button1_Click(sender, e);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			liste_activite liste_activite = new liste_activite();
			liste_activite.TopLevel = false;
			this.panel3.Controls.Clear();
			this.panel3.Controls.Add(liste_activite);
			liste_activite.Show();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000C85C File Offset: 0x0000AA5C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			liste_activité_st liste_activité_st = new liste_activité_st();
			liste_activité_st.TopLevel = false;
			this.panel3.Controls.Clear();
			this.panel3.Controls.Add(liste_activité_st);
			liste_activité_st.Show();
		}
	}
}
