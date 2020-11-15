using System;

namespace DateLayer.Entities.Car.Make.Model.AudiModels
{
    public class AudiQ3 : AudiModelBase
    {
        public override string Title { get; } = "Audi Q3";

        public AudiQ3(DateTime creationDate) : base(creationDate)
        {}
    }
}