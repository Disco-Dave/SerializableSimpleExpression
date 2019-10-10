using System;

namespace SerializableLambda
{
    internal class SerializableParameter
    {
        private readonly Type parameterType;
        private readonly dynamic parameterValue;

        internal SerializableParameter(object parameterValue)
        {
            this.parameterType = parameterValue.GetType();
            this.parameterValue = parameterValue;
        } 
    }
}