using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Maui.Controls;

namespace GMAO.MAUI
{
    public partial class acceuil_stock_liste_article : ContentPage
    {
        public acceuil_stock_liste_article()
        {
            InitializeComponent();
            remplissage_tableau();
        }

        private void remplissage_tableau()
        {
            bd bd = new bd();
            string cmdText = "SELECT designation, stock_neuf FROM article WHERE stock_neuf < stock_min";
            SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            List<Article> articles = new List<Article>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                articles.Add(new Article
                {
                    Designation = dataTable.Rows[i]["designation"].ToString(),
                    StockNeuf = Convert.ToDouble(dataTable.Rows[i]["stock_neuf"])
                });
            }
            radGridView3.ItemsSource = articles;
        }
    }

    public class Article
    {
        public string Designation { get; set; }
        public double StockNeuf { get; set; }
    }
}
