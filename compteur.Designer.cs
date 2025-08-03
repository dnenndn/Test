namespace GMAO
{
	// Token: 0x0200004A RID: 74
	public partial class compteur : global::System.Windows.Forms.Form
	{
		// Token: 0x0600034F RID: 847 RVA: 0x0008DBF8 File Offset: 0x0008BDF8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0008DC30 File Offset: 0x0008BE30
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.button4 = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1148, 25);
			this.panel4.TabIndex = 15;
			this.button3.BackColor = global::System.Drawing.Color.Firebrick;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(323, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(188, 25);
			this.button3.TabIndex = 3;
			this.button3.Text = "Historique de variation";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button2.BackColor = global::System.Drawing.Color.Firebrick;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(135, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(188, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "Historique des compteurs";
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
			this.button1.Size = new global::System.Drawing.Size(135, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Compteur Actuel";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(-3, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1148, 10);
			this.panel1.TabIndex = 17;
			this.panel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel3.Location = new global::System.Drawing.Point(7, 42);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1128, 558);
			this.panel3.TabIndex = 18;
			this.button4.BackColor = global::System.Drawing.Color.Firebrick;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(511, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(188, 25);
			this.button4.TabIndex = 4;
			this.button4.Text = "Liaison Intervention Corrective";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "compteur";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.compteur_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400048E RID: 1166
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400048F RID: 1167
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000490 RID: 1168
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000491 RID: 1169
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000492 RID: 1170
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000493 RID: 1171
		public global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000494 RID: 1172
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04000495 RID: 1173
		public global::System.Windows.Forms.Button button4;
	}
}
