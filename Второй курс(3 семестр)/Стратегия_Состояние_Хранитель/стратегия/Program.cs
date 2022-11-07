using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace стратегия
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("вы теперь лев");
            lion lion = new lion(new nature());
            Console.WriteLine("вы голодны");
            lion.hunting();
            Console.WriteLine("вас поймали");
            Caretaker caretaker = new Caretaker();
            caretaker.Memento = lion.CreateMemento();
            lion.ContextStrategy = new zoo();
            Console.WriteLine("вы голодны");
            lion.hunting();
            Console.WriteLine("шайтан машина из 7 шаров");
            balls.knock();
            Console.WriteLine("вам стало плохо вы отошли от этих шаров");
            if(caretaker.Memento != lion.ContextStrategy)
            Console.WriteLine("вы вспомнили о родных местах");
            Console.ReadLine();

        }
        //стротегия
        public interface Iwhere
        {
            void Algorithm();
        }

        public class zoo : Iwhere
        {
            public void Algorithm()
            {
                Console.WriteLine("ждет пока накормят");
            }
        }

        public class nature : Iwhere
        {
            public void Algorithm()
            {
                Console.WriteLine("охотится");
            }
        }

        public class lion
        {
            public Iwhere ContextStrategy { get; set; }

            public lion(Iwhere _strategy)
            {
                ContextStrategy = _strategy;
            }

            public void hunting()
            {
                ContextStrategy.Algorithm();
            }
            //моменто
                public Iwhere SetMemento(Memento memento)
                {
                    return memento.now;
                }
                public Memento CreateMemento()
                {
                    return new Memento(ContextStrategy);
                }
        }
        //состояние
        class balls
        {
            static public void knock()
            {
                Context context = new Context(new StateA());//один из шаров откланяют
                context.Request(); // тук
                context.Request();  // тук
            }
        }
        abstract class State
        {
            public abstract void Handle(Context context);
        }
        class StateA : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("тук");
                context.State = new StateB();//тук
            }
        }
        class StateB : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("тук");
                context.State = new StateA();//тук
            }
        }

        class Context
        {
            public State State { get; set; }
            public Context(State state)
            {
                this.State = state;
            }
            public void Request()
            {
                this.State.Handle(this);
            }
        }
        //моменто но без орегинаторо это лев
        public class Caretaker
        {
            public Memento Memento { get; set; }
        }
        public class Memento
        {
            public Iwhere now { get; private set; }
            public Memento(Iwhere now)
            {
                this.now = now;
            }
        }
    }
}
