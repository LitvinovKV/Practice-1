using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Tools.CarNumberGenerator;

namespace UnitTests.Tools
{
    [TestClass]
    public class CarNumberGeneratorTests
    {
        private readonly ICarNumberGenerator carNumberGenerator;

        private readonly string RuCarNumberPattern = "[А-Я][0-9]{3}[А-Я]{2}[0-9]{2,3}$";

        public CarNumberGeneratorTests()
        {
            carNumberGenerator = new CarRuNumberGenerator();
        }

        [TestMethod]
        public void GenerateRuNumberTest()
        {
            for(var i = 0; i < 1000; i++)
            {
                var actual = carNumberGenerator.Generate();

                Assert.IsNotNull(actual);
                Assert.AreEqual(true, !string.IsNullOrEmpty(actual));
                Assert.AreEqual(true, Regex.IsMatch(actual, RuCarNumberPattern));
            }
        }
    }
}
