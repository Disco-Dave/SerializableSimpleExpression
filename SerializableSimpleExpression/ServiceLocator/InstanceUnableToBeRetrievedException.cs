using System;

namespace SerializableSimpleExpression.ServiceLocator
{
    /// <summary>
    /// Thrown whenever we fail to resolve a type from <see cref="IServiceLocator"/>.
    /// </summary>
    public class InstanceUnableToBeRetrievedException : Exception
    {
        internal InstanceUnableToBeRetrievedException(Type instanceType) : base($"Unable to create an instance of type {instanceType}. Did you forget to attach {instanceType} to your IServiceLocator instance?")
        {
                
        }
    }
}