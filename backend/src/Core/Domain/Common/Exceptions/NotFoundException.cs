﻿namespace Domain.Common.Exceptions;

public class NotFoundException : CommonException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }
    

    public NotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
