namespace GMAO
{
	// Token: 0x02000070 RID: 112
	public partial class equipement_bsm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000542 RID: 1346 RVA: 0x000DFBD4 File Offset: 0x000DDDD4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000DFC0C File Offset: 0x000DDE0C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.equipement_bsm));
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			this.arbre.BeginInit();
			base.SuspendLayout();
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ImageList = this.imageList1;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(12, 45);
			this.arbre.Name = "arbre";
			this.arbre.RadContextMenu = this.radContextMenu1;
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.ShowNodeToolTips = true;
			this.arbre.Size = new global::System.Drawing.Size(469, 474);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 3;
			this.arbre.ThemeName = "Office2010Silver";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).NodeSpacing = -1;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "image1.png");
			this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-background-LmdRuXFWPTk.png");
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Choisir";
			this.guna2TextBox1.BorderRadius = 15;
			this.guna2TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2TextBox1.DefaultText = "";
			this.guna2TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.guna2TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Location = new global::System.Drawing.Point(12, 7);
			this.guna2TextBox1.Margin = new global::System.Windows.Forms.Padding(3, 4, 3, 4);
			this.guna2TextBox1.Name = "guna2TextBox1";
			this.guna2TextBox1.PasswordChar = '\0';
			this.guna2TextBox1.PlaceholderText = "Recherche";
			this.guna2TextBox1.SelectedText = "";
			this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
			this.guna2TextBox1.Size = new global::System.Drawing.Size(229, 31);
			this.guna2TextBox1.TabIndex = 4;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(531, 536);
			base.Controls.Add(this.guna2TextBox1);
			base.Controls.Add(this.arbre);
			base.Name = "equipement_bsm";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.equipement_bsm_Load);
			this.arbre.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400070D RID: 1805
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400070E RID: 1806
		public global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x0400070F RID: 1807
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x04000710 RID: 1808
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000711 RID: 1809
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000712 RID: 1810
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000713 RID: 1811
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04000714 RID: 1812
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;
	}
}
