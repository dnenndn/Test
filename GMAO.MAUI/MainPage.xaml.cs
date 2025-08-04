using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace GMAO.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var menuItems = new List<MenuItem>
            {
                new MenuItem { Title = "Equipement", TargetType = typeof(Arbre_Equipement) },
                new MenuItem { Title = "Stock", TargetType = typeof(acceuil_stock_liste_article) },
                new MenuItem { Title = "Achats", TargetType = typeof(demande_achat) },
                new MenuItem { Title = "Intervention", TargetType = typeof(intervention) },
                new MenuItem { Title = "Production", TargetType = typeof(prod_rapport) },
                new MenuItem { Title = "Sous-Traitance", TargetType = typeof(stock_sous_traitance) },
                new MenuItem { Title = "Budget", TargetType = typeof(liste_budget) },
                new MenuItem { Title = "Paramétrage", TargetType = typeof(parametrage_corrective) }
            };
            MenuList.ItemsSource = menuItems;
        }

        private void OnMenuItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menuItem = e.Item as MenuItem;
            if (menuItem != null)
            {
                var page = (Page)Activator.CreateInstance(menuItem.TargetType);
                ContentView.Content = page.Content;
            }
        }
    }

    public class MenuItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
