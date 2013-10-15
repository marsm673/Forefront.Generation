using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forefront.Generation.ObjectOriented;

namespace Forefront.Generation.Lists
{
    class Program
    {
        static Garage defaultGarage;
        static void Main(string[] args)
        {
            SkrivUtMetod();
            Console.SetWindowSize(100, 50);
            defaultGarage = new Garage();
            CheckSizeOnGarage();
            newParking();

        
        }

        private static void SkrivUtMetod()
        {
            Console.WriteLine("test");
            Console.WriteLine("sjj");
        }

       


        public static void newParking()
        {
            if (WantToPark())
            {
                Car CarInAction = WhatIsYourCar();
                defaultGarage.ParkCar(CarInAction);
                if (defaultGarage.parkingSuccesful)
                {
                    Console.WriteLine("Bilen som körs in är " + CarInAction.Model + " " + CarInAction.RegNumber);
                }
                else
                {
                    Console.WriteLine("Garaget är tyvärr fullt, följande bil " + CarInAction.Model + " " + CarInAction.RegNumber + " fick tyvärr inte plats i detta magnifika garage bättre lycka nästa gång!");
                }
                newParking();
            }

            else if (WantToExit())
            {
                List<ParkingLot> GarageShow = defaultGarage.getGarageList();

                WriteOutCarsInGarage(GarageShow);

                Console.WriteLine("\n");

                int input = CheckWhichCarToRemoveFromGarage();
                Console.WriteLine(input);
                Console.WriteLine("Bilen som körs ut är " + defaultGarage.garageList[input].CarToMove.Model + " " + defaultGarage.garageList[input].CarToMove.RegNumber);
                DateTime timeEntered = defaultGarage.garageList[input].TimeEntered;

                defaultGarage.RemoveCarFromGarage(defaultGarage.garageList[input].CarToMove);

                DateTime timeLeft = DateTime.Now;
                TimeSpan timeParked = timeLeft.Subtract(timeEntered);
                
                if (timeParked.TotalHours < 1 && timeEntered.TimeOfDay.Hours < 18 && timeEntered.TimeOfDay.Hours > 8)
                {
                    int CostOfParking = 10;
                    double AmountToPay = CostOfParking * (timeParked.TotalHours);
                    Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
                }
                else if (timeParked.TotalHours > 1 && timeParked.TotalHours < 2 && timeEntered.TimeOfDay.Hours < 18 && timeEntered.TimeOfDay.Hours > 8)
                {
                    int CostOfParking = 6;
                    double AmountToPay = CostOfParking * (timeParked.TotalHours);
                    Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
                }

                else if (timeParked.TotalHours > 2 && timeParked.TotalHours < 10)
                {
                    int CostOfParking = 4;
                    double AmountToPay = CostOfParking * (timeParked.TotalHours);
                    Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
                }
                //defaultGarage.RemoveCarFromGarageList(defaultGarage.garageList[input].CarToMove);
                newParking();
            }

            else if (WantToShowList())
            {
                List<ParkingLot> GarageShow = defaultGarage.getGarageList();

                Console.WriteLine("Kommer in i WantToShowList");

                WriteOutCarsInGarage(GarageShow);

                newParking();
            }

            else
            {
                Console.WriteLine("Du måste göra ett val - var god pröva igen");
                newParking();

            }
        }

        private static void WriteOutCarsInGarage(List<ParkingLot> GarageShow)
        {
            foreach (ParkingLot garageItem in GarageShow)
            {

                if (garageItem.IsOccupied)
                {
                    Car car = garageItem.CarToMove;
                    Console.WriteLine(GarageShow.IndexOf(garageItem));
                    Console.WriteLine(car.Model);
                    Console.WriteLine(car.RegNumber);
                    Console.WriteLine(garageItem.TimeEntered);

                }

            }
        }

        private static void CheckTimeInGarage(int input, out DateTime timeEntered, out TimeSpan timeParked)
        {
            DateTime timeLeft = DateTime.Now;
            timeEntered = defaultGarage.garageList[input].TimeEntered;
            timeParked = timeLeft.Subtract(timeEntered);
        }

