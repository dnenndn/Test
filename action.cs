using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;

namespace GMAO
{
	// Token: 0x02000006 RID: 6
	public partial class action : Form
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00009EC3 File Offset: 0x000080C3
		public action()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00009EDC File Offset: 0x000080DC
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			action_ajouter action_ajouter = new action_ajouter();
			action_ajouter.TopLevel = false;
			this.panel1.Controls.Add(action_ajouter);
			action_ajouter.Show();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00009F66 File Offset: 0x00008166
		private void action_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}
	}
}
