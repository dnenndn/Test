namespace GMAO
{
	// Token: 0x0200014C RID: 332
	public partial class open_pdf_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000EEA RID: 3818 RVA: 0x0024009C File Offset: 0x0023E29C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x002400D4 File Offset: 0x0023E2D4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.open_pdf_equipement));
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radPdfViewer1 = new global::Telerik.WinControls.UI.RadPdfViewer();
			this.fluentDarkTheme1 = new global::Telerik.WinControls.Themes.FluentDarkTheme();
			this.radPdfViewerNavigator1 = new global::Telerik.WinControls.UI.RadPdfViewerNavigator();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radPdfViewer1.BeginInit();
			this.radPdfViewerNavigator1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.radPdfViewer1.EnableThumbnails = false;
			this.radPdfViewer1.Location = new global::System.Drawing.Point(2, 73);
			this.radPdfViewer1.Name = "radPdfViewer1";
			this.radPdfViewer1.Size = new global::System.Drawing.Size(648, 458);
			this.radPdfViewer1.TabIndex = 64;
			this.radPdfViewer1.ThemeName = "Fluent";
			this.radPdfViewer1.ThumbnailsScaleFactor = 0.15f;
			this.radPdfViewerNavigator1.AssociatedViewer = this.radPdfViewer1;
			this.radPdfViewerNavigator1.Location = new global::System.Drawing.Point(2, 28);
			this.radPdfViewerNavigator1.Name = "radPdfViewerNavigator1";
			this.radPdfViewerNavigator1.Size = new global::System.Drawing.Size(648, 40);
			this.radPdfViewerNavigator1.TabIndex = 1;
			this.radPdfViewerNavigator1.ThemeName = "Fluent";
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(64, 24);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 65;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(662, 531);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.radPdfViewerNavigator1);
			base.Controls.Add(this.radPdfViewer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "open_pdf_equipement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.open_pdf_equipement_Load);
			this.radPdfViewer1.EndInit();
			this.radPdfViewerNavigator1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040012A9 RID: 4777
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040012AA RID: 4778
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040012AB RID: 4779
		private global::Telerik.WinControls.UI.RadPdfViewer radPdfViewer1;

		// Token: 0x040012AC RID: 4780
		private global::Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;

		// Token: 0x040012AD RID: 4781
		private global::Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator1;

		// Token: 0x040012AE RID: 4782
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
