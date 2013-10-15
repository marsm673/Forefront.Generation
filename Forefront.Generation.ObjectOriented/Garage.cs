using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forefront.Generation.ObjectOriented
{
    public class Garage
    {
        public List<ParkingLot> garageList { get; set; }
        public Car CarInsideGarage { get; private set; }
        public bool parkingSuccesful { get; private set; }


        public Garage()
        {
            garageList = new List<ParkingLot>();

        }

        public void AddParkingLots(int numberOfSpotsToAdd)
        {
            for (int i = 0; i < numberOfSpotsToAdd; i++)
            {
                var parkingSpots = new ParkingLot();
                garageList.Add(parkingSpots);
            }
        }


        public void ParkCar(Car carToMove)
        {
            foreach (var parkingSpot in garageList)
            {
                if (parkingSpot.CarToMove == null)
                {
                    parkingSpot.ParkCar(carToMove);
                    parkingSuccesful = true; 
                    return;
                }
                else
                {
                    parkingSuccesful = false; 
                }

            }

        }

        public void RemoveCarFromGarage(Car carToMove)
        {
            foreach (var parkingSpot in garageList)
            {
                if (parkingSpot.CarToMove.Model == carToMove.Model)
                {
                    int index = garageList.IndexOf(parkingSpot);
                    Console.WriteLine("Ta bort");
                    parkingSpot.UnParkCar(carToMove);
                    //garageList[index] = null;
                        return; 
                }
            }
        }
        public void RemoveCarFromGarageList(Car carToRemove)
        {
            foreach (var parkingSpot in garageList)
            {
                if (parkingSpot.CarToMove.Model == carToRemove.Model)
                {
                    int index = garageList.IndexOf(parkingSpot);
                    garageList.Remove(parkingSpot);
                    //garageList[index] = null;
                    return;
                }
            }
        }


        public List<ParkingLot> getGarageList()
        {
            return garageList;
        }

    }
}
