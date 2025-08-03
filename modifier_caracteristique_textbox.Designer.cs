namespace GMAO
{
	// Token: 0x0200009B RID: 155
	public partial class modifier_caracteristique_textbox : global::System.Windows.Forms.Form
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x00134C14 File Offset: 0x00132E14
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00134C4C File Offset: 0x00132E4C
		private void InitializeComponent()
		{
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radCheckBox1 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.ComboBox2 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radCheckBox1.BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(145, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(49, 19);
			this.label6.TabIndex = 15;
			this.label6.Text = "label6";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(136, 19);
			this.label4.TabIndex = 14;
			this.label4.Text = "ID caractéristique :";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(12, 37);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(166, 19);
			this.label1.TabIndex = 75;
			this.label1.Text = "Modifier Caractéristique";
			this.radCheckBox1.CheckAlignment = global::System.Drawing.ContentAlignment.MiddleRight;
			this.radCheckBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radCheckBox1.Location = new global::System.Drawing.Point(302, 98);
			this.radCheckBox1.Name = "radCheckBox1";
			this.radCheckBox1.Size = new global::System.Drawing.Size(145, 18);
			this.radCheckBox1.TabIndex = 84;
			this.radCheckBox1.Text = "Champs Obligatoire";
			this.radCheckBox1.ThemeName = "Crystal";
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
			this.TextBox1.Location = new global::System.Drawing.Point(12, 87);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(284, 29);
			this.TextBox1.TabIndex = 83;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(8, 65);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(39, 19);
			this.label3.TabIndex = 82;
			this.label3.Text = "Nom";
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.ComboBox2);
			this.panel1.Controls.Add(this.TextBox2);
			this.panel1.Location = new global::System.Drawing.Point(12, 123);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(617, 85);
			this.panel1.TabIndex = 88;
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
			this.ComboBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.ComboBox2.BorderRadius = 2;
			this.ComboBox2.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.ComboBox2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox2.FocusedColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.ComboBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.ComboBox2.FocusedState.Parent = this.ComboBox2;
			this.ComboBox2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ComboBox2.ForeColor = global::System.Drawing.Color.FromArgb(125, 137, 149);
			this.ComboBox2.HoverState.Parent = this.ComboBox2;
			this.ComboBox2.ItemHeight = 24;
			this.ComboBox2.ItemsAppearance.Parent = this.ComboBox2;
			this.ComboBox2.Location = new global::System.Drawing.Point(10, 31);
			this.ComboBox2.Name = "ComboBox2";
			this.ComboBox2.ShadowDecoration.Parent = this.ComboBox2;
			this.ComboBox2.Size = new global::System.Drawing.Size(274, 30);
			this.ComboBox2.TabIndex = 84;
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
			this.TextBox2.Location = new global::System.Drawing.Point(304, 32);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(274, 29);
			this.TextBox2.TabIndex = 83;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(471, 86);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 89;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(807, 276);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radCheckBox1);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Name = "modifier_caracteristique_textbox";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.modifier_caracteristique_textbox_Load);
			this.radCheckBox1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000987 RID: 2439
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000988 RID: 2440
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000989 RID: 2441
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400098A RID: 2442
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400098B RID: 2443
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox1;

		// Token: 0x0400098C RID: 2444
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400098D RID: 2445
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400098E RID: 2446
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400098F RID: 2447
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000990 RID: 2448
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000991 RID: 2449
		public global::Guna.UI2.WinForms.Guna2ComboBox ComboBox2;

		// Token: 0x04000992 RID: 2450
		public global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000993 RID: 2451
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
