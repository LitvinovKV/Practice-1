using System;

namespace DateLayer.Entities.Car.Make.Model.SkodaModels
{
    public abstract class SkodaModel : ModelBase
    {
        public override Type MakeType => typeof(SkodaMake);

        public SkodaModel(DateTime creationDate) : base(creationDate)
        {}
    }
}