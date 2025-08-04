using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
    public partial class page_loginn : Form
    {
        private string _selectedConnectionName;

        public page_loginn()
        {
            this.InitializeComponent();
            this.button1.Click += this.ouverture_login;
            this.select_type_cnx();
        }

        public void ouverture_login(object sender, EventArgs e)
        {
            fonction fonction = new fonction();
            UserSession.Clear();

            if (string.IsNullOrWhiteSpace(this.TextBox1.Text) || string.IsNullOrWhiteSpace(this.TextBox2.Text))
            {
                MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                bd database = new bd();
                using (SqlConnection connection = database.GetConnection(_selectedConnectionName))
                {
                    string cmdText = "select id, fonction from utilisateur where login = @x1 and mot_passe = @x2 and deleted = @d";
                    SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
                    sqlCommand.Parameters.Add("@x1", SqlDbType.VarChar).Value = this.TextBox1.Text;
                    sqlCommand.Parameters.Add("@x2", SqlDbType.VarChar).Value = this.TextBox2.Text;
                    sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count != 0)
                    {
                        UserSession.esm = this.TextBox1.Text;
                        UserSession.res = 1;
                        UserSession.id_user = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
                        UserSession.stat_user = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
                        UserSession.ConnectionName = _selectedConnectionName;

                        Form1 form = new Form1();
                        form.Show();
                        base.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Utilisateur ou mot de passe est incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur de base de données est survenue: {ex.Message}", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void select_type_cnx()
        {
            this.radDropDownList1.Items.Clear();
            this.radDropDownList1.Items.Add("IBB Local");
            this.radDropDownList1.Items.Add("IBB Distant");
            this.radDropDownList1.Items.Add("NGES Local");
            this.radDropDownList1.Text = "IBB Local";
            _selectedConnectionName = "IBB_Local"; // Default connection
        }

        private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            switch (this.radDropDownList1.Text)
            {
                case "IBB Local":
                    _selectedConnectionName = "IBB_Local";
                    break;
                case "IBB Distant":
                    _selectedConnectionName = "IBB_Distant";
                    break;
                case "NGES Local":
                    _selectedConnectionName = "NGES_Local";
                    break;
                default:
                    _selectedConnectionName = "IBB_Local"; // Default fallback
                    break;
            }
        }

		// Unused event handlers, kept for designer compatibility
		private void guna2Button1_Click(object sender, EventArgs e) {}
        private void button1_Click(object sender, EventArgs e) {}
        private void page_loginn_Load(object sender, EventArgs e) {}
    }
}
