using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                string name = "Markus Smed";
                //bool isThirsty = true;

                Console.Write("Enter temperature: ");

                string input = Console.ReadLine();
                decimal temperatureTest;

                try
                {
                    temperatureTest = decimal.Parse(input);
                }
                catch (Exception)
                {

                    Console.WriteLine("error, try again");
                        break;

                }



                decimal temperature = Convert.ToDecimal(input);

                Console.WriteLine("The temperature is: " + temperature);

                if (TempIsWithinLegalRange(temperature))
                {
                    Console.WriteLine("Yes " + name + " is allowed to drink");
                }

                else
                {
                    Console.WriteLine(name + " is not allowed to drink");
                }
            }

            Console.ReadLine();
        }

        private static bool TempIsWithinLegalRange(decimal temperature)
        {
            if (temperature > 22.5m && temperature < 30m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
