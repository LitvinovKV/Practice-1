using System;

namespace DateLayer.Entities.Car.Make.Model.SkodaModels
{
    public class SkodaKaroq : SkodaModel
    {
        public override string Title => "Karoq";

        public SkodaKaroq(DateTime creationDate) : base(creationDate)
        {}
    }
}