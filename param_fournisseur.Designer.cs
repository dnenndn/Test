namespace GMAO
{
	// Token: 0x02000159 RID: 345
	public partial class param_fournisseur : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F51 RID: 3921 RVA: 0x00250944 File Offset: 0x0024EB44
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x0025097C File Offset: 0x0024EB7C
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 6;
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 7;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel4.Controls.Add(this.button5);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(1, 42);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(899, 29);
			this.panel4.TabIndex = 71;
			this.button5.BackColor = global::System.Drawing.Color.Gray;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(460, 1);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(118, 28);
			this.button5.TabIndex = 76;
			this.button5.Text = "Devise";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button4.BackColor = global::System.Drawing.Color.Gray;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(346, 1);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(118, 28);
			this.button4.TabIndex = 75;
			this.button4.Text = "Compte budget";
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
			this.button3.Text = "Mode de livraison";
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
			this.button1.Text = "Mode de règlement";
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
			this.button2.Text = "Type d'activité";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel3.Location = new global::System.Drawing.Point(1, 71);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1148, 10);
			this.panel3.TabIndex = 72;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel5.Location = new global::System.Drawing.Point(1, 87);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(1114, 504);
			this.panel5.TabIndex = 73;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "param_fournisseur";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.param_fournisseur_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04001358 RID: 4952
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001359 RID: 4953
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400135A RID: 4954
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400135B RID: 4955
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400135C RID: 4956
		public global::System.Windows.Forms.Button button3;

		// Token: 0x0400135D RID: 4957
		public global::System.Windows.Forms.Button button1;

		// Token: 0x0400135E RID: 4958
		public global::System.Windows.Forms.Button button2;

		// Token: 0x0400135F RID: 4959
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04001360 RID: 4960
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04001361 RID: 4961
		public global::System.Windows.Forms.Button button5;

		// Token: 0x04001362 RID: 4962
		private global::System.Windows.Forms.Panel panel5;
	}
}
