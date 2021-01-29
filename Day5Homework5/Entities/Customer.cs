using System;
using System.Collections.Generic;

namespace Day5Homework5
{
    
    class Customer
    {
        public Customer()
        {
            HaveGame = new List<string>();
        }
        public int ID { get; set; }
        public string IdentityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Balance { get; set; }
        public List<string> HaveGame;

    }
    

}
