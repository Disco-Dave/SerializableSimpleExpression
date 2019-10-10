using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializableLambda
{
    public class SerializableLambda<TReturnType>
    {
        private Type ClassType { get; }
        private string MethodName { get; }
        private IEnumerable<object> Parameters { get; } = new List<object>();
        private Type[] GenericTypes { get; } = new Type[] { };
        
        internal SerializableLambda(Type classType, string methodName, IEnumerable<object> parameters, Type[] genericTypes)
        {
            this.ClassType = classType ?? throw new ArgumentNullException(nameof(classType));
            this.MethodName = methodName ?? throw new ArgumentNullException(nameof(methodName));

            if (parameters?.Any() ?? false)
            {
                this.Parameters = parameters;
            }

            if (genericTypes?.Any() ?? false)
            {
                this.GenericTypes = genericTypes;
            }
        }

        public TReturnType Execute(IServiceLocator serviceLocator)
        {
            var classInstance = typeof(IServiceLocator)
                .GetMethod(nameof(IServiceLocator.Get))
                .MakeGenericMethod(this.ClassType)
                .Invoke(serviceLocator, null);

            var method = this.ClassType.GetMethod(this.MethodName);

            if (this.GenericTypes.Any())
            {
                method = method.MakeGenericMethod(this.GenericTypes);
            }

            TReturnType returnValue;

            if (this.Parameters.Any())
            {
                returnValue = (TReturnType) method.Invoke(classInstance, this.Parameters.ToArray());
            }
            else
            {
                returnValue = (TReturnType) method.Invoke(classInstance, null);
            }

            return returnValue;
        }
    }
}