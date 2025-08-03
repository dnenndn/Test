namespace GMAO
{
	// Token: 0x02000023 RID: 35
	public partial class article_image : global::System.Windows.Forms.Form
	{
		// Token: 0x060001DA RID: 474 RVA: 0x0004E528 File Offset: 0x0004C728
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0004E560 File Offset: 0x0004C760
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.article_image));
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(2, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(271, 124);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(277, 105);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(32, 22);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 87;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "article_image";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.article_image_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040002A1 RID: 673
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002A2 RID: 674
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.PictureBox pictureBox2;
	}
}
