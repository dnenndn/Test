namespace GMAO
{
	// Token: 0x02000089 RID: 137
	public partial class liste_budget_general_tous : global::System.Windows.Forms.Form
	{
		// Token: 0x0600067A RID: 1658 RVA: 0x001165E8 File Offset: 0x001147E8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00116620 File Offset: 0x00114820
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.breezeTheme1 = new global::Telerik.WinControls.Themes.BreezeTheme();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.AutoScroll = true;
			this.radChartView1.Location = new global::System.Drawing.Point(12, 4);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.ShowTrackBall = true;
			this.radChartView1.Size = new global::System.Drawing.Size(1063, 215);
			this.radChartView1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(234, 234, 234);
			base.ClientSize = new global::System.Drawing.Size(1099, 222);
			base.Controls.Add(this.radChartView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_budget_general_tous";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_budget_general_tous_Load);
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400088E RID: 2190
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400088F RID: 2191
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04000890 RID: 2192
		private global::Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
	}
}
