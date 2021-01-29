using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Homework3
{
    class MusteriManager
    {
        //Müşteri eklemeyi temsil ediyor.
        public void AddMusteri(Musteri tempMusteri)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(tempMusteri.MusteriAdi + " " + tempMusteri.MusteriSoyadi + " Adlı müşteri sisteme kaydedildi.");
            Console.WriteLine("----------------------------------------\n");
        }

        //Müşteri silmeyi temsil ediyor.
        public void DeleteMusteri(Musteri tempMusteri)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(tempMusteri.MusteriAdi + " " + tempMusteri.MusteriSoyadi + " Adlı müşteri sistemden silindi.");
            Console.WriteLine("----------------------------------------\n");
        }

        //Müşteri yazdırmayı temsil ediyor.
        public void PrintMusteri(Musteri tempMusteri)
        {
            Console.WriteLine("----------------Specific Print---------------");
            Console.WriteLine("Müşteri ID: " + tempMusteri.MusteriID + "\n");
            Console.WriteLine("Müşteri TC No: " + tempMusteri.MusteriTcNo + "\n");
            Console.WriteLine("Müşteri Adı: " + tempMusteri.MusteriAdi + "\n");
            Console.WriteLine("Müşteri Soyadı: " + tempMusteri.MusteriSoyadi + "\n");
            Console.WriteLine("Müşteri Yaşı: " + tempMusteri.MusteriYas + "\n");
            Console.WriteLine("----------------------------------------\n");
        }

        //Tüm müşterileri yazdırmayı temsi ediyor.
        //Overloading the printMusteri method.
        public void PrintMusteri(Musteri[] tempMusteriArr)
        {
            Console.WriteLine("----------------------------------------\n");
            foreach (var musteri in tempMusteriArr)
            {
                Console.WriteLine("Müşteri ID: " + musteri.MusteriID);
                Console.WriteLine("Müşteri TC No: " + musteri.MusteriTcNo);
                Console.WriteLine("Müşteri Adı: " + musteri.MusteriAdi);
                Console.WriteLine("Müşteri Soyadı: " + musteri.MusteriSoyadi);
                Console.WriteLine("Müşteri Yaşı: " + musteri.MusteriYas + "\n\n");

            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
