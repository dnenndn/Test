using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000CB RID: 203
	public partial class ot_pareto_cout : Form
	{
		// Token: 0x06000916 RID: 2326 RVA: 0x0017C7A3 File Offset: 0x0017A9A3
		public ot_pareto_cout()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0017C7BC File Offset: 0x0017A9BC
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 1;
				this.panel2.Controls.Clear();
				pareto_cout_equipement pareto_cout_equipement = new pareto_cout_equipement();
				pareto_cout_equipement.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_equipement);
				pareto_cout_equipement.Show();
			}
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0017C81C File Offset: 0x0017AA1C
		private void ot_pareto_cout_Load(object sender, EventArgs e)
		{
			bool flag = ot_pareto_cout.p == 1;
			if (flag)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton1.IsChecked = true;
				pareto_cout_equipement pareto_cout_equipement = new pareto_cout_equipement();
				pareto_cout_equipement.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_equipement);
				pareto_cout_equipement.Show();
			}
			bool flag2 = ot_pareto_cout.p == 2;
			if (flag2)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton2.IsChecked = true;
				pareto_cout_fonction pareto_cout_fonction = new pareto_cout_fonction();
				pareto_cout_fonction.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_fonction);
				pareto_cout_fonction.Show();
			}
			bool flag3 = ot_pareto_cout.p == 3;
			if (flag3)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton4.IsChecked = true;
				pareto_cout_intervenant pareto_cout_intervenant = new pareto_cout_intervenant();
				pareto_cout_intervenant.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_intervenant);
				pareto_cout_intervenant.Show();
			}
			bool flag4 = ot_pareto_cout.p == 4;
			if (flag4)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton5.IsChecked = true;
				pareto_cout_famille pareto_cout_famille = new pareto_cout_famille();
				pareto_cout_famille.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_famille);
				pareto_cout_famille.Show();
			}
			bool flag5 = ot_pareto_cout.p == 5;
			if (flag5)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton3.IsChecked = true;
				pareto_cout_sous_famille pareto_cout_sous_famille = new pareto_cout_sous_famille();
				pareto_cout_sous_famille.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_sous_famille);
				pareto_cout_sous_famille.Show();
			}
			bool flag6 = ot_pareto_cout.p == 6;
			if (flag6)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton7.IsChecked = true;
				pareto_cout_classe_intervention pareto_cout_classe_intervention = new pareto_cout_classe_intervention();
				pareto_cout_classe_intervention.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_classe_intervention);
				pareto_cout_classe_intervention.Show();
			}
			bool flag7 = ot_pareto_cout.p == 7;
			if (flag7)
			{
				this.panel2.Controls.Clear();
				this.radRadioButton6.IsChecked = true;
				pareto_cout_defaillance pareto_cout_defaillance = new pareto_cout_defaillance();
				pareto_cout_defaillance.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_defaillance);
				pareto_cout_defaillance.Show();
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0017CA90 File Offset: 0x0017AC90
		private void radRadioButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton2.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 2;
				this.panel2.Controls.Clear();
				pareto_cout_fonction pareto_cout_fonction = new pareto_cout_fonction();
				pareto_cout_fonction.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_fonction);
				pareto_cout_fonction.Show();
			}
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0017CAF0 File Offset: 0x0017ACF0
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 3;
				this.panel2.Controls.Clear();
				pareto_cout_intervenant pareto_cout_intervenant = new pareto_cout_intervenant();
				pareto_cout_intervenant.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_intervenant);
				pareto_cout_intervenant.Show();
			}
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0017CB50 File Offset: 0x0017AD50
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 6;
				this.panel2.Controls.Clear();
				pareto_cout_classe_intervention pareto_cout_classe_intervention = new pareto_cout_classe_intervention();
				pareto_cout_classe_intervention.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_classe_intervention);
				pareto_cout_classe_intervention.Show();
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0017CBB0 File Offset: 0x0017ADB0
		private void radRadioButton6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton6.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 7;
				this.panel2.Controls.Clear();
				pareto_cout_defaillance pareto_cout_defaillance = new pareto_cout_defaillance();
				pareto_cout_defaillance.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_defaillance);
				pareto_cout_defaillance.Show();
			}
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0017CC10 File Offset: 0x0017AE10
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton5.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 4;
				this.panel2.Controls.Clear();
				pareto_cout_famille pareto_cout_famille = new pareto_cout_famille();
				pareto_cout_famille.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_famille);
				pareto_cout_famille.Show();
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0017CC70 File Offset: 0x0017AE70
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton3.IsChecked;
			if (isChecked)
			{
				ot_pareto_cout.p = 5;
				this.panel2.Controls.Clear();
				pareto_cout_sous_famille pareto_cout_sous_famille = new pareto_cout_sous_famille();
				pareto_cout_sous_famille.TopLevel = false;
				this.panel2.Controls.Add(pareto_cout_sous_famille);
				pareto_cout_sous_famille.Show();
			}
		}

		// Token: 0x04000C30 RID: 3120
		private static int p = 1;
	}
}
