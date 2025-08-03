namespace GMAO
{
	// Token: 0x02000083 RID: 131
	public partial class liste_activite : global::System.Windows.Forms.Form
	{
		// Token: 0x06000635 RID: 1589 RVA: 0x0010061C File Offset: 0x000FE81C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00100654 File Offset: 0x000FE854
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.liste_activite));
			this.label2 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radTreeView2 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu2 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem2 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radTreeView3 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu3 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem3 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radTreeView4 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu4 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem4 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.radTextBox1 = new global::Telerik.WinControls.UI.RadTextBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.panel3.SuspendLayout();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radTreeView1.BeginInit();
			this.radTreeView2.BeginInit();
			this.radTreeView3.BeginInit();
			this.radTreeView4.BeginInit();
			this.panel1.SuspendLayout();
			this.radRadioButton3.BeginInit();
			this.radRadioButton4.BeginInit();
			this.panel2.SuspendLayout();
			this.radTextBox1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(117, 19);
			this.label2.TabIndex = 49;
			this.label2.Text = "Ajouter Activité";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.ForeColor = global::System.Drawing.Color.Red;
			this.label15.Location = new global::System.Drawing.Point(375, 38);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(17, 19);
			this.label15.TabIndex = 102;
			this.label15.Text = "*";
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Red;
			this.label14.Location = new global::System.Drawing.Point(105, 38);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(17, 19);
			this.label14.TabIndex = 101;
			this.label14.Text = "*";
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
			this.TextBox2.Location = new global::System.Drawing.Point(293, 60);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox2.TabIndex = 100;
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Black;
			this.label11.Location = new global::System.Drawing.Point(289, 38);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(87, 19);
			this.label11.TabIndex = 99;
			this.label11.Text = "Désignation";
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
			this.TextBox1.Location = new global::System.Drawing.Point(16, 60);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox1.TabIndex = 98;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(12, 38);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(94, 19);
			this.label10.TabIndex = 97;
			this.label10.Text = "Code activité";
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Location = new global::System.Drawing.Point(566, 60);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(396, 29);
			this.panel3.TabIndex = 134;
			this.radRadioButton2.Location = new global::System.Drawing.Point(165, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(212, 22);
			this.radRadioButton2.TabIndex = 50;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Sous Traitant interne (Ateliers)";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(10, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(156, 22);
			this.radRadioButton1.TabIndex = 48;
			this.radRadioButton1.Text = "Sous Traitant externe";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.radTreeView1.Location = new global::System.Drawing.Point(16, 147);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(220, 216);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 212;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.radTreeView2.Location = new global::System.Drawing.Point(252, 147);
			this.radTreeView2.Name = "radTreeView2";
			this.radTreeView2.RadContextMenu = this.radContextMenu2;
			this.radTreeView2.Size = new global::System.Drawing.Size(220, 216);
			this.radTreeView2.SpacingBetweenNodes = -1;
			this.radTreeView2.TabIndex = 213;
			this.radTreeView2.ThemeName = "Office2010Silver";
			this.radContextMenu2.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem2
			});
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "Ajouter";
			this.radMenuItem2.UseCompatibleTextRendering = false;
			this.radTreeView3.Location = new global::System.Drawing.Point(478, 147);
			this.radTreeView3.Name = "radTreeView3";
			this.radTreeView3.RadContextMenu = this.radContextMenu3;
			this.radTreeView3.Size = new global::System.Drawing.Size(220, 216);
			this.radTreeView3.SpacingBetweenNodes = -1;
			this.radTreeView3.TabIndex = 214;
			this.radTreeView3.ThemeName = "Office2010Silver";
			this.radContextMenu3.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem3
			});
			this.radMenuItem3.Name = "radMenuItem3";
			this.radMenuItem3.Text = "Supprimer";
			this.radMenuItem3.UseCompatibleTextRendering = false;
			this.radTreeView4.Location = new global::System.Drawing.Point(704, 147);
			this.radTreeView4.Name = "radTreeView4";
			this.radTreeView4.RadContextMenu = this.radContextMenu4;
			this.radTreeView4.Size = new global::System.Drawing.Size(220, 216);
			this.radTreeView4.SpacingBetweenNodes = -1;
			this.radTreeView4.TabIndex = 213;
			this.radTreeView4.ThemeName = "Office2010Silver";
			this.radContextMenu4.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem4
			});
			this.radMenuItem4.Name = "radMenuItem4";
			this.radMenuItem4.Text = "Supprimer";
			this.radMenuItem4.UseCompatibleTextRendering = false;
			this.guna2TextBox2.BorderRadius = 15;
			this.guna2TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox2.DefaultText = "";
			this.guna2TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.guna2TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Location = new global::System.Drawing.Point(16, 110);
			this.guna2TextBox2.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "Recherche";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(220, 30);
			this.guna2TextBox2.TabIndex = 215;
			this.guna2TextBox2.TextChanged += new global::System.EventHandler(this.guna2TextBox2_TextChanged);
			this.guna2TextBox1.BorderRadius = 15;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Location = new global::System.Drawing.Point(252, 110);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(220, 30);
			this.guna2TextBox1.TabIndex = 216;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(478, 121);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(108, 19);
			this.label1.TabIndex = 217;
			this.label1.Text = "Famille Choisie";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(700, 121);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(142, 19);
			this.label3.TabIndex = 218;
			this.label3.Text = "Sous Famille Choisie";
			this.panel1.Controls.Add(this.radRadioButton3);
			this.panel1.Controls.Add(this.radRadioButton4);
			this.panel1.Location = new global::System.Drawing.Point(16, 382);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(289, 29);
			this.panel1.TabIndex = 219;
			this.radRadioButton3.Location = new global::System.Drawing.Point(103, 4);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(95, 22);
			this.radRadioButton3.TabIndex = 50;
			this.radRadioButton3.TabStop = false;
			this.radRadioButton3.Text = "Fabrication";
			this.radRadioButton3.ThemeName = "Crystal";
			this.radRadioButton4.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton4.Location = new global::System.Drawing.Point(10, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(92, 22);
			this.radRadioButton4.TabIndex = 48;
			this.radRadioButton4.Text = "Réparation";
			this.radRadioButton4.ThemeName = "Crystal";
			this.radRadioButton4.ToggleState = 1;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(12, 427);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(140, 19);
			this.label4.TabIndex = 220;
			this.label4.Text = "Liste des opérations";
			this.panel2.Controls.Add(this.radTextBox1);
			this.panel2.Controls.Add(this.pictureBox2);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Location = new global::System.Drawing.Point(16, 449);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(783, 46);
			this.panel2.TabIndex = 222;
			this.radTextBox1.Location = new global::System.Drawing.Point(13, 5);
			this.radTextBox1.Name = "radTextBox1";
			this.radTextBox1.Size = new global::System.Drawing.Size(531, 24);
			this.radTextBox1.TabIndex = 224;
			this.radTextBox1.ThemeName = "Crystal";
			this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(581, 5);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(22, 22);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 223;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(553, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(22, 22);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 222;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(16, 510);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 223;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.guna2TextBox2);
			base.Controls.Add(this.radTreeView4);
			base.Controls.Add(this.radTreeView3);
			base.Controls.Add(this.radTreeView2);
			base.Controls.Add(this.radTreeView1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "liste_activite";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.liste_activite_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radTreeView1.EndInit();
			this.radTreeView2.EndInit();
			this.radTreeView3.EndInit();
			this.radTreeView4.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton3.EndInit();
			this.radRadioButton4.EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radTextBox1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000810 RID: 2064
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000811 RID: 2065
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000812 RID: 2066
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000813 RID: 2067
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000814 RID: 2068
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000815 RID: 2069
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000816 RID: 2070
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000817 RID: 2071
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000818 RID: 2072
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000819 RID: 2073
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x0400081A RID: 2074
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x0400081B RID: 2075
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x0400081C RID: 2076
		private global::Telerik.WinControls.UI.RadTreeView radTreeView2;

		// Token: 0x0400081D RID: 2077
		private global::Telerik.WinControls.UI.RadTreeView radTreeView3;

		// Token: 0x0400081E RID: 2078
		private global::Telerik.WinControls.UI.RadTreeView radTreeView4;

		// Token: 0x0400081F RID: 2079
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x04000820 RID: 2080
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000821 RID: 2081
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000822 RID: 2082
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000823 RID: 2083
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04000824 RID: 2084
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000825 RID: 2085
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000826 RID: 2086
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000827 RID: 2087
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000828 RID: 2088
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000829 RID: 2089
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x0400082A RID: 2090
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x0400082B RID: 2091
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400082C RID: 2092
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400082D RID: 2093
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400082E RID: 2094
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x0400082F RID: 2095
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000830 RID: 2096
		private global::Telerik.WinControls.UI.RadTextBox radTextBox1;

		// Token: 0x04000831 RID: 2097
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu2;

		// Token: 0x04000832 RID: 2098
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem2;

		// Token: 0x04000833 RID: 2099
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu3;

		// Token: 0x04000834 RID: 2100
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem3;

		// Token: 0x04000835 RID: 2101
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu4;

		// Token: 0x04000836 RID: 2102
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem4;
	}
}
