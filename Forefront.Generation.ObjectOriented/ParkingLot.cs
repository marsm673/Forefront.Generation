using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.ObjectOriented
{
    public class ParkingLot
    {
        public bool IsOccupied { get; set; }
        public DateTime TimeEntered { get; set; }
        public DateTime TimeLeft { get; set; }
        public Car CarToMove { get; set; }  

    public ParkingLot()
    {
        IsOccupied = false; 
    }

    public void ParkCar(Car car)
    {
        IsOccupied = true;
        CarToMove = car;
        TimeEntered = DateTime.Now; 
    }
    public void UnParkCar(Car car)
    {
        IsOccupied = false;
        CarToMove = car;
        TimeLeft = DateTime.Now; 
    }

    public void ShowCar(Car car)
    {
        CarToMove = car; 
    
    }


    }
}
