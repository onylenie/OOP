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

    // вывести всю афишу
   public class Poster
    {
        private const string PosterFile = "data.txt";

        public Poster()
        {
            var lines = new List<string>();
            lines.AddRange(File.ReadAllLines(PosterFile));

            int l = 25;
            foreach (var line in lines)
            {
                if (line.Length > l)
                    l = line.Length;
            }

            l += 5;

            for (int i = 0; i < l; i++)
                Console.Write("-");

            Console.WriteLine("\nАфиша на ближайшее время:");

            for (int i = 0; i < l; i++)
                Console.Write("-");
            Console.WriteLine("");

            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {lines[i]}");
            }

            for (int i = 0; i < l; i++)
                Console.Write("-");

            Console.WriteLine("\n");
        }
    }

    // получить текст определенного номера афиши
    public class PosterNum
    {
        private const string PosterFile = "data.txt";

        public string GetPosterNum(int num)
        {
            try
            {
                var lines = new List<string>();
                lines.AddRange(File.ReadAllLines(PosterFile));
                string line = lines[num - 1];
                return line;
            }
            catch
            {
                return "0";
            }
        }
    }
}
