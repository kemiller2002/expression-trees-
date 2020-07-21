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
                .Select(x => Expression.Parameter(typeof(int), $"prm{x.ToString()}"))
                .ToArray();

            
            var block = Expression.Block (
                parameters.Cast<Expression>().Aggregate((s,i) => Expression.Add(s, i))
            );

            var lambda = Expression.Lambda(
                block, 
                parameters
            );
            
            //var compiled = (Func<int,int,int,int,int>)lambda.Compile();
            //Console.WriteLine(compiled(1,2,3,4));

            var compiled = lambda.Compile();

            var type = compiled.GetType();

            var tParameters = type.GetMethod("Invoke");

        }

    }
}
