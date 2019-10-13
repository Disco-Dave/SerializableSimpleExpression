using System;
using System.Linq;
using System.Linq.Expressions;
using SerializableSimpleExpression.ExpressionParsers;

namespace SerializableSimpleExpression
{
    public static class ThunkBuilder
    {
        public static Thunk<TReturn> Create<TClass, TReturn>(Expression<Func<TClass, TReturn>> expression) where TClass : class =>
            new Thunk<TReturn>(MethodCallParser.Parse(expression).MethodInfo, new object[] {});

        public static ThunkBuilder<TReturn, TArg> Create<TClass, TReturn, TArg>(
            Expression<Func<TClass, TArg, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2> Create<TClass, TReturn, TArg1, TArg2>(
            Expression<Func<TClass, TArg1, TArg2, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3> Create<TClass, TReturn, TArg1, TArg2, TArg3>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5,TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(expression);
        
        public static ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> Create<TClass, TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(
            Expression<Func<TClass, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>> expression) where TClass : class =>
           new ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(expression);
    }

    public class ThunkBuilder<TReturn, TArg> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg arg) =>
            base.SetArguments(arg);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2) =>
            base.SetArguments(arg1, arg2);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            base.SetArguments(arg1, arg2, arg3);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
            base.SetArguments(arg1, arg2, arg3, arg4);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }
    
    public class ThunkBuilder<TReturn, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> : AbstractThunkBuilder<TReturn>
    {
        internal ThunkBuilder(LambdaExpression expression) : base(expression) { }

        public Thunk<TReturn> SetArgument(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10) =>
            base.SetArguments(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    }

    public abstract class AbstractThunkBuilder<TReturn>
    {
        private readonly MethodCallResult methodCallExpression;
        
        internal AbstractThunkBuilder(LambdaExpression expression)
        {
            this.methodCallExpression = MethodCallParser.Parse(expression);
        }

        internal Thunk<TReturn> SetArguments(params object[] args)
        {
           return new Thunk<TReturn>(methodCallExpression.MethodInfo, ReOrderArgs(args ?? new object[] {})); 
        }

        private object[] ReOrderArgs(object[] args) =>
            this.methodCallExpression.ArgumentOrder.Select(i => args[i]).ToArray();
    }
}