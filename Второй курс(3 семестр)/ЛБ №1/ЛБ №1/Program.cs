using System;
using System.Runtime.CompilerServices;

namespace лаба_1
{
    class Program
    {
        static void Main()
        {
            Circle one = new Circle(0, 0, 0);
            Circle two = new Circle(0, 0, 0);
            int x, y, r;
            bool t = true;
            bool c_1 = false;
            bool c_2 = false;
            Console.WriteLine("Уважаемый пользователь:");
            while (true && t)
            {
                Console.WriteLine("Действия с программой:\r\n1-создать 1-ый условный круг с задаными координатами и радиусом" +
                                                        "\r\n2-создать 2-ой условный круг с задаными координатами и радиусом" +
                                                        "\r\n3-переместить 1-ый круг случайные координаты" +
                                                        "\r\n4-переместить 2-ой круг в случайные координаты" +
                                                        "\r\n5-узнать длину 1-ого круга" +
                                                        "\r\n6-узнать длину 2-ого круга" +
                                                        "\r\n7-узнать растояние между центрами окружностей(обязательно создать 1-ый и 2-ой круг при помощи соответствуещих команд)" +
                                                        "\r\n8-в скольки точках 1-ая и 2-ая окружность пересекаються\r\n(обязательно создать круг 1 и 2 при помощи соответствуещих команд)" +
                                                        "\r\n0-закрыть программу");
                switch (Console.ReadLine())
                {
                    case "0":
                        t = false;
                        break;
                    case "1":
                        Console.Clear();
                        Console.WriteLine("введите целое число, координату x, для кругов в диапозоне от -99 до 99");
                        while (!int.TryParse(Console.ReadLine(), out x))
                            Console.WriteLine("ошибка ввода, попробуйте ввести снова");
                        Console.WriteLine("введите целое число, координату y, для кругов в диапозоне от -99 до 99");
                        while (!int.TryParse(Console.ReadLine(), out y))
                            Console.WriteLine("ошибка ввода, попробуйте ввести снова");
                        Console.WriteLine("введите целое число, r-радиус, для круга");
                        while (!int.TryParse(Console.ReadLine(), out r))
                            Console.WriteLine("ошибка ввода, попробуйте ввести снова");
                        one = new Circle(x, y, r);
                        one.inf();
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        c_1 = true;
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("введите целое число, координату x, для кругов в диапозоне от -99 до 99");
                        while (!int.TryParse(Console.ReadLine(), out x))
                            Console.WriteLine("ошибка ввода, попробуйте ввести снова");
                        Console.WriteLine("введите целое число, координату y, для кругов в диапозоне от -99 до 99");
                        while (!int.TryParse(Console.ReadLine(), out y))
                            Console.WriteLine("введите целое число, r-радиус, для круга");
                        Console.WriteLine("ошибка ввода, попробуйте ввести снова");
                        while (!int.TryParse(Console.ReadLine(), out r))
                            Console.WriteLine("ошибка ввода, попробуйте ввести снова");
                        two = new Circle(x, y, r);
                        two.inf();
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        c_2 = true;
                        break;
                    case "3":
                        Console.Clear();
                        if (c_1)
                        {
                            one.ranbox();
                        }
                        else
                        {
                            Console.WriteLine("нет данных");
                        }
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        if (c_2)
                        {
                            two.ranbox();
                        }
                        else
                        {
                            Console.WriteLine("нет данных");
                        }
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        if (c_2)
                        {
                            two.length();
                        }
                        else
                        {
                            Console.WriteLine("нет данных о круге");
                        }
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        if (c_1)
                        {
                            one.length();
                        }
                        else
                        {
                            Console.WriteLine("нет данных о круге");
                        }
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        Console.Clear();
                        if (c_1 && c_2)
                        {
                            Console.WriteLine("растояние между центрами окружностей примерно " + Math.Ceiling(one.distance(one, two)));
                        }
                        else
                        {
                            Console.WriteLine("нет созданых кругов");
                        }
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":
                        Console.Clear();
                        if (c_1 && c_2)
                        {
                            one.touch(one, two);
                        }
                        else
                        {
                            Console.WriteLine("не хватает кругов");
                        }
                        Console.WriteLine("нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("такой команды не существует. нажмите любую клавишу, чтобы продолжить");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
    class Circle
    {
        Random rnt = new Random();
        private int r, x, y;
        public Circle(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        int for_Z(int t)
        {
            if (t == 1)
            {
                return x;
            }
            else if (t == 2)
            {
                return y;
            }
            else
            {
                return r;
            }
        }
        public void inf()
        {
            Console.WriteLine("координаты круга у={0} x={1}", y, x);
            Console.WriteLine("радиус " + r);
        }
        public void length()
        {
            Console.WriteLine(2 * Math.PI * r);
        }
        public void ranbox()
        {
            x = rnt.Next(-99, 100);
            y = rnt.Next(-99, 100);
            inf();
        }
        public double distance(Circle circle_1, Circle circle_2)
        {
            return Math.Sqrt(Math.Pow(circle_1.for_Z(1) - circle_2.for_Z(1), 2) + Math.Pow(circle_1.for_Z(2) - circle_2.for_Z(2), 2));
        }
        public void touch(Circle circle_1, Circle circle_2)
        {
            if (distance(circle_1, circle_2) == circle_1.for_Z(0) + circle_2.for_Z(0))
            {
                Console.WriteLine("окружности пересекаютя в одной точке");
            }
            else if (distance(circle_1, circle_2) > Math.Sqrt(circle_1.for_Z(0) - circle_2.for_Z(0))&& distance(circle_1, circle_2) < circle_1.for_Z(0) + circle_2.for_Z(0))
            {
                Console.WriteLine("окружности пересекаютя в двух точках");
            }
            else if (distance(circle_1, circle_2) == Math.Sqrt(circle_1.for_Z(0) - circle_2.for_Z(0)))
            {
                Console.WriteLine("окружности пересекаютя в одной точке");
            }
            else
            {
                Console.WriteLine("окружности не пересекаются");
            }
        }
    }
}