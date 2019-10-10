using System;
using System.Collections.Generic;

namespace SerializableLambda
{
    internal class SerializableLambdaSnapshot
    {
        public Type ClassType { get; set; }
        public string MethodName { get; set; }
        public IEnumerable<object> Parameters { get; set; } = new List<object>();
        public Type[] GenericTypes { get; set; } = new Type[] { };
    }
}
