using System;
using System.Reflection;

namespace SerializableSimpleExpression.ServiceLocator
{
    /// <summary>
    /// Extension methods to help make the <see cref="IServiceLocator"/> more pleasant to use with reflection.
    /// </summary>
    internal static class ServiceLocatorExtensions
    {
        /// <summary>
        /// Allows us to get an instance of an object using <see cref="Type"/> instead of a generic parameter.
        /// </summary>
        /// <param name="serviceLocator">
        /// The instance of the <see cref="IServiceLocator"/> that will be used for resolving dependencies.
        /// </param>
        /// <param name="instanceType">The <see cref="Type"/> of the class we wish to get an instance of.</param>
        /// <returns>An untyped instance of the requested type.</returns>
        /// <exception cref="InstanceUnableToBeRetrievedException">
        /// Thrown when the instance retrieved from the <see cref="IServiceLocator"/> is null.
        /// </exception>
        internal static object Get(this IServiceLocator serviceLocator, Type instanceType)
        {
            var instance = typeof(IServiceLocator)
                .GetMethod(nameof(IServiceLocator.Get))
                ?.MakeGenericMethod(instanceType)
                .Invoke(serviceLocator, null);

            if (instance == null)
            {
                throw new InstanceUnableToBeRetrievedException(instanceType);
            }

            return instance;
        }
    }
}