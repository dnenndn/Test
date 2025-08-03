using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000135 RID: 309
	public partial class Form1 : Form
	{
		// Token: 0x06000D9B RID: 3483 RVA: 0x0020D8A8 File Offset: 0x0020BAA8
		public Form1()
		{
			this.InitializeComponent();
			this.pr_1.Visible = false;
			this.pr_2.Visible = false;
			this.pr_3.Visible = false;
			this.pr_4.Visible = false;
			this.pr_5.Visible = false;
			this.pr_6.Visible = false;
			this.pr_7.Visible = false;
			this.pr_8.Visible = false;
			this.pr_9.Visible = false;
			this.t1.Elapsed += this.notif_confirmation_commande;
			this.t1.Enabled = true;
			this.t2.Elapsed += this.T2_Elapsed;
			this.t2.Enabled = true;
			this.radMenuItem2.Click += delegate(object s, EventArgs e)
			{
				this.ouvrir_ajouter_intervenant();
			};
			this.radMenuItem4.Click += delegate(object s, EventArgs e)
			{
				this.ouvrir_fonction_intervenant();
			};
			this.radMenuItem3.Click += delegate(object s, EventArgs e)
			{
				this.ouvrir_liste_intervenant();
			};
			Label label = new Label();
			label.Text = "";
			this.radPopupContainer1.BringToFront();
			this.radPopupContainer1.Controls.Add(label);
			this.radPopupContainer1.Visible = false;
			this.pictureBox13.Visible = false;
			this.pictureBox13.Image = this.pr_5.Image;
			accueil accueil = new accueil();
			accueil.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(accueil);
			accueil.Show();
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x0020DA91 File Offset: 0x0020BC91
		private void T2_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.get_notification();
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x0020DA9B File Offset: 0x0020BC9B
		private void guna2Panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x0020DAA0 File Offset: 0x0020BCA0
		private void Form1_Load(object sender, EventArgs e)
		{
			this.login_succes();
			this.panel6.Visible = false;
			this.panel7.Visible = false;
			this.panel8.Visible = false;
			this.panel10.Visible = false;
			this.panel13.Visible = false;
			this.panel15.Visible = false;
			this.panel18.Visible = false;
			this.panel19.Visible = false;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x0020DB1D File Offset: 0x0020BD1D
		private void label3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x0020DB20 File Offset: 0x0020BD20
		private void button1_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			Arbre_Equipement arbre_Equipement = new Arbre_Equipement();
			arbre_Equipement.TopLevel = false;
			Form1.Panel2.Controls.Add(arbre_Equipement);
			this.button1.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			arbre_Equipement.Show();
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x0020DF30 File Offset: 0x0020C130
		private void button2_Click(object sender, EventArgs e)
		{
			bool visible = this.panel6.Visible;
			if (visible)
			{
				this.panel6.Visible = false;
			}
			else
			{
				this.panel6.Visible = true;
			}
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x0020DF70 File Offset: 0x0020C170
		private void button3_Click(object sender, EventArgs e)
		{
			Famille famille = new Famille();
			famille.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(famille);
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.Firebrick;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			famille.Show();
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x0020E36C File Offset: 0x0020C56C
		private void button4_Click(object sender, EventArgs e)
		{
			Sous_Famille sous_Famille = new Sous_Famille();
			sous_Famille.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(sous_Famille);
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.Firebrick;
			this.button3.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			sous_Famille.Show();
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0020E768 File Offset: 0x0020C968
		private void button5_Click(object sender, EventArgs e)
		{
			bool visible = this.panel7.Visible;
			if (visible)
			{
				this.panel7.Visible = false;
			}
			else
			{
				this.panel7.Visible = true;
			}
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x0020E7A8 File Offset: 0x0020C9A8
		private void button7_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.Firebrick;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			bool flag = page_loginn.stat_user != "Administrateur";
			if (flag)
			{
				ajouter_fournisseur ajouter_fournisseur = new ajouter_fournisseur();
				ajouter_fournisseur.TopLevel = false;
				Form1.Panel2.Controls.Add(ajouter_fournisseur);
				ajouter_fournisseur.Show();
			}
			else
			{
				liste_fournisseur liste_fournisseur = new liste_fournisseur();
				liste_fournisseur.TopLevel = false;
				Form1.Panel2.Controls.Add(liste_fournisseur);
				liste_fournisseur.Show();
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x0020EC08 File Offset: 0x0020CE08
		private void button6_Click(object sender, EventArgs e)
		{
			articles articles = new articles();
			articles.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(articles);
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button7.BackColor = Color.Transparent;
			this.button8.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.Firebrick;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			articles.Show();
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x0020F038 File Offset: 0x0020D238
		private void button8_Click(object sender, EventArgs e)
		{
			demande_achat demande_achat = new demande_achat();
			demande_achat.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(demande_achat);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			demande_achat.Show();
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0020F456 File Offset: 0x0020D656
		private void button11_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x0020F45C File Offset: 0x0020D65C
		private void login_succes()
		{
			bool flag = page_loginn.res == 1;
			if (flag)
			{
				this.label3.Text = page_loginn.esm;
				this.label4.Text = page_loginn.stat_user;
				bool flag2 = page_loginn.stat_user == "Administrateur";
				if (flag2)
				{
					this.button3.Visible = false;
					this.button4.Visible = false;
					this.button10.Visible = false;
					this.button11.Visible = false;
					this.panel8.Visible = false;
					this.panel8.Size = new Size(200, 45);
					this.panel6.Size = new Size(200, 235);
				}
				bool flag3 = page_loginn.stat_user == "Responsable Achat";
				if (flag3)
				{
					this.panel3.Visible = false;
					this.button3.Visible = false;
					this.button4.Visible = false;
					this.panel11.Visible = false;
					this.panel9.Visible = false;
					this.panel8.Visible = false;
					this.panel6.Size = new Size(200, 235);
				}
				bool flag4 = page_loginn.stat_user == "Responsable Magasin";
				if (flag4)
				{
					this.panel3.Visible = false;
					this.button3.Visible = false;
					this.button4.Visible = false;
					this.panel11.Visible = false;
					this.button7.Visible = false;
					this.button16.Visible = false;
					this.button17.Visible = false;
					this.button10.Visible = false;
					this.button31.Visible = false;
					this.panel6.Size = new Size(200, 235);
					this.panel7.Size = new Size(200, 235);
					this.panel8.Size = new Size(200, 100);
					this.panel9.Visible = false;
					this.panel8.Visible = false;
					this.panel12.Visible = false;
					this.panel13.Visible = false;
				}
				bool flag5 = page_loginn.stat_user == "Magasinier";
				if (flag5)
				{
					this.panel3.Visible = false;
					this.button3.Visible = false;
					this.button4.Visible = false;
					this.panel11.Visible = false;
					this.button7.Visible = false;
					this.button8.Visible = false;
					this.button12.Visible = false;
					this.button15.Visible = false;
					this.button16.Visible = false;
					this.button17.Visible = false;
					this.button10.Visible = false;
					this.button31.Visible = false;
					this.button32.Visible = false;
					this.panel6.Size = new Size(200, 235);
					this.panel7.Size = new Size(200, 45);
					this.panel8.Size = new Size(200, 100);
					this.panel9.Visible = false;
					this.panel8.Visible = false;
					this.panel12.Visible = false;
					this.panel13.Visible = false;
				}
				bool flag6 = page_loginn.stat_user == "Agent de Méthode";
				if (flag6)
				{
					this.button7.Visible = false;
					this.button12.Visible = false;
					this.button14.Visible = false;
					this.button15.Visible = false;
					this.button16.Visible = false;
					this.button17.Visible = false;
					this.button10.Visible = false;
					this.button6.Visible = false;
					this.button31.Visible = false;
					this.button32.Visible = false;
					this.panel6.Size = new Size(200, 285);
					this.panel7.Size = new Size(200, 45);
					this.panel8.Size = new Size(200, 100);
					this.panel9.Visible = false;
					this.panel8.Visible = false;
					this.panel12.Visible = false;
					this.panel13.Visible = false;
				}
				bool flag7 = page_loginn.stat_user == "Responsable Technique";
				if (flag7)
				{
					this.button7.Visible = false;
					this.button15.Visible = false;
					this.button16.Visible = false;
					this.button17.Visible = false;
					this.button10.Visible = false;
					this.button31.Visible = false;
					this.button32.Visible = false;
					this.panel6.Size = new Size(200, 320);
					this.panel7.Size = new Size(200, 151);
					this.panel8.Size = new Size(200, 100);
					this.panel9.Visible = false;
					this.panel8.Visible = false;
				}
			}
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x0020F9F0 File Offset: 0x0020DBF0
		private void button12_Click(object sender, EventArgs e)
		{
			commande commande = new commande();
			commande.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(commande);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			commande.Show();
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x0020FE10 File Offset: 0x0020E010
		private void button14_Click(object sender, EventArgs e)
		{
			reception reception = new reception();
			reception.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(reception);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			reception.Show();
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00210230 File Offset: 0x0020E430
		private void button15_Click(object sender, EventArgs e)
		{
			livraison livraison = new livraison();
			livraison.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(livraison);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			livraison.Show();
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x00210650 File Offset: 0x0020E850
		private void button17_Click(object sender, EventArgs e)
		{
			devis devis = new devis();
			devis.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(devis);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			devis.Show();
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00210A70 File Offset: 0x0020EC70
		private void button16_Click(object sender, EventArgs e)
		{
			facture facture = new facture();
			facture.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(facture);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.Firebrick;
			this.button17.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			facture.Show();
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00210EA0 File Offset: 0x0020F0A0
		private void button18_Click(object sender, EventArgs e)
		{
			bsm bsm = new bsm();
			bsm.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(bsm);
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button7.BackColor = Color.Transparent;
			this.button8.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button18.BackColor = Color.Transparent;
			this.button18.ForeColor = Color.Firebrick;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button6.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			bsm.Show();
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x002112CF File Offset: 0x0020F4CF
		private void pictureBox5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x002112D4 File Offset: 0x0020F4D4
		private void ouvrir_ajouter_intervenant()
		{
			Ajouter_intervenant ajouter_intervenant = new Ajouter_intervenant();
			ajouter_intervenant.Show();
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x002112F0 File Offset: 0x0020F4F0
		private void ouvrir_fonction_intervenant()
		{
			ajouter_fonction_intervenant ajouter_fonction_intervenant = new ajouter_fonction_intervenant();
			ajouter_fonction_intervenant.Show();
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x0021130C File Offset: 0x0020F50C
		private void ouvrir_liste_intervenant()
		{
			liste_intervenant liste_intervenant = new liste_intervenant();
			liste_intervenant.Show();
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00211327 File Offset: 0x0020F527
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x0021132C File Offset: 0x0020F52C
		private void button10_Click_1(object sender, EventArgs e)
		{
			ajouter_utilisateur ajouter_utilisateur = new ajouter_utilisateur();
			ajouter_utilisateur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(ajouter_utilisateur);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button9.BackColor = Color.Firebrick;
			this.button9.ForeColor = Color.White;
			this.button10.ForeColor = Color.Firebrick;
			this.button13.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			ajouter_utilisateur.Show();
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x0021174C File Offset: 0x0020F94C
		private void button13_Click(object sender, EventArgs e)
		{
			signature signature = new signature();
			signature.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(signature);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button9.BackColor = Color.Firebrick;
			this.button9.ForeColor = Color.White;
			this.button13.ForeColor = Color.Firebrick;
			this.button10.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			signature.Show();
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00211B6C File Offset: 0x0020FD6C
		private void button9_Click(object sender, EventArgs e)
		{
			bool visible = this.panel8.Visible;
			if (visible)
			{
				this.panel8.Visible = false;
			}
			else
			{
				this.panel8.Visible = true;
			}
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00211BAC File Offset: 0x0020FDAC
		private void button22_Click(object sender, EventArgs e)
		{
			bool visible = this.panel10.Visible;
			if (visible)
			{
				this.panel10.Visible = false;
			}
			else
			{
				this.panel10.Visible = true;
			}
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00211BEC File Offset: 0x0020FDEC
		private void button21_Click(object sender, EventArgs e)
		{
			ajouter_moteur ajouter_moteur = new ajouter_moteur();
			ajouter_moteur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(ajouter_moteur);
			this.button22.BackColor = Color.Firebrick;
			this.button22.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.Firebrick;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			ajouter_moteur.Show();
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00211FE8 File Offset: 0x002101E8
		private void pictureBox7_Click(object sender, EventArgs e)
		{
			accueil accueil = new accueil();
			accueil.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(accueil);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			accueil.Show();
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x002123C4 File Offset: 0x002105C4
		private void pictureBox8_Click(object sender, EventArgs e)
		{
			page_loginn page_loginn = new page_loginn();
			page_loginn.Show();
			this.t1.Enabled = false;
			this.t2.Enabled = false;
			base.Close();
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00212400 File Offset: 0x00210600
		private void button19_Click(object sender, EventArgs e)
		{
			retour_magasin retour_magasin = new retour_magasin();
			retour_magasin.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(retour_magasin);
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button7.BackColor = Color.Transparent;
			this.button8.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button19.BackColor = Color.Transparent;
			this.button19.ForeColor = Color.Firebrick;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button6.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			retour_magasin.Show();
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00212830 File Offset: 0x00210A30
		private void button11_Click_1(object sender, EventArgs e)
		{
			liste_utilisateur liste_utilisateur = new liste_utilisateur();
			liste_utilisateur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(liste_utilisateur);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button9.BackColor = Color.Firebrick;
			this.button9.ForeColor = Color.White;
			this.button11.ForeColor = Color.Firebrick;
			this.button13.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			liste_utilisateur.Show();
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00212C50 File Offset: 0x00210E50
		public void CResolution(int a, int b)
		{
			Screen primaryScreen = Screen.PrimaryScreen;
			DEVMODE1 structure = default(DEVMODE1);
			structure.dmDeviceName = new string(new char[32]);
			structure.dmFormName = new string(new char[32]);
			structure.dmSize = (short)Marshal.SizeOf<DEVMODE1>(structure);
			bool flag = User_32.EnumDisplaySettings(null, -1, ref structure) != 0;
			if (flag)
			{
				structure.dmPelsWidth = a;
				structure.dmPelsHeight = b;
				int num = User_32.ChangeDisplaySettings(ref structure, 2);
				bool flag2 = num == -1;
				if (flag2)
				{
					MessageBox.Show("On ne peut proceder au chagement de Resolution");
					MessageBox.Show("Description: On ne peut proceder au chagement de Resolution. Desolé pour cette inconvénient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					num = User_32.ChangeDisplaySettings(ref structure, 1);
					int num2 = num;
					int num3 = num2;
					if (num3 != 0)
					{
						if (num3 != 1)
						{
							MessageBox.Show("Description: Imposible de changer la Resolution.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show("Description: VOus devez demarer votre ordinateur pour appliquer le changement.\n Si vous avez tout probleme aplrés redemarage.\nThen Essayer d'appliquer le Changement de Resolution en 'Safe Mode'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
				}
			}
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00212D54 File Offset: 0x00210F54
		private void button25_Click(object sender, EventArgs e)
		{
			creer_budget creer_budget = new creer_budget();
			creer_budget.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(creer_budget);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Firebrick;
			this.button20.ForeColor = Color.White;
			this.button25.ForeColor = Color.Firebrick;
			this.button13.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			creer_budget.Show();
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00213174 File Offset: 0x00211374
		private void button20_Click(object sender, EventArgs e)
		{
			bool flag = !this.panel13.Visible;
			if (flag)
			{
				this.panel13.Visible = true;
			}
			else
			{
				this.panel13.Visible = false;
			}
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x002131B4 File Offset: 0x002113B4
		private void button23_Click(object sender, EventArgs e)
		{
			liste_article_simple liste_article_simple = new liste_article_simple();
			liste_article_simple.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(liste_article_simple);
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button7.BackColor = Color.Transparent;
			this.button8.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button23.BackColor = Color.Transparent;
			this.button23.ForeColor = Color.Firebrick;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button6.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			liste_article_simple.Show();
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x002135E4 File Offset: 0x002117E4
		private void button24_Click(object sender, EventArgs e)
		{
			liste_budget liste_budget = new liste_budget();
			liste_budget.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(liste_budget);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Firebrick;
			this.button20.ForeColor = Color.White;
			this.button24.ForeColor = Color.Firebrick;
			this.button13.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			liste_budget.Show();
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00213A04 File Offset: 0x00211C04
		private void button27_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			intervention_sous_traitance intervention_sous_traitance = new intervention_sous_traitance();
			intervention_sous_traitance.TopLevel = false;
			Form1.Panel2.Controls.Add(intervention_sous_traitance);
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.Firebrick;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			intervention_sous_traitance.Show();
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00213E33 File Offset: 0x00212033
		private void panel14_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00213E38 File Offset: 0x00212038
		private void button26_Click(object sender, EventArgs e)
		{
			bool flag = !this.panel15.Visible;
			if (flag)
			{
				this.panel15.Visible = true;
			}
			else
			{
				this.panel15.Visible = false;
			}
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00213E78 File Offset: 0x00212078
		private void button28_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			activite_sous_traitance activite_sous_traitance = new activite_sous_traitance();
			activite_sous_traitance.TopLevel = false;
			Form1.Panel2.Controls.Add(activite_sous_traitance);
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.Firebrick;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			activite_sous_traitance.Show();
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x002142A8 File Offset: 0x002124A8
		private void button30_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			achat_sous_traitance achat_sous_traitance = new achat_sous_traitance();
			achat_sous_traitance.TopLevel = false;
			Form1.Panel2.Controls.Add(achat_sous_traitance);
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.Firebrick;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			achat_sous_traitance.Show();
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x002146D8 File Offset: 0x002128D8
		private void button29_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			stock_sous_traitance stock_sous_traitance = new stock_sous_traitance();
			stock_sous_traitance.TopLevel = false;
			Form1.Panel2.Controls.Add(stock_sous_traitance);
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Firebrick;
			this.button26.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.Firebrick;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			stock_sous_traitance.Show();
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00214B08 File Offset: 0x00212D08
		private void button31_Click(object sender, EventArgs e)
		{
			tb_achat tb_achat = new tb_achat();
			tb_achat.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(tb_achat);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			tb_achat.Show();
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00214F28 File Offset: 0x00213128
		private void button32_Click(object sender, EventArgs e)
		{
			approvisionnement approvisionnement = new approvisionnement();
			approvisionnement.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(approvisionnement);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button5.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.Firebrick;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			approvisionnement.Show();
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00215348 File Offset: 0x00213548
		private void notif_confirmation_commande(object source, ElapsedEventArgs e)
		{
			bool flag = Convert.ToString(page_loginn.stat_user) == "Administrateur";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select count(id) from commande where statut = @d and urgence = @i";
				string cmdText2 = "select count(id) from ds_commande where statut = @d and urgence = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable = new DataTable();
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				sqlDataAdapter2.Fill(dataTable2);
				int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				int num2 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
				bool flag2 = num + num2 != 0;
				if (flag2)
				{
					RadDesktopAlert radDesktopAlert = new RadDesktopAlert();
					radDesktopAlert.ThemeName = "CrystalDark";
					radDesktopAlert.CaptionText = "Confirmation Commandes en Attentes";
					string contentText = string.Concat(new string[]
					{
						"<html><i>Nbre des Commandes en attente Urgentes : ",
						num.ToString(),
						" </i>.<i>Nbre des Commandes Sous traitance Urgentes : ",
						num2.ToString(),
						" </i>.<b><span><color=Firebrick>S'il vous plaît confirmer les commandes.</span></b>"
					});
					radDesktopAlert.ContentText = contentText;
					radDesktopAlert.FixedSize = new Size(329, 175);
					radDesktopAlert.PopupAnimation = true;
					radDesktopAlert.PopupAnimationFrames = 78;
					radDesktopAlert.PopupAnimationDirection = 2;
					radDesktopAlert.PopupAnimationEasing = 31;
					radDesktopAlert.ScreenPosition = 1;
					radDesktopAlert.ShowPinButton = false;
					radDesktopAlert.ShowOptionsButton = false;
					radDesktopAlert.ContentImage = Resources.icons8_rappels_de_rendez_vous_50;
					radDesktopAlert.AutoClose = true;
					radDesktopAlert.AutoCloseDelay = 10;
					SoundPlayer soundPlayer = new SoundPlayer(Resources.AUD_1633653439186);
					radDesktopAlert.Show();
					soundPlayer.Play();
					MessageBox.Show("Notification Confirmation des commandes", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x002155A4 File Offset: 0x002137A4
		private void button33_Click(object sender, EventArgs e)
		{
			budget_investissement budget_investissement = new budget_investissement();
			budget_investissement.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(budget_investissement);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Firebrick;
			this.button20.ForeColor = Color.White;
			this.button33.ForeColor = Color.Firebrick;
			this.button13.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			budget_investissement.Show();
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x002159C4 File Offset: 0x00213BC4
		private void button34_Click(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			Outillage outillage = new Outillage();
			outillage.TopLevel = false;
			Form1.Panel2.Controls.Add(outillage);
			this.button34.BackColor = Color.Firebrick;
			this.button34.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			outillage.Show();
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00215DD4 File Offset: 0x00213FD4
		private void button35_Click(object sender, EventArgs e)
		{
			mvt_stock mvt_stock = new mvt_stock();
			mvt_stock.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(mvt_stock);
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button7.BackColor = Color.Transparent;
			this.button8.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button35.BackColor = Color.Transparent;
			this.button35.ForeColor = Color.Firebrick;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button6.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			mvt_stock.Show();
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00216204 File Offset: 0x00214404
		private void pictureBox12_Click(object sender, EventArgs e)
		{
			bool visible = this.radPopupContainer1.Visible;
			if (visible)
			{
				this.radPopupContainer1.Visible = false;
				bd bd = new bd();
				string cmdText = "update notification set vue = @i1 where id_utilisateur = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = 1;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.pictureBox13.Visible = false;
			}
			else
			{
				this.radPopupContainer1.Visible = true;
			}
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x002162C8 File Offset: 0x002144C8
		private void get_notification()
		{
			bool flag = !this.radPopupContainer1.Visible;
			if (flag)
			{
				this.radPopupContainer1.Invoke(new MethodInvoker(delegate()
				{
					this.radPopupContainer1.Controls.Clear();
				}));
				this.pictureBox13.Invoke(new MethodInvoker(delegate()
				{
					this.pictureBox13.Visible = false;
				}));
				bd bd = new bd();
				string cmdText = "select * from notification where id_utilisateur = @i and type <> @v order by id desc ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = page_loginn.id_user;
				sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Stock Sécurité";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				int num = 0;
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag3 = Convert.ToInt32(dataTable.Rows[i].ItemArray[5]) == 0;
						if (flag3)
						{
							num++;
						}
					}
					bool flag4 = num != 0;
					if (flag4)
					{
						this.pictureBox13.Invoke(new MethodInvoker(delegate()
						{
							this.pictureBox13.Visible = true;
						}));
						bool flag5 = num == 1;
						if (flag5)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_1.Image;
							}));
						}
						bool flag6 = num == 2;
						if (flag6)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_2.Image;
							}));
						}
						bool flag7 = num == 3;
						if (flag7)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_3.Image;
							}));
						}
						bool flag8 = num == 4;
						if (flag8)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_4.Image;
							}));
						}
						bool flag9 = num == 5;
						if (flag9)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_5.Image;
							}));
						}
						bool flag10 = num == 6;
						if (flag10)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_6.Image;
							}));
						}
						bool flag11 = num == 7;
						if (flag11)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_7.Image;
							}));
						}
						bool flag12 = num == 8;
						if (flag12)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_8.Image;
							}));
						}
						bool flag13 = num > 8;
						if (flag13)
						{
							this.pictureBox13.Invoke(new MethodInvoker(delegate()
							{
								this.pictureBox13.Image = this.pr_9.Image;
							}));
						}
					}
					int num2 = 10;
					for (int j = 0; j < dataTable.Rows.Count; j++)
					{
						Panel p = new Panel();
						p.Size = new Size(240, 50);
						p.Location = new Point(3, num2);
						PictureBox pictureBox = new PictureBox();
						pictureBox.Location = new Point(3, 3);
						pictureBox.Size = new Size(30, 30);
						bool flag14 = dataTable.Rows[j].ItemArray[2].ToString() == "DA Système";
						if (flag14)
						{
							pictureBox.Image = Resources.icons8_system_64;
						}
						bool flag15 = dataTable.Rows[j].ItemArray[2].ToString() == "Lancement OT Prév";
						if (flag15)
						{
							pictureBox.Image = Resources.icons8_entretien_50;
						}
						bool flag16 = dataTable.Rows[j].ItemArray[2].ToString() == "Signature Commande" | dataTable.Rows[j].ItemArray[2].ToString() == "Création Commande";
						if (flag16)
						{
							pictureBox.Image = Resources.icons8_signature_96;
						}
						bool flag17 = dataTable.Rows[j].ItemArray[2].ToString() == "Variation Commande";
						if (flag17)
						{
							pictureBox.Image = Resources.icons8_prix_50;
						}
						bool flag18 = dataTable.Rows[j].ItemArray[2].ToString() == "Budget";
						if (flag18)
						{
							pictureBox.Image = Resources.icons8_budget_64__2_;
						}
						bool flag19 = dataTable.Rows[j].ItemArray[2].ToString() == "Stock Sécurité";
						if (flag19)
						{
							pictureBox.Image = Resources.icons8_en_rupture_de_stock_50;
						}
						pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
						p.Controls.Add(pictureBox);
						Label label = new Label();
						label.Text = Convert.ToString(dataTable.Rows[j].ItemArray[4]);
						int num3 = label.Text.Length / 20;
						num3++;
						label.AutoSize = false;
						label.Size = new Size(170, 50);
						bool flag20 = Convert.ToInt32(dataTable.Rows[j].ItemArray[5]) == 0;
						if (flag20)
						{
							label.BackColor = Color.Gainsboro;
						}
						label.Font = new Font("Time New Roman", 9f, FontStyle.Italic, GraphicsUnit.Point, 0);
						bool flag21 = num3 >= 4;
						if (flag21)
						{
							label.Size = new Size(170, 15 * num3);
							p.Size = new Size(240, 15 * num3 + 1);
						}
						bool flag22 = j % 2 == 0;
						if (flag22)
						{
							label.ForeColor = Color.Firebrick;
						}
						else
						{
							label.ForeColor = Color.Black;
						}
						label.Location = new Point(60, 3);
						p.Controls.Add(label);
						num2 += p.Size.Height;
						this.radPopupContainer1.Invoke(new MethodInvoker(delegate()
						{
							this.radPopupContainer1.Controls.Add(p);
						}));
					}
				}
			}
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x00216914 File Offset: 0x00214B14
		private void pictureBox14_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00216918 File Offset: 0x00214B18
		private void notif_confirmation_commande_1()
		{
			bool flag = Convert.ToString(page_loginn.stat_user) == "Administrateur";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select count(id) from commande where statut = @d and urgence = @i";
				string cmdText2 = "select count(id) from ds_commande where statut = @d and urgence = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable = new DataTable();
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				sqlDataAdapter2.Fill(dataTable2);
				int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
				int num2 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
				bool flag2 = num + num2 != 0;
				if (flag2)
				{
					RadDesktopAlert radDesktopAlert = new RadDesktopAlert();
					radDesktopAlert.ThemeName = "CrystalDark";
					radDesktopAlert.CaptionText = "Confirmation Commandes en Attentes";
					string contentText = string.Concat(new string[]
					{
						"<html><i>Nbre des Commandes en attente Urgentes : ",
						num.ToString(),
						" </i>.<i>Nbre des Commandes Sous traitance Urgentes : ",
						num2.ToString(),
						" </i>.<b><span><color=Firebrick>S'il vous plaît confirmer les commandes.</span></b>"
					});
					radDesktopAlert.ContentText = contentText;
					radDesktopAlert.FixedSize = new Size(329, 175);
					radDesktopAlert.PopupAnimation = true;
					radDesktopAlert.PopupAnimationFrames = 78;
					radDesktopAlert.PopupAnimationDirection = 2;
					radDesktopAlert.PopupAnimationEasing = 31;
					radDesktopAlert.ScreenPosition = 1;
					radDesktopAlert.ShowPinButton = false;
					radDesktopAlert.ShowOptionsButton = false;
					radDesktopAlert.ContentImage = Resources.icons8_rappels_de_rendez_vous_50;
					radDesktopAlert.AutoClose = true;
					radDesktopAlert.AutoCloseDelay = 10;
					SoundPlayer soundPlayer = new SoundPlayer(Resources.AUD_1633653439186);
					radDesktopAlert.Show();
					soundPlayer.Play();
					MessageBox.Show("Notification Confirmation des commandes", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00216B74 File Offset: 0x00214D74
		private void button36_Click(object sender, EventArgs e)
		{
			bool visible = this.panel18.Visible;
			if (visible)
			{
				this.panel18.Visible = false;
			}
			else
			{
				this.panel18.Visible = true;
			}
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x00216BB4 File Offset: 0x00214DB4
		private void button40_Click(object sender, EventArgs e)
		{
			parametrage_corrective parametrage_corrective = new parametrage_corrective();
			parametrage_corrective.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(parametrage_corrective);
			this.button36.BackColor = Color.Firebrick;
			this.button36.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.Firebrick;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			parametrage_corrective.Show();
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x00216FB0 File Offset: 0x002151B0
		private void button39_Click(object sender, EventArgs e)
		{
			Demande_Intervention demande_Intervention = new Demande_Intervention();
			demande_Intervention.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(demande_Intervention);
			this.button36.BackColor = Color.Firebrick;
			this.button36.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.Firebrick;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			demande_Intervention.Show();
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x002173AC File Offset: 0x002155AC
		private void button37_Click(object sender, EventArgs e)
		{
			ordre_travail ordre_travail = new ordre_travail();
			ordre_travail.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(ordre_travail);
			this.button36.BackColor = Color.Firebrick;
			this.button36.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.Firebrick;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			ordre_travail.Show();
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x002177A8 File Offset: 0x002159A8
		private void button43_Click(object sender, EventArgs e)
		{
			bool visible = this.panel19.Visible;
			if (visible)
			{
				this.panel19.Visible = false;
			}
			else
			{
				this.panel19.Visible = true;
			}
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x002177E8 File Offset: 0x002159E8
		private void button42_Click(object sender, EventArgs e)
		{
			parametrage_production parametrage_production = new parametrage_production();
			parametrage_production.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(parametrage_production);
			this.button43.BackColor = Color.Firebrick;
			this.button43.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.Firebrick;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			parametrage_production.Show();
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00217BE4 File Offset: 0x00215DE4
		private void button41_Click(object sender, EventArgs e)
		{
			prod_rapport prod_rapport = new prod_rapport();
			prod_rapport.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(prod_rapport);
			this.button43.BackColor = Color.Firebrick;
			this.button43.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.Firebrick;
			this.button42.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			prod_rapport.Show();
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00217FE0 File Offset: 0x002161E0
		private void button38_Click(object sender, EventArgs e)
		{
			prod_recap prod_recap = new prod_recap();
			prod_recap.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(prod_recap);
			this.button43.BackColor = Color.Firebrick;
			this.button43.ForeColor = Color.White;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.Firebrick;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			prod_recap.Show();
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x002183DC File Offset: 0x002165DC
		private void pictureBox16_Click(object sender, EventArgs e)
		{
			compteur compteur = new compteur();
			compteur.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(compteur);
			compteur.Show();
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x00218420 File Offset: 0x00216620
		private void button44_Click_1(object sender, EventArgs e)
		{
			Form1.Panel2.Controls.Clear();
			notification notification = new notification();
			notification.TopLevel = false;
			Form1.Panel2.Controls.Add(notification);
			this.button44.BackColor = Color.Firebrick;
			this.button44.ForeColor = Color.White;
			this.button2.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button43.BackColor = Color.Transparent;
			this.button43.ForeColor = Color.DimGray;
			this.button42.ForeColor = Color.DimGray;
			this.button41.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			notification.Show();
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x00218830 File Offset: 0x00216A30
		private void pictureBox18_Click(object sender, EventArgs e)
		{
			parametre_photo parametre_photo = new parametre_photo();
			parametre_photo.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(parametre_photo);
			parametre_photo.Show();
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00218874 File Offset: 0x00216A74
		private void pictureBox19_Click(object sender, EventArgs e)
		{
			acceuil_maintenance acceuil_maintenance = new acceuil_maintenance();
			acceuil_maintenance.TopLevel = false;
			Form1.Panel2.Controls.Clear();
			Form1.Panel2.Controls.Add(acceuil_maintenance);
			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.DimGray;
			this.button20.BackColor = Color.Transparent;
			this.button20.ForeColor = Color.DimGray;
			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.DimGray;
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.DimGray;
			this.button26.BackColor = Color.Transparent;
			this.button26.ForeColor = Color.DimGray;
			this.button4.ForeColor = Color.DimGray;
			this.button3.ForeColor = Color.DimGray;
			this.button4.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.DimGray;
			this.button13.ForeColor = Color.DimGray;
			this.button10.ForeColor = Color.DimGray;
			this.button7.ForeColor = Color.DimGray;
			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.DimGray;
			this.button8.ForeColor = Color.DimGray;
			this.button12.ForeColor = Color.DimGray;
			this.button11.ForeColor = Color.DimGray;
			this.button14.ForeColor = Color.DimGray;
			this.button15.ForeColor = Color.DimGray;
			this.button17.ForeColor = Color.DimGray;
			this.button16.ForeColor = Color.DimGray;
			this.button18.ForeColor = Color.DimGray;
			this.button21.ForeColor = Color.DimGray;
			this.button22.BackColor = Color.Transparent;
			this.button22.ForeColor = Color.DimGray;
			this.button19.ForeColor = Color.DimGray;
			this.button25.ForeColor = Color.DimGray;
			this.button24.ForeColor = Color.DimGray;
			this.button23.ForeColor = Color.DimGray;
			this.button28.ForeColor = Color.DimGray;
			this.button27.ForeColor = Color.DimGray;
			this.button30.ForeColor = Color.DimGray;
			this.button29.ForeColor = Color.DimGray;
			this.button31.ForeColor = Color.DimGray;
			this.button32.ForeColor = Color.DimGray;
			this.button33.ForeColor = Color.DimGray;
			this.button34.BackColor = Color.Transparent;
			this.button34.ForeColor = Color.DimGray;
			this.button35.ForeColor = Color.DimGray;
			this.button40.ForeColor = Color.DimGray;
			this.button36.BackColor = Color.Transparent;
			this.button36.ForeColor = Color.DimGray;
			this.button39.ForeColor = Color.DimGray;
			this.button37.ForeColor = Color.DimGray;
			this.button38.ForeColor = Color.DimGray;
			this.button44.BackColor = Color.Transparent;
			this.button44.ForeColor = Color.DimGray;
			acceuil_maintenance.Show();
		}

		// Token: 0x04001134 RID: 4404
		public static string id_daa = "";

		// Token: 0x04001135 RID: 4405
		private System.Timers.Timer t1 = new System.Timers.Timer(1200000.0);

		// Token: 0x04001136 RID: 4406
		private System.Timers.Timer t2 = new System.Timers.Timer(10000.0);
	}
}
