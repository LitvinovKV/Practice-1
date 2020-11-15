using System;

namespace DateLayer.Entities.Car.Make.Model.ChevroletModels
{
    public class ChevroletAlero : ChevroletModelBase
    {
        public override string Title => "Alero";

        public ChevroletAlero(DateTime creationDate) : base(creationDate)
        {}
    }
}