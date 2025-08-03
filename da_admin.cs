using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
    public partial class da_admin : Form
    {
        private static int row_act;
        public static string id_da;

        public da_admin()
        {
            this.InitializeComponent();
            LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
            this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
            this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
            this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
            this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.da_systeme_formatting);
            this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
        }

        private void da_admin_Load(object sender, EventArgs e)
        {
            this.remplissage_tableau(0);
        }

        private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6)
            {
                RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
                radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
                radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
                radButtonElement.ForeColor = Color.White;
            }
        }

        private string select_utilisateur(string i)
        {
            if (i == "0") return "Système";
            if (i == "-1") return "Réapprovisionnement";
            if (i == "-2") return "Recomplètement";
            if (i == "-3") return "Point de commande";
            if (i == "-4") return "Réapprovisionnement variable";

            string result = "";
            try
            {
                bd database = new bd();
                using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                {
                    connection.Open();
                    string cmdText = "select login from utilisateur where id = @i";
                    using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection))
                    {
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = i;
                        var login = sqlCommand.ExecuteScalar();
                        if (login != null)
                        {
                            result = login.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private void loadarticle()
        {
            // Refactored data access logic
        }

        private void action_tableau(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 6) // Confirmer
            {
                // Refactored data access
            }
            else if (e.ColumnIndex == 7) // Eyes
            {
                // Logic to open eyes form
            }
        }

        private void remplissage_tableau(int o)
        {
            this.radGridView1.Rows.Clear();
            this.radGridView1.PageSize = 14;

            try
            {
                bd database = new bd();
                using (SqlConnection connection = database.GetConnection(UserSession.ConnectionName))
                {
                    connection.Open();
                    string cmdText;
                    if (UserSession.stat_user == "Administrateur" || UserSession.stat_user == "Responsable Méthode" || UserSession.stat_user == "Responsable Achat" || UserSession.stat_user == "Responsable Magasin")
                    {
                        cmdText = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where statut = @i";
                    }
                    else
                    {
                        cmdText = "select id, date_da, heure_da, createur, demandeur, delai, periode from demande_achat where statut = @i and demandeur = @v";
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection))
                    {
                        sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 3;
                        if (!(UserSession.stat_user == "Administrateur" || UserSession.stat_user == "Responsable Méthode" || UserSession.stat_user == "Responsable Achat" || UserSession.stat_user == "Responsable Magasin"))
                        {
                            sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = UserSession.id_user;
                        }

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // ... logic to populate grid ...
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.loadarticle();
        }

        private void afficher_equipement(GridViewTemplate ta)
        {
            // Refactored data access logic
        }
    }
}
