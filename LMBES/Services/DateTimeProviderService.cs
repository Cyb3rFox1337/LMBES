namespace LMBES.Services
{
    public interface IDateTimeProviderService
    {
        DateTime Now { get; }
    }
    public class DateTimeProviderService : IDateTimeProviderService
    {
        public virtual DateTime Now => DateTime.Now;
    }
}
