using LMBES.Models;
using Newtonsoft.Json;

namespace ModelsUnitTests
{
    public class Tests
    {
        private Foodgroup _Foodgroup;
        private Food _Food;
        [SetUp]
        public void Setup()
        {
            _Foodgroup = new Foodgroup("Name");
            _Food = new Food(100, "Name", _Foodgroup, 400, Food.UOMs.g);
        }
        [Test]
        [TestCase("Tomatensuppe")]
        public void ChangeName_SetValidValue_ReturnNewName(string name)
        {
            _Food.ChangeName(name);
            Assert.That(_Food.Name, Is.EqualTo(name));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ChangeName_SetInvalidValue_ThrowArgumentException(string? name)
        {
            var ex = Assert.Throws<ArgumentException>(() => _Food.ChangeName(name));
            Assert.That(ex.ParamName, Is.EqualTo("Name"));
        }
        [Test]
        [TestCase("Suppe aus Tomaten")]
        public void ChangeDescription_SetValidValue_ReturnDescription(string description)
        {
            _Food.ChangeName(description);
            Assert.That(_Food.Name, Is.EqualTo(description));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ChangeDescription_SetInvalidValue_ThrowArgumentException(string? description)
        {
            var ex = Assert.Throws<ArgumentException>(() => _Food.ChangeDescription(description));
            Assert.That(ex.ParamName, Is.EqualTo("Description"));
        }
        [Test]
        [TestCaseSource(nameof(Foodgroups))]
        public void ChangeFoodgroup_SetValidValue_ReturnNewFoodgroup(Foodgroup foodgroup)
        {
            _Food.ChangeFoodgroup(foodgroup);
            var actual = JsonConvert.SerializeObject(_Food.Foodgroup);
            var expected = JsonConvert.SerializeObject(foodgroup);
            Assert.That(actual, Is.EqualTo(expected));
        }
        private static object[] Foodgroups =
        {
            new object[] { new Foodgroup("Gemüse") },
            new object[] { new Foodgroup("Obst") }
        };
        [Test]
        [TestCase(0)]
        [TestCase(int.MaxValue)]
        public void ChangeAmountPerPackage_SetValidValue_ReturnNewAmountPerPackage(int amountPerPackage)
        {
            _Food.ChangeAmountPerPackage(amountPerPackage);
            Assert.That(_Food.AmountPerPackage, Is.EqualTo(amountPerPackage));
        }
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        public void ChangeAmountPerPackage_SetValidValue_ThrowArgumentOutOfRangeException(int amountPerPackage)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _Food.ChangeAmountPerPackage(amountPerPackage));
            Assert.That(ex.ParamName, Is.EqualTo("AmountPerPackage"));
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(Food.UOMs.g)]
        [TestCase(Food.UOMs.kg)]
        [TestCase(Food.UOMs.l)]
        [TestCase(Food.UOMs.Stk)]
        public void ChangeUOM_SetValidValue_ReturnNewUOM(Food.UOMs uom)
        {
            _Food.ChangeUOM(uom);
            Assert.That(_Food.UOM, Is.EqualTo(uom));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(99)]
        public void ChangeUOM_SetInvalidValue_ThrowArgumentOutOfRangeException(Food.UOMs uom)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _Food.ChangeUOM(uom));
            Assert.That(ex.ParamName, Is.EqualTo("UOM, UnitOfMeasurement"));
        }
    }
}