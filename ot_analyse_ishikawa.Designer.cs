namespace GMAO
{
	// Token: 0x020000A7 RID: 167
	public partial class ot_analyse_ishikawa : global::System.Windows.Forms.Form
	{
		// Token: 0x060007AF RID: 1967 RVA: 0x00153C18 File Offset: 0x00151E18
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00153C50 File Offset: 0x00151E50
		private void InitializeComponent()
		{
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new global::System.Drawing.Point(1, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1091, 477);
			this.panel1.TabIndex = 68;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.label1.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label1.Location = new global::System.Drawing.Point(854, 213);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(200, 127);
			this.label1.TabIndex = 70;
			this.label1.Text = "Les Défaillances des OT";
			this.panel6.AutoScroll = true;
			this.panel6.Location = new global::System.Drawing.Point(607, 229);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(198, 198);
			this.panel6.TabIndex = 69;
			this.panel5.AutoScroll = true;
			this.panel5.Location = new global::System.Drawing.Point(113, 229);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(198, 198);
			this.panel5.TabIndex = 68;
			this.panel4.AutoScroll = true;
			this.panel4.Location = new global::System.Drawing.Point(607, 39);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(198, 166);
			this.panel4.TabIndex = 67;
			this.panel3.AutoScroll = true;
			this.panel3.Location = new global::System.Drawing.Point(361, 39);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(198, 166);
			this.panel3.TabIndex = 66;
			this.panel2.AutoScroll = true;
			this.panel2.Location = new global::System.Drawing.Point(113, 39);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(198, 166);
			this.panel2.TabIndex = 65;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label8.Location = new global::System.Drawing.Point(589, 430);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(44, 18);
			this.label8.TabIndex = 64;
			this.label8.Text = "Milieu";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label7.Location = new global::System.Drawing.Point(84, 430);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(58, 18);
			this.label7.TabIndex = 63;
			this.label7.Text = "Méthode";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label6.Location = new global::System.Drawing.Point(589, 11);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(52, 18);
			this.label6.TabIndex = 62;
			this.label6.Text = "Matière";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label5.Location = new global::System.Drawing.Point(334, 11);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(56, 18);
			this.label5.TabIndex = 61;
			this.label5.Text = "Matériel";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label3.Location = new global::System.Drawing.Point(74, 11);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(88, 18);
			this.label3.TabIndex = 60;
			this.label3.Text = "Main d'ouevre";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Trebuchet MS", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label2.Location = new global::System.Drawing.Point(807, 212);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(50, 18);
			this.label2.TabIndex = 59;
			this.label2.Text = "Effet : ";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_analyse_ishikawa";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_analyse_ishikawa_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000AA0 RID: 2720
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000AA1 RID: 2721
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000AA2 RID: 2722
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000AA3 RID: 2723
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000AA4 RID: 2724
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000AA5 RID: 2725
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000AA6 RID: 2726
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000AA7 RID: 2727
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000AA8 RID: 2728
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000AA9 RID: 2729
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000AAA RID: 2730
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000AAB RID: 2731
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000AAC RID: 2732
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000AAD RID: 2733
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000AAE RID: 2734
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000AAF RID: 2735
		private global::System.Windows.Forms.Label label2;
	}
}
