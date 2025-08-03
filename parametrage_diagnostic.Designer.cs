namespace GMAO
{
	// Token: 0x020000F0 RID: 240
	public partial class parametrage_diagnostic : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A6E RID: 2670 RVA: 0x0019D000 File Offset: 0x0019B200
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0019D038 File Offset: 0x0019B238
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(899, 29);
			this.panel4.TabIndex = 74;
			this.button3.BackColor = global::System.Drawing.Color.Gray;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(251, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(138, 29);
			this.button3.TabIndex = 74;
			this.button3.Text = "Symptômes";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(113, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(138, 29);
			this.button1.TabIndex = 73;
			this.button1.Text = "Arbre des défaillances";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.Color.Gray;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(0, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(113, 29);
			this.button2.TabIndex = 72;
			this.button2.Text = "Anomalies";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel3.Location = new global::System.Drawing.Point(-10, 29);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1148, 10);
			this.panel3.TabIndex = 75;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel1.Location = new global::System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 501);
			this.panel1.TabIndex = 76;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "parametrage_diagnostic";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.parametrage_diagnostic_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000D71 RID: 3441
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D72 RID: 3442
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000D73 RID: 3443
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000D74 RID: 3444
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000D75 RID: 3445
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000D76 RID: 3446
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000D77 RID: 3447
		public global::System.Windows.Forms.Button button3;
	}
}
