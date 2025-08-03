namespace GMAO
{
	// Token: 0x02000145 RID: 325
	public partial class menu_reception : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E84 RID: 3716 RVA: 0x00232C34 File Offset: 0x00230E34
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x00232C6C File Offset: 0x00230E6C
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 9;
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
			this.button2.Text = "Liste des réceptions";
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
			this.button1.Text = "Créer un bon de réception";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1148, 25);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "menu_reception";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.menu_reception_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400123A RID: 4666
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400123B RID: 4667
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400123C RID: 4668
		public global::System.Windows.Forms.Button button2;

		// Token: 0x0400123D RID: 4669
		public global::System.Windows.Forms.Button button1;
	}
}
