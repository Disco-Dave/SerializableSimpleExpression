using System;
using System.IO;
using System.Linq.Expressions;

namespace SerializableLambda
{
    public class SerializableLambdaBuilder<TClassType, TReturnType> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TReturnType>> method) : base(method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }

        public SerializableLambda<TReturnType> Create() =>
            base.SetParameters();
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TReturnType>> method) : base(method,
            typeof(TClassType),
            typeof(TReturnType)) 
        {
        }

        public SerializableLambda<TReturnType> SetParameters(TParam1 param1) =>
            base.SetParameters(param1);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2) =>
            base.SetParameters(param1, param2);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3) =>
            base.SetParameters(param1, param2, param3);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3, TParam4> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TParam4, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) =>
            base.SetParameters(param1, param2, param3, param4);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3, TParam4, TParam5> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TParam4, TParam5, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5) =>
            base.SetParameters(param1, param2, param3, param4, param5);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6) =>
            base.SetParameters(param1, param2, param3, param4, param5, param6);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7) =>
            base.SetParameters(param1, param2, param3, param4, param5, param6, param7);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8) =>
            base.SetParameters(param1, param2, param3, param4, param5, param6, param7, param8);
    }
    
    public class SerializableLambdaBuilder<TClassType, TReturnType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> : AbstractSerializableLambdaBuilder<TReturnType>
    {
        internal SerializableLambdaBuilder(Expression<Func<TClassType, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TReturnType>> method) : base(
            method,
            typeof(TClassType),
            typeof(TReturnType))
        {
        }
        
        public SerializableLambda<TReturnType> SetParameters(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9) =>
            base.SetParameters(param1, param2, param3, param4, param5, param6, param7, param8, param9);
    }
}