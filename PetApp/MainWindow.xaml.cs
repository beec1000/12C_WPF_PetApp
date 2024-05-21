using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetApp
{
    public partial class MainWindow : Window
    {
        private List<Pet> pets = new List<Pet>();

        public MainWindow()
        {
            InitializeComponent();

            pets = Pet.FromFile(@"..\..\..\src\animals.txt");

            var sortedPets = new List<string>();
            foreach (var i in pets)
            {
                sortedPets.Add(i.ToString());
            }
            sortedPets.Sort();

            List.ItemsSource = sortedPets;
            List.SelectedItem = sortedPets[0];

        }

        private void AddToFavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = List.SelectedItem;

            if (selected != null)
            {
                FavoriteList.Items.Add(selected);
            }
        }

        private void DeleteFromFavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = List.SelectedItem;
            if (selected != null && FavoriteList.Items.Contains(selected))
            {
                FavoriteList.Items.Remove(selected);
            }
            else
            {
                MessageBox.Show("This pet is not in Favorites!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}