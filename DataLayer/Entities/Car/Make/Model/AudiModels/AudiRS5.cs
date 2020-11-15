using System;

namespace DateLayer.Entities.Car.Make.Model.AudiModels
{
    public class AudiRS5 : AudiModelBase
    {
        public override string Title => "Audi RS5";

        public AudiRS5(DateTime creationDate) : base(creationDate)
        {}
    }
}