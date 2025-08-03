namespace GMAO
{
	// Token: 0x02000021 RID: 33
	public partial class article_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x060001CB RID: 459 RVA: 0x0004BABC File Offset: 0x00049CBC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0004BAF4 File Offset: 0x00049CF4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.article_equipement));
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.arbre.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
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
			this.guna2TextBox1.Location = new global::System.Drawing.Point(519, 3);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(173, 25);
			this.guna2TextBox1.TabIndex = 155;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(698, 3);
			this.arbre.Name = "arbre";
			this.arbre.RadContextMenu = this.radContextMenu1;
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.Size = new global::System.Drawing.Size(371, 126);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 156;
			this.arbre.ThemeName = "Breeze";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).NodeSpacing = -1;
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Ajouter";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.radGridView1.AutoScroll = true;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(4, 3);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 225;
			gridViewImageColumn.HeaderText = "";
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column4";
			gridViewImageColumn.Width = 60;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewImageColumn
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowColumnHeaders = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.ReadOnly = true;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(470, 126);
			this.radGridView1.TabIndex = 157;
			this.radGridView1.ThemeName = "Fluent";
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-approuver-et-mettre-à-jour-96.png");
			this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-background-LmdRuXFWPTk.png");
			this.imageList1.Images.SetKeyName(2, "icons8-supprimer-pour-toujours-100 (4).png");
			this.imageList1.Images.SetKeyName(3, "images.png");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.arbre);
			base.Controls.Add(this.guna2TextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "article_equipement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.article_equipement_Load);
			this.arbre.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000285 RID: 645
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000286 RID: 646
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000287 RID: 647
		private global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x04000288 RID: 648
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400028A RID: 650
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x0400028B RID: 651
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x0400028C RID: 652
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
