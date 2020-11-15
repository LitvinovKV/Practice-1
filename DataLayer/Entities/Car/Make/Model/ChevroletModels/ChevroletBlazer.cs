using System;

namespace DateLayer.Entities.Car.Make.Model.ChevroletModels
{
    public class ChevroletBlazer : ChevroletModelBase
    {
        public override string Title => "Blazer";

        public ChevroletBlazer(DateTime creationDate) : base(creationDate)
        {}
    }
}