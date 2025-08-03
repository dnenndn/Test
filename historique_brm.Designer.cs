namespace GMAO
{
	// Token: 0x0200007C RID: 124
	public partial class historique_brm : global::System.Windows.Forms.Form
	{
		// Token: 0x060005C9 RID: 1481 RVA: 0x000F026C File Offset: 0x000EE46C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x000F02A4 File Offset: 0x000EE4A4
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radCheckBox5 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox3 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox4 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label20 = new global::System.Windows.Forms.Label();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label19 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radCheckBox1 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox2 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox6 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox7 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.radCheckBox8 = new global::Telerik.WinControls.UI.RadCheckBox();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.radCheckBox5.BeginInit();
			this.radCheckBox3.BeginInit();
			this.radCheckBox4.BeginInit();
			this.radDateTimePicker2.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.panel2.SuspendLayout();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radCheckBox1.BeginInit();
			this.radCheckBox2.BeginInit();
			this.radCheckBox6.BeginInit();
			this.radCheckBox7.BeginInit();
			this.radCheckBox8.BeginInit();
			base.SuspendLayout();
			this.panel6.Location = new global::System.Drawing.Point(73, 13);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(1055, 12);
			this.panel6.TabIndex = 85;
			this.panel6.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
			this.label1.AutoSize = true;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(3, 5);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(69, 13);
			this.label1.TabIndex = 84;
			this.label1.Text = "Filtre Avancé";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.guna2TextBox2);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.radDateTimePicker2);
			this.panel1.Controls.Add(this.label20);
			this.panel1.Controls.Add(this.radDateTimePicker1);
			this.panel1.Controls.Add(this.label19);
			this.panel1.Location = new global::System.Drawing.Point(13, 31);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 160);
			this.panel1.TabIndex = 83;
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
			this.guna2TextBox2.Location = new global::System.Drawing.Point(226, 83);
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(251, 27);
			this.guna2TextBox2.TabIndex = 215;
			this.guna2TextBox2.TextChanged += new global::System.EventHandler(this.guna2TextBox2_TextChanged);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(222, 58);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(77, 19);
			this.label5.TabIndex = 214;
			this.label5.Text = "Retour par";
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
			this.TextBox1.Location = new global::System.Drawing.Point(336, 28);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(145, 27);
			this.TextBox1.TabIndex = 211;
			this.TextBox1.TextChanged += new global::System.EventHandler(this.TextBox1_TextChanged);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(332, 6);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(57, 19);
			this.label3.TabIndex = 210;
			this.label3.Text = "N° BSM";
			this.panel3.Controls.Add(this.radCheckBox5);
			this.panel3.Controls.Add(this.radCheckBox3);
			this.panel3.Controls.Add(this.radCheckBox4);
			this.panel3.Location = new global::System.Drawing.Point(7, 80);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(209, 32);
			this.panel3.TabIndex = 209;
			this.radCheckBox5.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox5.Location = new global::System.Drawing.Point(111, 7);
			this.radCheckBox5.Name = "radCheckBox5";
			this.radCheckBox5.Size = new global::System.Drawing.Size(67, 18);
			this.radCheckBox5.TabIndex = 210;
			this.radCheckBox5.Text = "Rebuté";
			this.radCheckBox5.ThemeName = "Crystal";
			this.radCheckBox5.ToggleState = 1;
			this.radCheckBox5.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox5_ToggleStateChanged);
			this.radCheckBox3.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox3.Location = new global::System.Drawing.Point(58, 7);
			this.radCheckBox3.Name = "radCheckBox3";
			this.radCheckBox3.Size = new global::System.Drawing.Size(47, 18);
			this.radCheckBox3.TabIndex = 209;
			this.radCheckBox3.Text = "Usé";
			this.radCheckBox3.ThemeName = "Crystal";
			this.radCheckBox3.ToggleState = 1;
			this.radCheckBox3.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox3_ToggleStateChanged);
			this.radCheckBox4.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox4.Location = new global::System.Drawing.Point(3, 7);
			this.radCheckBox4.Name = "radCheckBox4";
			this.radCheckBox4.Size = new global::System.Drawing.Size(53, 18);
			this.radCheckBox4.TabIndex = 208;
			this.radCheckBox4.Text = "Neuf";
			this.radCheckBox4.ThemeName = "Crystal";
			this.radCheckBox4.ToggleState = 1;
			this.radCheckBox4.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox4_ToggleStateChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(3, 58);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(93, 19);
			this.label2.TabIndex = 208;
			this.label2.Text = "Etat de stock";
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(172, 28);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(149, 27);
			this.radDateTimePicker2.TabIndex = 205;
			this.radDateTimePicker2.TabStop = false;
			this.radDateTimePicker2.Text = "10/02/2021";
			this.radDateTimePicker2.ThemeName = "Crystal";
			this.radDateTimePicker2.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			this.radDateTimePicker2.ValueChanged += new global::System.EventHandler(this.radDateTimePicker2_ValueChanged);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker2.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.Black;
			this.label20.Location = new global::System.Drawing.Point(3, 6);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(81, 19);
			this.label20.TabIndex = 202;
			this.label20.Text = "Date début";
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(7, 28);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(149, 27);
			this.radDateTimePicker1.TabIndex = 204;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "10/02/2021";
			this.radDateTimePicker1.ThemeName = "Crystal";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			this.radDateTimePicker1.ValueChanged += new global::System.EventHandler(this.radDateTimePicker1_ValueChanged);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker1.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.ForeColor = global::System.Drawing.Color.Black;
			this.label19.Location = new global::System.Drawing.Point(168, 6);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(60, 19);
			this.label19.TabIndex = 203;
			this.label19.Text = "Date fin";
			this.panel2.Controls.Add(this.radCheckBox8);
			this.panel2.Controls.Add(this.radCheckBox7);
			this.panel2.Controls.Add(this.radCheckBox6);
			this.panel2.Controls.Add(this.radCheckBox2);
			this.panel2.Controls.Add(this.radCheckBox1);
			this.panel2.Location = new global::System.Drawing.Point(508, 6);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(365, 143);
			this.panel2.TabIndex = 216;
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(13, 197);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Date de retour";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Heure";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 110;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Retour par";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column9";
			gridViewTextBoxColumn4.Width = 170;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "N° BSM";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column11";
			gridViewTextBoxColumn5.Width = 100;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Stock";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column8";
			gridViewTextBoxColumn6.Width = 120;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Type retour";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column10";
			gridViewTextBoxColumn7.Width = 280;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column6";
			gridViewImageColumn.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewImageColumn
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnablePaging = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.ReadOnly = true;
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(1104, 349);
			this.radGridView1.TabIndex = 86;
			this.radGridView1.ThemeName = "Fluent";
			this.radCheckBox1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox1.Location = new global::System.Drawing.Point(7, 7);
			this.radCheckBox1.Name = "radCheckBox1";
			this.radCheckBox1.Size = new global::System.Drawing.Size(341, 18);
			this.radCheckBox1.TabIndex = 209;
			this.radCheckBox1.Text = "Ancienne Pièce lors de la sortie d'une nouvelle pièce";
			this.radCheckBox1.ThemeName = "Crystal";
			this.radCheckBox1.ToggleState = 1;
			this.radCheckBox1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
			this.radCheckBox2.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox2.Location = new global::System.Drawing.Point(7, 33);
			this.radCheckBox2.Name = "radCheckBox2";
			this.radCheckBox2.Size = new global::System.Drawing.Size(169, 18);
			this.radCheckBox2.TabIndex = 210;
			this.radCheckBox2.Text = "Pièce sortie non utilisée";
			this.radCheckBox2.ThemeName = "Crystal";
			this.radCheckBox2.ToggleState = 1;
			this.radCheckBox2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox2_ToggleStateChanged);
			this.radCheckBox6.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox6.Location = new global::System.Drawing.Point(7, 59);
			this.radCheckBox6.Name = "radCheckBox6";
			this.radCheckBox6.Size = new global::System.Drawing.Size(182, 18);
			this.radCheckBox6.TabIndex = 211;
			this.radCheckBox6.Text = "Pièce trouvée dans l'usine";
			this.radCheckBox6.ThemeName = "Crystal";
			this.radCheckBox6.ToggleState = 1;
			this.radCheckBox6.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox6_ToggleStateChanged);
			this.radCheckBox7.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox7.Location = new global::System.Drawing.Point(7, 85);
			this.radCheckBox7.Name = "radCheckBox7";
			this.radCheckBox7.Size = new global::System.Drawing.Size(198, 18);
			this.radCheckBox7.TabIndex = 212;
			this.radCheckBox7.Text = "Retour Pièce pour réparation";
			this.radCheckBox7.ThemeName = "Crystal";
			this.radCheckBox7.ToggleState = 1;
			this.radCheckBox7.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox7_ToggleStateChanged);
			this.radCheckBox8.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radCheckBox8.Location = new global::System.Drawing.Point(7, 111);
			this.radCheckBox8.Name = "radCheckBox8";
			this.radCheckBox8.Size = new global::System.Drawing.Size(109, 18);
			this.radCheckBox8.TabIndex = 213;
			this.radCheckBox8.Text = "Retour qualité";
			this.radCheckBox8.ThemeName = "Crystal";
			this.radCheckBox8.ToggleState = 1;
			this.radCheckBox8.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox8_ToggleStateChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "historique_brm";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.historique_brm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radCheckBox5.EndInit();
			this.radCheckBox3.EndInit();
			this.radCheckBox4.EndInit();
			this.radDateTimePicker2.EndInit();
			this.radDateTimePicker1.EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radCheckBox1.EndInit();
			this.radCheckBox2.EndInit();
			this.radCheckBox6.EndInit();
			this.radCheckBox7.EndInit();
			this.radCheckBox8.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040007A9 RID: 1961
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040007AA RID: 1962
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040007AB RID: 1963
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040007AC RID: 1964
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040007AD RID: 1965
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x040007AE RID: 1966
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040007AF RID: 1967
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040007B0 RID: 1968
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040007B1 RID: 1969
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040007B2 RID: 1970
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox5;

		// Token: 0x040007B3 RID: 1971
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox3;

		// Token: 0x040007B4 RID: 1972
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox4;

		// Token: 0x040007B5 RID: 1973
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040007B6 RID: 1974
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x040007B7 RID: 1975
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040007B8 RID: 1976
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x040007B9 RID: 1977
		private global::System.Windows.Forms.Label label19;

		// Token: 0x040007BA RID: 1978
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040007BB RID: 1979
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040007BC RID: 1980
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040007BD RID: 1981
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040007BE RID: 1982
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox1;

		// Token: 0x040007BF RID: 1983
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox8;

		// Token: 0x040007C0 RID: 1984
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox7;

		// Token: 0x040007C1 RID: 1985
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox6;

		// Token: 0x040007C2 RID: 1986
		private global::Telerik.WinControls.UI.RadCheckBox radCheckBox2;
	}
}
