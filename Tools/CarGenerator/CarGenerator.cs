using DateLayer.Entities.Car;
using DateLayer.Entities.Car.Make.Model;
using System;
using System.Reflection;
using Tools.CarNumberGenerator;
using Tools.Extensions;
using Tools.Factories.CarFactory;

namespace Tools.CarGenerator
{
    public class CarGenerator : ICarGenerator
    {
        private readonly ICarNumberGenerator carNumberGenerator;
        private readonly ICarFactory carFactory;

        private readonly Type[] allModelTypes;
        private readonly DateTime startDate = new DateTime(2015, 1, 1);

        public CarGenerator(ICarNumberGenerator carNumberGenerator, ICarFactory carFactory)
        {
            this.carNumberGenerator = carNumberGenerator;
            this.carFactory = carFactory;

            var modelBaseType = typeof(ModelBase);
            allModelTypes = Assembly.GetAssembly(modelBaseType).GetClassesByBaseClass(modelBaseType);
        }

        public CarBase Generate()
        {
            var random = new Random();

            var randModelType = random.Next(allModelTypes.Length);
            var carNumber = carNumberGenerator.Generate();
            var randColor = RandomColor();
            var randDateCreation = DateTimeExtensions.RandomDate(startDate);

            return carFactory.Create(allModelTypes[randModelType], carNumber, randColor, State.AtHome, randDateCreation);

            Color RandomColor()
            {
                var arrayOfColors = Enum.GetValues(typeof(Color));
                return (Color)arrayOfColors.GetValue(random.Next(arrayOfColors.Length));
            }
        }
    }
}
