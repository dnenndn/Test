namespace GMAO
{
	// Token: 0x02000072 RID: 114
	public partial class Equipement_di : global::System.Windows.Forms.Form
	{
		// Token: 0x0600055A RID: 1370 RVA: 0x000E1E60 File Offset: 0x000E0060
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000E1E98 File Offset: 0x000E0098
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.Equipement_di));
			this.guna2TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem2 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem3 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem4 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem5 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.office2010SilverTheme1 = new global::Telerik.WinControls.Themes.Office2010SilverTheme();
			this.aquaTheme1 = new global::Telerik.WinControls.Themes.AquaTheme();
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.arbre.BeginInit();
			base.SuspendLayout();
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
			this.guna2TextBox1.TabIndex = 5;
			this.guna2TextBox1.TextChanged += new global::System.EventHandler(this.guna2TextBox1_TextChanged);
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "image1.png");
			this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-background-LmdRuXFWPTk.png");
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1,
				this.radMenuItem2,
				this.radMenuItem3,
				this.radMenuItem4,
				this.radMenuItem5
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Atelier";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "Equipement";
			this.radMenuItem3.Name = "radMenuItem3";
			this.radMenuItem3.Text = "Sous Equipement";
			this.radMenuItem4.Name = "radMenuItem4";
			this.radMenuItem4.Text = "Organe";
			this.radMenuItem5.Name = "radMenuItem5";
			this.radMenuItem5.Text = "Choisir";
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ImageList = this.imageList1;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(12, 43);
			this.arbre.Name = "arbre";
			this.arbre.RadContextMenu = this.radContextMenu1;
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.ShowNodeToolTips = true;
			this.arbre.Size = new global::System.Drawing.Size(469, 474);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 6;
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
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(531, 536);
			base.Controls.Add(this.arbre);
			base.Controls.Add(this.guna2TextBox1);
			base.Name = "Equipement_di";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.Equipement_di_Load);
			this.arbre.EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400071D RID: 1821
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400071E RID: 1822
		private global::Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;

		// Token: 0x0400071F RID: 1823
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000720 RID: 1824
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000721 RID: 1825
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000722 RID: 1826
		private global::Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;

		// Token: 0x04000723 RID: 1827
		private global::Telerik.WinControls.Themes.AquaTheme aquaTheme1;

		// Token: 0x04000724 RID: 1828
		public global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x04000725 RID: 1829
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem2;

		// Token: 0x04000726 RID: 1830
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem3;

		// Token: 0x04000727 RID: 1831
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem4;

		// Token: 0x04000728 RID: 1832
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem5;
	}
}
