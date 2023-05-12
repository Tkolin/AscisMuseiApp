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
    /// Логика взаимодействия для AddEditQuastPage1.xaml
    /// </summary>
    public partial class AddEditQuastPage1 : Page
    {
        User user;
        Quast quast;
        bool add;
        public AddEditQuastPage1(User user)
        {
            InitializeComponent();
            this.user = user;
            this.quast = new Quast();
            this.add = true;
        }
        public AddEditQuastPage1(Quast quast)
        {
            InitializeComponent();
            user = null;
            this.quast = quast;
            this.add = false;
        }
        public AddEditQuastPage1()
        {
            InitializeComponent();
            user = null;
            this.quast = new Quast() ;
            this.add = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            quast.Date= D1.SelectedDate ; 
            quast.User= C1.SelectedItem as User ; 
            quast.StatusID1= C2.SelectedItem  as StatusID; 
            quast.Name= T1.Text ; 
            quast.Description= T2.Text ; 

            if(add)
                AskisMuseiDBEntities.GetContent().Quast.Add(quast) ;

            AskisMuseiDBEntities.GetContent().SaveChanges() ;
            NavigationService.GoBack() ;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            C1.ItemsSource = AskisMuseiDBEntities.GetContent().User.ToList();
            C1.DisplayMemberPath = "LastName";
            C2.ItemsSource = AskisMuseiDBEntities.GetContent().StatusID.ToList();
            C2.DisplayMemberPath = "Name";

            if (!add)
            {
                D1.SelectedDate = quast.Date;
                C1.SelectedItem = quast.User;
                C2.SelectedItem = quast.StatusID1;
                T1.Text = quast.Name;
                T2.Text = quast.Description;
            }
            if(user != null)
            {
                C1.SelectedItem = user;
                C1.IsEnabled = false;
            }
        }
    }
}
