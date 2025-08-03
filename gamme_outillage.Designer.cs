namespace GMAO
{
	// Token: 0x0200007A RID: 122
	public partial class gamme_outillage : global::System.Windows.Forms.Form
	{
		// Token: 0x060005A8 RID: 1448 RVA: 0x000EC90C File Offset: 0x000EAB0C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x000EC944 File Offset: 0x000EAB44
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
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.guna2TextBox4 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.label21 = new global::System.Windows.Forms.Label();
			this.radDropDownList3 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radButton1.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radDropDownList3.BeginInit();
			base.SuspendLayout();
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radButton1.Location = new global::System.Drawing.Point(422, 24);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 290;
			this.radButton1.Text = "Ajouter";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(14, 55);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "id";
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "column7";
			gridViewTextBoxColumn2.HeaderText = "id_type";
			gridViewTextBoxColumn2.IsVisible = false;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Famille Outillage";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 250;
			gridViewTextBoxColumn4.HeaderText = "Quantité";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 150;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column8";
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
			this.radGridView1.ReadOnly = true;
			this.radGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(968, 163);
			this.radGridView1.TabIndex = 291;
			this.radGridView1.ThemeName = "Fluent";
			this.guna2TextBox4.BorderRadius = 2;
			this.guna2TextBox4.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox4.DefaultText = "";
			this.guna2TextBox4.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox4.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox4.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox4.DisabledState.Parent = this.guna2TextBox4;
			this.guna2TextBox4.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox4.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox4.FocusedState.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.guna2TextBox4.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox4.HoverState.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Location = new global::System.Drawing.Point(234, 24);
			this.guna2TextBox4.Name = "guna2TextBox4";
			this.guna2TextBox4.PasswordChar = '\0';
			this.guna2TextBox4.PlaceholderText = "";
			this.guna2TextBox4.SelectedText = "";
			this.guna2TextBox4.ShadowDecoration.Parent = this.guna2TextBox4;
			this.guna2TextBox4.Size = new global::System.Drawing.Size(172, 25);
			this.guna2TextBox4.TabIndex = 289;
			this.label22.AutoSize = true;
			this.label22.BackColor = global::System.Drawing.Color.Transparent;
			this.label22.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label22.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label22.ForeColor = global::System.Drawing.Color.DimGray;
			this.label22.Location = new global::System.Drawing.Point(232, 9);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(53, 12);
			this.label22.TabIndex = 288;
			this.label22.Text = "Quantité";
			this.label21.AutoSize = true;
			this.label21.BackColor = global::System.Drawing.Color.Transparent;
			this.label21.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label21.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label21.ForeColor = global::System.Drawing.Color.DimGray;
			this.label21.Location = new global::System.Drawing.Point(12, 9);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(98, 12);
			this.label21.TabIndex = 286;
			this.label21.Text = "Famille Outillage";
			this.radDropDownList3.DropDownStyle = 2;
			this.radDropDownList3.Location = new global::System.Drawing.Point(14, 25);
			this.radDropDownList3.Name = "radDropDownList3";
			this.radDropDownList3.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList3.TabIndex = 292;
			this.radDropDownList3.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 258);
			base.Controls.Add(this.radDropDownList3);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.guna2TextBox4);
			base.Controls.Add(this.label22);
			base.Controls.Add(this.label21);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "gamme_outillage";
			base.Load += new global::System.EventHandler(this.gamme_outillage_Load);
			this.radButton1.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radDropDownList3.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000791 RID: 1937
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000792 RID: 1938
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000793 RID: 1939
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000794 RID: 1940
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000795 RID: 1941
		public global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000796 RID: 1942
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;

		// Token: 0x04000797 RID: 1943
		internal global::System.Windows.Forms.Label label22;

		// Token: 0x04000798 RID: 1944
		internal global::System.Windows.Forms.Label label21;

		// Token: 0x04000799 RID: 1945
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList3;
	}
}
