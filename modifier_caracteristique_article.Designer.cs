namespace GMAO
{
	// Token: 0x02000099 RID: 153
	public partial class modifier_caracteristique_article : global::System.Windows.Forms.Form
	{
		// Token: 0x060006FE RID: 1790 RVA: 0x00132BCC File Offset: 0x00130DCC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00132C04 File Offset: 0x00130E04
		private void InitializeComponent()
		{
			this.radPanel1 = new global::Telerik.WinControls.UI.RadPanel();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radPanel1.BeginInit();
			base.SuspendLayout();
			this.radPanel1.AutoScroll = true;
			this.radPanel1.Location = new global::System.Drawing.Point(12, 50);
			this.radPanel1.Name = "radPanel1";
			this.radPanel1.Size = new global::System.Drawing.Size(776, 249);
			this.radPanel1.TabIndex = 147;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radPanel1.GetChildAt(0).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(673, 17);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(115, 28);
			this.guna2Button1.TabIndex = 156;
			this.guna2Button1.Text = "Enregistrer";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(800, 321);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radPanel1);
			base.Name = "modifier_caracteristique_article";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.modifier_caracteristique_article_Load);
			this.radPanel1.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000972 RID: 2418
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000973 RID: 2419
		private global::Telerik.WinControls.UI.RadPanel radPanel1;

		// Token: 0x04000974 RID: 2420
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000975 RID: 2421
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
	}
}
