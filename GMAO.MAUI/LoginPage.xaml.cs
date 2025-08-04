using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Maui.Controls;

namespace GMAO.MAUI
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
            {
                DisplayAlert("Error", "Please enter username and password", "OK");
                return;
            }

            try
            {
                bd bd = new bd();
                string cmdText = "SELECT id, login, statu FROM utilisateur WHERE login = @login AND password = @password";
                SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
                sqlCommand.Parameters.AddWithValue("@login", Username.Text);
                sqlCommand.Parameters.AddWithValue("@password", Password.Text);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dataTable.Rows[0]["id"]);
                    string login = dataTable.Rows[0]["login"].ToString();
                    string statut = dataTable.Rows[0]["statu"].ToString();

                    UserSession.CurrentUser.SetUser(id, login, statut);

                    // Navigate to the main page
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    DisplayAlert("Error", "Invalid username or password", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
