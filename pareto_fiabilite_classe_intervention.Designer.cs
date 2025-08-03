namespace GMAO
{
	// Token: 0x020000FB RID: 251
	public partial class pareto_fiabilite_classe_intervention : global::System.Windows.Forms.Form
	{
		// Token: 0x06000B0A RID: 2826 RVA: 0x001AC008 File Offset: 0x001AA208
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x001AC040 File Offset: 0x001AA240
		private void InitializeComponent()
		{
			global::Telerik.WinControls.UI.CartesianArea areaDesign = new global::Telerik.WinControls.UI.CartesianArea();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.radButton1 = new global::Telerik.WinControls.UI.RadButton();
			this.radTextBox3 = new global::Telerik.WinControls.UI.RadTextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.radTextBox2 = new global::Telerik.WinControls.UI.RadTextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.radTextBox1 = new global::Telerik.WinControls.UI.RadTextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.radRadioButton5 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton4 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton2 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radRadioButton1 = new global::Telerik.WinControls.UI.RadRadioButton();
			this.radChartView1 = new global::Telerik.WinControls.UI.RadChartView();
			this.panel2.SuspendLayout();
			this.radButton1.BeginInit();
			this.radTextBox3.BeginInit();
			this.radTextBox2.BeginInit();
			this.radTextBox1.BeginInit();
			this.panel1.SuspendLayout();
			this.radRadioButton5.BeginInit();
			this.radRadioButton4.BeginInit();
			this.radRadioButton2.BeginInit();
			this.radRadioButton1.BeginInit();
			this.radChartView1.BeginInit();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.radButton1);
			this.panel2.Controls.Add(this.radTextBox3);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.radTextBox2);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.radTextBox1);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new global::System.Drawing.Point(372, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(652, 42);
			this.panel2.TabIndex = 6;
			this.radButton1.Location = new global::System.Drawing.Point(319, 15);
			this.radButton1.Name = "radButton1";
			this.radButton1.Size = new global::System.Drawing.Size(36, 24);
			this.radButton1.TabIndex = 0;
			this.radButton1.Text = "OK";
			this.radButton1.ThemeName = "Fluent";
			this.radButton1.Click += new global::System.EventHandler(this.radButton1_Click);
			this.radTextBox3.Location = new global::System.Drawing.Point(213, 15);
			this.radTextBox3.Name = "radTextBox3";
			this.radTextBox3.Size = new global::System.Drawing.Size(100, 24);
			this.radTextBox3.TabIndex = 4;
			this.radTextBox3.ThemeName = "Fluent";
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.Color.DimGray;
			this.label3.Location = new global::System.Drawing.Point(210, 1);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(62, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Poids Maint";
			this.radTextBox2.Location = new global::System.Drawing.Point(109, 15);
			this.radTextBox2.Name = "radTextBox2";
			this.radTextBox2.Size = new global::System.Drawing.Size(100, 24);
			this.radTextBox2.TabIndex = 2;
			this.radTextBox2.ThemeName = "Fluent";
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(106, 1);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Poids Fiab";
			this.radTextBox1.Location = new global::System.Drawing.Point(6, 15);
			this.radTextBox1.Name = "radTextBox1";
			this.radTextBox1.Size = new global::System.Drawing.Size(100, 24);
			this.radTextBox1.TabIndex = 0;
			this.radTextBox1.ThemeName = "Fluent";
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(3, 1);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(57, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Poids Disp";
			this.panel1.Controls.Add(this.radRadioButton5);
			this.panel1.Controls.Add(this.radRadioButton4);
			this.panel1.Controls.Add(this.radRadioButton2);
			this.panel1.Controls.Add(this.radRadioButton1);
			this.panel1.Location = new global::System.Drawing.Point(6, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(360, 25);
			this.panel1.TabIndex = 8;
			this.radRadioButton5.Location = new global::System.Drawing.Point(251, 4);
			this.radRadioButton5.Name = "radRadioButton5";
			this.radRadioButton5.Size = new global::System.Drawing.Size(87, 18);
			this.radRadioButton5.TabIndex = 5;
			this.radRadioButton5.TabStop = false;
			this.radRadioButton5.Text = "Combinaison";
			this.radRadioButton5.ThemeName = "Fluent";
			this.radRadioButton5.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton5_ToggleStateChanged);
			this.radRadioButton4.Location = new global::System.Drawing.Point(153, 4);
			this.radRadioButton4.Name = "radRadioButton4";
			this.radRadioButton4.Size = new global::System.Drawing.Size(93, 18);
			this.radRadioButton4.TabIndex = 4;
			this.radRadioButton4.TabStop = false;
			this.radRadioButton4.Text = "Mainténabilité";
			this.radRadioButton4.ThemeName = "Fluent";
			this.radRadioButton4.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton4_ToggleStateChanged);
			this.radRadioButton2.Location = new global::System.Drawing.Point(89, 4);
			this.radRadioButton2.Name = "radRadioButton2";
			this.radRadioButton2.Size = new global::System.Drawing.Size(60, 18);
			this.radRadioButton2.TabIndex = 2;
			this.radRadioButton2.TabStop = false;
			this.radRadioButton2.Text = "Fiabilité";
			this.radRadioButton2.ThemeName = "Fluent";
			this.radRadioButton2.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
			this.radRadioButton1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.radRadioButton1.Location = new global::System.Drawing.Point(3, 4);
			this.radRadioButton1.Name = "radRadioButton1";
			this.radRadioButton1.Size = new global::System.Drawing.Size(84, 18);
			this.radRadioButton1.TabIndex = 1;
			this.radRadioButton1.Text = "Disponibilité";
			this.radRadioButton1.ThemeName = "Fluent";
			this.radRadioButton1.ToggleState = 1;
			this.radRadioButton1.ToggleStateChanged += new global::Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
			this.radChartView1.AreaDesign = areaDesign;
			this.radChartView1.Location = new global::System.Drawing.Point(13, 51);
			this.radChartView1.Name = "radChartView1";
			this.radChartView1.ShowGrid = false;
			this.radChartView1.Size = new global::System.Drawing.Size(1079, 376);
			this.radChartView1.TabIndex = 7;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1098, 430);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.radChartView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "pareto_fiabilite_classe_intervention";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.pareto_fiabilite_classe_intervention_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.radButton1.EndInit();
			this.radTextBox3.EndInit();
			this.radTextBox2.EndInit();
			this.radTextBox1.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.radRadioButton5.EndInit();
			this.radRadioButton4.EndInit();
			this.radRadioButton2.EndInit();
			this.radRadioButton1.EndInit();
			this.radChartView1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000E07 RID: 3591
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000E08 RID: 3592
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000E09 RID: 3593
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000E0A RID: 3594
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000E0B RID: 3595
		private global::Telerik.WinControls.UI.RadButton radButton1;

		// Token: 0x04000E0C RID: 3596
		private global::Telerik.WinControls.UI.RadTextBox radTextBox3;

		// Token: 0x04000E0D RID: 3597
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000E0E RID: 3598
		private global::Telerik.WinControls.UI.RadTextBox radTextBox2;

		// Token: 0x04000E0F RID: 3599
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000E10 RID: 3600
		private global::Telerik.WinControls.UI.RadTextBox radTextBox1;

		// Token: 0x04000E11 RID: 3601
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000E12 RID: 3602
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000E13 RID: 3603
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton5;

		// Token: 0x04000E14 RID: 3604
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton4;

		// Token: 0x04000E15 RID: 3605
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton2;

		// Token: 0x04000E16 RID: 3606
		private global::Telerik.WinControls.UI.RadRadioButton radRadioButton1;

		// Token: 0x04000E17 RID: 3607
		private global::Telerik.WinControls.UI.RadChartView radChartView1;
	}
}
