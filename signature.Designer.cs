namespace GMAO
{
	// Token: 0x0200015F RID: 351
	public partial class signature : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F6B RID: 3947 RVA: 0x00252CEC File Offset: 0x00250EEC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00252D24 File Offset: 0x00250F24
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.guna2TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.guna2TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(86, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Signature";
			this.panel1.Location = new global::System.Drawing.Point(-3, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 5;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel2.Controls.Add(this.guna2Button1);
			this.panel2.Controls.Add(this.guna2TextBox1);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.TextBox2);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new global::System.Drawing.Point(12, 58);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(326, 304);
			this.panel2.TabIndex = 6;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(3, 24);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(70, 19);
			this.label3.TabIndex = 100;
			this.label3.Text = "Signature";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(73, 24);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(227, 13);
			this.label2.TabIndex = 101;
			this.label2.Text = "(La signature doit contenir entre 4 et 8 chiffres)";
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
			this.TextBox2.Location = new global::System.Drawing.Point(7, 46);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox2.TabIndex = 102;
			this.TextBox2.UseSystemPasswordChar = true;
			this.guna2TextBox1.BorderRadius = 2;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Location = new global::System.Drawing.Point(7, 110);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.guna2TextBox1.TabIndex = 105;
			this.guna2TextBox1.UseSystemPasswordChar = true;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(3, 88);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(174, 19);
			this.label5.TabIndex = 103;
			this.label5.Text = "Confirmer votre signature";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(170, 145);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 167;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.panel3.Controls.Add(this.guna2TextBox4);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.guna2Button2);
			this.panel3.Controls.Add(this.guna2TextBox2);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.guna2TextBox3);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Location = new global::System.Drawing.Point(408, 58);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(401, 304);
			this.panel3.TabIndex = 7;
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(170, 191);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button2.TabIndex = 167;
			this.guna2Button2.Text = "Modifier";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.guna2TextBox2.BorderRadius = 2;
			this.guna2TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox2.DefaultText = "";
			this.guna2TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Location = new global::System.Drawing.Point(7, 154);
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.guna2TextBox2.TabIndex = 105;
			this.guna2TextBox2.UseSystemPasswordChar = true;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(3, 132);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(174, 19);
			this.label4.TabIndex = 103;
			this.label4.Text = "Confirmer votre signature";
			this.guna2TextBox3.BorderRadius = 2;
			this.guna2TextBox3.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox3.DefaultText = "";
			this.guna2TextBox3.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox3.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox3.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox3.DisabledState.Parent = this.guna2TextBox3;
			this.guna2TextBox3.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox3.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox3.FocusedState.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox3.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox3.HoverState.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Location = new global::System.Drawing.Point(7, 100);
			this.guna2TextBox3.Name = "guna2TextBox3";
			this.guna2TextBox3.PasswordChar = '\0';
			this.guna2TextBox3.PlaceholderText = "";
			this.guna2TextBox3.SelectedText = "";
			this.guna2TextBox3.ShadowDecoration.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Size = new global::System.Drawing.Size(267, 29);
			this.guna2TextBox3.TabIndex = 102;
			this.guna2TextBox3.UseSystemPasswordChar = true;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(132, 78);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(227, 13);
			this.label6.TabIndex = 101;
			this.label6.Text = "(La signature doit contenir entre 4 et 8 chiffres)";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Black;
			this.label7.Location = new global::System.Drawing.Point(3, 78);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(131, 19);
			this.label7.TabIndex = 100;
			this.label7.Text = "Nouvelle signature";
			this.guna2TextBox4.BorderRadius = 2;
			this.guna2TextBox4.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox4.DefaultText = "";
			this.guna2TextBox4.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox4.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox4.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox4.DisabledState.Parent = this.guna2TextBox4;
			this.guna2TextBox4.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox4.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox4.FocusedState.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox4.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox4.HoverState.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Location = new global::System.Drawing.Point(7, 46);
			this.guna2TextBox4.Name = "guna2TextBox4";
			this.guna2TextBox4.PasswordChar = '\0';
			this.guna2TextBox4.PlaceholderText = "";
			this.guna2TextBox4.SelectedText = "";
			this.guna2TextBox4.ShadowDecoration.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Size = new global::System.Drawing.Size(267, 29);
			this.guna2TextBox4.TabIndex = 169;
			this.guna2TextBox4.UseSystemPasswordChar = true;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(3, 24);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(134, 19);
			this.label8.TabIndex = 168;
			this.label8.Text = "Ancienne Signature";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "signature";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.signature_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001377 RID: 4983
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001378 RID: 4984
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04001379 RID: 4985
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400137A RID: 4986
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400137B RID: 4987
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400137C RID: 4988
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400137D RID: 4989
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x0400137E RID: 4990
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400137F RID: 4991
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04001380 RID: 4992
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04001381 RID: 4993
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04001382 RID: 4994
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;

		// Token: 0x04001383 RID: 4995
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04001384 RID: 4996
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04001385 RID: 4997
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x04001386 RID: 4998
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04001387 RID: 4999
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;

		// Token: 0x04001388 RID: 5000
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04001389 RID: 5001
		private global::System.Windows.Forms.Label label7;
	}
}
