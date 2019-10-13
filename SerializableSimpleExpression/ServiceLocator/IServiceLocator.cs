namespace SerializableSimpleExpression.ServiceLocator
{
    /// <summary>
    /// Used to create an instance of a class.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Get an instance of <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <returns>An instance of <see cref="T"/>.</returns>
        T Get<T>() where T : class;
    }
}