namespace GMAO
{
	// Token: 0x020000DB RID: 219
	public partial class ot_tb_cout : global::System.Windows.Forms.Form
	{
		// Token: 0x060009B5 RID: 2485 RVA: 0x00189EFC File Offset: 0x001880FC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00189F34 File Offset: 0x00188134
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1037, 25);
			this.panel4.TabIndex = 272;
			this.button3.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.Black;
			this.button3.Location = new global::System.Drawing.Point(135, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(124, 25);
			this.button3.TabIndex = 3;
			this.button3.Text = "Coût MO";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
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
			this.button1.Text = "Coût Total";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(1, 31);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1091, 449);
			this.panel1.TabIndex = 273;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_tb_cout";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_tb_cout_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000CB0 RID: 3248
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000CB1 RID: 3249
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000CB2 RID: 3250
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04000CB3 RID: 3251
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000CB4 RID: 3252
		private global::System.Windows.Forms.Panel panel1;
	}
}
