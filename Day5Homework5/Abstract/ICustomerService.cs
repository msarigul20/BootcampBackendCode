using System;
using System.Collections.Generic;
using System.Text;

namespace Day5Homework5
{
    interface ICustomerService
    {
        public void Add(Customer customer);
        public void Delete(Customer customer);
        public void Update(Customer customer);
        //public void GetCustomer(Customer customer);
        public void GetAllCustomers();
    }
}
