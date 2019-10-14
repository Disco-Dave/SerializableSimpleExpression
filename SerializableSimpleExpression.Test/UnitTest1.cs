using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public Task<string> SomeTask()
        {
            return Task.FromResult("hey it worked");
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
        public async Task Test1()
        {
            var locator = new ServiceLocator().Register(_ => new ExampleObject());
            var thunk = MethodCallBuilder.Create<ExampleObject, string>(eo => eo.GenericSomething<double>());

            var sThunk = JsonConvert.SerializeObject(thunk);
            var result = JsonConvert.DeserializeObject<MethodCall<string>>(sThunk).Execute(locator);

            var thunk2 =
                MethodCallBuilder.Create<ExampleObject, List<int>, string, double, int>((eo, a, b, c) => eo.DoSomething(c, b, a))
                    .SetArguments("abc", 1.3, 2);

            var sThunk2 = JsonConvert.SerializeObject(thunk2);
            var result2 = JsonConvert.DeserializeObject<MethodCall<List<int>>>(sThunk2).Execute(locator);

            var someMethodCallTask = MethodCallBuilder.Create<ExampleObject, Task<string>>(eo => eo.SomeTask());
            var s = someMethodCallTask.ToJson();
            var ss = MethodCall<Task<string>>.FromJson(s);

            var r = await ss.Execute(locator);
        }
    }
}