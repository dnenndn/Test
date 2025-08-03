namespace GMAO
{
	// Token: 0x020000D9 RID: 217
	public partial class ot_tb : global::System.Windows.Forms.Form
	{
		// Token: 0x060009AA RID: 2474 RVA: 0x00189570 File Offset: 0x00187770
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x001895A8 File Offset: 0x001877A8
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button5 = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button5);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1086, 25);
			this.panel4.TabIndex = 271;
			this.button4.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.Black;
			this.button4.Location = new global::System.Drawing.Point(472, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(139, 25);
			this.button4.TabIndex = 4;
			this.button4.Text = "Réalisation des travaux";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.Black;
			this.button3.Location = new global::System.Drawing.Point(274, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(198, 25);
			this.button3.TabIndex = 3;
			this.button3.Text = "Répartition par type de maintenance";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.Black;
			this.button2.Location = new global::System.Drawing.Point(135, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(139, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "KPI";
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
			this.button1.Text = "Général";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(0, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 492);
			this.panel1.TabIndex = 272;
			this.button5.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.Black;
			this.button5.Location = new global::System.Drawing.Point(611, 0);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(139, 25);
			this.button5.TabIndex = 5;
			this.button5.Text = "Coût de maintenance";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1107, 520);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tb_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000CA6 RID: 3238
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CA7 RID: 3239
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000CA8 RID: 3240
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000CA9 RID: 3241
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000CAA RID: 3242
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000CAB RID: 3243
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04000CAC RID: 3244
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04000CAD RID: 3245
		public global::System.Windows.Forms.Button button5;
	}
}
