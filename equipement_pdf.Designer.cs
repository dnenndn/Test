namespace GMAO
{
	// Token: 0x02000130 RID: 304
	public partial class equipement_pdf : global::System.Windows.Forms.Form
	{
		// Token: 0x06000D66 RID: 3430 RVA: 0x00208174 File Offset: 0x00206374
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x002081AC File Offset: 0x002063AC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.equipement_pdf));
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.PictureBox8 = new global::System.Windows.Forms.PictureBox();
			this.PictureBox7 = new global::System.Windows.Forms.PictureBox();
			this.label26 = new global::System.Windows.Forms.Label();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.PictureBox6 = new global::System.Windows.Forms.PictureBox();
			this.PictureBox10 = new global::System.Windows.Forms.PictureBox();
			this.radPanel1.BeginInit();
			this.radPanel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox7).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox10).BeginInit();
			base.SuspendLayout();
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Controls.Add(this.PictureBox8);
			this.radPanel1.Controls.Add(this.PictureBox7);
			this.radPanel1.Location = new global::System.Drawing.Point(4, 35);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(634, 104);
			this.radPanel1.TabIndex = 0;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
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
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.ForeColor = global::System.Drawing.Color.Black;
			this.label26.Location = new global::System.Drawing.Point(4, 4);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(75, 19);
			this.label26.TabIndex = 62;
			this.label26.Text = "Joints PDF";
			this.PictureBox6.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox6.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox6.Image");
			this.PictureBox6.Location = new global::System.Drawing.Point(76, 4);
			this.PictureBox6.Name = "PictureBox6";
			this.PictureBox6.Size = new global::System.Drawing.Size(48, 28);
			this.PictureBox6.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox6.TabIndex = 57;
			this.PictureBox6.TabStop = false;
			this.PictureBox6.Click += new global::System.EventHandler(this.PictureBox6_Click);
			this.PictureBox10.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.PictureBox10.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("PictureBox10.Image");
			this.PictureBox10.Location = new global::System.Drawing.Point(541, 2);
			this.PictureBox10.Name = "PictureBox10";
			this.PictureBox10.Size = new global::System.Drawing.Size(48, 30);
			this.PictureBox10.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox10.TabIndex = 64;
			this.PictureBox10.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(650, 369);
			base.Controls.Add(this.PictureBox10);
			base.Controls.Add(this.PictureBox6);
			base.Controls.Add(this.label26);
			base.Controls.Add(this.radPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "equipement_pdf";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.equipement_pdf_Load);
			this.radPanel1.EndInit();
			this.radPanel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox7).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox10).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001109 RID: 4361
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400110A RID: 4362
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x0400110B RID: 4363
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400110C RID: 4364
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x0400110D RID: 4365
		internal global::System.Windows.Forms.PictureBox PictureBox8;

		// Token: 0x0400110E RID: 4366
		internal global::System.Windows.Forms.PictureBox PictureBox7;

		// Token: 0x0400110F RID: 4367
		internal global::System.Windows.Forms.PictureBox PictureBox6;

		// Token: 0x04001110 RID: 4368
		internal global::System.Windows.Forms.PictureBox PictureBox10;
	}
}
