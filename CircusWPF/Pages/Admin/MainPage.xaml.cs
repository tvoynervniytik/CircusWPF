using CircusWPF.DB;
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
using CircusWPF.Functions;

namespace CircusWPF.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private static Users user;
        private static Roles role;
        public MainPage()
        {
            InitializeComponent();
            user = Authorization.regUser;
            role = Authorization.Role;
            FIOTb.Text = $"{user.Surname} {user.Name[0]}. {user.Patronymic[0]}.";
            RoleTb.Text = role.Name.ToString();
        }

        private void BackBnt_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из профиля???", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes) 
                NavigationService.Navigate(new AuthorizationPage());
        }

        private void EmployeesRegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesMainPage());
        }

        private void AnimalsRegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalsMainPage());
        }

        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ScheduleMainPage());
        }

        private void TasksBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TasksMainPage());
        }

        private void CheckEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CheckEmployeesPage());
        }
    }
}
