using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        /*
         * In 10 line, A base(value1,value2) code sent the message that comes to parameter and 
             true data type to constroctor of base (Result) class so that the coder used object of this class
             to create successful result to inform the user with one parameter that is message.
        */
        public SuccessResult(string message) : base(true,message)
        {
        }

        // Same mentality used above, user can create succesfull object without message
        //   by calling the base (result) class constructor that has one parameter in Result(base) class.
        public SuccessResult():base(true)
        {
        }
    }
}
