namespace LMBES.Utilities
{
    public class Validator
    {
        public static void ValidateString(string? value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null, empty or whitespace.", paramName);
        }
        public static void ValidateInteger(int value, string paramName)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(paramName, "Value cannot be negative.");
        }
        public static void ValidateEnum<T>(T value, string paramName) where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), value))
                throw new ArgumentOutOfRangeException(paramName, $"{value} is not a valid value for {typeof(T).Name}.");
        }
        public static void ValidateObject(object? value, string paramName)
        {
            if (value == null) 
                throw new ArgumentNullException(paramName, "Value cannot be null.");
        }
    }
}
