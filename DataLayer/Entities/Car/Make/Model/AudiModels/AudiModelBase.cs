using System;

namespace DateLayer.Entities.Car.Make.Model.AudiModels
{
    public abstract class AudiModelBase : ModelBase
    {
        public override Type MakeType => typeof(AudiMake);

        public AudiModelBase(DateTime creationDate) : base(creationDate)
        {}
    }
}