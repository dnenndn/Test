namespace GMAO
{
	// Token: 0x0200002E RID: 46
	public partial class bon_dop : global::System.Windows.Forms.Form
	{
		// Token: 0x06000243 RID: 579 RVA: 0x00062ED8 File Offset: 0x000610D8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00062F10 File Offset: 0x00061110
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.bon_dop));
			this.radRichTextEditor1 = new global::Telerik.WinControls.UI.RadRichTextEditor();
			this.richTextEditorRibbonBar1 = new global::Telerik.WinControls.UI.RichTextEditorRibbonBar();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radRichTextEditor1.BeginInit();
			this.richTextEditorRibbonBar1.BeginInit();
			base.SuspendLayout();
			this.radRichTextEditor1.AutoScroll = true;
			this.radRichTextEditor1.BorderColor = global::System.Drawing.Color.FromArgb(156, 189, 232);
			this.radRichTextEditor1.LayoutMode = new global::Telerik.WinForms.Documents.Model.DocumentLayoutMode?(0);
			this.radRichTextEditor1.Location = new global::System.Drawing.Point(12, 180);
			this.radRichTextEditor1.Name = "radRichTextEditor1";
			this.radRichTextEditor1.SelectionFill = global::System.Drawing.Color.FromArgb(128, 78, 158, 255);
			this.radRichTextEditor1.SelectionStroke = global::System.Drawing.Color.FromArgb(179, 236, 248);
			this.radRichTextEditor1.Size = new global::System.Drawing.Size(821, 465);
			this.radRichTextEditor1.TabIndex = 1;
			this.radRichTextEditor1.ThemeName = "Fluent";
			this.richTextEditorRibbonBar1.ApplicationMenuStyle = 1;
			this.richTextEditorRibbonBar1.AssociatedRichTextEditor = this.radRichTextEditor1;
			this.richTextEditorRibbonBar1.BuiltInStylesVersion = 2;
			this.richTextEditorRibbonBar1.EnableKeyMap = false;
			this.richTextEditorRibbonBar1.ExitButton.Text = "Exit";
			this.richTextEditorRibbonBar1.LocalizationSettings.LayoutModeText = "Simplified Layout";
			this.richTextEditorRibbonBar1.Location = new global::System.Drawing.Point(0, 0);
			this.richTextEditorRibbonBar1.Name = "richTextEditorRibbonBar1";
			this.richTextEditorRibbonBar1.OptionsButton.Text = "Options";
			this.richTextEditorRibbonBar1.ShowLayoutModeButton = true;
			this.richTextEditorRibbonBar1.SimplifiedHeight = 100;
			this.richTextEditorRibbonBar1.Size = new global::System.Drawing.Size(852, 169);
			this.richTextEditorRibbonBar1.StartButtonImage = (global::System.Drawing.Image)componentResourceManager.GetObject("richTextEditorRibbonBar1.StartButtonImage");
			this.richTextEditorRibbonBar1.TabIndex = 2;
			this.richTextEditorRibbonBar1.TabStop = false;
			this.richTextEditorRibbonBar1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(852, 647);
			base.Controls.Add(this.richTextEditorRibbonBar1);
			base.Controls.Add(this.radRichTextEditor1);
			base.Name = "bon_dop";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.bon_dop_Load);
			this.radRichTextEditor1.EndInit();
			this.richTextEditorRibbonBar1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000317 RID: 791
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000318 RID: 792
		private global::Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;

		// Token: 0x04000319 RID: 793
		private global::Telerik.WinControls.UI.RichTextEditorRibbonBar richTextEditorRibbonBar1;

		// Token: 0x0400031A RID: 794
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
