using System;
using System.Collections.Generic;
using SerializableSimpleExpression.ServiceLocator;

namespace SerializableSimpleExpression.Test
{
    internal class MockServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, Func<IServiceLocator, dynamic>> container = 
            new Dictionary<Type, Func<IServiceLocator, dynamic>>();

        public T Get<T>() where T : class
        {
            return this.container[typeof(T)](this);
        }

        public MockServiceLocator Register<T>(Func<IServiceLocator, T> service)
        {
            this.container.Add(typeof(T), sl => (dynamic) service(sl));
            
            return this;
        }
    }
}