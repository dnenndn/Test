namespace GMAO
{
	// Token: 0x020000D2 RID: 210
	public partial class ot_tableau : global::System.Windows.Forms.Form
	{
		// Token: 0x06000972 RID: 2418 RVA: 0x0018465C File Offset: 0x0018285C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00184694 File Offset: 0x00182894
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button6 = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button6);
			this.panel4.Controls.Add(this.button5);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1086, 25);
			this.panel4.TabIndex = 271;
			this.button2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.Black;
			this.button2.Location = new global::System.Drawing.Point(135, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(124, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "BSM";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.BackColor = global::System.Drawing.Color.White;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.Black;
			this.button1.Location = new global::System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(135, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Interventions";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(0, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 492);
			this.panel1.TabIndex = 272;
			this.button3.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.Black;
			this.button3.Location = new global::System.Drawing.Point(259, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(124, 25);
			this.button3.TabIndex = 3;
			this.button3.Text = "Réservation PDR";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button4.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.Black;
			this.button4.Location = new global::System.Drawing.Point(383, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(124, 25);
			this.button4.TabIndex = 4;
			this.button4.Text = "Réparation Externe";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button5.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.Black;
			this.button5.Location = new global::System.Drawing.Point(507, 0);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(124, 25);
			this.button5.TabIndex = 5;
			this.button5.Text = "Projet";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button6.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button6.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button6.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button6.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button6.ForeColor = global::System.Drawing.Color.Black;
			this.button6.Location = new global::System.Drawing.Point(631, 0);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(124, 25);
			this.button6.TabIndex = 6;
			this.button6.Text = "Outillage";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1107, 520);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tableau";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tableau_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000C81 RID: 3201
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000C82 RID: 3202
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000C83 RID: 3203
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000C84 RID: 3204
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000C85 RID: 3205
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000C86 RID: 3206
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04000C87 RID: 3207
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04000C88 RID: 3208
		public global::System.Windows.Forms.Button button5;

		// Token: 0x04000C89 RID: 3209
		public global::System.Windows.Forms.Button button6;
	}
}
