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

namespace Practical_lesson_No._29.Pages
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class Filter : Page
    {
        public bool filter = false;
        public Filter()
        {
            InitializeComponent();
            UpdateDate();
        }

        public void UpdateDate()
        {
            ClubCB.IsChecked = false;
            UserCB.IsChecked = false;

            ClubsContext AllClub = new ClubsContext();
            UserContext AllUsers = new UserContext();

            Name.DisplayMemberPath = "Name";
            ClubUser.DisplayMemberPath = "Name";

            ClubUser.Items.Clear();
            Name.Items.Clear();
            Address.Items.Clear();
            WorkTime.Items.Clear();
            FullName.Items.Clear();

            foreach (Models.Clubs Club in AllClub.Clubs)
            {
                Name.Items.Add(Club);
                ClubUser.Items.Add(Club);
                Address.Items.Add(Club.Address);
                WorkTime.Items.Add(Club.WorkTime);
            }

            FullName.DisplayMemberPath = "FIO";
            foreach (Models.Users User in AllUsers.Users)
                FullName.Items.Add(User);
        }

        private void UserCB_Checked(object sender, RoutedEventArgs e)
        {
            UserSP.IsEnabled = (bool)UserCB.IsChecked;
        }

        private void ClubCB_Checked(object sender, RoutedEventArgs e)
        {
                ClubSP.IsEnabled = (bool)ClubCB.IsChecked;  
        }

        private void CancelFilter(object sender, RoutedEventArgs e)
        {
            Name.SelectedIndex = -1;
            Address.SelectedIndex = -1;
            WorkTime.SelectedIndex = -1;
            FullName.SelectedIndex = -1;
            ClubUser.SelectedIndex = -1;

            UserCB.IsChecked = UserSP.IsEnabled = false;
            ClubCB.IsChecked = ClubSP.IsEnabled = false;

            RentTime.Text = "";
            Duration.Text = "";
            RentStart.Text = "";

            MessageBox.Show("Фильтр был сброшен.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            filter = false;
        }

        private void TurnFilter(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Фильтр был применён.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            filter = true;
        }
    }
}
