using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ЛБ__4._2
{

    class Program
    {
        static void Main(string[] args)
        {
            byte z;
            while (true)
            {
                Console.Write(" Введите номер задания для проверки(числа от 1 до 3):");
                while (!byte.TryParse(Console.ReadLine(), out z) && (z > 0) && (z < 4))
                {
                    Console.Write(" Ошибка. Введите снова номер задания:");
                }
                switch (z)
                {
                    case 1:
                        while (true)
                        {
                            Z_1();
                            Console.Write("\n Хотите проверить задание с другими входными данными? (да,нет)");
                            if (Console.ReadLine() == "да")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Z_2();
                            Console.Write("\n Хотите проверить задание с другими входными данными? (да,нет)");
                            if (Console.ReadLine() == "да")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Z_3();
                            Console.Write("\n Хотите проверить задание с другими входными данными? (да,нет)");
                            if (Console.ReadLine() == "да")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                }
                Console.Write("\n Хотите проверить другое задание? (да,нет)");
                if (Console.ReadLine() == "нет")
                {
                    Console.Write(" Пока. Нажмите любую кнопку чтобы закрыть консоль.");
                    break;
                }
            }
            Console.ReadKey();
        }
        static void Z_1()
        {//a_n=1/(n*(n+1)!)
            double e, s = 0, fak = 1, n = 1;
            Console.Write(" Введите Е, которое больше 0:");
            while (!double.TryParse(Console.ReadLine(), out e) && (e > 0))
            {
                Console.Write(" Ошибка. Введите снова E:");
            }
            while (Math.Abs(1 / (n * fak * n)) > e)
            {
                fak = fak * n;
                if (Math.Abs(1 / (n * fak * n)) >= e)
                {
                    s = s + 1 / (n * (fak));
                }
                n += 1;
            }
            Console.Write(" Ответ:{0}", s + s);
        }
        static void Z_2()
        {
            int i, n = -1, c = int.MaxValue, p;
            List<int> x = new List<int>();
            Console.Write(" Введите последовательность");
            do
            {

                while (!int.TryParse(Console.ReadLine(), out p))
                {
                    Console.Write(" Ошибка введите снова");
                }
                x.Add(p);
                n += 1;
            } while (x[n] != 0);
            Console.Write(" Введите число к которому должно приблизитца последовательность");
            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.Write(" Ошибка введите снова");
            }
            p = -1;
            n = -1;
            do
            {
                n += 1;
                if (Math.Abs(i - x[n]) < c)
                {
                    c = Math.Abs(i - x[n]);
                    p = n;
                }

            } while (x[n] != 0);
            Console.Write(" Ответ:{0}", p);
        }

        static void Z_3()
        {
            string s, c;
            int m = 0, g = 0;
            Console.WriteLine(" Введите строчку для проверки условия");
            s = Console.ReadLine();
            s = s.Substring(0, s.IndexOf("."));
            s = s.Trim();
            s = s + ".";
            int n = 0;
            do
            {
                c = s.Substring(n, 1);
                if (c == "<" || c == ">" || c == "-" || c == "+" || c == "=" || c == "*" || c == "/")
                {
                    m += 1;
                }
                else if (c == "й" || c == "ц" || c == "к" || c == "н" || c == "г" || c == "ш" || c == "щ" || c == "з" || c == "х" || c == "ф" || c == "в" || c == "п" || c == "р" || c == "л" || c == "д" || c == "ж" || c == "ч" || c == "с" || c == "м" || c == "т" || c == "б")
                {
                    g += 1;
                }
                n += 1;
            } while (c != ".");
            if (g > m)
            {
                Console.WriteLine("Условие верно");
            }
            else
            {
                Console.WriteLine("Условие не верно");
            }
            Console.ReadKey();
        }
    }
}