namespace GMAO
{
	// Token: 0x0200015D RID: 349
	public partial class refuser_un_da : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F5F RID: 3935 RVA: 0x00251834 File Offset: 0x0024FA34
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x0025186C File Offset: 0x0024FA6C
		private void InitializeComponent()
		{
			this.label4 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			base.SuspendLayout();
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(54, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Id DA :";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(65, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(75, 19);
			this.label6.TabIndex = 10;
			this.label6.Text = "Id Parent :";
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
			this.TextBox1.Location = new global::System.Drawing.Point(16, 64);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(438, 92);
			this.TextBox1.TabIndex = 12;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(107, 19);
			this.label2.TabIndex = 11;
			this.label2.Text = "Cause de refus";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(350, 162);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 13;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(489, 216);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Name = "refuser_un_da";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.refuser_un_da_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400136B RID: 4971
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400136C RID: 4972
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400136D RID: 4973
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400136E RID: 4974
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400136F RID: 4975
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04001370 RID: 4976
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
