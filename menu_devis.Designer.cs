namespace GMAO
{
	// Token: 0x02000142 RID: 322
	public partial class menu_devis : global::System.Windows.Forms.Form
	{
		// Token: 0x06000E6F RID: 3695 RVA: 0x0023136C File Offset: 0x0022F56C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x002313A4 File Offset: 0x0022F5A4
		private void InitializeComponent()
		{
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button7 = new global::System.Windows.Forms.Button();
			this.button6 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel2.Controls.Add(this.button3);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button7);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1148, 25);
			this.panel2.TabIndex = 9;
			this.button5.BackColor = global::System.Drawing.Color.Firebrick;
			this.button5.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button5.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button5.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button5.ForeColor = global::System.Drawing.Color.White;
			this.button5.Location = new global::System.Drawing.Point(813, 0);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(164, 25);
			this.button5.TabIndex = 9;
			this.button5.Text = "Demande offre de prix annulé";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button4.BackColor = global::System.Drawing.Color.Firebrick;
			this.button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button4.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button4.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(649, 0);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(164, 25);
			this.button4.TabIndex = 8;
			this.button4.Text = "Historique Tableau comparatif";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button7.BackColor = global::System.Drawing.Color.Firebrick;
			this.button7.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button7.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button7.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button7.ForeColor = global::System.Drawing.Color.White;
			this.button7.Location = new global::System.Drawing.Point(465, 0);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(184, 25);
			this.button7.TabIndex = 7;
			this.button7.Text = "Historique demande offre de prix";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new global::System.EventHandler(this.button7_Click);
			this.button6.BackColor = global::System.Drawing.Color.Firebrick;
			this.button6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button6.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button6.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button6.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button6.ForeColor = global::System.Drawing.Color.White;
			this.button6.Location = new global::System.Drawing.Point(324, 0);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(141, 25);
			this.button6.TabIndex = 6;
			this.button6.Text = "Tableau comparatif";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
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
			this.button2.Text = "Liste demande offre de prix";
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
			this.button1.Text = "Créer demande offre de prix";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button3.BackColor = global::System.Drawing.Color.Firebrick;
			this.button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button3.Font = new global::System.Drawing.Font("Calibri", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(977, 0);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(137, 25);
			this.button3.TabIndex = 10;
			this.button3.Text = "Devis sous traitant";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1148, 25);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "menu_devis";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.menu_devis_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04001226 RID: 4646
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04001227 RID: 4647
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04001228 RID: 4648
		public global::System.Windows.Forms.Button button7;

		// Token: 0x04001229 RID: 4649
		public global::System.Windows.Forms.Button button6;

		// Token: 0x0400122A RID: 4650
		public global::System.Windows.Forms.Button button2;

		// Token: 0x0400122B RID: 4651
		public global::System.Windows.Forms.Button button1;

		// Token: 0x0400122C RID: 4652
		public global::System.Windows.Forms.Button button4;

		// Token: 0x0400122D RID: 4653
		public global::System.Windows.Forms.Button button5;

		// Token: 0x0400122E RID: 4654
		public global::System.Windows.Forms.Button button3;
	}
}
