using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersizdir.";
        public static string MaintainceTime = "Sistem bakımdadır.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride 10'dan fazla ürn var. Ürün Eklenemedi.";
        public static string ProductNameAlreadyExists = "Zaten bu isimde bir ürün bulunuyor.";
        public static string CategoryLimitExceded = "Kategori sınırı aşıldı.";
        public static string AuthorizationDenied = "Authorization has been denied.";
        public static string UserNotFound= "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string UserRegistered = "UserRegistered";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserAlreadyExists= "UserAlreadyExists";
        public static string AccessTokenCreated= "AccessTokenCreated";
    }
}
