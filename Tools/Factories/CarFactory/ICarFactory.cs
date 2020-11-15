using DateLayer.Entities.Car;
using System;

namespace Tools.Factories.CarFactory
{
    public interface ICarFactory
    {
        CarBase Create(Type modelType, string number, Color color, State state, DateTime modelCreation);
    }
}
