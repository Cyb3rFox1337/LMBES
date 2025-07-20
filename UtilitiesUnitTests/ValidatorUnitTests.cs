using LMBES.Utilities;

namespace UtilitiesUnitTests
{
    public class ValidatorUnitTests
    {
        public enum _Enum
        {
            a = 0,
            b = 1, 
            c = 2
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ValidateString_InvalidString_ThrowsArgumentException(string? value) =>
            Assert.Throws<ArgumentException>(() => Validator.ValidateString(value, "String"));
        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void ValidateInteger_InvalidInteger_ThrowsArgumentOutOfRangeException(int value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => Validator.ValidateInteger(value, "Integer"));
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(int.MaxValue)]
        public void ValidateEnum_InvalidEnum_ThrowArgumentOutOfRangeException(_Enum value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => Validator.ValidateEnum(value, "Enum"));
        [Test]
        [TestCase(null)]
        public void ValidateObject_InvalidObject_ThrowArgumentNullException(object? value) =>
            Assert.Throws<ArgumentNullException>(() => Validator.ValidateObject(value, "Object"));
    }
}