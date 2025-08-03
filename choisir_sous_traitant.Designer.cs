namespace GMAO
{
	// Token: 0x0200003A RID: 58
	public partial class choisir_sous_traitant : global::System.Windows.Forms.Form
	{
		// Token: 0x0600029A RID: 666 RVA: 0x0006E930 File Offset: 0x0006CB30
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0006E968 File Offset: 0x0006CB68
		private void InitializeComponent()
		{
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.radDropDownList6 = new global::Telerik.WinControls.UI.RadDropDownList();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radDropDownList6.BeginInit();
			base.SuspendLayout();
			this.radDropDownList6.DropDownAnimationEasing = 2;
			this.radDropDownList6.DropDownStyle = 2;
			this.radDropDownList6.Location = new global::System.Drawing.Point(16, 42);
			this.radDropDownList6.Name = "radDropDownList6";
			this.radDropDownList6.Size = new global::System.Drawing.Size(267, 24);
			this.radDropDownList6.TabIndex = 181;
			this.radDropDownList6.ThemeName = "Crystal";
			this.radDropDownList6.SelectedIndexChanged += new global::Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList6_SelectedIndexChanged);
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
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(165, 19);
			this.label1.TabIndex = 180;
			this.label1.Text = "Choisir un Sous -traitant";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(445, 108);
			base.Controls.Add(this.radDropDownList6);
			base.Controls.Add(this.label1);
			base.Name = "choisir_sous_traitant";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.choisir_sous_traitant_Load);
			this.radDropDownList6.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400037D RID: 893
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400037E RID: 894
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x0400037F RID: 895
		private global::Telerik.WinControls.UI.RadDropDownList radDropDownList6;

		// Token: 0x04000380 RID: 896
		private global::System.Windows.Forms.Label label1;
	}
}
