using System;

namespace DateLayer.Entities.Car.Make.Model.BmwModels
{
    public class BmxX5 : BmwModelBase
    {
        public override string Title => "X5";

        public BmxX5(DateTime creationDate) : base(creationDate)
        {}
    }
}