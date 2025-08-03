namespace GMAO
{
	// Token: 0x020000F3 RID: 243
	public partial class parametre_photo : global::System.Windows.Forms.Form
	{
		// Token: 0x06000A8B RID: 2699 RVA: 0x0019F104 File Offset: 0x0019D304
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0019F13C File Offset: 0x0019D33C
		private void InitializeComponent()
		{
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.guna2Button3 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button4 = new global::Guna.UI2.WinForms.Guna2Button();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			base.SuspendLayout();
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(12, 12);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 92;
			this.guna2Button1.Text = "Joindre Usine";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.pictureBox1.Location = new global::System.Drawing.Point(16, 48);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(388, 295);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 93;
			this.pictureBox1.TabStop = false;
			this.pictureBox2.Location = new global::System.Drawing.Point(414, 48);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(326, 295);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 95;
			this.pictureBox2.TabStop = false;
			this.guna2Button2.BorderRadius = 8;
			this.guna2Button2.CheckedState.Parent = this.guna2Button2;
			this.guna2Button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button2.CustomImages.Parent = this.guna2Button2;
			this.guna2Button2.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.HoverState.Parent = this.guna2Button2;
			this.guna2Button2.Location = new global::System.Drawing.Point(410, 12);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
			this.guna2Button2.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button2.TabIndex = 94;
			this.guna2Button2.Text = "Joindre Parc";
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.pictureBox3.Location = new global::System.Drawing.Point(750, 48);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(388, 295);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 97;
			this.pictureBox3.TabStop = false;
			this.guna2Button3.BorderRadius = 8;
			this.guna2Button3.CheckedState.Parent = this.guna2Button3;
			this.guna2Button3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button3.CustomImages.Parent = this.guna2Button3;
			this.guna2Button3.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button3.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button3.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button3.HoverState.Parent = this.guna2Button3;
			this.guna2Button3.Location = new global::System.Drawing.Point(746, 12);
			this.guna2Button3.Name = "guna2Button3";
			this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
			this.guna2Button3.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button3.TabIndex = 96;
			this.guna2Button3.Text = "Joindre Atelier";
			this.guna2Button3.Click += new global::System.EventHandler(this.guna2Button3_Click);
			this.guna2Button4.BorderRadius = 8;
			this.guna2Button4.CheckedState.Parent = this.guna2Button4;
			this.guna2Button4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button4.CustomImages.Parent = this.guna2Button4;
			this.guna2Button4.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button4.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button4.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button4.HoverState.Parent = this.guna2Button4;
			this.guna2Button4.Location = new global::System.Drawing.Point(16, 376);
			this.guna2Button4.Name = "guna2Button4";
			this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
			this.guna2Button4.Size = new global::System.Drawing.Size(230, 30);
			this.guna2Button4.TabIndex = 98;
			this.guna2Button4.Text = "Enregistrer Modification";
			this.guna2Button4.Click += new global::System.EventHandler(this.guna2Button4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1147, 612);
			base.Controls.Add(this.guna2Button4);
			base.Controls.Add(this.pictureBox3);
			base.Controls.Add(this.guna2Button3);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.guna2Button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "parametre_photo";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.parametre_photo_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000D89 RID: 3465
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D8A RID: 3466
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000D8B RID: 3467
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000D8C RID: 3468
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000D8D RID: 3469
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x04000D8E RID: 3470
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000D8F RID: 3471
		private global::Guna.UI2.WinForms.Guna2Button guna2Button3;

		// Token: 0x04000D90 RID: 3472
		private global::Guna.UI2.WinForms.Guna2Button guna2Button4;
	}
}
