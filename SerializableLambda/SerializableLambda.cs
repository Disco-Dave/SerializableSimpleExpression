using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializableLambda
{
    public class SerializableLambda<TReturnType>
    {
        private Type ClassType { get; }
        private string MethodName { get; }
        private Type ReturnType { get; }
        private IEnumerable<SerializableParameter> Parameters { get; } = new List<SerializableParameter>();
        
        internal SerializableLambda(Type classType, string methodName, Type returnType, IEnumerable<object> parameters)
        {
            this.ClassType = classType ?? throw new ArgumentNullException(nameof(classType));
            this.MethodName = methodName ?? throw new ArgumentNullException(nameof(methodName));
            this.ReturnType = returnType ?? throw new ArgumentNullException(nameof(returnType));

            if (parameters?.Any() ?? false)
            {
                 this.Parameters = parameters.Select(p => new SerializableParameter(p));               
            }
        }

        public TReturnType Execute(IServiceLocator serviceLocator)
        {
            throw new NotImplementedException();
        }
        
        
    }
}