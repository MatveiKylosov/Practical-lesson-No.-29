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

namespace Practical_lesson_No._29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public bool admin = false;
        public MainWindow()
        {
            InitializeComponent();

            init = this;     
        }

        public void OpenPages(Page Page) => frame.Navigate(Page);  
        private void Clubs(object sender, RoutedEventArgs e) => OpenPages(new Pages.Clubs.Main(admin));
        private void Users(object sender, RoutedEventArgs e) => OpenPages(new Pages.Users.Main(admin));

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(((TextBlock)Role.SelectedItem).Text == "Админ")
                admin = true;
            else 
                admin = false;
        }
    }
}
