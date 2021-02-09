using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    /* 
     * Generic Constraint (Limit Type of Generic Class)
     * Class: means it must be reference type (ignored int, string, decimal, etc.)
     * IEntity: means it must be IEntity or object that is belongs to class that implemented IEntitiy.(ignored exeption class, math class, etc.)
     * new(): means it must be non-abstract object such that we can crate object with new key.(ignored IEntity class {interface} because of the abstract architecture.)
     * There are just classes that are located concrete folder that is connected to Entities classes such as Category, Customer and Product for now.
     * There are symbolised the tables of database that called our entities.
     */

    /*
     * Core layer DOES NOT take a reference from other layers. (STAR NOTE)
     * If it takes a reference, core layer will dependent on the layer that takes a reference.
     * This means that you can not generate universal section to use different independent of each other projects.
     */
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
