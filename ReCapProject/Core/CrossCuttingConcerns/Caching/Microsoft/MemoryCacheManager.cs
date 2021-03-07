using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;
using Core.Utilities.Results;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        #region Lesson Note
        /*
         *  We can't add injection by constructor because 
         *      aspects are located outside of the dependency chain of program.
         *  The chain starts with "WebAPI" and goes "Business", "DataAccess".
         *  We coded "ServiceTool" and "CoreModule" because of dependency injection.
         *  We applied adapter pattern to use .NET Core cache operations without any dependences 
         *      because avoid hard coding.
         */
        #endregion
        
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public IResult Add(string key, object value, int duration)
        {
            try
            {
                _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
                return new SuccessResult($"Key added into cache for {duration} minutes.");
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }

        public IDataResult<T> Get<T>(string key)
        {
            return new SuccessDataResult<T>(_memoryCache.Get<T>(key), "Data received from cache with generic.");
        }

        public IDataResult<object> Get(string key)
        {
            return new SuccessDataResult<object>(_memoryCache.Get(key), "Data received from cache with object.");
        }

        public IDataResult<bool> IsAdd(string key)
        {
            try
            {
                // We didn't want to return data then used "out _" to ignore data from coming method.
                return new SuccessDataResult<bool>(_memoryCache.TryGetValue(key, out _));
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(e.Message);
            }          
        }

        public IResult Remove(string key)
        {
            try
            {
                _memoryCache.Remove(key);
                return new SuccessResult("Key revomed in cache.");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult RemoveByPattern(string pattern)
        {
            try
            {
                var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
                List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

                foreach (var cacheItem in cacheEntriesCollection)
                {
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                    cacheCollectionValues.Add(cacheItemValue);
                }

                var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

                foreach (var key in keysToRemove)
                {
                    _memoryCache.Remove(key);
                }

                return new SuccessResult("Key removed with pattern in cache.");
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }
    }
}
