namespace GMAO
{
	// Token: 0x02000077 RID: 119
	public partial class gamme_fonction : global::System.Windows.Forms.Form
	{
		// Token: 0x06000586 RID: 1414 RVA: 0x000E7944 File Offset: 0x000E5B44
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x000E797C File Offset: 0x000E5B7C
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
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.radButton2 = new global::Telerik.WinControls.UI.RadButton();
			this.label26 = new global::System.Windows.Forms.Label();
			this.guna2TextBox6 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.guna2TextBox5 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label24 = new global::System.Windows.Forms.Label();
			this.label25 = new global::System.Windows.Forms.Label();
			this.radDropDownList9 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radGridView2.BeginInit();
			this.radGridView2.MasterTemplate.BeginInit();
			this.radButton2.BeginInit();
			this.panel5.SuspendLayout();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radDropDownList9.BeginInit();
			base.SuspendLayout();
			this.radGridView2.BackColor = global::System.Drawing.Color.White;
			this.radGridView2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView2.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView2.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView2.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView2.Location = new global::System.Drawing.Point(6, 55);
			this.radGridView2.MasterTemplate.AllowAddNewRow = false;
			this.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnReorder = false;
			this.radGridView2.MasterTemplate.AllowDeleteRow = false;
			this.radGridView2.MasterTemplate.AllowDragToGroup = false;
			this.radGridView2.MasterTemplate.AllowEditRow = false;
			this.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.HeaderText = "id_fonction";
			gridViewTextBoxColumn2.IsVisible = false;
			gridViewTextBoxColumn2.Name = "column5";
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Fonction";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 300;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Nbre Requis";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 130;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Minutes Planifiées";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.Width = 160;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Type de coûts";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column4";
			gridViewTextBoxColumn6.Width = 100;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column8";
			this.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewImageColumn
			});
			this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView2.MasterTemplate.EnableFiltering = true;
			this.radGridView2.MasterTemplate.EnableSorting = false;
			this.radGridView2.MasterTemplate.ShowFilteringRow = false;
			this.radGridView2.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView2.Name = "radGridView2";
			this.radGridView2.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView2.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView2.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView2.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView2.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView2.ReadOnly = true;
			this.radGridView2.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView2.ShowGroupPanel = false;
			this.radGridView2.Size = new global::System.Drawing.Size(974, 191);
			this.radGridView2.TabIndex = 297;
			this.radGridView2.ThemeName = "Fluent";
			this.radButton2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton2.Location = new global::System.Drawing.Point(827, 18);
			this.radButton2.Name = "radButton2";
			this.radButton2.Size = new global::System.Drawing.Size(110, 24);
			this.radButton2.TabIndex = 296;
			this.radButton2.Text = "Ajouter";
			this.radButton2.ThemeName = "Crystal";
			this.radButton2.Click += new global::System.EventHandler(this.radButton2_Click);
			this.label26.AutoSize = true;
			this.label26.BackColor = global::System.Drawing.Color.Transparent;
			this.label26.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label26.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.ForeColor = global::System.Drawing.Color.DimGray;
			this.label26.Location = new global::System.Drawing.Point(644, 3);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(89, 12);
			this.label26.TabIndex = 295;
			this.label26.Text = "Type des coûts";
			this.guna2TextBox6.BorderRadius = 2;
			this.guna2TextBox6.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox6.DefaultText = "";
			this.guna2TextBox6.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox6.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox6.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox6.DisabledState.Parent = this.guna2TextBox6;
			this.guna2TextBox6.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox6.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox6.FocusedState.Parent = this.guna2TextBox6;
			this.guna2TextBox6.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox6.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox6.HoverState.Parent = this.guna2TextBox6;
			this.guna2TextBox6.Location = new global::System.Drawing.Point(459, 18);
			this.guna2TextBox6.Name = "guna2TextBox6";
			this.guna2TextBox6.PasswordChar = '\0';
			this.guna2TextBox6.PlaceholderText = "";
			this.guna2TextBox6.SelectedText = "";
			this.guna2TextBox6.ShadowDecoration.Parent = this.guna2TextBox6;
			this.guna2TextBox6.Size = new global::System.Drawing.Size(172, 25);
			this.guna2TextBox6.TabIndex = 294;
			this.label27.AutoSize = true;
			this.label27.BackColor = global::System.Drawing.Color.Transparent;
			this.label27.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label27.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label27.ForeColor = global::System.Drawing.Color.DimGray;
			this.label27.Location = new global::System.Drawing.Point(457, 3);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(105, 12);
			this.label27.TabIndex = 293;
			this.label27.Text = "Minutes planifiées";
			this.panel5.Controls.Add(this.radRadioButton2);
			this.panel5.Controls.Add(this.radRadioButton1);
			this.panel5.Location = new global::System.Drawing.Point(646, 18);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(159, 32);
			this.panel5.TabIndex = 292;
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
			this.guna2TextBox5.BorderRadius = 2;
			this.guna2TextBox5.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox5.DefaultText = "";
			this.guna2TextBox5.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox5.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox5.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox5.DisabledState.Parent = this.guna2TextBox5;
			this.guna2TextBox5.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox5.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox5.FocusedState.Parent = this.guna2TextBox5;
			this.guna2TextBox5.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox5.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox5.HoverState.Parent = this.guna2TextBox5;
			this.guna2TextBox5.Location = new global::System.Drawing.Point(269, 18);
			this.guna2TextBox5.Name = "guna2TextBox5";
			this.guna2TextBox5.PasswordChar = '\0';
			this.guna2TextBox5.PlaceholderText = "";
			this.guna2TextBox5.SelectedText = "";
			this.guna2TextBox5.ShadowDecoration.Parent = this.guna2TextBox5;
			this.guna2TextBox5.Size = new global::System.Drawing.Size(172, 25);
			this.guna2TextBox5.TabIndex = 291;
			this.label24.AutoSize = true;
			this.label24.BackColor = global::System.Drawing.Color.Transparent;
			this.label24.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label24.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label24.ForeColor = global::System.Drawing.Color.DimGray;
			this.label24.Location = new global::System.Drawing.Point(267, 3);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(73, 12);
			this.label24.TabIndex = 290;
			this.label24.Text = "Nbre Requis";
			this.label25.AutoSize = true;
			this.label25.BackColor = global::System.Drawing.Color.Transparent;
			this.label25.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label25.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label25.ForeColor = global::System.Drawing.Color.DimGray;
			this.label25.Location = new global::System.Drawing.Point(10, 3);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(54, 12);
			this.label25.TabIndex = 288;
			this.label25.Text = "Fonction";
			this.radDropDownList9.DropDownStyle = 2;
			this.radDropDownList9.Location = new global::System.Drawing.Point(12, 18);
			this.radDropDownList9.Name = "radDropDownList9";
			this.radDropDownList9.Size = new global::System.Drawing.Size(251, 24);
			this.radDropDownList9.TabIndex = 298;
			this.radDropDownList9.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 258);
			base.Controls.Add(this.radDropDownList9);
			base.Controls.Add(this.radGridView2);
			base.Controls.Add(this.radButton2);
			base.Controls.Add(this.label26);
			base.Controls.Add(this.guna2TextBox6);
			base.Controls.Add(this.label27);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.guna2TextBox5);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.label25);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "gamme_fonction";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.gamme_fonction_Load);
			this.radGridView2.MasterTemplate.EndInit();
			this.radGridView2.EndInit();
			this.radButton2.EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radDropDownList9.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400075A RID: 1882
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400075B RID: 1883
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400075C RID: 1884
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400075D RID: 1885
		public global::Telerik.WinControls.UI.RadGridView radGridView2;

		// Token: 0x0400075E RID: 1886
		private global::Telerik.WinControls.UI.RadButton radButton2;

		// Token: 0x0400075F RID: 1887
		internal global::System.Windows.Forms.Label label26;

		// Token: 0x04000760 RID: 1888
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;

		// Token: 0x04000761 RID: 1889
		internal global::System.Windows.Forms.Label label27;

		// Token: 0x04000762 RID: 1890
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000763 RID: 1891
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000764 RID: 1892
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000765 RID: 1893
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox5;

		// Token: 0x04000766 RID: 1894
		internal global::System.Windows.Forms.Label label24;

		// Token: 0x04000767 RID: 1895
		internal global::System.Windows.Forms.Label label25;

		// Token: 0x04000768 RID: 1896
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList9;
	}
}
