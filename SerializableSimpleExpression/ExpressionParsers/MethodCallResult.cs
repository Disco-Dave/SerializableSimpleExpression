using System;
using System.Reflection;

namespace SerializableSimpleExpression.ExpressionParsers
{
    internal class MethodCallResult
    {
        public MethodInfo MethodInfo { get; }
        
        public int[] ArgumentOrder { get; }
        
        
        public MethodCallResult(MethodInfo methodInfo, int[] argumentOrder)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            ArgumentOrder = argumentOrder ?? new int[]{};
        }

    }
}