namespace GMAO
{
	// Token: 0x02000121 RID: 289
	public partial class retour_magasin : global::System.Windows.Forms.Form
	{
		// Token: 0x06000CDA RID: 3290 RVA: 0x001F3A88 File Offset: 0x001F1C88
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x001F3AC0 File Offset: 0x001F1CC0
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.retour_magasin.panel3 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(-1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 12;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 13;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			global::GMAO.retour_magasin.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.retour_magasin.panel3.Name = "panel3";
			global::GMAO.retour_magasin.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.retour_magasin.panel3.TabIndex = 14;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.retour_magasin.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "retour_magasin";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.retour_magasin_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04001069 RID: 4201
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400106A RID: 4202
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400106B RID: 4203
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400106C RID: 4204
		public static global::System.Windows.Forms.Panel panel3;
	}
}
