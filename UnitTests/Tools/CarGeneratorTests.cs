using DateLayer.Entities.Car;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tools.CarGenerator;
using Tools.CarNumberGenerator;
using Tools.Extensions;
using Tools.Factories.CarFactory;
using Tools.Factories.MakeFactory;
using Tools.Factories.ModelFactory;

namespace UnitTests.Tools
{
    [TestClass]
    public class CarGeneratorTests
    {
        private readonly ICarGenerator carGenerator;
        private readonly ICarNumberGenerator carNumberGenerator;
        private readonly ICarFactory carFactory;
        private readonly IMakeFactory makeFactory;
        private readonly IModelFactory modelFactory;

        public CarGeneratorTests()
        {
            makeFactory = new MakeFactory();
            modelFactory = new ModelFactory(makeFactory);
            carNumberGenerator = new CarRuNumberGenerator();
            carFactory = new CarFactory(modelFactory, makeFactory);
            carGenerator = new CarGenerator(carNumberGenerator, carFactory);
        }

        [TestMethod]
        public void GenerateTest()
        {
            for(var i = 0; i < 1000; i++)
            {
                var actualCar = carGenerator.Generate();

                Assert.IsNotNull(actualCar.Model);
                Assert.IsNotNull(actualCar.Make);
                Assert.IsTrue(EnumExtensionsGeneric<Color>.GetValues().Any(x => x == actualCar.Color));
                Assert.IsTrue(EnumExtensionsGeneric<State>.GetValues().Any(x => x == actualCar.State));
                Assert.AreEqual(true, !string.IsNullOrEmpty(actualCar.Number));
                Assert.IsNotNull(actualCar.Number);
            }
        }
    }
}
