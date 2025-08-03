namespace GMAO
{
	// Token: 0x020000B5 RID: 181
	public partial class ot_diagnostic_final : global::System.Windows.Forms.Form
	{
		// Token: 0x0600083C RID: 2108 RVA: 0x00162450 File Offset: 0x00160650
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00162488 File Offset: 0x00160688
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_diagnostic_final));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new global::Telerik.WinControls.UI.GridViewCommandColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radTimePicker2 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label9 = new global::System.Windows.Forms.Label();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label30 = new global::System.Windows.Forms.Label();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radButton2 = new global::Telerik.WinControls.UI.RadButton();
			this.radDropDownList2 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.radTimePicker2.BeginInit();
			this.radDateTimePicker2.BeginInit();
			this.radTimePicker1.BeginInit();
			this.radDateTimePicker1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.radButton1.BeginInit();
			this.radDropDownList1.BeginInit();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.radButton2.BeginInit();
			this.radDropDownList2.BeginInit();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.radTimePicker2);
			this.panel1.Controls.Add(this.radDateTimePicker2);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.radTimePicker1);
			this.panel1.Controls.Add(this.radDateTimePicker1);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.radButton1);
			this.panel1.Controls.Add(this.radDropDownList1);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Location = new global::System.Drawing.Point(12, 237);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1021, 98);
			this.panel1.TabIndex = 249;
			this.radTimePicker2.Location = new global::System.Drawing.Point(502, 64);
			this.radTimePicker2.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker2.MinValue = new global::System.DateTime(0L);
			this.radTimePicker2.Name = "radTimePicker2";
			this.radTimePicker2.Size = new global::System.Drawing.Size(100, 24);
			this.radTimePicker2.TabIndex = 286;
			this.radTimePicker2.TabStop = false;
			this.radTimePicker2.ThemeName = "Fluent";
			this.radTimePicker2.Value = new global::System.DateTime?(new global::System.DateTime(2021, 11, 20, 14, 26, 2, 128));
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(314, 64);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(182, 24);
			this.radDateTimePicker2.TabIndex = 285;
			this.radDateTimePicker2.TabStop = false;
			this.radDateTimePicker2.Text = "20/11/2021";
			this.radDateTimePicker2.ThemeName = "Fluent";
			this.radDateTimePicker2.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.label9.AutoSize = true;
			this.label9.BackColor = global::System.Drawing.Color.Transparent;
			this.label9.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label9.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.DimGray;
			this.label9.Location = new global::System.Drawing.Point(312, 51);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(116, 12);
			this.label9.TabIndex = 284;
			this.label9.Text = "Date et Heure de fin";
			this.radTimePicker1.Location = new global::System.Drawing.Point(193, 64);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(100, 24);
			this.radTimePicker1.TabIndex = 283;
			this.radTimePicker1.TabStop = false;
			this.radTimePicker1.ThemeName = "Fluent";
			this.radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 11, 20, 14, 26, 2, 128));
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(5, 64);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(182, 24);
			this.radDateTimePicker1.TabIndex = 282;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "20/11/2021";
			this.radDateTimePicker1.ThemeName = "Fluent";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(3, 51);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(134, 12);
			this.label8.TabIndex = 281;
			this.label8.Text = "Date et Heure de début";
			this.TextBox1.BorderRadius = 2;
			this.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox1.DefaultText = "";
			this.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.DisabledState.Parent = this.TextBox1;
			this.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.Enabled = false;
			this.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.FocusedState.Parent = this.TextBox1;
			this.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.HoverState.Parent = this.TextBox1;
			this.TextBox1.Location = new global::System.Drawing.Point(261, 24);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(601, 24);
			this.TextBox1.TabIndex = 280;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(991, 2);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 278;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(868, 23);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 277;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(5, 24);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(250, 24);
			this.radDropDownList1.TabIndex = 259;
			this.radDropDownList1.ThemeName = "Fluent";
			this.radDropDownList1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged);
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(3, 9);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(103, 12);
			this.label30.TabIndex = 258;
			this.label30.Text = "Choisir Opération";
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 12);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Code Défaillance";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column5";
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Désignation";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 530;
			gridViewCommandColumn.EnableExpressionEditor = false;
			gridViewCommandColumn.Name = "column2";
			gridViewCommandColumn.Width = 100;
			gridViewCommandColumn2.EnableExpressionEditor = false;
			gridViewCommandColumn2.Name = "column3";
			gridViewCommandColumn2.Width = 100;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewCommandColumn,
				gridViewCommandColumn2
			});
			this.radGridView3.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView3.MasterTemplate.EnableFiltering = true;
			this.radGridView3.MasterTemplate.EnableSorting = false;
			this.radGridView3.MasterTemplate.ShowFilteringRow = false;
			this.radGridView3.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView3.Name = "radGridView3";
			this.radGridView3.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView3.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView3.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView3.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView3.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView3.ReadOnly = true;
			this.radGridView3.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView3.ShowGroupPanel = false;
			this.radGridView3.Size = new global::System.Drawing.Size(1021, 141);
			this.radGridView3.TabIndex = 248;
			this.radGridView3.ThemeName = "Fluent";
			this.panel2.Controls.Add(this.TextBox2);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.radButton2);
			this.panel2.Controls.Add(this.radDropDownList2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new global::System.Drawing.Point(12, 159);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1021, 66);
			this.panel2.TabIndex = 250;
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
			this.TextBox2.Location = new global::System.Drawing.Point(261, 24);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(601, 24);
			this.TextBox2.TabIndex = 279;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(984, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 278;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.radButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton2.Location = new global::System.Drawing.Point(868, 24);
			this.radButton2.Name = "radButton2";
			this.radButton2.Size = new global::System.Drawing.Size(110, 24);
			this.radButton2.TabIndex = 277;
			this.radButton2.Text = "Ajouter";
			this.radButton2.ThemeName = "Crystal";
			this.radButton2.Click += new global::System.EventHandler(this.radButton2_Click);
			this.radDropDownList2.DropDownStyle = 2;
			this.radDropDownList2.Location = new global::System.Drawing.Point(5, 24);
			this.radDropDownList2.Name = "radDropDownList2";
			this.radDropDownList2.Size = new global::System.Drawing.Size(250, 24);
			this.radDropDownList2.TabIndex = 259;
			this.radDropDownList2.ThemeName = "Fluent";
			this.radDropDownList2.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList2_SelectedIndexChanged);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(105, 12);
			this.label1.TabIndex = 258;
			this.label1.Text = "Choisir Symptôme";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1091, 243);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_diagnostic_final";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_diagnostic_final_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radTimePicker2.EndInit();
			this.radDateTimePicker2.EndInit();
			this.radTimePicker1.EndInit();
			this.radDateTimePicker1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.radButton1.EndInit();
			this.radDropDownList1.EndInit();
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.radButton2.EndInit();
			this.radDropDownList2.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000B37 RID: 2871
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B38 RID: 2872
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000B39 RID: 2873
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000B3A RID: 2874
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000B3B RID: 2875
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000B3C RID: 2876
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000B3D RID: 2877
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000B3E RID: 2878
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000B3F RID: 2879
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000B40 RID: 2880
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000B41 RID: 2881
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000B42 RID: 2882
		private global::Telerik.WinControls.UI.RadButton radButton2;

		// Token: 0x04000B43 RID: 2883
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList2;

		// Token: 0x04000B44 RID: 2884
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000B45 RID: 2885
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000B46 RID: 2886
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000B47 RID: 2887
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x04000B48 RID: 2888
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000B49 RID: 2889
		internal global::System.Windows.Forms.Label label8;

		// Token: 0x04000B4A RID: 2890
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker2;

		// Token: 0x04000B4B RID: 2891
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x04000B4C RID: 2892
		internal global::System.Windows.Forms.Label label9;
	}
}
