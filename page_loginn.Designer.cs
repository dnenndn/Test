namespace GMAO
{
	// Token: 0x0200014D RID: 333
	public partial class page_loginn : global::System.Windows.Forms.Form
	{
		// Token: 0x06000EF3 RID: 3827 RVA: 0x00240684 File Offset: 0x0023E884
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x002406BC File Offset: 0x0023E8BC
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.label10 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.materialTheme1 = new global::Telerik.WinControls.Themes.MaterialTheme();
			this.panel1.SuspendLayout();
			this.radDropDownList1.BeginInit();
			base.SuspendLayout();
			this.panel1.BackgroundImage = global::GMAO.Properties.Resources.arriere_plan_gmao;
			this.panel1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.radDropDownList1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Controls.Add(this.TextBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new global::System.Drawing.Point(-4, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1137, 623);
			this.panel1.TabIndex = 168;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(355, 193);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(96, 19);
			this.label1.TabIndex = 434;
			this.label1.Text = "Configuration";
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(359, 217);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(267, 36);
			this.radDropDownList1.TabIndex = 433;
			this.radDropDownList1.ThemeName = "Material";
			this.radDropDownList1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged);
			this.button1.BackColor = global::System.Drawing.Color.Transparent;
			this.button1.BorderRadius = 8;
			this.button1.CheckedState.Parent = this.button1;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.CustomImages.Parent = this.button1;
			this.button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.HoverState.Parent = this.button1;
			this.button1.Location = new global::System.Drawing.Point(643, 222);
			this.button1.Name = "button1";
			this.button1.ShadowDecoration.Parent = this.button1;
			this.button1.Size = new global::System.Drawing.Size(104, 29);
			this.button1.TabIndex = 161;
			this.button1.Text = "Connecter";
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label10.AutoSize = true;
			this.label10.BackColor = global::System.Drawing.Color.Transparent;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(355, 52);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(77, 19);
			this.label10.TabIndex = 102;
			this.label10.Text = "Utilisateur";
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
			this.TextBox1.Location = new global::System.Drawing.Point(359, 74);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox1.TabIndex = 103;
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
			this.TextBox2.Location = new global::System.Drawing.Point(359, 143);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox2.TabIndex = 106;
			this.TextBox2.UseSystemPasswordChar = true;
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(355, 121);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(97, 19);
			this.label3.TabIndex = 105;
			this.label3.Text = "Mot de passe";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1130, 620);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "page_loginn";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.page_loginn_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radDropDownList1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040012B4 RID: 4788
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040012B5 RID: 4789
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x040012B6 RID: 4790
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040012B7 RID: 4791
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040012B8 RID: 4792
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040012B9 RID: 4793
		public global::System.Windows.Forms.Panel panel1;

		// Token: 0x040012BA RID: 4794
		public global::Guna.UI2.WinForms.Guna2Button button1;

		// Token: 0x040012BB RID: 4795
		private global::Telerik.WinControls.Themes.MaterialTheme materialTheme1;

		// Token: 0x040012BC RID: 4796
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040012BD RID: 4797
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;
	}
}
