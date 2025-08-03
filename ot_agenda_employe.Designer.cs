namespace GMAO
{
	// Token: 0x020000A3 RID: 163
	public partial class ot_agenda_employe : global::System.Windows.Forms.Form
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x0014E424 File Offset: 0x0014C624
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0014E45C File Offset: 0x0014C65C
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.SchedulerDailyPrintStyle schedulerDailyPrintStyle = new global::Telerik.WinControls.UI.SchedulerDailyPrintStyle();
			this.telerikMetroTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.radScheduler1 = new global::Telerik.WinControls.UI.RadScheduler();
			this.radDateTimePicker1.BeginInit();
			this.radScheduler1.BeginInit();
			base.SuspendLayout();
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(6, 16);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(138, 24);
			this.radDateTimePicker1.TabIndex = 281;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "20/11/2021";
			this.radDateTimePicker1.ThemeName = "Fluent";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 11, 20, 14, 25, 16, 200);
			this.radDateTimePicker1.ValueChanged += new global::System.EventHandler(this.radDateTimePicker1_ValueChanged);
			this.label8.AutoSize = true;
			this.label8.BackColor = global::System.Drawing.Color.Transparent;
			this.label8.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label8.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DimGray;
			this.label8.Location = new global::System.Drawing.Point(4, 3);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(38, 12);
			this.label8.TabIndex = 280;
			this.label8.Text = "Début";
			this.radScheduler1.AllowAppointmentCreateInline = false;
			this.radScheduler1.AllowAppointmentMove = false;
			this.radScheduler1.AutoScroll = true;
			this.radScheduler1.Culture = new global::System.Globalization.CultureInfo("fr-FR");
			this.radScheduler1.EnableExactTimeRendering = true;
			this.radScheduler1.Location = new global::System.Drawing.Point(6, 47);
			this.radScheduler1.Name = "radScheduler1";
			schedulerDailyPrintStyle.AppointmentFont = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			schedulerDailyPrintStyle.DateEndRange = new global::System.DateTime(2021, 10, 11, 0, 0, 0, 0);
			schedulerDailyPrintStyle.DateHeadingFont = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			schedulerDailyPrintStyle.DateStartRange = new global::System.DateTime(2021, 10, 6, 0, 0, 0, 0);
			schedulerDailyPrintStyle.PageHeadingFont = new global::System.Drawing.Font("Microsoft Sans Serif", 22f, global::System.Drawing.FontStyle.Bold);
			this.radScheduler1.PrintStyle = schedulerDailyPrintStyle;
			this.radScheduler1.ReadOnly = true;
			this.radScheduler1.Size = new global::System.Drawing.Size(1086, 440);
			this.radScheduler1.TabIndex = 279;
			this.radScheduler1.ThemeName = "TelerikMetro";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.radScheduler1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_agenda_employe";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_agenda_employe_Load);
			this.radDateTimePicker1.EndInit();
			this.radScheduler1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000A5B RID: 2651
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000A5C RID: 2652
		private global::Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;

		// Token: 0x04000A5D RID: 2653
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000A5E RID: 2654
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000A5F RID: 2655
		private global::Telerik.WinControls.UI.RadScheduler radScheduler1;

		// Token: 0x04000A60 RID: 2656
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000A61 RID: 2657
		internal global::System.Windows.Forms.Label label8;
	}
}
