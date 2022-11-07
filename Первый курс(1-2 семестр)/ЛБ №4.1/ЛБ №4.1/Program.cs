using System;

namespace ЛБ__4._1
{
    class Program
    {
        static Random rnt = new Random();
        static void Main()
        {

            while (true)
            {
                Console.Write(" Введите номер задания каторый вы хотите проверить (1,2,3,4):");
                int n;
                while (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.Write(" Ошибка введите снова значение:");
                }
                switch (n)
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
                            Console.Write("\n Хотите проверить задание с другими входными данными ?(да,нет)");
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
                    case 4:
                        while (true)
                        {
                            Z_4();
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
                Console.Write("\n Хотите проверить другое задание?(да,нет)");
                if (Console.ReadLine() == "нет")
                {
                    Console.Write(" Пока. Нажмите любую кнопку чтобы закрыть консоль.");
                    break;
                }
            }
            Console.ReadKey();
        }
        private static void Z_4()
        {
            Console.Write(" Введите длину и ширину квадратной матрицы для проверки условий:");
            int n, k;
            bool t = true;
            while (!int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                Console.Write(" Ошибка введите снова значение:");
            }
            Console.Write("\n1 - ое условие:Все элементы k - й строки равны элементам 1 -й строки.\n2 - ое условие: Все элементы k - го столбца заканчиваются на 3.\n");
            int[,] mas = new int[n, n];
            Console.WriteLine(" Введите матрицу столбец за столбцом каждое значение через Enter");
            for (int i = 0; i < n; i += 1)
            {
                for (int r = 0; r < n; r += 1)
                {
                    Console.Write("({0},{1})=", i + 1, r + 1);
                    while (!int.TryParse(Console.ReadLine(), out mas[i, r]))
                    {
                        Console.Write(" Ошибка введите снова значение:");
                    }
                }

            }
            Console.Write(" Введите к-ую строку для 1-ого условия:");
            while (!int.TryParse(Console.ReadLine(), out k) && k >= 1 && k <= n)
            {
                Console.Write(" Ошибка введите снова значение:");
            }
            for (int i = 0; i < n; i += 1)
            {
                if (mas[k - 1, i] != mas[1, i])
                {
                    t = false;
                }
            }
            if (t)
            {
                Console.Write(" Условие  выполняется\n");
            }
            else
            {
                Console.Write(" Условие не выполняется\n");
            }
            t = true;
            Console.Write(" Введите к-тый столбец для 2-ого условия:");
            while (!int.TryParse(Console.ReadLine(), out k) && k >= 1 && k <= n)
            {
                Console.Write(" Ошибка введите снова значение:");
            }
            for (int i = 0; i < n; i += 1)
            {
                if (mas[i, k - 1] % 10 != 3)
                {
                    t = false;
                }
            }
            if (t)
            {
                Console.Write(" Условие  выполняется");
            }
            else
            {
                Console.Write(" Условие не выполняется");
            }
        }
        private static void Z_2()
        {
            Console.Write(" Введите длину и ширину квадратной матрицы для нахождения макс значения:");
            int n, s = int.MinValue;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out n);
                if ((n % 2 == 1) && (n <= 25) && (n >= 3))
                {
                    break;
                }
                else
                {
                    Console.Write(" Ошибка введите снова значение:");
                }
            }
            int[,] mas = new int[n, n];
            for (int i = 0; i < n; i += 1)
            {
                for (int t = 0; t < n; t += 1)
                {
                    mas[i, t] = rnt.Next(10, 100);
                    Console.Write(mas[i, t] + " ");
                }
                Console.Write("\n");
            }
            for (int i = 0; i < n; i += 1)
            {
                for (int t = 0; t < n; t += 1)
                {
                    if (i >= t && s < mas[i, t])
                    {
                        s = mas[i, t];
                    }
                }
            }
            Console.Write("\n Максимальное значение: {0}", s);
        }
        static void Z_3()
        {
            Console.Write(" Введите длину и ширину квадратной матрицы для заштриховки:");
            int n;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out n);
                if ((n % 2 == 1) && (n <= 25) && (n >= 3))
                {
                    break;
                }
                else
                {
                    Console.Write(" Ошибка введите снова значение:");
                }

            }
            int[,] mas = new int[n, n];
            for (int i = 0; i < n; i += 1)
            {
                for (int t = 0; t < n; t += 1)
                {
                    mas[i, t] = 1;
                }
            }
            for (int i = 0; i < n; i += 1)
            {
                for (int t = 0; t < n; t += 1)
                {
                    if (((i < n / 2 + 1) && ((t == 0) || (t == n - 1))) || (i == t + n / 2) || (i == n - 1 - t + n / 2))
                    {
                        mas[i, t] = 0;
                    }
                }
            }
            for (int i = 0; i < n; i += 1)
            {
                for (int t = 0; t < n; t += 1)
                {
                    Console.Write(mas[i, t] + " ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
        static void Z_1()
        {
            Console.Write(" Введите размер массива для нахождения 3-его минимума:");
            int n;
            int s = int.MinValue;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out n);
                if ((n >= 3) && (n <= 100))
                {
                    break;
                }
                else
                {
                    Console.Write(" Ошибка введите снова значение:");
                }
            }
            int[] mat = new int[n];
            for (int i = 0; i < n; i += 1)
            {
                mat[i] = rnt.Next(10, 100);
                Console.WriteLine("y({0})={1}", i + 1, mat[i]);
            }
            Array.Sort(mat);
            n = 0;
            for (int i = 0; i < mat.Length; i += 1)
            {
                if (mat[i] > s)
                {
                    s = mat[i];
                    n += 1;
                    if (n == 3)
                    {
                        Console.Write("3-й минимум равен:{0}", mat[i]);
                        break;
                    }
                }
            }
        }
    }
}
