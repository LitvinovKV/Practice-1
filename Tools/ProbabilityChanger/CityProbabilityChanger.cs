using DataLayer.Entities;
using DateLayer.Entities.Car;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Tools.CarGenerator;
using Tools.Extensions;

namespace Tools.ProbabilityChanger
{
    public class CityProbabilityChanger : ICityProbabilityChanger
    {
        private readonly Random rand;
        private readonly City city;
        private readonly ICarGenerator carGenerator;

        public CityProbabilityChanger(City city, ICarGenerator carGenerator)
        {

            this.city = city;
            this.carGenerator = carGenerator;

            rand = new Random();
        }

        private double carsStatusChance = 0.4;
        public double CarsStatusChance
        {
            get => carsStatusChance;
            set
            {
                carsStatusChance = ChanceValueCheck(value, "CarStatusChance");
            }
        }

        //private double carsUtilizationChance = 0.01;
        private double carsUtilizationChance = 0.5;
        public double CarsUtilizationChance
        {
            get => carsUtilizationChance; 
            set
            {
                carsUtilizationChance = ChanceValueCheck(value, "CarUtilizationChance");
            }
        }

        private double newCarChance = 0.7;
        public double NewCarChance
        {
            get => newCarChance; 
            set
            {
                newCarChance = ChanceValueCheck(value, "NewCarChance");
            }
        }

        #region PER HOUR EVENTS
        public void NewCarAction()
        {
            var chanceVal = rand.NextDouble();

            if (chanceVal <= newCarChance)
            {
                return;
            }

            var newCar = carGenerator.Generate();

            lock(city.CarsHashSetLock)
            {
                city.Cars.Add(newCar);
                city.NewCarsCounter++;
            }

            Debug.WriteLine(newCar.ToString());
        }
        #endregion

        #region PER DAY EVENTS
        public void CarsStatusChangeAction()
        {
            lock(city.CarsHashSetLock)
            {
                city.Parking.Cars.Clear();
             
                foreach (var car in city.Cars)
                {
                    var chanceVal = rand.NextDouble();

                    if (chanceVal <= carsStatusChance)
                    {
                        continue;
                    }

                    var oldState = car.State;
                    var randState = RandState();
                    car.State = randState;

                    Debug.WriteLine($"У машины {car.Number} поменялся статус с {oldState} на {car.State}");

                    switch (car.State)
                    {
                        case State.LookingParking:
                            city.LookingParkingCarsCounter++;
                            break;
                        case State.InParking:
                            if (city.Parking.Cars.Count >= city.Parking.Capacity)
                            {
                                Debug.WriteLine($"Вместимость парковки переполнена. Машина с номерами {car.Number} переведа в статус Ищу парковку.");
                                car.State = State.LookingParking;
                                city.LookingParkingCarsCounter++;
                            }
                            else
                            {
                                city.Parking.Cars.Add(car);
                            }
                            break;
                    }
                }
            }
        }
        #endregion

        #region PER MONTH EVENTS
        public void CarsUtilizationAction()
        {
            var utilizedCars = new HashSet<CarBase>();
         
            lock (city.CarsHashSetLock)
            {
                foreach (var car in city.Cars)
                {
                    var chanceVal = rand.NextDouble();

                    if (chanceVal <= carsUtilizationChance)
                    {
                        continue;
                    }

                    utilizedCars.Add(car);
                }

                city.UtilizeCarsCounter += utilizedCars.Count;
                city.Cars.ExceptWith(utilizedCars);
            }
        }
        #endregion
        

        private double ChanceValueCheck(double value, string methodName)
        {
            if(value < 0 || value > 1)
            {
                throw new ArgumentException($"Input value in {methodName} must be >= 0 && <= 1");
            }

            return value;
        }

        private State RandState()
        {
            var maxStateValue = (int)EnumExtensionsGeneric<State>.GetMaxValue();
            
            return (State) rand.Next(0, maxStateValue + 1);

        }
    }
}
