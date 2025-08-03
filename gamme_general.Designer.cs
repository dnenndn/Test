namespace GMAO
{
	// Token: 0x02000078 RID: 120
	public partial class gamme_general : global::System.Windows.Forms.Form
	{
		// Token: 0x06000594 RID: 1428 RVA: 0x000E999C File Offset: 0x000E7B9C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000E99D4 File Offset: 0x000E7BD4
		private void InitializeComponent()
		{
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton6 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton5 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label31 = new global::System.Windows.Forms.Label();
			this.label29 = new global::System.Windows.Forms.Label();
			this.guna2TextBox7 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label6 = new global::System.Windows.Forms.Label();
			this.radDropDownList5 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label5 = new global::System.Windows.Forms.Label();
			this.radDropDownList4 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label4 = new global::System.Windows.Forms.Label();
			this.radDropDownList3 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label30 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radCheckedDropDownList1 = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.radButton1.BeginInit();
			this.panel6.SuspendLayout();
			this.radRadioButton7.BeginInit();
			this.radRadioButton6.BeginInit();
			this.radRadioButton5.BeginInit();
			this.radRadioButton3.BeginInit();
			this.radRadioButton4.BeginInit();
			this.radDropDownList6.BeginInit();
			this.radDropDownList5.BeginInit();
			this.radDropDownList4.BeginInit();
			this.radDropDownList3.BeginInit();
			this.radDropDownList1.BeginInit();
			this.radCheckedDropDownList1.BeginInit();
			base.SuspendLayout();
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(469, 182);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 323;
			this.radButton1.Text = "Modifier";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.panel6.Controls.Add(this.radRadioButton7);
			this.panel6.Controls.Add(this.radRadioButton6);
			this.panel6.Controls.Add(this.radRadioButton5);
			this.panel6.Controls.Add(this.radRadioButton3);
			this.panel6.Controls.Add(this.radRadioButton4);
			this.panel6.Location = new global::System.Drawing.Point(469, 123);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(399, 32);
			this.panel6.TabIndex = 322;
			this.radRadioButton7.Location = new global::System.Drawing.Point(288, 4);
			this.radRadioButton7.Name = "radRadioButton7";
			this.radRadioButton7.Size = new global::System.Drawing.Size(52, 22);
			this.radRadioButton7.TabIndex = 284;
			this.radRadioButton7.TabStop = false;
			this.radRadioButton7.Text = "Max";
			this.radRadioButton7.ThemeName = "Crystal";
			this.radRadioButton6.Location = new global::System.Drawing.Point(233, 4);
			this.radRadioButton6.Name = "radRadioButton6";
			this.radRadioButton6.Size = new global::System.Drawing.Size(49, 22);
			this.radRadioButton6.TabIndex = 283;
			this.radRadioButton6.TabStop = false;
			this.radRadioButton6.Text = "Min";
			this.radRadioButton6.ThemeName = "Crystal";
			this.radRadioButton5.Location = new global::System.Drawing.Point(153, 4);
			this.radRadioButton5.Name = "radRadioButton5";
			this.radRadioButton5.Size = new global::System.Drawing.Size(82, 22);
			this.radRadioButton5.TabIndex = 282;
			this.radRadioButton5.TabStop = false;
			this.radRadioButton5.Text = "Moyenne";
			this.radRadioButton5.ThemeName = "Crystal";
			this.radRadioButton3.Location = new global::System.Drawing.Point(76, 4);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(77, 22);
			this.radRadioButton3.TabIndex = 246;
			this.radRadioButton3.TabStop = false;
			this.radRadioButton3.Text = "Dernière";
			this.radRadioButton3.ThemeName = "Crystal";
			this.radRadioButton4.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton4.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(71, 22);
			this.radRadioButton4.TabIndex = 245;
			this.radRadioButton4.TabStop = false;
			this.radRadioButton4.Text = "Manuel";
			this.radRadioButton4.ThemeName = "Crystal";
			this.radRadioButton4.ToggleState = 1;
			this.label31.AutoSize = true;
			this.label31.BackColor = global::System.Drawing.Color.Transparent;
			this.label31.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label31.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label31.ForeColor = global::System.Drawing.Color.DimGray;
			this.label31.Location = new global::System.Drawing.Point(467, 108);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(93, 12);
			this.label31.TabIndex = 321;
			this.label31.Text = "Variation Durée";
			this.label29.AutoSize = true;
			this.label29.BackColor = global::System.Drawing.Color.Transparent;
			this.label29.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label29.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label29.ForeColor = global::System.Drawing.Color.DimGray;
			this.label29.Location = new global::System.Drawing.Point(467, 61);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(116, 12);
			this.label29.TabIndex = 320;
			this.label29.Text = "Durée Estimée (Min)";
			this.guna2TextBox7.BorderRadius = 2;
			this.guna2TextBox7.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox7.DefaultText = "";
			this.guna2TextBox7.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox7.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox7.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox7.DisabledState.Parent = this.guna2TextBox7;
			this.guna2TextBox7.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox7.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox7.FocusedState.Parent = this.guna2TextBox7;
			this.guna2TextBox7.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox7.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox7.HoverState.Parent = this.guna2TextBox7;
			this.guna2TextBox7.Location = new global::System.Drawing.Point(469, 75);
			this.guna2TextBox7.Name = "guna2TextBox7";
			this.guna2TextBox7.PasswordChar = '\0';
			this.guna2TextBox7.PlaceholderText = "";
			this.guna2TextBox7.SelectedText = "";
			this.guna2TextBox7.ShadowDecoration.Parent = this.guna2TextBox7;
			this.guna2TextBox7.Size = new global::System.Drawing.Size(127, 24);
			this.guna2TextBox7.TabIndex = 319;
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(469, 22);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(593, 25);
			this.guna2TextBox1.TabIndex = 318;
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(467, 7);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(71, 12);
			this.label8.TabIndex = 317;
			this.label8.Text = "Désignation";
			this.TextBox2.BorderRadius = 2;
			this.TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox2.DefaultText = "";
			this.TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.DisabledState.Parent = this.TextBox2;
			this.TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox2.Enabled = false;
			this.TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.FocusedState.Parent = this.TextBox2;
			this.TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox2.HoverState.Parent = this.TextBox2;
			this.TextBox2.Location = new global::System.Drawing.Point(7, 76);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(205, 25);
			this.TextBox2.TabIndex = 316;
			this.label7.AutoSize = true;
			this.label7.BackColor = global::System.Drawing.Color.Transparent;
			this.label7.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label7.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DimGray;
			this.label7.Location = new global::System.Drawing.Point(254, 7);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(103, 12);
			this.label7.TabIndex = 314;
			this.label7.Text = "Centre de charge";
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(256, 129);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList6.TabIndex = 313;
			this.radDropDownList6.ThemeName = "Fluent";
			this.label6.AutoSize = true;
			this.label6.BackColor = global::System.Drawing.Color.Transparent;
			this.label6.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label6.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(254, 114);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(72, 12);
			this.label6.TabIndex = 312;
			this.label6.Text = "Superviseur";
			this.radDropDownList5.DropDownStyle = 2;
			this.radDropDownList5.Enabled = false;
			this.radDropDownList5.Location = new global::System.Drawing.Point(256, 182);
			this.radDropDownList5.Name = "radDropDownList5";
			this.radDropDownList5.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList5.TabIndex = 311;
			this.radDropDownList5.ThemeName = "Fluent";
			this.label5.AutoSize = true;
			this.label5.BackColor = global::System.Drawing.Color.Transparent;
			this.label5.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label5.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(254, 167);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(122, 12);
			this.label5.TabIndex = 310;
			this.label5.Text = "Plan de maintenance";
			this.radDropDownList4.DropDownStyle = 2;
			this.radDropDownList4.Location = new global::System.Drawing.Point(256, 76);
			this.radDropDownList4.Name = "radDropDownList4";
			this.radDropDownList4.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList4.TabIndex = 309;
			this.radDropDownList4.ThemeName = "Fluent";
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label4.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(254, 61);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(46, 12);
			this.label4.TabIndex = 308;
			this.label4.Text = "Priorité";
			this.radDropDownList3.DropDownStyle = 2;
			this.radDropDownList3.Location = new global::System.Drawing.Point(7, 182);
			this.radDropDownList3.Name = "radDropDownList3";
			this.radDropDownList3.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList3.TabIndex = 307;
			this.radDropDownList3.ThemeName = "Fluent";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(5, 167);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(122, 12);
			this.label3.TabIndex = 306;
			this.label3.Text = "Classe d'intervention";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(5, 61);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(112, 12);
			this.label2.TabIndex = 305;
			this.label2.Text = "Type d'intervention";
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(7, 129);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList1.TabIndex = 304;
			this.radDropDownList1.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(5, 114);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(27, 12);
			this.label1.TabIndex = 303;
			this.label1.Text = "Etat";
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
			this.TextBox1.Location = new global::System.Drawing.Point(7, 22);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(205, 25);
			this.TextBox1.TabIndex = 302;
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(5, 7);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(34, 12);
			this.label30.TabIndex = 301;
			this.label30.Text = "Code";
			this.radCheckedDropDownList1.Location = new global::System.Drawing.Point(256, 23);
			this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
			this.radCheckedDropDownList1.Size = new global::System.Drawing.Size(205, 24);
			this.radCheckedDropDownList1.TabIndex = 324;
			this.radCheckedDropDownList1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 258);
			base.Controls.Add(this.radCheckedDropDownList1);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.label31);
			base.Controls.Add(this.label29);
			base.Controls.Add(this.guna2TextBox7);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.radDropDownList5);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.radDropDownList4);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.radDropDownList3);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label30);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "gamme_general";
			base.Load += new global::System.EventHandler(this.gamme_general_Load);
			this.radButton1.EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.radRadioButton7.EndInit();
			this.radRadioButton6.EndInit();
			this.radRadioButton5.EndInit();
			this.radRadioButton3.EndInit();
			this.radRadioButton4.EndInit();
			this.radDropDownList6.EndInit();
			this.radDropDownList5.EndInit();
			this.radDropDownList4.EndInit();
			this.radDropDownList3.EndInit();
			this.radDropDownList1.EndInit();
			this.radCheckedDropDownList1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000769 RID: 1897
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400076A RID: 1898
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x0400076B RID: 1899
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400076C RID: 1900
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x0400076D RID: 1901
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton6;

		// Token: 0x0400076E RID: 1902
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton5;

		// Token: 0x0400076F RID: 1903
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x04000770 RID: 1904
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000771 RID: 1905
		internal global::System.Windows.Forms.Label label31;

		// Token: 0x04000772 RID: 1906
		internal global::System.Windows.Forms.Label label29;

		// Token: 0x04000773 RID: 1907
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox7;

		// Token: 0x04000774 RID: 1908
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000775 RID: 1909
		internal global::System.Windows.Forms.Label label8;

		// Token: 0x04000776 RID: 1910
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000777 RID: 1911
		internal global::System.Windows.Forms.Label label7;

		// Token: 0x04000778 RID: 1912
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000779 RID: 1913
		internal global::System.Windows.Forms.Label label6;

		// Token: 0x0400077A RID: 1914
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList5;

		// Token: 0x0400077B RID: 1915
		internal global::System.Windows.Forms.Label label5;

		// Token: 0x0400077C RID: 1916
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList4;

		// Token: 0x0400077D RID: 1917
		internal global::System.Windows.Forms.Label label4;

		// Token: 0x0400077E RID: 1918
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList3;

		// Token: 0x0400077F RID: 1919
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000780 RID: 1920
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000781 RID: 1921
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000782 RID: 1922
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000783 RID: 1923
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000784 RID: 1924
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000785 RID: 1925
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000786 RID: 1926
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000787 RID: 1927
		private global::Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;
	}
}
