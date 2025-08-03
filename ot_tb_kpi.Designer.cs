namespace GMAO
{
	// Token: 0x020000DF RID: 223
	public partial class ot_tb_kpi : global::System.Windows.Forms.Form
	{
		// Token: 0x060009D8 RID: 2520 RVA: 0x0018DA04 File Offset: 0x0018BC04
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0018DA3C File Offset: 0x0018BC3C
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton5 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.radRadioButton5.BeginInit();
			this.radRadioButton4.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.radRadioButton5);
			this.panel1.Controls.Add(this.radRadioButton4);
			this.panel1.Controls.Add(this.radRadioButton2);
			this.panel1.Controls.Add(this.radRadioButton1);
			this.panel1.Location = new global::System.Drawing.Point(2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(702, 25);
			this.panel1.TabIndex = 0;
			this.radRadioButton5.Location = new global::System.Drawing.Point(334, 4);
			this.radRadioButton5.Name = "radRadioButton5";
			this.radRadioButton5.Size = new global::System.Drawing.Size(77, 18);
			this.radRadioButton5.TabIndex = 5;
			this.radRadioButton5.TabStop = false;
			this.radRadioButton5.Text = "KPI Organe";
			this.radRadioButton5.ThemeName = "Fluent";
			this.radRadioButton5.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton5_ToggleStateChanged);
			this.radRadioButton4.Location = new global::System.Drawing.Point(202, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(127, 18);
			this.radRadioButton4.TabIndex = 4;
			this.radRadioButton4.TabStop = false;
			this.radRadioButton4.Text = "KPI Sous equipement";
			this.radRadioButton4.ThemeName = "Fluent";
			this.radRadioButton4.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton4_ToggleStateChanged);
			this.radRadioButton2.Location = new global::System.Drawing.Point(106, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(90, 18);
			this.radRadioButton2.TabIndex = 2;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "KPI des zones";
			this.radRadioButton2.ThemeName = "Fluent";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(100, 18);
			this.radRadioButton1.TabIndex = 1;
			this.radRadioButton1.Text = "KPI Equipement";
			this.radRadioButton1.ThemeName = "Fluent";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.panel2.Location = new global::System.Drawing.Point(2, 34);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1100, 454);
			this.panel2.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb_kpi";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tb_kpi_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton5.EndInit();
			this.radRadioButton4.EndInit();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000CD1 RID: 3281
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CD2 RID: 3282
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000CD3 RID: 3283
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000CD4 RID: 3284
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000CD5 RID: 3285
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000CD6 RID: 3286
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000CD7 RID: 3287
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton5;

		// Token: 0x04000CD8 RID: 3288
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000CD9 RID: 3289
		private global::System.Windows.Forms.Panel panel2;
	}
}
