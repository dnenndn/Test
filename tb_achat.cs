using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000162 RID: 354
	public partial class tb_achat : Form
	{
		// Token: 0x06000F83 RID: 3971 RVA: 0x00258810 File Offset: 0x00256A10
		public tb_achat()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00258828 File Offset: 0x00256A28
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x00258864 File Offset: 0x00256A64
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
			tb_flux_achat tb_flux_achat = new tb_flux_achat();
			tb_flux_achat.TopLevel = false;
			this.panel3.Controls.Add(tb_flux_achat);
			tb_flux_achat.Show();
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x00258932 File Offset: 0x00256B32
		private void tb_achat_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00258940 File Offset: 0x00256B40
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
			tb_variation_prix tb_variation_prix = new tb_variation_prix();
			tb_variation_prix.TopLevel = false;
			this.panel3.Controls.Add(tb_variation_prix);
			tb_variation_prix.Show();
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x00258A10 File Offset: 0x00256C10
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
			tb_variation_prix_article tb_variation_prix_article = new tb_variation_prix_article();
			tb_variation_prix_article.TopLevel = false;
			this.panel3.Controls.Add(tb_variation_prix_article);
			tb_variation_prix_article.Show();
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x00258AE0 File Offset: 0x00256CE0
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
			this.panel3.Controls.Clear();
			tb_achat_article tb_achat_article = new tb_achat_article();
			tb_achat_article.TopLevel = false;
			this.panel3.Controls.Add(tb_achat_article);
			tb_achat_article.Show();
		}
	}
}
