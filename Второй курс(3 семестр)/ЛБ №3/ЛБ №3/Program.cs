using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_3
{
    class Program
    {
        static void Main()
        {
            cat cat = new cat();
            whale whale = new whale();
            dog dog = new dog();
            cat.getNaim();
            whale.getNaim();
            object Child = new object();
            bool f = true;
            while(true && f)
            {
                Console.WriteLine("кого создать: " +
                                                "\r\n 1-кошка" +
                                                "\r\n 2-собака" +
                                                "\r\n 0-проверять дальше");
                switch(Console.ReadKey().KeyChar)
                {
                    case '1':
                        Child = cat.getChild();
                        break;
                    case '2':
                        Child = dog.getChild();
                        break;
                    case '0':
                        f = false;
                        break;
                }
            }
            Child=cat.getChild();
            
            Console.ReadKey();
        }
        public void opr(Object obe)
        {

            if (obe.GetType() == typeof(cat))
                Console.WriteLine("это кот");
            else if (obe.GetType() == typeof(bird))
                Console.WriteLine("это птица");
            else if (obe.GetType() == typeof(dog))
                Console.WriteLine("это собака");
            else if (obe.GetType() == typeof(lamp))
                Console.WriteLine("это лампа");
        }
        public void print(int x)
        {
            Console.WriteLine(x);
        }
        public void print(string x)
        {
            Console.WriteLine(x);
        }
        public void print(double x)
        {
            Console.WriteLine(x);
        }
        public void print(byte x)
        {
            Console.WriteLine(x);
        }
        public void print(uint x)
        {
            Console.WriteLine(x);
        }
        public static int min(int x, int y)
        {
            if(x>y)
            {
                return y;
            }
            else
            {
                return x;
            }
        }
        public static long min(long x, long y)
        {
            if (x > y)
            {
                return y;
            }
            else
            {
                return x;
            }
        }
        public static double min(double x, double y)
        {
            if (x > y)
            {
                return y;
            }
            else
            {
                return x;
            }
        }
        public static int max(int x, int y)
        {
            if (x < y)
            {
                return y;
            }
            else
            {
                return x;
            }
        }
        public static long max(long x, long y)
        {
            if (x < y)
            {
                return y;
            }
            else
            {
                return x;
            }
        }
        public static double max(double x, double y)
        {
            if (x < y)
            {
                return y;
            }
            else
            {
                return x;
            }
        }
    }
    class lamp
    { }
    class bird
    { }
    class whale:cat
    {
        public override void getNaim()
        {
            Console.WriteLine("я не кот, я кит");
        }
    }
    class cat
    {
        public virtual void getNaim()
        {
            Console.WriteLine("я кот");
        }
        public virtual Object getChild()
        {
            cat Child = new cat();
            return Child;
        }
    }
    class dog:cat
    {
        public override Object getChild()
        {
            dog Child = new dog();
            return Child;
        }
    }
}
