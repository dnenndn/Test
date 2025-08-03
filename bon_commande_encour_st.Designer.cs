namespace GMAO
{
	// Token: 0x0200002D RID: 45
	public partial class bon_commande_encour_st : global::System.Windows.Forms.Form
	{
		// Token: 0x0600023D RID: 573 RVA: 0x00061C28 File Offset: 0x0005FE28
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00061C60 File Offset: 0x0005FE60
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.bon_commande_encour_st));
			this.richTextEditorRibbonBar1 = new global::Telerik.WinControls.UI.RichTextEditorRibbonBar();
			this.radRichTextEditor1 = new global::Telerik.WinControls.UI.RadRichTextEditor();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
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
			this.richTextEditorRibbonBar1.TabIndex = 2;
			this.richTextEditorRibbonBar1.TabStop = false;
			this.richTextEditorRibbonBar1.ThemeName = "Fluent";
			this.radRichTextEditor1.AutoScroll = true;
			this.radRichTextEditor1.BorderColor = global::System.Drawing.Color.FromArgb(156, 189, 232);
			this.radRichTextEditor1.LayoutMode = new global::Telerik.WinForms.Documents.Model.DocumentLayoutMode?(0);
			this.radRichTextEditor1.Location = new global::System.Drawing.Point(6, 175);
			this.radRichTextEditor1.Name = "radRichTextEditor1";
			this.radRichTextEditor1.SelectionFill = global::System.Drawing.Color.FromArgb(128, 78, 158, 255);
			this.radRichTextEditor1.SelectionStroke = global::System.Drawing.Color.FromArgb(179, 236, 248);
			this.radRichTextEditor1.Size = new global::System.Drawing.Size(821, 465);
			this.radRichTextEditor1.TabIndex = 3;
			this.radRichTextEditor1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(852, 647);
			base.Controls.Add(this.radRichTextEditor1);
			base.Controls.Add(this.richTextEditorRibbonBar1);
			base.Name = "bon_commande_encour_st";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.bon_commande_encour_st_Load);
			this.richTextEditorRibbonBar1.EndInit();
			this.radRichTextEditor1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000313 RID: 787
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000314 RID: 788
		private global::Telerik.WinControls.UI.RichTextEditorRibbonBar richTextEditorRibbonBar1;

		// Token: 0x04000315 RID: 789
		private global::Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;

		// Token: 0x04000316 RID: 790
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
