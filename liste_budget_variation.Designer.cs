namespace GMAO
{
	// Token: 0x0200008B RID: 139
	public partial class liste_budget_variation : global::System.Windows.Forms.Form
	{
		// Token: 0x06000686 RID: 1670 RVA: 0x0011C120 File Offset: 0x0011A320
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0011C158 File Offset: 0x0011A358
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.AutoScroll = true;
			this.radChartView1.Location = new global::System.Drawing.Point(12, 4);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.ShowTrackBall = true;
			this.radChartView1.Size = new global::System.Drawing.Size(1063, 215);
			this.radChartView1.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(234, 234, 234);
			base.ClientSize = new global::System.Drawing.Size(1099, 222);
			base.Controls.Add(this.radChartView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_budget_variation";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_budget_variation_Load);
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040008A9 RID: 2217
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040008AA RID: 2218
		private global::Telerik.WinControls.UI.RadChartView radChartView1;
	}
}
