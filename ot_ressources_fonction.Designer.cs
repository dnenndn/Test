namespace GMAO
{
	// Token: 0x020000CF RID: 207
	public partial class ot_ressources_fonction : global::System.Windows.Forms.Form
	{
		// Token: 0x06000953 RID: 2387 RVA: 0x00180318 File Offset: 0x0017E518
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00180350 File Offset: 0x0017E550
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
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.label30 = new global::System.Windows.Forms.Label();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radDropDownList1.BeginInit();
			this.panel3.SuspendLayout();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radButton1.BeginInit();
			this.radTimePicker1.BeginInit();
			this.radDateTimePicker1.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 72);
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
			gridViewTextBoxColumn2.HeaderText = "Fonction";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.HeaderText = "Date début";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column5";
			gridViewTextBoxColumn3.Width = 120;
			gridViewTextBoxColumn4.HeaderText = "Heure début";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column6";
			gridViewTextBoxColumn4.Width = 100;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Nbre Requis";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column2";
			gridViewTextBoxColumn5.Width = 130;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Minutes Planifiées";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column3";
			gridViewTextBoxColumn6.Width = 160;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Type de coûts";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column4";
			gridViewTextBoxColumn7.Width = 100;
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
				gridViewTextBoxColumn7,
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
			this.radGridView3.TabIndex = 245;
			this.radGridView3.ThemeName = "Fluent";
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(12, 9);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(54, 12);
			this.label30.TabIndex = 253;
			this.label30.Text = "Fonction";
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(14, 24);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList1.TabIndex = 257;
			this.radDropDownList1.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(237, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(73, 12);
			this.label1.TabIndex = 258;
			this.label1.Text = "Nbre Requis";
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
			this.TextBox1.Location = new global::System.Drawing.Point(239, 24);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(118, 25);
			this.TextBox1.TabIndex = 259;
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
			this.TextBox2.Location = new global::System.Drawing.Point(365, 24);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.PasswordChar = '\0';
			this.TextBox2.PlaceholderText = "";
			this.TextBox2.SelectedText = "";
			this.TextBox2.ShadowDecoration.Parent = this.TextBox2;
			this.TextBox2.Size = new global::System.Drawing.Size(131, 25);
			this.TextBox2.TabIndex = 261;
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(363, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(105, 12);
			this.label2.TabIndex = 260;
			this.label2.Text = "Minutes Planifiées";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(792, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(89, 12);
			this.label3.TabIndex = 262;
			this.label3.Text = "Type des coûts";
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Location = new global::System.Drawing.Point(794, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(159, 32);
			this.panel3.TabIndex = 263;
			this.radRadioButton2.Location = new global::System.Drawing.Point(76, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(72, 22);
			this.radRadioButton2.TabIndex = 246;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Externe";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(69, 22);
			this.radRadioButton1.TabIndex = 245;
			this.radRadioButton1.TabStop = false;
			this.radRadioButton1.Text = "Interne";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(958, 23);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 276;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radTimePicker1.Location = new global::System.Drawing.Point(690, 24);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(100, 24);
			this.radTimePicker1.TabIndex = 279;
			this.radTimePicker1.TabStop = false;
			this.radTimePicker1.ThemeName = "Fluent";
			this.radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 11, 20, 14, 26, 2, 128));
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(502, 24);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(182, 24);
			this.radDateTimePicker1.TabIndex = 278;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "20/11/2021";
			this.radDateTimePicker1.ThemeName = "Fluent";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(500, 11);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(134, 12);
			this.label8.TabIndex = 277;
			this.label8.Text = "Date et Heure de début";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.radTimePicker1);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.TextBox2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label30);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_ressources_fonction";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_ressources_fonction_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radDropDownList1.EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radButton1.EndInit();
			this.radTimePicker1.EndInit();
			this.radDateTimePicker1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000C54 RID: 3156
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C55 RID: 3157
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000C56 RID: 3158
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000C57 RID: 3159
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000C58 RID: 3160
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000C59 RID: 3161
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000C5A RID: 3162
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x04000C5B RID: 3163
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000C5C RID: 3164
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000C5D RID: 3165
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C5E RID: 3166
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C5F RID: 3167
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000C60 RID: 3168
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000C61 RID: 3169
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000C62 RID: 3170
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000C63 RID: 3171
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x04000C64 RID: 3172
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000C65 RID: 3173
		internal global::System.Windows.Forms.Label label8;
	}
}
