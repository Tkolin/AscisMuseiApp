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
    /// Логика взаимодействия для QuastPage.xaml
    /// </summary>
    public partial class QuastPage : Page
    {
        User user;
        public QuastPage(User user)
        {
            InitializeComponent();
            this.user = user;


        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tBox.Text = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditQuastPage1());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditQuastPage1(dataGrid.SelectedItem as Quast));

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            AskisMuseiDBEntities.GetContent().Quast.Remove(dataGrid.SelectedItem as Quast);
            AskisMuseiDBEntities.GetContent().SaveChanges();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void tBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();

        }

        private void dPicer_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            List<Quast> list = AskisMuseiDBEntities.GetContent().Quast.ToList();

            list = list.Where(l=> tBox.Text.Length > 0 && l.Name.ToLower().Contains(tBox.Text.ToLower())).ToList();
            list = list.Where(l => dPicer.SelectedDate != null && l.Date == dPicer.SelectedDate.Value).ToList();

            dataGrid.ItemsSource = list;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }
    }
}
