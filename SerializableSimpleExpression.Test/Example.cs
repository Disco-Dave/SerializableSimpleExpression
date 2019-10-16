using System.Collections.Generic;
using System.Linq;

namespace SerializableSimpleExpression.Test
{
    internal class Example
    {
        public string NoArguments() => "no args were passed in";

        public IEnumerable<string> WithThreeArgs(int x, double y, string z) =>
            PassedInArgs(x, y, z);

        public string SingleArg(string x) =>
            x;

        public string SingleArg(string x, string y) =>
            string.Join("", PassedInArgs(x, y));

        public IEnumerable<string> WithGenericArgs<TA, TB>(TA a, TB b) =>
            PassedInArgs(a, b);
        
        private static IEnumerable<string> PassedInArgs(params object[] args) =>
            args.Select(a => a.ToString());
    }

    internal class GenericExample<T>
    {
        public T Echo(T value) => value;
    }
}