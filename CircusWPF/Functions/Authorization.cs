using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CircusWPF.DB;

namespace CircusWPF.Functions
{
    internal static class Authorization
    {
        public static Roles Role;
        public static Users regUser;
        private static List<Users> users {  get; set; }
        private static List<Roles> roles {  get; set; }
        
        public static void CheckRole(string login, string password)
        {
            users = new List<Users>(DBConnection.circus.Users.ToList());
            var user = users.Where(i => i.login == login && i.password == password).FirstOrDefault();

            if (login == "" || password == "")
            {
                MessageBox.Show("Поля ввода данных не заполнены");
            }
            else
            {
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
                else
                {
                    roles = new List<Roles>(DBConnection.circus.Roles.Where(i => i.Id == user.IdRole).ToList());
                    Role = roles.FirstOrDefault();
                    regUser = user;
                    MessageBox.Show(Role.Name);
                }
            }
        }
    }
}
