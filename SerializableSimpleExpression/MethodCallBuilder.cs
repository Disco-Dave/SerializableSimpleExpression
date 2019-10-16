using System;
using System.Linq;
using System.Linq.Expressions;
using SerializableSimpleExpression.ExpressionParsers;

namespace SerializableSimpleExpression
{
    public static class MethodCallBuilder
    {
        public static MethodCall<TReturn> Create<TClass, TReturn>(Expression<Func<TClass, TReturn>> expression) where TClass : class =>
            new MethodCall<TReturn>(MethodCallParser.Parse(expression).MethodInfo, new object[] {});

        public static MethodCallBuilder<TReturn, TArg> Create<TClass, TReturn, TArg>(
            Expression<Func<TClass, TArg, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2> Create<TClass, TReturn, TArg1, TArg2>(
            Expression<Func<TClass, TArg1, TArg2, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3> Create<TClass, TReturn, TArg1, TArg2, TArg3>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5,TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(expression);
        
        public static MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>> expression) where TClass : class =>
           new MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(expression);
    }

    public class MethodCallBuilder<TReturn, TArg> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArgument(TArg arg) =>
            base.SetArguments(arg);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2) =>
            base.SetArguments(arg1, arg2);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            base.SetArguments(arg1, arg2, arg3);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
            base.SetArguments(arg1, arg2, arg3, arg4);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }
    
    public class MethodCallBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> : AbstractMethodCallBuilder<TReturn>
    {
        internal MethodCallBuilder(LambdaExpression expression) : base(expression) { }

        public MethodCall<TReturn> SetArguments(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    }

    public abstract class AbstractMethodCallBuilder<TReturn>
    {
        private readonly MethodCallResult methodCallExpression;
        
        internal AbstractMethodCallBuilder(LambdaExpression expression)
        {
            this.methodCallExpression = MethodCallParser.Parse(expression);
        }

        internal MethodCall<TReturn> SetArguments(params object[] args)
        {
            var variableNameToArg = this.methodCallExpression
                .ArgumentVariablesInLambda
                .Zip(args, (n, a) => (name : n, value : a))
                .ToDictionary(a => a.name, a => a.value);

            var methodArgs = this.methodCallExpression
                .MethodArgumentVariableNames
                .Select(a => variableNameToArg[a])
                .ToArray();
                
           return new MethodCall<TReturn>(methodCallExpression.MethodInfo, methodArgs); 
        }
    }
}