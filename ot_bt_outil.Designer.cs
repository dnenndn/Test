namespace GMAO
{
	// Token: 0x020000AF RID: 175
	public partial class ot_bt_outil : global::System.Windows.Forms.Form
	{
		// Token: 0x060007F0 RID: 2032 RVA: 0x00159630 File Offset: 0x00157830
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00159668 File Offset: 0x00157868
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 12);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.EnableExpressionEditor = false;
			gridViewTextBoxColumn.HeaderText = "Code Outil";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn.Width = 120;
			gridViewTextBoxColumn2.EnableExpressionEditor = false;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 200;
			gridViewTextBoxColumn3.HeaderText = "Date Sortie";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column5";
			gridViewTextBoxColumn3.Width = 100;
			gridViewTextBoxColumn4.HeaderText = "Heure Sortie";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column8";
			gridViewTextBoxColumn4.Width = 100;
			gridViewTextBoxColumn5.HeaderText = "Date Retour";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column7";
			gridViewTextBoxColumn5.Width = 100;
			gridViewTextBoxColumn6.HeaderText = "Heure Retour";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column2";
			gridViewTextBoxColumn6.Width = 100;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Réceptionniste";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column4";
			gridViewTextBoxColumn7.Width = 250;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5,
				gridViewTextBoxColumn6,
				gridViewTextBoxColumn7
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
			this.radGridView3.Size = new global::System.Drawing.Size(1050, 219);
			this.radGridView3.TabIndex = 246;
			this.radGridView3.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_bt_outil";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_bt_outil_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000AE3 RID: 2787
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000AE4 RID: 2788
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000AE5 RID: 2789
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000AE6 RID: 2790
		public global::Telerik.WinControls.UI.RadGridView radGridView3;
	}
}
