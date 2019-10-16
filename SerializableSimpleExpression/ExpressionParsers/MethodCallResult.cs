using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public IEnumerable<string> MethodArgumentVariableNames { get; }
        
        public IEnumerable<string> ArgumentVariablesInLambda { get; }
        
        public MethodCallResult(MethodInfo methodInfo, IEnumerable<string> methodArgumentVariableNames, IEnumerable<string> argumentVariablesInLambda)
        {
            this.MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            this.MethodArgumentVariableNames = methodArgumentVariableNames ?? Enumerable.Empty<string>();
            this.ArgumentVariablesInLambda = argumentVariablesInLambda ?? Enumerable.Empty<string>();

        }
    }
}