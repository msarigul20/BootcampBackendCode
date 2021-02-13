using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Readonly Property Injection
        //Getter mehthos are readonly so that they can set with using constructor. 

        /*
         * In this point, when the coder calls Result constructor with two parameter, the method that starts on 15 line works and 
            take the paramaters then will Message that is local property sets with the message that is coming from parameter.And later,
            the Result constructor that takes one parameter will work and takes the success property that is comes as a parameter because of
            code piece in line 20 that is " :this(succcess) ".This means that call the constructor with one paramameter.Also, can call 
            constructer that has different number of parameter except those with the same number of parameters with itself because
            this means that you created infinitelly loop after all the compailer will warn the user and not compaile the code.        
         */
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        //Constructor Overloaded
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
