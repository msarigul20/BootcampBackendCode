using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    //Context means that to connect database tables with project classes such as Entities.
    //Conrete classes by implementing (by inheriting from DbContext Class in Microsoft Entity Framework NuGet package) DbContext class.
    public class CarDbContext : DbContext 
    {
        //The method (OnConfiguring) provides to state that the project related to which database. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Used '@' sign because of reverse slash.
            //Server parameter takes address of database server for now in local.
            //Database  parameter takes name of database.
            //Trusted_Connection paramater provides to connect database server without username or password by taking true value.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyCarDatabase;Trusted_Connection=true");
        }
        //Initialization of tables and project entities classes with Dbset<Table> Class propery.
        //Which table will correspond which class.  
        //project classes -  Db Tables
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

    }
}
