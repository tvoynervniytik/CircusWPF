using System;
using System.Collections.Generic;
using System.Data;
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
using CircusWPF.Functions;

namespace CircusWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private string login;
        private string password;
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login = loginTb.Text.Trim();
            password = passwordPb.Password.Trim();
            Authorization.CheckRole(login, password);
            if (Authorization.Role.Name == "Администратор")
                NavigationService.Navigate(new Pages.Admin.MainPage());
            if (Authorization.Role.Name == "Актёр")
                NavigationService.Navigate(new Pages.Actor.MainPage());
            if (Authorization.Role.Name == "Дрессировщик")
                NavigationService.Navigate(new Pages.Trainer.MainPage());
            if (Authorization.Role.Name == "Стафф")
                NavigationService.Navigate(new Pages.Staff.MainPage());
        }
    }
}
