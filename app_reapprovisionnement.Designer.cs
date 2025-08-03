namespace GMAO
{
	// Token: 0x02000019 RID: 25
	public partial class app_reapprovisionnement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000154 RID: 340 RVA: 0x00040830 File Offset: 0x0003EA30
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00040868 File Offset: 0x0003EA68
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.SchedulerDailyPrintStyle schedulerDailyPrintStyle = new global::Telerik.WinControls.UI.SchedulerDailyPrintStyle();
			this.radSchedulerNavigator1 = new global::Telerik.WinControls.UI.RadSchedulerNavigator();
			this.materialTheme1 = new global::Telerik.WinControls.Themes.MaterialTheme();
			this.radButton3 = new global::Telerik.WinControls.UI.RadButton();
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radScheduler1 = new global::Telerik.WinControls.UI.RadScheduler();
			this.telerikMetroTouchTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroTouchTheme();
			this.radSchedulerNavigator1.BeginInit();
			this.radButton3.BeginInit();
			this.radButton1.BeginInit();
			this.radScheduler1.BeginInit();
			base.SuspendLayout();
			this.radSchedulerNavigator1.AssociatedScheduler = this.radScheduler1;
			this.radSchedulerNavigator1.DateFormat = "yyyy/MM/dd";
			this.radSchedulerNavigator1.Location = new global::System.Drawing.Point(15, 23);
			this.radSchedulerNavigator1.Name = "radSchedulerNavigator1";
			this.radSchedulerNavigator1.NavigationStepType = 2;
			this.radSchedulerNavigator1.RootElement.StretchVertically = false;
			this.radSchedulerNavigator1.Size = new global::System.Drawing.Size(920, 97);
			this.radSchedulerNavigator1.TabIndex = 1;
			this.radSchedulerNavigator1.ThemeName = "TelerikMetroTouch";
			((global::Telerik.WinControls.UI.RadLabelElement)this.radSchedulerNavigator1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(6).GetChildAt(0)).Text = "(UTC+01:00) Bruxelles, Copenhague, Madrid, Paris";
			((global::Telerik.WinControls.UI.RadLabelElement)this.radSchedulerNavigator1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(2).GetChildAt(6).GetChildAt(0)).CanFocus = false;
			this.radButton3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton3.Font = new global::System.Drawing.Font("Calibri", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radButton3.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton3.Location = new global::System.Drawing.Point(941, 87);
			this.radButton3.Name = "radButton3";
			this.radButton3.Size = new global::System.Drawing.Size(162, 24);
			this.radButton3.TabIndex = 231;
			this.radButton3.Text = "Planifier DA";
			this.radButton3.ThemeName = "Crystal";
			this.radButton3.Click += new global::System.EventHandler(this.radButton3_Click);
			this.radButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.radButton1.Font = new global::System.Drawing.Font("Calibri", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radButton1.ForeColor = global::System.Drawing.Color.Firebrick;
			this.radButton1.Location = new global::System.Drawing.Point(941, 57);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(162, 24);
			this.radButton1.TabIndex = 232;
			this.radButton1.Text = "Actualiser";
			this.radButton1.ThemeName = "Crystal";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radScheduler1.AllowAppointmentCreateInline = false;
			this.radScheduler1.AllowAppointmentMove = false;
			this.radScheduler1.AutoScroll = true;
			this.radScheduler1.Culture = new global::System.Globalization.CultureInfo("fr-FR");
			this.radScheduler1.EnableExactTimeRendering = true;
			this.radScheduler1.Location = new global::System.Drawing.Point(12, 117);
			this.radScheduler1.Name = "radScheduler1";
			schedulerDailyPrintStyle.AppointmentFont = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			schedulerDailyPrintStyle.DateEndRange = new global::System.DateTime(2021, 10, 11, 0, 0, 0, 0);
			schedulerDailyPrintStyle.DateHeadingFont = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			schedulerDailyPrintStyle.DateStartRange = new global::System.DateTime(2021, 10, 6, 0, 0, 0, 0);
			schedulerDailyPrintStyle.PageHeadingFont = new global::System.Drawing.Font("Microsoft Sans Serif", 22f, global::System.Drawing.FontStyle.Bold);
			this.radScheduler1.PrintStyle = schedulerDailyPrintStyle;
			this.radScheduler1.ReadOnly = true;
			this.radScheduler1.Size = new global::System.Drawing.Size(1091, 429);
			this.radScheduler1.TabIndex = 0;
			this.radScheduler1.ThemeName = "TelerikMetroTouch";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.radButton1);
			base.Controls.Add(this.radButton3);
			base.Controls.Add(this.radSchedulerNavigator1);
			base.Controls.Add(this.radScheduler1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "app_reapprovisionnement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.app_reapprovisionnement_Load);
			this.radSchedulerNavigator1.EndInit();
			this.radButton3.EndInit();
			this.radButton1.EndInit();
			this.radScheduler1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000211 RID: 529
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000212 RID: 530
		private global::Telerik.WinControls.UI.RadScheduler radScheduler1;

		// Token: 0x04000213 RID: 531
		private global::Telerik.WinControls.UI.RadSchedulerNavigator radSchedulerNavigator1;

		// Token: 0x04000214 RID: 532
		private global::Telerik.WinControls.Themes.MaterialTheme materialTheme1;

		// Token: 0x04000215 RID: 533
		private global::Telerik.WinControls.UI.RadButton radButton3;

		// Token: 0x04000216 RID: 534
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;

		// Token: 0x04000217 RID: 535
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000218 RID: 536
		private global::Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
	}
}
