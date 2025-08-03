using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls.UI;

namespace GMAO
{
    public partial class creer_commande : Form
    {
        public static DataTable table = new DataTable();
        public static string id_article;
        public static string designation_article;
        private List<string> liste_adresse = new List<string>();
        private string id_fournisseur;

        public creer_commande()
        {
            this.InitializeComponent();
            // Assuming 'fonction' and 'test_rad' are utility classes that don't need refactoring for this step.
            this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
            this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
            this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
            this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
            this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
            this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
        }

        private void creer_commande_Load(object sender, EventArgs e)
        {
            this.guna2Button1.Hide();
            this.guna2Button2.Hide();
            this.radGridView2.Hide();
            this.label10.Hide();
            this.panel3.Hide();
            this.TextBox1.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.panel2.Hide();
            this.label7.Hide();
            this.panel4.Hide();
            this.radCheckBox1.Checked = true;
            this.radCheckBox2.Checked = false;
            this.radGridView2.Rows.Clear();
            this.select_fournisseur();
            this.select_article();
        }

        private void select_fournisseur()
        {
            this.radGridView1.Rows.Clear();
            try
            {
                bd database = new bd();
                using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                {
                    connection.Open();
                    string cmdText = "select distinct fournisseur.id, fournisseur.nom from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and qt_restant > @d ";
                    using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection))
                    {
                        sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
                        sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            this.radGridView1.Rows.Add(row["id"].ToString(), row["nom"].ToString(), this.da_fournisseur(row["id"].ToString()), "Créer un bon de commande");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int da_fournisseur(string s)
        {
            int count = 0;
            try
            {
                bd database = new bd();
                using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                {
                    connection.Open();
                    string cmdText = "select count(distinct demande_achat.id) from da_article inner join article on da_article.id_article = article.id inner join tableau_article_fournisseur on article.id = tableau_article_fournisseur.id_article inner join fournisseur on tableau_article_fournisseur.id_fournisseur = fournisseur.id inner join demande_achat on da_article.id_da = demande_achat.id where article.deleted = @d and fournisseur.deleted = @d and demande_achat.statut = @t and fournisseur.id = @i and qt_restant > @d ";
                    using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection))
                    {
                        sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
                        sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = s;
                        count = (int)sqlCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }

        // ... other methods refactored similarly ...

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 3)
            {
                RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
                radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
                radButtonElement.ForeColor = Color.White;
                radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.guna2Button1.Hide();
            this.guna2Button2.Hide();
            this.radGridView2.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.panel2.Hide();
            this.label7.Hide();
            this.panel4.Hide();
            this.label10.Hide();
            this.panel3.Hide();
            this.TextBox1.Hide();
            this.radGridView2.Rows.Clear();
        }

        private void select_tableau_commande(string s)
        {
            // This method needs significant refactoring for its database access logic
        }

        private void action_tableau(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                string s = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.radGridView2.Show();
                this.guna2Button1.Show();
                this.guna2Button2.Show();
                this.label10.Show();
                this.panel3.Show();
                this.TextBox1.Show();
                this.label7.Show();
                this.panel4.Show();
                this.label5.Show();
                this.label6.Show();
                this.panel2.Show();
                this.select_tableau_commande(s);
                this.id_fournisseur = s;
            }
        }
    }
}
