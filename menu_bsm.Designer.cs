namespace GMAO
{
	// Token: 0x02000096 RID: 150
	public partial class menu_bsm : global::System.Windows.Forms.Form
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x0012E438 File Offset: 0x0012C638
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0012E470 File Offset: 0x0012C670
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 8;
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
			this.button2.Text = "Historique BSM";
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
			this.button1.Text = "Créer BSM";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button4.BackColor = global::System.Drawing.Color.Firebrick;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(324, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(162, 25);
			this.button4.TabIndex = 4;
			this.button4.Text = "Tableau de bord";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1148, 25);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "menu_bsm";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.menu_bsm_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400094F RID: 2383
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000950 RID: 2384
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000951 RID: 2385
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000952 RID: 2386
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000953 RID: 2387
		public global::System.Windows.Forms.Button button4;
	}
}
