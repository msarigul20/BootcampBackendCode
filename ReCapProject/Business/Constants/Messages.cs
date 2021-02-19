using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //System
        public static string MaintainceTime = "System in maintaince time.";

        //Cars
        public static string CarAdded = "New car added.";
        public static string CarsListed = "Cars listed.";
        public static string CarDailyPriceInvalid = "Car daily price must be greater than 0(Zero).";
        public static string CarDeleted = "Car Deleted.";
        public static string CarUpdated = "Car Updated.";

        //Brands
        public static string BrandNameInvalid = "Brand name invalid.(Must be 3 charachter or more)";
        public static string BrandAdded = "Brand Added.";
        public static string BrandDeleted = "Brand Deleted.";
        public static string BrandUpdated = "Brand Updated.";
        public static string BrandListed = "Brand Listed.";

        //Colors
        public static string ColorUpdated = "Color Updated.";
        public static string ColorAdded = "Color Added.";
        public static string ColorDeleted = "Color Deleted.";
        public static string ColorListed = "Color Listed.";

        //Users
        public static string UserUpdated = "User Updated.";
        public static string UserAdded = "User Added.";
        public static string UserDeleted = "User Deleted.";
        public static string UserListed = "User Listed.";

        //Customers
        public static string CustomerUpdated = "Customer Updated.";
        public static string CustomerAdded = "Customer Added.";
        public static string CustomerDeleted = "Customer Deleted.";
        public static string CustomerListed = "Customer Listed.";

        //Rentals
        public static string RentalUpdated = "Rental Updated.";
        public static string RentalAdded = "Rental Added.";
        public static string RentalDeleted = "Rental Deleted.";
        public static string RentalListed = "Rental Listed.";
        public static string RentalReturnDateNullCheck = "The rental of return date must be null to add first time.";
        public static string RentalAlreadyRented = "The car that you entered id already rented.";
        public static string RentalAlreadyCompleted = "Rental that related to you entered car id has already completed!";
        internal static string RentalCompleted = "Rental was completed and car returned succesfully.";
    }

}
