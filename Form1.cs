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
    public partial class Form1 : Form
    {
        public static string id_daa = "";
        private System.Timers.Timer t1 = new System.Timers.Timer(1200000.0);
        private System.Timers.Timer t2 = new System.Timers.Timer(10000.0);

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
            this.radMenuItem2.Click += delegate (object s, EventArgs e)
            {
                this.ouvrir_ajouter_intervenant();
            };
            this.radMenuItem4.Click += delegate (object s, EventArgs e)
            {
                this.ouvrir_fonction_intervenant();
            };
            this.radMenuItem3.Click += delegate (object s, EventArgs e)
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

        private void T2_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.get_notification();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

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

        private void label3_Click(object sender, EventArgs e)
        {
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.panel6.Visible)
            {
                this.panel6.Visible = false;
            }
            else
            {
                this.panel6.Visible = true;
            }
        }

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

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.panel7.Visible)
            {
                this.panel7.Visible = false;
            }
            else
            {
                this.panel7.Visible = true;
            }
        }

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

            if (UserSession.stat_user != "Administrateur")
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

        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void login_succes()
        {
            if (UserSession.res == 1)
            {
                UIPermissionManager.ApplyPermissions(this);
            }
        }

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void ouvrir_ajouter_intervenant()
        {
            Ajouter_intervenant ajouter_intervenant = new Ajouter_intervenant();
            ajouter_intervenant.Show();
        }

        private void ouvrir_fonction_intervenant()
        {
            ajouter_fonction_intervenant ajouter_fonction_intervenant = new ajouter_fonction_intervenant();
            ajouter_fonction_intervenant.Show();
        }

        private void ouvrir_liste_intervenant()
        {
            liste_intervenant liste_intervenant = new liste_intervenant();
            liste_intervenant.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

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

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.panel8.Visible)
            {
                this.panel8.Visible = false;
            }
            else
            {
                this.panel8.Visible = true;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (this.panel10.Visible)
            {
                this.panel10.Visible = false;
            }
            else
            {
                this.panel10.Visible = true;
            }
        }

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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            page_loginn page_loginn = new page_loginn();
            page_loginn.Show();
            this.t1.Enabled = false;
            this.t2.Enabled = false;
            base.Close();
        }

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

        public void CResolution(int a, int b)
        {
            Screen primaryScreen = Screen.PrimaryScreen;
            DEVMODE1 structure = default(DEVMODE1);
            structure.dmDeviceName = new string(new char[32]);
            structure.dmFormName = new string(new char[32]);
            structure.dmSize = (short)Marshal.SizeOf<DEVMODE1>(structure);
            if (User_32.EnumDisplaySettings(null, -1, ref structure) != 0)
            {
                structure.dmPelsWidth = a;
                structure.dmPelsHeight = b;
                int num = User_32.ChangeDisplaySettings(ref structure, 2);
                if (num == -1)
                {
                    MessageBox.Show("On ne peut proceder au chagement de Resolution");
                    MessageBox.Show("Description: On ne peut proceder au chagement de Resolution. Desolé pour cette inconvénient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    num = User_32.ChangeDisplaySettings(ref structure, 1);
                    int num2 = num;
                    if (num2 != 0)
                    {
                        if (num2 != 1)
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

        private void button20_Click(object sender, EventArgs e)
        {
            if (!this.panel13.Visible)
            {
                this.panel13.Visible = true;
            }
            else
            {
                this.panel13.Visible = false;
            }
        }

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

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (!this.panel15.Visible)
            {
                this.panel15.Visible = true;
            }
            else
            {
                this.panel15.Visible = false;
            }
        }

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

        private void notif_confirmation_commande(object source, ElapsedEventArgs e)
        {
            if (UserSession.stat_user == "Administrateur")
            {
                try
                {
                    bd database = new bd();
                    using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                    {
                        connection.Open();
                        string cmdText = "select count(id) from commande where statut = @d and urgence = @i";
                        string cmdText2 = "select count(id) from ds_commande where statut = @d and urgence = @i";

                        SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                        sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;

                        SqlCommand sqlCommand2 = new SqlCommand(cmdText2, connection);
                        sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
                        sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;

                        int num = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        int num2 = Convert.ToInt32(sqlCommand2.ExecuteScalar());

                        if (num + num2 > 0)
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
                catch (Exception)
                {
                    // Log error or handle exception silently on a timer thread
                }
            }
        }

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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (this.radPopupContainer1.Visible)
            {
                this.radPopupContainer1.Visible = false;
                try
                {
                    bd database = new bd();
                    using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                    {
                        string cmdText = "update notification set vue = @i1 where id_utilisateur = @i2";
                        SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                        sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = 1;
                        sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = UserSession.id_user;
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    this.pictureBox13.Visible = false;
                }
                catch (Exception)
                {
                    // Handle or log error
                }
            }
            else
            {
                this.radPopupContainer1.Visible = true;
            }
        }

        private void get_notification()
        {
            if (!this.radPopupContainer1.Visible)
            {
                this.radPopupContainer1.Invoke(new MethodInvoker(delegate ()
                {
                    this.radPopupContainer1.Controls.Clear();
                }));
                this.pictureBox13.Invoke(new MethodInvoker(delegate ()
                {
                    this.pictureBox13.Visible = false;
                }));

                try
                {
                    bd database = new bd();
                    using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                    {
                        string cmdText = "select * from notification where id_utilisateur = @i and type <> @v order by id desc ";
                        SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = UserSession.id_user;
                        sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Stock Sécurité";
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        int num = 0;
                        if (dataTable.Rows.Count != 0)
                        {
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dataTable.Rows[i].ItemArray[5]) == 0)
                                {
                                    num++;
                                }
                            }
                            if (num != 0)
                            {
                                this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Visible = true));
                                if (num == 1) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_1.Image));
                                else if (num == 2) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_2.Image));
                                else if (num == 3) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_3.Image));
                                else if (num == 4) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_4.Image));
                                else if (num == 5) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_5.Image));
                                else if (num == 6) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_6.Image));
                                else if (num == 7) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_7.Image));
                                else if (num == 8) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_8.Image));
                                else if (num > 8) this.pictureBox13.Invoke(new MethodInvoker(() => this.pictureBox13.Image = this.pr_9.Image));
                            }

                            int num2 = 10;
                            for (int j = 0; j < dataTable.Rows.Count; j++)
                            {
                                Panel p = new Panel { Size = new Size(240, 50), Location = new Point(3, num2) };
                                PictureBox pictureBox = new PictureBox { Location = new Point(3, 3), Size = new Size(30, 30), SizeMode = PictureBoxSizeMode.Zoom };

                                string type = dataTable.Rows[j].ItemArray[2].ToString();
                                if (type == "DA Système") pictureBox.Image = Resources.icons8_system_64;
                                else if (type == "Lancement OT Prév") pictureBox.Image = Resources.icons8_entretien_50;
                                else if (type == "Signature Commande" || type == "Création Commande") pictureBox.Image = Resources.icons8_signature_96;
                                else if (type == "Variation Commande") pictureBox.Image = Resources.icons8_prix_50;
                                else if (type == "Budget") pictureBox.Image = Resources.icons8_budget_64__2_;
                                else if (type == "Stock Sécurité") pictureBox.Image = Resources.icons8_en_rupture_de_stock_50;

                                p.Controls.Add(pictureBox);
                                Label label = new Label { Text = Convert.ToString(dataTable.Rows[j].ItemArray[4]), AutoSize = false, Size = new Size(170, 50) };

                                int num3 = label.Text.Length / 20 + 1;
                                if (Convert.ToInt32(dataTable.Rows[j].ItemArray[5]) == 0) label.BackColor = Color.Gainsboro;

                                label.Font = new Font("Time New Roman", 9f, FontStyle.Italic, GraphicsUnit.Point, 0);
                                if (num3 >= 4)
                                {
                                    label.Size = new Size(170, 15 * num3);
                                    p.Size = new Size(240, 15 * num3 + 1);
                                }
                                label.ForeColor = (j % 2 == 0) ? Color.Firebrick : Color.Black;
                                label.Location = new Point(60, 3);
                                p.Controls.Add(label);
                                num2 += p.Size.Height;
                                this.radPopupContainer1.Invoke(new MethodInvoker(() => this.radPopupContainer1.Controls.Add(p)));
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // Log error or handle exception silently on a timer thread
                }
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
        }

        private void notif_confirmation_commande_1()
        {
            if (UserSession.stat_user == "Administrateur")
            {
                try
                {
                    bd database = new bd();
                    using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                    {
                        connection.Open();
                        string cmdText = "select count(id) from commande where statut = @d and urgence = @i";
                        string cmdText2 = "select count(id) from ds_commande where statut = @d and urgence = @i";

                        SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                        sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;

                        SqlCommand sqlCommand2 = new SqlCommand(cmdText2, connection);
                        sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
                        sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = 1;

                        int num = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        int num2 = Convert.ToInt32(sqlCommand2.ExecuteScalar());

                        if (num + num2 > 0)
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
                catch (Exception)
                {
                    // Log error or handle exception silently
                }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (this.panel18.Visible)
            {
                this.panel18.Visible = false;
            }
            else
            {
                this.panel18.Visible = true;
            }
        }

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

        private void button43_Click(object sender, EventArgs e)
        {
            if (this.panel19.Visible)
            {
                this.panel19.Visible = false;
            }
            else
            {
                this.panel19.Visible = true;
            }
        }

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

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            compteur compteur = new compteur();
            compteur.TopLevel = false;
            Form1.Panel2.Controls.Clear();
            Form1.Panel2.Controls.Add(compteur);
            compteur.Show();
        }

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

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            parametre_photo parametre_photo = new parametre_photo();
            parametre_photo.TopLevel = false;
            Form1.Panel2.Controls.Clear();
            Form1.Panel2.Controls.Add(parametre_photo);
            parametre_photo.Show();
        }

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
    }
}
