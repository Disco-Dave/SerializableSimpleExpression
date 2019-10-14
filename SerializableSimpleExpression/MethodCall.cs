using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using SerializableSimpleExpression.ServiceLocator;

namespace SerializableSimpleExpression
{
    /// <summary>
    /// A serializable method call.
    /// </summary>
    /// <typeparam name="TReturn">The return type from executing the method call.</typeparam>
    public class MethodCall<TReturn>
    {
        private MethodInfo MethodInfo { get; }
        private object[] Arguments { get; } = new object[] { };
        
        [JsonProperty]
        internal List<SerializableParameter> SerializableParameters { get; } = new List<SerializableParameter>();
        
        [JsonProperty]
        internal string ClassType { get; }
        
        [JsonProperty]
        internal string MethodName { get; }

        [JsonProperty]
        internal List<string> GenericTypes { get; } = new List<string>();
        
        internal MethodCall(MethodInfo methodInfo, object[] arguments)
        {
            this.MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            this.Arguments = arguments ?? new object[] {};

            this.SerializableParameters = this.Arguments.Select(a => new SerializableParameter(a)).ToList();
            this.ClassType = this.MethodInfo.DeclaringType.AssemblyQualifiedName;
            this.MethodName = this.MethodInfo.Name;

            if (this.MethodInfo.IsGenericMethod)
            {
                this.GenericTypes = this.MethodInfo.GetGenericArguments().Select(a => a.AssemblyQualifiedName).ToList();
            }
        }

        [JsonConstructor]
        internal MethodCall(string classType, string methodName, List<SerializableParameter> serializableParameters, List<string> genericTypes)
        {
            this.ClassType = classType;
            this.MethodName = methodName;

            if (serializableParameters?.Any() ?? false)
            {
                this.SerializableParameters = serializableParameters;
                this.Arguments = this.SerializableParameters.Select(a => a.Value).ToArray();
            }

            if (genericTypes?.Any() ?? false)
            {
                this.GenericTypes = genericTypes;
            }

            var argumentTypes = this.SerializableParameters.Select(a => a.Type).ToArray();
            this.MethodInfo = Type.GetType(this.ClassType, true).GetMethod(this.MethodName, argumentTypes);

            if (this.GenericTypes.Any())
            {
                this.MethodInfo =
                    this.MethodInfo.MakeGenericMethod(this.GenericTypes.Select(t => Type.GetType(t, true)).ToArray());
            }
        }

        /// <summary>
        /// Executes the method call.
        /// </summary>
        /// <param name="serviceLocator">A service locator used to retrieving an instance of the declaring type.</param>
        /// <returns>The result of executing the method.</returns>
        public TReturn Execute(IServiceLocator serviceLocator)
        {
            var classInstance = serviceLocator.Get(this.MethodInfo.DeclaringType);
            var parameters = this.Arguments.Any() ? this.Arguments : null;
            return (TReturn) this.MethodInfo.Invoke(classInstance, parameters);
        }

        /// <summary>
        /// Converts this method call to JSON.
        /// </summary>
        /// <returns>A string of JSON.</returns>
        public string ToJson() =>
            JsonConvert.SerializeObject(this);

        /// <summary>
        /// Converts a string of JSON into a method call.
        /// </summary>
        /// <param name="json">A JSON string of a method call.</param>
        /// <returns>A method call.</returns>
        public static MethodCall<TReturn> FromJson(string json) =>
            JsonConvert.DeserializeObject<MethodCall<TReturn>>(json);
    }
}