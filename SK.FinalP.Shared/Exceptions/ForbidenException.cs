using System;

namespace SK.FinalP.Shared.Exceptions;

public class ForbidenException : Exception
{
    public ForbidenException()
        : base("You do not have permission to access this resource.")
    {
    }

    public ForbidenException(string message)
        : base(message)
    {
    }

    public ForbidenException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}