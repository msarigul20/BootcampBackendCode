using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //The first step for basic void methods.
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
