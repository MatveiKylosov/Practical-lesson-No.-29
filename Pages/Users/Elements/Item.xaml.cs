using Practical_lesson_No._29.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Practical_lesson_No._29.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public ClubsContext AllClub = new ClubsContext();
        Main Main;
        Models.Users User;

        public Item(Models.Users User, Main Main, bool admin)
        {
            InitializeComponent();

            if (admin)
                BthItem.Visibility = Visibility.Visible;
            else
                BthItem.Visibility = Visibility.Hidden;

            this.FIO.Text = User.FIO;
            this.RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
            this.RentTime.Text = User.RentStart.ToString("HH:mm");
            this.Duration.Text = User.Duration.ToString();
            this.Club.Text = AllClub.Clubs.Where(x => x.Id == User.IdClub).First().Name;
            this.Main = Main;
            this.User = User;
        }

        private void EditUser(object sender, System.Windows.RoutedEventArgs e) =>
            MainWindow.init.OpenPages(new Pages.Users.Add(this.Main, this.User));

        private void DeleteUser(object sender, System.Windows.RoutedEventArgs e)
        {
            Main.AllUsers.Users.Remove(User);
            Main.AllUsers.SaveChanges();
            Main.Parent.Children.Remove(this);
        }
    }
}
