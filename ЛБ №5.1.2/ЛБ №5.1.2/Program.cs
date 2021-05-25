using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ЛБ__5._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder a = new StringBuilder("Съешь ещё этих мягких французских булок, да выпей же чаю.");
            Console.WriteLine(a);
            Console.WriteLine("Изменить строку?");
            string yn = Console.ReadLine();
            if (yn == "Да" ^ yn == "Yes" ^ yn == "да" ^ yn == "yes")
            {
                Console.WriteLine("Вводите другую строку: ");
                string b = Console.ReadLine();
                a.Replace("Съешь ещё этих мягких французских булок, да выпей же чаю.", b);
            }
            else Console.WriteLine("Вы отказались от изменения строки :)");
            Words(a);
            Console.ReadKey();
        }
        static void Words(StringBuilder a)
        {
            string[] words = a.ToString().Split(' ');
            char[] symbols = { ' ', '.', ',', ':', '!', '/', '\t', '\0', '\v', '\"', '\'', '\\', '\r' };
            Console.Write("Введите символ: ");
            char letter;
            while (!char.TryParse(Console.ReadLine(), out letter))
                Console.Write("Вы вводите слишком много символов, повторите ввод: ");
            string letter2 = Convert.ToString(letter);
            foreach (string word in words)
            {
                string w = word.TrimEnd(symbols);
                if (w.EndsWith(letter2))
                {
                    a.Replace(w, null);
                }
            }
            if (a.ToString().Contains("  "))
            {
                a.Replace("  ", " ");
            }
            if (a.ToString().Contains(" ,"))
            {
                a.Replace(" , ", " ");
            }
            Console.WriteLine(a);
        }
    }
}