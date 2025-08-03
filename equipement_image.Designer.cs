namespace GMAO
{
	// Token: 0x0200012E RID: 302
	public partial class equipement_image : global::System.Windows.Forms.Form
	{
		// Token: 0x06000D56 RID: 3414 RVA: 0x0020705C File Offset: 0x0020525C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x00207094 File Offset: 0x00205294
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.equipement_image));
			this.label26 = new global::System.Windows.Forms.Label();
			this.PictureBox6 = new global::System.Windows.Forms.PictureBox();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.PictureBox8 = new global::System.Windows.Forms.PictureBox();
			this.PictureBox7 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox6).BeginInit();
			this.radPanel1.BeginInit();
			this.radPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox7).BeginInit();
			base.SuspendLayout();
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.ForeColor = global::System.Drawing.Color.Black;
			this.label26.Location = new global::System.Drawing.Point(4, 4);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(90, 19);
			this.label26.TabIndex = 63;
			this.label26.Text = "Joints image";
			this.PictureBox6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox6.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox6.Image");
			this.PictureBox6.Location = new global::System.Drawing.Point(94, 4);
			this.PictureBox6.Name = "PictureBox6";
			this.PictureBox6.Size = new global::System.Drawing.Size(48, 28);
			this.PictureBox6.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox6.TabIndex = 64;
			this.PictureBox6.TabStop = false;
			this.PictureBox6.Click += new global::System.EventHandler(this.PictureBox6_Click);
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Controls.Add(this.PictureBox8);
			this.radPanel1.Controls.Add(this.PictureBox7);
			this.radPanel1.Location = new global::System.Drawing.Point(4, 35);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(634, 332);
			this.radPanel1.TabIndex = 65;
			this.PictureBox8.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox8.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox8.Image");
			this.PictureBox8.Location = new global::System.Drawing.Point(298, 2);
			this.PictureBox8.Name = "PictureBox8";
			this.PictureBox8.Size = new global::System.Drawing.Size(13, 12);
			this.PictureBox8.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox8.TabIndex = 65;
			this.PictureBox8.TabStop = false;
			this.PictureBox7.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox7.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox7.Image");
			this.PictureBox7.Location = new global::System.Drawing.Point(4, 2);
			this.PictureBox7.Name = "PictureBox7";
			this.PictureBox7.Size = new global::System.Drawing.Size(291, 302);
			this.PictureBox7.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox7.TabIndex = 64;
			this.PictureBox7.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(650, 369);
			base.Controls.Add(this.radPanel1);
			base.Controls.Add(this.PictureBox6);
			base.Controls.Add(this.label26);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "equipement_image";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.equipement_image_Load);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox6).EndInit();
			this.radPanel1.EndInit();
			this.radPanel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox7).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040010FE RID: 4350
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040010FF RID: 4351
		private global::System.Windows.Forms.Label label26;

		// Token: 0x04001100 RID: 4352
		internal global::System.Windows.Forms.PictureBox PictureBox6;

		// Token: 0x04001101 RID: 4353
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x04001102 RID: 4354
		internal global::System.Windows.Forms.PictureBox PictureBox8;

		// Token: 0x04001103 RID: 4355
		internal global::System.Windows.Forms.PictureBox PictureBox7;
	}
}
