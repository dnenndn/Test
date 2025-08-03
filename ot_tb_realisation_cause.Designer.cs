namespace GMAO
{
	// Token: 0x020000E1 RID: 225
	public partial class ot_tb_realisation_cause : global::System.Windows.Forms.Form
	{
		// Token: 0x060009E7 RID: 2535 RVA: 0x0018E780 File Offset: 0x0018C980
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0018E7B8 File Offset: 0x0018C9B8
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(7, 12);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1088, 443);
			this.radChartView1.TabIndex = 2;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 457);
			base.Controls.Add(this.radChartView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb_realisation_cause";
			base.ShowInTaskbar = false;
			base.Load += new global::System.EventHandler(this.ot_tb_realisation_cause_Load);
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000CE2 RID: 3298
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CE3 RID: 3299
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000CE4 RID: 3300
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000CE5 RID: 3301
		private global::Telerik.WinControls.UI.RadChartView radChartView1;
	}
}
