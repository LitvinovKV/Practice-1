using System;

namespace DateLayer.Entities.Car.Make.Model.RenaultModels
{
    public abstract class RenaultModelBase : ModelBase
    {
        public override Type MakeType => typeof(RenaultMake);
        public RenaultModelBase(DateTime creationDate) : base(creationDate)
        {}
    }
}