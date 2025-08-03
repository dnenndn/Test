using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000108 RID: 264
	public partial class prod_param_compteur : Form
	{
		// Token: 0x06000BD0 RID: 3024 RVA: 0x001D09CB File Offset: 0x001CEBCB
		public prod_param_compteur()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x001D09E4 File Offset: 0x001CEBE4
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x001D0A20 File Offset: 0x001CEC20
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.panel1.Controls.Clear();
			prod_param_compteur_1 prod_param_compteur_ = new prod_param_compteur_1();
			prod_param_compteur_.TopLevel = false;
			this.panel1.Controls.Add(prod_param_compteur_);
			prod_param_compteur_.Show();
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x001D0A88 File Offset: 0x001CEC88
		private void prod_param_compteur_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}
	}
}
