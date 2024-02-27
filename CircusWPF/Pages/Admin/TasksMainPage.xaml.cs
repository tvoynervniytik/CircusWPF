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
    /// Логика взаимодействия для TasksMainPage.xaml
    /// </summary>
    public partial class TasksMainPage : Page
    {
        public TasksMainPage()
        {
            InitializeComponent();
        }

        private void BackBnt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
