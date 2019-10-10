using System;
using System.Collections;
using System.Collections.Generic;
using SerializableLambda;

namespace ExampleRunner
{
    class ExampleObject
    {
        public List<int> DoSomething(int x, double y, string z)
        {
            return new List<int>();
        }

        public string DoSomethingElse()
        {
            return "dadad";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
             var s = SerializableLambdaFactory.Create<ExampleObject, IEnumerable, int, string, double>(
                new SerializableClass<ExampleObject>(), (eo, x, z, y) => eo.DoSomething(x, y, z))
                .SetParameters(1, "adsadasdsa", 303030.30);

             var f = SerializableLambdaFactory.Create<ExampleObject, string>(new SerializableClass<ExampleObject>(),
                 eo => eo.DoSomethingElse());
            Console.WriteLine("Hello World!");
        }
    }
}