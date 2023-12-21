using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PosterOutput
    { 
        // получить текст определенного номера афиши
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
}
