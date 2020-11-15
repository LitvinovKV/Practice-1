using System;

namespace DateLayer.Entities.Car.Make.Model.ChevroletModels
{
    public abstract class ChevroletModelBase : ModelBase
    {
        public override Type MakeType => typeof(ChevroletMake);

        public ChevroletModelBase(DateTime createionDate) : base(createionDate)
        {}
    }
}