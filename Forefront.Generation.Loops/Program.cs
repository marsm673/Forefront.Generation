using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numberOfTimes = 0; 
            
            //while (numberOfTimes < 5)
            //{
            //    Console.WriteLine("Markus Smed");
            //    numberOfTimes++; 
            //}

            for (int numbersInFor = 0; numbersInFor < 5; numbersInFor++)
            {
                Console.WriteLine("Markus Smed"); 
            }

            Console.ReadLine();
        }
    }
}
