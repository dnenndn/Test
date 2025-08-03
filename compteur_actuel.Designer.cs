namespace GMAO
{
	// Token: 0x0200004B RID: 75
	public partial class compteur_actuel : global::System.Windows.Forms.Form
	{
		// Token: 0x06000356 RID: 854 RVA: 0x0008E620 File Offset: 0x0008C820
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0008E658 File Offset: 0x0008C858
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(12, 12);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "Code Equipement";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column1";
			gridViewTextBoxColumn.Width = 100;
			gridViewTextBoxColumn2.HeaderText = "Equipement";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column2";
			gridViewTextBoxColumn2.Width = 400;
			gridViewTextBoxColumn3.HeaderText = "Compteur";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column3";
			gridViewTextBoxColumn3.Width = 300;
			gridViewTextBoxColumn4.HeaderText = "Valeur Actuel";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column4";
			gridViewTextBoxColumn4.Width = 120;
			gridViewTextBoxColumn5.HeaderText = "Unité";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column5";
			gridViewTextBoxColumn5.Width = 100;
			this.radGridView1.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
			this.radGridView1.MasterTemplate.EnableSorting = false;
			this.radGridView1.MasterTemplate.ShowFilteringRow = false;
			this.radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			this.radGridView1.MasterTemplate.ViewDefinition = viewDefinition;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.Padding = new global::System.Windows.Forms.Padding(1);
			this.radGridView1.PrintStyle.CellFont = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.PrintStyle.ChildViewPrintMode = 0;
			this.radGridView1.PrintStyle.GroupRowBackColor = global::System.Drawing.Color.Gray;
			this.radGridView1.PrintStyle.HeaderCellBackColor = global::System.Drawing.Color.Red;
			this.radGridView1.ReadOnly = true;
			this.radGridView1.ShowGroupPanel = false;
			this.radGridView1.ShowHeaderCellButtons = true;
			this.radGridView1.Size = new global::System.Drawing.Size(1104, 457);
			this.radGridView1.TabIndex = 83;
			this.radGridView1.ThemeName = "Fluent";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.radGridView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "compteur_actuel";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.compteur_actuel_Load);
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000496 RID: 1174
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000497 RID: 1175
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000498 RID: 1176
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000499 RID: 1177
		private global::Telerik.WinControls.UI.RadGridView radGridView1;
	}
}
