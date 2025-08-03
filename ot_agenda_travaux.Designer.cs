namespace GMAO
{
	// Token: 0x020000A4 RID: 164
	public partial class ot_agenda_travaux : global::System.Windows.Forms.Form
	{
		// Token: 0x06000798 RID: 1944 RVA: 0x00150168 File Offset: 0x0014E368
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x001501A0 File Offset: 0x0014E3A0
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.SchedulerDailyPrintStyle schedulerDailyPrintStyle = new global::Telerik.WinControls.UI.SchedulerDailyPrintStyle();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label8 = new global::System.Windows.Forms.Label();
			this.telerikMetroTheme1 = new global::Telerik.WinControls.Themes.TelerikMetroTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.radGanttView1 = new global::Telerik.WinControls.UI.RadGanttView();
			this.radScheduler1 = new global::Telerik.WinControls.UI.RadScheduler();
			this.radDateTimePicker1.BeginInit();
			this.radDropDownList6.BeginInit();
			this.radDropDownList1.BeginInit();
			this.radGanttView1.BeginInit();
			this.radScheduler1.BeginInit();
			base.SuspendLayout();
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(6, 22);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(138, 24);
			this.radDateTimePicker1.TabIndex = 275;
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
			this.label8.Location = new global::System.Drawing.Point(4, 9);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(38, 12);
			this.label8.TabIndex = 274;
			this.label8.Text = "Début";
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(151, 22);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(153, 24);
			this.radDropDownList6.TabIndex = 280;
			this.radDropDownList6.ThemeName = "Fluent";
			this.radDropDownList6.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList6_SelectedIndexChanged);
			this.label6.AutoSize = true;
			this.label6.BackColor = global::System.Drawing.Color.Transparent;
			this.label6.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label6.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DimGray;
			this.label6.Location = new global::System.Drawing.Point(149, 9);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(59, 12);
			this.label6.TabIndex = 279;
			this.label6.Text = "Affichage";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(312, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(125, 12);
			this.label1.TabIndex = 281;
			this.label1.Text = "Type de maintenance";
			this.radDropDownList1.DropDownStyle = 2;
			this.radDropDownList1.Location = new global::System.Drawing.Point(314, 22);
			this.radDropDownList1.Name = "radDropDownList1";
			this.radDropDownList1.Size = new global::System.Drawing.Size(153, 24);
			this.radDropDownList1.TabIndex = 282;
			this.radDropDownList1.ThemeName = "Fluent";
			this.radDropDownList1.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged);
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(106, 68, 232);
			this.panel1.Location = new global::System.Drawing.Point(482, 9);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(16, 16);
			this.panel1.TabIndex = 283;
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 178);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(501, 10);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(47, 13);
			this.label2.TabIndex = 284;
			this.label2.Text = "En Cours";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 178);
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(501, 30);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(43, 13);
			this.label3.TabIndex = 286;
			this.label3.Text = "Planifié";
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(255, 0, 127);
			this.panel2.Location = new global::System.Drawing.Point(482, 29);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(16, 16);
			this.panel2.TabIndex = 285;
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 178);
			this.label4.ForeColor = global::System.Drawing.Color.DimGray;
			this.label4.Location = new global::System.Drawing.Point(573, 10);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(42, 13);
			this.label4.TabIndex = 288;
			this.label4.Text = "Clôturé";
			this.panel3.BackColor = global::System.Drawing.Color.PaleGreen;
			this.panel3.Location = new global::System.Drawing.Point(554, 9);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(16, 16);
			this.panel3.TabIndex = 287;
			this.label5.AutoSize = true;
			this.label5.BackColor = global::System.Drawing.Color.Transparent;
			this.label5.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label5.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 178);
			this.label5.ForeColor = global::System.Drawing.Color.DimGray;
			this.label5.Location = new global::System.Drawing.Point(573, 30);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(76, 13);
			this.label5.TabIndex = 290;
			this.label5.Text = "En Préparation";
			this.panel4.BackColor = global::System.Drawing.Color.Aquamarine;
			this.panel4.Location = new global::System.Drawing.Point(554, 29);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(16, 16);
			this.panel4.TabIndex = 289;
			this.label7.AutoSize = true;
			this.label7.BackColor = global::System.Drawing.Color.Transparent;
			this.label7.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label7.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 178);
			this.label7.ForeColor = global::System.Drawing.Color.DimGray;
			this.label7.Location = new global::System.Drawing.Point(674, 10);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(124, 13);
			this.label7.TabIndex = 292;
			this.label7.Text = "En Attente Arrêt Machine";
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 0);
			this.panel5.Location = new global::System.Drawing.Point(655, 9);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(16, 16);
			this.panel5.TabIndex = 291;
			this.label9.AutoSize = true;
			this.label9.BackColor = global::System.Drawing.Color.Transparent;
			this.label9.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label9.Font = new global::System.Drawing.Font("Calibri", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 178);
			this.label9.ForeColor = global::System.Drawing.Color.DimGray;
			this.label9.Location = new global::System.Drawing.Point(674, 30);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(125, 13);
			this.label9.TabIndex = 294;
			this.label9.Text = "Sous-Traitant à contacter";
			this.panel6.BackColor = global::System.Drawing.Color.Silver;
			this.panel6.Location = new global::System.Drawing.Point(655, 29);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(16, 16);
			this.panel6.TabIndex = 293;
			this.radGanttView1.AutoScroll = true;
			this.radGanttView1.ItemHeight = 30;
			this.radGanttView1.Location = new global::System.Drawing.Point(6, 268);
			this.radGanttView1.Name = "radGanttView1";
			this.radGanttView1.ReadOnly = true;
			this.radGanttView1.ShowTimelineTodayIndicator = false;
			this.radGanttView1.ShowTodayIndicator = false;
			this.radGanttView1.Size = new global::System.Drawing.Size(1086, 223);
			this.radGanttView1.SplitterWidth = 8;
			this.radGanttView1.TabIndex = 295;
			this.radGanttView1.ThemeName = "Crystal";
			this.radScheduler1.AllowAppointmentCreateInline = false;
			this.radScheduler1.AllowAppointmentMove = false;
			this.radScheduler1.AutoScroll = true;
			this.radScheduler1.Culture = new global::System.Globalization.CultureInfo("fr-FR");
			this.radScheduler1.EnableExactTimeRendering = true;
			this.radScheduler1.Location = new global::System.Drawing.Point(6, 51);
			this.radScheduler1.Name = "radScheduler1";
			schedulerDailyPrintStyle.AppointmentFont = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			schedulerDailyPrintStyle.DateEndRange = new global::System.DateTime(2021, 10, 11, 0, 0, 0, 0);
			schedulerDailyPrintStyle.DateHeadingFont = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			schedulerDailyPrintStyle.DateStartRange = new global::System.DateTime(2021, 10, 6, 0, 0, 0, 0);
			schedulerDailyPrintStyle.PageHeadingFont = new global::System.Drawing.Font("Microsoft Sans Serif", 22f, global::System.Drawing.FontStyle.Bold);
			this.radScheduler1.PrintStyle = schedulerDailyPrintStyle;
			this.radScheduler1.ReadOnly = true;
			this.radScheduler1.Size = new global::System.Drawing.Size(1086, 211);
			this.radScheduler1.TabIndex = 278;
			this.radScheduler1.ThemeName = "TelerikMetro";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.radGanttView1);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radDropDownList1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.radScheduler1);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label8);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_agenda_travaux";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_agenda_travaux_Load);
			this.radDateTimePicker1.EndInit();
			this.radDropDownList6.EndInit();
			this.radDropDownList1.EndInit();
			this.radGanttView1.EndInit();
			this.radScheduler1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000A62 RID: 2658
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000A63 RID: 2659
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000A64 RID: 2660
		internal global::System.Windows.Forms.Label label8;

		// Token: 0x04000A65 RID: 2661
		private global::Telerik.WinControls.UI.RadScheduler radScheduler1;

		// Token: 0x04000A66 RID: 2662
		private global::Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;

		// Token: 0x04000A67 RID: 2663
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000A68 RID: 2664
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000A69 RID: 2665
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000A6A RID: 2666
		internal global::System.Windows.Forms.Label label6;

		// Token: 0x04000A6B RID: 2667
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000A6C RID: 2668
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;

		// Token: 0x04000A6D RID: 2669
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000A6E RID: 2670
		internal global::System.Windows.Forms.Label label2;

		// Token: 0x04000A6F RID: 2671
		internal global::System.Windows.Forms.Label label3;

		// Token: 0x04000A70 RID: 2672
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000A71 RID: 2673
		internal global::System.Windows.Forms.Label label4;

		// Token: 0x04000A72 RID: 2674
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000A73 RID: 2675
		internal global::System.Windows.Forms.Label label5;

		// Token: 0x04000A74 RID: 2676
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000A75 RID: 2677
		internal global::System.Windows.Forms.Label label7;

		// Token: 0x04000A76 RID: 2678
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000A77 RID: 2679
		internal global::System.Windows.Forms.Label label9;

		// Token: 0x04000A78 RID: 2680
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000A79 RID: 2681
		private global::Telerik.WinControls.UI.RadGanttView radGanttView1;
	}
}
