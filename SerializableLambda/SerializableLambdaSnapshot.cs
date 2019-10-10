using System;
using System.Collections.Generic;

namespace SerializableLambda
{
    internal class SerializableLambdaSnapshot
    {
        public Type ClassType { get; set; }
        public string MethodName { get; set; }
        public IEnumerable<SerializableParameter> Parameters { get; set; } = new List<SerializableParameter>();
        public Type[] GenericTypes { get; set; } = new Type[] { };
    }
}
