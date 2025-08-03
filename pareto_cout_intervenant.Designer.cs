namespace GMAO
{
	// Token: 0x020000F9 RID: 249
	public partial class pareto_cout_intervenant : global::System.Windows.Forms.Form
	{
		// Token: 0x06000AF0 RID: 2800 RVA: 0x001A9268 File Offset: 0x001A7468
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x001A92A0 File Offset: 0x001A74A0
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton8 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton7 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radDropDownList3 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radChartView1.BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.radRadioButton8.BeginInit();
			this.radRadioButton7.BeginInit();
			this.radDropDownList3.BeginInit();
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
			gridViewTextBoxColumn.HeaderText = "Fonction";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column11";
			gridViewTextBoxColumn.Width = 250;
			gridViewTextBoxColumn2.HeaderText = "Coût MO";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column1";
			gridViewTextBoxColumn2.Width = 150;
			gridViewTextBoxColumn3.HeaderText = "TTR (H)";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.Width = 200;
			gridViewTextBoxColumn4.HeaderText = "Pourcentage";
			gridViewTextBoxColumn4.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn4.Name = "column6";
			gridViewTextBoxColumn4.Width = 150;
			gridViewTextBoxColumn5.HeaderText = "Pourcentage cum";
			gridViewTextBoxColumn5.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn5.Name = "column8";
			gridViewTextBoxColumn5.Width = 150;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3,
				gridViewTextBoxColumn4,
				gridViewTextBoxColumn5
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
			this.radGridView3.TabIndex = 257;
			this.radGridView3.ThemeName = "Fluent";
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(3, 56);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1079, 372);
			this.radChartView1.TabIndex = 256;
			this.panel1.Controls.Add(this.radDropDownList3);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new global::System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1092, 48);
			this.panel1.TabIndex = 255;
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
			this.radDropDownList3.DropDownStyle = 2;
			this.radDropDownList3.Location = new global::System.Drawing.Point(104, 21);
			this.radDropDownList3.Name = "radDropDownList3";
			this.radDropDownList3.Size = new global::System.Drawing.Size(205, 24);
			this.radDropDownList3.TabIndex = 262;
			this.radDropDownList3.ThemeName = "Fluent";
			this.radDropDownList3.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList3_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(102, 6);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(54, 12);
			this.label3.TabIndex = 261;
			this.label3.Text = "Fonction";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 430);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "pareto_cout_intervenant";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.pareto_cout_intervenant_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radChartView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton8.EndInit();
			this.radRadioButton7.EndInit();
			this.radDropDownList3.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000DF1 RID: 3569
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000DF2 RID: 3570
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000DF3 RID: 3571
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000DF4 RID: 3572
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000DF5 RID: 3573
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04000DF6 RID: 3574
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000DF7 RID: 3575
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000DF8 RID: 3576
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton8;

		// Token: 0x04000DF9 RID: 3577
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton7;

		// Token: 0x04000DFA RID: 3578
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList3;

		// Token: 0x04000DFB RID: 3579
		internal global::System.Windows.Forms.Label label3;
	}
}
