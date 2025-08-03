namespace GMAO
{
	// Token: 0x02000136 RID: 310
	public partial class fournisseur_adresse : global::System.Windows.Forms.Form
	{
		// Token: 0x06000DF4 RID: 3572 RVA: 0x0021F244 File Offset: 0x0021D444
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x0021F27C File Offset: 0x0021D47C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.fournisseur_adresse));
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.label2 = new global::System.Windows.Forms.Label();
			global::GMAO.fournisseur_adresse.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			global::GMAO.fournisseur_adresse.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			global::GMAO.fournisseur_adresse.TextBox3 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			global::GMAO.fournisseur_adresse.TextBox2 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			global::GMAO.fournisseur_adresse.imageList2 = new global::System.Windows.Forms.ImageList(this.components);
			global::GMAO.fournisseur_adresse.radDropDownList1 = new global::Telerik.WinControls.UI.RadDropDownList();
			global::GMAO.fournisseur_adresse.radDropDownList1.BeginInit();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.Black;
			this.label2.Location = new global::System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(39, 19);
			this.label2.TabIndex = 52;
			this.label2.Text = "Pays";
			global::GMAO.fournisseur_adresse.imageList1.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth8Bit;
			global::GMAO.fournisseur_adresse.imageList1.ImageSize = new global::System.Drawing.Size(16, 16);
			global::GMAO.fournisseur_adresse.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			global::GMAO.fournisseur_adresse.TextBox1.BorderRadius = 2;
			global::GMAO.fournisseur_adresse.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			global::GMAO.fournisseur_adresse.TextBox1.DefaultText = "";
			global::GMAO.fournisseur_adresse.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			global::GMAO.fournisseur_adresse.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			global::GMAO.fournisseur_adresse.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.fournisseur_adresse.TextBox1.DisabledState.Parent = global::GMAO.fournisseur_adresse.TextBox1;
			global::GMAO.fournisseur_adresse.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.fournisseur_adresse.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.fournisseur_adresse.TextBox1.FocusedState.Parent = global::GMAO.fournisseur_adresse.TextBox1;
			global::GMAO.fournisseur_adresse.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			global::GMAO.fournisseur_adresse.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.fournisseur_adresse.TextBox1.HoverState.Parent = global::GMAO.fournisseur_adresse.TextBox1;
			global::GMAO.fournisseur_adresse.TextBox1.Location = new global::System.Drawing.Point(16, 87);
			global::GMAO.fournisseur_adresse.TextBox1.Name = "TextBox1";
			global::GMAO.fournisseur_adresse.TextBox1.PasswordChar = '\0';
			global::GMAO.fournisseur_adresse.TextBox1.PlaceholderText = "";
			global::GMAO.fournisseur_adresse.TextBox1.SelectedText = "";
			global::GMAO.fournisseur_adresse.TextBox1.ShadowDecoration.Parent = global::GMAO.fournisseur_adresse.TextBox1;
			global::GMAO.fournisseur_adresse.TextBox1.Size = new global::System.Drawing.Size(267, 29);
			global::GMAO.fournisseur_adresse.TextBox1.TabIndex = 55;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(12, 65);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(38, 19);
			this.label10.TabIndex = 54;
			this.label10.Text = "Ville";
			global::GMAO.fournisseur_adresse.TextBox3.BorderRadius = 2;
			global::GMAO.fournisseur_adresse.TextBox3.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			global::GMAO.fournisseur_adresse.TextBox3.DefaultText = "";
			global::GMAO.fournisseur_adresse.TextBox3.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			global::GMAO.fournisseur_adresse.TextBox3.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			global::GMAO.fournisseur_adresse.TextBox3.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.fournisseur_adresse.TextBox3.DisabledState.Parent = global::GMAO.fournisseur_adresse.TextBox3;
			global::GMAO.fournisseur_adresse.TextBox3.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.fournisseur_adresse.TextBox3.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.fournisseur_adresse.TextBox3.FocusedState.Parent = global::GMAO.fournisseur_adresse.TextBox3;
			global::GMAO.fournisseur_adresse.TextBox3.Font = new global::System.Drawing.Font("Calibri", 9f);
			global::GMAO.fournisseur_adresse.TextBox3.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.fournisseur_adresse.TextBox3.HoverState.Parent = global::GMAO.fournisseur_adresse.TextBox3;
			global::GMAO.fournisseur_adresse.TextBox3.Location = new global::System.Drawing.Point(16, 211);
			global::GMAO.fournisseur_adresse.TextBox3.Name = "TextBox3";
			global::GMAO.fournisseur_adresse.TextBox3.PasswordChar = '\0';
			global::GMAO.fournisseur_adresse.TextBox3.PlaceholderText = "";
			global::GMAO.fournisseur_adresse.TextBox3.SelectedText = "";
			global::GMAO.fournisseur_adresse.TextBox3.ShadowDecoration.Parent = global::GMAO.fournisseur_adresse.TextBox3;
			global::GMAO.fournisseur_adresse.TextBox3.Size = new global::System.Drawing.Size(479, 29);
			global::GMAO.fournisseur_adresse.TextBox3.TabIndex = 57;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 189);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 19);
			this.label1.TabIndex = 56;
			this.label1.Text = "Adresse";
			global::GMAO.fournisseur_adresse.TextBox2.BorderRadius = 2;
			global::GMAO.fournisseur_adresse.TextBox2.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			global::GMAO.fournisseur_adresse.TextBox2.DefaultText = "";
			global::GMAO.fournisseur_adresse.TextBox2.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			global::GMAO.fournisseur_adresse.TextBox2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			global::GMAO.fournisseur_adresse.TextBox2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.fournisseur_adresse.TextBox2.DisabledState.Parent = global::GMAO.fournisseur_adresse.TextBox2;
			global::GMAO.fournisseur_adresse.TextBox2.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			global::GMAO.fournisseur_adresse.TextBox2.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.fournisseur_adresse.TextBox2.FocusedState.Parent = global::GMAO.fournisseur_adresse.TextBox2;
			global::GMAO.fournisseur_adresse.TextBox2.Font = new global::System.Drawing.Font("Calibri", 9f);
			global::GMAO.fournisseur_adresse.TextBox2.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			global::GMAO.fournisseur_adresse.TextBox2.HoverState.Parent = global::GMAO.fournisseur_adresse.TextBox2;
			global::GMAO.fournisseur_adresse.TextBox2.Location = new global::System.Drawing.Point(17, 150);
			global::GMAO.fournisseur_adresse.TextBox2.Name = "TextBox2";
			global::GMAO.fournisseur_adresse.TextBox2.PasswordChar = '\0';
			global::GMAO.fournisseur_adresse.TextBox2.PlaceholderText = "";
			global::GMAO.fournisseur_adresse.TextBox2.SelectedText = "";
			global::GMAO.fournisseur_adresse.TextBox2.ShadowDecoration.Parent = global::GMAO.fournisseur_adresse.TextBox2;
			global::GMAO.fournisseur_adresse.TextBox2.Size = new global::System.Drawing.Size(267, 29);
			global::GMAO.fournisseur_adresse.TextBox2.TabIndex = 59;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(13, 128);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(86, 19);
			this.label3.TabIndex = 58;
			this.label3.Text = "Code Postal";
			global::GMAO.fournisseur_adresse.imageList2.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList2.ImageStream");
			global::GMAO.fournisseur_adresse.imageList2.TransparentColor = global::System.Drawing.Color.Transparent;
			global::GMAO.fournisseur_adresse.imageList2.Images.SetKeyName(0, "tunisie.png");
			global::GMAO.fournisseur_adresse.imageList2.Images.SetKeyName(1, "algerie.png");
			global::GMAO.fournisseur_adresse.imageList2.Images.SetKeyName(2, "maroc.png");
			global::GMAO.fournisseur_adresse.imageList2.Images.SetKeyName(3, "egypte.png");
			global::GMAO.fournisseur_adresse.imageList2.Images.SetKeyName(4, "arabia saudi.png");
			global::GMAO.fournisseur_adresse.imageList2.Images.SetKeyName(5, "libya.png");
			global::GMAO.fournisseur_adresse.radDropDownList1.DropDownAnimationEasing = 2;
			global::GMAO.fournisseur_adresse.radDropDownList1.DropDownStyle = 2;
			global::GMAO.fournisseur_adresse.radDropDownList1.Location = new global::System.Drawing.Point(16, 31);
			global::GMAO.fournisseur_adresse.radDropDownList1.Name = "radDropDownList1";
			global::GMAO.fournisseur_adresse.radDropDownList1.Size = new global::System.Drawing.Size(267, 24);
			global::GMAO.fournisseur_adresse.radDropDownList1.TabIndex = 60;
			global::GMAO.fournisseur_adresse.radDropDownList1.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)global::GMAO.fournisseur_adresse.radDropDownList1.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(507, 485);
			base.Controls.Add(global::GMAO.fournisseur_adresse.radDropDownList1);
			base.Controls.Add(global::GMAO.fournisseur_adresse.TextBox2);
			base.Controls.Add(this.label3);
			base.Controls.Add(global::GMAO.fournisseur_adresse.TextBox3);
			base.Controls.Add(this.label1);
			base.Controls.Add(global::GMAO.fournisseur_adresse.TextBox1);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fournisseur_adresse";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.fournisseur_adresse_Load);
			global::GMAO.fournisseur_adresse.radDropDownList1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040011A8 RID: 4520
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040011A9 RID: 4521
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x040011AA RID: 4522
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040011AB RID: 4523
		private static global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040011AC RID: 4524
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040011AD RID: 4525
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040011AE RID: 4526
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040011AF RID: 4527
		public static global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x040011B0 RID: 4528
		public static global::Guna.UI2.WinForms.Guna2TextBox TextBox3;

		// Token: 0x040011B1 RID: 4529
		public static global::Guna.UI2.WinForms.Guna2TextBox TextBox2;

		// Token: 0x040011B2 RID: 4530
		private static global::System.Windows.Forms.ImageList imageList2;

		// Token: 0x040011B3 RID: 4531
		public static global::Telerik.WinControls.UI.RadDropDownList radDropDownList1;
	}
}
