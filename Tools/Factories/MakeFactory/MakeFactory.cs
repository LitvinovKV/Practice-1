using DateLayer.Entities.Car.Make;
using System;
using System.Collections.Generic;

namespace Tools.Factories.MakeFactory
{
    public class MakeFactory : IMakeFactory
    {
        private readonly Dictionary<Type, MakeBase> makes = new Dictionary<Type, MakeBase>();

        public MakeBase Create(Type makeType)
        {
            if(makeType.BaseType != typeof(MakeBase))
            {
                throw new ArgumentException($"Параметр makeType = {makeType} не является дочерним классом {typeof(MakeBase)}.");
            }

            if (makes.ContainsKey(makeType))
            {
                return makes[makeType];
            }

            var newMake = Activator.CreateInstance(makeType) as MakeBase;
            makes.Add(makeType, newMake);

            return newMake;
        }
    }
}
