using NUnit.Framework;
using System;

namespace TestApp.UnitTests
{
    [TestFixture]
    public class PlanetTests
    {
        [Test]
        public void Test_CalculateGravity_ReturnsCorrectCalculation()
        {
            // Arrange
            Planet earth = new Planet("Earth", 12742, 149600000, 1);
            double mass = 1000;
            double expectedGravity = mass * 6.67430e-11 / Math.Pow(earth.Diameter / 2, 2);

            // Act
            double resultGravity = earth.CalculateGravity(mass);

            // Assert
            Assert.That(resultGravity, Is.EqualTo(expectedGravity).Within(1e-10)); // Use Within to account for potential floating-point errors
        }

        [Test]
        public void Test_GetPlanetInfo_ReturnsCorrectInfo()
        {
            // Arrange
            Planet mars = new Planet("Mars", 6779, 227900000, 2);
            string expectedInfo = $"Planet: Mars{Environment.NewLine}Diameter: 6779 km{Environment.NewLine}Distance from the Sun: 227900000 km{Environment.NewLine}Number of Moons: 2";

            // Act
            string resultInfo = mars.GetPlanetInfo();

            // Assert
            Assert.That(resultInfo, Is.EqualTo(expectedInfo));
        }
    }
}

