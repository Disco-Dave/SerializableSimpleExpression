using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using SerializableSimpleExpression.ExpressionParsers;
using SerializableSimpleExpression.ServiceLocator;
using Xunit;

namespace SerializableSimpleExpression.Test
{
    class ExampleObject
    {
        public List<int> DoSomething(int x, double y, string z)
        {
            return new List<int>() { 1, 2, 3, 4 };
        }

        public string DoSomethingElse()
        {
            return "asjdklasdjalksd";
        }

        public string GenericSomething<T>()
        {
            return typeof(T).ToString();
        }
    }
    
    class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, Func<IServiceLocator, dynamic>> container = new Dictionary<Type, Func<IServiceLocator, dynamic>>();

        public T Get<T>() where T : class
        {
            return this.container[typeof(T)](this);
        }

        public ServiceLocator Register<T>(Func<IServiceLocator, T> service)
        {
            this.container.Add(typeof(T), sl => (dynamic) service(sl));
            
            return this;
        }
    }
    
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var locator = new ServiceLocator().Register(_ => new ExampleObject());
            var thunk = ThunkBuilder.Create<ExampleObject, string>(eo => eo.GenericSomething<double>());

            var sThunk = JsonConvert.SerializeObject(thunk);
            var result = JsonConvert.DeserializeObject<Thunk<string>>(sThunk).Execute(locator);
        }
    }
}