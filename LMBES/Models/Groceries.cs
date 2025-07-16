namespace LMBES.Models
{
    public class Groceries : Food
    {
        public DateTime ExpirationDate { get; private set; }
        public int Amount { get; private set; }
        public Groceries(int id, string name, Foodgroup foodgroup, DateTime expirationDate, int amountPerPackage, UOMs uom, string description, byte[]? image) : base(id, name, foodgroup, amountPerPackage, uom, description, image)
        {
            ExpirationDate = expirationDate;
        }
        public void ChangeExpirationDate (DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
        }
    }
}