using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMAO
{
	// Token: 0x0200001E RID: 30
	public partial class articles : Form
	{
		// Token: 0x060001AD RID: 429 RVA: 0x00048E2F File Offset: 0x0004702F
		public articles()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00048E48 File Offset: 0x00047048
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00048E84 File Offset: 0x00047084
		private void articles_Load(object sender, EventArgs e)
		{
			menu_article menu_article = new menu_article();
			menu_article.TopLevel = false;
			menu_article.button1.BackColor = Color.White;
			menu_article.button1.ForeColor = Color.Firebrick;
			menu_article.button2.BackColor = Color.Firebrick;
			menu_article.button2.ForeColor = Color.White;
			menu_article.button3.BackColor = Color.Firebrick;
			menu_article.button3.ForeColor = Color.White;
			articles.panel2.Controls.Clear();
			articles.panel2.Controls.Add(menu_article);
			menu_article.Show();
			bool flag = page_loginn.stat_user == "Administrateur" | page_loginn.stat_user == "Magasinier" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				menu_article.button2.BackColor = Color.White;
				menu_article.button2.ForeColor = Color.Firebrick;
				menu_article.button1.BackColor = Color.Firebrick;
				menu_article.button1.ForeColor = Color.White;
				menu_article.button3.BackColor = Color.Firebrick;
				menu_article.button3.ForeColor = Color.White;
				liste_article liste_article = new liste_article();
				liste_article.TopLevel = false;
				articles.panel3.Controls.Clear();
				articles.panel3.Controls.Add(liste_article);
				liste_article.Show();
			}
			else
			{
				ajouter_article ajouter_article = new ajouter_article();
				ajouter_article.TopLevel = false;
				articles.panel3.Controls.Clear();
				articles.panel3.Controls.Add(ajouter_article);
				ajouter_article.Show();
			}
		}
	}
}
