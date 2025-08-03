namespace GMAO
{
	// Token: 0x02000117 RID: 279
	public partial class prod_rapport_fabrication_produit : global::System.Windows.Forms.Form
	{
		// Token: 0x06000C62 RID: 3170 RVA: 0x001E305C File Offset: 0x001E125C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x001E3094 File Offset: 0x001E1294
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn = new global::Telerik.WinControls.UI.GridViewComboBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition2 = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.radGridView2 = new global::Telerik.WinControls.UI.RadGridView();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radGridView2.BeginInit();
			this.radGridView2.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(12, 29);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "ID";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "id_famille";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 150;
			gridViewTextBoxColumn2.HeaderText = "id_produit";
			gridViewTextBoxColumn2.IsVisible = false;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn3.HeaderText = "Produit";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.ReadOnly = true;
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.AllowSort = false;
			gridViewTextBoxColumn4.HeaderText = "Quantité (Nbre des wagons)";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column2";
			gridViewTextBoxColumn4.Width = 250;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4
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
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.Size = new global::System.Drawing.Size(540, 193);
			this.radGridView1.TabIndex = 174;
			this.radGridView1.ThemeName = "Fluent";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(1004, 2);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 24);
			this.guna2Button1.TabIndex = 175;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.radGridView2.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView2.Location = new global::System.Drawing.Point(568, 29);
			this.radGridView2.MasterTemplate.AllowAddNewRow = false;
			this.radGridView2.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView2.MasterTemplate.AllowColumnReorder = false;
			this.radGridView2.MasterTemplate.AllowDeleteRow = false;
			this.radGridView2.MasterTemplate.AllowDragToGroup = false;
			this.radGridView2.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn5.HeaderText = "id_produit";
			gridViewTextBoxColumn5.IsVisible = false;
			gridViewTextBoxColumn5.Name = "column1";
			gridViewTextBoxColumn6.AllowSort = false;
			gridViewTextBoxColumn6.HeaderText = "Heure";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column2";
			gridViewTextBoxColumn6.ReadOnly = true;
			gridViewTextBoxColumn6.Width = 100;
			gridViewComboBoxColumn.HeaderText = "Produit";
			gridViewComboBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewComboBoxColumn.Name = "column3";
			gridViewComboBoxColumn.Width = 120;
			this.radGridView2.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewComboBoxColumn
			});
			this.radGridView2.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView2.MasterTemplate.EnableFiltering = true;
			this.radGridView2.MasterTemplate.EnableSorting = false;
			this.radGridView2.MasterTemplate.ShowFilteringRow = false;
			this.radGridView2.MasterTemplate.ViewDefinition = viewDefinition2;
			this.radGridView2.Name = "radGridView2";
			this.radGridView2.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView2.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView2.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView2.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView2.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView2.ShowGroupPanel = false;
			this.radGridView2.Size = new global::System.Drawing.Size(540, 193);
			this.radGridView2.TabIndex = 176;
			this.radGridView2.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1120, 234);
			base.Controls.Add(this.radGridView2);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "prod_rapport_fabrication_produit";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.prod_rapport_fabrication_produit_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radGridView2.MasterTemplate.EndInit();
			this.radGridView2.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000FF9 RID: 4089
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000FFA RID: 4090
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000FFB RID: 4091
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000FFC RID: 4092
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04000FFD RID: 4093
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000FFE RID: 4094
		private global::Telerik.WinControls.UI.RadGridView radGridView2;
	}
}
