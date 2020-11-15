using DateLayer.Entities.Car;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataLayer.Entities
{
    public class Parking
    {
        public static readonly int MIN_SIZE = 10;
        public static readonly int MAX_SIZE = 10000;

        public int Capacity { get; set;  }
        public HashSet<CarBase> Cars { get; set; }

        public Parking()
        {
            Capacity = 10;
            //Capacity = MAX_SIZE / 2;
            Cars = new HashSet<CarBase>();
        }
    }
}
