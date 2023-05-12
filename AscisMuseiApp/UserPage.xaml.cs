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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditUserPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditUserPage(dataGrid.SelectedItem as User));

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;


            AskisMuseiDBEntities.GetContent().User.Remove(dataGrid.SelectedItem as User);
            AskisMuseiDBEntities.GetContent().SaveChanges();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }
        public void Filter()
        {
            List<User> list = AskisMuseiDBEntities.GetContent().User.ToList();

            list = list.Where(l => tBox.Text.Length > 0 && (l.LastName.ToLower().Contains(tBox.Text.ToLower()) ||
                                                            l.FirstName.ToLower().Contains(tBox.Text.ToLower()) ||
                                                            l.Patronymic.ToLower().Contains(tBox.Text.ToLower()))).ToList();

            dataGrid.ItemsSource = list;

        }
    }
}
