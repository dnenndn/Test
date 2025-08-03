namespace GMAO
{
	// Token: 0x02000002 RID: 2
	public partial class acceuil_maintenance : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00005280 File Offset: 0x00003480
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000052B8 File Offset: 0x000034B8
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.bunifuCards1 = new global::Bunifu.Framework.UI.BunifuCards();
			this.label30 = new global::System.Windows.Forms.Label();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.label27 = new global::System.Windows.Forms.Label();
			this.pieChart1 = new global::LiveCharts.WinForms.PieChart();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pieChart2 = new global::LiveCharts.WinForms.PieChart();
			this.bunifuCards2 = new global::Bunifu.Framework.UI.BunifuCards();
			this.label2 = new global::System.Windows.Forms.Label();
			this.bunifuCards3 = new global::Bunifu.Framework.UI.BunifuCards();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.bunifuCards1.SuspendLayout();
			this.radChartView1.BeginInit();
			this.panel1.SuspendLayout();
			this.radRadioButton4.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.bunifuCards2.SuspendLayout();
			this.bunifuCards3.SuspendLayout();
			base.SuspendLayout();
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(561, 32);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "Date";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 80;
			gridViewTextBoxColumn2.HeaderText = "Gamme Opératoire";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 300;
			gridViewTextBoxColumn3.HeaderText = "Equipement";
			gridViewTextBoxColumn3.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn3.Name = "column1";
			gridViewTextBoxColumn3.Width = 350;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2,
				gridViewTextBoxColumn3
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
			this.radGridView3.Size = new global::System.Drawing.Size(573, 227);
			this.radGridView3.TabIndex = 275;
			this.radGridView3.ThemeName = "Fluent";
			this.bunifuCards1.BackColor = global::System.Drawing.Color.White;
			this.bunifuCards1.BorderRadius = 5;
			this.bunifuCards1.BottomSahddow = true;
			this.bunifuCards1.color = global::System.Drawing.Color.Firebrick;
			this.bunifuCards1.Controls.Add(this.label30);
			this.bunifuCards1.LeftSahddow = false;
			this.bunifuCards1.Location = new global::System.Drawing.Point(561, 2);
			this.bunifuCards1.Name = "bunifuCards1";
			this.bunifuCards1.RightSahddow = true;
			this.bunifuCards1.ShadowDepth = 20;
			this.bunifuCards1.Size = new global::System.Drawing.Size(573, 34);
			this.bunifuCards1.TabIndex = 274;
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.Black;
			this.label30.Location = new global::System.Drawing.Point(128, 5);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(339, 22);
			this.label30.TabIndex = 255;
			this.label30.Text = "Préventive Systématique de ce Mois";
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(3, 330);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1131, 299);
			this.radChartView1.TabIndex = 275;
			this.panel1.Controls.Add(this.radRadioButton4);
			this.panel1.Controls.Add(this.radRadioButton2);
			this.panel1.Controls.Add(this.radRadioButton1);
			this.panel1.Location = new global::System.Drawing.Point(3, 286);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(360, 39);
			this.panel1.TabIndex = 9;
			this.radRadioButton4.Font = new global::System.Drawing.Font("Segoe UI", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radRadioButton4.Location = new global::System.Drawing.Point(174, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(67, 30);
			this.radRadioButton4.TabIndex = 4;
			this.radRadioButton4.TabStop = false;
			this.radRadioButton4.Text = "Coût";
			this.radRadioButton4.ThemeName = "Fluent";
			this.radRadioButton4.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton4_ToggleStateChanged);
			this.radRadioButton2.Font = new global::System.Drawing.Font("Segoe UI", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radRadioButton2.Location = new global::System.Drawing.Point(68, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(102, 30);
			this.radRadioButton2.TabIndex = 2;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "TTR (Hr)";
			this.radRadioButton2.ThemeName = "Fluent";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Font = new global::System.Drawing.Font("Segoe UI", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(59, 30);
			this.radRadioButton1.TabIndex = 1;
			this.radRadioButton1.Text = "Nbr";
			this.radRadioButton1.ThemeName = "Fluent";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.label27.AutoSize = true;
			this.label27.BackColor = global::System.Drawing.Color.Transparent;
			this.label27.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label27.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label27.ForeColor = global::System.Drawing.Color.Black;
			this.label27.Location = new global::System.Drawing.Point(64, 5);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(154, 18);
			this.label27.TabIndex = 276;
			this.label27.Text = "Nbre Wagon (Moy)";
			this.pieChart1.Location = new global::System.Drawing.Point(12, 21);
			this.pieChart1.Name = "pieChart1";
			this.pieChart1.Size = new global::System.Drawing.Size(248, 238);
			this.pieChart1.TabIndex = 277;
			this.pieChart1.Text = "pieChart1";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(311, 7);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(232, 18);
			this.label1.TabIndex = 278;
			this.label1.Text = "Arrêt Production (min) - Hier";
			this.pieChart2.Location = new global::System.Drawing.Point(278, 21);
			this.pieChart2.Name = "pieChart2";
			this.pieChart2.Size = new global::System.Drawing.Size(277, 238);
			this.pieChart2.TabIndex = 279;
			this.pieChart2.Text = "pieChart2";
			this.bunifuCards2.BackColor = global::System.Drawing.Color.White;
			this.bunifuCards2.BorderRadius = 5;
			this.bunifuCards2.BottomSahddow = true;
			this.bunifuCards2.color = global::System.Drawing.Color.Firebrick;
			this.bunifuCards2.Controls.Add(this.label2);
			this.bunifuCards2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCards2.LeftSahddow = false;
			this.bunifuCards2.Location = new global::System.Drawing.Point(561, 260);
			this.bunifuCards2.Name = "bunifuCards2";
			this.bunifuCards2.RightSahddow = true;
			this.bunifuCards2.ShadowDepth = 20;
			this.bunifuCards2.Size = new global::System.Drawing.Size(320, 27);
			this.bunifuCards2.TabIndex = 280;
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(75, 5);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(191, 18);
			this.label2.TabIndex = 255;
			this.label2.Text = "Consommation Fuel (T)";
			this.bunifuCards3.BackColor = global::System.Drawing.Color.White;
			this.bunifuCards3.BorderRadius = 5;
			this.bunifuCards3.BottomSahddow = true;
			this.bunifuCards3.color = global::System.Drawing.Color.Firebrick;
			this.bunifuCards3.Controls.Add(this.label3);
			this.bunifuCards3.LeftSahddow = false;
			this.bunifuCards3.Location = new global::System.Drawing.Point(887, 260);
			this.bunifuCards3.Name = "bunifuCards3";
			this.bunifuCards3.RightSahddow = true;
			this.bunifuCards3.ShadowDepth = 20;
			this.bunifuCards3.Size = new global::System.Drawing.Size(248, 27);
			this.bunifuCards3.TabIndex = 281;
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(62, 4);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(137, 18);
			this.label3.TabIndex = 255;
			this.label3.Text = "Ratio Fuel (kg/T)";
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label4.Font = new global::System.Drawing.Font("Imprint MT Shadow", 27.75f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label4.Location = new global::System.Drawing.Point(669, 287);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(76, 43);
			this.label4.TabIndex = 282;
			this.label4.Text = "105";
			this.label5.AutoSize = true;
			this.label5.BackColor = global::System.Drawing.Color.Transparent;
			this.label5.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label5.Font = new global::System.Drawing.Font("Imprint MT Shadow", 27.75f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.Firebrick;
			this.label5.Location = new global::System.Drawing.Point(954, 287);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(76, 43);
			this.label5.TabIndex = 283;
			this.label5.Text = "105";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.bunifuCards3);
			base.Controls.Add(this.bunifuCards2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pieChart2);
			base.Controls.Add(this.label27);
			base.Controls.Add(this.pieChart1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.bunifuCards1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "acceuil_maintenance";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.acceuil_maintenance_Load);
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.bunifuCards1.ResumeLayout(false);
			this.bunifuCards1.PerformLayout();
			this.radChartView1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton4.EndInit();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.bunifuCards2.ResumeLayout(false);
			this.bunifuCards2.PerformLayout();
			this.bunifuCards3.ResumeLayout(false);
			this.bunifuCards3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000003 RID: 3
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000004 RID: 4
		private global::Bunifu.Framework.UI.BunifuCards bunifuCards1;

		// Token: 0x04000005 RID: 5
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000006 RID: 6
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000008 RID: 8
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000009 RID: 9
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x0400000A RID: 10
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x0400000B RID: 11
		internal global::System.Windows.Forms.Label label27;

		// Token: 0x0400000C RID: 12
		private global::LiveCharts.WinForms.PieChart pieChart1;

		// Token: 0x0400000D RID: 13
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x0400000E RID: 14
		private global::LiveCharts.WinForms.PieChart pieChart2;

		// Token: 0x0400000F RID: 15
		private global::Bunifu.Framework.UI.BunifuCards bunifuCards2;

		// Token: 0x04000010 RID: 16
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000011 RID: 17
		private global::Bunifu.Framework.UI.BunifuCards bunifuCards3;

		// Token: 0x04000012 RID: 18
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000013 RID: 19
		internal global::System.Windows.Forms.Label label4;

		// Token: 0x04000014 RID: 20
		internal global::System.Windows.Forms.Label label5;
	}
}
