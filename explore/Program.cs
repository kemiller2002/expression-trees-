using System;
using System.Linq.Expressions;
using System.Linq;

namespace explore
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                            LabelTarget returnTarget = Expression.Label(typeof(bool));
            ParameterExpression para = Expression.Parameter(typeof(int), "intvalue");
            Expression test = Expression.GreaterThan(para, Expression.Constant(5));
            Expression iftrue = Expression.Return(returnTarget, Expression.Constant(true));
            Expression iffalse = Expression.Return(returnTarget, Expression.Constant(false));

            var ex = Expression.Block(
                Expression.IfThenElse(test, iftrue, iffalse),
                Expression.Label(returnTarget, Expression.Constant(false)));

            var compiled = Expression.Lambda<Func<int, bool>>(
                ex,
                new ParameterExpression[] { para }
            ).Compile();

            Console.WriteLine(compiled(5));     // prints "False"
            Console.WriteLine(compiled(6));     // prints "True"*/

            var label = Expression.Label(typeof(int));

            var rtn = Expression.Return(label, Expression.Constant(10));

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));

            var block = Expression.Block(
                Expression.Add(p1, p2)
            );

            var compiled = Expression.Lambda<Func<int, int, int>>(
                block,
                new ParameterExpression[] { p1, p2 }
            ).Compile();

            Console.WriteLine(compiled(5, 7));


            Test(i => i + 1);

        }


        static public void Test(Expression<Func<int, int>> testExp)
        {

        }

    }
}
