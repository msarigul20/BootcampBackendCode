using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;


namespace DataAccess.Abstract
{
    interface ICustomerDal : IEntityRepository<Customer>
    {

    }
}
