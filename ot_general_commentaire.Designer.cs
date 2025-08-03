namespace GMAO
{
	// Token: 0x020000BB RID: 187
	public partial class ot_general_commentaire : global::System.Windows.Forms.Form
	{
		// Token: 0x06000873 RID: 2163 RVA: 0x00168AE8 File Offset: 0x00166CE8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00168B20 File Offset: 0x00166D20
		private void InitializeComponent()
		{
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radButton1.BeginInit();
			base.SuspendLayout();
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(912, 145);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 278;
			this.radButton1.Text = "Modifier";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.TextBox1.BorderRadius = 2;
			this.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox1.DefaultText = "";
			this.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.DisabledState.Parent = this.TextBox1;
			this.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.FocusedState.Parent = this.TextBox1;
			this.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.HoverState.Parent = this.TextBox1;
			this.TextBox1.Location = new global::System.Drawing.Point(12, 33);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(1010, 106);
			this.TextBox1.TabIndex = 277;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 12);
			this.label1.TabIndex = 279;
			this.label1.Text = "Commentaire";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.TextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_general_commentaire";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_general_commentaire_Load);
			this.radButton1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000B80 RID: 2944
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B81 RID: 2945
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000B82 RID: 2946
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000B83 RID: 2947
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000B84 RID: 2948
		internal global::System.Windows.Forms.Label label1;
	}
}
