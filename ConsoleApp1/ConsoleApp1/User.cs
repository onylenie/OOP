using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class User
    {
        public const string Users = "users.txt";
        public string Name { get; set; }
        public string Password { get; set; }
        public int Type { get; private set; } = 0;

        public User(string name, string password)
        {
            var userLines = File.ReadAllLines(Users);
            foreach (var userLine in userLines)
            {
                string[] parts = userLine.Split(':');
                if (parts[0] == name.Trim() && parts[1] == password.Trim())
                {
                    Name = name.Trim();
                    Password = password.Trim();
                    Type = int.Parse(parts[2]);
                }
            }
        }

        //покупка билетов
        List<string> ticketsReserved = new List<string>();
        private const string Tickets = "tickets.txt";

        public void BuyTicket(int num, User user)
        {
            foreach (var line in File.ReadLines(Tickets))
            {
                ticketsReserved.Add(line);
            }
            string ticketInfo = $"Пользователь {user.Name} купил билет на мероприятие {num}";
            
            if (ticketsReserved.Contains(ticketInfo))
            {
                Console.WriteLine("Вы уже покупали билет на это мероприятие.");
            }
            else
            {
                // Сохранение покупки
                File.AppendAllText(Tickets, ticketInfo + Environment.NewLine);
                
                Console.WriteLine("Билет куплен успешно!");      
            }
        }
    }
}
        //    private const string Users = "users.txt";
        //    private const string PosterFile = "data.txt";
        //    private const string Tickets = "tickets.txt";
        //    private const string Changes = "changes.txt";