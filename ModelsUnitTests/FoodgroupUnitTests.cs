using LMBES.Models;

namespace ModelsUnitTests;
public class FoodgroupUnitTests
{
    Foodgroup _Foodgroup;
    [SetUp]
    public void Setup()
    {
        _Foodgroup = new Foodgroup("Name", "Description");
    }

    [Test]
    [TestCase("Suppe")]
    public void ChangeName_SetValidValue_ReturnNewName(string name)
    {
        _Foodgroup.ChangeName(name);
        Assert.That(_Foodgroup.Name, Is.EqualTo(name));
    }
    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void ChangeName_SetInvalidValue_ThrowArgumentException(string? name)
    {
        var ex = Assert.Throws<ArgumentException>(() => _Foodgroup.ChangeName(name));
        Assert.That(ex.ParamName, Is.EqualTo("Name"));
    }
    [Test]
    [TestCase("Flüssige Mahlzeit")]
    public void ChangeDescription_SetValidValue_ReturnDescription(string description)
    {
        _Foodgroup.ChangeName(description);
        Assert.That(_Foodgroup.Name, Is.EqualTo(description));
    }
    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void ChangeDescription_SetInvalidValue_ThrowArgumentException(string? description)
    {
        var ex = Assert.Throws<ArgumentException>(() => _Foodgroup.ChangeDescription(description));
        Assert.That(ex.ParamName, Is.EqualTo("Description"));
    }
}