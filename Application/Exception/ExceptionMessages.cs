namespace Application.Exception;

public abstract class ExceptionMessages
{
    public static readonly Func<string, string> NullException = param => $"{param} is null";
    public static readonly Func<string, string> EmptyException = param => $"{param} is empty";
    public static readonly Func<string, string> OldDateException = param => $"{param} Date is too old";
    public static readonly Func<string, string> FutureDateException = param => $"{param} Date is future";
    public static readonly Func<string, string> TooLowValue = param => $"{param} value is too low";
    public static readonly Func<string, string> TooHighValue = param => $"{param} value is too high";
    public static readonly Func<string, string> InvalidFormat = param => $"{param} is invalid format";
}