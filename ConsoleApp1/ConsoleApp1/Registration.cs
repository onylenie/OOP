using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Registration
    {
        private const string Users = "users.txt";

        // Проверка на увникальность логина
        public bool CheckLogin(string login)
        {
            var users = File.ReadAllLines(Users);
            foreach (string user in users)
            {
                string[] parts = user.Split(':');
                if (parts[0].Trim() == login)
                    return false;
            }
            return true;
        }
        
        // Добавление нового пользователя
        public bool AddNewUser(string login, string password)
        {
            string newUserString = $"{login}:{password}:1";
            
            try
            {
                using (StreamWriter writer = new StreamWriter(Users, true))
                {
                    writer.WriteLine(newUserString);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
