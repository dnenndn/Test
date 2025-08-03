namespace GMAO
{
	// Token: 0x02000008 RID: 8
	public partial class activite_sous_traitance : global::System.Windows.Forms.Form
	{
		// Token: 0x06000059 RID: 89 RVA: 0x0000C8E8 File Offset: 0x0000AAE8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000C920 File Offset: 0x0000AB20
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Location = new global::System.Drawing.Point(-1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 10;
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1148, 25);
			this.panel4.TabIndex = 9;
			this.button2.BackColor = global::System.Drawing.Color.Firebrick;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(162, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(162, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "Liste activité";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.BackColor = global::System.Drawing.Color.Firebrick;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(162, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Créer Activité";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(-3, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 11;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel3.Location = new global::System.Drawing.Point(7, 42);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1128, 558);
			this.panel3.TabIndex = 12;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "activite_sous_traitance";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.activite_sous_traitance_Load);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400004F RID: 79
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000050 RID: 80
		public global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000052 RID: 82
		public global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000054 RID: 84
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000055 RID: 85
		public global::System.Windows.Forms.Button button1;
	}
}
