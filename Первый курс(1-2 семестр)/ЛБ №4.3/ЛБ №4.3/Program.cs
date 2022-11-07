using System;

namespace ЛБ__4._3
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("введите № задания (1 или 2):");
                int z;
                while (!(int.TryParse(Console.ReadLine(), out z) && (z > 0 && z < 3)))
                { Console.Write("введено не верно № заданияю Введите снова № задания:"); }
                if (z == 1)
                {
                    while (true)
                    {
                        int m, k;
                        Console.WriteLine("введите два натуральных числа m и k");
                        Console.Write("k=");
                        while (!(int.TryParse(Console.ReadLine(), out k)))
                        { Console.Write("Ошибка ввода. Введите сново число k:"); }
                        Console.Write("m=");
                        while (!int.TryParse(Console.ReadLine(), out m))
                        { Console.Write("Ошибка ввода. Введите сново число m:"); }
                        Console.WriteLine("ответ:{0}", e_1(k * 2) + e_1(m));
                        Console.Write("хотите проверить другое задание(да,нет):");
                        if (Console.ReadLine() == "нет")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.Write("введите еще одно число для построения картинки:");
                        double n;
                        Console.Write("n=");
                        while (!(double.TryParse(Console.ReadLine(), out n) && n < 20))
                        { Console.Write("Ошибка ввода. Введите сново число n:"); }
                        z_2(n, 0, true);
                        Console.Write("хотите проверить другое задание(да,нет):");
                        if (Console.ReadLine() == "нет")
                        {
                            break;
                        }
                    }
                }
                Console.Write("хотите закрыть програму(да,нет):");
                if (Console.ReadLine() == "да")
                {
                    break;
                }
            }
        }
        static int e_1(int k)
        {
            if (k == 1) { return 1; }
            else { return k + e_1(k - 1); }
        }
        static void z_2(double n, int p, bool t)
        {
            if (!(p * 2 - n == 0 || p * 2 - n == 1))
            {
                if (t && !(p * 2 - n == 0 || p * 2 - n == 1))
                {
                    z_2(n, p + 1, true);
                }
                for (int i = 0; i != p; i += 1)
                { Console.Write(" "); }
                for (int i = 0; i != n - p * 2; i += 1)
                { Console.Write("{0}", Math.Ceiling((n - p * 2) / 2)); }
                for (int i = 0; i != p; i += 1)
                { Console.Write(" "); }
                Console.WriteLine();
                for (int i = 1; !(i >= n / 2) && p == 0; i++)
                {
                    z_2(n, i, false);
                }
            }
        }
    }

}
