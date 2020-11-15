using System;

namespace DateLayer.Entities.Car.Make.Model.ChevroletModels
{
    public class ChevroletCamaro : ChevroletModelBase
    {
        public override string Title => "Camaro";

        public ChevroletCamaro(DateTime creationDate) : base(creationDate)
        {}
    }
}