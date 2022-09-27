using System.Globalization;

namespace CafeSimpleManagementSystem.Helpers;

public class AppException : Exception
{
    public AppException(): base() {}
    public AppException(string message): base() {}
    public AppException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
        
    }
}

