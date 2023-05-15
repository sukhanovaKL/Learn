using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LearnEntities db = new LearnEntities();

        public MainWindow()
        {
            InitializeComponent();

            ServicesList.ItemsSource = db.Services.ToList();

            OrderByComboBox.ItemsSource = new List<string>
            {
                "Сброс", "По возрастанию", "По убыванию"
            };

            FilterComboBox.ItemsSource = new List<string>
            {
                "от 0 до 5%", "от 5% до 15%", "от 15% до 30%", "от 30% до 70%", "от 70% до 100%"
            };

            CountItemsLabel.Content = db.Services.ToList().Count + " из " + db.Services.ToList().Count;
        }

        public void GetByFilter()
        {
            var allItems = db.Services.ToList();

            if (SearchTextBox.Text.Any())
            {
                allItems = allItems.FindAll(x => x.Name.Contains(SearchTextBox.Text) || x.Description.Contains(SearchTextBox.Text));
            }

            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    allItems = allItems.ToList().FindAll(x => x.Sale < 5);
                    break;
                case 1:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 5 && x.Sale < 15);
                    break;
                case 2:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 15 && x.Sale < 30);
                    break;
                case 3:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 30 && x.Sale < 70);
                    break;
                case 4:
                    allItems = allItems.ToList().FindAll(x => x.Sale >= 70 && x.Sale < 100);
                    break;
            }

            switch (OrderByComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    allItems = allItems.OrderBy(x => x.Cost).ToList();
                    break;
                case 2:
                    allItems = allItems.OrderByDescending(x => x.Cost).ToList();
                    break;
            }

            ServicesList.ItemsSource = allItems;
            CountItemsLabel.Content = allItems + "из" + db.Services.ToList().Count;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetByFilter();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetByFilter();
        }

        private void OrderByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetByFilter();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int deleteId = ((sender as Button).DataContext as Services).Id;
            var deleteItem = db.Services.ToList().Find(x => x.Id == deleteId);
            db.Services.Remove(deleteItem);
            db.SaveChanges();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new EditCreateWindow(new Services(), false).Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new EditCreateWindow((sender as Button).DataContext as Services, true).Show();
        }
    }
}
