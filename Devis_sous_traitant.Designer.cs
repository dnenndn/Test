namespace GMAO
{
	// Token: 0x02000068 RID: 104
	public partial class Devis_sous_traitant : global::System.Windows.Forms.Form
	{
		// Token: 0x060004F9 RID: 1273 RVA: 0x000D5BDC File Offset: 0x000D3DDC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000D5C14 File Offset: 0x000D3E14
		private void InitializeComponent()
		{
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.Controls.Add(this.button1);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(899, 29);
			this.panel4.TabIndex = 72;
			this.button1.BackColor = global::System.Drawing.Color.Gray;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(113, 0);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(118, 29);
			this.button1.TabIndex = 73;
			this.button1.Text = "Historique Devis";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
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
			this.button2.Text = "Créer Devis";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.panel3.Location = new global::System.Drawing.Point(-10, 29);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1148, 10);
			this.panel3.TabIndex = 73;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.panel1.Location = new global::System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1104, 501);
			this.panel1.TabIndex = 74;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1128, 558);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Devis_sous_traitant";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.Devis_sous_traitant_Load);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000697 RID: 1687
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000698 RID: 1688
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000699 RID: 1689
		public global::System.Windows.Forms.Button button1;

		// Token: 0x0400069A RID: 1690
		public global::System.Windows.Forms.Button button2;

		// Token: 0x0400069B RID: 1691
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400069C RID: 1692
		private global::System.Windows.Forms.Panel panel1;
	}
}
