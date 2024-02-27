using Practical_lesson_No._29.Classes;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace Practical_lesson_No._29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public ClubsContext AllClub = new ClubsContext();
        public Main(bool admin)
        {
            InitializeComponent();

            if (admin)
                BthAdd.Visibility = Visibility.Visible;
            else
                BthAdd.Visibility = Visibility.Hidden;

            foreach (Models.Clubs Club in AllClub.Clubs)
                Parent.Children.Add(new Elements.Item(Club, this, admin));
        }

        private void AddClub(object sender, RoutedEventArgs e) => 
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this));
    }
}
