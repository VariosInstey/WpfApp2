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
using WpfApp2.Core;
using WpfApp2.Model;

namespace WpfApp2.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ZayavaPage.xaml
    /// </summary>
    public partial class ZayavaPage : Page
    {
        private User _user = new User();
        public ZayavaPage()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnCas_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.MyConnection.Navigate(new OnasPage());
        }

        private void BtnCase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCa_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.MyConnection.Navigate(new InfoPage());
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.MyConnection?.Navigate(new MainPage());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext())
            {
                var login = TbLogin.Text;
                var Email = TbEmail.Text;
                var Phone = TbPhone.Text;
                var Project = TbProject.Text;

                try
                {
                    if (string.IsNullOrEmpty(TbLogin.Text) ||
            string.IsNullOrEmpty(TbPhone.Text) ||
            string.IsNullOrEmpty(TbEmail.Text))



                    {
                        MessageBox.Show($"Email, телефон и логин обязательно!", "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    else
                    {
                        db.Users.Add(new User()
                        {
                            Login = login,
                            Email = Email,
                            PhoneNumber = Phone,
                            Project = Project
                        });
                        db.SaveChanges();
                        MessageBox.Show($"Вы успешно отправили нам запрос!", 
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                        TbLogin.Text = string.Empty;
                        TbEmail.Text = string.Empty;
                        TbPhone.Text = string.Empty;
                        TbProject.Text= string.Empty;


                    }
                }
                catch (Exception)
                {

                    throw;

                }
            }
        }
    }
}
