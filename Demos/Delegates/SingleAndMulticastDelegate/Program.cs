using System;

namespace Delegates
{
    class Program
    {
        //a delegate has a particular param list and return type.
        public delegate double PerformCalculation(double x, double y);

        static void Main(string[] args)
        {
            PerformCalculation pc = Multiply;//[0] of invocationList
            pc = pc += Subtract;             // [1] of invocationList
            pc += Divide;                   // [2] of invocationList

            pc -= Subtract;//take one method out of the list.

            double result = pc(5.1, 6.1);

            System.Console.WriteLine(result);//gives the result of Divide() only
            System.Console.WriteLine("\nStarting ForEach loop.\n");
            double result1 = 0;
            foreach (var item in pc.GetInvocationList())
            {
                if (result1 == 0)
                {
                    result1 = (double)item.DynamicInvoke(5.1, 6.1);
                    System.Console.WriteLine(result1);
                }
                else
                {
                    result1 = (double)item.DynamicInvoke(result1, result1);
                    System.Console.WriteLine(result1);
                }
            }
        }

        // method 1
        public static double Multiply(double x, double y)
        { return x * y; }

        //method 2
        public static double Subtract(double x, double y)
        { return x - y; }

        //method 3
        public static double Divide(double x, double y)
        { return x / y; }
    }
}
