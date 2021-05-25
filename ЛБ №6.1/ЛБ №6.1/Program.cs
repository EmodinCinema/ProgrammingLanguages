using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛБ__6._1

{
        class Program
        {

            static void Main()
            {
                while (true)
                {
                    int n;
                    string o;
                    Console.Write("Введите № задания(1 или 2): ");
                    while (!(int.TryParse(Console.ReadLine(), out n) && n > 0 && n < 3))
                    {
                        Console.Write("Нет такого номера задания, введите снова: ");
                    }
                    switch (n)
                    {
                        case 1:
                            {
                                while (true)
                                {
                                    z_1();
                                    Console.Write("Хотите проверить задание с другими входными данными(да,нет): ");
                                    o = Console.ReadLine();
                                    if (o == "нет")
                                    {
                                        break;
                                    }
                                    else if (o != "да")
                                    {
                                        Console.WriteLine("Ошибка введите снова: ");
                                    }

                                }
                                break;
                            }
                        case 2:
                            {
                                while (true)
                                {
                                    z_2();
                                    Console.Write("Хотите проверить задание с другими входными данными(да,нет): ");
                                    o = Console.ReadLine();
                                    if (o == "нет")
                                    {
                                        break;
                                    }
                                    else if (o != "да")
                                    {
                                        Console.WriteLine("Ошибка введите снова: ");
                                    }
                                }
                                break;
                            }
                    }
                    Console.Write("Хотите проверить другое задание?(да,нет) ");
                    o = Console.ReadLine();
                    if (o == "нет")
                    {
                        break;
                    }
                    else if (o != "да")
                    {
                        Console.WriteLine("Ошибка введите снова: ");
                    }
                }
            }
            static void z_1()
            {
                string path = @"C:\Users\Александр\Desktop\1.txt";
                Console.Write("Введите до какого n надо расчитать последовательность фибоначи: ");
                uint n;
                while (!uint.TryParse(Console.ReadLine(), out n))
                {
                    Console.Write("Ошибка.Введите снова значение: ");
                }
                StreamWriter sw = new StreamWriter(path);
                if (n >= 1)
                {
                    sw.WriteLine(0);
                }
                else if (n >= 2)
                {
                    sw.WriteLine(1);
                }
                for (decimal i = 3, a = 0, b = 1; i < n + 1; i++)
                {
                    if (a < b)
                    {
                        a = a + b;
                        sw.WriteLine(a);
                    }
                    else
                    {
                        b = b + a;
                        sw.WriteLine(b);
                    }

                }
                sw.Dispose();
                StreamReader sr = new StreamReader(path);
                for (int i = 1; !sr.EndOfStream; i++)
                {
                    if (i % 3 != 0)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                }
                sr.Dispose();
                Console.WriteLine("Проверте файл он в папке, после он будет удален.\nНажмите люб кнопку чтобы продолжить ");
                Console.ReadKey();
                File.Delete(path);

            }
            static void z_2()
            {
                string path;
                Console.WriteLine("Введите путь к текстовому файлу(если нет файла пишите заготовка)");
                while (true)
                {
                    path = Console.ReadLine();
                    if (File.Exists(path) || path == "заготовка")
                    {
                        break;
                    }
                }
                if (path == "заготовка")
                {
                    path = @"C:\Users\Александр\Desktop\2.txt";
                }
                StreamReader sr = new StreamReader(path, Encoding.Default);
                int s = int.MaxValue;
                string c = null;
                for (; !sr.EndOfStream;)
                {
                    string t;
                    t = sr.ReadLine();
                    if (t.Length < s)
                    {
                        s = t.Length;
                        c = t;
                    }
                }
                sr.Dispose();
                Console.WriteLine("мин строка={0}\nеё длина ={1}", c, s);
            }
        }
    }

