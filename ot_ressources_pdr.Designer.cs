namespace GMAO
{
	// Token: 0x020000D1 RID: 209
	public partial class ot_ressources_pdr : global::System.Windows.Forms.Form
	{
		// Token: 0x06000968 RID: 2408 RVA: 0x001832CC File Offset: 0x001814CC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00183304 File Offset: 0x00181504
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
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_ressources_pdr));
			global::GMAO.ot_ressources_pdr.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label30 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			global::GMAO.ot_ressources_pdr.radGridView3.BeginInit();
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.BeginInit();
			this.panel1.SuspendLayout();
			this.radTimePicker1.BeginInit();
			this.radButton1.BeginInit();
			this.radDateTimePicker1.BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			global::GMAO.ot_ressources_pdr.radGridView3.BackColor = global::System.Drawing.Color.White;
			global::GMAO.ot_ressources_pdr.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			global::GMAO.ot_ressources_pdr.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			global::GMAO.ot_ressources_pdr.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			global::GMAO.ot_ressources_pdr.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			global::GMAO.ot_ressources_pdr.radGridView3.Location = new global::System.Drawing.Point(12, 34);
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowAddNewRow = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowColumnReorder = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowDeleteRow = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowDragToGroup = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowEditRow = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.HeaderText = "Date Souhaitée";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column9";
			gridViewTextBoxColumn2.Width = 120;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Code Article";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 110;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Réf Article";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Désignation";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.Width = 300;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Quantité";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column4";
			gridViewTextBoxColumn6.Width = 90;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Unité";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column6";
			gridViewTextBoxColumn7.Width = 90;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column5";
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column8";
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewImageColumn,
				gridViewImageColumn2
			});
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.EnableAlternatingRowColor = true;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.EnableFiltering = true;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.EnableSorting = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.ShowFilteringRow = false;
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.ViewDefinition = viewDefinition;
			global::GMAO.ot_ressources_pdr.radGridView3.Name = "radGridView3";
			global::GMAO.ot_ressources_pdr.radGridView3.Padding = new global::System.Windows.Forms.Padding(1);
			global::GMAO.ot_ressources_pdr.radGridView3.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			global::GMAO.ot_ressources_pdr.radGridView3.PrintStyle.ChildViewPrintMode = 0;
			global::GMAO.ot_ressources_pdr.radGridView3.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			global::GMAO.ot_ressources_pdr.radGridView3.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			global::GMAO.ot_ressources_pdr.radGridView3.ReadOnly = true;
			global::GMAO.ot_ressources_pdr.radGridView3.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			global::GMAO.ot_ressources_pdr.radGridView3.ShowGroupPanel = false;
			global::GMAO.ot_ressources_pdr.radGridView3.Size = new global::System.Drawing.Size(1050, 197);
			global::GMAO.ot_ressources_pdr.radGridView3.TabIndex = 244;
			global::GMAO.ot_ressources_pdr.radGridView3.ThemeName = "Fluent";
			this.panel1.Controls.Add(this.radTimePicker1);
			this.panel1.Controls.Add(this.radButton1);
			this.panel1.Controls.Add(this.TextBox1);
			this.panel1.Controls.Add(this.radDateTimePicker1);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label30);
			this.panel1.Location = new global::System.Drawing.Point(12, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(993, 30);
			this.panel1.TabIndex = 245;
			this.radTimePicker1.Location = new global::System.Drawing.Point(546, 2);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(100, 24);
			this.radTimePicker1.TabIndex = 279;
			this.radTimePicker1.TabStop = false;
			this.radTimePicker1.ThemeName = "Fluent";
			this.radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 11, 20, 14, 26, 2, 128));
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(653, 4);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 276;
			this.radButton1.Text = "Modifier";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
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
			this.TextBox1.Location = new global::System.Drawing.Point(59, 2);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(205, 25);
			this.TextBox1.TabIndex = 253;
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(417, 2);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(127, 24);
			this.radDateTimePicker1.TabIndex = 278;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "20/11/2021";
			this.radDateTimePicker1.ThemeName = "Fluent";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(769, 4);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(27, 22);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 271;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(270, 2);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(141, 12);
			this.label8.TabIndex = 277;
			this.label8.Text = "Date et Heure Souhaitée";
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(3, 2);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(53, 12);
			this.label30.TabIndex = 252;
			this.label30.Text = "Quantité";
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(1031, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(31, 26);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(global::GMAO.ot_ressources_pdr.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_ressources_pdr";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_ressources_pdr_Load);
			global::GMAO.ot_ressources_pdr.radGridView3.MasterTemplate.EndInit();
			global::GMAO.ot_ressources_pdr.radGridView3.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radTimePicker1.EndInit();
			this.radButton1.EndInit();
			this.radDateTimePicker1.EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000C73 RID: 3187
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C74 RID: 3188
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000C75 RID: 3189
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000C76 RID: 3190
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000C77 RID: 3191
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x04000C78 RID: 3192
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000C79 RID: 3193
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000C7A RID: 3194
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000C7B RID: 3195
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000C7C RID: 3196
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x04000C7D RID: 3197
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000C7E RID: 3198
		internal global::System.Windows.Forms.Label label8;

		// Token: 0x04000C7F RID: 3199
		public static global::Telerik.WinControls.UI.RadGridView radGridView3;
	}
}
