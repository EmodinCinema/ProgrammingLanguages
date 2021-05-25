using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ__5._1._1
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
            Letters(a);
            Console.ReadKey();
        }
        static void Letters(StringBuilder a)
        {
            int c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsLetter(a[i])) c++;
            }
            Console.WriteLine("Количество букв в строке: " + c);
        }
    }
}