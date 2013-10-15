using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 3;

            int result = Add(a, b);

            Write("We added " + a + " and " + b); 
            Write("The result was: " + result); 

        }

        private static void Write(string message)
        {
            Console.WriteLine(message);
        }


        private static int Add(int number1, int number2)
        {
        int result = number1 + number2; 
        return result;
        }

    }
}
