namespace GMAO
{
	// Token: 0x020000C4 RID: 196
	public partial class ot_kpi_zone : global::System.Windows.Forms.Form
	{
		// Token: 0x060008C7 RID: 2247 RVA: 0x0017457C File Offset: 0x0017277C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x001745B4 File Offset: 0x001727B4
		private void InitializeComponent()
		{
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel1.AutoScroll = true;
			this.panel1.Location = new global::System.Drawing.Point(3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1091, 449);
			this.panel1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1100, 454);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_kpi_zone";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_kpi_zone_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04000BDE RID: 3038
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000BDF RID: 3039
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000BE0 RID: 3040
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000BE1 RID: 3041
		private global::System.Windows.Forms.Panel panel1;
	}
}
