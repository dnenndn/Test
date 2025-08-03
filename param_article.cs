using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000158 RID: 344
	public partial class param_article : Form
	{
		// Token: 0x06000F3F RID: 3903 RVA: 0x0024F8CD File Offset: 0x0024DACD
		public param_article()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F40 RID: 3904 RVA: 0x0024F8E8 File Offset: 0x0024DAE8
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x0024F924 File Offset: 0x0024DB24
		private void param_article_Load(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Gray;
			this.button2.BackColor = Color.White;
			parametre_article_unite parametre_article_unite = new parametre_article_unite();
			parametre_article_unite.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_article_unite);
			parametre_article_unite.Show();
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x0024F98C File Offset: 0x0024DB8C
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Gray;
			this.button2.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			parametre_article_unite parametre_article_unite = new parametre_article_unite();
			parametre_article_unite.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_article_unite);
			parametre_article_unite.Show();
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x0024FA5C File Offset: 0x0024DC5C
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Gray;
			this.button1.BackColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			parametre_article_classification parametre_article_classification = new parametre_article_classification();
			parametre_article_classification.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_article_classification);
			parametre_article_classification.Show();
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0024FB2C File Offset: 0x0024DD2C
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Gray;
			this.button3.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button4.BackColor = Color.Gray;
			this.button4.ForeColor = Color.White;
			parametre_article_stockage parametre_article_stockage = new parametre_article_stockage();
			parametre_article_stockage.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_article_stockage);
			parametre_article_stockage.Show();
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x0024FBFC File Offset: 0x0024DDFC
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Gray;
			this.button4.BackColor = Color.White;
			this.button1.BackColor = Color.Gray;
			this.button1.ForeColor = Color.White;
			this.button2.BackColor = Color.Gray;
			this.button2.ForeColor = Color.White;
			this.button3.BackColor = Color.Gray;
			this.button3.ForeColor = Color.White;
			parametre_article_localisation parametre_article_localisation = new parametre_article_localisation();
			parametre_article_localisation.TopLevel = false;
			this.panel5.Controls.Clear();
			this.panel5.Controls.Add(parametre_article_localisation);
			parametre_article_localisation.Show();
		}
	}
}
