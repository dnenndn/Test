namespace GMAO
{
	// Token: 0x0200001E RID: 30
	public partial class articles : global::System.Windows.Forms.Form
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x0004903C File Offset: 0x0004723C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00049074 File Offset: 0x00047274
		private void InitializeComponent()
		{
			global::GMAO.articles.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.articles.panel3 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			global::GMAO.articles.panel2.Location = new global::System.Drawing.Point(1, 1);
			global::GMAO.articles.panel2.Name = "panel2";
			global::GMAO.articles.panel2.Size = new global::System.Drawing.Size(1148, 25);
			global::GMAO.articles.panel2.TabIndex = 7;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 8;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			global::GMAO.articles.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.articles.panel3.Name = "panel3";
			global::GMAO.articles.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.articles.panel3.TabIndex = 9;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.articles.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(global::GMAO.articles.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "articles";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.articles_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000277 RID: 631
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000278 RID: 632
		public static global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400027A RID: 634
		public static global::System.Windows.Forms.Panel panel3;
	}
}
