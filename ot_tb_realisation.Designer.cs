namespace GMAO
{
	// Token: 0x020000E0 RID: 224
	public partial class ot_tb_realisation : global::System.Windows.Forms.Form
	{
		// Token: 0x060009DF RID: 2527 RVA: 0x0018E09C File Offset: 0x0018C29C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0018E0D4 File Offset: 0x0018C2D4
		private void InitializeComponent()
		{
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.radRadioButton2);
			this.panel1.Controls.Add(this.radRadioButton1);
			this.panel1.Location = new global::System.Drawing.Point(4, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(908, 25);
			this.panel1.TabIndex = 3;
			this.radRadioButton2.Location = new global::System.Drawing.Point(96, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(149, 18);
			this.radRadioButton2.TabIndex = 2;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Causes de non réalisation";
			this.radRadioButton2.ThemeName = "Fluent";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(87, 18);
			this.radRadioButton1.TabIndex = 1;
			this.radRadioButton1.Text = "OT en Retard";
			this.radRadioButton1.ThemeName = "Fluent";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.panel2.Location = new global::System.Drawing.Point(4, 30);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1098, 457);
			this.panel2.TabIndex = 4;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb_realisation";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tb_realisation_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000CDB RID: 3291
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CDC RID: 3292
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000CDD RID: 3293
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000CDE RID: 3294
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000CDF RID: 3295
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000CE0 RID: 3296
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000CE1 RID: 3297
		private global::System.Windows.Forms.Panel panel2;
	}
}