        public static Car WhatIsYourCar()
        {
            Console.Write("Skriv in din modell: ");
            string newModel = Console.ReadLine();
            Console.Write("Skriv in ditt registreringsnummer: ");
            string newRegNumber = Console.ReadLine();
            Car newCar = new Car(newModel, newRegNumber);
            bool existsInGarage = CheckIfCarIsInGarage(newCar);
            if (existsInGarage)
            {

                if (WantToExit())
                {

                    Console.WriteLine("Bilen som körs ut är: " + newCar.Model + " " + newCar.RegNumber);
                    List<ParkingLot> TimeParkAssistance = defaultGarage.garageList;

                    DateTime timeLeft;
                    DateTime timeEntered;

                    foreach (ParkingLot p in TimeParkAssistance)
                    {
                        if (newCar.Model == p.CarToMove.Model)
                        {
                            defaultGarage.RemoveCarFromGarage(newCar);
                            timeLeft = p.TimeLeft;
                            timeEntered = p.TimeEntered;
                            TimeSpan timeParked = timeLeft.Subtract(timeEntered);

                            if (timeParked.TotalHours < 1 && timeEntered.TimeOfDay.Hours < 18 && timeEntered.TimeOfDay.Hours > 8)
                            {
                                int CostOfParking = 10;
                                double AmountToPay = CostOfParking * (timeParked.TotalHours);
                                Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
                            }
                            else if (timeParked.TotalHours > 1 && timeParked.TotalHours < 2 && timeEntered.TimeOfDay.Hours < 18 && timeEntered.TimeOfDay.Hours > 8)
                            {
                                int CostOfParking = 6;
                                double AmountToPay = CostOfParking * (timeParked.TotalHours);
                                Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
                            }

                            else if (timeParked.TotalHours > 2 && timeParked.TotalHours < 10)
                            {
                                int CostOfParking = 4;
                                double AmountToPay = CostOfParking * (timeParked.TotalHours);
                                Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
                            }
                            break;
                        }
                    }

                    newParking();

                }
                else if (WantToShowList())
                {
                    Console.WriteLine("visar listan");
                    List<ParkingLot> GarageShow = defaultGarage.getGarageList();

                    foreach (ParkingLot garageItem in GarageShow)
                    {

                        if (garageItem.IsOccupied)
                        {
                            Car car = garageItem.CarToMove;
                            Console.WriteLine(car.Model);
                            Console.WriteLine(car.RegNumber);
                            Console.WriteLine(garageItem.TimeEntered);
                            Console.WriteLine(garageItem.TimeLeft);
                        }

                    }

                    newParking();

                }
            }

            return newCar;
        }

        private static bool CheckIfCarIsInGarage(Car car)
        {

            foreach (ParkingLot parkinglot in defaultGarage.garageList)
            {
                if (parkinglot.IsOccupied)
                {
                    if (car.Model == parkinglot.CarToMove.Model && car.RegNumber == parkinglot.CarToMove.RegNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckIfUserWantToRemoveFromGarage()
        {
            Console.WriteLine("Vill du köra ut någon bil ur garaget? - J/N?");
            string input = Console.ReadLine();
            if (input == "J" || input == "j")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static int CheckWhichCarToRemoveFromGarage()
        {
            Console.Write("Vilken bil vill du köra ut? - Ange nummer: ");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;

        }

        private static string RequestForParkingAlternative()
        {
            Console.Write("Vill du parkera tryck J, vill du köra någon bil ur garaget tryck N eller tryck visa för att visa bilarna i garaget: ");
            string wantToPark = Console.ReadLine();
            return wantToPark;
        }

        private static bool WantToPark()
        {
            Console.Write("Vill parkera J/N?");
            string wantToPark = Console.ReadLine();
            if (wantToPark == "j" || wantToPark == "J")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool WantToExit()
        {
            Console.Write("Vill köra ut din bil J/N?");
            string wantToExit = Console.ReadLine();
            if (wantToExit == "j" || wantToExit == "J")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool WantToShowList()
        {
            Console.Write("Vill du visa bilarna i garaget J/N?");
            string wantToShowListInGarage = Console.ReadLine();
            if (wantToShowListInGarage == "j" || wantToShowListInGarage == "J")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static void CheckSizeOnGarage()
        {
            Console.Write("Hur många platser stort skall garaget vara? - Ange en siffra mellan 0 och 1000: ");
            int size = Convert.ToInt32(Console.ReadLine());
            defaultGarage.AddParkingLots(size);
        }

        //DateTime timeLeft = defaultGarage.garageList[input].TimeLeft;
        //       DateTime timeEntered = defaultGarage.garageList[input].TimeEntered;
        //       TimeSpan timeParked = timeLeft.Subtract(timeEntered);
        //       if (timeParked.TotalHours < 1 && timeEntered.TimeOfDay.Hours < 18 && timeEntered.TimeOfDay.Hours > 8)
        //       {
        //           int CostOfParking = 10;
        //           double AmountToPay = CostOfParking * (timeParked.TotalHours);
        //           Console.WriteLine("Kostnaden för parkeringen är " + AmountToPay);
        //       }


    }
}
