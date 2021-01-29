using System;
using System.Collections.Generic;

namespace Day5Homework5
{
    class CustomerManager:ICustomerService
    {
        List<Customer> customerList = new List<Customer>();
        public void Add(Customer customer)
        {
            ICheckPersonService myPersonChecker = new MyCheckPersonManager();
            if (myPersonChecker.CheckPerson(customer)) {
                customerList.Add(customer);
                System.Console.WriteLine(customer.FirstName +" "+ customer.LastName + " added the system.");
            }
            else {
                System.Console.WriteLine("Person couldn't add.");
            }

        }
        public void Delete(Customer customer)
        {
            customerList.Remove(customer);
            System.Console.WriteLine(customer.FirstName + " " + customer.LastName + " deleted the system.");
        }
        public void Update(Customer customer)
        {
            System.Console.WriteLine(customer.FirstName + " " + customer.LastName + "updated the system.");
        }
      
        public void GetAllCustomers()
        {
            Console.WriteLine("************ Customer List ********************");
            foreach (var customer in customerList) {
                System.Console.WriteLine("Customer Name: " + customer.FirstName + customer.LastName);
                System.Console.WriteLine("Customer Identity Number: " + customer.IdentityID);
                System.Console.WriteLine("Customer Birth Date: " + customer.BirthDate);
                System.Console.WriteLine("Customer Balance: " + customer.Balance + "TL");
                System.Console.WriteLine("Have these games : ");
                foreach (var game in customer.HaveGame) {
                    System.Console.WriteLine(game);
                }
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine("*******************************************");

        }
    }
}
