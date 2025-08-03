namespace GMAO
{
	// Token: 0x0200012F RID: 303
	public partial class equipement_observation : global::System.Windows.Forms.Form
	{
		// Token: 0x06000D5C RID: 3420 RVA: 0x002076D8 File Offset: 0x002058D8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x00207710 File Offset: 0x00205910
		private void InitializeComponent()
		{
			this.label10 = new global::System.Windows.Forms.Label();
			this.guna2TextBox9 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			base.SuspendLayout();
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(12, 4);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(88, 19);
			this.label10.TabIndex = 39;
			this.label10.Text = "Observation";
			this.guna2TextBox9.BorderRadius = 2;
			this.guna2TextBox9.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox9.DefaultText = "";
			this.guna2TextBox9.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox9.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox9.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox9.DisabledState.Parent = this.guna2TextBox9;
			this.guna2TextBox9.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox9.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox9.FocusedState.Parent = this.guna2TextBox9;
			this.guna2TextBox9.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox9.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox9.HoverState.Parent = this.guna2TextBox9;
			this.guna2TextBox9.Location = new global::System.Drawing.Point(12, 35);
			this.guna2TextBox9.Multiline = true;
			this.guna2TextBox9.Name = "guna2TextBox9";
			this.guna2TextBox9.PasswordChar = '\0';
			this.guna2TextBox9.PlaceholderText = "";
			this.guna2TextBox9.SelectedText = "";
			this.guna2TextBox9.ShadowDecoration.Parent = this.guna2TextBox9;
			this.guna2TextBox9.Size = new global::System.Drawing.Size(565, 109);
			this.guna2TextBox9.TabIndex = 52;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(473, 150);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 63;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(650, 369);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.guna2TextBox9);
			base.Controls.Add(this.label10);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "equipement_observation";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.equipement_observation_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001104 RID: 4356
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001105 RID: 4357
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04001106 RID: 4358
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox9;

		// Token: 0x04001107 RID: 4359
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
