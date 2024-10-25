namespace NerdStore.Core.DomainObjects;

public static class AssertionConcern
{
    public static void AssertArgumentNotNull(object object1, string message)
    {
        if (object1 == null)
            throw new DomainException(message);
    }
    
    public static void AssertArgumentNotEmpty(string stringValue, string message)
    {
        if (string.IsNullOrEmpty(stringValue))
            throw new DomainException(message);
    }
    
    public static void AssertArgumentLength(string stringValue, int maximum, string message)
    {
        var length = stringValue.Trim().Length;
        if (length > maximum)
            throw new DomainException(message);
    }
    
    public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
    {
        var length = stringValue.Trim().Length;
        if (length < minimum || length > maximum)
            throw new DomainException(message);
    }
}