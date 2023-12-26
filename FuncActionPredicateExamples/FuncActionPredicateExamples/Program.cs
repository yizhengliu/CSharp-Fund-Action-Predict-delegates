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
            FuncPractice();
            ActionPractice();

            Console.ReadKey();
        }
        private static void ActionPractice() 
        {
            //first trial, we can see that Action only take parameters and dont return any fields
            Action<int, string, string> displayEmployeeRecords = (arg1, arg2, arg3) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}");
            displayEmployeeRecords(1, "Sarah", "Jones");
        }

        private static void FuncPractice() 
        {
            //Func examples
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
            /*
            Func2<int, int, int> calc = (a, b) => a + b;
            int result = calc(1, 2);
            Console.WriteLine($"Result: {result}");
            
            */
            //example for complex calculation
            /*
            float d = 2.3f, e = 4.56f;
            int f = 5;
            Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;

            float result2 = calc2(d, e, f);
            Console.WriteLine($"Result: {result2}");
            */

            //practical example, employee annual salary
            /*
            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (annualSalary, bonusPercentage) => annualSalary + (annualSalary * (bonusPercentage / 100));

            Console.WriteLine($"Total Salary: {calculateTotalAnnualSalary(60000, 2)}");
            */
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
