using DateLayer.Entities.Car.Make;
using System;

namespace Tools.Factories.MakeFactory
{
    public interface IMakeFactory
    {
        MakeBase Create(Type makeType);
    }
}
