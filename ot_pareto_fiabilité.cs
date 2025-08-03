using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000CC RID: 204
	public partial class ot_pareto_fiabilité : Form
	{
		// Token: 0x06000922 RID: 2338 RVA: 0x0017D444 File Offset: 0x0017B644
		public ot_pareto_fiabilité()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0017D45C File Offset: 0x0017B65C
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				ot_pareto_fiabilité.p = 1;
				this.panel2.Controls.Clear();
				pareto_fiabilite_equipement pareto_fiabilite_equipement = new pareto_fiabilite_equipement();
				pareto_fiabilite_equipement.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_equipement);
				pareto_fiabilite_equipement.Show();
			}
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0017D4BC File Offset: 0x0017B6BC
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				ot_pareto_fiabilité.p = 2;
				this.panel2.Controls.Clear();
				pareto_fiabilite_zone pareto_fiabilite_zone = new pareto_fiabilite_zone();
				pareto_fiabilite_zone.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_zone);
				pareto_fiabilite_zone.Show();
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0017D51C File Offset: 0x0017B71C
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			ot_pareto_fiabilité.p = 3;
			this.panel2.Controls.Clear();
			pareto_fiabilite_sous_equipement pareto_fiabilite_sous_equipement = new pareto_fiabilite_sous_equipement();
			pareto_fiabilite_sous_equipement.TopLevel = false;
			this.panel2.Controls.Add(pareto_fiabilite_sous_equipement);
			pareto_fiabilite_sous_equipement.Show();
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0017D568 File Offset: 0x0017B768
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			ot_pareto_fiabilité.p = 4;
			this.panel2.Controls.Clear();
			pareto_fiabilite_organe pareto_fiabilite_organe = new pareto_fiabilite_organe();
			pareto_fiabilite_organe.TopLevel = false;
			this.panel2.Controls.Add(pareto_fiabilite_organe);
			pareto_fiabilite_organe.Show();
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0017D5B4 File Offset: 0x0017B7B4
		private void ot_pareto_fiabilité_Load(object sender, EventArgs e)
		{
			bool flag = ot_pareto_fiabilité.p == 1;
			if (flag)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton1.IsChecked = true;
				pareto_fiabilite_equipement pareto_fiabilite_equipement = new pareto_fiabilite_equipement();
				pareto_fiabilite_equipement.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_equipement);
				pareto_fiabilite_equipement.Show();
			}
			bool flag2 = ot_pareto_fiabilité.p == 2;
			if (flag2)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton2.IsChecked = true;
				pareto_fiabilite_zone pareto_fiabilite_zone = new pareto_fiabilite_zone();
				pareto_fiabilite_zone.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_zone);
				pareto_fiabilite_zone.Show();
			}
			bool flag3 = ot_pareto_fiabilité.p == 3;
			if (flag3)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton4.IsChecked = true;
				pareto_fiabilite_sous_equipement pareto_fiabilite_sous_equipement = new pareto_fiabilite_sous_equipement();
				pareto_fiabilite_sous_equipement.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_sous_equipement);
				pareto_fiabilite_sous_equipement.Show();
			}
			bool flag4 = ot_pareto_fiabilité.p == 4;
			if (flag4)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton5.IsChecked = true;
				pareto_fiabilite_organe pareto_fiabilite_organe = new pareto_fiabilite_organe();
				pareto_fiabilite_organe.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_organe);
				pareto_fiabilite_organe.Show();
			}
			bool flag5 = ot_pareto_fiabilité.p == 5;
			if (flag5)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton3.IsChecked = true;
				pareto_fiabilite_classe_intervention pareto_fiabilite_classe_intervention = new pareto_fiabilite_classe_intervention();
				pareto_fiabilite_classe_intervention.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_classe_intervention);
				pareto_fiabilite_classe_intervention.Show();
			}
			bool flag6 = ot_pareto_fiabilité.p == 6;
			if (flag6)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton6.IsChecked = true;
				pareto_fiabilite_defaillance pareto_fiabilite_defaillance = new pareto_fiabilite_defaillance();
				pareto_fiabilite_defaillance.TopLevel = false;
				this.panel2.Controls.Add(pareto_fiabilite_defaillance);
				pareto_fiabilite_defaillance.Show();
			}
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0017D7CC File Offset: 0x0017B9CC
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			ot_pareto_fiabilité.p = 5;
			this.panel2.Controls.Clear();
			pareto_fiabilite_classe_intervention pareto_fiabilite_classe_intervention = new pareto_fiabilite_classe_intervention();
			pareto_fiabilite_classe_intervention.TopLevel = false;
			this.panel2.Controls.Add(pareto_fiabilite_classe_intervention);
			pareto_fiabilite_classe_intervention.Show();
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0017D818 File Offset: 0x0017BA18
		private void radRadioButton6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			ot_pareto_fiabilité.p = 6;
			this.panel2.Controls.Clear();
			pareto_fiabilite_defaillance pareto_fiabilite_defaillance = new pareto_fiabilite_defaillance();
			pareto_fiabilite_defaillance.TopLevel = false;
			this.panel2.Controls.Add(pareto_fiabilite_defaillance);
			pareto_fiabilite_defaillance.Show();
		}

		// Token: 0x04000C3D RID: 3133
		private static int p = 1;
	}
}
