namespace LMBES.Models
{
    public class Food
    {
        // ID = Barcode
        public int ID { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public Foodgroup? Foodgroup { get; private set; }
        public int AmountPerPackage { get; private set; }
        public enum UOMs
        {
            g = 0,
            kg = 1,
            l = 2,
            Stk = 3,
        }
        public UOMs UOM { get; private set; }
        public byte[]? Image { get; private set; }
        public Food(int id, string name, Foodgroup foodgroup, int amountPerPackage, UOMs uom,  string description = "-", byte[]? image = null)
        {
            ID = id;
            Name = name;
            Description = description;
            Foodgroup = foodgroup;
            AmountPerPackage = amountPerPackage;
            UOM = uom;
            Image = image;
        }
        public void ChangeName(string? name)
        {
            Utilities.Validator.ValidateString(name, "Name");
            Name = name;
        }
        public void ChangeDescription(string? description)
        {
            Utilities.Validator.ValidateString(description, "Description");
            Description = description;
        }
        public void ChangeFoodgroup(Foodgroup? foodgroup)
        {
            Utilities.Validator.ValidateObject(foodgroup, "Foodgroup");
            Foodgroup = foodgroup;
        }
        public void ChangeAmountPerPackage(int amountPerPackage)
        {
            Utilities.Validator.ValidateInteger(amountPerPackage, "AmountPerPackage");
            AmountPerPackage = amountPerPackage;
        }
        public void ChangeUOM(UOMs uom)
        {
            Utilities.Validator.ValidateEnum(uom, "UOM, UnitOfMeasurement");
            UOM = uom;
        }
        public void ChangeImage(byte[] image)
        {
            Image = image;
        }
    }
}