using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            var parameters =
                Enumerable.Range(0, 4)
                .Select(x => Expression.Parameter(typeof(int)))
                .ToArray();


            var block = Expression.Block(
                parameters.Cast<Expression>().Aggregate((s, i) => Expression.Add(s, i))
            );

            var lambda = Expression.Lambda(
                block,
                parameters
            );

            var compiled = lambda.Compile();

            var type = compiled.GetType();

            var methodInfo = type.GetMethod("Invoke");

            var tParameters = methodInfo.GetParameters();

            tParameters.Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            var result = methodInfo.Invoke(compiled, new Object[] { 1, 2, 3, 4 });

            Console.WriteLine(result);
        }

    }
}
