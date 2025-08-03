namespace GMAO
{
	// Token: 0x02000051 RID: 81
	public partial class creer_bl_st : global::System.Windows.Forms.Form
	{
		// Token: 0x060003A3 RID: 931 RVA: 0x00098330 File Offset: 0x00096530
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00098368 File Offset: 0x00096568
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition2 = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label5 = new global::System.Windows.Forms.Label();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label18 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.panel1.SuspendLayout();
			this.radGridView2.BeginInit();
			this.radGridView2.MasterTemplate.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.radDropDownList6.BeginInit();
			base.SuspendLayout();
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(12, 52);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column6";
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "ID Commande";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column5";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Date Commande";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 150;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Article";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column4";
			gridViewTextBoxColumn4.Width = 200;
			gridViewTextBoxColumn5.HeaderText = "Ref interne";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column2";
			gridViewTextBoxColumn5.Width = 150;
			gridViewTextBoxColumn6.HeaderText = "Activité";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column3";
			gridViewTextBoxColumn6.Width = 200;
			gridViewCommandColumn.EnableExpressionEditor = false;
			gridViewCommandColumn.Name = "column7";
			gridViewCommandColumn.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewCommandColumn.Width = 150;
			gridViewTextBoxColumn7.HeaderText = "id_t";
			gridViewTextBoxColumn7.IsVisible = false;
			gridViewTextBoxColumn7.Name = "column8";
			gridViewTextBoxColumn8.HeaderText = "source";
			gridViewTextBoxColumn8.IsVisible = false;
			gridViewTextBoxColumn8.Name = "column9";
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewCommandColumn,
				gridViewTextBoxColumn7,
				gridViewTextBoxColumn8
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
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
			this.radGridView1.Size = new global::System.Drawing.Size(1080, 215);
			this.radGridView1.TabIndex = 84;
			this.radGridView1.ThemeName = "Fluent";
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.radGridView2);
			this.panel1.Controls.Add(this.guna2Button1);
			this.panel1.Controls.Add(this.radDateTimePicker1);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Location = new global::System.Drawing.Point(12, 273);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1080, 216);
			this.panel1.TabIndex = 85;
			this.radGridView2.BackColor = global::System.Drawing.Color.White;
			this.radGridView2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView2.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView2.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView2.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView2.Location = new global::System.Drawing.Point(13, 69);
			this.radGridView2.MasterTemplate.AllowAddNewRow = false;
			this.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnReorder = false;
			this.radGridView2.MasterTemplate.AllowDeleteRow = false;
			this.radGridView2.MasterTemplate.AllowDragToGroup = false;
			this.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn9.HeaderText = "id";
			gridViewTextBoxColumn9.IsVisible = false;
			gridViewTextBoxColumn9.Name = "column6";
			gridViewTextBoxColumn9.ReadOnly = true;
			gridViewTextBoxColumn10.EnableExpressionEditor = false;
			gridViewTextBoxColumn10.HeaderText = "ID Commande";
			gridViewTextBoxColumn10.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn10.Name = "column5";
			gridViewTextBoxColumn10.ReadOnly = true;
			gridViewTextBoxColumn10.Width = 150;
			gridViewTextBoxColumn11.EnableExpressionEditor = false;
			gridViewTextBoxColumn11.HeaderText = "Article";
			gridViewTextBoxColumn11.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn11.Name = "column4";
			gridViewTextBoxColumn11.ReadOnly = true;
			gridViewTextBoxColumn11.Width = 200;
			gridViewTextBoxColumn12.HeaderText = "Ref interne";
			gridViewTextBoxColumn12.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn12.Name = "column2";
			gridViewTextBoxColumn12.ReadOnly = true;
			gridViewTextBoxColumn12.Width = 150;
			gridViewTextBoxColumn13.HeaderText = "Activité";
			gridViewTextBoxColumn13.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn13.Name = "column3";
			gridViewTextBoxColumn13.ReadOnly = true;
			gridViewTextBoxColumn13.Width = 200;
			gridViewTextBoxColumn14.HeaderText = "Quantité";
			gridViewTextBoxColumn14.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn14.Name = "column10";
			gridViewTextBoxColumn14.ReadOnly = true;
			gridViewTextBoxColumn14.Width = 120;
			gridViewTextBoxColumn15.HeaderText = "Prix U HT";
			gridViewTextBoxColumn15.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn15.Name = "column1";
			gridViewTextBoxColumn15.Width = 100;
			gridViewTextBoxColumn16.HeaderText = "Remise";
			gridViewTextBoxColumn16.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn16.Name = "column7";
			gridViewTextBoxColumn16.Width = 120;
			gridViewTextBoxColumn17.HeaderText = "id_t";
			gridViewTextBoxColumn17.IsVisible = false;
			gridViewTextBoxColumn17.Name = "column8";
			gridViewTextBoxColumn17.ReadOnly = true;
			gridViewTextBoxColumn18.HeaderText = "source";
			gridViewTextBoxColumn18.IsVisible = false;
			gridViewTextBoxColumn18.Name = "column9";
			gridViewTextBoxColumn18.ReadOnly = true;
			this.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn9,
				gridViewTextBoxColumn10,
				gridViewTextBoxColumn11,
				gridViewTextBoxColumn12,
				gridViewTextBoxColumn13,
				gridViewTextBoxColumn14,
				gridViewTextBoxColumn15,
				gridViewTextBoxColumn16,
				gridViewTextBoxColumn17,
				gridViewTextBoxColumn18
			});
			this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView2.MasterTemplate.EnableFiltering = true;
			this.radGridView2.MasterTemplate.EnableSorting = false;
			this.radGridView2.MasterTemplate.ShowFilteringRow = false;
			this.radGridView2.MasterTemplate.ViewDefinition = viewDefinition2;
			this.radGridView2.Name = "radGridView2";
			this.radGridView2.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView2.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView2.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView2.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView2.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView2.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView2.ShowGroupPanel = false;
			this.radGridView2.Size = new global::System.Drawing.Size(1006, 217);
			this.radGridView2.TabIndex = 212;
			this.radGridView2.ThemeName = "Fluent";
			this.guna2Button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(534, 22);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 211;
			this.guna2Button1.Text = "Créer BL";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(13, 25);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(267, 27);
			this.radDateTimePicker1.TabIndex = 210;
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
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(10, 7);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(86, 15);
			this.label5.TabIndex = 209;
			this.label5.Text = "Date Livraison";
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(12, 25);
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
			this.label18.Location = new global::System.Drawing.Point(8, 3);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(97, 19);
			this.label18.TabIndex = 163;
			this.label18.Text = "Sous_Traitant";
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
			this.TextBox1.Location = new global::System.Drawing.Point(294, 25);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(145, 27);
			this.TextBox1.TabIndex = 214;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(291, 7);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(103, 15);
			this.label6.TabIndex = 213;
			this.label6.Text = "N° BL Fournisseur";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "creer_bl_st";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.creer_bl_st_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radGridView2.MasterTemplate.EndInit();
			this.radGridView2.EndInit();
			this.radDateTimePicker1.EndInit();
			this.radDropDownList6.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040004DA RID: 1242
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040004DB RID: 1243
		public global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040004DC RID: 1244
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040004DD RID: 1245
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x040004DE RID: 1246
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040004DF RID: 1247
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x040004E0 RID: 1248
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x040004E1 RID: 1249
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040004E2 RID: 1250
		public global::Telerik.WinControls.UI.RadGridView radGridView2;

		// Token: 0x040004E3 RID: 1251
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040004E4 RID: 1252
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040004E5 RID: 1253
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040004E6 RID: 1254
		private global::System.Windows.Forms.Label label6;
	}
}
