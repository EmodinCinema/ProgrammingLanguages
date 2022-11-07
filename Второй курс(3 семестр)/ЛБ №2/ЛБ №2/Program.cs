using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace лаба_2
{
    class Program
    {
        static void Main()
        {
            bool exod = true;
            Console.WriteLine("создадим лошадь");
            Horse hor = new Horse();
            Console.WriteLine("информация о лошадь");
            hor.inf();
            Console.WriteLine("создадим пегаса: ");
            Pegas peg=new Pegas();
            Console.WriteLine("информация о пегаса");
            peg.inf();
            Console.WriteLine("варианты команд:\r\n1-убить и завести нового коня" +
                                                "\r\n2-иформация о коне" +
                                                "\r\n3-убить и завести новога пигаса" +
                                                "\r\n4-информация о пегасе" +
                                                "\r\n0-следующее задание(консоль очистится при переходе к следуйщему заданию)");
            while (exod)
            {
                switch(Console.ReadLine())
                {
                    case "1":
                        hor = new Horse();
                    break;
                    case "2":
                        hor.inf();
                    break;
                    case "3":
                        peg = new Pegas();
                    break;
                    case "4":
                        peg.inf();
                    break;
                    case "0":
                        exod = false;
                    break;
                    default:
                        Console.WriteLine("нет такой команды, попробуйте ввести данные снова");
                        break;
                }
            }
            exod = true;
            Console.Clear();
            Console.WriteLine("создадим питомца, вид кота: ");
            Cat cat=new Cat();
            Console.WriteLine("информация о питомце");
            cat.inf();
            Console.WriteLine("создадим питомца, вид собака: ");
            Dog dog = new Dog();
            Console.WriteLine("информация о питомце");
            dog.inf();
            Console.WriteLine("варианты команд:\r\n1-убить и завести нового питомца, вид кот" +
                                                "\r\n2-информацая о питомце, вид кот" +
                                                "\r\n3-убить и завести нового питомца, вид собака" +
                                                "\r\n4-информацая о питомце, вид собака" +
                                                "\r\n0-следующее задание(консоль очистится при переходе к следуйщему заданию)");
            while (exod)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        cat = new Cat();
                        break;
                    case "2":
                        cat.inf();
                        break;
                    case "3":
                        dog = new Dog();
                        break;
                    case "4":
                        dog.inf();
                        break;
                    case "0":
                        exod = false;
                        break;
                    default:
                        Console.WriteLine("нет такой команды, попробуйте ввести данные снова");
                        break;
                }
            }
            exod = true;
            Console.Clear();
            Console.WriteLine("узнаем про эволюцию");
            Human human = new Human();
            Console.WriteLine("варианты команд:\r\n1-повторить информацию о эволюции" +
                                                "\r\n0-закрыть програму");
            while (exod)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        human = new Human();
                        break;
                    case "0":
                        exod = false;
                        break;
                    default:
                        Console.WriteLine("нет такой команды, попробуйте ввести данные снова");
                        break;
                }
            } 
        }
    }
    
    class Horse
    {
        protected string naim;
        protected bool wings;
        
        public Horse()
        {
            wings = false;
            Console.Write("введите имя: ");
            naim = Console.ReadLine();

        }
        public void inf()
        {
            Console.WriteLine("теперь его зовут " + naim);
            Ran();
            flay();
        }
        protected void Ran ()
        {
            Console.WriteLine(naim + " скачет");
        }
        protected void flay()
        {
            if(wings)
            {
                Console.WriteLine(naim + " летит ,парит в небе");
            }
            else
            {
                Console.WriteLine(naim + " не летит");
            }            
        }
    }
    class Pegas:Horse
    {
         public Pegas()
        {
            wings = true;
        }
    }
    class Pet
    {
        protected string naim;
        protected int age;
        protected bool sex;
        protected double weight;
        protected Pet()
        {
            bool exod = true;
            Console.Write("введите имя петомца: ");
            naim = Console.ReadLine();
            Console.WriteLine("введите пол петомца: " +
                                                    "\r\nм - мальчик" +
                                                    "\r\nд - девочка");
            while(exod)
            {

                switch (Console.ReadLine())
                {
                    case "м":
                        sex = false;
                        exod = false;
                        break;
                    case "д":
                        sex = true;
                        exod = false;
                        break;
                    default:
                        Console.WriteLine("он мальчик или девочка?");
                        break;
                }
            }
            if(sex)
            {
                Console.Write("возраст: ");
                while (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("это не возвраст, пропробуйте ввести снова ");
                }
                Console.Write("вес: ");
                while (!double.TryParse(Console.ReadLine(), out weight))
                {
                    Console.WriteLine("это не вес, пропробуйте ввести снова ");
                }
            }
            else
            {
                Console.Write("Возраст: ");
                while (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("это не возвраст, пропробуйте ввести снова ");
                }
                Console.Write("вес: ");
                while (!double.TryParse(Console.ReadLine(), out weight))
                {
                    Console.WriteLine("это не вес, пропробуйте ввести снова ");
                }
            }
        }
    }
    class Cat:Pet
    {
        public Cat()
        { }
        public void inf()
        {
            if(sex)
            {
                Console.WriteLine("кошка по имени " + naim + ", возраст " + age + " год и вес " + weight + " кг");
            }else
            {
                Console.WriteLine("кот по имени " + naim + ", возраст " + age + " год и вес " + weight + " кг");
            }
        }
    }
    class Dog : Pet
    {
        public Dog()
        { }
        public void inf()
        {
            if (sex)
            {
                Console.WriteLine("Собака(девочка) по имени " + naim + ", возраст " + age + " год и вес " + weight + " кг");
            }
            else
            {
                Console.WriteLine("Собака(мальчик) по имени " + naim + ", возраст " + age + " год и вес " + weight + " кг");
            }
        }
    }
    class Fish
    {
        public Fish ()
        {
            Console.WriteLine("от рыб мы унаследовали внутренние органы, но не жабры");
        }
    }
    class Animal:Fish
    {
        public Animal()
        {
            Console.WriteLine("от животных мы унаследовали волосеной покров, но не когти и клыки");
        }
    }
    class Ape:Animal
    {
        public Ape()
        {
            Console.WriteLine("от обезьян мы унаследовали геномы, но не кокти и клыки");
        }
    }
    class Human:Ape
    {
        public Human()
        {
            Console.WriteLine("следующим видам мы передадим нечто своё");
        }
    }
}
