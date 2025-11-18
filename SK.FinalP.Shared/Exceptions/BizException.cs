using System;

namespace SK.FinalP.Shared.Exceptions;

public class BizException : Exception
{
    public BizException()
        : base("A business exception has occurred.")
    {
    }

    public BizException(string message)
        : base(message)
    {
    }

    public BizException(string message, Exception inner)
        : base(message, inner)
    {
    }
}