using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.ObjectOriented
{
    public class Car
    {
        // Properties 

        public Color Color { get; private set; }
        public string RegNumber { get; set; }

        public DateTime Created { get; private set; }
        public DateTime TimeParked { get; private set; }

        private Engine _engine; 

        public string Model { get; private set; }

        //public bool IsParked { get; private set; }

        

        // Constructor - det man vill kunna påverka men inte förändra sen 
        public Car(string model, string regNumber)
        {
            Model = model; 
            RegNumber = regNumber;
            Color = Color.Gray;
            Created = DateTime.Now;

        }

        // Methods 
        public void ChangeColor(Color color)
        {
            Color = color; 
        }

        

        public void AddEngine(Engine engine)
        {
            if (_engine != null)
            {
                throw new Exception("There was already an engine in this car");
            }
            else
            {
                _engine = engine;      
            }
            
        } 

        public void Start()
        {
            _engine.StartEngine();
        }

        public void Stop()
        {
            _engine.StopEngine();
        }

    }
}
