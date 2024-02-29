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
    /// Логика взаимодействия для AnimalsMainPage.xaml
    /// </summary>
    public partial class AnimalsMainPage : Page
    {
        public static List<Animals> animals {  get; set; }
        public static List<Gender> genders { get; set; }
        public static List<Users> users { get; set; }
        public AnimalsMainPage()
        {
            InitializeComponent();
            animals = new List<Animals>(DBConnection.circus.Animals.ToList());
            genders = new List<Gender>(DBConnection.circus.Gender.ToList());
            users = new List<Users>(DBConnection.circus.Users.ToList());
            this.DataContext = this;
        }

        private void BackBnt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DateDp.SelectedDate != null)
            {
                DateTime af = (DateTime)DateDp.SelectedDate;
                AgeTb.Text = (-af.Year + DateTime.Now.Year).ToString();
                MessageBox.Show(af.GetType().ToString());
            }
            else
            { AgeTb.Text = " "; }
            var a = DateDp.SelectedDate;
            
        }
    }
}
