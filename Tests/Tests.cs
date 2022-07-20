using NUnit.Framework;
using FigureLib;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void CreateCircle_WrongRadius_ThrowsException(double radius)
        {
            Assert.Catch(() => new Circle(radius));
        }


        [Test]
        [TestCase(6, 113.09)]
        [TestCase(5, 78.53)]
        [TestCase(4, 50.26)]
        public void Square_Circle_ReturnsCorrectResult(double radius, double expected)
        {
            var circle = new Circle(radius);
            var actual = circle.Square;
            Assert.AreEqual(expected, actual, 0.01);
        }

        [Test]
        [TestCase(4, 4, 4, 6.928)]
        [TestCase(3, 4, 5, 6)]
        [TestCase(7, 10, 5, 16.248)]
        public void Square_Triangle_ReturnsCorrectResult(double ab, double bc, double ca, double expected)
        {
            var triangle = new Triangle(ab, bc, ca);
            var actual = triangle.Square;
            Assert.AreEqual(expected, actual, 0.01);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(-1, 5, 10)]
        [TestCase(100, 10, 15)]
        public void CreateTriangle_WrongSideSizes_ThrowsException(double ab, double bc, double ca)
        {
            Assert.Catch(() => new Triangle(ab, bc, ca));
        }

        [Test]
        [TestCase(3, 4, 5)]
        [TestCase(2,3,3.605)]
        public void IsRight_RightTriangle_ReturnsTrue(double ab, double bc, double ca)
        {
            var triangle = new Triangle(ab, bc, ca);
            Assert.IsTrue(triangle.IsRight());
        }

        [Test]
        [TestCase(4, 4, 4)]
        [TestCase(3, 4, 6)]
        [TestCase(7, 10, 5)]
        public void IsRight_Triangle_ReturnsFalse(double ab, double bc, double ca)
        {
            var triangle = new Triangle(ab, bc, ca);
            Assert.IsFalse(triangle.IsRight());
        }
    }
}