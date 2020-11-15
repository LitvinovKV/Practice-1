using DateLayer.Entities.Car;
using DateLayer.Entities.Car.Make;
using DateLayer.Entities.Car.Make.Model.ChevroletModels;
using Tools.Factories.CarFactory;
using Tools.Factories.MakeFactory;
using Tools.Factories.ModelFactory;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Factories
{
    [TestClass]
    public class CarFactoryTests
    {
        private readonly IModelFactory modelFactory;
        private readonly IMakeFactory makeFactory;
        private readonly ICarFactory carFactory;

        public CarFactoryTests()
        {
            makeFactory = new MakeFactory();
            modelFactory = new ModelFactory(makeFactory);
            carFactory = new CarFactory(modelFactory, makeFactory);
        }

        [TestMethod]
        public void CreateTestWhenCarWithCorrectFields()
        {
            var carModelType = typeof(ChevroletBlazer);
            var carNumber = "М123АЯ987";
            var creationDate = DateTime.Now;
            var expectedCar = new CarBase
            {
                Number = carNumber,
                Make = new ChevroletMake(),
                Model = new ChevroletBlazer(creationDate),
                Color = Color.Red,
                State = State.AtHome
            };
            
            var actual = carFactory.Create(carModelType, carNumber, Color.Red, State.AtHome, creationDate);

            Assert.AreEqual(expectedCar.Color, actual.Color);
            Assert.AreEqual(expectedCar.State, actual.State);
            Assert.AreEqual(expectedCar.Number, actual.Number);
            Assert.AreEqual(expectedCar.Model.GetType(), actual.Model.GetType());
            Assert.AreEqual(expectedCar.Make.GetType(), actual.Make.GetType());
        }

        [TestMethod]
        public void CreateTestWhenCarWithNotInitNumber()
        {
            var carModelType = typeof(ChevroletCamaro);
            string carNumber = null;
            var creationDate = DateTime.Now;
            
            Assert.ThrowsException<ArgumentNullException>(() => carFactory.Create(carModelType, carNumber, Color.Red, State.AtHome, creationDate));
        }
        
        [TestMethod]
        public void CreateTestWhenCarWithEmptyNumber()
        {
            var carModelType = typeof(ChevroletCamaro);
            string carNumber = "";
            var creationDate = DateTime.Now;
            
            Assert.ThrowsException<ArgumentNullException>(() => carFactory.Create(carModelType, carNumber, Color.Red, State.AtHome, creationDate));
        }
        
        [TestMethod]
        public void CreateTestWhenCarWithBadNumber()
        {
            var carModelType = typeof(ChevroletCamaro);
            string carNumber = "12А2ААА";
            var creationDate = DateTime.Now;
            
            Assert.ThrowsException<ArgumentException>(() => carFactory.Create(carModelType, carNumber, Color.Red, State.AtHome, creationDate));
        }
    }
}
