using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FuncActionPredicateExamples.Program;

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
            PredicatePractice();
            Console.ReadKey();
        }

        private static void PredicatePractice()
        {
            List<Employee> employees = new List<Employee>();
            Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}Annual salary: {arg4}{Environment.NewLine}Gender: {arg5}{Environment.NewLine}Manager: {arg6}");

            employees.Add(new Employee { Id = 1, FirstName = "Sarah", LastName = "Jones", AnuualSalary = 60000, Gender = 'f', IsManager = true });
            employees.Add(new Employee { Id = 2, FirstName = "Andrew", LastName = "Brown", AnuualSalary = 40000, Gender = 'm', IsManager = false });
            employees.Add(new Employee { Id = 3, FirstName = "John", LastName = "Henderson", AnuualSalary = 58000, Gender = 'm', IsManager = true });
            employees.Add(new Employee { Id = 4, FirstName = "Jane", LastName = "May", AnuualSalary = 30000, Gender = 'f', IsManager = false });

            //List<Employee> employeesFiletered = FilterEmployees(employees, e => e.IsManager);
            //only need to pass lambda pression for the method of the list object
            //List<Employee> employeesFiletered = employees.FilterEmployees(e => !e.IsManager);
            //use linqaa
            List<Employee> employeesFiletered = employees.Where(e => !e.IsManager).ToList();
            foreach (Employee employee in employeesFiletered) 
            {
                displayEmployeeRecords(employee.Id, employee.FirstName, employee.LastName, employee.AnuualSalary, employee.Gender, employee.IsManager);
                Console.WriteLine();
            }
        }   

        static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicate) 
        {
            //predicate method encapsuluates a method that contains one parameter(intput) and returns bool,
            //normally used to check whether the input meets the criteria 
            List<Employee> employeesFiltered = new List<Employee>();

            foreach (Employee employee in employees) 
            {
                if(predicate(employee))
                { 
                    employeesFiltered.Add(employee);
                }
            }
            return employeesFiltered;
        }

        private static void ActionPractice() 
        {
            //first trial, we can see that Action only take parameters and dont return any fields
            //Action<int, string, string> displayEmployeeRecords = (arg1, arg2, arg3) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}");
            //add annual salary
            //Action<int, string, string, decimal> displayEmployeeRecords = (arg1, arg2, arg3, arg4) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}Annual salary: {arg4}");
            //add Gender and is manager fields
            //Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}Annual salary: {arg4}{Environment.NewLine}Gender: {arg5}{Environment.NewLine}Manager: {arg6}");

            //displayEmployeeRecords(1, "Sarah", "Jones", 60000, 'f', true);
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

        
    }

    //by using extension, we can then say directly use the method from the list object
    public static class Extensions
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            //predicate method encapsuluates a method that contains one parameter(intput) and returns bool,
            //normally used to check whether the input meets the criteria 
            List<Employee> employeesFiltered = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }
            return employeesFiltered;
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AnuualSalary { get; set; }

        public char Gender { get; set; }

        public bool IsManager { get; set; }
    }
    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

}
