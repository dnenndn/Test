namespace GMAO
{
	// Token: 0x02000059 RID: 89
	public partial class creer_reception : global::System.Windows.Forms.Form
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x000B63FC File Offset: 0x000B45FC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000B6434 File Offset: 0x000B4634
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn = new global::Telerik.WinControls.UI.GridViewCheckBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.creer_reception));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewRatingColumn gridViewRatingColumn = new global::Telerik.WinControls.UI.GridViewRatingColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition2 = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radPanel2 = new global::Telerik.WinControls.UI.RadPanel();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label3 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.radDropDownList6.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radPanel2.BeginInit();
			this.radPanel2.SuspendLayout();
			this.radDateTimePicker1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.radGridView2.BeginInit();
			this.radGridView2.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(151, 19);
			this.label1.TabIndex = 166;
			this.label1.Text = "Choisir un fournisseur";
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(16, 31);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList6.TabIndex = 167;
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
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(16, 61);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.HeaderText = "Date";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 120;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Créateur";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.ReadOnly = true;
			gridViewTextBoxColumn3.Width = 150;
			gridViewCheckBoxColumn.EnableExpressionEditor = false;
			gridViewCheckBoxColumn.MinWidth = 20;
			gridViewCheckBoxColumn.Name = "column4";
			gridViewCheckBoxColumn.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewCheckBoxColumn
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
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(492, 462);
			this.radGridView1.TabIndex = 168;
			this.radGridView1.ThemeName = "Fluent";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(354, 26);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(154, 29);
			this.guna2Button1.TabIndex = 169;
			this.guna2Button1.Text = "Afficher Bon de réception";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radPanel2.Controls.Add(this.radDateTimePicker1);
			this.radPanel2.Controls.Add(this.label3);
			this.radPanel2.Controls.Add(this.pictureBox1);
			this.radPanel2.Controls.Add(this.label2);
			this.radPanel2.Controls.Add(this.TextBox1);
			this.radPanel2.Controls.Add(this.radGridView2);
			this.radPanel2.Controls.Add(this.guna2Button2);
			this.radPanel2.Controls.Add(this.label5);
			this.radPanel2.Controls.Add(this.label4);
			this.radPanel2.Location = new global::System.Drawing.Point(514, 26);
			this.radPanel2.Name = "radPanel2";
			this.radPanel2.Size = new global::System.Drawing.Size(603, 497);
			this.radPanel2.TabIndex = 170;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel2.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Silver;
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(6, 90);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(267, 27);
			this.radDateTimePicker1.TabIndex = 206;
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
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(3, 72);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(86, 15);
			this.label3.TabIndex = 183;
			this.label3.Text = "Date réception";
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(564, 6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(36, 29);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 182;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(3, 22);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(86, 15);
			this.label2.TabIndex = 181;
			this.label2.Text = "Commentaire :";
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
			this.TextBox1.Location = new global::System.Drawing.Point(6, 39);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(512, 29);
			this.TextBox1.TabIndex = 180;
			this.radGridView2.AutoScroll = true;
			this.radGridView2.BackColor = global::System.Drawing.Color.White;
			this.radGridView2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView2.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView2.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView2.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView2.Location = new global::System.Drawing.Point(0, 124);
			this.radGridView2.MasterTemplate.AllowAddNewRow = false;
			this.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnReorder = false;
			this.radGridView2.MasterTemplate.AllowDeleteRow = false;
			this.radGridView2.MasterTemplate.AllowDragToGroup = false;
			this.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn4.HeaderText = "id_commande";
			gridViewTextBoxColumn4.IsVisible = false;
			gridViewTextBoxColumn4.Name = "column7";
			gridViewTextBoxColumn5.HeaderText = "id_article";
			gridViewTextBoxColumn5.IsVisible = false;
			gridViewTextBoxColumn5.Name = "column8";
			gridViewTextBoxColumn6.HeaderText = "Demandeur";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column11";
			gridViewTextBoxColumn6.Width = 200;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Code Article";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column1";
			gridViewTextBoxColumn7.ReadOnly = true;
			gridViewTextBoxColumn7.Width = 120;
			gridViewTextBoxColumn8.EnableExpressionEditor = false;
			gridViewTextBoxColumn8.HeaderText = "Désignation";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column3";
			gridViewTextBoxColumn8.ReadOnly = true;
			gridViewTextBoxColumn8.Width = 150;
			gridViewTextBoxColumn9.EnableExpressionEditor = false;
			gridViewTextBoxColumn9.HeaderText = "Qt commandée";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column2";
			gridViewTextBoxColumn9.ReadOnly = true;
			gridViewTextBoxColumn9.Width = 130;
			gridViewTextBoxColumn10.EnableExpressionEditor = false;
			gridViewTextBoxColumn10.HeaderText = "Qt déja récu";
			gridViewTextBoxColumn10.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn10.Name = "column4";
			gridViewTextBoxColumn10.ReadOnly = true;
			gridViewTextBoxColumn10.Width = 150;
			gridViewTextBoxColumn11.EnableExpressionEditor = false;
			gridViewTextBoxColumn11.HeaderText = "Qt récu";
			gridViewTextBoxColumn11.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn11.Name = "column5";
			gridViewTextBoxColumn11.Width = 100;
			gridViewTextBoxColumn12.HeaderText = "Qt Bon état";
			gridViewTextBoxColumn12.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn12.Name = "column10";
			gridViewTextBoxColumn12.Width = 120;
			gridViewTextBoxColumn13.HeaderText = "Qt Mauvaise état";
			gridViewTextBoxColumn13.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn13.Name = "column9";
			gridViewTextBoxColumn13.ReadOnly = true;
			gridViewTextBoxColumn13.Width = 170;
			gridViewRatingColumn.EnableExpressionEditor = false;
			gridViewRatingColumn.HeaderText = "Etat";
			gridViewRatingColumn.Name = "column6";
			gridViewRatingColumn.Width = 102;
			gridViewTextBoxColumn14.HeaderText = "id_da";
			gridViewTextBoxColumn14.IsVisible = false;
			gridViewTextBoxColumn14.Name = "column12";
			this.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewTextBoxColumn8,
				gridViewTextBoxColumn9,
				gridViewTextBoxColumn10,
				gridViewTextBoxColumn11,
				gridViewTextBoxColumn12,
				gridViewTextBoxColumn13,
				gridViewRatingColumn,
				gridViewTextBoxColumn14
			});
			this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
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
			this.radGridView2.Size = new global::System.Drawing.Size(600, 370);
			this.radGridView2.TabIndex = 179;
			this.radGridView2.ThemeName = "Fluent";
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(524, 39);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(76, 29);
			this.guna2Button2.TabIndex = 178;
			this.guna2Button2.Text = "Création";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(84, 6);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(45, 15);
			this.label5.TabIndex = 174;
			this.label5.Text = "label 5";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(3, 6);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(79, 15);
			this.label4.TabIndex = 173;
			this.label4.Text = "Fournisseur :";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.radPanel2);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "creer_reception";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.creer_reception_Load);
			this.radDropDownList6.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radPanel2.EndInit();
			this.radPanel2.ResumeLayout(false);
			this.radPanel2.PerformLayout();
			this.radDateTimePicker1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.radGridView2.MasterTemplate.EndInit();
			this.radGridView2.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005C0 RID: 1472
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040005C1 RID: 1473
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040005C2 RID: 1474
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x040005C3 RID: 1475
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040005C4 RID: 1476
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040005C5 RID: 1477
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040005C6 RID: 1478
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x040005C7 RID: 1479
		private global::Telerik.WinControls.UI.RadPanel radPanel2;

		// Token: 0x040005C8 RID: 1480
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040005C9 RID: 1481
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040005CA RID: 1482
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x040005CB RID: 1483
		private global::Telerik.WinControls.UI.RadGridView radGridView2;

		// Token: 0x040005CC RID: 1484
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040005CD RID: 1485
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040005CE RID: 1486
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040005CF RID: 1487
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040005D0 RID: 1488
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;
	}
}
