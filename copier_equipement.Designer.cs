namespace GMAO
{
	// Token: 0x0200004F RID: 79
	public partial class copier_equipement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000382 RID: 898 RVA: 0x00092FE0 File Offset: 0x000911E0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00093018 File Offset: 0x00091218
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.copier_equipement));
			this.office2007SilverTheme1 = new global::Telerik.WinControls.Themes.Office2007SilverTheme();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.arbre_cloner = new global::Telerik.WinControls.UI.RadTreeView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2NumericUpDown1 = new global::Guna.UI2.WinForms.Guna2NumericUpDown();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.arbre_cloner.BeginInit();
			this.arbre.BeginInit();
			this.guna2NumericUpDown1.BeginInit();
			base.SuspendLayout();
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-approuver-et-mettre-à-jour-96.png");
			this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-background-LmdRuXFWPTk.png");
			this.arbre_cloner.BackColor = global::System.Drawing.Color.White;
			this.arbre_cloner.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre_cloner.EnableKineticScrolling = true;
			this.arbre_cloner.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre_cloner.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre_cloner.ImageList = this.imageList1;
			this.arbre_cloner.ItemHeight = 36;
			this.arbre_cloner.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre_cloner.LineStyle = 0;
			this.arbre_cloner.Location = new global::System.Drawing.Point(12, 39);
			this.arbre_cloner.Name = "arbre_cloner";
			this.arbre_cloner.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre_cloner.Size = new global::System.Drawing.Size(379, 443);
			this.arbre_cloner.SpacingBetweenNodes = -1;
			this.arbre_cloner.TabIndex = 3;
			this.arbre_cloner.ThemeName = "Office2010Silver";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre_cloner.GetChildAt(0)).NodeSpacing = -1;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(151, 19);
			this.label1.TabIndex = 12;
			this.label1.Text = "Equipement à copier";
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ImageList = this.imageList1;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(410, 39);
			this.arbre.Name = "arbre";
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.Size = new global::System.Drawing.Size(379, 443);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 13;
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
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.DimGray;
			this.label2.Location = new global::System.Drawing.Point(406, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(117, 19);
			this.label2.TabIndex = 14;
			this.label2.Text = "Nbre des copies";
			this.guna2NumericUpDown1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2NumericUpDown1.BorderRadius = 3;
			this.guna2NumericUpDown1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.guna2NumericUpDown1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.guna2NumericUpDown1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.guna2NumericUpDown1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.guna2NumericUpDown1.DisabledState.Parent = this.guna2NumericUpDown1;
			this.guna2NumericUpDown1.DisabledState.UpDownButtonFillColor = global::System.Drawing.Color.FromArgb(177, 177, 177);
			this.guna2NumericUpDown1.DisabledState.UpDownButtonForeColor = global::System.Drawing.Color.FromArgb(203, 203, 203);
			this.guna2NumericUpDown1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.guna2NumericUpDown1.FocusedState.Parent = this.guna2NumericUpDown1;
			this.guna2NumericUpDown1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.guna2NumericUpDown1.ForeColor = global::System.Drawing.Color.FromArgb(126, 137, 149);
			this.guna2NumericUpDown1.Location = new global::System.Drawing.Point(529, 4);
			global::Guna.UI2.WinForms.Suite.NumericUpDown numericUpDown = this.guna2NumericUpDown1;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Maximum = new decimal(array);
			this.guna2NumericUpDown1.Name = "guna2NumericUpDown1";
			this.guna2NumericUpDown1.ShadowDecoration.Parent = this.guna2NumericUpDown1;
			this.guna2NumericUpDown1.Size = new global::System.Drawing.Size(100, 29);
			this.guna2NumericUpDown1.TabIndex = 15;
			this.guna2NumericUpDown1.UpDownButtonFillColor = global::System.Drawing.Color.Firebrick;
			this.guna2NumericUpDown1.UpDownButtonForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(685, 3);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 30);
			this.guna2Button1.TabIndex = 18;
			this.guna2Button1.Text = "Coller";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(878, 504);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.guna2NumericUpDown1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.arbre);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.arbre_cloner);
			base.Name = "copier_equipement";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.copier_equipement_Load);
			this.arbre_cloner.EndInit();
			this.arbre.EndInit();
			this.guna2NumericUpDown1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040004B7 RID: 1207
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040004B8 RID: 1208
		private global::Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;

		// Token: 0x040004B9 RID: 1209
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040004BA RID: 1210
		private global::Telerik.WinControls.UI.RadTreeView arbre_cloner;

		// Token: 0x040004BB RID: 1211
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040004BC RID: 1212
		private global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x040004BD RID: 1213
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040004BE RID: 1214
		private global::Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown1;

		// Token: 0x040004BF RID: 1215
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;
	}
}
