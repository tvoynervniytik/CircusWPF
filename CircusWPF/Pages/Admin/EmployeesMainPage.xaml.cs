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

namespace CircusWPF.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для EmployeesMainPage.xaml
    /// </summary>
    public partial class EmployeesMainPage : Page
    {
        public static List<Users> users { get; set; }
        public static List<Roles> roles { get; set; }
        public EmployeesMainPage()
        {       
            InitializeComponent();
            users = new List<Users>(DBConnection.circus.Users.ToList());
            roles = new List<Roles>(DBConnection.circus.Roles.ToList());
            this.DataContext = this;
        }

        private void BackBnt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
