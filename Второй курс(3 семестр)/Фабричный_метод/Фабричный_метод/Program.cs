using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фабрики
{
    class Program
    {
        static void Main(string[] args)
        {
            seamstress seamstress = new seamstress();
            machine machine = new machine();
            Console.WriteLine("швия делает рубашки\nа станок свитеры\nвведите сколько рубашек надо (энтор) сколько свитеров");
            int i;
            int.TryParse(Console.ReadLine(),out i);
            int k;
            int.TryParse(Console.ReadLine(), out k);
            for(;i!=0;i--)
            {
                seamstress.sew();
            }
            for (; k != 0; k--)
            {
                machine.sew();
            }
            Console.WriteLine("-нам нужен римонт!\n-сказала жена\nвыберите таджиков\n1-Армен\n2-Джамшут");
            int.TryParse(Console.ReadLine(), out i);
            if(i>1)
            {
                for (; k != 5; k++)//k-условная площадь квартиры ремонт не за один день делают а в пару дней по куску и вот весь ремонт готов
                {
                    Client I = new Client(new OAO_Dgamhyt());
                    I.Rurepair();
                }
                Console.WriteLine("ремонт всё");
            }else
            {
                for (; k != 5; k++)
                {
                    Client I = new Client(new OAO_Armen());
                    I.Rurepair();
                }
                Console.WriteLine("ремонт всё");
            }
            Console.ReadLine();
        }
        abstract class Product
        { }

        class shirt : Product
        {
            public shirt()
            {
                Console.WriteLine("хорошая рубашка");
            }
        }

        class sweater : Product
        {
        public sweater()
            {
                Console.WriteLine("хороший свитер");
            }
        }

        abstract class Creator
        {
            public abstract Product sew();
        }

        class seamstress : Creator
        {
            public override Product sew() { return new shirt(); }
        }

        class machine : Creator
        {
            public override Product sew() { return new sweater(); }
        }
        //абстрактная фабрика
        abstract class wallpaper
        {
            public abstract void glue();
        }

        abstract class floor
        {
            public abstract void lodges();
        }

        class wallpaper_polka : wallpaper
        {
            public override void glue()
            {
                Console.WriteLine("часть ваших обоев в горошек");
            }
        }

        class floor_wooden : floor
        {
            public override void lodges()
            {
                Console.WriteLine("часть вашего пола деревянный");
            }
        }

        class wallpaper_striped : wallpaper
        {
            public override void glue()
            {
                Console.WriteLine("часть ваших обоев в полосочку");
            }
        }

        class floor_stone : floor
        {
            public override void lodges()
            {
                Console.WriteLine("часть вашего пола каменная плитка");
            }
        }
        abstract class construction_company
        {
            public abstract wallpaper glue_wallpaper();
            public abstract floor lodges_floor();
        }
        class OAO_Armen : construction_company
        {
            public override wallpaper glue_wallpaper()
            {
                return new wallpaper_polka();
            }

            public override floor lodges_floor()
            {
                return new floor_wooden();
            }
        }
        class OAO_Dgamhyt : construction_company
        {
            public override wallpaper glue_wallpaper()
            {
                return new wallpaper_striped();
            }

            public override floor lodges_floor()
            {
                return new floor_stone();
            }
        }



        class Client
        {
            private wallpaper my_wallpaper;
            private floor my_floor;

            public Client(construction_company guest_worker)
            {
                my_floor = guest_worker.lodges_floor();
                my_wallpaper = guest_worker.glue_wallpaper();
            }
            public void Rurepair()
            {
                my_floor.lodges();
                my_wallpaper.glue();
            }
        }
    }
}
