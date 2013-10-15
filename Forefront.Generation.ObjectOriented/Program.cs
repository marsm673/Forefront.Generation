using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Forefront.Generation.ObjectOriented
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("EDP511", "Volvo");
            myCar.ChangeColor(Color.Black);

            Engine myEngine = new Engine(900, 8);
               
            myCar.AddEngine(myEngine);
            myCar.Start();

            Console.WriteLine(myCar.Created);


            Console.ReadLine(); 

        }
    }
}
