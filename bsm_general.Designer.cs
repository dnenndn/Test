namespace GMAO
{
	// Token: 0x02000033 RID: 51
	public partial class bsm_general : global::System.Windows.Forms.Form
	{
		// Token: 0x06000268 RID: 616 RVA: 0x000677B0 File Offset: 0x000659B0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000677E8 File Offset: 0x000659E8
		private void InitializeComponent()
		{
			this.label3 = new global::System.Windows.Forms.Label();
			this.radDateTimePicker1 = new global::Telerik.WinControls.UI.RadDateTimePicker();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::Guna.UI2.WinForms.Guna2TextBox();
			this.radTimePicker1 = new global::Telerik.WinControls.UI.RadTimePicker();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label18 = new global::System.Windows.Forms.Label();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radDateTimePicker1.BeginInit();
			this.radTimePicker1.BeginInit();
			this.radDropDownList6.BeginInit();
			base.SuspendLayout();
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Black;
			this.label3.Location = new global::System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(98, 19);
			this.label3.TabIndex = 185;
			this.label3.Text = "Date et heure";
			this.radDateTimePicker1.CalendarSize = new global::System.Drawing.Size(290, 320);
			this.radDateTimePicker1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radDateTimePicker1.ForeColor = global::System.Drawing.Color.DimGray;
			this.radDateTimePicker1.Format = global::System.Windows.Forms.DateTimePickerFormat.Short;
			this.radDateTimePicker1.Location = new global::System.Drawing.Point(16, 30);
			this.radDateTimePicker1.Name = "radDateTimePicker1";
			this.radDateTimePicker1.Size = new global::System.Drawing.Size(158, 27);
			this.radDateTimePicker1.TabIndex = 184;
			this.radDateTimePicker1.TabStop = false;
			this.radDateTimePicker1.Text = "10/02/2021";
			this.radDateTimePicker1.ThemeName = "Crystal";
			this.radDateTimePicker1.Value = new global::System.DateTime(2021, 2, 10, 16, 51, 18, 838);
			((global::Telerik.WinControls.UI.RadDateTimePickerElement)this.radDateTimePicker1.GetChildAt(0)).CalendarSize = new global::System.Drawing.Size(290, 320);
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Red;
			this.label14.Location = new global::System.Drawing.Point(525, 9);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(17, 19);
			this.label14.TabIndex = 183;
			this.label14.Text = "*";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(480, 9);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(47, 19);
			this.label10.TabIndex = 181;
			this.label10.Text = "N° OT";
			this.TextBox1.BorderRadius = 2;
			this.TextBox1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.TextBox1.DefaultText = "";
			this.TextBox1.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.TextBox1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.TextBox1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.DisabledState.Parent = this.TextBox1;
			this.TextBox1.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.TextBox1.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.FocusedState.Parent = this.TextBox1;
			this.TextBox1.Font = new global::System.Drawing.Font("Calibri", 9f);
			this.TextBox1.HoverState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.TextBox1.HoverState.Parent = this.TextBox1;
			this.TextBox1.Location = new global::System.Drawing.Point(481, 31);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.PasswordChar = '\0';
			this.TextBox1.PlaceholderText = "";
			this.TextBox1.SelectedText = "";
			this.TextBox1.ShadowDecoration.Parent = this.TextBox1;
			this.TextBox1.Size = new global::System.Drawing.Size(244, 24);
			this.TextBox1.TabIndex = 182;
			this.radTimePicker1.Location = new global::System.Drawing.Point(16, 63);
			this.radTimePicker1.MaxValue = new global::System.DateTime(9999, 12, 31, 23, 59, 59, 0);
			this.radTimePicker1.MinValue = new global::System.DateTime(0L);
			this.radTimePicker1.Name = "radTimePicker1";
			this.radTimePicker1.Size = new global::System.Drawing.Size(158, 24);
			this.radTimePicker1.TabIndex = 186;
			this.radTimePicker1.TabStop = false;
			this.radTimePicker1.ThemeName = "Crystal";
			this.radTimePicker1.Value = new global::System.DateTime?(new global::System.DateTime(2021, 5, 18, 23, 1, 27, 720));
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BorderColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).NumberOfColors = 1;
			((global::Telerik.WinControls.UI.StackLayoutElement)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.UI.RadTimeElementUpButton)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(0).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.None;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.ArrowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(2)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.OverflowPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(3)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.ImagePrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(4)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).LineLimit = false;
			((global::Telerik.WinControls.Primitives.TextPrimitive)this.radTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(2).GetChildAt(1).GetChildAt(5)).BackColor = global::System.Drawing.Color.Firebrick;
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(199, 31);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList6.TabIndex = 188;
			this.radDropDownList6.ThemeName = "Crystal";
			((global::Telerik.WinControls.UI.RadDropDownListElement)this.radDropDownList6.GetChildAt(0)).DropDownStyle = 2;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(0)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(1)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderBoxStyle = 0;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BorderColor = global::System.Drawing.SystemColors.ControlDarkDark;
			((global::Telerik.WinControls.UI.RadDropDownListEditableAreaElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.UI.RadDropDownTextBoxElement)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0)).Visibility = 1;
			((global::Telerik.WinControls.UI.RadTextBoxItem)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(2)).BackColor = global::System.Drawing.Color.White;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.FillPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = global::System.Drawing.Color.Firebrick;
			((global::Telerik.WinControls.Primitives.BorderPrimitive)this.radDropDownList6.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = global::System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = global::System.Drawing.Color.Black;
			this.label18.Location = new global::System.Drawing.Point(195, 9);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(106, 19);
			this.label18.TabIndex = 187;
			this.label18.Text = "Réceptionniste";
			this.guna2Button1.BorderRadius = 8;
			this.guna2Button1.CheckedState.Parent = this.guna2Button1;
			this.guna2Button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.guna2Button1.CustomImages.Parent = this.guna2Button1;
			this.guna2Button1.FillColor = global::System.Drawing.Color.Firebrick;
			this.guna2Button1.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.HoverState.Parent = this.guna2Button1;
			this.guna2Button1.Location = new global::System.Drawing.Point(965, 9);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
			this.guna2Button1.Size = new global::System.Drawing.Size(104, 29);
			this.guna2Button1.TabIndex = 189;
			this.guna2Button1.Text = "Modifier";
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1081, 131);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label18);
			base.Controls.Add(this.radTimePicker1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.radDateTimePicker1);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.TextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "bsm_general";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.bsm_general_Load);
			this.radDateTimePicker1.EndInit();
			this.radTimePicker1.EndInit();
			this.radDropDownList6.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000335 RID: 821
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000336 RID: 822
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000337 RID: 823
		private global::Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;

		// Token: 0x04000338 RID: 824
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000339 RID: 825
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400033A RID: 826
		private global::Guna.UI2.WinForms.Guna2TextBox TextBox1;

		// Token: 0x0400033B RID: 827
		private global::Telerik.WinControls.UI.RadTimePicker radTimePicker1;

		// Token: 0x0400033C RID: 828
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x0400033D RID: 829
		private global::System.Windows.Forms.Label label18;

		// Token: 0x0400033E RID: 830
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x0400033F RID: 831
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
	}
}
