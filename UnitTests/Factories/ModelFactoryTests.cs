using DateLayer.Entities.Car.Make;
using DateLayer.Entities.Car.Make.Model;
using DateLayer.Entities.Car.Make.Model.ChevroletModels;
using Tools.Factories.MakeFactory;
using Tools.Factories.ModelFactory;
using System;
using System.Reflection;
using Tools.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Factories
{
    [TestClass]
    public class ModelFactoryTests
    {
        private IMakeFactory makeFactoryMock;
        private IModelFactory modelFactoryWithMock;
        private readonly IModelFactory modelFactory;

        private Type[] modelTypes;

        public ModelFactoryTests()
        {
            modelFactory = new ModelFactory(new MakeFactory());
            
            var modelBaseType = typeof(ModelBase);
            modelTypes = Assembly.GetAssembly(modelBaseType).GetClassesByBaseClass(modelBaseType);
        }

        [TestMethod]
        public void CreateTestWhenEachModelIsAvailable()
        {
            foreach(var modelType in modelTypes)
            {
                var actual = modelFactory.Create(modelType, DateTime.Now);
                Assert.IsNotNull(actual);
            }
        }


        [TestMethod]
        private void TestCasesWhenModelWithBadType()
        {
            // Входной тип не является производным типом модели.
            CreateTestWhenModelWithBadType(typeof(ChevroletMake));

            // Входной тип является производным от базового типа модели, но абстрактным.
            CreateTestWhenModelWithBadType(typeof(ChevroletModelBase));
        }

        private void CreateTestWhenModelWithBadType(Type modelType)
        {
            Assert.ThrowsException<NotSupportedException>(() => modelFactory.Create(modelType, DateTime.Now));
        }
    }
}
