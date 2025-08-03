namespace GMAO
{
	// Token: 0x02000036 RID: 54
	public partial class caractéristique_textbox : global::System.Windows.Forms.Form
	{
		// Token: 0x0600027C RID: 636 RVA: 0x0006A740 File Offset: 0x00068940
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0006A778 File Offset: 0x00068978
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			global::GMAO.caractéristique_textbox.ComboBox2 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			global::GMAO.caractéristique_textbox.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(global::GMAO.caractéristique_textbox.ComboBox2);
			this.panel1.Controls.Add(global::GMAO.caractéristique_textbox.TextBox2);
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(617, 85);
			this.panel1.TabIndex = 87;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(6, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(118, 19);
			this.label2.TabIndex = 80;
			this.label2.Text = "Type de données";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(300, 10);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(121, 19);
			this.label8.TabIndex = 82;
			this.label8.Text = "Valeur par défaut";
			global::GMAO.caractéristique_textbox.ComboBox2.BackColor = global::System.Drawing.Color.Transparent;
			global::GMAO.caractéristique_textbox.ComboBox2.BorderRadius = 2;
			global::GMAO.caractéristique_textbox.ComboBox2.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawFixed;
			global::GMAO.caractéristique_textbox.ComboBox2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			global::GMAO.caractéristique_textbox.ComboBox2.FocusedColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.caractéristique_textbox.ComboBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.caractéristique_textbox.ComboBox2.FocusedState.Parent = global::GMAO.caractéristique_textbox.ComboBox2;
			global::GMAO.caractéristique_textbox.ComboBox2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.caractéristique_textbox.ComboBox2.ForeColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			global::GMAO.caractéristique_textbox.ComboBox2.HoverState.Parent = global::GMAO.caractéristique_textbox.ComboBox2;
			global::GMAO.caractéristique_textbox.ComboBox2.ItemHeight = 24;
			global::GMAO.caractéristique_textbox.ComboBox2.ItemsAppearance.Parent = global::GMAO.caractéristique_textbox.ComboBox2;
			global::GMAO.caractéristique_textbox.ComboBox2.Location = new global::System.Drawing.Point(10, 31);
			global::GMAO.caractéristique_textbox.ComboBox2.Name = "ComboBox2";
			global::GMAO.caractéristique_textbox.ComboBox2.ShadowDecoration.Parent = global::GMAO.caractéristique_textbox.ComboBox2;
			global::GMAO.caractéristique_textbox.ComboBox2.Size = new global::System.Drawing.Size(274, 30);
			global::GMAO.caractéristique_textbox.ComboBox2.TabIndex = 84;
			global::GMAO.caractéristique_textbox.TextBox2.BorderRadius = 2;
			global::GMAO.caractéristique_textbox.TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			global::GMAO.caractéristique_textbox.TextBox2.DefaultText = "";
			global::GMAO.caractéristique_textbox.TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			global::GMAO.caractéristique_textbox.TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			global::GMAO.caractéristique_textbox.TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.caractéristique_textbox.TextBox2.DisabledState.Parent = global::GMAO.caractéristique_textbox.TextBox2;
			global::GMAO.caractéristique_textbox.TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.caractéristique_textbox.TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.caractéristique_textbox.TextBox2.FocusedState.Parent = global::GMAO.caractéristique_textbox.TextBox2;
			global::GMAO.caractéristique_textbox.TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			global::GMAO.caractéristique_textbox.TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.caractéristique_textbox.TextBox2.HoverState.Parent = global::GMAO.caractéristique_textbox.TextBox2;
			global::GMAO.caractéristique_textbox.TextBox2.Location = new global::System.Drawing.Point(304, 32);
			global::GMAO.caractéristique_textbox.TextBox2.Name = "TextBox2";
			global::GMAO.caractéristique_textbox.TextBox2.PasswordChar = '\0';
			global::GMAO.caractéristique_textbox.TextBox2.PlaceholderText = "";
			global::GMAO.caractéristique_textbox.TextBox2.SelectedText = "";
			global::GMAO.caractéristique_textbox.TextBox2.ShadowDecoration.Parent = global::GMAO.caractéristique_textbox.TextBox2;
			global::GMAO.caractéristique_textbox.TextBox2.Size = new global::System.Drawing.Size(274, 29);
			global::GMAO.caractéristique_textbox.TextBox2.TabIndex = 83;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(652, 105);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "caractéristique_textbox";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.caractéristique_textbox_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000351 RID: 849
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000352 RID: 850
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000353 RID: 851
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000354 RID: 852
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000355 RID: 853
		public static global::Guna.UI2.WinForms.Guna2ComboBox ComboBox2;

		// Token: 0x04000356 RID: 854
		public static global::Guna.UI2.WinForms.Guna2TextBox TextBox2;
	}
}
