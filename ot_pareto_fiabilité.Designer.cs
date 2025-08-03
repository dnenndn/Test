namespace GMAO
{
	// Token: 0x020000CC RID: 204
	public partial class ot_pareto_fiabilité : global::System.Windows.Forms.Form
	{
		// Token: 0x0600092A RID: 2346 RVA: 0x0017D864 File Offset: 0x0017BA64
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0017D89C File Offset: 0x0017BA9C
		private void InitializeComponent()
		{
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton5 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton6 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.radRadioButton5.BeginInit();
			this.radRadioButton4.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radRadioButton3.BeginInit();
			this.radRadioButton6.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.radRadioButton6);
			this.panel1.Controls.Add(this.radRadioButton3);
			this.panel1.Controls.Add(this.radRadioButton5);
			this.panel1.Controls.Add(this.radRadioButton4);
			this.panel1.Controls.Add(this.radRadioButton2);
			this.panel1.Controls.Add(this.radRadioButton1);
			this.panel1.Location = new global::System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1068, 25);
			this.panel1.TabIndex = 1;
			this.radRadioButton5.Location = new global::System.Drawing.Point(258, 4);
			this.radRadioButton5.Name = "radRadioButton5";
			this.radRadioButton5.Size = new global::System.Drawing.Size(58, 18);
			this.radRadioButton5.TabIndex = 5;
			this.radRadioButton5.TabStop = false;
			this.radRadioButton5.Text = "Organe";
			this.radRadioButton5.ThemeName = "Fluent";
			this.radRadioButton5.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton5_ToggleStateChanged);
			this.radRadioButton4.Location = new global::System.Drawing.Point(144, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(108, 18);
			this.radRadioButton4.TabIndex = 4;
			this.radRadioButton4.TabStop = false;
			this.radRadioButton4.Text = "Sous equipement";
			this.radRadioButton4.ThemeName = "Fluent";
			this.radRadioButton4.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton4_ToggleStateChanged);
			this.radRadioButton2.Location = new global::System.Drawing.Point(89, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(51, 18);
			this.radRadioButton2.TabIndex = 2;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Zones";
			this.radRadioButton2.ThemeName = "Fluent";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(81, 18);
			this.radRadioButton1.TabIndex = 1;
			this.radRadioButton1.Text = "Equipement";
			this.radRadioButton1.ThemeName = "Fluent";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.radRadioButton3.Location = new global::System.Drawing.Point(322, 4);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(125, 18);
			this.radRadioButton3.TabIndex = 6;
			this.radRadioButton3.TabStop = false;
			this.radRadioButton3.Text = "Classe d'intervention";
			this.radRadioButton3.ThemeName = "Fluent";
			this.radRadioButton3.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton3_ToggleStateChanged);
			this.radRadioButton6.Location = new global::System.Drawing.Point(453, 4);
			this.radRadioButton6.Name = "radRadioButton6";
			this.radRadioButton6.Size = new global::System.Drawing.Size(76, 18);
			this.radRadioButton6.TabIndex = 7;
			this.radRadioButton6.TabStop = false;
			this.radRadioButton6.Text = "Défaillance";
			this.radRadioButton6.ThemeName = "Fluent";
			this.radRadioButton6.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton6_ToggleStateChanged);
			this.panel2.Location = new global::System.Drawing.Point(2, 29);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1098, 430);
			this.panel2.TabIndex = 2;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1102, 460);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_pareto_fiabilité";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_pareto_fiabilité_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton5.EndInit();
			this.radRadioButton4.EndInit();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radRadioButton3.EndInit();
			this.radRadioButton6.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000C3E RID: 3134
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C3F RID: 3135
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C40 RID: 3136
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C41 RID: 3137
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000C42 RID: 3138
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton5;

		// Token: 0x04000C43 RID: 3139
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000C44 RID: 3140
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000C45 RID: 3141
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000C46 RID: 3142
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x04000C47 RID: 3143
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton6;

		// Token: 0x04000C48 RID: 3144
		private global::System.Windows.Forms.Panel panel2;
	}
}
