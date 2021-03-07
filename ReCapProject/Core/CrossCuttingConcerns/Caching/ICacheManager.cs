using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        IDataResult<T> Get<T>(string key);

        //It is not generic version (but base of everthing) to get so that should make type conversion.
        IDataResult<object> Get(string key);
        IResult Add(string key, object value, int duration);
        IDataResult<bool> IsAdd(string key);
        IResult Remove(string key);
        IResult RemoveByPattern(string pattern);
    }
}
