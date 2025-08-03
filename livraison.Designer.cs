namespace GMAO
{
	// Token: 0x0200013E RID: 318
	public partial class livraison : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E48 RID: 3656 RVA: 0x0022E0D8 File Offset: 0x0022C2D8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x0022E110 File Offset: 0x0022C310
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.livraison.panel3 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(-1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 11;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 12;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			global::GMAO.livraison.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.livraison.panel3.Name = "panel3";
			global::GMAO.livraison.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.livraison.panel3.TabIndex = 13;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.livraison.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "livraison";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.livraison_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x0400120C RID: 4620
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400120D RID: 4621
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400120E RID: 4622
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400120F RID: 4623
		public static global::System.Windows.Forms.Panel panel3;
	}
}
