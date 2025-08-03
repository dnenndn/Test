namespace GMAO
{
	// Token: 0x020000BE RID: 190
	public partial class ot_general_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x0600089C RID: 2204 RVA: 0x0016E830 File Offset: 0x0016CA30
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0016E868 File Offset: 0x0016CA68
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_general_equipement));
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem2 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem3 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem4 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.arbre.BeginInit();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ImageList = this.imageList1;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(12, 42);
			this.arbre.Name = "arbre";
			this.arbre.RadContextMenu = this.radContextMenu1;
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.ShowNodeToolTips = true;
			this.arbre.Size = new global::System.Drawing.Size(410, 474);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 8;
			this.arbre.ThemeName = "Office2010Silver";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).NodeSpacing = -1;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "image1.png");
			this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-background-LmdRuXFWPTk.png");
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1,
				this.radMenuItem2,
				this.radMenuItem3,
				this.radMenuItem4
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Atelier";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "Equipement";
			this.radMenuItem2.UseCompatibleTextRendering = false;
			this.radMenuItem3.Name = "radMenuItem3";
			this.radMenuItem3.Text = "Sous Equipement";
			this.radMenuItem3.UseCompatibleTextRendering = false;
			this.radMenuItem4.Name = "radMenuItem4";
			this.radMenuItem4.Text = "Organe";
			this.radMenuItem4.UseCompatibleTextRendering = false;
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(12, 4);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(229, 31);
			this.guna2TextBox1.TabIndex = 7;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(439, 42);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "Element";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "id_equipement";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.IsVisible = false;
			gridViewTextBoxColumn2.Name = "column2";
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Code";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.Width = 120;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Désignation";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column4";
			gridViewTextBoxColumn4.Width = 260;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column5";
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
			this.radGridView3.MasterTemplate.VerticalScrollState = 2;
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
			this.radGridView3.Size = new global::System.Drawing.Size(591, 162);
			this.radGridView3.TabIndex = 243;
			this.radGridView3.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1066, 243);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.arbre);
			base.Controls.Add(this.guna2TextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_general_equipement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_general_equipement_Load);
			this.arbre.EndInit();
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000BAD RID: 2989
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000BAE RID: 2990
		public global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x04000BAF RID: 2991
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000BB0 RID: 2992
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000BB1 RID: 2993
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000BB2 RID: 2994
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000BB3 RID: 2995
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem2;

		// Token: 0x04000BB4 RID: 2996
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem3;

		// Token: 0x04000BB5 RID: 2997
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem4;

		// Token: 0x04000BB6 RID: 2998
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04000BB7 RID: 2999
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;

		// Token: 0x04000BB8 RID: 3000
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000BB9 RID: 3001
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
