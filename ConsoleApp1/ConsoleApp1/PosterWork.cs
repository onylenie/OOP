using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //абстрактный класс для работы с расписанием
    public abstract class PosterWork
    {

        public abstract string Text { get; set; }
        public abstract string Date { get; set; }
        public abstract string Author { get; set; }

        public abstract void Result(string text);
    }

    // класс для изменения строки расписания
    public class ChangePoster : PosterWork
    {
        private const string Changes = "changes.txt";
        private const string Poster = "data.txt";
        public override string Text { get; set; }
        public override string Date { get; set; }
        public override string Author { get; set; }
        public int Num { get; set; }

        public ChangePoster(string text, string date, string author, int num)
        {
            Text = text;
            Date = date;
            Author = author;
            Num = num;

            var lines = new List<string>();
            lines.AddRange(File.ReadAllLines(Poster));
            lines[num - 1] = $"{text}, {date}";
            File.WriteAllLines(Poster, lines);

            string change = $"Пользователь {author} изменил событие №'{1 + num}' на '{text}' ";
            this.Result(change);
        }

        public override void Result(string text)
        {
            using (StreamWriter writer = new StreamWriter(Changes, true))
            {
                writer.WriteLine(text);
            }

            Console.WriteLine("// Изменения успешно внесены! //");
        }
    }


    // класс для добавления строки в афишу
    public class AddPoster : PosterWork
    {
        private const string Changes = "changes.txt";
        private const string Poster = "data.txt";

        public override string Text { get; set; }
        public override string Date { get; set; }
        public override string Author { get; set; }

        public AddPoster(string text, string date, string author)
        {
            Text = text;
            Date = date;
            Author = author;
            string change = $"Пользователь {author} добавил событие '{text}' ";

            using (StreamWriter writer = new StreamWriter(Poster, true))
            {
                writer.WriteLine($"{text}, {date}".Trim());
            }

            this.Result(change);
        }

        public override void Result(string text)
        {
            using (StreamWriter writer = new StreamWriter(Changes, true))
            {
                writer.WriteLine(text);
            }

            Console.WriteLine("// Новое событие успешно добавлено! //");
        }
    }
}

//    private const string Users = "users.txt";
//    private const string PosterFile = "data.txt";
//    private const string Tickets = "tickets.txt";
//    private const string Changes = "changes.txt";