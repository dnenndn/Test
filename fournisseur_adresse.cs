using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000136 RID: 310
	public partial class fournisseur_adresse : Form
	{
		// Token: 0x06000DF1 RID: 3569 RVA: 0x0021F09C File Offset: 0x0021D29C
		public fournisseur_adresse()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0021F0B4 File Offset: 0x0021D2B4
		private void fournisseur_adresse_Load(object sender, EventArgs e)
		{
			fournisseur_adresse.select_pays();
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x0021F0C0 File Offset: 0x0021D2C0
		public static void select_pays()
		{
			fournisseur_adresse.radDropDownList1.Items.Clear();
			RadListDataItem radListDataItem = new RadListDataItem();
			radListDataItem.Text = "Tunisie";
			radListDataItem.Image = fournisseur_adresse.imageList2.Images[0];
			RadListDataItem radListDataItem2 = new RadListDataItem();
			radListDataItem2.Text = "Algérie";
			radListDataItem2.Image = fournisseur_adresse.imageList2.Images[1];
			RadListDataItem radListDataItem3 = new RadListDataItem();
			radListDataItem3.Text = "Maroc";
			radListDataItem3.Image = fournisseur_adresse.imageList2.Images[2];
			RadListDataItem radListDataItem4 = new RadListDataItem();
			radListDataItem4.Text = "Egypte";
			radListDataItem4.Image = fournisseur_adresse.imageList2.Images[3];
			RadListDataItem radListDataItem5 = new RadListDataItem();
			radListDataItem5.Text = "Arabia Saudi";
			radListDataItem5.Image = fournisseur_adresse.imageList2.Images[4];
			RadListDataItem radListDataItem6 = new RadListDataItem();
			radListDataItem6.Text = "Libya";
			radListDataItem6.Image = fournisseur_adresse.imageList2.Images[5];
			fournisseur_adresse.radDropDownList1.Items.Add(radListDataItem);
			fournisseur_adresse.radDropDownList1.Items.Add(radListDataItem2);
			fournisseur_adresse.radDropDownList1.Items.Add(radListDataItem3);
			fournisseur_adresse.radDropDownList1.Items.Add(radListDataItem4);
			fournisseur_adresse.radDropDownList1.Items.Add(radListDataItem5);
			fournisseur_adresse.radDropDownList1.Items.Add(radListDataItem6);
		}
	}
}
