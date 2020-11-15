using System;

namespace DateLayer.Entities.Car.Make.Model.RenaultModels
{
    public class RenaultDuster : RenaultModelBase
    {
        public override string Title => "Duster";

        public RenaultDuster(DateTime creationDate) : base(creationDate)
        {}
    }
}