using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЦепочкаОбязанностей_Посредник_Наблюдатель_Посетитель
{
    class Program
    {
        public static void GiveCommand(IWorker worker, string command)
        {
            string str = worker.Execute(command);
            if (str == "")
            {
                Console.WriteLine(command + " - никто не умеет делать");
            }
            else
            {
                Console.WriteLine(str);
            }
        }

        static void Main(string[] args)
        {
            bool exod = true;
            Console.WriteLine("Варианты команд:\r\n1-Хотите сделать ремонт?" +
                                                "\r\n2-Хотите сделать дизайн?" +
                                                "\r\n3-Хотите купить продукт?" +
                                                "\r\n4-Иеста для посящения" +
                                                "\r\n0-Закрыть консоль");
            while (exod)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Desinger desinger = new Desinger();
                        Carpenters carpenters = new Carpenters();
                        FinishingWorker finishingWorker = new FinishingWorker();

                        desinger.SetNextWorker(carpenters).SetNextWorker(finishingWorker);

                        GiveCommand(desinger, "спроектировать дом");
                        GiveCommand(desinger, "класть кирпич");
                        GiveCommand(desinger, "клеить обои");

                        GiveCommand(desinger, "провести проводку");

                        break;
                    case "2":
                        Designer designer = new Designer();
                        Director director = new Director();

                        Controller mediator = new Controller(designer, director);

                        director.GiveCommand("Проектировать");

                        Console.WriteLine();

                        designer.ExecuteWork();

                        break;
                    case "3":
                        //Продукт
                        Product product = new Product(400);

                        //Оптовый покупатель наблюдает за продуктом
                        Wholesale wholesale = new Wholesale(product);
                        //Покупатель наблюдает за продуктом
                        Buyer buyer = new Buyer(product);

                        product.ChangePrice(320);
                        product.ChangePrice(280);
                        break;
                    case "4":
                        //Список мест, где желает побывать
                        List<IPlace> places = new List<IPlace>()
                        {
                            new Zoo(),
                            new Cinema(),
                            new Circus()
                        };

                        foreach(IPlace place in places)
                        {
                            HolidayMaker visitor = new HolidayMaker();
                            place.Accept(visitor);
                            Console.WriteLine(visitor.value);
                        }

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
    }
        //Цепочка обязанностей
    interface IWorker
        {
            IWorker SetNextWorker(IWorker worker);
            string Execute(string command);
        }

    abstract class AbsWorker : IWorker
        {
            private IWorker nextWorker;
            public AbsWorker()
            {
                nextWorker = null;
            }
            public IWorker SetNextWorker(IWorker worker)
            {
                nextWorker = worker;
                return worker;
            }

            public virtual string Execute(string command)
            {
                if (nextWorker != null)
                {
                    return nextWorker.Execute(command);
                }
                return string.Empty;
            }
        }

    class Desinger : AbsWorker
        {
            public override string Execute(string command)
            {
                if(command=="спроектировать дом")
                {
                    return "Проектировщик выполнил команду: " + command;
                }
                else
                {
                    return base.Execute(command);
                }
            }
        }

    class Carpenters : AbsWorker
        {
            public override string Execute(string command)
            {
                if (command=="класть кирпич")
                {
                    return "Плотник выполнил команду: " + command;
                }
                else
                {
                    return base.Execute(command);
                }
            }
        }   class FinishingWorker : AbsWorker
        {
            public override string Execute(string command)
            {
                if (command == "клеить обои")
                {
                    return "Рабочий внутреней отделки выполнил команду: " + command;
                }
                else
                {
                    return base.Execute(command);
                }
            }
        }


        //Посредник
    interface IMediator
    {
        void Notify(Employee emp, string msg);
    }

    abstract class Employee
    {
        protected IMediator mediator;
        public Employee(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public void SetMediator(IMediator med)
        {
            this.mediator = med;
        }
    }

    class Designer : Employee
    {
        private bool isWorking;
        public Designer(IMediator med = null) : base(med) { }
        public void ExecuteWork()
        {
            Console.WriteLine("<-Дизайнер в работе");
            mediator.Notify(this, "дизайнер проектирует...");
        }
        public void SetWork(bool state)
        {
            isWorking = state;
            if (state)
            {
                Console.WriteLine("<-Дизайнер освобождён от работы");
            }
            else
            {
                Console.WriteLine("< -Дизайнер занят");
            }
        }

    }
    

    class Director : Employee
    {
        private string text;
        public Director(IMediator mediator = null) : base(mediator) { }

        public void GiveCommand(string txt)
        {
            text = txt;
            if (txt == "")
            {
                Console.WriteLine("->Директор знает, что дизайнер уже работает");
            }
            else
            {
                Console.WriteLine("->Директор дал команду");
            }
            mediator.Notify(this, text);
        }
    }


    class Controller : IMediator
    {
        private Designer designer;
        private Director director;

        public Controller(Designer designer, Director director)
        {
            this.designer = designer;
            this.director = director;
            designer.SetMediator(this);
            director.SetMediator(this);
        }
        public void Notify(Employee emp, string msg)
        {
            if (emp is Director dir)
            {
                if (msg == "")
                {
                    designer.SetWork(false);
                }
                else
                {
                    designer.SetWork(true);
                }
            }
            if (emp is Designer des)
            {
                if (msg == "дизайнер проектирует...")
                {
                    director.GiveCommand("");
                }
            }
        }
    }

        
        //Наблюдатель
    interface IObserver
    {
        void Update(double p);
    }
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void Notify();
    }

    class Product:IObservable
    {
        private List<IObserver> observers;
        private double price;
        public Product(double p)
        {
            price = p;
            observers = new List<IObserver>();
        }
        public void ChangePrice(double p)
        {
            price = p;
            Notify();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
        public void Notify()
        {
            foreach(IObserver o in observers.ToList())
            {
                o.Update(price);
            }
        }
    }
    class Wholesale : IObserver
    {
        private IObservable product;
        public Wholesale(IObservable obj)
        {
            product = obj;
            obj.AddObserver(this);
        }
        public void Update(double p)
        {
            if (p < 30)
            {
                Console.WriteLine("Оптовик закупил товар по цене " + p);
                product.RemoveObserver(this);
            }
        }
    }

    class Buyer : IObserver
    {
        private IObservable product;
        public Buyer(IObservable obj)
        {
            product = obj;
            obj.AddObserver(this);
        }
        public void Update(double p)
        {
            if (p < 350)
            {
                Console.WriteLine("Покупатель приобрёл товар по цене " + p);
                product.RemoveObserver(this);
            }
        }
    }

        
        //Посетитель
    interface IVisitor
    {
        void Visit(Zoo zoo);
        void Visit(Cinema cinema);
        void Visit(Circus circus);
    }
    
    interface IPlace
    {
        void Accept(IVisitor v);
    }

    class Zoo : IPlace
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
    class Cinema : IPlace
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
    class Circus : IPlace
    {
        public void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }

    class HolidayMaker : IVisitor
    {
        public string value;
        public void Visit(Zoo zoo)
        {
            value = "Слон в зоопарке";
        }
        public void Visit(Cinema cinema)
        {
            value = "Кино - Властелин колец";
        }
        public void Visit(Circus circus)
        {
            value = "Клоун в цирке";
        }
    }
}
