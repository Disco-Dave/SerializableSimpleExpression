using System;
using System.Linq;
using System.Linq.Expressions;

namespace SerializableSimpleExpression.ExpressionParsers
{
    /// <summary>
    /// A parser for getting information out of a <see cref="MethodCallExpression"/>.
    /// </summary>
    internal static class MethodCallParser
    {
        /// <summary>
        /// Get all relevant information out of a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">The expression you wish to parse.</param>
        /// <returns>The parsed method call result.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the <see cref="LambdaExpression"/> is not a <see cref="MethodCallExpression"/>.
        /// </exception>
        internal static MethodCallResult Parse(LambdaExpression expression)
        {
            if (!(expression.Body is MethodCallExpression methodCallExpression))
            {
                throw new ArgumentException($"The expression passed in needs to be a {nameof(MethodCallExpression)}.");
            }
            
            var methodInfo = methodCallExpression.Method;
            var methodArgumentVariableNames = methodCallExpression.Arguments.Select(a => a.ToString());
            
            var classArgumentName = methodCallExpression.Object?.ToString();
            
            var argumentVariablesInLambda = expression.Parameters
                .Select(a => a.ToString())
                .Where(a => a != classArgumentName);
            
            return new MethodCallResult(methodInfo, methodArgumentVariableNames, argumentVariablesInLambda);
        }
    }
}