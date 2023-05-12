using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditUserPage.xaml
    /// </summary>
    public partial class AddEditUserPage : Page
    {
        User user;
        bool add;
        BitmapImage _image;
        public AddEditUserPage(User user)
        {
            InitializeComponent();
            this.user = user;
            add = false;
        }
        public AddEditUserPage()
        {
            InitializeComponent();
            this.user = new User();
            add = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_image != null)
                user.Avatar = ConvertToArray(_image);
            else
                user.Avatar = null;

            T1.Text = user.FirstName = T1.Text;
            user.LastName = T2.Text;
            user.Patronymic = T3.Text;
              user.Post = C1.SelectedItem as Post;

            user.Login = T4.Text;
            user.Password = T5.Text;
            user.Role = C2.SelectedItem as Role;
            user.HealStatus = C3.SelectedItem as HealStatus;

            if (add)
                AskisMuseiDBEntities.GetContent().User.Add(user);

            AskisMuseiDBEntities.GetContent().SaveChanges();
            NavigationService.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnDelQuast_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            AskisMuseiDBEntities.GetContent().Quast.Remove(dataGrid.SelectedItem as Quast);
        }

        private void btnEditQuast_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditQuastPage1(dataGrid.SelectedItem as Quast));

        }

        private void btnAddQuast_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditQuastPage1(user));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            C1.ItemsSource = AskisMuseiDBEntities.GetContent().Post.ToList();
            C1.DisplayMemberPath = "Name";
            C2.ItemsSource = AskisMuseiDBEntities.GetContent().Role.ToList();
            C2.DisplayMemberPath = "Name";
            C3.ItemsSource = AskisMuseiDBEntities.GetContent().HealStatus.ToList();
            C3.DisplayMemberPath = "Name";

            if (!add)
            {
                if (user.Avatar != null)
                {//конвертация из базы
                    MemoryStream ms = new MemoryStream(user.Avatar, 0, user.Avatar.Length);
                    ms.Write(user.Avatar, 0, user.Avatar.Length);
                    _image = ConvertToBitmap(user.Avatar);
                    imageBox.Source = _image;
                }
                T1.Text = user.FirstName;
                T2.Text = user.LastName;
                T3.Text = user.Patronymic;
                C1.SelectedItem = user.Post;

                T4.Text = user.Login;
                T5.Text = user.Password;
                C2.SelectedItem = user.Role;
                C3.SelectedItem = user.HealStatus;
                dataGrid.ItemsSource = user.Quast;
            }
        }

        public BitmapImage ConvertToBitmap(byte[] value)
        {
            BitmapImage bitmap = new BitmapImage();
            try
            {
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(value);
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                MessageBox.Show("Ошибка изображения в базе данных");
            }
            return null;

        }

        public byte[] ConvertToArray(BitmapImage value)
        {
            BitmapImage image = (BitmapImage)value;
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
