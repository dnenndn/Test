namespace GMAO
{
	// Token: 0x02000169 RID: 361
	public partial class tb_variation_prix_recap : global::System.Windows.Forms.Form
	{
		// Token: 0x0600104E RID: 4174 RVA: 0x0029308C File Offset: 0x0029128C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x002930C4 File Offset: 0x002912C4
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
			global::Telerik.WinControls.UI.TableViewDefinition viewDefinition = new global::Telerik.WinControls.UI.TableViewDefinition();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.radGridView1 = new global::Telerik.WinControls.UI.RadGridView();
			this.radButton8 = new global::Telerik.WinControls.UI.RadButton();
			this.panel3.SuspendLayout();
			this.radRadioButton1.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radDateTimePicker2.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.radGridView1.BeginInit();
			this.radGridView1.MasterTemplate.BeginInit();
			this.radButton8.BeginInit();
			base.SuspendLayout();
			this.panel3.Controls.Add(this.radRadioButton1);
			this.panel3.Controls.Add(this.radRadioButton2);
			this.panel3.Location = new global::System.Drawing.Point(348, 17);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(202, 29);
			this.panel3.TabIndex = 248;
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f);
			this.radRadioButton1.Location = new global::System.Drawing.Point(6, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(99, 20);
			this.radRadioButton1.TabIndex = 232;
			this.radRadioButton1.Text = "Non Reparable";
			this.radRadioButton1.ThemeName = "Crystal";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8f);
			this.radRadioButton2.Location = new global::System.Drawing.Point(112, 5);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(76, 20);
			this.radRadioButton2.TabIndex = 50;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Réparable";
			this.radRadioButton2.ThemeName = "Crystal";
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(143, 27);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(117, 23);
			this.radDateTimePicker2.TabIndex = 247;
			this.radDateTimePicker2.TabStop = false;
			this.radDateTimePicker2.Text = "10/02/2021";
			this.radDateTimePicker2.ThemeName = "Crystal";
			this.radDateTimePicker2.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			this.radDateTimePicker2.ValueChanged += new global::System.EventHandler(this.radDateTimePicker2_ValueChanged);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker2.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(16, 27);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(120, 23);
			this.radDateTimePicker1.TabIndex = 246;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "10/02/2021";
			this.radDateTimePicker1.ThemeName = "Crystal";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			this.radDateTimePicker1.ValueChanged += new global::System.EventHandler(this.radDateTimePicker1_ValueChanged);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker1.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.Black;
			this.label20.Location = new global::System.Drawing.Point(12, 9);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(66, 15);
			this.label20.TabIndex = 244;
			this.label20.Text = "Date début";
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.ForeColor = global::System.Drawing.Color.Black;
			this.label19.Location = new global::System.Drawing.Point(140, 9);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(49, 15);
			this.label19.TabIndex = 245;
			this.label19.Text = "Date fin";
			this.radGridView1.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radGridView1.Location = new global::System.Drawing.Point(12, 88);
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowColumnReorder = false;
			this.radGridView1.MasterTemplate.AllowDeleteRow = false;
			this.radGridView1.MasterTemplate.AllowDragToGroup = false;
			this.radGridView1.MasterTemplate.AllowEditRow = false;
			this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
			this.radGridView1.MasterTemplate.AllowSearchRow = true;
			gridViewTextBoxColumn.HeaderText = "Code Article";
			gridViewTextBoxColumn.Name = "Code Article";
			gridViewTextBoxColumn.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn.Width = 80;
			gridViewTextBoxColumn.WrapText = true;
			gridViewTextBoxColumn2.HeaderText = "Désignation";
			gridViewTextBoxColumn2.Name = "column6";
			gridViewTextBoxColumn2.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn2.Width = 180;
			gridViewTextBoxColumn3.AllowSort = false;
			gridViewTextBoxColumn3.HeaderText = "Réf interne";
			gridViewTextBoxColumn3.Name = "column2";
			gridViewTextBoxColumn3.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn3.Width = 10;
			gridViewTextBoxColumn3.WrapText = true;
			gridViewTextBoxColumn4.ExcelExportType = 0;
			gridViewTextBoxColumn4.HeaderText = "Max Prix";
			gridViewTextBoxColumn4.Name = "column1";
			gridViewTextBoxColumn4.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn4.Width = 100;
			gridViewTextBoxColumn4.WrapText = true;
			gridViewTextBoxColumn5.ExcelExportType = 0;
			gridViewTextBoxColumn5.HeaderText = "Min Prix";
			gridViewTextBoxColumn5.Name = "column3";
			gridViewTextBoxColumn5.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn5.Width = 100;
			gridViewTextBoxColumn5.WrapText = true;
			gridViewTextBoxColumn6.ExcelExportType = 0;
			gridViewTextBoxColumn6.HeaderText = "Etendu";
			gridViewTextBoxColumn6.Name = "column4";
			gridViewTextBoxColumn6.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn6.Width = 110;
			gridViewTextBoxColumn6.WrapText = true;
			gridViewTextBoxColumn7.DataType = typeof(decimal);
			gridViewTextBoxColumn7.ExcelExportType = 0;
			gridViewTextBoxColumn7.HeaderText = "Moyenne";
			gridViewTextBoxColumn7.Name = "column5";
			gridViewTextBoxColumn7.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn7.Width = 110;
			gridViewTextBoxColumn7.WrapText = true;
			gridViewTextBoxColumn8.ExcelExportType = 0;
			gridViewTextBoxColumn8.HeaderText = "Ecart type";
			gridViewTextBoxColumn8.Name = "column7";
			gridViewTextBoxColumn8.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn8.Width = 120;
			gridViewTextBoxColumn9.ExcelExportType = 0;
			gridViewTextBoxColumn9.HeaderText = "Coe. Variation (%)";
			gridViewTextBoxColumn9.Name = "column8";
			gridViewTextBoxColumn9.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			gridViewTextBoxColumn9.Width = 80;
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
				gridViewTextBoxColumn9
			});
			this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
			this.radGridView1.MasterTemplate.EnableFiltering = true;
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
			this.radGridView1.Size = new global::System.Drawing.Size(969, 401);
			this.radGridView1.TabIndex = 249;
			this.radGridView1.ThemeName = "Fluent";
			this.radButton8.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton8.Font = new global::System.Drawing.Font("Calibri", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radButton8.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton8.Location = new global::System.Drawing.Point(861, 58);
			this.radButton8.Name = "radButton8";
			this.radButton8.Size = new global::System.Drawing.Size(120, 24);
			this.radButton8.TabIndex = 250;
			this.radButton8.Text = "Exporter Excel";
			this.radButton8.ThemeName = "Crystal";
			this.radButton8.Click += new global::System.EventHandler(this.radButton8_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1004, 501);
			base.Controls.Add(this.radButton8);
			base.Controls.Add(this.radGridView1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.radDateTimePicker2);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label20);
			base.Controls.Add(this.label19);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "tb_variation_prix_recap";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.tb_variation_prix_recap_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.radRadioButton1.EndInit();
			this.radRadioButton2.EndInit();
			this.radDateTimePicker2.EndInit();
			this.radDateTimePicker1.EndInit();
			this.radGridView1.MasterTemplate.EndInit();
			this.radGridView1.EndInit();
			this.radButton8.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001447 RID: 5191
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001448 RID: 5192
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04001449 RID: 5193
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x0400144A RID: 5194
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x0400144B RID: 5195
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x0400144C RID: 5196
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x0400144D RID: 5197
		private global::System.Windows.Forms.Label label20;

		// Token: 0x0400144E RID: 5198
		private global::System.Windows.Forms.Label label19;

		// Token: 0x0400144F RID: 5199
		private global::Telerik.WinControls.UI.RadGridView radGridView1;

		// Token: 0x04001450 RID: 5200
		private global::Telerik.WinControls.UI.RadButton radButton8;
	}
}
