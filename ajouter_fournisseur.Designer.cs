namespace GMAO
{
	// Token: 0x02000011 RID: 17
	public partial class ajouter_fournisseur : global::System.Windows.Forms.Form
	{
		// Token: 0x06000101 RID: 257 RVA: 0x0002BB04 File Offset: 0x00029D04
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0002BB3C File Offset: 0x00029D3C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ajouter_fournisseur));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.guna2TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.guna2TextBox5 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.radPanel2 = new global::Telerik.WinControls.UI.RadPanel();
			this.p3 = new global::System.Windows.Forms.Panel();
			this.p1 = new global::System.Windows.Forms.Panel();
			this.p2 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label17 = new global::System.Windows.Forms.Label();
			this.radCheckedDropDownList3 = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2TextBox6 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radCheckedDropDownList2 = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.radCheckedDropDownList1 = new global::Telerik.WinControls.UI.RadCheckedDropDownList();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panel3.SuspendLayout();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radDropDownList1.BeginInit();
			this.panel4.SuspendLayout();
			this.radPanel2.BeginInit();
			this.radPanel2.SuspendLayout();
			this.p1.SuspendLayout();
			this.radPanel1.BeginInit();
			this.radCheckedDropDownList3.BeginInit();
			this.radCheckedDropDownList2.BeginInit();
			this.radCheckedDropDownList1.BeginInit();
			this.radDropDownList6.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 5;
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
			this.TextBox2.Location = new global::System.Drawing.Point(324, 61);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox2.TabIndex = 45;
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Black;
			this.label11.Location = new global::System.Drawing.Point(320, 39);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(39, 19);
			this.label11.TabIndex = 44;
			this.label11.Text = "Nom";
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
			this.TextBox1.Location = new global::System.Drawing.Point(26, 61);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.TextBox1.TabIndex = 43;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(22, 39);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(121, 19);
			this.label10.TabIndex = 42;
			this.label10.Text = "Code Fournisseur";
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(26, 115);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(267, 29);
			this.guna2TextBox1.TabIndex = 47;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(22, 93);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(58, 19);
			this.label1.TabIndex = 46;
			this.label1.Text = "Activité";
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Location = new global::System.Drawing.Point(314, 115);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(258, 29);
			this.panel3.TabIndex = 49;
			this.radRadioButton2.Location = new global::System.Drawing.Point(110, 3);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(110, 22);
			this.radRadioButton2.TabIndex = 100;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Sous_Traitant";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 2);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(98, 22);
			this.radRadioButton1.TabIndex = 0;
			this.radRadioButton1.Text = "Fournisseur";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(22, 152);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(103, 19);
			this.label2.TabIndex = 50;
			this.label2.Text = "Type d'activité";
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100.png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (1).png");
			this.imageList1.Images.SetKeyName(2, "icons8-word-96.png");
			this.imageList1.Images.SetKeyName(3, "icons8-ms-excel-104.png");
			this.imageList1.Images.SetKeyName(4, "icons8-pdf-40.png");
			this.imageList1.Images.SetKeyName(5, "icons8-txt-80.png");
			this.imageList1.Images.SetKeyName(6, "icons8-winrar-240.png");
			this.imageList1.Images.SetKeyName(7, "icons8-image-96.png");
			this.imageList1.Images.SetKeyName(8, "icons8-autodesk-autocad-144.png");
			this.imageList1.Images.SetKeyName(9, "icons8-fichier-128.png");
			this.radDropDownList1.DropDownAnimationEasing = 2;
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(26, 174);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList1.TabIndex = 51;
			this.radDropDownList1.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList1.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(320, 152);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(136, 19);
			this.label3.TabIndex = 52;
			this.label3.Text = "Mode de règlement";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(320, 207);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(108, 19);
			this.label4.TabIndex = 56;
			this.label4.Text = "Compte budget";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(22, 207);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(125, 19);
			this.label5.TabIndex = 54;
			this.label5.Text = "Mode de livraison";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(22, 263);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(96, 19);
			this.label6.TabIndex = 58;
			this.label6.Text = "Commentaire";
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
			this.guna2TextBox2.Location = new global::System.Drawing.Point(26, 285);
			this.guna2TextBox2.Multiline = true;
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(565, 62);
			this.guna2TextBox2.TabIndex = 59;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Black;
			this.label7.Location = new global::System.Drawing.Point(320, 359);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(105, 19);
			this.label7.TabIndex = 62;
			this.label7.Text = "TVA par défaut";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(22, 359);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(53, 19);
			this.label8.TabIndex = 60;
			this.label8.Text = "Devise";
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
			this.guna2TextBox3.Location = new global::System.Drawing.Point(324, 381);
			this.guna2TextBox3.Name = "guna2TextBox3";
			this.guna2TextBox3.PasswordChar = '\0';
			this.guna2TextBox3.PlaceholderText = "";
			this.guna2TextBox3.SelectedText = "";
			this.guna2TextBox3.ShadowDecoration.Parent = this.guna2TextBox3;
			this.guna2TextBox3.Size = new global::System.Drawing.Size(119, 24);
			this.guna2TextBox3.TabIndex = 63;
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
			this.guna2TextBox4.Location = new global::System.Drawing.Point(26, 436);
			this.guna2TextBox4.Name = "guna2TextBox4";
			this.guna2TextBox4.PasswordChar = '\0';
			this.guna2TextBox4.PlaceholderText = "";
			this.guna2TextBox4.SelectedText = "";
			this.guna2TextBox4.ShadowDecoration.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Size = new global::System.Drawing.Size(267, 24);
			this.guna2TextBox4.TabIndex = 65;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(22, 414);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(109, 19);
			this.label9.TabIndex = 64;
			this.label9.Text = "Délai (en jours)";
			this.guna2TextBox5.BorderRadius = 2;
			this.guna2TextBox5.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox5.DefaultText = "";
			this.guna2TextBox5.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox5.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox5.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox5.DisabledState.Parent = this.guna2TextBox5;
			this.guna2TextBox5.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox5.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox5.FocusedState.Parent = this.guna2TextBox5;
			this.guna2TextBox5.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox5.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox5.HoverState.Parent = this.guna2TextBox5;
			this.guna2TextBox5.Location = new global::System.Drawing.Point(324, 436);
			this.guna2TextBox5.Name = "guna2TextBox5";
			this.guna2TextBox5.PasswordChar = '\0';
			this.guna2TextBox5.PlaceholderText = "";
			this.guna2TextBox5.SelectedText = "";
			this.guna2TextBox5.ShadowDecoration.Parent = this.guna2TextBox5;
			this.guna2TextBox5.Size = new global::System.Drawing.Size(267, 24);
			this.guna2TextBox5.TabIndex = 67;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.Black;
			this.label12.Location = new global::System.Drawing.Point(320, 414);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(153, 19);
			this.label12.TabIndex = 66;
			this.label12.Text = "Remise par défaut (%)";
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(619, 61);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(516, 29);
			this.panel4.TabIndex = 70;
			this.button3.BackColor = global::System.Drawing.Color.Gray;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(229, 1);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(118, 28);
			this.button3.TabIndex = 74;
			this.button3.Text = "Banque";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(112, 1);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(118, 28);
			this.button1.TabIndex = 73;
			this.button1.Text = "Contact";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.Color.Gray;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(0, 1);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(113, 28);
			this.button2.TabIndex = 72;
			this.button2.Text = "Adresse";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel5.Location = new global::System.Drawing.Point(619, 91);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(516, 10);
			this.panel5.TabIndex = 71;
			this.panel5.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
			this.radPanel2.Controls.Add(this.p3);
			this.radPanel2.Controls.Add(this.p1);
			this.radPanel2.Location = new global::System.Drawing.Point(619, 115);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new global::System.Drawing.Size(507, 485);
			this.radPanel2.TabIndex = 72;
			this.radPanel2.ThemeName = "ControlDefault";
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel2.GetChildAt(0).GetChildAt(1)).GradientStyle = 0;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel2.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			this.p3.Location = new global::System.Drawing.Point(3, 3);
			this.p3.Name = "p3";
			this.p3.Size = new global::System.Drawing.Size(498, 479);
			this.p3.TabIndex = 1;
			this.p1.Controls.Add(this.p2);
			this.p1.Location = new global::System.Drawing.Point(3, 3);
			this.p1.Name = "p1";
			this.p1.Size = new global::System.Drawing.Size(498, 479);
			this.p1.TabIndex = 0;
			this.p2.Location = new global::System.Drawing.Point(3, 3);
			this.p2.Name = "p2";
			this.p2.Size = new global::System.Drawing.Size(498, 479);
			this.p2.TabIndex = 1;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.ForeColor = global::System.Drawing.Color.Black;
			this.label13.Location = new global::System.Drawing.Point(22, 469);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(82, 19);
			this.label13.TabIndex = 68;
			this.label13.Text = "Documents";
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Location = new global::System.Drawing.Point(26, 491);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(565, 109);
			this.radPanel1.TabIndex = 69;
			this.radPanel1.ThemeName = "ControlDefault";
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).GradientStyle = 0;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Red;
			this.label14.Location = new global::System.Drawing.Point(141, 39);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(17, 19);
			this.label14.TabIndex = 88;
			this.label14.Text = "*";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.ForeColor = global::System.Drawing.Color.Red;
			this.label15.Location = new global::System.Drawing.Point(358, 39);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(17, 19);
			this.label15.TabIndex = 89;
			this.label15.Text = "*";
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.ForeColor = global::System.Drawing.Color.Red;
			this.label16.Location = new global::System.Drawing.Point(426, 206);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(17, 19);
			this.label16.TabIndex = 90;
			this.label16.Text = "*";
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.ForeColor = global::System.Drawing.Color.Red;
			this.label17.Location = new global::System.Drawing.Point(76, 359);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(17, 19);
			this.label17.TabIndex = 91;
			this.label17.Text = "*";
			this.radCheckedDropDownList3.Location = new global::System.Drawing.Point(324, 174);
			this.radCheckedDropDownList3.Name = "radCheckedDropDownList3";
			this.radCheckedDropDownList3.Size = new global::System.Drawing.Size(267, 24);
			this.radCheckedDropDownList3.TabIndex = 93;
			this.radCheckedDropDownList3.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadCheckedDropDownListElement)this.radCheckedDropDownList3.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList3.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(1017, 37);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 21);
			this.guna2Button1.TabIndex = 94;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.guna2TextBox6.BorderRadius = 2;
			this.guna2TextBox6.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox6.DefaultText = "";
			this.guna2TextBox6.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox6.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox6.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox6.DisabledState.Parent = this.guna2TextBox6;
			this.guna2TextBox6.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox6.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox6.FocusedState.Parent = this.guna2TextBox6;
			this.guna2TextBox6.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox6.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox6.HoverState.Parent = this.guna2TextBox6;
			this.guna2TextBox6.Location = new global::System.Drawing.Point(453, 381);
			this.guna2TextBox6.Name = "guna2TextBox6";
			this.guna2TextBox6.PasswordChar = '\0';
			this.guna2TextBox6.PlaceholderText = "";
			this.guna2TextBox6.SelectedText = "";
			this.guna2TextBox6.ShadowDecoration.Parent = this.guna2TextBox6;
			this.guna2TextBox6.Size = new global::System.Drawing.Size(119, 24);
			this.guna2TextBox6.TabIndex = 95;
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Black;
			this.label18.Location = new global::System.Drawing.Point(449, 359);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(72, 19);
			this.label18.TabIndex = 96;
			this.label18.Text = "Fodec (%)";
			this.radCheckedDropDownList2.Location = new global::System.Drawing.Point(26, 229);
			this.radCheckedDropDownList2.Name = "radCheckedDropDownList2";
			this.radCheckedDropDownList2.Size = new global::System.Drawing.Size(267, 24);
			this.radCheckedDropDownList2.TabIndex = 97;
			this.radCheckedDropDownList2.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadCheckedDropDownListElement)this.radCheckedDropDownList2.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.radCheckedDropDownList1.Location = new global::System.Drawing.Point(324, 229);
			this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
			this.radCheckedDropDownList1.Size = new global::System.Drawing.Size(267, 24);
			this.radCheckedDropDownList1.TabIndex = 98;
			this.radCheckedDropDownList1.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadCheckedDropDownListElement)this.radCheckedDropDownList1.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCheckedDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(26, 381);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList6.TabIndex = 99;
			this.radDropDownList6.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList6.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(559, 469);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(13, 13);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 86;
			this.pictureBox2.TabStop = false;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(102, 468);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(32, 22);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 85;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.radCheckedDropDownList1);
			base.Controls.Add(this.radCheckedDropDownList2);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.guna2TextBox6);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radCheckedDropDownList3);
			base.Controls.Add(this.label17);
			base.Controls.Add(this.label16);
			base.Controls.Add(this.label15);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.radPanel2);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.radPanel1);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.guna2TextBox5);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.guna2TextBox4);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.guna2TextBox3);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.guna2TextBox2);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ajouter_fournisseur";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ajouter_fournisseur_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radDropDownList1.EndInit();
			this.panel4.ResumeLayout(false);
			this.radPanel2.EndInit();
			this.radPanel2.ResumeLayout(false);
			this.p1.ResumeLayout(false);
			this.radPanel1.EndInit();
			this.radCheckedDropDownList3.EndInit();
			this.radCheckedDropDownList2.EndInit();
			this.radCheckedDropDownList1.EndInit();
			this.radDropDownList6.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000150 RID: 336
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000153 RID: 339
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000154 RID: 340
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000155 RID: 341
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000157 RID: 343
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000159 RID: 345
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400015D RID: 349
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000162 RID: 354
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000165 RID: 357
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;

		// Token: 0x04000166 RID: 358
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000168 RID: 360
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox5;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x0400016C RID: 364
		private global::Telerik.WinControls.UI.RadPanel radPanel2;

		// Token: 0x0400016D RID: 365
		public global::System.Windows.Forms.Button button3;

		// Token: 0x0400016E RID: 366
		public global::System.Windows.Forms.Button button1;

		// Token: 0x0400016F RID: 367
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.Panel p3;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.Panel p1;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.Panel p2;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000175 RID: 373
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.Label label17;

		// Token: 0x0400017B RID: 379
		private global::Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList3;

		// Token: 0x0400017C RID: 380
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x0400017D RID: 381
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Label label18;

		// Token: 0x0400017F RID: 383
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000180 RID: 384
		private global::Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList2;

		// Token: 0x04000181 RID: 385
		private global::Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;

		// Token: 0x04000182 RID: 386
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000183 RID: 387
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000184 RID: 388
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;
	}
}
