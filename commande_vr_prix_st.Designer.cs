namespace GMAO
{
	// Token: 0x02000049 RID: 73
	public partial class commande_vr_prix_st : global::System.Windows.Forms.Form
	{
		// Token: 0x06000346 RID: 838 RVA: 0x0008CFC0 File Offset: 0x0008B1C0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0008CFF8 File Offset: 0x0008B1F8
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.CartesianArea cartesianArea = new global::Telerik.WinControls.UI.CartesianArea();
			this.radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.radDateTimePicker2.BeginInit();
			this.radDateTimePicker1.BeginInit();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker2.Location = new global::System.Drawing.Point(143, 27);
			this.radDateTimePicker2.Name = "radDateTimePicker2";
			this.radDateTimePicker2.Size = new global::System.Drawing.Size(117, 23);
			this.radDateTimePicker2.TabIndex = 250;
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
			this.radDateTimePicker1.TabIndex = 249;
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
			this.label20.TabIndex = 247;
			this.label20.Text = "Date début";
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.ForeColor = global::System.Drawing.Color.Black;
			this.label19.Location = new global::System.Drawing.Point(140, 9);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(49, 15);
			this.label19.TabIndex = 248;
			this.label19.Text = "Date fin";
			cartesianArea.ShowGrid = true;
			this.radChartView1.AreaDesign = cartesianArea;
			this.radChartView1.Location = new global::System.Drawing.Point(23, 70);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowTrackBall = true;
			this.radChartView1.Size = new global::System.Drawing.Size(919, 298);
			this.radChartView1.TabIndex = 251;
			this.radChartView1.ThemeName = "Crystal";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(965, 415);
			base.Controls.Add(this.radChartView1);
			base.Controls.Add(this.radDateTimePicker2);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label20);
			base.Controls.Add(this.label19);
			base.Name = "commande_vr_prix_st";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.commande_vr_prix_st_Load);
			this.radDateTimePicker2.EndInit();
			this.radDateTimePicker1.EndInit();
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000488 RID: 1160
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000489 RID: 1161
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker2;

		// Token: 0x0400048A RID: 1162
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.Label label20;

		// Token: 0x0400048C RID: 1164
		private global::System.Windows.Forms.Label label19;

		// Token: 0x0400048D RID: 1165
		private global::Telerik.WinControls.UI.RadChartView radChartView1;
	}
}
