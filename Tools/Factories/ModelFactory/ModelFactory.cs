using DateLayer.Entities.Car.Make.Model;
using Tools.Factories.MakeFactory;
using System;

namespace Tools.Factories.ModelFactory
{
    public class ModelFactory : IModelFactory
    {
        private readonly IMakeFactory makeFactory;

        public ModelFactory(IMakeFactory makeFactory)
        {
            this.makeFactory = makeFactory;
        }

        public ModelBase Create(Type modelType, DateTime creationDate)
        {
            if(!modelType.IsSubclassOf(typeof(ModelBase)) || modelType.IsAbstract)
            {
                throw new NotSupportedException($"Переданный параметр типа {modelType} не является типом конкретной модели машины {typeof(ModelBase)}.");
            }

            var model = Activator.CreateInstance(modelType, new object[] { creationDate }) as ModelBase;
            var make = makeFactory.Create(model.MakeType);

            if(make == null)
            {
                throw new NullReferenceException($"Не удалось получить тип марки модели {model.MakeType}.");
            }

            return model;
        }
    }
}
