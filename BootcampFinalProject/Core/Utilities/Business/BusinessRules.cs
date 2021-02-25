using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules 
    {
        public static IResult Run(params IResult[] logics)
        {
            //Diğer yöntem
            //List<IResult> errorResults = new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                    //errorResults.Add(logic);
                }
            }
            return null;
            //return errorResults;
        }
    }
}
