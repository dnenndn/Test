using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200013F RID: 319
	public partial class menu_article : Form
	{
		// Token: 0x06000E4A RID: 3658 RVA: 0x0022E2E9 File Offset: 0x0022C4E9
		public menu_article()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x0022E304 File Offset: 0x0022C504
		private void button3_Click(object sender, EventArgs e)
		{
			menu_article menu_article = new menu_article();
			menu_article.TopLevel = false;
			param_article param_article = new param_article();
			param_article.TopLevel = false;
			menu_article.button3.BackColor = Color.White;
			menu_article.button3.ForeColor = Color.Firebrick;
			menu_article.button2.BackColor = Color.Firebrick;
			menu_article.button2.ForeColor = Color.White;
			menu_article.button1.BackColor = Color.Firebrick;
			menu_article.button1.ForeColor = Color.White;
			articles.panel2.Controls.Clear();
			articles.panel2.Controls.Add(menu_article);
			menu_article.Show();
			articles.panel3.Controls.Clear();
			articles.panel3.Controls.Add(param_article);
			param_article.Show();
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x0022E3E4 File Offset: 0x0022C5E4
		private void button1_Click(object sender, EventArgs e)
		{
			menu_article menu_article = new menu_article();
			menu_article.TopLevel = false;
			ajouter_article ajouter_article = new ajouter_article();
			ajouter_article.TopLevel = false;
			menu_article.button1.BackColor = Color.White;
			menu_article.button1.ForeColor = Color.Firebrick;
			menu_article.button2.BackColor = Color.Firebrick;
			menu_article.button2.ForeColor = Color.White;
			menu_article.button3.BackColor = Color.Firebrick;
			menu_article.button3.ForeColor = Color.White;
			articles.panel2.Controls.Clear();
			articles.panel2.Controls.Add(menu_article);
			menu_article.Show();
			articles.panel3.Controls.Clear();
			articles.panel3.Controls.Add(ajouter_article);
			ajouter_article.Show();
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x0022E4C4 File Offset: 0x0022C6C4
		private void button2_Click(object sender, EventArgs e)
		{
			menu_article menu_article = new menu_article();
			menu_article.TopLevel = false;
			liste_article liste_article = new liste_article();
			liste_article.TopLevel = false;
			menu_article.button2.BackColor = Color.White;
			menu_article.button2.ForeColor = Color.Firebrick;
			menu_article.button1.BackColor = Color.Firebrick;
			menu_article.button1.ForeColor = Color.White;
			menu_article.button3.BackColor = Color.Firebrick;
			menu_article.button3.ForeColor = Color.White;
			articles.panel2.Controls.Clear();
			articles.panel2.Controls.Add(menu_article);
			menu_article.Show();
			articles.panel3.Controls.Clear();
			articles.panel3.Controls.Add(liste_article);
			liste_article.Show();
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x0022E5A4 File Offset: 0x0022C7A4
		private void menu_article_Load(object sender, EventArgs e)
		{
			bool flag = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Magasinier" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				this.button1.Hide();
				this.button3.Hide();
			}
		}
	}
}
