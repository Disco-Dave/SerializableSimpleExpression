using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace SerializableLambda
{
    public abstract class AbstractSerializableLambdaBuilder<TReturn>
    {
        private Type ClassType { get; }
        private string MethodName { get; }
        private Type ReturnType { get; }
        private int[] ParamOrder { get; } 

        protected AbstractSerializableLambdaBuilder(LambdaExpression expr, Type classType, Type returnType)
        {
            if (expr.Body is MethodCallExpression method)
            {
                this.MethodName = method.Method.Name;
                this.ClassType = classType;
                this.ReturnType = returnType;
                this.ParamOrder = GetParamOrder(method, expr);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        protected SerializableLambda<TReturn> SetParameters(params object[] parameters)
        {
            var reOrderedParams = this.ParamOrder.Select(i => parameters[i]);
            return new SerializableLambda<TReturn>(this.ClassType, this.MethodName, this.ReturnType, reOrderedParams);
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