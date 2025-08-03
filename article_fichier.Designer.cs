namespace GMAO
{
	// Token: 0x02000152 RID: 338
	public partial class article_fichier : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F19 RID: 3865 RVA: 0x00247408 File Offset: 0x00245608
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00247440 File Offset: 0x00245640
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.article_fichier));
			this.PictureBox6 = new global::System.Windows.Forms.PictureBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.PictureBox8 = new global::System.Windows.Forms.PictureBox();
			this.PictureBox7 = new global::System.Windows.Forms.PictureBox();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox6).BeginInit();
			this.radPanel1.BeginInit();
			this.radPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox7).BeginInit();
			base.SuspendLayout();
			this.PictureBox6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox6.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox6.Image");
			this.PictureBox6.Location = new global::System.Drawing.Point(54, 3);
			this.PictureBox6.Name = "PictureBox6";
			this.PictureBox6.Size = new global::System.Drawing.Size(48, 25);
			this.PictureBox6.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox6.TabIndex = 66;
			this.PictureBox6.TabStop = false;
			this.PictureBox6.Click += new global::System.EventHandler(this.PictureBox6_Click);
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.ForeColor = global::System.Drawing.Color.Black;
			this.label26.Location = new global::System.Drawing.Point(7, 1);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(46, 19);
			this.label26.TabIndex = 67;
			this.label26.Text = "Joints";
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Controls.Add(this.PictureBox8);
			this.radPanel1.Controls.Add(this.PictureBox7);
			this.radPanel1.Location = new global::System.Drawing.Point(12, 32);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(977, 97);
			this.radPanel1.TabIndex = 65;
			this.PictureBox8.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox8.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox8.Image");
			this.PictureBox8.Location = new global::System.Drawing.Point(52, 2);
			this.PictureBox8.Name = "PictureBox8";
			this.PictureBox8.Size = new global::System.Drawing.Size(13, 12);
			this.PictureBox8.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox8.TabIndex = 65;
			this.PictureBox8.TabStop = false;
			this.PictureBox7.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox7.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox7.Image");
			this.PictureBox7.Location = new global::System.Drawing.Point(4, 2);
			this.PictureBox7.Name = "PictureBox7";
			this.PictureBox7.Size = new global::System.Drawing.Size(48, 20);
			this.PictureBox7.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox7.TabIndex = 64;
			this.PictureBox7.TabStop = false;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100.png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (1).png");
			this.imageList1.Images.SetKeyName(2, "icons8-word-96.png");
			this.imageList1.Images.SetKeyName(3, "icons8-ms-excel-104.png");
			this.imageList1.Images.SetKeyName(4, "icons8-pdf-40.png");
			this.imageList1.Images.SetKeyName(5, "icons8-txt-80.png");
			this.imageList1.Images.SetKeyName(6, "icons8-winrar-240.png");
			this.imageList1.Images.SetKeyName(7, "icons8-image-96.png");
			this.imageList1.Images.SetKeyName(8, "icons8-autodesk-autocad-144.png");
			this.imageList1.Images.SetKeyName(9, "icons8-fichier-128.png");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.PictureBox6);
			base.Controls.Add(this.label26);
			base.Controls.Add(this.radPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "article_fichier";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.article_fichier_Load);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox6).EndInit();
			this.radPanel1.EndInit();
			this.radPanel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox7).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040012FA RID: 4858
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040012FB RID: 4859
		internal global::System.Windows.Forms.PictureBox PictureBox6;

		// Token: 0x040012FC RID: 4860
		private global::System.Windows.Forms.Label label26;

		// Token: 0x040012FD RID: 4861
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x040012FE RID: 4862
		internal global::System.Windows.Forms.PictureBox PictureBox8;

		// Token: 0x040012FF RID: 4863
		internal global::System.Windows.Forms.PictureBox PictureBox7;

		// Token: 0x04001300 RID: 4864
		private global::System.Windows.Forms.ImageList imageList1;
	}
}
