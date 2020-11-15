using System;

namespace DateLayer.Entities.Car.Make.Model.SkodaModels
{
    public class SkodaRapid : SkodaModel
    {
        public override string Title => "Rapid";

        public SkodaRapid(DateTime creationDate) : base(creationDate)
        {}
    }
}