using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //The first step for basic void methods.
        bool Success { get; }
        string Message { get; }
    }
}
