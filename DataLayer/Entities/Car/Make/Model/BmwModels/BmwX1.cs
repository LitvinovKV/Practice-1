using System;

namespace DateLayer.Entities.Car.Make.Model.BmwModels
{
    public class BmwX1 : BmwModelBase
    {
        public override string Title  => "X1";

        public BmwX1(DateTime creationDate) : base(creationDate)
        {}
    }
}