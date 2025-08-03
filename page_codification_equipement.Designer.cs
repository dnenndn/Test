namespace GMAO
{
	// Token: 0x020000ED RID: 237
	public partial class page_codification_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A4F RID: 2639 RVA: 0x00199748 File Offset: 0x00197948
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00199780 File Offset: 0x00197980
		private void InitializeComponent()
		{
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.ProgressBar1 = new global::Bunifu.Framework.UI.BunifuProgressBar();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
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
			this.TextBox1.Location = new global::System.Drawing.Point(22, 43);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(264, 29);
			this.TextBox1.TabIndex = 68;
			this.TextBox2.BorderRadius = 2;
			this.TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox2.DefaultText = "";
			this.TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.DisabledState.Parent = this.TextBox2;
			this.TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.FocusedState.Parent = this.TextBox2;
			this.TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.HoverState.Parent = this.TextBox2;
			this.TextBox2.Location = new global::System.Drawing.Point(22, 106);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(264, 29);
			this.TextBox2.TabIndex = 72;
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(303, 106);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button2.TabIndex = 75;
			this.guna2Button2.Text = "Button";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.ProgressBar1.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.ProgressBar1.BorderRadius = 5;
			this.ProgressBar1.Location = new global::System.Drawing.Point(22, 176);
			this.ProgressBar1.MaximumValue = 100;
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.ProgressColor = global::System.Drawing.Color.Firebrick;
			this.ProgressBar1.Size = new global::System.Drawing.Size(410, 20);
			this.ProgressBar1.TabIndex = 233;
			this.ProgressBar1.Value = 0;
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.Black;
			this.label20.Location = new global::System.Drawing.Point(19, 25);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(125, 15);
			this.label20.TabIndex = 234;
			this.label20.Text = "ID equipement parent";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(19, 88);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(107, 15);
			this.label1.TabIndex = 235;
			this.label1.Text = "Text à incrementer";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(662, 346);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label20);
			base.Controls.Add(this.ProgressBar1);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.TextBox1);
			base.Name = "page_codification_equipement";
			this.Text = "page_codification_equipement";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000D50 RID: 3408
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D51 RID: 3409
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000D52 RID: 3410
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000D53 RID: 3411
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04000D54 RID: 3412
		private global::Bunifu.Framework.UI.BunifuProgressBar ProgressBar1;

		// Token: 0x04000D55 RID: 3413
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000D56 RID: 3414
		private global::System.Windows.Forms.Label label1;
	}
}
