using System;

namespace ЛБ__3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, y, h;
            Console.Write("Введите левую границу_");
            while (!double.TryParse(Console.ReadLine(), out a)) 
            Console.WriteLine("Ошибка ввода");

            Console.Write("Введите правую границу_");
            while (!double.TryParse(Console.ReadLine(), out b)) 
            Console.WriteLine("Ошибка ввода");

            Console.Write("Введите шаг_");
            while (!double.TryParse(Console.ReadLine(), out h)) 
            Console.WriteLine("Ошибка ввода");
            Console.WriteLine("Таблица");
            Console.WriteLine("x\ty");
            if (h <= 0)
            {
                Console.WriteLine("Недопустимый шаг");

            }
            else
            { 
                for(double i=a; i<=b; i=i+h)
                {
                    if (i>0)
                    {
                        y = i;
                    }
                    else if(i<=0 && i>= -1)
                    {
                        y = 0;
                    }
                    else
                    {
                        y = Math.Pow(i, 2);
                    }
                    Console.WriteLine("x=" + i + "ty=" + y);

                }           
            }
            Console.ReadKey();




        }
    }
}
