namespace GMAO
{
	// Token: 0x020000FA RID: 250
	public partial class pareto_cout_sous_famille : global::System.Windows.Forms.Form
	{
		// Token: 0x06000AFC RID: 2812 RVA: 0x001AA488 File Offset: 0x001A8688
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x001AA4C0 File Offset: 0x001A86C0
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radDropDownList3 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton8 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label3 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radChartView1.BeginInit();
			this.panel1.SuspendLayout();
			this.radDropDownList3.BeginInit();
			this.panel3.SuspendLayout();
			this.radRadioButton8.BeginInit();
			this.radRadioButton7.BeginInit();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(3, 55);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "Sous Famille";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column11";
			gridViewTextBoxColumn.Width = 250;
			gridViewTextBoxColumn2.HeaderText = "Coût PDR";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.HeaderText = "Pourcentage";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column6";
			gridViewTextBoxColumn3.Width = 150;
			gridViewTextBoxColumn4.HeaderText = "Pourcentage cum";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column8";
			gridViewTextBoxColumn4.Width = 150;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4
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
			this.radGridView3.Size = new global::System.Drawing.Size(969, 373);
			this.radGridView3.TabIndex = 260;
			this.radGridView3.ThemeName = "Fluent";
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(3, 56);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1079, 372);
			this.radChartView1.TabIndex = 259;
			this.panel1.Controls.Add(this.radDropDownList3);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new global::System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1092, 48);
			this.panel1.TabIndex = 258;
			this.radDropDownList3.DropDownStyle = 2;
			this.radDropDownList3.Location = new global::System.Drawing.Point(104, 21);
			this.radDropDownList3.Name = "radDropDownList3";
			this.radDropDownList3.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList3.TabIndex = 262;
			this.radDropDownList3.ThemeName = "Fluent";
			this.radDropDownList3.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList3_SelectedIndexChanged);
			this.panel3.Controls.Add(this.radRadioButton8);
			this.panel3.Controls.Add(this.radRadioButton7);
			this.panel3.Location = new global::System.Drawing.Point(2, 1);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(94, 47);
			this.panel3.TabIndex = 9;
			this.radRadioButton8.Location = new global::System.Drawing.Point(3, 24);
			this.radRadioButton8.Name = "radRadioButton8";
			this.radRadioButton8.Size = new global::System.Drawing.Size(60, 18);
			this.radRadioButton8.TabIndex = 10;
			this.radRadioButton8.TabStop = false;
			this.radRadioButton8.Text = "Tableau";
			this.radRadioButton8.ThemeName = "Fluent";
			this.radRadioButton8.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton8_ToggleStateChanged);
			this.radRadioButton7.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton7.Location = new global::System.Drawing.Point(3, 3);
			this.radRadioButton7.Name = "radRadioButton7";
			this.radRadioButton7.Size = new global::System.Drawing.Size(73, 18);
			this.radRadioButton7.TabIndex = 2;
			this.radRadioButton7.TabStop = false;
			this.radRadioButton7.Text = "Graphique";
			this.radRadioButton7.ThemeName = "Fluent";
			this.radRadioButton7.ToggleState = 1;
			this.radRadioButton7.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton7_ToggleStateChanged);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(102, 6);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(45, 12);
			this.label3.TabIndex = 261;
			this.label3.Text = "Famille";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 430);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "pareto_cout_sous_famille";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.pareto_cout_sous_famille_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radChartView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radDropDownList3.EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton8.EndInit();
			this.radRadioButton7.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000DFC RID: 3580
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000DFD RID: 3581
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000DFE RID: 3582
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04000DFF RID: 3583
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000E00 RID: 3584
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList3;

		// Token: 0x04000E01 RID: 3585
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000E02 RID: 3586
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton8;

		// Token: 0x04000E03 RID: 3587
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x04000E04 RID: 3588
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000E05 RID: 3589
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000E06 RID: 3590
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;
	}
}
