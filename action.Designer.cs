namespace GMAO
{
	// Token: 0x02000006 RID: 6
	public partial class action : global::System.Windows.Forms.Form
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00009F74 File Offset: 0x00008174
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00009FAC File Offset: 0x000081AC
		private void InitializeComponent()
		{
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(2, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(899, 29);
			this.panel4.TabIndex = 77;
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(113, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(138, 29);
			this.button1.TabIndex = 73;
			this.button1.Text = "Liste";
			this.button1.UseVisualStyleBackColor = false;
			this.button2.BackColor = global::System.Drawing.Color.Gray;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(0, 0);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(113, 29);
			this.button2.TabIndex = 72;
			this.button2.Text = "Ajouter";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel1.Location = new global::System.Drawing.Point(2, 37);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1090, 435);
			this.panel1.TabIndex = 78;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1104, 501);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "action";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.action_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000033 RID: 51
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000034 RID: 52
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000035 RID: 53
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000037 RID: 55
		public global::System.Windows.Forms.Button button1;

		// Token: 0x04000038 RID: 56
		public global::System.Windows.Forms.Button button2;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Panel panel1;
	}
}
