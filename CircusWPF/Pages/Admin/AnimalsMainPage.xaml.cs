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
            Animals animal = new Animals();
            animal.Name = NameTb.Text.Trim();
            animal.Birthday = DateDp.SelectedDate;
                DateTime selectedDate = (DateTime)DateDp.SelectedDate;
                int age = -selectedDate.Year + DateTime.Now.Year;
            animal.Age = age;
            if (GenderCb.SelectedIndex == 0)
                animal.IdGender = 1;
            else animal.IdGender = 2;
            animal.Weight = int.Parse(WeightTb.Text.Trim());
            animal.FoodDesc = MealTb.Text.Trim();
            animal.CareDesc = CareTb.Text.Trim();
            //int a = users.FirstOrDefault(i => i.Surname == TrainerCb.SelectedItem).Id;
            var curTrainer = TrainerCb.SelectedItem as Users;
            animal.IdTrainer = curTrainer.Id;

            DBConnection.circus.Animals.Add(animal);
            DBConnection.circus.SaveChanges();

            UsersSlv.ItemsSource = new List<Animals>(DBConnection.circus.Animals);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (DateDp.SelectedDate != null)
            {
                DateTime selectedDate = (DateTime)DateDp.SelectedDate;
                int age = -selectedDate.Year + DateTime.Now.Year;
                AgeTb.FontSize = 15;
                AgeTb.Text = (age).ToString();
            }
            else
            {
                MessageBox.Show("Введите дату для расчёта возраста", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
            }
        }
    }
}
