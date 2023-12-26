using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionPredicateExamples
{
    internal class Program
    {
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
        static void Main(string[] args)
        {
            //reference a method
            /*
            MathClass mathClass = new MathClass();

            Func<int, int, int> calc = mathClass.Sum;
            */
            
            //or use delegate for reference
            /*
            Func<int, int, int> calc = delegate (int a, int b) { return a + b; };
            */

            //or we can use lambda, shorter way to represent anoynomous method
            //Func<int, int, int> calc = (a, b) => a + b;

            //using our created func2 key word of func
            Func2<int, int, int> calc = (a, b) => a + b;
            int result = calc(1, 2);
            Console.WriteLine($"Result: {result}");
            Console.ReadKey();
        }

        public class MathClass 
        {
            public int Sum(int a, int b) 
            {
                return a + b;
            }
        }
    }
}
