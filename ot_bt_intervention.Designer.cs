namespace GMAO
{
	// Token: 0x020000AE RID: 174
	public partial class ot_bt_intervention : global::System.Windows.Forms.Form
	{
		// Token: 0x060007E9 RID: 2025 RVA: 0x0015881C File Offset: 0x00156A1C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00158854 File Offset: 0x00156A54
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
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 41);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "Intervenant";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column3";
			gridViewTextBoxColumn.Width = 120;
			gridViewTextBoxColumn2.HeaderText = "Fonction";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column5";
			gridViewTextBoxColumn2.Width = 100;
			gridViewTextBoxColumn3.EnableExpressionEditor = false;
			gridViewTextBoxColumn3.HeaderText = "Intervention";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 300;
			gridViewTextBoxColumn4.HeaderText = "Type Intervention";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column7";
			gridViewTextBoxColumn4.Width = 100;
			gridViewTextBoxColumn5.HeaderText = "Début";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column6";
			gridViewTextBoxColumn5.Width = 130;
			gridViewTextBoxColumn6.HeaderText = "Fin";
			gridViewTextBoxColumn6.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn6.Name = "column4";
			gridViewTextBoxColumn6.Width = 130;
			gridViewTextBoxColumn7.EnableExpressionEditor = false;
			gridViewTextBoxColumn7.HeaderText = "Durée";
			gridViewTextBoxColumn7.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn7.Name = "column2";
			gridViewTextBoxColumn7.Width = 100;
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
			this.radGridView3.Size = new global::System.Drawing.Size(1050, 190);
			this.radGridView3.TabIndex = 247;
			this.radGridView3.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(12, 4);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(76, 12);
			this.label1.TabIndex = 261;
			this.label1.Text = "Date Début : ";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(12, 20);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(39, 12);
			this.label2.TabIndex = 262;
			this.label2.Text = "label2";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(147, 20);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(39, 12);
			this.label3.TabIndex = 264;
			this.label3.Text = "label3";
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label4.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(147, 4);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(60, 12);
			this.label4.TabIndex = 263;
			this.label4.Text = "Date Fin : ";
			this.label5.AutoSize = true;
			this.label5.BackColor = global::System.Drawing.Color.Transparent;
			this.label5.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label5.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(300, 20);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(39, 12);
			this.label5.TabIndex = 266;
			this.label5.Text = "label5";
			this.label6.AutoSize = true;
			this.label6.BackColor = global::System.Drawing.Color.Transparent;
			this.label6.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label6.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(300, 4);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(69, 12);
			this.label6.TabIndex = 265;
			this.label6.Text = "Durée Tot : ";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radGridView3);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_bt_intervention";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_bt_intervention_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000AD9 RID: 2777
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000ADA RID: 2778
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000ADB RID: 2779
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000ADC RID: 2780
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000ADD RID: 2781
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000ADE RID: 2782
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000ADF RID: 2783
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000AE0 RID: 2784
		internal global::System.Windows.Forms.Label label4;

		// Token: 0x04000AE1 RID: 2785
		internal global::System.Windows.Forms.Label label5;

		// Token: 0x04000AE2 RID: 2786
		internal global::System.Windows.Forms.Label label6;
	}
}
