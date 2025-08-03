namespace GMAO
{
	// Token: 0x02000168 RID: 360
	public partial class tb_variation_prix_article_vr : global::System.Windows.Forms.Form
	{
		// Token: 0x06001043 RID: 4163 RVA: 0x00290C84 File Offset: 0x0028EE84
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00290CBC File Offset: 0x0028EEBC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.tb_variation_prix_article_vr));
			global::Telerik.WinControls.UI.CartesianArea cartesianArea = new global::Telerik.WinControls.UI.CartesianArea();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.office2013LightTheme1 = new global::Telerik.WinControls.Themes.Office2013LightTheme();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label17 = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radTreeView1.BeginInit();
			this.panel1.SuspendLayout();
			this.radChartView1.BeginInit();
			this.radDateTimePicker2.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.panel3.SuspendLayout();
			this.radRadioButton1.BeginInit();
			this.radRadioButton2.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(10, 23);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(229, 25);
			this.guna2TextBox1.TabIndex = 176;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 19);
			this.label2.TabIndex = 175;
			this.label2.Text = "Article";
			this.radTreeView1.Location = new global::System.Drawing.Point(12, 52);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(255, 437);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 174;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (4).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk (1).ico");
			this.imageList1.Images.SetKeyName(3, "icons8-word-96.png");
			this.imageList1.Images.SetKeyName(4, "icons8-ms-excel-104.png");
			this.imageList1.Images.SetKeyName(5, "icons8-pdf-40.png");
			this.imageList1.Images.SetKeyName(6, "icons8-txt-80.png");
			this.imageList1.Images.SetKeyName(7, "icons8-image-96.png");
			this.imageList1.Images.SetKeyName(8, "icons8-winrar-240.png");
			this.imageList1.Images.SetKeyName(9, "icons8-fichier-128.png");
			this.panel1.Controls.Add(this.label17);
			this.panel1.Controls.Add(this.label18);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new global::System.Drawing.Point(282, 52);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(710, 133);
			this.panel1.TabIndex = 177;
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.ForeColor = global::System.Drawing.Color.Black;
			this.label17.Location = new global::System.Drawing.Point(608, 106);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(49, 15);
			this.label17.TabIndex = 254;
			this.label17.Text = "label17";
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label18.Location = new global::System.Drawing.Point(548, 106);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(62, 15);
			this.label18.TabIndex = 253;
			this.label18.Text = "Etendue = ";
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.ForeColor = global::System.Drawing.Color.Black;
			this.label16.Location = new global::System.Drawing.Point(457, 106);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(49, 15);
			this.label16.TabIndex = 252;
			this.label16.Text = "label16";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.ForeColor = global::System.Drawing.Color.Black;
			this.label15.Location = new global::System.Drawing.Point(311, 106);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(49, 15);
			this.label15.TabIndex = 251;
			this.label15.Text = "label15";
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Black;
			this.label14.Location = new global::System.Drawing.Point(172, 106);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(49, 15);
			this.label14.TabIndex = 250;
			this.label14.Text = "label14";
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.ForeColor = global::System.Drawing.Color.Black;
			this.label13.Location = new global::System.Drawing.Point(231, 82);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(49, 15);
			this.label13.TabIndex = 249;
			this.label13.Text = "label13";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.Black;
			this.label12.Location = new global::System.Drawing.Point(262, 56);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(49, 15);
			this.label12.TabIndex = 248;
			this.label12.Text = "label12";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Black;
			this.label11.Location = new global::System.Drawing.Point(234, 30);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(49, 15);
			this.label11.TabIndex = 247;
			this.label11.Text = "label11";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(221, 3);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(49, 15);
			this.label10.TabIndex = 246;
			this.label10.Text = "label10";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label9.Location = new global::System.Drawing.Point(427, 106);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(32, 15);
			this.label9.TabIndex = 245;
			this.label9.Text = "Cv = ";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label8.Location = new global::System.Drawing.Point(286, 106);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(26, 15);
			this.label8.TabIndex = 244;
			this.label8.Text = "σ = ";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label7.Location = new global::System.Drawing.Point(149, 106);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(26, 15);
			this.label7.TabIndex = 243;
			this.label7.Text = "X̅ = ";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label6.Location = new global::System.Drawing.Point(149, 106);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(0, 15);
			this.label6.TabIndex = 242;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label5.Location = new global::System.Drawing.Point(149, 82);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(81, 15);
			this.label5.TabIndex = 241;
			this.label5.Text = "Désignation : ";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label4.Location = new global::System.Drawing.Point(149, 56);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(107, 15);
			this.label4.TabIndex = 240;
			this.label4.Text = "Référence Article : ";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label3.Location = new global::System.Drawing.Point(149, 30);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(81, 15);
			this.label3.TabIndex = 239;
			this.label3.Text = "Code Article : ";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label1.Location = new global::System.Drawing.Point(149, 3);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(66, 15);
			this.label1.TabIndex = 238;
			this.label1.Text = "ID Article : ";
			cartesianArea.ShowGrid = true;
			this.radChartView1.AreaDesign = cartesianArea;
			this.radChartView1.Location = new global::System.Drawing.Point(282, 191);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowTrackBall = true;
			this.radChartView1.Size = new global::System.Drawing.Size(710, 298);
			this.radChartView1.TabIndex = 238;
			this.radChartView1.ThemeName = "Crystal";
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(410, 22);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(117, 23);
			this.radDateTimePicker2.TabIndex = 242;
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
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(283, 22);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(120, 23);
			this.radDateTimePicker1.TabIndex = 241;
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
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.Black;
			this.label20.Location = new global::System.Drawing.Point(279, 4);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(66, 15);
			this.label20.TabIndex = 239;
			this.label20.Text = "Date début";
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.ForeColor = global::System.Drawing.Color.Black;
			this.label19.Location = new global::System.Drawing.Point(407, 4);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(49, 15);
			this.label19.TabIndex = 240;
			this.label19.Text = "Date fin";
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Location = new global::System.Drawing.Point(615, 12);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(202, 29);
			this.panel3.TabIndex = 243;
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f);
			this.radRadioButton1.Location = new global::System.Drawing.Point(6, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(99, 20);
			this.radRadioButton1.TabIndex = 232;
			this.radRadioButton1.Text = "Non Reparable";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f);
			this.radRadioButton2.Location = new global::System.Drawing.Point(112, 5);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(76, 20);
			this.radRadioButton2.TabIndex = 50;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Réparable";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.pictureBox1.Location = new global::System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(140, 127);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1004, 501);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.radDateTimePicker2);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label20);
			base.Controls.Add(this.label19);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.radTreeView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "tb_variation_prix_article_vr";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.tb_variation_prix_article_vr_Load);
			this.radTreeView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radChartView1.EndInit();
			this.radDateTimePicker2.EndInit();
			this.radDateTimePicker1.EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton1.EndInit();
			this.radRadioButton2.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001421 RID: 5153
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001422 RID: 5154
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04001423 RID: 5155
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04001424 RID: 5156
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x04001425 RID: 5157
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04001426 RID: 5158
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04001427 RID: 5159
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04001428 RID: 5160
		private global::Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;

		// Token: 0x04001429 RID: 5161
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x0400142A RID: 5162
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400142B RID: 5163
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400142C RID: 5164
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400142D RID: 5165
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x0400142E RID: 5166
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400142F RID: 5167
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04001430 RID: 5168
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04001431 RID: 5169
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04001432 RID: 5170
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04001433 RID: 5171
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04001434 RID: 5172
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04001435 RID: 5173
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04001436 RID: 5174
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04001437 RID: 5175
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04001438 RID: 5176
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04001439 RID: 5177
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400143A RID: 5178
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400143B RID: 5179
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400143C RID: 5180
		private global::System.Windows.Forms.Label label11;

		// Token: 0x0400143D RID: 5181
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400143E RID: 5182
		private global::System.Windows.Forms.Label label17;

		// Token: 0x0400143F RID: 5183
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04001440 RID: 5184
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x04001441 RID: 5185
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04001442 RID: 5186
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04001443 RID: 5187
		private global::System.Windows.Forms.Label label19;

		// Token: 0x04001444 RID: 5188
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04001445 RID: 5189
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04001446 RID: 5190
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;
	}
}
