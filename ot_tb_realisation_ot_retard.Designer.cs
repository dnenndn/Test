namespace GMAO
{
	// Token: 0x020000E2 RID: 226
	public partial class ot_tb_realisation_ot_retard : global::System.Windows.Forms.Form
	{
		// Token: 0x060009EC RID: 2540 RVA: 0x0018F10C File Offset: 0x0018D30C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0018F144 File Offset: 0x0018D344
		private void InitializeComponent()
		{
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.radChartView1.AreaType = 4;
			this.radChartView1.Location = new global::System.Drawing.Point(7, 12);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1088, 443);
			this.radChartView1.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 457);
			base.Controls.Add(this.radChartView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb_realisation_ot_retard";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tb_realisation_ot_retard_Load);
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000CE6 RID: 3302
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CE7 RID: 3303
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000CE8 RID: 3304
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000CE9 RID: 3305
		private global::Telerik.WinControls.UI.RadChartView radChartView1;
	}
}
