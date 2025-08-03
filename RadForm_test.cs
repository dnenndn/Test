using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200015B RID: 347
	public class RadForm_test : RadForm
	{
		// Token: 0x06000F54 RID: 3924 RVA: 0x00251173 File Offset: 0x0024F373
		public RadForm_test()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x0025118C File Offset: 0x0024F38C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x002511C4 File Offset: 0x0024F3C4
		private void InitializeComponent()
		{
			this.crystalTheme1 = new CrystalTheme();
			this.crystalDarkTheme1 = new CrystalDarkTheme();
			this.panel1 = new Panel();
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Red;
			this.panel1.Location = new Point(51, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(1230, 409);
			this.panel1.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1378, 753);
			base.Controls.Add(this.panel1);
			base.Name = "RadForm_test";
			base.RootElement.ApplyShapeToControl = true;
			this.Text = "RadForm_test";
			base.ThemeName = "Crystal";
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04001363 RID: 4963
		private IContainer components = null;

		// Token: 0x04001364 RID: 4964
		private CrystalTheme crystalTheme1;

		// Token: 0x04001365 RID: 4965
		private CrystalDarkTheme crystalDarkTheme1;

		// Token: 0x04001366 RID: 4966
		private Panel panel1;
	}
}
