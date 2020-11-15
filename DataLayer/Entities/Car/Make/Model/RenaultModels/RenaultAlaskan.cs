using System;

namespace DateLayer.Entities.Car.Make.Model.RenaultModels
{
    public class RenaultAlaskan : RenaultModelBase
    {
        public override string Title => "Alaskan";

        public RenaultAlaskan(DateTime creationDate) : base(creationDate)
        {}
    }
}