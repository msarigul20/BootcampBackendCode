using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    #region Lesson Note
    /*
     *  The interceptors can execute specific time for operations. So that if you want  to control all methods 
     *      of project in a one center, you need to write related code in SelectInterceptors method like as 
     *      classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); for logging every method or 
     *      classAttributes.Add(new PerformanceAspect(5)); for performing every method and warn for 5 seconds to coder.
     */
    #endregion
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //This methods related to all methods of project to use interceptor that are execute specific time of operations.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
