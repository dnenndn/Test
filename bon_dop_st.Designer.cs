namespace GMAO
{
	// Token: 0x0200002F RID: 47
	public partial class bon_dop_st : global::System.Windows.Forms.Form
	{
		// Token: 0x06000249 RID: 585 RVA: 0x00064480 File Offset: 0x00062680
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000644B8 File Offset: 0x000626B8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.bon_dop_st));
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.richTextEditorRibbonBar1 = new global::Telerik.WinControls.UI.RichTextEditorRibbonBar();
			this.radRichTextEditor1 = new global::Telerik.WinControls.UI.RadRichTextEditor();
			this.richTextEditorRibbonBar1.BeginInit();
			this.radRichTextEditor1.BeginInit();
			base.SuspendLayout();
			this.richTextEditorRibbonBar1.ApplicationMenuStyle = 1;
			this.richTextEditorRibbonBar1.AssociatedRichTextEditor = null;
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
			this.richTextEditorRibbonBar1.TabIndex = 3;
			this.richTextEditorRibbonBar1.TabStop = false;
			this.richTextEditorRibbonBar1.ThemeName = "Fluent";
			this.radRichTextEditor1.AutoScroll = true;
			this.radRichTextEditor1.BorderColor = global::System.Drawing.Color.FromArgb(156, 189, 232);
			this.radRichTextEditor1.LayoutMode = new global::Telerik.WinForms.Documents.Model.DocumentLayoutMode?(0);
			this.radRichTextEditor1.Location = new global::System.Drawing.Point(12, 180);
			this.radRichTextEditor1.Name = "radRichTextEditor1";
			this.radRichTextEditor1.SelectionFill = global::System.Drawing.Color.FromArgb(128, 78, 158, 255);
			this.radRichTextEditor1.SelectionStroke = global::System.Drawing.Color.FromArgb(179, 236, 248);
			this.radRichTextEditor1.Size = new global::System.Drawing.Size(821, 465);
			this.radRichTextEditor1.TabIndex = 4;
			this.radRichTextEditor1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(852, 647);
			base.Controls.Add(this.radRichTextEditor1);
			base.Controls.Add(this.richTextEditorRibbonBar1);
			base.Name = "bon_dop_st";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.bon_dop_st_Load);
			this.richTextEditorRibbonBar1.EndInit();
			this.radRichTextEditor1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400031B RID: 795
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400031C RID: 796
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400031D RID: 797
		private global::Telerik.WinControls.UI.RichTextEditorRibbonBar richTextEditorRibbonBar1;

		// Token: 0x0400031E RID: 798
		private global::Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;
	}
}
