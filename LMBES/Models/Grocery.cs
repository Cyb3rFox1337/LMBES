using LMBES.Services;

namespace LMBES.Models
{
    public class Grocery : Food
    {
        public DateTime ExpirationDate { get; private set; }
        public int Amount { get; private set; }
        public Grocery(int id, string name, Foodgroup foodgroup, DateTime expirationDate, int amountPerPackage, UOMs uom, string description, byte[]? image) : base(id, name, foodgroup, amountPerPackage, uom, description, image)
        {
            ExpirationDate = expirationDate;
        }
        public Grocery(DateTime expirationDate, int amount) : base()
        {
            ExpirationDate = expirationDate;
            Amount = amount;
        }
        public void ChangeExpirationDate(DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
        }
        public void ChangeAmount(int amount)
        {
            Utilities.Validator.ValidateInteger(amount, "Amount");
            Amount = amount;
        }
        public (int, int, int) ExpirationTime(IDateTimeProviderService dateTimeProviderService)
        {
            DateTime now = dateTimeProviderService.Now;
            int years = ExpirationDate.Year - now.Year;
            int days = ExpirationDate.Day - now.Day;
            int months = ExpirationDate.Month - now.Month;
            if (now < ExpirationDate) 
            {
                if (months < 0)
                {
                    months += 12;
                    years -= 1;
                }
                if (days < 0)
                {
                    days += DateTime.DaysInMonth(now.Year, months);
                    months -= 1;
                }
            }
            return (years, months, days);
        }
    }
}