using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ticket
    {
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
