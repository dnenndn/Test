using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200014C RID: 332
	public partial class open_pdf_equipement : Form
	{
		// Token: 0x06000EE7 RID: 3815 RVA: 0x0023FFB1 File Offset: 0x0023E1B1
		public open_pdf_equipement()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x0023FFCC File Offset: 0x0023E1CC
		private void open_pdf_equipement_Load(object sender, EventArgs e)
		{
			bool flag = equipement_pdf.id_adresse != "";
			if (flag)
			{
				this.radPdfViewer1.ScaleFactor = 0.75f;
				this.radPdfViewer1.LoadDocument(equipement_pdf.id_adresse ?? "");
				this.radPdfViewerNavigator1.ZoomDropDown.Text = "75,00 %";
			}
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00240030 File Offset: 0x0023E230
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			base.Close();
			foreach (object obj in Arbre_Equipement.Panel10.Controls)
			{
				Control control = (Control)obj;
				control.Visible = true;
			}
		}
	}
}
