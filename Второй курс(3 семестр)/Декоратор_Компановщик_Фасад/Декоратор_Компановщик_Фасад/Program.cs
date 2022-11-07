using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Декоратор_Компановщик_Фасад
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exod = true;
            Console.WriteLine("Варианты команд:\r\n1-Хотите зашифровать данные?" +
                                                "\r\n2-Меню программы" +
                                                "\r\n3-Маркетплейс" +
                                                "\r\n0-Закрыть консоль");
            while (exod)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        IProcessor transmitter = new Transmitter("12345");
                        transmitter.Process();
                        Console.WriteLine();

                        //Устройства кодирования данных
                        Shell hammingCoder = new HammingCoder(transmitter);
                        hammingCoder.Process();
                        Console.WriteLine();

                        Shell encoder = new Encryptor(hammingCoder);
                        encoder.Process();
                        break;
                    case "2":
                        // Меню
                        Console.WriteLine("Меню");
                        Item file = new DropDownItem("Файл->");

                        Item create = new DropDownItem("Создать->");
                        Item open = new DropDownItem("Открыть->");
                        Item exit = new DropDownItem("Выход->");

                        file.Add(create);
                        file.Add(open);
                        file.Add(exit);

                        Item project = new ClickabelItem("Проект...");
                        Item repository = new ClickabelItem("Репозиторий...");

                        create.Add(project);
                        create.Add(repository);

                        Item solution = new ClickabelItem("Решение...");
                        Item folder = new ClickabelItem("Папка...");

                        open.Add(solution);
                        open.Add(folder);

                        file.Display();
                        Console.WriteLine();

                        file.Remove(create);

                        file.Display();

                        break;
                    case "3":
                        Console.WriteLine("Маркетплейс");
                        MarketPlace marketPlace = new MarketPlace();

                        marketPlace.ProductReceippt();

                        Console.WriteLine(new string('-', 20));

                        marketPlace.ProductRelease();
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

            //Декоратор
        interface IProcessor
        {
            void Process();
        }
        class Transmitter : IProcessor
        {
            private string data;
            public Transmitter(string data)
            {
                this.data = data;
            }
            public void Process()
            {
                Console.WriteLine("Данные " + data + " переданные по каналу связи");
            }
        }
        abstract class Shell : IProcessor 
        {
            protected IProcessor processor;
            public Shell(IProcessor pr)
            {
                processor = pr;
            }
            public virtual void Process()
            {
                processor.Process();
            }
        }
        class HammingCoder : Shell
        {
            public HammingCoder(IProcessor pr) : base(pr) { }
            public override void Process()
            {
                Console.WriteLine("Наложение помехоустойчивый код Хамминга->");
                processor.Process();
            }
        }
        class Encryptor : Shell
        {
            public Encryptor(IProcessor pr) : base(pr) { }
            public override void Process()
            {
                Console.Write("Шифрование данных");
                processor.Process();
            }
        }

            //Компановщик
        abstract class Item
        {
            protected string itemName;
            protected string ownerName;
            public void SetOwner(string o)
            {
                ownerName = o;
            }
            public Item(string name)
            {
                itemName = name;
            }
            public virtual void Add(Item subItem) { }
            public virtual void Remove(Item subItem) { }
            public abstract void Display();
        }

        class ClickabelItem : Item
        {
            public ClickabelItem(string name) : base(name) { }
            public override void Add(Item subItem)
            {
                throw new Exception();
            }
            public override void Remove(Item subItem)
            {
                throw new Exception();
            }
            public override void Display()
            {
                Console.WriteLine(itemName);
            }
        }

        class DropDownItem : Item
        {
            private List<Item> children;
            public DropDownItem(string name) : base(name)
            {
                children = new List<Item>();
            }
            public override void Add(Item subItem)
            {
                subItem.SetOwner(this.itemName);
                children.Add(subItem);
            }
            public override void Remove(Item subItem)
            {
                children.Remove(subItem);
            }
            public override void Display()
            {
                foreach(Item item in children)
                {
                    if (ownerName != null)
                    {
                        Console.Write(ownerName + itemName);
                    }
                    item.Display();
                }
            }
        }

            //Фасад
        //Отдел по приёму товаров от производителя
        class ProviderCommunication
        {
            public void Receive()
            {
                Console.WriteLine("Получение продукции от производителей");
            }
            public void Payment()
            {
                Console.WriteLine("Оплата постановщику с удержанием комиссии за продажу продукции");
            }
        }
        class Site
        {
            //Размещает продукцию на сайте
            public void Placement()
            {
                Console.WriteLine("Размещение на сайте");
            }
            public void Del()
            {
                Console.WriteLine("Удаление с сайта");
            }
        }
        class Database
        {
            public void Insert()
            {
                Console.WriteLine("Запись в базу данных");
            }
            public void Del()
            {
                Console.WriteLine("Удаление из базы данных");
            }
        }
        class MarketPlace
        {
            private ProviderCommunication providerCommunication;
            private Site site;
            private Database database;

            public MarketPlace()
            {
                providerCommunication = new ProviderCommunication();
                site = new Site();
                database = new Database();
            }

            public void ProductReceippt()
            {
                providerCommunication.Receive();
                site.Placement();
                database.Insert();
            }

            public void ProductRelease()
            {
                providerCommunication.Payment();
                site.Del();
                database.Del();
            }
        }
    }
}
