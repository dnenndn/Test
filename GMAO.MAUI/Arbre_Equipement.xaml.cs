using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Maui.Controls;

namespace GMAO.MAUI
{
    public partial class Arbre_Equipement : ContentPage
    {
        public Arbre_Equipement()
        {
            InitializeComponent();
            load_arbre(0);
        }

        private void load_arbre(int r)
        {
            arbre.ItemsSource = null;
            DataTable dataTable = new DataTable();
            bd bd = new bd();
            string cmdText = "select id, designation, code from equipement where id_parent = @d and deleted = @d";
            SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
            sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter.Fill(dataTable2);
            string cmdText2 = "select id, code, designation, id_parent from equipement where deleted = @d and id_parent <> @d order by ordre";
            SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
            sqlCommand2.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
            DataTable dataTable3 = new DataTable();
            sqlDataAdapter2.Fill(dataTable3);
            dataTable.Columns.Clear();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("ParentID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("code", typeof(string));
            if (dataTable2.Rows.Count != 0)
            {
                dataTable.Rows.Add(new object[]
                {
                    dataTable2.Rows[0].ItemArray[0].ToString(),
                    null,
                    dataTable2.Rows[0].ItemArray[1].ToString(),
                    dataTable2.Rows[0].ItemArray[2].ToString()
                });
                for (int i = 0; i < dataTable3.Rows.Count; i++)
                {
                    dataTable.Rows.Add(new object[]
                    {
                        dataTable3.Rows[i].ItemArray[0].ToString(),
                        dataTable3.Rows[i].ItemArray[3].ToString(),
                        dataTable3.Rows[i].ItemArray[2].ToString(),
                        dataTable3.Rows[i].ItemArray[1].ToString()
                    });
                }
                arbre.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
