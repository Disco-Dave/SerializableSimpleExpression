using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;

namespace SerializableLambda
{
    public abstract class AbstractSerializableLambdaBuilder<TReturn>
    {
        private Type ClassType { get; }
        private string MethodName { get; }
        private int[] ParamOrder { get; }
        private Type[] GenericTypes { get; } = new Type[] { };

        protected AbstractSerializableLambdaBuilder(LambdaExpression expr, Type classType)
        {
            if (expr.Body is MethodCallExpression method)
            {
                this.MethodName = method.Method.Name;
                this.ClassType = classType;
                this.ParamOrder = GetParamOrder(method, expr);

                if (method.Method.IsGenericMethod)
                {
                    this.GenericTypes = method.Method.GetGenericArguments();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        protected SerializableLambda<TReturn> SetParameters(params object[] parameters)
        {
            var reOrderedParams = this.ParamOrder.Select(i => parameters[i]);
            return new SerializableLambda<TReturn>(this.ClassType, this.MethodName, reOrderedParams, this.GenericTypes);
        }

        private static int[] GetParamOrder(MethodCallExpression methodCallExpr, LambdaExpression lambdaExpr)
        {
            var methodParameterOrder = methodCallExpr.Arguments.Select(arg => arg.ToString()).ToArray();
            var originalPassedInOrder = lambdaExpr.Parameters.Skip(1).Select(arg => arg.ToString());
            return originalPassedInOrder
                .Select(op => Array.FindIndex(methodParameterOrder, mp => mp == op))
                .ToArray();
        }
    }
}