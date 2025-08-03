using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000167 RID: 359
	public partial class tb_variation_prix_article : Form
	{
		// Token: 0x0600102F RID: 4143 RVA: 0x0028F539 File Offset: 0x0028D739
		public tb_variation_prix_article()
		{
			this.InitializeComponent();
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0028F554 File Offset: 0x0028D754
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x0028F590 File Offset: 0x0028D790
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			tb_variation_prix_article_vr tb_variation_prix_article_vr = new tb_variation_prix_article_vr();
			tb_variation_prix_article_vr.TopLevel = false;
			this.panel1.Controls.Add(tb_variation_prix_article_vr);
			tb_variation_prix_article_vr.Show();
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0028F61A File Offset: 0x0028D81A
		private void tb_variation_prix_article_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0028F628 File Offset: 0x0028D828
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			tb_variation_prix_recap tb_variation_prix_recap = new tb_variation_prix_recap();
			tb_variation_prix_recap.TopLevel = false;
			this.panel1.Controls.Add(tb_variation_prix_recap);
			tb_variation_prix_recap.Show();
		}
	}
}
