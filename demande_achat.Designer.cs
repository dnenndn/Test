namespace GMAO
{
	// Token: 0x02000063 RID: 99
	public partial class demande_achat : global::System.Windows.Forms.Form
	{
		// Token: 0x060004A5 RID: 1189 RVA: 0x000C547C File Offset: 0x000C367C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x000C54B4 File Offset: 0x000C36B4
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.demande_achat.panel3 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 8;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 9;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			global::GMAO.demande_achat.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.demande_achat.panel3.Name = "panel3";
			global::GMAO.demande_achat.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.demande_achat.panel3.TabIndex = 10;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.demande_achat.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "demande_achat";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.demande_achat_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000611 RID: 1553
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000612 RID: 1554
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000613 RID: 1555
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000614 RID: 1556
		public static global::System.Windows.Forms.Panel panel3;
	}
}
