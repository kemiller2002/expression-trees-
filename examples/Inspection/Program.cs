using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Inspection
{
    class Program
    {
        static void Main(string[] args)
        {

            var fparameter = Expression.Parameter(typeof(string), "firstName");
            var lparameter = Expression.Parameter(typeof(string), "lastName");
            var aparameter = Expression.Parameter(typeof(int), "age");


            var fullNameVariable = Expression.Variable(typeof(string), "fullName");
            var concatMethodInfo = typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) });

            var concatFNameWithSpace = Expression.Call(concatMethodInfo, new Expression[] { fparameter, Expression.Constant(" ") });

            var expressionAssign = Expression.Assign(fullNameVariable, concatFNameWithSpace);

            var concatLName = Expression.Call(concatMethodInfo, new Expression[] { fullNameVariable, lparameter });

            var expressionBody = Expression.Block(new ParameterExpression[] { fullNameVariable }, concatFNameWithSpace, expressionAssign, concatLName);

            var lamba = Expression.Lambda(expressionBody, new[] { fparameter, lparameter, aparameter });

            var cLambda = (Func<string, string, int, string>)lamba.Compile();

            var result = cLambda("Kevin", "Miller", 34);

            var placedExpression = (BlockExpression)lamba.Body;

            placedExpression.Expressions.ToList().ForEach(Console.WriteLine);

            Console.WriteLine(result);
        }


        static void RunComputation(Expression body)
        {
            var queue = new Queue<Expression>(new[] { body });

            while (queue.Count > 0)
            {
                var d = queue.Dequeue();
                Console.WriteLine(d);
            }
        }




    }
}
