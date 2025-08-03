namespace GMAO
{
	// Token: 0x02000017 RID: 23
	public partial class app_planifier_da_recomp : global::System.Windows.Forms.Form
	{
		// Token: 0x06000145 RID: 325 RVA: 0x0003D9D0 File Offset: 0x0003BBD0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0003DA08 File Offset: 0x0003BC08
		private void InitializeComponent()
		{
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label7 = new global::System.Windows.Forms.Label();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label6 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label29 = new global::System.Windows.Forms.Label();
			this.radDropDownList2 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.label5 = new global::System.Windows.Forms.Label();
			this.guna2ComboBox1 = new global::Guna.UI2.WinForms.Guna2ComboBox();
			this.radTimePicker1.BeginInit();
			this.panel1.SuspendLayout();
			this.radDateTimePicker2.BeginInit();
			this.panel3.SuspendLayout();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.radDropDownList2.BeginInit();
			base.SuspendLayout();
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(673, 132);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 232;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radTimePicker1.Location = new global::System.Drawing.Point(258, 192);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(154, 24);
			this.radTimePicker1.TabIndex = 231;
			this.radTimePicker1.TabStop = false;
			this.radTimePicker1.ThemeName = "Crystal";
			this.radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 5, 18, 23, 1, 27, 720));
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).NumberOfColors = 1;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.RadTimeElementUpButton)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(254, 170);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(91, 19);
			this.label9.TabIndex = 230;
			this.label9.Text = "Heure Début";
			this.panel1.Controls.Add(this.radDateTimePicker2);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Location = new global::System.Drawing.Point(452, 170);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 229;
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(14, 31);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(153, 27);
			this.radDateTimePicker2.TabIndex = 211;
			this.radDateTimePicker2.TabStop = false;
			this.radDateTimePicker2.Text = "10/02/2021";
			this.radDateTimePicker2.ThemeName = "Crystal";
			this.radDateTimePicker2.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker2.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Black;
			this.label8.Location = new global::System.Drawing.Point(10, 9);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(157, 19);
			this.label8.TabIndex = 212;
			this.label8.Text = "Date Limite de période";
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Location = new global::System.Drawing.Point(446, 132);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(209, 32);
			this.panel3.TabIndex = 228;
			this.radRadioButton2.Location = new global::System.Drawing.Point(73, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(91, 22);
			this.radRadioButton2.TabIndex = 212;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Périodique";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(64, 22);
			this.radRadioButton1.TabIndex = 211;
			this.radRadioButton1.TabStop = false;
			this.radRadioButton1.Text = "Infinie";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Black;
			this.label7.Location = new global::System.Drawing.Point(442, 113);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(84, 19);
			this.label7.TabIndex = 227;
			this.label7.Text = "Réccurence";
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(258, 135);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(154, 27);
			this.radDateTimePicker1.TabIndex = 226;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "10/02/2021";
			this.radDateTimePicker1.ThemeName = "Crystal";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker1.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(254, 113);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(83, 19);
			this.label6.TabIndex = 225;
			this.label6.Text = "Date Début";
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(27, 135);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(85, 29);
			this.guna2TextBox1.TabIndex = 224;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(23, 113);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(43, 19);
			this.label4.TabIndex = 223;
			this.label4.Text = "Délai";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label3.Location = new global::System.Drawing.Point(23, 82);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(165, 19);
			this.label3.TabIndex = 222;
			this.label3.Text = "Paramètrage de période";
			this.label29.AutoSize = true;
			this.label29.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label29.ForeColor = global::System.Drawing.Color.Black;
			this.label29.Location = new global::System.Drawing.Point(23, 15);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(119, 19);
			this.label29.TabIndex = 218;
			this.label29.Text = "Choisir un article";
			this.radDropDownList2.DropDownAnimationEasing = 2;
			this.radDropDownList2.DropDownStyle = 2;
			this.radDropDownList2.Location = new global::System.Drawing.Point(23, 41);
			this.radDropDownList2.Name = "radDropDownList2";
			this.radDropDownList2.Size = new global::System.Drawing.Size(758, 24);
			this.radDropDownList2.TabIndex = 217;
			this.radDropDownList2.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList2.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList2.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(113, 113);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(58, 19);
			this.label5.TabIndex = 234;
			this.label5.Text = "Période";
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
			this.guna2ComboBox1.Location = new global::System.Drawing.Point(117, 135);
			this.guna2ComboBox1.Name = "guna2ComboBox1";
			this.guna2ComboBox1.ShadowDecoration.Parent = this.guna2ComboBox1;
			this.guna2ComboBox1.Size = new global::System.Drawing.Size(134, 29);
			this.guna2ComboBox1.TabIndex = 233;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(800, 294);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.guna2ComboBox1);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radTimePicker1);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label29);
			base.Controls.Add(this.radDropDownList2);
			base.Name = "app_planifier_da_recomp";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.app_planifier_da_recomp_Load);
			this.radTimePicker1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radDateTimePicker2.EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radDateTimePicker1.EndInit();
			this.radDropDownList2.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001F8 RID: 504
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040001F9 RID: 505
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x040001FA RID: 506
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040001FD RID: 509
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000200 RID: 512
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000201 RID: 513
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000203 RID: 515
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000205 RID: 517
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.Label label29;

		// Token: 0x04000209 RID: 521
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList2;

		// Token: 0x0400020A RID: 522
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400020C RID: 524
		private global::Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
	}
}
