using System;
using System.Collections.Generic;
using System.Text;

namespace Day5Homework5
{
    class MyCheckPersonManager : ICheckPersonService
    {
        public bool CheckPerson(Customer customer)
        {
            DateTime today = DateTime.Today;
            if (customer.ID>9999 && customer.FirstName != "" && customer.LastName != "" && customer.IdentityID != "" && (today.Year - customer.BirthDate.Year)>18) {
                Console.WriteLine(customer.FirstName + " " + customer.LastName + " is a person");
                return true;
            }
            else {
                Console.WriteLine("Unvalid person!");
                return false;
            }
            
        }
    }
}


