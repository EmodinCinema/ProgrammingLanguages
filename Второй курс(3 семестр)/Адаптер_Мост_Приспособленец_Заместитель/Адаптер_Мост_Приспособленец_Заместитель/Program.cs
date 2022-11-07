using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Адаптер__Мост__Приспособленец__Заместитель
{
    class Program
    {

        //Приспособленец
        static void AddSpecialDatabase(FlywieghtFactory ff, string company, string position, string name, string passport) 
        {
            Console.WriteLine();
            Flyweight flyweight = ff.GetFlyweight(new Shared(company, position));
            flyweight.Process(new Unique(name, passport));
        }


        static void Main(string[] args)
        {
            
                bool exod = true;
                Console.WriteLine("Варианты команд:\r\n1-У вас жажда. Вам нужно купить газированную воду" +
                                                    "\r\n2-Хотите получить данные" +
                                                    "\r\n3-Хотите посмтореть учёт представителей разных компаний, которые приехали на ИТ форум в Саратов?" +
                                                    "\r\n4-История открытия страниц вэб сайтов" +
                                                    "\r\n0-Закрыть консоль");
                while (exod)
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            //Клиент
                            Client client = new Client();
                            //Надо купить газировку, чтобы удалить жажду
                            Sparkling_water sparkling_water = new Sparkling_water();
                            //Клиент отправляется в магазин за газировкой
                            client.Shop(sparkling_water);
                            //В магазине нет газировки, поэтому приходиться взять молоко
                            Milk milk = new Milk();
                            //Для этого используем адаптер
                            IProduct milkProduct = new MilkToProductAdapter(milk);
                            //Идём покупать молоко
                            client.Shop(milkProduct);
                            break;
                        case "2":
                            // Отправка данных через Email
                            Console.WriteLine("Отправка данных из Email");
                            Sender sender = new EmailSender(new DataBaseReader());
                            sender.Send();
                            // Отправка данных через Файловую систему
                            Console.WriteLine("Отправка данных через Файловую систему");
                            sender.SetDataReader(new FileReader());
                            sender.Send();
                            //Отправка данных через Telegramm бота
                            Console.WriteLine("Отправка данных через Telegramm бота");
                            sender = new TelegramBot_Sender(new DataBaseReader());
                            sender.Send();
                            break;
                        case "3":
                            Console.WriteLine("ИТ форум");
                            FlywieghtFactory factory = new FlywieghtFactory(new List<Shared>()
                            {
                                new Shared("Microsoft", "Управляющий"),
                                new Shared("Appel", "Iphone-Разработчик"),
                                new Shared("Google", "Android-Разработчик"),
                                new Shared("Microsoft", "Web-Разработчик"),
                                new Shared("Google", "Управляющий"),
                            });
                            factory.ListFlyweights();

                            AddSpecialDatabase(factory,
                                "Google",
                                "Управляющий",
                                "Борис",
                                "942afwr_62");
                            AddSpecialDatabase(factory,
                                "Google",
                                "Android-Разработчик",
                                "Дмитрий",
                                "9jeg82rnfvoo_=a+");

                            factory.ListFlyweights();
                            break;
                        case "4":
                            Console.WriteLine("Открытие страниц");
                            ISite mySite = new SiteProxy(new Site());

                            for (int i=1; i<=3; i++) 
                            {
                                Console.WriteLine(mySite.GetPage(i));
                            }
                            Console.WriteLine(mySite.GetPage(2));
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
            
        }

            //Адаптер(Магазин)
        interface IProduct
        {
            void Buy();
        }

        class Sparkling_water : IProduct
        {
            public void Buy()
            {
                Console.WriteLine("В магазине ищем газированную воду");
            }
        }
        class Client
        {
            public void Shop(IProduct product)
            {
                product.Buy();
            }
        }

        interface Dairy_product
        {
            void RepProd();
        }

        class Milk : Dairy_product
        {
            public void RepProd()
            {
                Console.WriteLine("Берём молоко");
            }
        }

        class MilkToProductAdapter : IProduct
        {

            Milk milk;
            public MilkToProductAdapter(Milk m)
            {
                Console.WriteLine("Газировки нет");
                milk = m;
            }

            public void Buy()
            {
                milk.RepProd();
            }
        }


            //Мост(Пекарня)
        interface IDataReader
        {
            void Read();
        }

        //Имитация чтения данных
        class DataBaseReader : IDataReader
        {
            public void Read()
            {
                Console.WriteLine("Данные из базы данных");
            }
        }

        class FileReader : IDataReader
        {
            public void Read()
            {
                Console.WriteLine("Данные из файла");
            }
        }

        //Отправитель
        abstract class Sender
        {
            protected IDataReader reader;
            public Sender(IDataReader dr)
            {
                reader = dr;
            }
            public void SetDataReader(IDataReader dr)
            {
                reader = dr;
            }
            public abstract void Send();
        }

        class EmailSender : Sender
        {
            public EmailSender(IDataReader dr) : base(dr) { }
            public override void Send()
            {
                reader.Read();
                Console.WriteLine("Отправлены при помощи Email");
            }
        }

        class TelegramBot_Sender : Sender
        {
            public TelegramBot_Sender(IDataReader dr) : base(dr) { }
            public override void Send()
            {
                reader.Read();
                Console.WriteLine("Отправлены при помощи Telegram бота");
            }
        }


            //Приспособленец
        //Общие свойства представителей
        struct Shared
        {
            private string company;
            private string position;

            public Shared(string company, string position)
            {
                this.company = company;
                this.position = position;
            }

            public string Company { get => company; }
            public string Position { get => position; }
        }

        //Уникальные поля
        struct Unique
        {
            private string name;
            private string passport;
            public Unique(string name, string passport)
            {
                this.name = name;
                this.passport = passport;
            }
            public string Name { get => name; }
            public string Passport { get => passport; }
        }

        //Класс легковесов
        class Flyweight
        {
            private Shared shared;
            public Flyweight(Shared shared)
            {
                this.shared = shared;
            }

            //Приём уникальных свойств посетителей
            public void Process(Unique unique) 
            {
                Console.WriteLine("Отображаем новые данные: общее - " + shared.Company + " " 
                                   + shared.Position + " и уникальное - " + unique.Name + " " + unique.Passport);
            }
            public string GetData()
            {
                return shared.Company + " " + shared.Position;
            }
        }
        
        //Храняться и накапливаються общие данные о компании
        class FlywieghtFactory
        {
            private Hashtable flyweights;
            private string GetKey(Shared shared)
            {
                return shared.Company + " " + shared.Position;
            }
            public FlywieghtFactory(List<Shared> shareds)
            {
                flyweights = new Hashtable();
                foreach(Shared shared in shareds)
                {
                    flyweights.Add(GetKey(shared), new Flyweight(shared));
                }
            }
            public Flyweight GetFlyweight(Shared shared)
            {
                string key = GetKey(shared);
                if (!flyweights.Contains(key))
                {
                    Console.WriteLine("Фабрика легковесов: общий объект по ключу " + key + " не найден. Создаём новый.");
                    flyweights.Add(key, new Flyweight(shared));
                }
                else
                {
                    Console.WriteLine("Фабрика легковесов: извлекаем данные из имеющихся записей по ключу " + key + ".");
                }
                return (Flyweight)flyweights[key];
            }

            //Колличество записей в хеш таблице и список этих записей
            public void ListFlyweights()
            {
                int count = flyweights.Count;
                Console.WriteLine("\nФабрика легковесов: всего " + count + " записей:");
                foreach(Flyweight pair in flyweights.Values)
                {
                    Console.WriteLine(pair.GetData());
                }
            }
        }


            //Заместитель
        interface ISite
        {
            string GetPage(int num);
        }
        class Site : ISite
        {
            //Возвращение страницы сайта
            public string GetPage(int num)
            {
                return "Это страница " + num;
            }
        }
        class SiteProxy : ISite
        {
            private ISite site;
            private Dictionary<int, string> cache;

            public SiteProxy(ISite site)
            {
                this.site = site;
                cache = new Dictionary<int, string>();
            }
            public string GetPage(int num)
            {
                string page;
                if (cache.ContainsKey(num))
                {
                    page = cache[num];
                    page = "из кеша: " + page;
                }
                else
                {
                    page = site.GetPage(num);
                    cache.Add(num, page);
                }
                return page;
            }
        }
    }
}
