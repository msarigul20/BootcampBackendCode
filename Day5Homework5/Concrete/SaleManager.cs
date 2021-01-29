using System;
using System.Collections.Generic;
using System.Text;
using Day5Homework5.Abstract;
using Day5Homework5.Entities;

namespace Day5Homework5.Concrete
{
    class SaleManager:ISaleService
    {
        List<Sale> SaleList = new List<Sale>();
        public int counter = 100000;
        public void Sale(Customer customer, Game game)
        {
            customer.HaveGame.Add(game.Name);
            customer.Balance = customer.Balance - game.Price;
            Sale tempSale = new Sale();
            tempSale.Id = counter + 1;
            tempSale.SaleTime = DateTime.Now;
            tempSale.BuyerName = customer.FirstName + " " + customer.LastName;
            tempSale.GameName = game.Name;
            tempSale.Explanation = "Game bought without discount.";
            counter = counter + 1;
            SaleList.Add(tempSale);
        }
        public void SaleWithDiscount(Customer customer, Game game, Campaign campaign)
        {
            customer.HaveGame.Add(game.Name);        
            customer.Balance = customer.Balance - (game.Price - (game.Price * (campaign.Discount / 100)));
            Sale tempSale = new Sale();
            tempSale.Id = counter + 1;
            tempSale.SaleTime = DateTime.Now;
            tempSale.BuyerName = customer.FirstName + " " + customer.LastName;
            tempSale.GameName = game.Name;
            tempSale.Explanation = "Game bought with " + campaign.Name + " as %" + campaign.Discount + ".";
            counter = counter + 1;
            SaleList.Add(tempSale);
        }

        public void GetSales()
        {
            Console.WriteLine("************ Sale List ********************");
            foreach (var sale in SaleList) {
                Console.WriteLine("Sale ID: " + sale.Id);
                Console.WriteLine("Sale Date: " + sale.SaleTime);
                Console.WriteLine("Buyer Name: " + sale.BuyerName);
                Console.WriteLine("Game Name: " + sale.GameName);
                Console.WriteLine("Sale Explanation: " + sale.Explanation);
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine("*******************************************");
        }
    }
}
