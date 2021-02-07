using Entities.Concrete;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    /* 
     * Generic Constraint (Limit Type of Generic Class)
     * Class: means it must be reference type (ignored int, string, decimal, etc.)
     * IEntity: means it must be IEntity or object that is belongs to class that 
        implemented IEntitiy.(ignored exeption class, math class, etc.)
     * new(): means it must be non-abstract object such that we can crate object with new key.
        (ignored IEntity class {interface} because of the abstract architecture.)
     * There are just classes that are located concrete folder that is connected to Entities 
        classes such as Category, Customer and Product for now.
     * There are symbolised the tables of database that called our entities.
     */
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entitiy);
    }
}
