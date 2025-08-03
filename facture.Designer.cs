namespace GMAO
{
	// Token: 0x02000075 RID: 117
	public partial class facture : global::System.Windows.Forms.Form
	{
		// Token: 0x06000571 RID: 1393 RVA: 0x000E3B64 File Offset: 0x000E1D64
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x000E3B9C File Offset: 0x000E1D9C
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.facture.panel3 = new global::System.Windows.Forms.Panel();
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
			global::GMAO.facture.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.facture.panel3.Name = "panel3";
			global::GMAO.facture.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.facture.panel3.TabIndex = 12;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.facture.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "facture";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.facture_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000738 RID: 1848
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000739 RID: 1849
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400073A RID: 1850
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400073B RID: 1851
		public static global::System.Windows.Forms.Panel panel3;
	}
}
