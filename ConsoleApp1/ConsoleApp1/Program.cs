using PosterApp;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Channels;
using ConsoleApp1;

namespace PosterApp
{
    class Program
    {
        // Файлы, принимающие участие в программе
        public  const string Users = "users.txt";
        public const string PosterFile = "data.txt";
        public const string Tickets = "tickets.txt";

        static void Main(string[] args)
        {
            PosterOutput posterOutput = new PosterOutput();
            while (true)
            {
                Console.WriteLine("Выберите действие: 1-войти в аккаунт; 2-зарегистрироваться; 3-посмотреть афишу; 0-выйти");
                string choose = Console.ReadLine();
                if (choose.Equals("3"))
                {
                Poster poster = new Poster();
                }
                else if (choose.Equals("1"))
                {
                    Console.WriteLine("Введите логин:");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string password = Console.ReadLine();

                    User user = new User(login, password);                    

                    if (user.Type == 1) // Если тип пользователя ==1 -> открывается афиша
                    {
                        string input = "";

                        while (!input.Equals("0"))
                        {
                            Poster poster = new Poster();

                            Console.WriteLine("Введите номер интересующей вас афишы, чтобы купить билет или введите '0' чтобы выйти из аккаунта:");
                            input = Console.ReadLine();

                            if (!input.Equals("0") && int.TryParse(input, out int itemNumber) && itemNumber >= 1)
                            {
                                string posterString = posterOutput.GetPosterNum(itemNumber);

                                if (posterString.Equals("0"))
                                {
                                    Console.WriteLine("Вы ввели неверный номер афиши. Повторите попытку ввода");
                                }
                                else
                                {
                                    Console.WriteLine($"Вы точно хотите купить билет на мероприятие: '{posterString}'? (y/n)");
                                    string buyInput = Console.ReadLine().ToLower();
                                    if (buyInput == "y" || buyInput == "у")
                                    {
                                        Console.WriteLine(Environment.NewLine);
                                        Ticket ticket = new Ticket();
                                        ticket.BuyTicket(itemNumber, user);
                                    }
                                }
                            }
                            else if (input.Equals("0")) break;
                        }
                    }
                    else if (user.Type == 2) //Если тип пользователя ==2 -> открывается возможность редактировать афишу
                    {
                        while (true)
                        {
                            Console.WriteLine("Что вы хотите сделать? (1-добавить афишу; 2-редактировать афишу; 3-посмотреть афишу):");

                            int help = int.Parse(Console.ReadLine());

                            if (help == 1) // Добавление
                            {
                                Console.WriteLine("Введите текст афиши: ");
                                string text = Console.ReadLine();

                                Console.WriteLine("Введите дату (в любом виде): ");
                                string date = Console.ReadLine();

                                AddPoster addPoster;

                                if (text != "" && date != "")

                                    addPoster = new AddPoster(text, date, user.Name);
                                else Console.WriteLine("Вы не ввели текст афиши или дату!");
     
                            }
                            else if (help == 2) // Изменение
                            {
                                Poster poster = new Poster();

                                Console.WriteLine("Введите номер афиши, которую хотите поменять: ");
                                string num = Console.ReadLine();

                                Console.WriteLine("Введите новый текст афиши: ");
                                string text = Console.ReadLine();

                                Console.WriteLine("Введите дату (в любом виде): ");
                                string date = Console.ReadLine();

                                if (int.TryParse(num, out int itemNumber) && itemNumber >= 1 && text.Trim() != "" && date.Trim() != "")
                                {

                                    try
                                    {
                                        ChangePoster changePoster = new ChangePoster(text, date, user.Name, int.Parse(num));

                                        Poster poster1 = new Poster();
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Произошла ошибка при вводе! Проверьте правильность ввода и повторите попытку");
                                    }
                                }
                                else Console.WriteLine("Вы не ввели текст афиши или дату!");


                            }
                            else if (help == 3) // Просмотр
                            {
                                Poster poster = new Poster();
                            }
                            else break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Неверный логин или пароль -_-");
                    }
                }
                else if (choose.Equals("2"))
                {                        
                    Registration registration = new Registration();

                    while (true)
                    {
                        Console.WriteLine("Введите логин или напишите '0', чтобы выйти: ");
                        Console.Write("Лоигн: ");
                        string login = Console.ReadLine();

                        if (login.Equals("0")) break;
                        if (registration.CheckLogin(login.Trim()) && !login.Trim().Equals(""))
                        {
                            Console.Write("Пароль: ");
                            string password = Console.ReadLine();

                            Console.Write("Повторите пароль: ");
                            string password2 = Console.ReadLine();

                            if (password.Equals(password2) && !password.Trim().Equals(""))
                            {
                                if (registration.AddNewUser(login, password))
                                {
                                    Console.WriteLine("Вы успешно зарегистрировались!");
                                    break;
                                }
                            }
                            else
                                Console.WriteLine("Пароли не совпадают!");
                        }
                        else
                            Console.WriteLine("Пользователь с таким именем уже существует, выберите другой логин");
                    }
                }
                else
                {
                    Console.WriteLine("Спасибо, что посмотрели афишу :)");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}

