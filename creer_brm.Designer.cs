namespace GMAO
{
	// Token: 0x02000052 RID: 82
	public partial class creer_brm : global::System.Windows.Forms.Form
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x0009B21C File Offset: 0x0009941C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0009B254 File Offset: 0x00099454
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton5 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton3 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.label10 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label18 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton8 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton6 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label21 = new global::System.Windows.Forms.Label();
			this.radTimePicker1.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.panel1.SuspendLayout();
			this.radRadioButton5.BeginInit();
			this.radRadioButton3.BeginInit();
			this.radRadioButton4.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radTreeView1.BeginInit();
			this.radDropDownList6.BeginInit();
			this.panel3.SuspendLayout();
			this.radRadioButton7.BeginInit();
			this.radRadioButton8.BeginInit();
			this.radRadioButton6.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			base.SuspendLayout();
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(388, 108);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(98, 19);
			this.label3.TabIndex = 201;
			this.label3.Text = "Date et heure";
			this.radTimePicker1.Location = new global::System.Drawing.Point(392, 163);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(158, 24);
			this.radTimePicker1.TabIndex = 200;
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
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(392, 130);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(158, 27);
			this.radDateTimePicker1.TabIndex = 199;
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
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(1007, 192);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 198;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.panel1.Controls.Add(this.radRadioButton5);
			this.panel1.Controls.Add(this.radRadioButton3);
			this.panel1.Controls.Add(this.radRadioButton4);
			this.panel1.Location = new global::System.Drawing.Point(380, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(432, 29);
			this.panel1.TabIndex = 197;
			this.radRadioButton5.Location = new global::System.Drawing.Point(201, 4);
			this.radRadioButton5.Name = "radRadioButton5";
			this.radRadioButton5.Size = new global::System.Drawing.Size(103, 22);
			this.radRadioButton5.TabIndex = 177;
			this.radRadioButton5.TabStop = false;
			this.radRadioButton5.Text = "Stock rebuté";
			this.radRadioButton5.ThemeName = "Crystal";
			this.radRadioButton3.Location = new global::System.Drawing.Point(109, 4);
			this.radRadioButton3.Name = "radRadioButton3";
			this.radRadioButton3.Size = new global::System.Drawing.Size(86, 22);
			this.radRadioButton3.TabIndex = 50;
			this.radRadioButton3.TabStop = false;
			this.radRadioButton3.Text = "Stock usé";
			this.radRadioButton3.ThemeName = "Crystal";
			this.radRadioButton4.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton4.Location = new global::System.Drawing.Point(10, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(91, 22);
			this.radRadioButton4.TabIndex = 48;
			this.radRadioButton4.Text = "Stock neuf";
			this.radRadioButton4.ThemeName = "Crystal";
			this.radRadioButton4.ToggleState = 1;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(388, 3);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(93, 19);
			this.label1.TabIndex = 196;
			this.label1.Text = "Etat de stock";
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Red;
			this.label14.Location = new global::System.Drawing.Point(728, 59);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(17, 19);
			this.label14.TabIndex = 189;
			this.label14.Text = "*";
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(303, 225);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 80;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.ReadOnly = true;
			gridViewTextBoxColumn2.Width = 225;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Quantité";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 100;
			gridViewTextBoxColumn4.HeaderText = "Unité";
			gridViewTextBoxColumn4.Name = "column4";
			gridViewTextBoxColumn4.ReadOnly = true;
			gridViewTextBoxColumn4.Width = 130;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column6";
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewImageColumn
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(808, 314);
			this.radGridView1.TabIndex = 195;
			this.radGridView1.ThemeName = "Fluent";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(671, 59);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(57, 19);
			this.label10.TabIndex = 187;
			this.label10.Text = "N° BSM";
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(27, 190);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(229, 30);
			this.guna2TextBox1.TabIndex = 194;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
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
			this.TextBox1.Location = new global::System.Drawing.Point(672, 81);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(244, 24);
			this.TextBox1.TabIndex = 188;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(25, 170);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 19);
			this.label2.TabIndex = 193;
			this.label2.Text = "Article";
			this.radTreeView1.Location = new global::System.Drawing.Point(29, 225);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu1;
			this.radTreeView1.Size = new global::System.Drawing.Size(255, 314);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 192;
			this.radTreeView1.ThemeName = "Office2010Silver";
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(392, 81);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList6.TabIndex = 191;
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
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Black;
			this.label18.Location = new global::System.Drawing.Point(388, 59);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(77, 19);
			this.label18.TabIndex = 190;
			this.label18.Text = "Retour par";
			this.panel3.Controls.Add(this.radRadioButton7);
			this.panel3.Controls.Add(this.radRadioButton8);
			this.panel3.Controls.Add(this.radRadioButton6);
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Location = new global::System.Drawing.Point(4, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(365, 143);
			this.panel3.TabIndex = 186;
			this.radRadioButton7.Location = new global::System.Drawing.Point(10, 116);
			this.radRadioButton7.Name = "radRadioButton7";
			this.radRadioButton7.Size = new global::System.Drawing.Size(111, 22);
			this.radRadioButton7.TabIndex = 53;
			this.radRadioButton7.TabStop = false;
			this.radRadioButton7.Text = "Retour qualité";
			this.radRadioButton7.ThemeName = "Crystal";
			this.radRadioButton7.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton7_ToggleStateChanged);
			this.radRadioButton8.Location = new global::System.Drawing.Point(10, 88);
			this.radRadioButton8.Name = "radRadioButton8";
			this.radRadioButton8.Size = new global::System.Drawing.Size(200, 22);
			this.radRadioButton8.TabIndex = 52;
			this.radRadioButton8.TabStop = false;
			this.radRadioButton8.Text = "Retour Pièce pour réparation";
			this.radRadioButton8.ThemeName = "Crystal";
			this.radRadioButton8.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton8_ToggleStateChanged);
			this.radRadioButton6.Location = new global::System.Drawing.Point(10, 60);
			this.radRadioButton6.Name = "radRadioButton6";
			this.radRadioButton6.Size = new global::System.Drawing.Size(184, 22);
			this.radRadioButton6.TabIndex = 51;
			this.radRadioButton6.TabStop = false;
			this.radRadioButton6.Text = "Pièce trouvée dans l'usine";
			this.radRadioButton6.ThemeName = "Crystal";
			this.radRadioButton6.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton6_ToggleStateChanged);
			this.radRadioButton2.Location = new global::System.Drawing.Point(10, 32);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(171, 22);
			this.radRadioButton2.TabIndex = 50;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Pièce sortie non utilisée";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(10, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(343, 22);
			this.radRadioButton1.TabIndex = 48;
			this.radRadioButton1.Text = "Ancienne Pièce lors de la sortie d'une nouvelle pièce";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.label21.AutoSize = true;
			this.label21.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label21.ForeColor = global::System.Drawing.Color.Black;
			this.label21.Location = new global::System.Drawing.Point(13, 3);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(106, 19);
			this.label21.TabIndex = 185;
			this.label21.Text = "Type de Retour";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.radTimePicker1);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.radTreeView1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.label21);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "creer_brm";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.creer_brm_Load);
			this.radTimePicker1.EndInit();
			this.radDateTimePicker1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton5.EndInit();
			this.radRadioButton3.EndInit();
			this.radRadioButton4.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radTreeView1.EndInit();
			this.radDropDownList6.EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton7.EndInit();
			this.radRadioButton8.EndInit();
			this.radRadioButton6.EndInit();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040004E7 RID: 1255
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040004E8 RID: 1256
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040004E9 RID: 1257
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040004EA RID: 1258
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x040004EB RID: 1259
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x040004EC RID: 1260
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x040004ED RID: 1261
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040004EE RID: 1262
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x040004EF RID: 1263
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x040004F0 RID: 1264
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x040004F1 RID: 1265
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040004F2 RID: 1266
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton5;

		// Token: 0x040004F3 RID: 1267
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton3;

		// Token: 0x040004F4 RID: 1268
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x040004F5 RID: 1269
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040004F6 RID: 1270
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040004F7 RID: 1271
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040004F8 RID: 1272
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040004F9 RID: 1273
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x040004FA RID: 1274
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040004FB RID: 1275
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040004FC RID: 1276
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x040004FD RID: 1277
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x040004FE RID: 1278
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040004FF RID: 1279
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000500 RID: 1280
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000501 RID: 1281
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000502 RID: 1282
		private global::System.Windows.Forms.Label label21;

		// Token: 0x04000503 RID: 1283
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x04000504 RID: 1284
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton8;

		// Token: 0x04000505 RID: 1285
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton6;
	}
}
