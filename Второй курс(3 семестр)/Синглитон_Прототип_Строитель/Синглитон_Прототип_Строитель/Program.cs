using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace синглитон
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("где сердце?");
            Hard.where();
            Console.WriteLine("начинаем смотреть аниме");
            naruto Uzumaki = new naruto();
            for(int i=0;i<6 ;i++ )
            {
                Uzumaki.shadow_cloning();
            }
            Console.WriteLine("бог решил дать вам возможность создать новый вид пауков");
            god god = new god();
            god.game().inf();
            Console.ReadLine();
        }
        //синглитон
        class Hard
        {
            private static Hard instance;

            private void knock()
            {
                Console.WriteLine("тук-тук");
            }

            private Hard()
            { }

            public static Hard where()
            {
                if (instance == null)
                    instance = new Hard();
                instance.knock();
                return instance;
            }
        }
        //прототип
        class naruto
        {
            private const int max_clon = 5;
            int nam_clon = 0;
            public void shadow_cloning()
            {
                Prototype prototype = new ConcretePrototype1(nam_clon);
                if (nam_clon != max_clon)
                {
                    Console.WriteLine("я наруто утзумаки и теперь меня на 1 больше");
                    Prototype clone = prototype.Clone();
                    nam_clon++;
                }
                else
                {
                    Console.WriteLine("я наруто утзумаки и я стану хокаге");
                }

            }
        }

        abstract class Prototype
        {
            public int Id { get; private set; }
            public Prototype(int id)
            {
                this.Id = id;
            }
            public abstract Prototype Clone();
        }

        class ConcretePrototype1 : Prototype
        {
            public ConcretePrototype1(int id)
            : base(id)
            { }
            public override Prototype Clone()
            {
                return new ConcretePrototype1(Id+1);
            }
        }
        //строитель
        class god
        {
            public Spider  game()
            {
                creator angel = new Angel();
                glas nev_spider = new glas(angel);
                nev_spider.Construct();
                Spider spider = angel.GetResult();
                return spider;
            }
        }
        class glas
        {
            creator angel;
            public glas(creator angel)
            {
                this.angel = angel;
            }
            public void Construct()
            {
                angel.color();
                angel.feature();
                angel.poison();
            }
        }

        abstract class creator
        {
            public abstract void color();
            public abstract void feature();
            public abstract void poison();
            public abstract Spider GetResult();
        }

        class Spider
        {
            List<object> parts = new List<object>();
            public void Add(string part)
            {
                parts.Add(part);
            }
            public void inf()
            {
                Console.WriteLine("ваш паук");
                foreach(object x in parts)
                {
                    Console.WriteLine(x);
                }
            }
        }

        class Angel : creator
        {
            Spider product = new Spider();
            public override void color()
            {
                Console.WriteLine("какой цвет(напиши и энтор)");
                product.Add(Console.ReadLine());
            }
            public override void feature()
            {
                Console.WriteLine("какие ужасы может сделать ваш поук(напиши и энтор)");
                product.Add(Console.ReadLine());
            }
            public override void poison()
            {
                Console.WriteLine("он ядавит(напиши и энтор)");
                product.Add(Console.ReadLine());
            }
            public override Spider GetResult()
            {
                return product;
            }
        }
    }
}
