using DateLayer.Entities.Car;

namespace Tools.CarGenerator
{
    public interface ICarGenerator
    {
        CarBase Generate();
    }
}
