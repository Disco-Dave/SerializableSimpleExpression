using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SerializableLambda;

namespace ExampleRunner
{
    class ExampleObject
    {
        public List<int> DoSomething(int x, double y, string z)
        {
            return new List<int>() { 1, 2, 3, 4 };
        }

        public string DoSomethingElse()
        {
            return "dadad";
        }

        public string GenericSomething<T>()
        {
            return nameof(T);
        }
    }

    class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, Func<IServiceLocator, dynamic>> container = new Dictionary<Type, Func<IServiceLocator, dynamic>>();

        public T Get<T>()
        {
            return this.container[typeof(T)](this);
        }

        public ServiceLocator Register<T>(Func<IServiceLocator, T> service)
        {
            this.container.Add(typeof(T), sl => (dynamic) service(sl));
            
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var locator = new ServiceLocator().Register(_ => new ExampleObject());

            var s = SerializableLambdaFactory.Create<ExampleObject, IEnumerable, int, string, double>(
               (eo, x, z, y) => eo.DoSomething(x, y, z))
               .SetParameters(1, "adsadasdsa", 303030.30);

            var sReturn = s.Execute(locator);

            var f = SerializableLambdaFactory.Create<ExampleObject, string>(eo => eo.DoSomethingElse());
            var fReturn  = f.Execute(locator);
        }
    }
}