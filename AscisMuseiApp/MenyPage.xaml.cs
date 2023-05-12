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

namespace AscisMuseiApp
{
    /// <summary>
    /// Логика взаимодействия для MenyPage.xaml
    /// </summary>
    public partial class MenyPage : Page
    {
        User user;
        public MenyPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        public MenyPage()
        {
            InitializeComponent();
        }

        private void N1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuastPage(user));
        }

        private void N2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuastPage(user));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Роли
        }
    }
}
