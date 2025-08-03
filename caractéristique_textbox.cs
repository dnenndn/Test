using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x02000036 RID: 54
	public partial class caractéristique_textbox : Form
	{
		// Token: 0x06000279 RID: 633 RVA: 0x0006A6BD File Offset: 0x000688BD
		public caractéristique_textbox()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0006A6D5 File Offset: 0x000688D5
		private void caractéristique_textbox_Load(object sender, EventArgs e)
		{
			this.select_type_donnee();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0006A6E0 File Offset: 0x000688E0
		private void select_type_donnee()
		{
			caractéristique_textbox.ComboBox2.Items.Clear();
			caractéristique_textbox.ComboBox2.Items.Add("Chaîne de caractères");
			caractéristique_textbox.ComboBox2.Items.Add("Entier");
			caractéristique_textbox.ComboBox2.Items.Add("Réel");
		}
	}
}
