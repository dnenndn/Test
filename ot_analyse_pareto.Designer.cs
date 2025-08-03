namespace GMAO
{
	// Token: 0x020000A8 RID: 168
	public partial class ot_analyse_pareto : global::System.Windows.Forms.Form
	{
		// Token: 0x060007B5 RID: 1973 RVA: 0x0015467C File Offset: 0x0015287C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x001546B4 File Offset: 0x001528B4
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1086, 25);
			this.panel4.TabIndex = 272;
			this.button2.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.Black;
			this.button2.Location = new global::System.Drawing.Point(154, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(139, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "Coût de maintenance";
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
			this.button1.Size = new global::System.Drawing.Size(154, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Indicateurs de maintenance";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(0, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1102, 460);
			this.panel1.TabIndex = 273;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 492);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_analyse_pareto";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_analyse_pareto_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000AB1 RID: 2737
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000AB2 RID: 2738
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000AB3 RID: 2739
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000AB4 RID: 2740
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000AB5 RID: 2741
		private global::System.Windows.Forms.Panel panel1;
	}
}
