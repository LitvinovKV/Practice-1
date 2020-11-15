using DateLayer.Entities.Car.Make.Model;
using System;

namespace Tools.Factories.ModelFactory
{
    public interface IModelFactory
    {
        ModelBase Create(Type modelType, DateTime creationDate);
    }
}
