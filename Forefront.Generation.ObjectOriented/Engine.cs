using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.ObjectOriented
{
   public class Engine
    {
       public int CubicCentimeters  { get; private set; }
       public int Cylinders         { get; private set; }
       public bool IsRunning        { get; private set; }

       public Engine(int cubicCentimeters, int cylinders)
       {
           CubicCentimeters = cubicCentimeters;
           Cylinders = cylinders; 
       }

       public void StartEngine()
       {
           IsRunning = true; 
       }

       public void StopEngine()
       {
           IsRunning = false; 
       }

    }
}
