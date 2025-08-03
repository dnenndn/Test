namespace GMAO
{
	// Token: 0x02000066 RID: 102
	public partial class devis : global::System.Windows.Forms.Form
	{
		// Token: 0x060004E2 RID: 1250 RVA: 0x000D24BC File Offset: 0x000D06BC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x000D24F4 File Offset: 0x000D06F4
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.devis.panel3 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(-1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 10;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 11;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			global::GMAO.devis.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.devis.panel3.Name = "panel3";
			global::GMAO.devis.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.devis.panel3.TabIndex = 12;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.devis.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "devis";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.devis_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000680 RID: 1664
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000681 RID: 1665
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000682 RID: 1666
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000683 RID: 1667
		public static global::System.Windows.Forms.Panel panel3;
	}
}
