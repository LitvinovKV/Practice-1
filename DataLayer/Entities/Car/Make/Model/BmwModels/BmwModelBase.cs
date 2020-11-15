using System;

namespace DateLayer.Entities.Car.Make.Model.BmwModels
{
    public abstract class BmwModelBase : ModelBase
    {
        public override Type MakeType => typeof(BmwMake);

        public BmwModelBase(DateTime creationDate) : base(creationDate)
        {}
    }
}