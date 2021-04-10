using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    #region Lesson Note
    /*  Context means that to connect database tables with project classes such as Entities.
     *  Conrete classes by implementing (by inheriting from DbContext Class in Microsoft Entity 
     *      Framework NuGet package) DbContext class.
     *  In connectionString that is parameter of UseSqlServer clues:
     *      Used '@' sign because of reverse slash.
     *      Server parameter takes address of database server for now in local, 
     *          it'll be ip address in future.
     *      Database  parameter takes name of database.
     *      Trusted_Connection paramater provides to connect database server without username or 
     *          password by taking true value.
     *  Properties of this class provide to connect database tables with project classes.
     *      Which table will correspond which class like as {DbSet<ProjectClassName> DbTableName}.  
     */
    #endregion

    public class CarDbContext : DbContext 
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<FakeCard> FakeCards { get; set; }

        //The method (OnConfiguring) provides to state that the project related to which database. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyCarDatabase;Trusted_Connection=true");
        }
        

    }
}
