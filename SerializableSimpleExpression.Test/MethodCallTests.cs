using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SerializableSimpleExpression.ServiceLocator;
using Xunit;

namespace SerializableSimpleExpression.Test
{
    public class MethodCallTests
    {
        private static readonly IServiceLocator mockServiceLocator =
            new MockServiceLocator()
                .Register(_ => new Example())
                .Register(_ => new GenericExample<int>());
        
        [Fact]
        public void WorksWithZeroArguments()
        {
            var methodCall = MethodCallBuilder.Create<Example, string>(e => e.NoArguments());
            ExecuteAndAssert("no args were passed in", methodCall);
        }

        [Fact]
        public void WorksWithParameters()
        {
            var methodCall = MethodCallBuilder
                .Create<Example, IEnumerable<string>, int, double, string>((e, x, y, z) => e.WithThreeArgs(x, y, z))
                .SetArguments(1, 3.5, "four");
            
            ExecuteAndAssert(new [] { "1", "3.5", "four"}, methodCall);
        }
        
        [Fact]
        public void WorksWithParametersOutOfOrder()
        {
            var methodCall = MethodCallBuilder
                .Create<Example, IEnumerable<string>, double, int, string>((e, y, x, z) => e.WithThreeArgs(x, y, z))
                .SetArguments(3.5, 1, "four");
            
            ExecuteAndAssert(new [] { "1", "3.5", "four"}, methodCall);
        }

        [Fact]
        public void WorksWithGenericArgs()
        {
            var methodCall = MethodCallBuilder
                .Create<Example, IEnumerable<string>, string, int>((e, a, b) => e.WithGenericArgs(a, b))
                .SetArguments("first thing", 21);
            
            ExecuteAndAssert(new [] { "first thing", "21" }, methodCall);
        }

        [Fact]
        public void WorksWhenThereAreOverloads()
        {
            var methodCall = MethodCallBuilder
                .Create<Example, string, string, string>((e, x, y) => e.SingleArg(x, y))
                .SetArguments("first", "second");
            
            ExecuteAndAssert("firstsecond", methodCall);
        }

        [Fact]
        public void WorksWhenThereAreGenericOverloads()
        {
           throw new NotImplementedException(); 
        }

        [Fact]
        public void WorksWhenNotAllArgsAreUsed()
        {
            var methodCall = MethodCallBuilder
                .Create<Example, string, double, int, string>((e, y, x, z) => e.SingleArg(z))
                .SetArguments(3.5, 1, "single");
            
            ExecuteAndAssert("single", methodCall);
        }
        
        [Fact]
        public void WorksWithGenericClass()
        {
            var methodCall = MethodCallBuilder
                .Create<GenericExample<int>, int, int>((ge, i) => ge.Echo(i))
                .SetArgument(532);
            
            ExecuteAndAssert(532, methodCall);
        }
        
        private static void ExecuteAndAssert<T>(T expected, MethodCall<T> methodCall)
        {
            Assert.Equal(expected, methodCall.Execute(mockServiceLocator));

            var methodToJson = methodCall.ToJson();
            var methodFromJson = MethodCall<T>.FromJson(methodToJson);
            Assert.Equal(expected, methodFromJson.Execute(mockServiceLocator));

            var newtonJson = JsonConvert.SerializeObject(methodCall);
            var newtonMethod = JsonConvert.DeserializeObject<MethodCall<T>>(newtonJson);
            Assert.Equal(expected, newtonMethod.Execute(mockServiceLocator));
        }
    }
}