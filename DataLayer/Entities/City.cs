using DateLayer.Entities.Car;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class City
    {
        public static readonly int MIN_COUNTS_CARS = 100;
        public static readonly int MAX_COUNTS_CARS = 1000000;

        public object CarsHashSetLock { get; }

        public HashSet<CarBase> Cars { get; set; }
        public Parking Parking { get; set; }

        public int NewCarsCounter { get; set; }
        public int NewCarsPerMonthCount { get; set; }


        public int UtilizeCarsCounter {get; set;}
        public int UtilizeCarsPerMonthCount { get; set; }


        public int LookingParkingCarsCounter { get; set; }
        public int LookingParkingCarsCount { get; set; }

        public City(Parking parking)
        {
            Parking = parking;
            Cars = new HashSet<CarBase>();

            CarsHashSetLock = new object();
        }

        public void SetCountLookingParkingAction()
        {
            LookingParkingCarsCount = LookingParkingCarsCounter;
            LookingParkingCarsCounter = 0;
        }

        public void SetCountNewCarsAction()
        {
            NewCarsPerMonthCount = NewCarsCounter;
            NewCarsCounter = 0;
        }

        public void SetCountUtilizedCarsAction()
        {
            UtilizeCarsPerMonthCount = UtilizeCarsCounter;
            UtilizeCarsCounter = 0;
        }
    }
}
