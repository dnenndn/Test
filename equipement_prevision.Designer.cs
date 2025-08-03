namespace GMAO
{
	// Token: 0x02000131 RID: 305
	public partial class equipement_prevision : global::System.Windows.Forms.Form
	{
		// Token: 0x06000D6D RID: 3437 RVA: 0x00208AA4 File Offset: 0x00206CA4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00208ADC File Offset: 0x00206CDC
		private void InitializeComponent()
		{
			this.guna2ComboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label28 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label25 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			base.SuspendLayout();
			this.guna2ComboBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2ComboBox1.BorderRadius = 2;
			this.guna2ComboBox1.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.guna2ComboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.guna2ComboBox1.FocusedColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2ComboBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2ComboBox1.FocusedState.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2ComboBox1.ForeColor = global::System.Drawing.Color.FromArgb(68, 88, 112);
			this.guna2ComboBox1.HoverState.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.ItemHeight = 23;
			this.guna2ComboBox1.ItemsAppearance.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Location = new global::System.Drawing.Point(314, 89);
			this.guna2ComboBox1.Name = "guna2ComboBox1";
			this.guna2ComboBox1.ShadowDecoration.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Size = new global::System.Drawing.Size(267, 29);
			this.guna2ComboBox1.TabIndex = 68;
			this.label27.AutoSize = true;
			this.label27.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label27.ForeColor = global::System.Drawing.Color.Black;
			this.label27.Location = new global::System.Drawing.Point(310, 67);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(58, 19);
			this.label27.TabIndex = 67;
			this.label27.Text = "Période";
			this.TextBox3.BorderRadius = 2;
			this.TextBox3.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox3.DefaultText = "";
			this.TextBox3.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox3.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox3.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox3.DisabledState.Parent = this.TextBox3;
			this.TextBox3.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox3.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox3.FocusedState.Parent = this.TextBox3;
			this.TextBox3.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox3.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox3.HoverState.Parent = this.TextBox3;
			this.TextBox3.Location = new global::System.Drawing.Point(16, 89);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.PasswordChar = '\0';
			this.TextBox3.PlaceholderText = "";
			this.TextBox3.SelectedText = "";
			this.TextBox3.ShadowDecoration.Parent = this.TextBox3;
			this.TextBox3.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox3.TabIndex = 66;
			this.label28.AutoSize = true;
			this.label28.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label28.ForeColor = global::System.Drawing.Color.Black;
			this.label28.Location = new global::System.Drawing.Point(12, 67);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(110, 19);
			this.label28.TabIndex = 65;
			this.label28.Text = "Sur une période";
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
			this.TextBox2.Location = new global::System.Drawing.Point(314, 26);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox2.TabIndex = 64;
			this.label25.AutoSize = true;
			this.label25.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label25.ForeColor = global::System.Drawing.Color.Black;
			this.label25.Location = new global::System.Drawing.Point(310, 4);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(107, 19);
			this.label25.TabIndex = 63;
			this.label25.Text = "Nombre d'arrêt";
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
			this.TextBox1.Location = new global::System.Drawing.Point(16, 26);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox1.TabIndex = 62;
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.ForeColor = global::System.Drawing.Color.Black;
			this.label26.Location = new global::System.Drawing.Point(12, 4);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(142, 19);
			this.label26.TabIndex = 61;
			this.label26.Text = "Coût d'arrêt (Dinars)";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(477, 130);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 69;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(650, 369);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.guna2ComboBox1);
			base.Controls.Add(this.label27);
			base.Controls.Add(this.TextBox3);
			base.Controls.Add(this.label28);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label25);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label26);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "equipement_prevision";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.equipement_prevision_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001111 RID: 4369
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001112 RID: 4370
		private global::Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;

		// Token: 0x04001113 RID: 4371
		private global::System.Windows.Forms.Label label27;

		// Token: 0x04001114 RID: 4372
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox3;

		// Token: 0x04001115 RID: 4373
		private global::System.Windows.Forms.Label label28;

		// Token: 0x04001116 RID: 4374
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04001117 RID: 4375
		private global::System.Windows.Forms.Label label25;

		// Token: 0x04001118 RID: 4376
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04001119 RID: 4377
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400111A RID: 4378
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
