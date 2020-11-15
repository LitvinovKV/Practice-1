using DataLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Reflection;
using Tools.CarGenerator;
using Tools.ProbabilityChanger;

namespace UnitTests.Tools
{
    [TestClass]
    public class CityProbabilityChangerTests
    {
        private ICityProbabilityChanger probabilityChanger {get; set;}
        private ICarGenerator carGenerator { get; set; }

        public CityProbabilityChangerTests()
        {
            carGenerator = MockRepository.GenerateStub<ICarGenerator>();
            probabilityChanger = new CityProbabilityChanger(new City(new Parking()), carGenerator);
        }


        [TestMethod]
        public void CarStatusChangeWhenBadValueTestCases()
        {
            ChangeValueCheckWhenBadValueTest(-1);
            ChangeValueCheckWhenBadValueTest(-0.5);
            ChangeValueCheckWhenBadValueTest(-0.1);
            ChangeValueCheckWhenBadValueTest(1.1);
            ChangeValueCheckWhenBadValueTest(1.5);
            ChangeValueCheckWhenBadValueTest(2);
        }

        private void ChangeValueCheckWhenBadValueTest(double value)
        {
            var method = probabilityChanger.GetType().GetMethod("ChanceValueCheck", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.ThrowsException<TargetInvocationException>(() => method.Invoke(probabilityChanger, new object[] { value, "METHOD NAME" }));
        }
    }
}
