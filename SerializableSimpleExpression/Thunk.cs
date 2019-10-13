using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using SerializableSimpleExpression.ServiceLocator;

namespace SerializableSimpleExpression
{
    public class Thunk<TReturn>
    {
        private MethodInfo MethodInfo { get; }
        private object[] Arguments { get; } = new object[] { };
        
        
        public List<SerializableParameter> SerializableParameters { get; } = new List<SerializableParameter>();
        
        public string ClassType { get; }

        public List<string> GenericTypes { get; } = new List<string>();
        
        internal Thunk(MethodInfo methodInfo, object[] arguments)
        {
            this.MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            this.Arguments = arguments ?? new object[] {};

            this.SerializableParameters = this.Arguments.Select(a => new SerializableParameter(a)).ToList();
            this.ClassType = this.MethodInfo.DeclaringType.AssemblyQualifiedName;

            if (this.MethodInfo.IsGenericMethod)
            {
                this.GenericTypes = this.MethodInfo.GetGenericArguments().Select(a => a.AssemblyQualifiedName).ToList();
            }
        }

        public Thunk(string classType, List<SerializableParameter> serializableParameters, List<string> genericTypes)
        {
            this.ClassType = classType;

            if (serializableParameters?.Any() ?? false)
            {
                this.SerializableParameters = serializableParameters;
                this.Arguments = this.SerializableParameters.Select(a => a.Value).ToArray();
            }

            if (genericTypes?.Any() ?? false)
            {
                this.GenericTypes = genericTypes;
            }
            
            
            
        }

        public TReturn Execute(IServiceLocator serviceLocator)
        {
            var classInstance = serviceLocator.Get(this.MethodInfo.DeclaringType);
            var parameters = this.Arguments.Any() ? this.Arguments : null;
            return (TReturn) this.MethodInfo.Invoke(classInstance, parameters);
        }

        public string ToJson() =>
            JsonConvert.SerializeObject(this);

        public static Thunk<TReturn> FromJson(string json) =>
            JsonConvert.DeserializeObject<Thunk<TReturn>>(json);
    }
}