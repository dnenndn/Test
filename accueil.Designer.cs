namespace GMAO
{
	// Token: 0x02000004 RID: 4
	public partial class accueil : global::System.Windows.Forms.Form
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00008730 File Offset: 0x00006930
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00008768 File Offset: 0x00006968
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new global::Telerik.WinControls.UI.GridViewTextBoxColumn();
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.linearGaugeBar4 = new global::Telerik.WinControls.UI.Gauges.LinearGaugeBar();
			this.pieChart1 = new global::LiveCharts.WinForms.PieChart();
			this.bunifuCards1 = new global::Bunifu.Framework.UI.BunifuCards();
			this.label30 = new global::System.Windows.Forms.Label();
			this.radGridView3 = new global::Telerik.WinControls.UI.RadGridView();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.radCalendar1 = new global::Telerik.WinControls.UI.RadCalendar();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.materialPinkTheme1 = new global::Telerik.WinControls.Themes.MaterialPinkTheme();
			this.telerikMetroTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroTheme();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.bunifuCards1.SuspendLayout();
			this.radGridView3.BeginInit();
			this.radGridView3.MasterTemplate.BeginInit();
			this.radChartView1.BeginInit();
			this.radCalendar1.BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Location = new global::System.Drawing.Point(12, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(414, 233);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 94;
			this.pictureBox1.TabStop = false;
			this.label27.AutoSize = true;
			this.label27.BackColor = global::System.Drawing.Color.Transparent;
			this.label27.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label27.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label27.ForeColor = global::System.Drawing.Color.Black;
			this.label27.Location = new global::System.Drawing.Point(543, 2);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(136, 18);
			this.label27.TabIndex = 271;
			this.label27.Text = "Demande Achat";
			this.linearGaugeBar4.BackColor = global::System.Drawing.Color.FromArgb(224, 88, 88);
			this.linearGaugeBar4.BackColor2 = global::System.Drawing.Color.FromArgb(224, 88, 88);
			this.linearGaugeBar4.DisabledTextRenderingHint = global::System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.linearGaugeBar4.Name = "linearGaugeBar4";
			this.linearGaugeBar4.Offset = 25f;
			this.linearGaugeBar4.Padding = new global::System.Windows.Forms.Padding(0);
			this.linearGaugeBar4.RangeEnd = 120f;
			this.linearGaugeBar4.RangeStart = 81f;
			this.linearGaugeBar4.TextRenderingHint = global::System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.linearGaugeBar4.UseCompatibleTextRendering = false;
			this.linearGaugeBar4.Width = 60f;
			this.linearGaugeBar4.Width2 = 60f;
			this.pieChart1.Location = new global::System.Drawing.Point(432, 23);
			this.pieChart1.Name = "pieChart1";
			this.pieChart1.Size = new global::System.Drawing.Size(359, 212);
			this.pieChart1.TabIndex = 271;
			this.pieChart1.Text = "pieChart1";
			this.bunifuCards1.BackColor = global::System.Drawing.Color.White;
			this.bunifuCards1.BorderRadius = 5;
			this.bunifuCards1.BottomSahddow = true;
			this.bunifuCards1.color = global::System.Drawing.Color.Firebrick;
			this.bunifuCards1.Controls.Add(this.label30);
			this.bunifuCards1.LeftSahddow = false;
			this.bunifuCards1.Location = new global::System.Drawing.Point(12, 233);
			this.bunifuCards1.Name = "bunifuCards1";
			this.bunifuCards1.RightSahddow = true;
			this.bunifuCards1.ShadowDepth = 20;
			this.bunifuCards1.Size = new global::System.Drawing.Size(431, 35);
			this.bunifuCards1.TabIndex = 272;
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.Black;
			this.label30.Location = new global::System.Drawing.Point(82, 9);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(250, 22);
			this.label30.TabIndex = 255;
			this.label30.Text = "Repture de stock : TOP 10";
			this.radGridView3.BackColor = global::System.Drawing.Color.White;
			this.radGridView3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radGridView3.Font = new global::System.Drawing.Font("Calibri", 8.25f);
			this.radGridView3.ForeColor = global::System.Drawing.Color.Black;
			this.radGridView3.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.radGridView3.Location = new global::System.Drawing.Point(12, 270);
			this.radGridView3.MasterTemplate.AllowAddNewRow = false;
			this.radGridView3.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView3.MasterTemplate.AllowColumnReorder = false;
			this.radGridView3.MasterTemplate.AllowDeleteRow = false;
			this.radGridView3.MasterTemplate.AllowDragToGroup = false;
			this.radGridView3.MasterTemplate.AllowEditRow = false;
			this.radGridView3.MasterTemplate.AllowRowHeaderContextMenu = false;
			gridViewTextBoxColumn.HeaderText = "Article";
			gridViewTextBoxColumn.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn.Name = "column5";
			gridViewTextBoxColumn.Width = 300;
			gridViewTextBoxColumn2.HeaderText = "Quantité";
			gridViewTextBoxColumn2.HeaderTextAlignment = global::System.Drawing.ContentAlignment.MiddleLeft;
			gridViewTextBoxColumn2.Name = "column3";
			gridViewTextBoxColumn2.Width = 100;
			this.radGridView3.MasterTemplate.Columns.AddRange(new global::Telerik.WinControls.UI.GridViewDataColumn[]
			{
				gridViewTextBoxColumn,
				gridViewTextBoxColumn2
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
			this.radGridView3.Size = new global::System.Drawing.Size(431, 330);
			this.radGridView3.TabIndex = 273;
			this.radGridView3.ThemeName = "Fluent";
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(462, 250);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(673, 390);
			this.radChartView1.TabIndex = 274;
			this.radCalendar1.HeaderHeight = 30;
			this.radCalendar1.HeaderWidth = 30;
			this.radCalendar1.Location = new global::System.Drawing.Point(809, 12);
			this.radCalendar1.Name = "radCalendar1";
			this.radCalendar1.Size = new global::System.Drawing.Size(332, 223);
			this.radCalendar1.TabIndex = 275;
			this.radCalendar1.ThemeName = "Fluent";
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BottomColor = global::System.Drawing.Color.FromArgb(216, 4, 4);
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FocusPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0)).BackColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0)).BackColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			this.imageList1.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new global::System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.radCalendar1);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.radGridView3);
			base.Controls.Add(this.bunifuCards1);
			base.Controls.Add(this.label27);
			base.Controls.Add(this.pieChart1);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "accueil";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.accueil_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.bunifuCards1.ResumeLayout(false);
			this.bunifuCards1.PerformLayout();
			this.radGridView3.MasterTemplate.EndInit();
			this.radGridView3.EndInit();
			this.radChartView1.EndInit();
			this.radCalendar1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400001C RID: 28
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400001D RID: 29
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400001F RID: 31
		internal global::System.Windows.Forms.Label label27;

		// Token: 0x04000020 RID: 32
		private global::Telerik.WinControls.UI.Gauges.LinearGaugeBar linearGaugeBar4;

		// Token: 0x04000021 RID: 33
		private global::LiveCharts.WinForms.PieChart pieChart1;

		// Token: 0x04000022 RID: 34
		private global::Bunifu.Framework.UI.BunifuCards bunifuCards1;

		// Token: 0x04000023 RID: 35
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000024 RID: 36
		public global::Telerik.WinControls.UI.RadGridView radGridView3;

		// Token: 0x04000025 RID: 37
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000026 RID: 38
		private global::Telerik.WinControls.UI.RadChartView radChartView1;

		// Token: 0x04000027 RID: 39
		private global::Telerik.WinControls.UI.RadCalendar radCalendar1;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000029 RID: 41
		private global::Telerik.WinControls.Themes.MaterialPinkTheme materialPinkTheme1;

		// Token: 0x0400002A RID: 42
		private global::Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
	}
}
