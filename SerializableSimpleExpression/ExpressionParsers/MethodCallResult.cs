using System;
using System.Reflection;

namespace SerializableSimpleExpression.ExpressionParsers
{
    /// <summary>
    /// The parsed result of the method call expression.
    /// </summary>
    internal class MethodCallResult
    {
        /// <summary>
        /// The method info of the method the user wishes to call.
        /// </summary>
        public MethodInfo MethodInfo { get; }
        
        /// <summary>
        /// An array that maps the indexes of the expression's arguments to the order of the arguments passed to the method.
        /// <example>
        /// (eo, a, c, b) => eo.DoSomething(a,c,b);
        /// ArgumentOrder = new int[] { 0, 2, 1 };
        /// </example>
        /// </summary>
        public int[] ArgumentOrder { get; }
        
        public MethodCallResult(MethodInfo methodInfo, int[] argumentOrder)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            ArgumentOrder = argumentOrder ?? new int[]{};
        }
    }
}