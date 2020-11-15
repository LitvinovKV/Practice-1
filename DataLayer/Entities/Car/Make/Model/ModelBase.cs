using System;

namespace DateLayer.Entities.Car.Make.Model
{
    public abstract class ModelBase
    {
        public abstract string Title { get; }
        public abstract Type MakeType { get; }
        public DateTime Creation { get; set; }

        public ModelBase(DateTime creationDate)
        {
            Creation = creationDate;
        }

        public override int GetHashCode()
        {
            return Creation.GetHashCode() ^ Title.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var otherModel = obj as ModelBase;

            if (otherModel == null)
            {
                return false;
            }

            return this.Creation == otherModel.Creation
                && this.Title == otherModel.Title
                && this.MakeType == otherModel.MakeType;
        }
    }
}