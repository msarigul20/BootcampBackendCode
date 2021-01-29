using System;

namespace ClassIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            string adi = "Engin";
            int yas = 36;

            Kurs kurs1 = new Kurs();
            kurs1.KursAdi = "C#";
            kurs1.Egitmen = "Engin Demiroğ";
            kurs1.IzlenmeOrani = 85;

            Kurs kurs2 = new Kurs();
            kurs2.KursAdi = "C++";
            kurs2.Egitmen = "Ali Kaya";
            kurs2.IzlenmeOrani = 25;

            Kurs kurs3 = new Kurs();
            kurs3.KursAdi = "C";
            kurs3.Egitmen = "Ayşe Bulut";
            kurs3.IzlenmeOrani = 95;

            //Console.WriteLine(kurs1.KursAdi +" "+ kurs1.Egitmen +" "+ kurs1.IzlenmeOrani);
            Kurs[] kurslar = new Kurs[] { kurs1, kurs2, kurs3 };
            foreach (Kurs tempKurs in kurslar)
            {
                Console.WriteLine("Kurs Adı: " + tempKurs.KursAdi + "\n");
                Console.WriteLine("Eğitmen Adı: " + tempKurs.Egitmen + "\n");
                Console.WriteLine("İzlenme Oranı: " + tempKurs.IzlenmeOrani + "\n");
                Console.WriteLine("**--**--**--***----*-*-*");
            }

        }
    }
    class Kurs
    {
        public string KursAdi { get; set; }
        public string Egitmen { get; set; }
        public int IzlenmeOrani { get; set; }

    }
}
