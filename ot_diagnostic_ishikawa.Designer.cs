namespace GMAO
{
	// Token: 0x020000B6 RID: 182
	public partial class ot_diagnostic_ishikawa : global::System.Windows.Forms.Form
	{
		// Token: 0x06000842 RID: 2114 RVA: 0x00163F40 File Offset: 0x00162140
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00163F78 File Offset: 0x00162178
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
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
			this.panel1.Location = new global::System.Drawing.Point(5, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1057, 238);
			this.panel1.TabIndex = 67;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label8.Location = new global::System.Drawing.Point(589, 215);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(44, 18);
			this.label8.TabIndex = 64;
			this.label8.Text = "Milieu";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label7.Location = new global::System.Drawing.Point(84, 215);
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
			this.label2.Location = new global::System.Drawing.Point(811, 110);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(50, 18);
			this.label2.TabIndex = 59;
			this.label2.Text = "Effet : ";
			this.panel2.AutoScroll = true;
			this.panel2.Location = new global::System.Drawing.Point(113, 39);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(198, 74);
			this.panel2.TabIndex = 65;
			this.panel3.AutoScroll = true;
			this.panel3.Location = new global::System.Drawing.Point(361, 39);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(198, 74);
			this.panel3.TabIndex = 66;
			this.panel4.AutoScroll = true;
			this.panel4.Location = new global::System.Drawing.Point(607, 39);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(198, 74);
			this.panel4.TabIndex = 67;
			this.panel5.AutoScroll = true;
			this.panel5.Location = new global::System.Drawing.Point(113, 128);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(198, 74);
			this.panel5.TabIndex = 68;
			this.panel6.AutoScroll = true;
			this.panel6.Location = new global::System.Drawing.Point(607, 128);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(198, 74);
			this.panel6.TabIndex = 69;
			this.label1.Font = new global::System.Drawing.Font("Trebuchet MS", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DarkGray;
			this.label1.Location = new global::System.Drawing.Point(854, 111);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(200, 91);
			this.label1.TabIndex = 70;
			this.label1.Text = "label1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_diagnostic_ishikawa";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_diagnostic_ishikawa_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000B4D RID: 2893
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B4E RID: 2894
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000B4F RID: 2895
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000B50 RID: 2896
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000B51 RID: 2897
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000B52 RID: 2898
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000B53 RID: 2899
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000B54 RID: 2900
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000B55 RID: 2901
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000B56 RID: 2902
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000B57 RID: 2903
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000B58 RID: 2904
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000B59 RID: 2905
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000B5A RID: 2906
		private global::System.Windows.Forms.Label label1;
	}
}
