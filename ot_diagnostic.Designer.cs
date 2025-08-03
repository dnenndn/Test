namespace GMAO
{
	// Token: 0x020000B3 RID: 179
	public partial class ot_diagnostic : global::System.Windows.Forms.Form
	{
		// Token: 0x0600081B RID: 2075 RVA: 0x0015E460 File Offset: 0x0015C660
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0015E498 File Offset: 0x0015C698
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.guna2Button6 = new global::Guna.UI2.WinForms.Guna2Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.guna2Button6);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Location = new global::System.Drawing.Point(0, 1);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1086, 25);
			this.panel4.TabIndex = 272;
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
			this.button2.Text = "Arbre des causes";
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
			this.button1.Text = "Analyse des causes";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.Location = new global::System.Drawing.Point(0, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1074, 243);
			this.panel1.TabIndex = 273;
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
			this.button3.Text = "Diagramme Ishikawa";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.guna2Button6.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button6.BorderRadius = 8;
			this.guna2Button6.BorderThickness = 1;
			this.guna2Button6.CheckedState.Parent = this.guna2Button6;
			this.guna2Button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button6.CustomImages.Parent = this.guna2Button6;
			this.guna2Button6.FillColor = global::System.Drawing.Color.White;
			this.guna2Button6.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button6.ForeColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button6.HoverState.Parent = this.guna2Button6;
			this.guna2Button6.Location = new global::System.Drawing.Point(888, 3);
			this.guna2Button6.Name = "guna2Button6";
			this.guna2Button6.ShadowDecoration.Parent = this.guna2Button6;
			this.guna2Button6.Size = new global::System.Drawing.Size(185, 20);
			this.guna2Button6.TabIndex = 172;
			this.guna2Button6.Text = "Imprimer Fiche de diagnostic";
			this.guna2Button6.Click += new global::System.EventHandler(this.guna2Button6_Click);
			this.button4.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.Black;
			this.button4.Location = new global::System.Drawing.Point(383, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(124, 25);
			this.button4.TabIndex = 173;
			this.button4.Text = "Rapport Final";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1086, 277);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_diagnostic";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_diagnostic_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B17 RID: 2839
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B18 RID: 2840
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000B19 RID: 2841
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000B1A RID: 2842
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000B1B RID: 2843
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000B1C RID: 2844
		public global::System.Windows.Forms.Button button3;

		// Token: 0x04000B1D RID: 2845
		private global::Guna.UI2.WinForms.Guna2Button guna2Button6;

		// Token: 0x04000B1E RID: 2846
		public global::System.Windows.Forms.Button button4;
	}
}
