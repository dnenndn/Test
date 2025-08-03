namespace GMAO
{
	// Token: 0x020000B0 RID: 176
	public partial class ot_bt_projet : global::System.Windows.Forms.Form
	{
		// Token: 0x060007F9 RID: 2041 RVA: 0x0015A214 File Offset: 0x00158414
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0015A24C File Offset: 0x0015844C
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.label30 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.guna2TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.radDateTimePicker2.BeginInit();
			this.radButton1.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 69);
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
			gridViewTextBoxColumn2.HeaderText = "Sous Traitant";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Description Projet";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 420;
			gridViewTextBoxColumn4.HeaderText = "Date début";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column5";
			gridViewTextBoxColumn4.Width = 100;
			gridViewTextBoxColumn5.HeaderText = "Date fin";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column6";
			gridViewTextBoxColumn5.Width = 100;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Coût (HT)";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column2";
			gridViewTextBoxColumn6.Width = 100;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column8";
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewImageColumn
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
			this.radGridView3.Size = new global::System.Drawing.Size(1050, 164);
			this.radGridView3.TabIndex = 246;
			this.radGridView3.ThemeName = "Fluent";
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(10, 3);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(82, 12);
			this.label30.TabIndex = 254;
			this.label30.Text = "Ajouter Projet";
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
			this.TextBox1.Location = new global::System.Drawing.Point(12, 38);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(323, 25);
			this.TextBox1.TabIndex = 261;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(10, 23);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(69, 12);
			this.label1.TabIndex = 260;
			this.label1.Text = "Description";
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(531, 38);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(139, 24);
			this.radDateTimePicker1.TabIndex = 280;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "20/11/2021";
			this.radDateTimePicker1.ThemeName = "Fluent";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(529, 25);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(67, 12);
			this.label8.TabIndex = 279;
			this.label8.Text = "Date Début";
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(676, 38);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(129, 24);
			this.radDateTimePicker2.TabIndex = 282;
			this.radDateTimePicker2.TabStop = false;
			this.radDateTimePicker2.Text = "20/11/2021";
			this.radDateTimePicker2.ThemeName = "Fluent";
			this.radDateTimePicker2.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(674, 25);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 12);
			this.label2.TabIndex = 281;
			this.label2.Text = "Date Fin";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(340, 23);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(79, 12);
			this.label3.TabIndex = 283;
			this.label3.Text = "Sous Traitant";
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(342, 38);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(183, 25);
			this.guna2TextBox1.TabIndex = 284;
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
			this.guna2TextBox2.Location = new global::System.Drawing.Point(813, 38);
			this.guna2TextBox2.Name = "guna2TextBox2";
			this.guna2TextBox2.PasswordChar = '\0';
			this.guna2TextBox2.PlaceholderText = "";
			this.guna2TextBox2.SelectedText = "";
			this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
			this.guna2TextBox2.Size = new global::System.Drawing.Size(118, 25);
			this.guna2TextBox2.TabIndex = 286;
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label4.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(811, 23);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(57, 12);
			this.label4.TabIndex = 285;
			this.label4.Text = "Coût (HT)";
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(937, 38);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 287;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.guna2TextBox2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.radDateTimePicker2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label30);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_bt_projet";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_bt_projet_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radDateTimePicker1.EndInit();
			this.radDateTimePicker2.EndInit();
			this.radButton1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000AE7 RID: 2791
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000AE8 RID: 2792
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000AE9 RID: 2793
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000AEA RID: 2794
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000AEB RID: 2795
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000AEC RID: 2796
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000AED RID: 2797
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000AEE RID: 2798
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000AEF RID: 2799
		internal global::System.Windows.Forms.Label label8;

		// Token: 0x04000AF0 RID: 2800
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x04000AF1 RID: 2801
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000AF2 RID: 2802
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000AF3 RID: 2803
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000AF4 RID: 2804
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

		// Token: 0x04000AF5 RID: 2805
		internal global::System.Windows.Forms.Label label4;

		// Token: 0x04000AF6 RID: 2806
		private global::Telerik.WinControls.UI.RadButton radButton1;
	}
}
