namespace GMAO
{
	// Token: 0x020000D0 RID: 208
	public partial class ot_ressources_outillage : global::System.Windows.Forms.Form
	{
		// Token: 0x0600095D RID: 2397 RVA: 0x00181E44 File Offset: 0x00180044
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00181E7C File Offset: 0x0018007C
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label30 = new global::System.Windows.Forms.Label();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDropDownList1.BeginInit();
			this.radTimePicker1.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.radButton1.BeginInit();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(14, 24);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList1.TabIndex = 259;
			this.radDropDownList1.ThemeName = "Fluent";
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(12, 9);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(98, 12);
			this.label30.TabIndex = 258;
			this.label30.Text = "Famille Outillage";
			this.radTimePicker1.Location = new global::System.Drawing.Point(537, 24);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(100, 24);
			this.radTimePicker1.TabIndex = 282;
			this.radTimePicker1.TabStop = false;
			this.radTimePicker1.ThemeName = "Fluent";
			this.radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 11, 20, 14, 26, 2, 128));
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(349, 24);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(182, 24);
			this.radDateTimePicker1.TabIndex = 281;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "20/11/2021";
			this.radDateTimePicker1.ThemeName = "Fluent";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(347, 11);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(140, 12);
			this.label8.TabIndex = 280;
			this.label8.Text = "Date et Heure souhaitée";
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(643, 25);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 283;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(14, 55);
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
			gridViewTextBoxColumn2.HeaderText = "Famille Outillage";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 250;
			gridViewTextBoxColumn3.HeaderText = "Date Souhaitée";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column5";
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.HeaderText = "Quantité";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 150;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column8";
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
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
			this.radGridView3.Size = new global::System.Drawing.Size(1048, 176);
			this.radGridView3.TabIndex = 284;
			this.radGridView3.ThemeName = "Fluent";
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
			this.TextBox1.Location = new global::System.Drawing.Point(225, 23);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(118, 25);
			this.TextBox1.TabIndex = 286;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(223, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(53, 12);
			this.label1.TabIndex = 285;
			this.label1.Text = "Quantité";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.radTimePicker1);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label30);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_ressources_outillage";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_ressources_outillage_Load);
			this.radDropDownList1.EndInit();
			this.radTimePicker1.EndInit();
			this.radDateTimePicker1.EndInit();
			this.radButton1.EndInit();
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000C66 RID: 3174
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C67 RID: 3175
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C68 RID: 3176
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C69 RID: 3177
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000C6A RID: 3178
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000C6B RID: 3179
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x04000C6C RID: 3180
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000C6D RID: 3181
		internal global::System.Windows.Forms.Label label8;

		// Token: 0x04000C6E RID: 3182
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000C6F RID: 3183
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000C70 RID: 3184
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000C71 RID: 3185
		internal global::System.Windows.Forms.Label label1;
	}
}
