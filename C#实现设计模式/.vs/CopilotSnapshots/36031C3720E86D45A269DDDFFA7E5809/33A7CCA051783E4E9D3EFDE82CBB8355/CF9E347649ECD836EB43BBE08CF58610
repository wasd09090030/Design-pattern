using System;
using System.Collections.Generic;

namespace 观察者模式
{
    // 观察者接口
    public interface IObserver
    {
        void Update(string message);
    }

    // 主题接口
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }

    // 具体主题
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }

    // 具体观察者
    public class ConcreteObserver : IObserver
    {
        private string name;
        public ConcreteObserver(string name)
        {
            this.name = name;
        }
        public void Update(string message)
        {
            Console.WriteLine($"{name} 收到通知: {message}");
        }
    }

    internal class Observer
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();
            IObserver observer1 = new ConcreteObserver("观察者A");
            IObserver observer2 = new ConcreteObserver("观察者B");

            subject.Attach(observer1);
            subject.Attach(observer2);

            subject.Notify("主题状态已更新！");

            subject.Detach(observer1);
            subject.Notify("只通知观察者B。");
        }
    }
}
