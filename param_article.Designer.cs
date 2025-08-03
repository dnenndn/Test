namespace GMAO
{
	// Token: 0x02000158 RID: 344
	public partial class param_article : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F46 RID: 3910 RVA: 0x0024FCCC File Offset: 0x0024DECC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x0024FD04 File Offset: 0x0024DF04
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(1, 7);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(899, 29);
			this.panel4.TabIndex = 72;
			this.button4.BackColor = global::System.Drawing.Color.Gray;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(346, 1);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(137, 28);
			this.button4.TabIndex = 75;
			this.button4.Text = "Emplacement Magasin";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.BackColor = global::System.Drawing.Color.Gray;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(229, 1);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(118, 28);
			this.button3.TabIndex = 74;
			this.button3.Text = "Moyen de stockage";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(112, 1);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(118, 28);
			this.button1.TabIndex = 73;
			this.button1.Text = "Classification";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.Color.Gray;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(0, 1);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(113, 28);
			this.button2.TabIndex = 72;
			this.button2.Text = "Unité de stockage";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel3.Location = new global::System.Drawing.Point(1, 36);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1148, 10);
			this.panel3.TabIndex = 73;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel5.Location = new global::System.Drawing.Point(2, 52);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(1114, 494);
			this.panel5.TabIndex = 74;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "param_article";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.param_article_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04001350 RID: 4944
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001351 RID: 4945
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04001352 RID: 4946
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04001353 RID: 4947
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04001354 RID: 4948
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04001355 RID: 4949
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04001356 RID: 4950
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04001357 RID: 4951
		private global::System.Windows.Forms.Panel panel5;
	}
}
