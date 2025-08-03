using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000DF RID: 223
	public partial class ot_tb_kpi : Form
	{
		// Token: 0x060009D2 RID: 2514 RVA: 0x0018D715 File Offset: 0x0018B915
		public ot_tb_kpi()
		{
			this.InitializeComponent();
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0018D730 File Offset: 0x0018B930
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				ot_tb_kpi.p = 1;
				this.panel2.Controls.Clear();
				ot_kpi_tous ot_kpi_tous = new ot_kpi_tous();
				ot_kpi_tous.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_tous);
				ot_kpi_tous.Show();
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0018D790 File Offset: 0x0018B990
		private void ot_tb_kpi_Load(object sender, EventArgs e)
		{
			bool flag = ot_tb_kpi.p == 1;
			if (flag)
			{
				this.radRadioButton1.IsChecked = true;
				this.panel2.Controls.Clear();
				ot_kpi_tous ot_kpi_tous = new ot_kpi_tous();
				ot_kpi_tous.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_tous);
				ot_kpi_tous.Show();
			}
			bool flag2 = ot_tb_kpi.p == 2;
			if (flag2)
			{
				this.radRadioButton2.IsChecked = true;
				this.panel2.Controls.Clear();
				ot_kpi_zone ot_kpi_zone = new ot_kpi_zone();
				ot_kpi_zone.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_zone);
				ot_kpi_zone.Show();
			}
			bool flag3 = ot_tb_kpi.p == 3;
			if (flag3)
			{
				this.radRadioButton4.IsChecked = true;
				this.panel2.Controls.Clear();
				ot_kpi_equipement ot_kpi_equipement = new ot_kpi_equipement();
				ot_kpi_equipement.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_equipement);
				ot_kpi_equipement.Show();
			}
			bool flag4 = ot_tb_kpi.p == 4;
			if (flag4)
			{
				this.radRadioButton5.IsChecked = true;
				this.panel2.Controls.Clear();
				ot_kpi_sous_equipement ot_kpi_sous_equipement = new ot_kpi_sous_equipement();
				ot_kpi_sous_equipement.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_sous_equipement);
				ot_kpi_sous_equipement.Show();
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0018D8F8 File Offset: 0x0018BAF8
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				ot_tb_kpi.p = 2;
				this.panel2.Controls.Clear();
				ot_kpi_zone ot_kpi_zone = new ot_kpi_zone();
				ot_kpi_zone.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_zone);
				ot_kpi_zone.Show();
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0018D958 File Offset: 0x0018BB58
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				ot_tb_kpi.p = 3;
				this.panel2.Controls.Clear();
				ot_kpi_equipement ot_kpi_equipement = new ot_kpi_equipement();
				ot_kpi_equipement.TopLevel = false;
				this.panel2.Controls.Add(ot_kpi_equipement);
				ot_kpi_equipement.Show();
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0018D9B8 File Offset: 0x0018BBB8
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			ot_tb_kpi.p = 4;
			this.panel2.Controls.Clear();
			ot_kpi_sous_equipement ot_kpi_sous_equipement = new ot_kpi_sous_equipement();
			ot_kpi_sous_equipement.TopLevel = false;
			this.panel2.Controls.Add(ot_kpi_sous_equipement);
			ot_kpi_sous_equipement.Show();
		}

		// Token: 0x04000CD0 RID: 3280
		private static int p = 1;
	}
}
