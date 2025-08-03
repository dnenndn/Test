namespace GMAO
{
	// Token: 0x0200001B RID: 27
	public partial class arbre_defaillance : global::System.Windows.Forms.Form
	{
		// Token: 0x06000178 RID: 376 RVA: 0x00042D1C File Offset: 0x00040F1C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00042D54 File Offset: 0x00040F54
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.arbre_defaillance));
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label18 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radDiagram1 = new global::Telerik.WinControls.UI.RadDiagram();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.guna2Button4 = new global::Guna.UI2.WinForms.Guna2Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem2 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.guna2Button3 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button5 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button6 = new global::Guna.UI2.WinForms.Guna2Button();
			this.breezeTheme1 = new global::Telerik.WinControls.Themes.BreezeTheme();
			this.radDropDownList6.BeginInit();
			this.radDiagram1.BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.radDropDownList1.BeginInit();
			this.arbre.BeginInit();
			base.SuspendLayout();
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(16, 31);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(264, 24);
			this.radDropDownList6.TabIndex = 164;
			this.radDropDownList6.ThemeName = "Crystal";
			this.radDropDownList6.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList6_SelectedIndexChanged);
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
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Black;
			this.label18.Location = new global::System.Drawing.Point(12, 9);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(132, 19);
			this.label18.TabIndex = 163;
			this.label18.Text = "Choisir Défaillance";
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
			this.TextBox2.Location = new global::System.Drawing.Point(286, 12);
			this.TextBox2.Multiline = true;
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(806, 44);
			this.TextBox2.TabIndex = 165;
			this.radDiagram1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radDiagram1.IsBackgroundSurfaceVisible = false;
			this.radDiagram1.IsDraggingEnabled = false;
			this.radDiagram1.IsEditable = false;
			this.radDiagram1.IsManipulationAdornerVisible = false;
			this.radDiagram1.Location = new global::System.Drawing.Point(16, 99);
			this.radDiagram1.Name = "radDiagram1";
			this.radDiagram1.SelectionMode = 3;
			this.radDiagram1.SerializedXml = componentResourceManager.GetString("radDiagram1.SerializedXml");
			this.radDiagram1.Size = new global::System.Drawing.Size(439, 400);
			this.radDiagram1.TabIndex = 166;
			this.radDiagram1.Text = "radDiagram1";
			this.panel1.Controls.Add(this.guna2Button4);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.arbre);
			this.panel1.Location = new global::System.Drawing.Point(461, 68);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(608, 431);
			this.panel1.TabIndex = 167;
			this.guna2Button4.BorderRadius = 8;
			this.guna2Button4.CheckedState.Parent = this.guna2Button4;
			this.guna2Button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button4.CustomImages.Parent = this.guna2Button4;
			this.guna2Button4.FillColor = global::System.Drawing.Color.Silver;
			this.guna2Button4.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button4.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button4.HoverState.Parent = this.guna2Button4;
			this.guna2Button4.Location = new global::System.Drawing.Point(226, 15);
			this.guna2Button4.Name = "guna2Button4";
			this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
			this.guna2Button4.Size = new global::System.Drawing.Size(78, 28);
			this.guna2Button4.TabIndex = 183;
			this.guna2Button4.Text = "Fermer";
			this.guna2Button4.Click += new global::System.EventHandler(this.guna2Button4_Click);
			this.panel2.Controls.Add(this.guna2TextBox1);
			this.panel2.Controls.Add(this.guna2Button1);
			this.panel2.Controls.Add(this.guna2Button2);
			this.panel2.Controls.Add(this.radDropDownList1);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new global::System.Drawing.Point(310, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(295, 397);
			this.panel2.TabIndex = 175;
			this.guna2TextBox1.BorderRadius = 2;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.Enabled = false;
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Location = new global::System.Drawing.Point(17, 244);
			this.guna2TextBox1.Multiline = true;
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(240, 103);
			this.guna2TextBox1.TabIndex = 174;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(17, 353);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 176;
			this.guna2Button1.Text = "Ajouter";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(127, 353);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button2.TabIndex = 169;
			this.guna2Button2.Text = "Annuler";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.radDropDownList1.DropDownAnimationEasing = 2;
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(17, 214);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(240, 24);
			this.radDropDownList1.TabIndex = 182;
			this.radDropDownList1.ThemeName = "Crystal";
			this.radDropDownList1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged_1);
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
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.Black;
			this.label6.Location = new global::System.Drawing.Point(17, 192);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(194, 19);
			this.label6.TabIndex = 181;
			this.label6.Text = "Choisir Cause de défaillance";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Black;
			this.label4.Location = new global::System.Drawing.Point(17, 153);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(49, 19);
			this.label4.TabIndex = 180;
			this.label4.Text = "label4";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Black;
			this.label5.Location = new global::System.Drawing.Point(17, 134);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(178, 19);
			this.label5.TabIndex = 179;
			this.label5.Text = "Code Défaillance Parent : ";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(17, 101);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(49, 19);
			this.label3.TabIndex = 178;
			this.label3.Text = "label3";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(17, 82);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(159, 19);
			this.label1.TabIndex = 177;
			this.label1.Text = "ID Défaillance Parent : ";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label2.Location = new global::System.Drawing.Point(17, 47);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(140, 19);
			this.label2.TabIndex = 175;
			this.label2.Text = "Ajouter Défaillance";
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ImageList = this.imageList1;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(7, 49);
			this.arbre.Name = "arbre";
			this.arbre.RadContextMenu = this.radContextMenu1;
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.Size = new global::System.Drawing.Size(297, 372);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 174;
			this.arbre.ThemeName = "Breeze";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).NodeSpacing = -1;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "et operator.png");
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1,
				this.radMenuItem2
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Afficher";
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "Supprimer";
			this.guna2Button3.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button3.BorderRadius = 8;
			this.guna2Button3.BorderThickness = 1;
			this.guna2Button3.CheckedState.Parent = this.guna2Button3;
			this.guna2Button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button3.CustomImages.Parent = this.guna2Button3;
			this.guna2Button3.FillColor = global::System.Drawing.Color.White;
			this.guna2Button3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button3.HoverState.Parent = this.guna2Button3;
			this.guna2Button3.Location = new global::System.Drawing.Point(16, 63);
			this.guna2Button3.Name = "guna2Button3";
			this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
			this.guna2Button3.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button3.TabIndex = 169;
			this.guna2Button3.Text = "Modifier";
			this.guna2Button3.Click += new global::System.EventHandler(this.guna2Button3_Click);
			this.guna2Button5.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button5.BorderRadius = 8;
			this.guna2Button5.BorderThickness = 1;
			this.guna2Button5.CheckedState.Parent = this.guna2Button5;
			this.guna2Button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button5.CustomImages.Parent = this.guna2Button5;
			this.guna2Button5.FillColor = global::System.Drawing.Color.White;
			this.guna2Button5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button5.ForeColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button5.HoverState.Parent = this.guna2Button5;
			this.guna2Button5.Location = new global::System.Drawing.Point(126, 63);
			this.guna2Button5.Name = "guna2Button5";
			this.guna2Button5.ShadowDecoration.Parent = this.guna2Button5;
			this.guna2Button5.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button5.TabIndex = 170;
			this.guna2Button5.Text = "Export";
			this.guna2Button5.Click += new global::System.EventHandler(this.guna2Button5_Click);
			this.guna2Button6.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button6.BorderRadius = 8;
			this.guna2Button6.BorderThickness = 1;
			this.guna2Button6.CheckedState.Parent = this.guna2Button6;
			this.guna2Button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button6.CustomImages.Parent = this.guna2Button6;
			this.guna2Button6.FillColor = global::System.Drawing.Color.White;
			this.guna2Button6.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button6.ForeColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button6.HoverState.Parent = this.guna2Button6;
			this.guna2Button6.Location = new global::System.Drawing.Point(236, 63);
			this.guna2Button6.Name = "guna2Button6";
			this.guna2Button6.ShadowDecoration.Parent = this.guna2Button6;
			this.guna2Button6.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button6.TabIndex = 171;
			this.guna2Button6.Text = "Imprimer";
			this.guna2Button6.Click += new global::System.EventHandler(this.guna2Button6_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.guna2Button6);
			base.Controls.Add(this.guna2Button5);
			base.Controls.Add(this.guna2Button3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radDiagram1);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label18);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "arbre_defaillance";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.arbre_defaillance_Load);
			this.radDropDownList6.EndInit();
			this.radDiagram1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radDropDownList1.EndInit();
			this.arbre.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000220 RID: 544
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000221 RID: 545
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000223 RID: 547
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000224 RID: 548
		private global::Telerik.WinControls.UI.RadDiagram radDiagram1;

		// Token: 0x04000225 RID: 549
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000226 RID: 550
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000227 RID: 551
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000228 RID: 552
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04000229 RID: 553
		private global::Guna.UI2.WinForms.Guna2Button guna2Button3;

		// Token: 0x0400022A RID: 554
		private global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400022C RID: 556
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x0400022D RID: 557
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x0400022E RID: 558
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem2;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000230 RID: 560
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000231 RID: 561
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000232 RID: 562
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000239 RID: 569
		public global::Guna.UI2.WinForms.Guna2Button guna2Button4;

		// Token: 0x0400023A RID: 570
		private global::Guna.UI2.WinForms.Guna2Button guna2Button5;

		// Token: 0x0400023B RID: 571
		private global::Guna.UI2.WinForms.Guna2Button guna2Button6;

		// Token: 0x0400023C RID: 572
		private global::Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
	}
}
