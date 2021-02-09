using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // A class that carries the sql commands.
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}
