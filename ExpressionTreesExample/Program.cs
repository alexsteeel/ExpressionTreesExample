using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateExpressionBlocks();

            Console.ReadKey();
        }

        private static void CreateExpressionBlocks()
        {
            BlockExpression blockExpr = Expression.Block(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                                Expression.Constant("Hello ")
                               ),
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                                Expression.Constant("World!")
                                ),
                            Expression.Constant(42)
                        );

            Console.WriteLine("The result of executing the expression tree:");        
            var result = Expression.Lambda<Func<int>>(blockExpr).Compile()();

            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in blockExpr.Expressions)
            {
                Console.WriteLine(expr.ToString());
            }                
        }
    }
}
