using System;

namespace SerializableLambda
{
    public interface IServiceLocator
    {
        T Get<T>();
    }
}