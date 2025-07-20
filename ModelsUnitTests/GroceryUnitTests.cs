using LMBES.Models;
using LMBES.Services;
using Moq;

namespace ModelsUnitTests;
public class GroceryUnitTests
{
    private Grocery _Grocery;
    [SetUp]
    public void Setup()
    {
        _Grocery = new Grocery(new DateTime(2025, 12, 20), 10);
    }
    [Test]
    [TestCaseSource(nameof(_Dates))]
    public void ExpirationTimeCalculation_IsToday_ReturnCorrectTimeSpan(DateTime date, (int, int, int) value)
    {
        _Grocery = new Grocery(date, 10);
        Mock<IDateTimeProviderService> MockDateTimeProviderService = new();
        DateTime today = new DateTime(2020, 5, 10);
        MockDateTimeProviderService.Setup(x => x.Now).Returns(today);
        Assert.That(_Grocery.ExpirationTime(MockDateTimeProviderService.Object), Is.EqualTo(value));
    }
    private static object[] _Dates =
    {
        new object[] { new DateTime(2030, 5, 10), (10, 0, 0) },
        new object[] { new DateTime(2020, 12, 10), (0, 7, 0) },
        new object[] { new DateTime(2020, 5, 12),  (0, 0, 2) },
        new object[] { new DateTime(2020, 7, 8),  (0, 1, 27) },
        new object[] { new DateTime(2021, 4, 10), (0, 11, 0) },
        new object[] { new DateTime(2021, 4, 8), (0, 10, 28) },
        new object[] { new DateTime(2019, 5 , 10), (-1, 0, 0) },
        new object[] { new DateTime(2020, 4 , 10), (0, -1, 0) },
        new object[] { new DateTime(2020, 5 , 8), (0, 0, -2) },
        new object[] { new DateTime(2019, 4 , 8), (-1, -1, -2) }
    };
    [Test]
    [TestCase(0)]
    [TestCase(int.MaxValue)]
    public void ChangeAmount_SetValidValue_ReturnNewAmount(int amount)
    {
        _Grocery.ChangeAmount(amount);
        Assert.That(_Grocery.Amount, Is.EqualTo(amount));
    }
    [Test]
    [TestCase(-1)]
    [TestCase(int.MinValue)]
    public void ChangeAmount_SetInvalidValue_ThrowArgumentOutOfRangeException(int amount)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _Grocery.ChangeAmount(amount));
        Assert.That(ex.ParamName, Is.EqualTo("Amount"));
    }
}