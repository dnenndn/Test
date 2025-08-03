namespace GMAO
{
	// Token: 0x02000141 RID: 321
	public partial class menu_demande_achat : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E64 RID: 3684 RVA: 0x00230174 File Offset: 0x0022E374
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x002301AC File Offset: 0x0022E3AC
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.button6 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button7 = new global::System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.button7);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 7;
			this.button6.BackColor = global::System.Drawing.Color.Firebrick;
			this.button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button6.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button6.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button6.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button6.ForeColor = global::System.Drawing.Color.White;
			this.button6.Location = new global::System.Drawing.Point(810, 0);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(162, 25);
			this.button6.TabIndex = 6;
			this.button6.Text = "DA Administrateur";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			this.button5.BackColor = global::System.Drawing.Color.Firebrick;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(648, 0);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(162, 25);
			this.button5.TabIndex = 5;
			this.button5.Text = "DA Reporté";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button4.BackColor = global::System.Drawing.Color.Firebrick;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(486, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(162, 25);
			this.button4.TabIndex = 4;
			this.button4.Text = "DA Refusée";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.BackColor = global::System.Drawing.Color.Firebrick;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(324, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(162, 25);
			this.button3.TabIndex = 3;
			this.button3.Text = "DA Confirmée";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
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
			this.button2.Text = "DA en cours";
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
			this.button1.Text = "Créer une demande d'achat";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button7.BackColor = global::System.Drawing.Color.Firebrick;
			this.button7.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button7.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button7.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button7.ForeColor = global::System.Drawing.Color.White;
			this.button7.Location = new global::System.Drawing.Point(972, 0);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(162, 25);
			this.button7.TabIndex = 7;
			this.button7.Text = "Historique DA Commandée";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new global::System.EventHandler(this.button7_Click_1);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1148, 25);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "menu_demande_achat";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.menu_demande_achat_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400121D RID: 4637
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400121E RID: 4638
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400121F RID: 4639
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04001220 RID: 4640
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04001221 RID: 4641
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04001222 RID: 4642
		public global::System.Windows.Forms.Button button4;

		// Token: 0x04001223 RID: 4643
		public global::System.Windows.Forms.Button button5;

		// Token: 0x04001224 RID: 4644
		public global::System.Windows.Forms.Button button6;

		// Token: 0x04001225 RID: 4645
		public global::System.Windows.Forms.Button button7;
	}
}
