using System;
using System.Linq.Expressions;
using System.Linq;

namespace PrintExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int>> addTwo = (number) => number + 2;

            Console.WriteLine($"Return Type: {addTwo.ReturnType}");
            addTwo.
                Parameters.
                Select(x => $"Parameter: {x.Name}, {x.Type}").
                ToList().
                ForEach(Console.WriteLine);


            var func = addTwo.Compile();
            var answer = func(1);
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
