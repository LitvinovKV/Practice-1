using System;

namespace DateLayer.Entities.Car.Make.Model.BmwModels
{
    public class BmwI8 : BmwModelBase
    {
        public override string Title => "I8";

        public BmwI8(DateTime creationDate) : base(creationDate)
        {}
    }
}