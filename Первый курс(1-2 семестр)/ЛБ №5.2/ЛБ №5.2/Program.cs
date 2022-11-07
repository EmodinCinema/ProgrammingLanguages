using System;
using System.Text;
namespace ЛБ__5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder a = new StringBuilder("\nSomebody once told me the world is gonna roll me,\nI ain't the sharpest tool in the shed.\nShe was looking kind of dumb with her finger and her thumb,\nIn the shape of an \"L\" on her forehead...");
            Console.WriteLine(a);
            Console.WriteLine("Изменить строку?");
            string yn = Console.ReadLine();
            if (yn == "Да" ^ yn == "Yes" ^ yn == "да" ^ yn == "yes")
            {
                Console.WriteLine("Вводите другую строку: ");
                string b = Console.ReadLine();
                a.Replace("\nSomebody once told me the world is gonna roll me,\nI ain't the sharpest tool in the shed.\nShe was looking kind of dumb with her finger and her thumb,\nIn the shape of an \"L\" on her forehead...", b);
            }
            else Console.WriteLine("\nВы отказались от изменения строки :)");
            Punctuation(a);
            Console.ReadKey();
        }
        static void Punctuation(StringBuilder a)
        {
            int position = -1; for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsPunctuation(a[i]))
                {
                    position = i;
                    a.Remove(i, 1);
                }
            }
            if (position < 0) Console.WriteLine($"В строке нет знаков препинания \n {a}");
            else Console.WriteLine(a);
        }
    }
}
