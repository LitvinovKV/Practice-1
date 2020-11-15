using DateLayer.Entities.Car.Make;
using Tools.Factories.MakeFactory;
using System;
using System.Reflection;
using Tools.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Factories
{
    [TestClass]
    public class MakeFactoryTests
    {
        private readonly IMakeFactory makeFactory;

        private readonly Type[] makeTypes;

        public MakeFactoryTests()
        {
            makeFactory = new MakeFactory();

            var makeBaseType = typeof(MakeBase);
            makeTypes = Assembly.GetAssembly(makeBaseType).GetClassesByBaseClass(makeBaseType);
        }

        [TestMethod]
        public void ReturnTypeIsCorrectWhenCreate()
        {
            foreach (var makeType in makeTypes)
            {
                var actual = makeFactory.Create(makeType);
                Assert.AreEqual(actual.GetType(), makeType);
            }
        }

        [TestMethod]
        public void ReturnSameObjectWhenCreate()
        {
            foreach (var makeType in makeTypes)
            {
                var make1 = makeFactory.Create(makeType);
                var make2 = makeFactory.Create(makeType);
                Assert.AreSame(make1, make2);
            }
        }

        [TestMethod]
        public void CreateTestWhenMakeWithBadType()
        {
            Assert.ThrowsException<ArgumentException>(() => makeFactory.Create(typeof(MakeBase)));
        }
    }
}
