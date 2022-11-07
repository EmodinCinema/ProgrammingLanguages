using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                bool exod = true;
                Console.WriteLine("Варианты команд:\r\n1-Хотите узнать, что говорит кот?" +
                                                    "\r\n2-Хотите узнать, что говорит собака?" +
                                                    "\r\n3-Хотите узнать, что говорит патрульная собака?" +
                                                    "\r\n4-Хотите узнать, что говорит рыба?" +
                                                    "\r\n5-Хотите узнать, что говорит змея?" +
                                                    "\r\n0-следующее задание(консоль очистится при переходе к следуйщему заданию)");
                while (exod)
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Кот говорит: ");
                            Cat cat = new Cat();
                            cat.voice();
                            break;
                        case "2":
                            Console.WriteLine("Собака говорит: ");
                            Dog dog = new Dog();
                            dog.voice();
                            break;
                        case "3":
                            Console.WriteLine("Патрульная собака говорит: ");
                            PatrolDog patroldog = new PatrolDog();
                            patroldog.voice();
                            break;
                        case "4":
                            Console.WriteLine("Рыба говорит: : ");
                            Fish fish = new Fish();
                            fish.voice();
                            break;
                        case "5":
                            Console.WriteLine("Змея говорит: ");
                            Snake snake = new Snake();
                            snake.voice();
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
                Console.WriteLine("Варианты команд:\r\n1-Хотите перевезти пассажира на седане?" +
                                                    "\r\n2-Хотите перевезти пассажира на пикапа?" +
                                                    "\r\n3-Хотите перевезти груз на грузовой машине?" +
                                                    "\r\n4-Хотите перевезти груз на пикапе?" +
                                                    "\r\n0-Закрыть консоль");
                while (exod)
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Пассажир едет на седане");
                            Sedan passangersauto = new Sedan();
                            passangersauto.traffic();
                            break;
                        case "2":
                            Console.WriteLine("Пассажир едет на пикапе");
                            Pickup pickup = new Pickup();
                            pickup.traffic();
                            break;
                        case "3":
                            Console.WriteLine("Груз едет на грузовой машине");
                            Truck truck = new Truck();
                            truck.traffic();
                            break;
                        case "4":
                            Console.WriteLine("Груз едет на пикапе");
                            Pickup pickup2 = new Pickup();
                            pickup2.traffic();
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
    }
}
    abstract class Pet
    {
        protected string naim;
        protected int age;
        protected bool hungry;
        abstract public void voice();
    }
    class Snake:Pet
    {
        public override void voice()
        {
            Console.WriteLine("ссссссссссс");
        }
    }
    class Dog : Pet
    {
        public override void voice()
        {
            Console.WriteLine("гав гав гав");
        }
    }
    class PatrolDog : Pet
    {
        public override void voice()
        {
            Console.WriteLine("ищет наркотические вещества");
        }
    }
    class Cat : Pet
    {
        public override void voice()
        {
            Console.WriteLine("мяу");
        }
    }
    class Fish : Pet
    {
        public override void voice()
        {
            Console.WriteLine("(молчит)");
        }
    }
    interface PassangersAuto
    {
        void traffic();
    }
    interface CargoAuto
    {
         void traffic();
    }
    class Truck:CargoAuto
    {
        public void traffic()
        {
            Console.WriteLine("перевезли груз");
        }
    }
    class Sedan:PassangersAuto
    {
        public void traffic()
        {
            Console.WriteLine("перевезли пасажира");
        }
    }
    class Pickup:PassangersAuto,CargoAuto
    {
        public void traffic()
        {
            Console.WriteLine("перевезли пасажира");
        }
        void CargoAuto.traffic() 
        {
            Console.WriteLine("перевезли груз");
        }
    }
