using DateLayer.Entities.Car;
using Tools.Factories.MakeFactory;
using Tools.Factories.ModelFactory;
using System;
using System.Text.RegularExpressions;
using Tools.Extensions;

namespace Tools.Factories.CarFactory
{
    public class CarFactory : ICarFactory
    {
        private readonly IModelFactory modelFactory;
        private readonly IMakeFactory makeFactory;

        private readonly string carNumberPattern = "[А-Я][0-9]{3}[А-Я]{2}[0-9]{2,3}";

        public CarFactory(
            IModelFactory modelFactory,
            IMakeFactory makeFactory
        )
        {
            this.modelFactory = modelFactory;
            this.makeFactory = makeFactory;
        }

        public CarBase Create(Type modelType, string number, Color color, State state, DateTime modelCreation)
        {
            if(number.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Car number must be init.");
            }

            if(!Regex.IsMatch(number, carNumberPattern))
            {
                throw new ArgumentException("Incorrect car number format.");
            }

            var model = modelFactory.Create(modelType, modelCreation);
            var make = makeFactory.Create(model.MakeType);

            return new CarBase
            {
                Number = number,
                Make = make,
                Color = color,
                Model = model,
                State = state
            };
        }
    }
}
