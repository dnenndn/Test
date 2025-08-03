namespace GMAO
{
	// Token: 0x02000015 RID: 21
	public partial class app_gerer_planning : global::System.Windows.Forms.Form
	{
		// Token: 0x06000133 RID: 307 RVA: 0x0003A278 File Offset: 0x00038478
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0003A2B0 File Offset: 0x000384B0
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new global::Telerik.WinControls.UI.GridViewImageColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radDropDownList1.BeginInit();
			base.SuspendLayout();
			this.radGridView1.BackColor = global::System.Drawing.Color.White;
			this.radGridView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f);
			this.radGridView1.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView1.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView1.Location = new global::System.Drawing.Point(21, 47);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "ID ac";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.IsVisible = false;
			gridViewTextBoxColumn.Name = "id_famille";
			gridViewTextBoxColumn.ReadOnly = true;
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.AllowSort = false;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Code Article";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.ReadOnly = true;
			gridViewTextBoxColumn2.Width = 130;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Désignation";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.ReadOnly = true;
			gridViewTextBoxColumn3.Width = 250;
			gridViewTextBoxColumn4.EnableExpressionEditor = false;
			gridViewTextBoxColumn4.HeaderText = "Quantité";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column3";
			gridViewTextBoxColumn4.Width = 70;
			gridViewTextBoxColumn5.EnableExpressionEditor = false;
			gridViewTextBoxColumn5.HeaderText = "Date Début";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column6";
			gridViewTextBoxColumn5.Width = 80;
			gridViewTextBoxColumn6.EnableExpressionEditor = false;
			gridViewTextBoxColumn6.HeaderText = "Heure Début";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column8";
			gridViewTextBoxColumn6.Width = 70;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Délai";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column4";
			gridViewTextBoxColumn7.ReadOnly = true;
			gridViewTextBoxColumn7.Width = 100;
			gridViewTextBoxColumn8.EnableExpressionEditor = false;
			gridViewTextBoxColumn8.HeaderText = "Réccurence";
			gridViewTextBoxColumn8.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn8.Name = "column7";
			gridViewTextBoxColumn8.Width = 80;
			gridViewTextBoxColumn9.EnableExpressionEditor = false;
			gridViewTextBoxColumn9.HeaderText = "Date Limite";
			gridViewTextBoxColumn9.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn9.Name = "column9";
			gridViewTextBoxColumn9.Width = 80;
			gridViewImageColumn.EnableExpressionEditor = false;
			gridViewImageColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewImageColumn.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn.Name = "column5";
			gridViewImageColumn2.EnableExpressionEditor = false;
			gridViewImageColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewImageColumn2.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn2.Name = "column10";
			gridViewImageColumn3.EnableExpressionEditor = false;
			gridViewImageColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewImageColumn3.ImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			gridViewImageColumn3.Name = "column11";
			gridViewTextBoxColumn10.HeaderText = "arr";
			gridViewTextBoxColumn10.IsVisible = false;
			gridViewTextBoxColumn10.Name = "column12";
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7,
				gridViewTextBoxColumn8,
				gridViewTextBoxColumn9,
				gridViewImageColumn,
				gridViewImageColumn2,
				gridViewImageColumn3,
				gridViewTextBoxColumn10
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
			this.radGridView1.Size = new global::System.Drawing.Size(1087, 487);
			this.radGridView1.TabIndex = 174;
			this.radGridView1.ThemeName = "Fluent";
			this.radDropDownList1.DropDownAnimationEasing = 2;
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(21, 12);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(199, 24);
			this.radDropDownList1.TabIndex = 175;
			this.radDropDownList1.ThemeName = "Crystal";
			this.radDropDownList1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged);
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList1.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(1)).AutoSize = false;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "app_gerer_planning";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.app_gerer_planning_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radDropDownList1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001DB RID: 475
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040001DC RID: 476
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x040001DD RID: 477
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040001DE RID: 478
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x040001DF RID: 479
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;
	}
}
