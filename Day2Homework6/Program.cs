using System;

namespace Day2Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            //defined first product.
            Product Pr1 = new Product();
            Pr1.ProductID = 00001;
            Pr1.ProductStars = 3;
            Pr1.ProductImage = "/images/img1.jpg";
            Pr1.ProductName = "Lenovo V15 - ADA AMD Ryzen 5 3500U 8GB 512GB " +
                "SSD Freedos 15.6" +
                (char)34 +
                "FHD Taşınabilir Bilgisayar 82C700C6TXR";
            Pr1.ProductSupplier = "A Sistem";
            Pr1.ProductExplanation = "V15 dizüstü bilgisayarın çift depolama " +
                "seçenekleri ve isteğe bağlı üretkenliğe yardımcı oluyor; entegre " +
                "üretici yazılımı (Güvenilir Platform Modülü (TPM) 2.0) ise " +
                "verileri ve parolaları şifreleyerek elde edilen işi güvende tutuyor.";
            Pr1.ProductBasePrice = 7199.00F;
            Pr1.ProductDiscount = 25.00F;
            Pr1.ProductCurrentPrice = Pr1.ProductBasePrice -
                (Pr1.ProductBasePrice * (Pr1.ProductDiscount / 100));

            //defined second product.
            Product Pr2 = new Product();
            Pr2.ProductID = 00002;
            Pr2.ProductStars = 5;
            Pr2.ProductImage = "/images/img2.jpg";
            Pr2.ProductName = "Xiaomi Mi Curved BHR4269GL 34" +
                (char)34 +
                "144Hz 4ms (HDMI+Display) FreeSync WQHD Led Monitör";
            Pr2.ProductSupplier = "B Technics";
            Pr2.ProductExplanation = "Geniş görüş alanı ve ultra yüksek çözünürlüklü," +
                " pürüzsüz görüntü, kontrolü hareketin merkezine koymanızı sağlar.";
            Pr2.ProductBasePrice = 4699.00F;
            Pr2.ProductDiscount = 18.50F;
            Pr2.ProductCurrentPrice = Pr2.ProductBasePrice -
                (Pr2.ProductBasePrice * (Pr2.ProductDiscount / 100));

            //defined third product.
            Product Pr3 = new Product();
            Pr3.ProductID = 00003;
            Pr3.ProductStars = 4;
            Pr3.ProductImage = "/images/img3.jpg";
            Pr3.ProductName = "POCO X3 NFC 128 GB (POCO Türkiye Garantili)";
            Pr3.ProductSupplier = "C Supplier";
            Pr3.ProductExplanation = "Henüz çok genç bir telefon markası olan POCO, " +
                "üst sınıf telefonlara meydan okuyan modelleriyle kullanıcıların büyük" +
                " beğenisini kazanıyor. POCO, piyasaya sunduğu son akıllı telefon POCO " +
                "X3 NFC 128 GB ile yine iddiasını ortaya koyuyor";
            Pr3.ProductBasePrice = 3899.00F;
            Pr3.ProductDiscount = 19F;
            Pr3.ProductCurrentPrice = Pr3.ProductBasePrice -
                (Pr3.ProductBasePrice * (Pr3.ProductDiscount / 100));

            //initialized list of products.
            Product[] ProductList = new Product[] { Pr1, Pr2, Pr3 };

            //listing product list by using for loop.
            for (int i = 0; i < ProductList.Length; i++)
            {

                Console.WriteLine("--------------------FOR LOOP-------------------------");
                Console.WriteLine("Product ID: " + ProductList[i].ProductID);
                Console.WriteLine("Product Name: " + ProductList[i].ProductName);
                Console.WriteLine("Product Image: " + ProductList[i].ProductImage);
                Console.WriteLine("Product Supplier: " + ProductList[i].ProductSupplier);
                Console.WriteLine("Product Stars: " + ProductList[i].ProductStars + " Star(s)");
                Console.WriteLine("Product Current Price: " + ProductList[i].ProductCurrentPrice + " TL");
                Console.WriteLine("Product Discount: %" + ProductList[i].ProductDiscount);
                Console.WriteLine("Product Previous Price: " + ProductList[i].ProductBasePrice + " TL");
                Console.WriteLine("Product Explanation: " + ProductList[i].ProductExplanation);
                Console.WriteLine("--------------------FOR LOOP-------------------------\n");
            }

            //listing product list by using while loop.
            int index = 0;
            while (index < ProductList.Length)
            {
                Console.WriteLine("--------------------WHILE LOOP---------------------------");
                Console.WriteLine("Product ID: " + ProductList[index].ProductID);
                Console.WriteLine("Product Name: " + ProductList[index].ProductName);
                Console.WriteLine("Product Image: " + ProductList[index].ProductImage);
                Console.WriteLine("Product Supplier: " + ProductList[index].ProductSupplier);
                Console.WriteLine("Product Stars: " + ProductList[index].ProductStars + " Star(s)");
                Console.WriteLine("Product Current Price: " + ProductList[index].ProductCurrentPrice + " TL");
                Console.WriteLine("Product Discount: %" + ProductList[index].ProductDiscount);
                Console.WriteLine("Product Previous Price: " + ProductList[index].ProductBasePrice + " TL");
                Console.WriteLine("Product Explanation: " + ProductList[index].ProductExplanation);
                Console.WriteLine("--------------------WHILE LOOP---------------------------\n");
                // updated condition
                index++;
            }

            //listing product list by using foreach loop
            foreach (Product TempProduct in ProductList)
            {
                Console.WriteLine("--------------------FOREACH LOOP---------------------------");
                Console.WriteLine("Product ID: " + TempProduct.ProductID);
                Console.WriteLine("Product Name: " + TempProduct.ProductName);
                Console.WriteLine("Product Image: " + TempProduct.ProductImage);
                Console.WriteLine("Product Supplier: " + TempProduct.ProductSupplier);
                Console.WriteLine("Product Stars: " + TempProduct.ProductStars + " Star(s)");
                Console.WriteLine("Product Current Price: " + TempProduct.ProductCurrentPrice + " TL");
                Console.WriteLine("Product Discount: %" + TempProduct.ProductDiscount);
                Console.WriteLine("Product Previous Price: " + TempProduct.ProductBasePrice + " TL");
                Console.WriteLine("Product Explanation: " + TempProduct.ProductExplanation);
                Console.WriteLine("--------------------FOREACH LOOP---------------------------\n");
            }
        }
    }
    class Product
    {
        //initialized properies of Product class to identify.
        public int ProductID { get; set; }
        public int ProductStars { get; set; }
        public string ProductImage { get; set; }
        // Used string like "/images/img1.jpg" because of as an example.
        public string ProductName { get; set; }
        public string ProductSupplier { get; set; }
        public string ProductExplanation { get; set; }
        public float ProductBasePrice { get; set; }
        public float ProductDiscount { get; set; }
        public float ProductCurrentPrice { get; set; }


    }
}
