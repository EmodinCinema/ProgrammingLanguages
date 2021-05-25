using System;

namespace ЛБ__2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
                Console.Write("a=");
                int.TryParse(Console.ReadLine(), out int a);
                Console.Write("b=");
                int.TryParse(Console.ReadLine(), out int b);
                Console.WriteLine("{0}+{1}={2}", a, b, a + b);
                Console.ReadLine();


                Console.Write("c=");
                int.TryParse(Console.ReadLine(), out int c);
                Console.Write("d=");
                int.TryParse(Console.ReadLine(), out int d);
                Console.Write("{0}+{1}={1}+{0}", c, d, c + d);
                Console.ReadLine();

                Console.Write("e=");
                int.TryParse(Console.ReadLine(), out int e);
                Console.Write("f=");
                int.TryParse(Console.ReadLine(), out int f);
                Console.Write("g=");
                int.TryParse(Console.ReadLine(), out int g);
                Console.WriteLine("{0}+{1}+{2}={3}", e, f, g, e + f + g);
                Console.ReadLine();

                Console.Write("h=");
                Double.TryParse(Console.ReadLine(), out double h);
                Console.Write("j=");
                Double.TryParse(Console.ReadLine(), out double j);
                Console.WriteLine("{0}*{1}={2:f1}", h, j, h * j);
                Console.ReadLine();

               
                Console.Write("k=");
                Double.TryParse(Console.ReadLine(), out double k);
                Console.Write("l=");
                Double.TryParse(Console.ReadLine(), out double l);
                Console.WriteLine("{0}/{1}={2:f3}", k, l, k / l);
                Console.ReadLine();


                Console.Write("i=");
                Double.TryParse(Console.ReadLine(), out double i);
                Console.Write("o=");
                Double.TryParse(Console.ReadLine(), out double o);
                Console.Write("u=");
                Double.TryParse(Console.ReadLine(), out double u);
                Console.WriteLine("({0}+{1})+{2}={0}+({1}+{2})", i, o, u, i + o + u);
                Console.ReadLine();
            
        }
    }
}
