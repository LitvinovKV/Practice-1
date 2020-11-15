using System;

namespace DateLayer.Entities.Car.Make.Model.RenaultModels
{
    public class RenaultFluence : RenaultModelBase
    {
        public override string Title => "Fluence";

        public RenaultFluence(DateTime creationDate) : base(creationDate)
        {}
    }
}