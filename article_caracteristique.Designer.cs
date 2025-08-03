namespace GMAO
{
	// Token: 0x0200001F RID: 31
	public partial class article_caracteristique : global::System.Windows.Forms.Form
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x0004A250 File Offset: 0x00048450
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0004A288 File Offset: 0x00048488
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.article_caracteristique));
			global::GMAO.article_caracteristique.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			global::GMAO.article_caracteristique.radPanel1.BeginInit();
			base.SuspendLayout();
			global::GMAO.article_caracteristique.radPanel1.AutoScroll = true;
			global::GMAO.article_caracteristique.radPanel1.Location = new global::System.Drawing.Point(3, 25);
			global::GMAO.article_caracteristique.radPanel1.Name = "radPanel1";
			global::GMAO.article_caracteristique.radPanel1.Size = new global::System.Drawing.Size(1076, 104);
			global::GMAO.article_caracteristique.radPanel1.TabIndex = 66;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(998, 2);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(81, 21);
			this.guna2Button1.TabIndex = 156;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-supprimer-pour-toujours-100.png");
			this.imageList1.Images.SetKeyName(1, "icons8-approuver-et-mettre-à-jour-96 (1).png");
			this.imageList1.Images.SetKeyName(2, "imgonline-com-ua-Transparent-background-mY80EJnxkjzbk (1).ico");
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(global::GMAO.article_caracteristique.radPanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "article_caracteristique";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.article_caracteristique_Load);
			global::GMAO.article_caracteristique.radPanel1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400027B RID: 635
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x0400027D RID: 637
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x0400027E RID: 638
		private static global::Telerik.WinControls.UI.RadPanel radPanel1;
	}
}
