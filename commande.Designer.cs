namespace GMAO
{
	// Token: 0x0200003E RID: 62
	public partial class commande : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x00072EA8 File Offset: 0x000710A8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00072EE0 File Offset: 0x000710E0
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			global::GMAO.commande.panel3 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(-1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 9;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 10;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			global::GMAO.commande.panel3.Location = new global::System.Drawing.Point(7, 42);
			global::GMAO.commande.panel3.Name = "panel3";
			global::GMAO.commande.panel3.Size = new global::System.Drawing.Size(1128, 558);
			global::GMAO.commande.panel3.TabIndex = 11;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(global::GMAO.commande.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "commande";
			base.Load += new global::System.EventHandler(this.commande_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040003A3 RID: 931
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040003A4 RID: 932
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x040003A5 RID: 933
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040003A6 RID: 934
		public static global::System.Windows.Forms.Panel panel3;
	}
}
