namespace GMAO
{
	// Token: 0x020000C8 RID: 200
	public partial class ot_ordonnacement_gantt : global::System.Windows.Forms.Form
	{
		// Token: 0x060008F2 RID: 2290 RVA: 0x00179044 File Offset: 0x00177244
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0017907C File Offset: 0x0017727C
		private void InitializeComponent()
		{
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGanttView1 = new global::Telerik.WinControls.UI.RadGanttView();
			this.radGanttView1.BeginInit();
			base.SuspendLayout();
			this.radGanttView1.AutoScroll = true;
			this.radGanttView1.ItemHeight = 30;
			this.radGanttView1.Location = new global::System.Drawing.Point(12, 8);
			this.radGanttView1.Name = "radGanttView1";
			this.radGanttView1.ReadOnly = true;
			this.radGanttView1.ShowTimelineTodayIndicator = false;
			this.radGanttView1.ShowTodayIndicator = false;
			this.radGanttView1.Size = new global::System.Drawing.Size(1050, 223);
			this.radGanttView1.SplitterWidth = 8;
			this.radGanttView1.TabIndex = 0;
			this.radGanttView1.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.radGanttView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_ordonnacement_gantt";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_ordonnacement_gantt_Load);
			this.radGanttView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000C0F RID: 3087
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C10 RID: 3088
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C11 RID: 3089
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C12 RID: 3090
		private global::Telerik.WinControls.UI.RadGanttView radGanttView1;
	}
}
