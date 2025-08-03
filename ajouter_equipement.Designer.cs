namespace GMAO
{
	// Token: 0x0200000F RID: 15
	public partial class ajouter_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00027B0C File Offset: 0x00025D0C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00027B44 File Offset: 0x00025D44
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.guna2NumericUpDown1 = new global::Guna.UI2.WinForms.Guna2NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.guna2NumericUpDown1.BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(12, 70);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(49, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ordre";
			this.guna2NumericUpDown1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2NumericUpDown1.BorderRadius = 3;
			this.guna2NumericUpDown1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2NumericUpDown1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2NumericUpDown1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2NumericUpDown1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2NumericUpDown1.DisabledState.Parent = this.guna2NumericUpDown1;
			this.guna2NumericUpDown1.DisabledState.UpDownButtonFillColor = global::System.Drawing.Color.FromArgb(177, 177, 177);
			this.guna2NumericUpDown1.DisabledState.UpDownButtonForeColor = global::System.Drawing.Color.FromArgb(203, 203, 203);
			this.guna2NumericUpDown1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2NumericUpDown1.FocusedState.Parent = this.guna2NumericUpDown1;
			this.guna2NumericUpDown1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2NumericUpDown1.ForeColor = global::System.Drawing.Color.FromArgb(126, 137, 149);
			this.guna2NumericUpDown1.Location = new global::System.Drawing.Point(16, 92);
			global::Guna.UI2.WinForms.Suite.NumericUpDown numericUpDown = this.guna2NumericUpDown1;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Maximum = new decimal(array);
			this.guna2NumericUpDown1.Name = "guna2NumericUpDown1";
			this.guna2NumericUpDown1.ShadowDecoration.Parent = this.guna2NumericUpDown1;
			this.guna2NumericUpDown1.Size = new global::System.Drawing.Size(100, 29);
			this.guna2NumericUpDown1.TabIndex = 1;
			this.guna2NumericUpDown1.UpDownButtonFillColor = global::System.Drawing.Color.Firebrick;
			this.guna2NumericUpDown1.UpDownButtonForeColor = global::System.Drawing.Color.White;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(130, 70);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(130, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Code equipement";
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
			this.TextBox1.Location = new global::System.Drawing.Point(134, 92);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(337, 29);
			this.TextBox1.TabIndex = 3;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(486, 70);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(89, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Désignation";
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
			this.TextBox2.Location = new global::System.Drawing.Point(490, 92);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(337, 29);
			this.TextBox2.TabIndex = 5;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(723, 134);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 6;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(80, 19);
			this.label4.TabIndex = 7;
			this.label4.Text = "Id Parent :";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(12, 35);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(147, 19);
			this.label5.TabIndex = 8;
			this.label5.Text = "Désignation Parent :";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(88, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(75, 19);
			this.label6.TabIndex = 9;
			this.label6.Text = "Id Parent :";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DimGray;
			this.label7.Location = new global::System.Drawing.Point(156, 35);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(75, 19);
			this.label7.TabIndex = 10;
			this.label7.Text = "Id Parent :";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(872, 196);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.guna2NumericUpDown1);
			base.Controls.Add(this.label1);
			base.Name = "ajouter_equipement";
			base.ShowIcon = false;
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.ajouter_equipement_Load);
			this.guna2NumericUpDown1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000138 RID: 312
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400013A RID: 314
		private global::Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400013C RID: 316
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400013E RID: 318
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x0400013F RID: 319
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Label label7;
	}
}
