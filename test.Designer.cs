namespace GMAO
{
	// Token: 0x0200016A RID: 362
	public partial class test : global::System.Windows.Forms.Form
	{
		// Token: 0x06001053 RID: 4179 RVA: 0x002940CC File Offset: 0x002922CC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x00294104 File Offset: 0x00292304
		private void InitializeComponent()
		{
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			this.radTextBox1 = new global::Telerik.WinControls.UI.RadTextBox();
			this.radTextBox1.BeginInit();
			base.SuspendLayout();
			this.radTextBox1.Location = new global::System.Drawing.Point(361, 125);
			this.radTextBox1.Name = "radTextBox1";
			this.radTextBox1.Size = new global::System.Drawing.Size(254, 24);
			this.radTextBox1.TabIndex = 0;
			this.radTextBox1.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1370, 749);
			base.Controls.Add(this.radTextBox1);
			base.Name = "test";
			this.Text = "test";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new global::System.EventHandler(this.test_Load);
			this.radTextBox1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001451 RID: 5201
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001452 RID: 5202
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;

		// Token: 0x04001453 RID: 5203
		private global::Telerik.WinControls.UI.RadTextBox radTextBox1;
	}
}
