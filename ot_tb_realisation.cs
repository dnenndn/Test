using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000E0 RID: 224
	public partial class ot_tb_realisation : Form
	{
		// Token: 0x060009DB RID: 2523 RVA: 0x0018DF0D File Offset: 0x0018C10D
		public ot_tb_realisation()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0018DF28 File Offset: 0x0018C128
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				ot_tb_realisation.p = 1;
				this.panel2.Controls.Clear();
				ot_tb_realisation_ot_retard ot_tb_realisation_ot_retard = new ot_tb_realisation_ot_retard();
				ot_tb_realisation_ot_retard.TopLevel = false;
				this.panel2.Controls.Add(ot_tb_realisation_ot_retard);
				ot_tb_realisation_ot_retard.Show();
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0018DF88 File Offset: 0x0018C188
		private void ot_tb_realisation_Load(object sender, EventArgs e)
		{
			bool flag = ot_tb_realisation.p == 1;
			if (flag)
			{
				this.radRadioButton1.IsChecked = true;
				this.panel2.Controls.Clear();
				ot_tb_realisation_ot_retard ot_tb_realisation_ot_retard = new ot_tb_realisation_ot_retard();
				ot_tb_realisation_ot_retard.TopLevel = false;
				this.panel2.Controls.Add(ot_tb_realisation_ot_retard);
				ot_tb_realisation_ot_retard.Show();
			}
			bool flag2 = ot_tb_realisation.p == 2;
			if (flag2)
			{
				this.radRadioButton2.IsChecked = true;
				this.panel2.Controls.Clear();
				ot_tb_realisation_cause ot_tb_realisation_cause = new ot_tb_realisation_cause();
				ot_tb_realisation_cause.TopLevel = false;
				this.panel2.Controls.Add(ot_tb_realisation_cause);
				ot_tb_realisation_cause.Show();
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0018E03C File Offset: 0x0018C23C
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				ot_tb_realisation.p = 2;
				this.panel2.Controls.Clear();
				ot_tb_realisation_cause ot_tb_realisation_cause = new ot_tb_realisation_cause();
				ot_tb_realisation_cause.TopLevel = false;
				this.panel2.Controls.Add(ot_tb_realisation_cause);
				ot_tb_realisation_cause.Show();
			}
		}

		// Token: 0x04000CDA RID: 3290
		private static int p = 1;
	}
}
