using DataLayer.Entities;
using DateLayer.Entities.Car;
using System.Collections.Generic;

namespace Tools.FileSaver.JSON
{
    public class ProjectInfoDto
    {
        public HashSet<CarBase> Cars { get; set; }
        public HashSet<CarBase> ParkingCars { get; set; }
        public int ParkingCapacity { get; set; }
        public int LookingParkingCars { get; set; }
        public int NewCarsPerMonth { get; set; }
        public int UtilizedCarsPerMonth { get; set; }
        public double NewCarChance { get; set; }
        public double CarsUtilizationChance { get; set; }
        public double CarsStatusChance { get; set; }

    }
}
