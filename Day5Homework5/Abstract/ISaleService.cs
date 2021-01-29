using System;
using System.Collections.Generic;
using System.Text;
using Day5Homework5.Entities;

namespace Day5Homework5.Abstract
{
    interface ISaleService
    {
        public void Sale(Customer customer, Game game);
        public void SaleWithDiscount(Customer customer, Game game, Campaign campaign);
        public void GetSales();    
    
    }
}
