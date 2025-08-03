namespace GMAO
{
	// Token: 0x02000079 RID: 121
	public partial class gamme_operatoire : global::System.Windows.Forms.Form
	{
		// Token: 0x0600059E RID: 1438 RVA: 0x000EBA54 File Offset: 0x000E9C54
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x000EBA8C File Offset: 0x000E9C8C
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button5);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(899, 29);
			this.panel4.TabIndex = 75;
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(158, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(160, 29);
			this.button1.TabIndex = 73;
			this.button1.Text = "Liste Gamme Opératoire";
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
			this.button2.Size = new global::System.Drawing.Size(158, 29);
			this.button2.TabIndex = 72;
			this.button2.Text = "Ajouter Gamme Opératoire";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel3.Location = new global::System.Drawing.Point(-10, 29);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1148, 10);
			this.panel3.TabIndex = 76;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel1.Location = new global::System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 501);
			this.panel1.TabIndex = 77;
			this.button3.BackColor = global::System.Drawing.Color.Gray;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(318, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(160, 29);
			this.button3.TabIndex = 74;
			this.button3.Text = "Maintenance Systématique";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button4.BackColor = global::System.Drawing.Color.Gray;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(478, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(160, 29);
			this.button4.TabIndex = 75;
			this.button4.Text = "Maintenance Syst. Compteur";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button5.BackColor = global::System.Drawing.Color.Gray;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(638, 0);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(160, 29);
			this.button5.TabIndex = 76;
			this.button5.Text = "Maintenance Conditionnelle";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "gamme_operatoire";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.gamme_operatoire_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000788 RID: 1928
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000789 RID: 1929
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400078A RID: 1930
		public global::System.Windows.Forms.Button button1;

		// Token: 0x0400078B RID: 1931
		public global::System.Windows.Forms.Button button2;

		// Token: 0x0400078C RID: 1932
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400078D RID: 1933
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400078E RID: 1934
		public global::System.Windows.Forms.Button button3;

		// Token: 0x0400078F RID: 1935
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04000790 RID: 1936
		public global::System.Windows.Forms.Button button5;
	}
}
