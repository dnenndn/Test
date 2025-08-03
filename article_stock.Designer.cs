namespace GMAO
{
	// Token: 0x02000025 RID: 37
	public partial class article_stock : global::System.Windows.Forms.Form
	{
		// Token: 0x060001F3 RID: 499 RVA: 0x000512B0 File Offset: 0x0004F4B0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000512E8 File Offset: 0x0004F4E8
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.TextBox5 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.TextBox8 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.TextBox7 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.TextBox6 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(1, 3);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(96, 19);
			this.label1.TabIndex = 104;
			this.label1.Text = "Code Article :";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(97, 3);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(96, 19);
			this.label2.TabIndex = 105;
			this.label2.Text = "Code Article :";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Red;
			this.label3.Location = new global::System.Drawing.Point(109, 22);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(17, 19);
			this.label3.TabIndex = 108;
			this.label3.Text = "*";
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
			this.TextBox1.Location = new global::System.Drawing.Point(5, 44);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox1.TabIndex = 107;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(1, 22);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(109, 19);
			this.label4.TabIndex = 106;
			this.label4.Text = "Prix unitaire HT";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Red;
			this.label5.Location = new global::System.Drawing.Point(263, 22);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(17, 19);
			this.label5.TabIndex = 111;
			this.label5.Text = "*";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(204, 22);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(59, 19);
			this.label6.TabIndex = 109;
			this.label6.Text = "TVA (%)";
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
			this.TextBox2.Location = new global::System.Drawing.Point(208, 44);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox2.TabIndex = 112;
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
			this.TextBox3.Location = new global::System.Drawing.Point(412, 44);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.PasswordChar = '\0';
			this.TextBox3.PlaceholderText = "";
			this.TextBox3.SelectedText = "";
			this.TextBox3.ShadowDecoration.Parent = this.TextBox3;
			this.TextBox3.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox3.TabIndex = 115;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Red;
			this.label7.Location = new global::System.Drawing.Point(485, 22);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(17, 19);
			this.label7.TabIndex = 114;
			this.label7.Text = "*";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(408, 22);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(78, 19);
			this.label8.TabIndex = 113;
			this.label8.Text = "Stock Neuf";
			this.TextBox4.BorderRadius = 2;
			this.TextBox4.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox4.DefaultText = "";
			this.TextBox4.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox4.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox4.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox4.DisabledState.Parent = this.TextBox4;
			this.TextBox4.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox4.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox4.FocusedState.Parent = this.TextBox4;
			this.TextBox4.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox4.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox4.HoverState.Parent = this.TextBox4;
			this.TextBox4.Location = new global::System.Drawing.Point(617, 44);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.PasswordChar = '\0';
			this.TextBox4.PlaceholderText = "";
			this.TextBox4.SelectedText = "";
			this.TextBox4.ShadowDecoration.Parent = this.TextBox4;
			this.TextBox4.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox4.TabIndex = 118;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Red;
			this.label9.Location = new global::System.Drawing.Point(689, 22);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(17, 19);
			this.label9.TabIndex = 117;
			this.label9.Text = "*";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(613, 22);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(78, 19);
			this.label10.TabIndex = 116;
			this.label10.Text = "Stock usée";
			this.TextBox5.BorderRadius = 2;
			this.TextBox5.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox5.DefaultText = "";
			this.TextBox5.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox5.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox5.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox5.DisabledState.Parent = this.TextBox5;
			this.TextBox5.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox5.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox5.FocusedState.Parent = this.TextBox5;
			this.TextBox5.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox5.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox5.HoverState.Parent = this.TextBox5;
			this.TextBox5.Location = new global::System.Drawing.Point(821, 44);
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.PasswordChar = '\0';
			this.TextBox5.PlaceholderText = "";
			this.TextBox5.SelectedText = "";
			this.TextBox5.ShadowDecoration.Parent = this.TextBox5;
			this.TextBox5.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox5.TabIndex = 121;
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Red;
			this.label11.Location = new global::System.Drawing.Point(909, 22);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(17, 19);
			this.label11.TabIndex = 120;
			this.label11.Text = "*";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.Black;
			this.label12.Location = new global::System.Drawing.Point(817, 22);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(93, 19);
			this.label12.TabIndex = 119;
			this.label12.Text = "Stock Rebuté";
			this.TextBox8.BorderRadius = 2;
			this.TextBox8.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox8.DefaultText = "";
			this.TextBox8.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox8.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox8.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox8.DisabledState.Parent = this.TextBox8;
			this.TextBox8.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox8.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox8.FocusedState.Parent = this.TextBox8;
			this.TextBox8.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox8.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox8.HoverState.Parent = this.TextBox8;
			this.TextBox8.Location = new global::System.Drawing.Point(412, 98);
			this.TextBox8.Name = "TextBox8";
			this.TextBox8.PasswordChar = '\0';
			this.TextBox8.PlaceholderText = "";
			this.TextBox8.SelectedText = "";
			this.TextBox8.ShadowDecoration.Parent = this.TextBox8;
			this.TextBox8.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox8.TabIndex = 130;
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Black;
			this.label14.Location = new global::System.Drawing.Point(408, 76);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(119, 19);
			this.label14.TabIndex = 128;
			this.label14.Text = "Stock de sécurité";
			this.TextBox7.BorderRadius = 2;
			this.TextBox7.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox7.DefaultText = "";
			this.TextBox7.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox7.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox7.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox7.DisabledState.Parent = this.TextBox7;
			this.TextBox7.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox7.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox7.FocusedState.Parent = this.TextBox7;
			this.TextBox7.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox7.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox7.HoverState.Parent = this.TextBox7;
			this.TextBox7.Location = new global::System.Drawing.Point(208, 98);
			this.TextBox7.Name = "TextBox7";
			this.TextBox7.PasswordChar = '\0';
			this.TextBox7.PlaceholderText = "";
			this.TextBox7.SelectedText = "";
			this.TextBox7.ShadowDecoration.Parent = this.TextBox7;
			this.TextBox7.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox7.TabIndex = 127;
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.ForeColor = global::System.Drawing.Color.Black;
			this.label16.Location = new global::System.Drawing.Point(204, 76);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(78, 19);
			this.label16.TabIndex = 125;
			this.label16.Text = "Stock maxi";
			this.TextBox6.BorderRadius = 2;
			this.TextBox6.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox6.DefaultText = "";
			this.TextBox6.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox6.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox6.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox6.DisabledState.Parent = this.TextBox6;
			this.TextBox6.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox6.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox6.FocusedState.Parent = this.TextBox6;
			this.TextBox6.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox6.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox6.HoverState.Parent = this.TextBox6;
			this.TextBox6.Location = new global::System.Drawing.Point(5, 98);
			this.TextBox6.Name = "TextBox6";
			this.TextBox6.PasswordChar = '\0';
			this.TextBox6.PlaceholderText = "";
			this.TextBox6.SelectedText = "";
			this.TextBox6.ShadowDecoration.Parent = this.TextBox6;
			this.TextBox6.Size = new global::System.Drawing.Size(188, 29);
			this.TextBox6.TabIndex = 123;
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Black;
			this.label18.Location = new global::System.Drawing.Point(1, 76);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(75, 19);
			this.label18.TabIndex = 122;
			this.label18.Text = "Stock mini";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(617, 98);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 161;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.TextBox8);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.TextBox7);
			base.Controls.Add(this.label16);
			base.Controls.Add(this.TextBox6);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.TextBox5);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.TextBox4);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.TextBox3);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "article_stock";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.article_stock_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002B1 RID: 689
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002B2 RID: 690
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002B3 RID: 691
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002B4 RID: 692
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002B5 RID: 693
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040002B6 RID: 694
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002B7 RID: 695
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040002B8 RID: 696
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040002B9 RID: 697
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x040002BA RID: 698
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox3;

		// Token: 0x040002BB RID: 699
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040002BD RID: 701
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox4;

		// Token: 0x040002BE RID: 702
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040002BF RID: 703
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040002C0 RID: 704
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox5;

		// Token: 0x040002C1 RID: 705
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040002C2 RID: 706
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040002C3 RID: 707
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox8;

		// Token: 0x040002C4 RID: 708
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040002C5 RID: 709
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox7;

		// Token: 0x040002C6 RID: 710
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040002C7 RID: 711
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox6;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040002C9 RID: 713
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
