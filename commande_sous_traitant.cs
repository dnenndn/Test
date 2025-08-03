using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x02000047 RID: 71
	public partial class commande_sous_traitant : Form
	{
		// Token: 0x0600032E RID: 814 RVA: 0x0008B3AB File Offset: 0x000895AB
		public commande_sous_traitant()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0008B3C4 File Offset: 0x000895C4
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0008B400 File Offset: 0x00089600
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			creer_commande_st creer_commande_st = new creer_commande_st();
			creer_commande_st.TopLevel = false;
			this.panel1.Controls.Add(creer_commande_st);
			creer_commande_st.Show();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0008B4F0 File Offset: 0x000896F0
		private void commande_sous_traitant_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Responsable Achat";
			if (flag)
			{
				this.button2.Show();
				this.button2_Click(sender, e);
			}
			else
			{
				this.button2.Hide();
				this.button1_Click(sender, e);
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0008B544 File Offset: 0x00089744
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			commande_attente_st commande_attente_st = new commande_attente_st();
			commande_attente_st.TopLevel = false;
			this.panel1.Controls.Add(commande_attente_st);
			commande_attente_st.Show();
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0008B634 File Offset: 0x00089834
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.DimGray;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			commande_encour_st commande_encour_st = new commande_encour_st();
			commande_encour_st.TopLevel = false;
			this.panel1.Controls.Add(commande_encour_st);
			commande_encour_st.Show();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0008B724 File Offset: 0x00089924
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			commande_annule_st commande_annule_st = new commande_annule_st();
			commande_annule_st.TopLevel = false;
			this.panel1.Controls.Add(commande_annule_st);
			commande_annule_st.Show();
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0008B814 File Offset: 0x00089A14
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.DimGray;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.DimGray;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.DimGray;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.DimGray;
			this.panel1.Controls.Clear();
			commande_cloturer_st commande_cloturer_st = new commande_cloturer_st();
			commande_cloturer_st.TopLevel = false;
			this.panel1.Controls.Add(commande_cloturer_st);
			commande_cloturer_st.Show();
		}
	}
}
