using System;
using Day5Homework5.Abstract;
using Day5Homework5.Concrete;
using Day5Homework5.Entities;

namespace Day5Homework5
{
    class Program
    {

        static void Main(string[] args)
        
        {
            //Games
            Game gameLOL = new Game() {ID= 00001 ,Name= "League Of Legends",Price=100,Publisher="Riot Games",ReleaseDate= new DateTime(2009, 10, 27) };
            Game gameFifa21 = new Game() { ID = 00002, Name = "Fifa 2021", Price = 200, Publisher = "EA Sports", ReleaseDate = new DateTime(2020, 10, 5) };
            //Customers
            Customer customer1 = new Customer() { ID = 10001, FirstName = "Mustafa", 
                LastName = "Sarıgül", IdentityID = "12345678910", 
                BirthDate = new DateTime(1996,3,7),Balance=1000 
            };
            Customer customer2 = new Customer() {
                ID = 10002, FirstName = "Ali",
                LastName = "Veli", IdentityID = "11111111111",
                BirthDate = new DateTime(1991, 1, 1), Balance = 1991
            };
            Customer customer3 = new Customer() {
                ID = 10003, FirstName = "Ahmet Hamdi",
                LastName = "Şeker", IdentityID = "22222222222",
                BirthDate = new DateTime(1992, 2, 2), Balance = 1992
            };
            Customer customer4 = new Customer() {
                ID = 10004, FirstName = "Ayşe Fatma",
                LastName = "Hayır", IdentityID = "33333333333",
                BirthDate = new DateTime(1993, 3, 3), Balance = 1993
            };

            //Campaigns
            Campaign campaign1 = new Campaign() {Id=01001, Name="Kdv indirimi",Discount=18};
    
            //Initialization of managers to use concrete operatios
            GameManager gameManager = new GameManager();
            ICustomerService customerManager = new CustomerManager();
            ICampaignService campaignManager = new CampaignManager();
            ICheckPersonService checkPersonManager = new MyCheckPersonManager();
            ISaleService saleManager = new SaleManager();

            //Customers added by manually.
            customerManager.Add(customer1);
            customerManager.Add(customer2);
            customerManager.Add(customer3);
            customerManager.Add(customer4);

            //Games added by manually.
            gameManager.Add(gameLOL);
            gameManager.Add(gameFifa21);

            //Campaign added by manually.
            campaignManager.Add(campaign1);

            //Customer1 bought the LOL game without any campaign.
            saleManager.Sale(customer1, gameLOL);
            
            //Customer2 bought the FİFA21 game with discount of campaign1.
            saleManager.SaleWithDiscount(customer2,gameFifa21,campaign1);

            //Printed my entities.
            gameManager.GetAllGames();
            saleManager.GetSales();
            customerManager.GetAllCustomers();
            campaignManager.GetCampaigns();
        }
    }
}
