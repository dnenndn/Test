namespace GMAO
{
	// Token: 0x020000E5 RID: 229
	public partial class outillage_date_heure_fin : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A05 RID: 2565 RVA: 0x001918B0 File Offset: 0x0018FAB0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x001918E8 File Offset: 0x0018FAE8
		private void InitializeComponent()
		{
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.fin_radDateTimePicker2 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.fin_radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radButton1.BeginInit();
			this.fin_radDateTimePicker2.BeginInit();
			this.fin_radTimePicker1.BeginInit();
			base.SuspendLayout();
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton1.Location = new global::System.Drawing.Point(154, 117);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(110, 24);
			this.radButton1.TabIndex = 26;
			this.radButton1.Text = "Cloturer";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(22, 76);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(53, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Heure_fin";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(22, 23);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(47, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Date_fin";
			this.fin_radDateTimePicker2.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.fin_radDateTimePicker2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.fin_radDateTimePicker2.ForeColor = global::System.Drawing.Color.DimGray;
			this.fin_radDateTimePicker2.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.fin_radDateTimePicker2.Location = new global::System.Drawing.Point(84, 17);
			this.fin_radDateTimePicker2.Name = "fin_radDateTimePicker2";
			this.fin_radDateTimePicker2.Size = new global::System.Drawing.Size(180, 27);
			this.fin_radDateTimePicker2.TabIndex = 166;
			this.fin_radDateTimePicker2.TabStop = false;
			this.fin_radDateTimePicker2.Text = "10/02/2021";
			this.fin_radDateTimePicker2.ThemeName = "Crystal";
			this.fin_radDateTimePicker2.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.fin_radDateTimePicker2.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radDateTimePicker2.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.fin_radTimePicker1.Location = new global::System.Drawing.Point(84, 73);
			this.fin_radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.fin_radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.fin_radTimePicker1.Name = "fin_radTimePicker1";
			this.fin_radTimePicker1.Size = new global::System.Drawing.Size(180, 24);
			this.fin_radTimePicker1.TabIndex = 202;
			this.fin_radTimePicker1.TabStop = false;
			this.fin_radTimePicker1.ThemeName = "Crystal";
			this.fin_radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 5, 18, 23, 1, 27, 720));
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).NumberOfColors = 1;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.RadTimeElementUpButton)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.fin_radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(360, 193);
			base.Controls.Add(this.fin_radTimePicker1);
			base.Controls.Add(this.fin_radDateTimePicker2);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Name = "outillage_date_heure_fin";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.outillage_date_heure_fin_Load);
			this.radButton1.EndInit();
			this.fin_radDateTimePicker2.EndInit();
			this.fin_radTimePicker1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000CFA RID: 3322
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CFB RID: 3323
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000CFC RID: 3324
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000CFD RID: 3325
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000CFE RID: 3326
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000CFF RID: 3327
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000D00 RID: 3328
		private global::Telerik.WinControls.UI.RadDateTimePicker fin_radDateTimePicker2;

		// Token: 0x04000D01 RID: 3329
		private global::Telerik.WinControls.UI.RadTimePicker fin_radTimePicker1;
	}
}
