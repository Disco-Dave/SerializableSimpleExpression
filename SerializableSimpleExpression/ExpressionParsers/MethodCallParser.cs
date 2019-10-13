using System;
using System.Linq;
using System.Linq.Expressions;

namespace SerializableSimpleExpression.ExpressionParsers
{
    internal static class MethodCallParser
    {
        internal static MethodCallResult Parse(LambdaExpression expression)
        {
            if (!(expression.Body is MethodCallExpression methodCallExpression))
            {
                throw new ArgumentException($"The expression passed in needs to be a {nameof(MethodCallExpression)}.");
            }
            
            var methodInfo = methodCallExpression.Method;
            var argumentOrder = GetArgumentOrder(methodCallExpression, expression);
            return new MethodCallResult(methodInfo, argumentOrder);

        }

        private static int[] GetArgumentOrder(MethodCallExpression methodCallExpression, LambdaExpression expression)
        {
            var classArgumentName = methodCallExpression.Object.ToString();
            var methodArgumentOrder = methodCallExpression.Arguments.Select(a => a.ToString()).ToArray();
            var originalPassedInOrder =
                expression.Parameters.Select(a => a.ToString()).Where(a => a != classArgumentName);

            return originalPassedInOrder.Select(oa => Array.FindIndex(methodArgumentOrder, ma => ma == oa)).ToArray();
        }
    }
}