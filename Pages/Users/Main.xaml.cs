using Practical_lesson_No._29.Classes;
using Practical_lesson_No._29.Pages.Clubs;
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

namespace Practical_lesson_No._29.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public UserContext AllUsers = new UserContext();
        public Main(bool admin)
        {
            InitializeComponent();

            if (admin)
                BthAdd.Visibility = Visibility.Visible;
            else
                BthAdd.Visibility = Visibility.Hidden;

            if(MainWindow.init.filter.filter & MainWindow.init.filter.UserCB.IsChecked == true)
            {
                Pages.Filter filter = MainWindow.init.filter;
                foreach (Models.Users User in AllUsers.Users)
                {
                    if( (filter.ClubUser.SelectedIndex != -1 && ((Models.Clubs)filter.ClubUser.SelectedItem).Id != User.IdClub) ||
                        (filter.FullName.SelectedIndex != -1 && ((Models.Users)filter.FullName.SelectedItem).Id != User.Id) ||
                        (!int.TryParse(filter.Duration.Text, out int duration) || duration != User.Duration) )
                        continue;
                    
                    Parent.Children.Add(new Elements.Item(User, this, admin));
                }
            }
            else
                foreach (Models.Users User in AllUsers.Users)
                    Parent.Children.Add(new Elements.Item(User, this, admin));

        }

        private void AddUser(object sender, RoutedEventArgs e) => 
            MainWindow.init.OpenPages(new Pages.Users.Add(this));
    }
}
