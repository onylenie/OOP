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
        private const string Users = "users.txt";
        public string Name { get; set; }
        private string Password { get; set; }
        public int Type { get; set; } = 0;

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


    }


}
        //    private const string Users = "users.txt";
        //    private const string PosterFile = "data.txt";
        //    private const string Tickets = "tickets.txt";
        //    private const string Changes = "changes.txt";