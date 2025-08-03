namespace GMAO
{
	// Token: 0x02000122 RID: 290
	public partial class signature_commande_attente_st : global::System.Windows.Forms.Form
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x001F4418 File Offset: 0x001F2618
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x001F4450 File Offset: 0x001F2650
		private void InitializeComponent()
		{
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(185, 76);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 171;
			this.guna2Button1.Text = "Confirmer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
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
			this.TextBox2.Location = new global::System.Drawing.Point(22, 41);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox2.TabIndex = 170;
			this.TextBox2.UseSystemPasswordChar = true;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(18, 19);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(70, 19);
			this.label3.TabIndex = 169;
			this.label3.Text = "Signature";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(353, 160);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label3);
			base.Name = "signature_commande_attente_st";
			base.ShowIcon = false;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400106E RID: 4206
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400106F RID: 4207
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04001070 RID: 4208
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04001071 RID: 4209
		private global::System.Windows.Forms.Label label3;
	}
}
