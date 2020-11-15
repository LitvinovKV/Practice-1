using System;

namespace DateLayer.Entities.Car.Make.Model.AudiModels
{
    public class AudiA4 : AudiModelBase
    {
        public override string Title { get; } = "Audi A4";

        public AudiA4(DateTime creationDate) : base(creationDate)
        {}
    }
}